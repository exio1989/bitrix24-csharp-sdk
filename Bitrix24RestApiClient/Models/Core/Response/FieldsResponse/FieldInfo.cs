using Bitrix24RestApiClient.Models.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bitrix24RestApiClient.Models.Core.Response.FieldsResponse
{
    public class FieldInfo
	{
		[JsonIgnore]
		public CrmFieldTypeEnum Type { 
			get {
                switch (TypeExt)
                {
					case CrmFieldType.Char:
						return CrmFieldTypeEnum.Char;
					case CrmFieldType.CrmCategory:
						return CrmFieldTypeEnum.CrmCategory;
					case CrmFieldType.CrmCompany:
						return CrmFieldTypeEnum.CrmCompany;
					case CrmFieldType.CrmContact:
						return CrmFieldTypeEnum.CrmContact;
					case CrmFieldType.CrmCurrency:
						return CrmFieldTypeEnum.CrmCurrency;
					case CrmFieldType.CrmLead:
						return CrmFieldTypeEnum.CrmLead;
					case CrmFieldType.CrmStatus:
						return CrmFieldTypeEnum.CrmStatus;
					case CrmFieldType.CrmQuote:
						return CrmFieldTypeEnum.CrmQuote;
					case CrmFieldType.Date:
						return CrmFieldTypeEnum.Date;
					case CrmFieldType.DateTime:
						return CrmFieldTypeEnum.DateTime;
					case CrmFieldType.Double:
						return CrmFieldTypeEnum.Double;
					case CrmFieldType.Enumeration:
						return CrmFieldTypeEnum.Enumeration;
					case CrmFieldType.Integer:
						return CrmFieldTypeEnum.Integer;
					case CrmFieldType.Location:
						return CrmFieldTypeEnum.Location;
					case CrmFieldType.User:
						return CrmFieldTypeEnum.User;
					case CrmFieldType.String:
						return CrmFieldTypeEnum.String;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set {
				switch (value)
				{
					case CrmFieldTypeEnum.Char:
						TypeExt = CrmFieldType.Char;
						break;
					case CrmFieldTypeEnum.CrmCategory:
						TypeExt = CrmFieldType.CrmCategory;
						break;
					case CrmFieldTypeEnum.CrmCompany:
						TypeExt = CrmFieldType.CrmCompany;
						break;
					case CrmFieldTypeEnum.CrmContact:
						TypeExt = CrmFieldType.CrmContact;
						break;
					case CrmFieldTypeEnum.CrmCurrency:
						TypeExt = CrmFieldType.CrmCurrency;
						break;
					case CrmFieldTypeEnum.CrmLead:
						TypeExt = CrmFieldType.CrmLead;
						break;
					case CrmFieldTypeEnum.CrmStatus:
						TypeExt = CrmFieldType.CrmStatus;
						break;
					case CrmFieldTypeEnum.CrmQuote:
						TypeExt = CrmFieldType.CrmQuote;
						break;
					case CrmFieldTypeEnum.Date:
						TypeExt = CrmFieldType.Date;
						break;
					case CrmFieldTypeEnum.DateTime:
						TypeExt = CrmFieldType.DateTime;
						break;
					case CrmFieldTypeEnum.Double:
						TypeExt = CrmFieldType.Double;
						break;
					case CrmFieldTypeEnum.Enumeration:
						TypeExt = CrmFieldType.Enumeration;
						break;
					case CrmFieldTypeEnum.Integer:
						TypeExt = CrmFieldType.Integer;
						break;
					case CrmFieldTypeEnum.Location:
						TypeExt = CrmFieldType.Location;
						break;
					case CrmFieldTypeEnum.User:
						TypeExt = CrmFieldType.User;
						break;
					case CrmFieldTypeEnum.String:
						TypeExt = CrmFieldType.String;
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}
			} 
		}

		[JsonProperty("type")]
		public string TypeExt { get; set; }

		[JsonProperty("isRequired")]
		public bool IsRequired { get; set; }

		[JsonProperty("isReadOnly")]
		public bool IsReadOnly { get; set; }

		[JsonProperty("isImmutable")]
		public bool IsImmutable { get; set; }

		[JsonProperty("isMultiple")]
		public bool IsMultiple { get; set; }

		[JsonProperty("isDynamic")]
		public bool IsDynamic { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("listLabel")]
		public string ListLabel { get; set; }

		[JsonProperty("formLabel")]
		public string FormLabel { get; set; }

		[JsonProperty("filterLabel")]
		public string FilterLabel { get; set; }

		[JsonProperty("items")]
		public List<FieldInfoEnumerationItem> Items { get; set; } = new List<FieldInfoEnumerationItem>();

		[JsonProperty("settings")]
		public FieldInfoSettings Settings { get; set; }

		[JsonIgnore]
		public StringFieldSettings StringSettings {
            get
            {
				if (Settings == null || Type != CrmFieldTypeEnum.String)
					return null;

				return new StringFieldSettings
				{
					DefaultValue = Settings.DefaultValue,
					MaxLength = Settings.MaxLength,
					MinLength = Settings.MinLength,
					RegExp = Settings.RegExp,
					Rows = Settings.Rows,
					Size = Settings.Size
				};
            }

            set
            {
				throw new NotImplementedException();
            }
		}

		[JsonIgnore]
		public EnumerationFieldSettings EnumerationSettings
		{
			get
			{
				if (Settings == null || Type != CrmFieldTypeEnum.Enumeration)
					return null;

				return new EnumerationFieldSettings
				{
					CaptionNoValue = Settings.CaptionNoValue,
					Display = Settings.Display,
					ListHeight = Settings.ListHeight,
					ShowNoValue = Settings.ShowNoValue
				};
			}

			set
			{
				throw new NotImplementedException();
			}
		}

		[JsonIgnore]
		public DateFieldSettings DateSettings
		{ 
			get
			{
				if (Settings == null || Type != CrmFieldTypeEnum.Date)
					return null;

				return new DateFieldSettings
				{
					DefaultValue = Settings.DefaultValue
				};
			}

			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
