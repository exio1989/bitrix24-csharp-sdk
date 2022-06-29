using PowerArgs;
using System.IO;
using Humanizer;
using System.Linq;
using System.Threading.Tasks;
using Bitrix24RestApiClient.Api;
using System.Collections.Generic;
using Bitrix24RestApiTools.Models;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;
using Bitrix24RestApiClient.Core.Models.Response.SmartProcessResponse;

namespace Bitrix24RestApiTools
{
    [ArgExceptionBehavior(ArgExceptionPolicy.StandardExceptionHandling)]
    public class ConsoleApp
    {
        [HelpHook, ArgShortcut("-?"), ArgDescription("Shows this help")]
        public bool Help { get; set; }

        [ArgActionMethod, ArgShortcut("-g"), ArgDescription("Generate model by fields info")]
        public async Task GenerateModelByFields(GenerateModelArgs args)
        {
            var client = new Bitrix24Client(args.WebhookUrl, new ConsoleLogger<Bitrix24Client>());
            object body = args.EntityTypeId == null
                ? new { }
                : new { entityTypeId = args.EntityTypeId };

            Dictionary<string, FieldInfo> fields;
            if (args.ResponseClass == "FieldsResponse")
            {
                FieldsResponse response = await client.SendPostRequest<object, FieldsResponse>(new EntryPointPrefix(args.FieldsEntryPoint), EntityMethod.None, body);
                fields = response.Result;
            }
            else if(args.ResponseClass == "UserFieldsResponse")
            {
                UserFieldsResponse response = await client.SendPostRequest<object, UserFieldsResponse>(new EntryPointPrefix(args.FieldsEntryPoint), EntityMethod.None, body);
                fields = response.Result.Select(x=> new FieldInfo
                {
                    Title = x.Value,
                    UpperName = x.Key,
                    Type = CrmFieldTypeEnum.String
                }).ToDictionary(x=>x.UpperName);
            }
            else
            {
                ExtFieldsResponse response = await client.SendPostRequest<object, ExtFieldsResponse>(new EntryPointPrefix(args.FieldsEntryPoint), EntityMethod.None, body);
                fields = response.Fields.Result;
                foreach(var field in fields)
                {
                    field.Value.UpperName = field.Key;
                }
            }

            var classGenerator = new ClassGenerator();
            
            string outputPath = args.OutputPath;
            if(!Directory.Exists(outputPath))
                Directory.CreateDirectory(outputPath);

            string outputModelsPath = Path.Combine(args.OutputPath, "Models");
            if (!Directory.Exists(outputModelsPath))
                Directory.CreateDirectory(outputModelsPath);

            string modelClassCode = classGenerator.GenerateModelClass(args.ClassDescription, args.ClassName, fields);
            await File.WriteAllTextAsync(Path.Combine(outputModelsPath, $"{args.ClassName}.cs"), modelClassCode);

            string fielNamesClassCode = classGenerator.GenerateFieldNamesClass(args.ClassName, fields);
            await File.WriteAllTextAsync(Path.Combine(outputModelsPath, $"{args.ClassName}Fields.cs"), fielNamesClassCode);

            string containerClassCode = classGenerator.GenerateContainerClass(args.ClassDescription, args.ClassName, fields);
            await File.WriteAllTextAsync(Path.Combine(outputPath, $"{args.ClassName}s.cs"), containerClassCode);
        }

