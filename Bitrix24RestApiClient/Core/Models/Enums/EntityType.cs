namespace Bitrix24RestApiClient.Core.Models.Enums
{
    public class EntryPointPrefix
    {
        public EntryPointPrefix() { }
        public EntryPointPrefix(string value) {
            Value = value;
        }
        public string Value { get; private set; }
        public static EntryPointPrefix StageHistory = new EntryPointPrefix { Value = "crm.stagehistory" };        
        public static EntryPointPrefix DealProductRows = new EntryPointPrefix { Value = "crm.deal.productrows" };        
        public static EntryPointPrefix Batch = new EntryPointPrefix { Value = "batch" };
        public static EntryPointPrefix Status = new EntryPointPrefix { Value = "crm.status" };
        public static EntryPointPrefix SmartProcessType = new EntryPointPrefix { Value = "crm.type" };
        public static EntryPointPrefix PaySystem = new EntryPointPrefix { Value = "crm.paysystem" };
        public static EntryPointPrefix Invoice = new EntryPointPrefix { Value = "crm.invoice" };
        public static EntryPointPrefix Product = new EntryPointPrefix { Value = "crm.product" };
        public static EntryPointPrefix Company = new EntryPointPrefix { Value = "crm.company" };
        public static EntryPointPrefix Deal = new EntryPointPrefix { Value = "crm.deal" };
        public static EntryPointPrefix DealContact = new EntryPointPrefix { Value = "crm.deal.contact" };
        public static EntryPointPrefix DealContactItems = new EntryPointPrefix { Value = "crm.deal.contact.items" };
        public static EntryPointPrefix Lead = new EntryPointPrefix { Value = "crm.lead" };
        public static EntryPointPrefix DealUserFields = new EntryPointPrefix { Value = "crm.deal.userfield" };
        public static EntryPointPrefix Contact = new EntryPointPrefix { Value = "crm.contact" };
        public static EntryPointPrefix TimelineComment = new EntryPointPrefix { Value = "crm.timeline.comment" };
        public static EntryPointPrefix User = new EntryPointPrefix { Value = "user" };
        public static EntryPointPrefix Item = new EntryPointPrefix { Value = "crm.item" };
        public static EntryPointPrefix RequisiteLink = new EntryPointPrefix { Value = "crm.requisite.link" };
        public static EntryPointPrefix RequisiteBankdetail = new EntryPointPrefix { Value = "crm.requisite.bankdetail" };
        public static EntryPointPrefix RequisitePresetField = new EntryPointPrefix { Value = "crm.requisite.preset.field" };
        public static EntryPointPrefix RequisitePreset = new EntryPointPrefix { Value = "crm.requisite.preset" };
        public static EntryPointPrefix Requisite = new EntryPointPrefix { Value = "crm.requisite" };
    }
}
