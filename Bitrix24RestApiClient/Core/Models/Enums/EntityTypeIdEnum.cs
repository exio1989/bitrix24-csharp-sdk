using System;
using Bitrix24RestApiClient.Core.Models.Enums;

namespace Bitrix24RestApiClient.Core.Models.Enums
{
    public class EntityTypeIdEnum
    {
        /// <summary>
        /// Тип сущности 
        /// </summary>
        public string EntityType { get; private set; }

        /// <summary>
        /// Числовой идентификатор(entityTypeId) 
        /// </summary>
        public int EntityTypeId { get; private set; }

        /// <summary>
        ///  Символьный код(entityTypeName)
        /// </summary>
        public string EntityTypeName { get; private set; }

        /// <summary>
        /// Краткий символьный код
        /// </summary>
        public string EntitySymbolCode { get; private set; }

        /// <summary>
        /// Тип сущности пользовательского поля
        /// </summary>
        public string EntityFieldTypeName { get; private set; }

        public static EntityTypeIdEnum Lead = new EntityTypeIdEnum
        { 
            EntityType = "Лид",
            EntityTypeId = 1,
            EntityTypeName = "LEAD",
            EntitySymbolCode = "L",
            EntityFieldTypeName = "CRM_LEAD"
        };

        public static EntityTypeIdEnum Deal = new EntityTypeIdEnum
        {
            EntityType = "Сделка",
            EntityTypeId = 2,
            EntityTypeName = "DEAL",
            EntitySymbolCode = "D",
            EntityFieldTypeName = "CRM_DEAL"
        };

        public static EntityTypeIdEnum Contact = new EntityTypeIdEnum
        {
            EntityType = "Контакт",
            EntityTypeId = 3,
            EntityTypeName = "CONTACT",
            EntitySymbolCode = "C",
            EntityFieldTypeName = "CRM_CONTACT"
        };

        public static EntityTypeIdEnum Company = new EntityTypeIdEnum
        {
            EntityType = "Компания",
            EntityTypeId = 4,
            EntityTypeName = "COMPANY",
            EntitySymbolCode = "CO",
            EntityFieldTypeName = "CRM_COMPANY"
        };

        public static EntityTypeIdEnum Invoice = new EntityTypeIdEnum
        {
            EntityType = "Счет (старый)",
            EntityTypeId = 5,
            EntityTypeName = "INVOICE",
            EntitySymbolCode = "I",
            EntityFieldTypeName = "CRM_INVOICE"
        };

        public static EntityTypeIdEnum SmartInvoice = new EntityTypeIdEnum
        {
            EntityType = "Счет (новый)",
            EntityTypeId = 31,
            EntityTypeName = "SMART_INVOICE",
            EntitySymbolCode = "SI",
            EntityFieldTypeName = "CRM_SMART_INVOICE"
        };

        public static EntityTypeIdEnum Quote = new EntityTypeIdEnum
        {
            EntityType = "Предложение",
            EntityTypeId = 7,
            EntityTypeName = "QUOTE",
            EntitySymbolCode = "Q",
            EntityFieldTypeName = "CRM_QUOTE"
        };

        public static EntityTypeIdEnum Requisite = new EntityTypeIdEnum
        {
            EntityType = "Реквизит",
            EntityTypeId = 8,
            EntityTypeName = "REQUISITE",
            EntitySymbolCode = "RQ",
            EntityFieldTypeName = "CRM_REQUISITE"
        };

        public static EntityTypeIdEnum Create(int typeId)
        {
            if(typeId == Lead.EntityTypeId)
                return Lead;

            if (typeId == Deal.EntityTypeId)
                return Deal;

            if (typeId == Contact.EntityTypeId)
                return Contact;

            if (typeId == Company.EntityTypeId)
                return Company;

            if (typeId == Invoice.EntityTypeId)
                return Invoice;

            if (typeId == SmartInvoice.EntityTypeId)
                return SmartInvoice;

            if (typeId == Quote.EntityTypeId)
                return Quote;

            if (typeId == Requisite.EntityTypeId)
                return Requisite;

            throw new ArgumentOutOfRangeException();
        }
    }
}
