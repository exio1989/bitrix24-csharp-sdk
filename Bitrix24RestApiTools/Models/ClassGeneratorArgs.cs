using System.Collections.Generic;

namespace Bitrix24RestApiTools.Models
{
    public class ClassGeneratorArgs
    {
        public string description { get; set; }
        public string className { get; set; }
        public string entryPoint { get; set; }
        public List<string> dirs { get; set; }
        public string responseClass { get; set; }
        public int? entityTypeId { get; set; }
    }
}