        [ArgActionMethod, ArgShortcut("-gall"), ArgDescription("Generate all models by fields info")]
        public async Task GenerateAllModelsByFields(GenerateAllModelsArgs args)
        {
            var models = new List<ClassGeneratorArgs>
            {
                new ClassGeneratorArgs {description= "Cделки", className= "Deal", entryPoint= "crm.deal.fields", dirs= new List<string> { "Crm", "Deal" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Контакты", className= "Contact", entryPoint= "crm.contact.fields", dirs= new List<string> { "Crm", "Contact" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Лиды", className= "Lead", entryPoint= "crm.lead.fields", dirs= new List<string> { "Crm", "Lead" }, responseClass= "FieldsResponse" },
                 new ClassGeneratorArgs {description= "Компании", className= "Company", entryPoint= "crm.company.fields", dirs= new List<string> { "Crm", "Company" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Контакыт компаний", className= "CompanyContact", entryPoint= "crm.company.contact.fields", dirs= new List<string> { "Crm", "Company", "Contact" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Компании контактов", className= "ContactCompany", entryPoint= "crm.contact.company.fields", dirs= new List<string> { "Crm", "Contact", "Company" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Направления сделок, устаревшее", className= "DealCategory", entryPoint= "crm.dealcategory.fields", dirs= new List<string> { "Crm", "DealCategory" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Статусы счетов", className= "InvoiceStatus", entryPoint= "crm.invoice.status.fields", dirs= new List<string> { "Crm", "Invoice", "Status" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Коммерческие предложения", className= "Quote", entryPoint= "crm.quote.fields", dirs= new List<string> { "Crm", "Quote" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Счета (старые}", className= "Invoice", entryPoint= "crm.invoice.fields", dirs= new List<string> { "Crm", "Invoice" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Регулярные счета", className= "InvoiceRecurring", entryPoint= "crm.invoice.recurring.fields", dirs= new List<string> { "Crm", "Invoice", "Recurring" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Способы оплат", className= "PaySystem", entryPoint= "crm.paysystem.fields", dirs= new List<string> { "Crm", "PaySystem" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Типы плательщиков", className= "PersonType", entryPoint= "crm.persontype.fields", dirs= new List<string> { "Crm", "PersonType" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Привязки элементов crm в таймлайне", className= "TimelineBindings", entryPoint= "crm.timeline.bindings.fields", dirs= new List<string> { "Crm", "Timeline", "Bindings" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Комментарии таймлайна", className= "TimelineComment", entryPoint= "crm.timeline.comment.fields", dirs= new List<string> { "Crm", "Timeline", "Comment" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Дела. Дела описывают выполненную, текущую и запланированную работу по лидам, контактам, компаниям и сделкам. Делятся на звонки, встречи и e-mail сообщения.", className= "Activity", entryPoint= "crm.activity.fields", dirs= new List<string> { "Crm", "Activity" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Коммуникации для активности. Коммуникации хранят номера телефонов в звонках, email-адреса в письмах, имена во встречах.", className= "ActivityCommunication", entryPoint= "crm.activity.communication.fields", dirs= new List<string> { "Crm", "Activity", "Communication" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Адреса реквизитов", className= "Address", entryPoint= "crm.address.fields", dirs= new List<string> { "Crm", "Address" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Реквизиты", className= "Requisite", entryPoint= "crm.requisite.fields", dirs= new List<string> { "Crm", "Requisite" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Банковские реквизиты", className= "RequisiteBankdetail", entryPoint= "crm.requisite.bankdetail.fields", dirs= new List<string> { "Crm", "Requisite", "Bankdetail" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Связи реквизитов. Связи определяют, какие реквизиты выбраны для сделки, предложения или счёта. При этом реквизиты должны принадлежать выбранной компании или контакту. Так, если в счёте в качестве покупателя выбрана компания, то реквизиты покупателя должны принадлежать этой компании. В качестве продавца может быть выбрана только компания из справочника \"Реквизиты ваших компаний\".", className= "RequisiteLink", entryPoint= "crm.requisite.link.fields", dirs= new List<string> { "Crm", "Requisite", "Link" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Шаблоны реквизитов", className= "RequisitePreset", entryPoint= "crm.requisite.preset.fields", dirs= new List<string> { "Crm", "Requisite", "Preset" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Список полей из набора полей шаблона для определенного реквизита.", className= "RequisitePresetField", entryPoint= "crm.requisite.preset.field.fields", dirs= new List<string> { "Crm", "Requisite", "Preset", "Field" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Пользовательские поля", className= "Userfield", entryPoint= "crm.userfield.fields", dirs= new List<string> { "Crm", "Userfield" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Каталог товаров", className= "Catalog", entryPoint= "crm.catalog.fields", dirs= new List<string> { "Crm", "Catalog" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Валюты", className= "Currency", entryPoint= "crm.currency.fields", dirs= new List<string> { "Crm", "Currency" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Локализаций для валют", className= "CurrencyLocalizations", entryPoint= "crm.currency.localizations.fields", dirs= new List<string> { "Crm", "Currency", "Localizations" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Единицы измерения", className= "Measure", entryPoint= "crm.measure.fields", dirs= new List<string> { "Crm", "Measure" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Разделы товаров", className= "ProductSection", entryPoint= "crm.productsection.fields", dirs= new List<string> { "Crm", "ProductSection" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Товарные позиции (старые}", className= "ProductRowOld", entryPoint= "crm.productrow.fields", dirs= new List<string> { "Crm", "ProductRowOld" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Товарные позиции", className= "ProductRow", entryPoint= "crm.item.productrow.fields", dirs= new List<string> { "Crm", "ProductRow" }, responseClass= "ExtFieldsResponse" },
                new ClassGeneratorArgs {description= "Товары", className= "Product", entryPoint= "crm.product.fields", dirs= new List<string> { "Crm", "Product" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Свойства товар", className= "ProductProperty", entryPoint= "crm.product.property.fields", dirs= new List<string> { "Crm", "Product", "Property" }, responseClass= "FieldsResponse" },
                //new ClassGeneratorArgs {description= "Описание полей дополнительных настроек свойства товаров пользовательского типа", className= "ProductPropertySettings", entryPoint= "crm.product.property.settings.fields", dirs= new List<string> { "Crm", "Product", "Property", "Settings" }, responseClass= "ExtFieldsResponse" },
                new ClassGeneratorArgs {description= "Множественные поля", className= "Multifield", entryPoint= "crm.multifield.fields", dirs= new List<string> { "Crm", "Multifield" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Перечисления", className= "Enum", entryPoint= "crm.enum.fields", dirs= new List<string> { "Crm", "Enum" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Справочники", className= "Status", entryPoint= "crm.status.fields", dirs= new List<string> { "Crm", "Status" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Ставки НДС", className= "Vat", entryPoint= "crm.vat.fields", dirs= new List<string> { "Crm", "Vat" }, responseClass= "FieldsResponse" },
                new ClassGeneratorArgs {description= "Типы смарт-процессов", className= "SmartProcessType", entryPoint= "crm.type.fields", dirs= new List<string> { "Crm", "SmartProcessType" }, responseClass= "ExtFieldsResponse"},
                new ClassGeneratorArgs {description= "Пользователи", className= "User", entryPoint= "user.fields", dirs= new List<string> { "User" }, responseClass= "UserFieldsResponse"}
            };

            //Направления требуют указания entityTypeId
            //(description: "Направления", className: "Category", entryPoint: "crm.category.fields", dirs: new List<string> { "Crm", "Category", "Models" }),
            //EntityTypeIdEnum
            var client = new Bitrix24Client(args.WebhookUrl, new ConsoleLogger<Bitrix24Client>());
            var bitrix24 = new Bitrix24(client);
            SmartProcessTypeListResponse smartProcesses = await bitrix24.Crm.SmartProcessTypes.List(x=>x.SelectAll());
            foreach(var smartProcess in smartProcesses.Result.Items)
            {
                var className = smartProcess.Title.Transform(To.LowerCase, To.TitleCase).Dehumanize();
                models.Add(new ClassGeneratorArgs {
                    description= smartProcess.Title,
                    className= className,
                    entryPoint= "crm.item.fields",
                    dirs= new List<string> { "SmartProcesses", className },
                    responseClass= "ExtFieldsResponse",
                    entityTypeId= smartProcess.EntityTypeId
                });
            }

            foreach (var model in models)
            {
                await GenerateModelByFields(new GenerateModelArgs
                {
                    EntityTypeId = model.entityTypeId,
                    ClassDescription = model.description,
                    ClassName = $"{args.ClassPrefix}{model.className}",
                    FieldsEntryPoint = model.entryPoint,
                    OutputPath = Path.Combine(args.OutputPath, string.Join("\\", model.dirs)),
                    WebhookUrl = args.WebhookUrl,
                    ResponseClass = model.responseClass
                });
            }
        }
    }
}
