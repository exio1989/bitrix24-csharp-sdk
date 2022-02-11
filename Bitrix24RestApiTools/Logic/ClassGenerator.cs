using Bitrix24RestApiClient.Models.Core.Response.FieldsResponse;
using Humanizer;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bitrix24RestApiTools
{
    public class ClassGenerator
    {
        public string GenerateModelClass(string description, string className, Dictionary<string, FieldInfo> fields)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"#nullable enable");
            sb.AppendLine($"using Bitrix24RestApiClient.Models.Core.Attributes;");
            sb.AppendLine($"using Bitrix24RestApiClient.Models.Core.Enums;");
            sb.AppendLine($"using Newtonsoft.Json;");
            sb.AppendLine($"");
            sb.AppendLine($"namespace G_{className}");
            sb.AppendLine("{");
            sb.AppendLine("\t/// <summary>");
            sb.AppendLine($"\t/// {description}");
            sb.AppendLine("\t/// </summary>");
            sb.AppendLine($"\tpublic class {className}");
            sb.AppendLine("\t{");

            HashSet<string> duplicateFieldNames = GetDuplicatedPropertyNames(fields);

            foreach (KeyValuePair<string, FieldInfo> field in fields)
            {
                string propertyName = GetPropertyName(field, duplicateFieldNames);

                sb.AppendLine("\t\t/// <summary>");
                sb.AppendLine($"\t\t/// {(field.Value.IsDynamic ? field.Value.ListLabel : field.Value.Title)}");
                sb.AppendLine($"\t\t/// Тип: {field.Value.TypeExt}");
                
                if(field.Value.IsRequired)
                    sb.AppendLine($"\t\t/// Обязательное поле");
                
                if (field.Value.IsReadOnly)
                    sb.AppendLine($"\t\t/// Только для чтения");

                sb.AppendLine("\t\t/// </summary>");
                sb.AppendLine($"\t\t[JsonProperty({className}Fields.{propertyName})]");
                sb.AppendLine($"\t\tpublic {field.Value.TypeCSharp} {propertyName} {"{"} get; set; {"}"}");
                sb.AppendLine("");
            }
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public string GenerateFieldNamesClass(string className, Dictionary<string, FieldInfo> fields)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"namespace G_{className}");
            sb.AppendLine("{");
            sb.AppendLine($"\tpublic static class {className}Fields");
            sb.AppendLine("\t{");

            HashSet<string> duplicateFieldNames = GetDuplicatedPropertyNames(fields);

            foreach (KeyValuePair<string, FieldInfo> field in fields)
            {
                string propertyName = GetPropertyName(field, duplicateFieldNames);
                string key = field.Value.UpperName != null
                    ? field.Value.UpperName
                    : field.Key;

                sb.AppendLine($"\t\tpublic const string {propertyName} = \"{key}\";");
            }
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        public string GenerateContainerClass(string description, string className, Dictionary<string, FieldInfo> fields)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"namespace G_{className}");
            sb.AppendLine("{");
            sb.AppendLine("\t/// <summary>");
            sb.AppendLine($"\t/// {description}");
            sb.AppendLine("\t/// </summary>");
            sb.AppendLine($"\tpublic class {className}s: AbstractEntities<{className}>");
            sb.AppendLine("\t{");
            sb.AppendLine($"\t\tpublic {className}s(IBitrix24Client client)");
            sb.AppendLine($"\t\t\t:base(client, EntryPointPrefix.{className})");
            sb.AppendLine("\t\t{");
            sb.AppendLine("\t\t}");
            sb.AppendLine("\t}");
            sb.AppendLine("}");
            return sb.ToString();
        }

        private HashSet<string> GetDuplicatedPropertyNames(Dictionary<string, FieldInfo> fields)
        {
            return fields
                .Select(x => GetPropertyName(x))
                .GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .ToHashSet();
        }

        private string GetPropertyName(KeyValuePair<string, FieldInfo> field, HashSet<string> duplicatedPropertyNames = null)
        {
            string keyName = field.Value.UpperName != null
                ? field.Value.UpperName.Transform(To.LowerCase, To.TitleCase).Dehumanize()
                : field.Key.Transform(To.LowerCase, To.TitleCase).Dehumanize();
            string titleName = field.Value.ListLabel?.Transform(To.LowerCase, To.TitleCase)?.Dehumanize();

            string name = field.Value.IsDynamic
                    ? titleName
                    : keyName;

            return duplicatedPropertyNames != null && duplicatedPropertyNames.Contains(titleName)
                ? $"{titleName}_{keyName}"
                : name;
        }
    }
}
