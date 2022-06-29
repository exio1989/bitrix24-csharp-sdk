using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using Bitrix24RestApiClient.Core.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using Bitrix24RestApiClient.Core.Models.Response.FieldsResponse;

namespace Bitrix24RestApiClient.Core.Models.Response.FieldsResponse
{
    public class FieldInfo
	{
		[JsonIgnore]
		public string TypeCSharp
		{
			get
			{
				switch (TypeExt)
				{
					case CrmFieldType.Boolean:
						return "bool?";
					case CrmFieldType.ProductPropertyEnumElement:
						return "List<object>";
					case CrmFieldType.CurrencyLocalization:
						return "List<object>";
					case CrmFieldType.UfEnumElement:
						return "List<object>";
					case CrmFieldType.Int:
						return "int?";
					case CrmFieldType.ProductFile:
						return "CrmFile";
					case CrmFieldType.DiskFile:
						return "CrmFile";
					case CrmFieldType.CrmActivityBinding:
						return "List<int>";
					case CrmFieldType.CrmActivityCommunication:
						return "object?";
					case CrmFieldType.Object:
						return "object?";
					case CrmFieldType.Null:
						return "object?";
					case CrmFieldType.CrmEnumFields:
						return "int?";
					case CrmFieldType.CrmEnumOwnerType:
						return "int?";
					case CrmFieldType.CrmEnumContentType:
						return "int?";
					case CrmFieldType.CrmEnumActivityType:
						return "int?";
					case CrmFieldType.CrmEnumActivityPriority:
						return "int?";
					case CrmFieldType.CrmEnumActivityDirection:
						return "int?";
					case CrmFieldType.CrmEnumActivityNotifyType:
						return "int?";
					case CrmFieldType.CrmEnumAddressType:
						return "int?";
					case CrmFieldType.CrmEnumActivityStatus:
						return "int?";
					case CrmFieldType.CrmEnumSettingsMode:
						return "int?";
					case CrmFieldType.AttachedDiskfile:
						return "object?";
					case CrmFieldType.RecurringParams:
						return "object?";
					case CrmFieldType.Char:
						return "string?";
					case CrmFieldType.CrmCategory:
						return "string?";
					case CrmFieldType.CrmCompany:
						return "int?";
					case CrmFieldType.CrmContact:
						return "int?";
					case CrmFieldType.CrmCurrency:
						return "string?";
					case CrmFieldType.CrmLead:
						return "int?";
					case CrmFieldType.CrmStatus:
						return "string?";
					case CrmFieldType.CrmEntity:
						return "string?";
					case CrmFieldType.ProductProperty:
						return "string?";						
					case CrmFieldType.CrmQuote:
						return "string?";
					case CrmFieldType.Date:
						return "DateTimeOffset?";
					case CrmFieldType.DateTime:
						return "DateTimeOffset?";
					case CrmFieldType.Double:
						return "decimal?";
					case CrmFieldType.Enumeration:
						return IsMultiple 
							? "List<int>" 
							: "int?";
					case CrmFieldType.Integer:
						return "int?";
					case CrmFieldType.Location:
						return "string?";
					case CrmFieldType.User:
						return "int?";
					case CrmFieldType.String:
						return "string?";
					case CrmFieldType.File:
						return "CrmFile?";
					case CrmFieldType.CrmStatusExtra:
						return "string?";
					case CrmFieldType.CrmDeal:
						return "int?";
					case CrmFieldType.Text:
						return "string?";
					case CrmFieldType.Variable:
						return "object?";
					case CrmFieldType.IndexArray:
						return "List<object>";
					case CrmFieldType.AssociativeArray:
						if(Definition.Key.Type == CrmFieldTypeEnum.Integer && Definition.Value.Type == CrmFieldTypeEnum.Variable)
							return "List<int, object>";
						else
							throw new ArgumentOutOfRangeException();
					case CrmFieldType.CrmMultiField:
						return IsMultiple
							? "List<CrmMultiField>"
							: "CrmMultiField?"; 
					default:
						throw new ArgumentOutOfRangeException($"Unknown type of '{TypeExt}'");
				}
			}
		}

		[JsonIgnore]
		public CrmFieldTypeEnum Type { 
			get {
                switch (TypeExt)
				{
					case CrmFieldType.Boolean:
						return CrmFieldTypeEnum.Boolean;
					case CrmFieldType.ProductPropertyEnumElement:
						return CrmFieldTypeEnum.ProductPropertyEnumElement;
					case CrmFieldType.ProductFile:
						return CrmFieldTypeEnum.ProductFile;
					case CrmFieldType.CurrencyLocalization:
						return CrmFieldTypeEnum.CurrencyLocalization;
					case CrmFieldType.UfEnumElement:
						return CrmFieldTypeEnum.UfEnumElement;
					case CrmFieldType.Int:
						return CrmFieldTypeEnum.Int;
					case CrmFieldType.DiskFile:
						return CrmFieldTypeEnum.DiskFile;
					case CrmFieldType.CrmActivityCommunication:
						return CrmFieldTypeEnum.CrmActivityCommunication;
					case CrmFieldType.CrmActivityBinding:
						return CrmFieldTypeEnum.CrmActivityBinding;
					case CrmFieldType.Object:
						return CrmFieldTypeEnum.Object;
					case CrmFieldType.Null:
						return CrmFieldTypeEnum.Null;
					case CrmFieldType.CrmEnumFields:
						return CrmFieldTypeEnum.CrmEnumFields;
					case CrmFieldType.CrmEnumOwnerType:
						return CrmFieldTypeEnum.CrmEnumOwnerType;
					case CrmFieldType.CrmEnumContentType:
						return CrmFieldTypeEnum.CrmEnumContentType;
					case CrmFieldType.CrmEnumActivityType:
						return CrmFieldTypeEnum.CrmEnumActivityType;
					case CrmFieldType.CrmEnumActivityPriority:
						return CrmFieldTypeEnum.CrmEnumActivityPriority;
					case CrmFieldType.CrmEnumActivityDirection:
						return CrmFieldTypeEnum.CrmEnumActivityDirection;
					case CrmFieldType.CrmEnumActivityNotifyType:
						return CrmFieldTypeEnum.CrmEnumActivityNotifyType;
					case CrmFieldType.CrmEnumAddressType:
						return CrmFieldTypeEnum.CrmEnumAddressType;
					case CrmFieldType.CrmEnumActivityStatus:
						return CrmFieldTypeEnum.CrmEnumActivityStatus;
					case CrmFieldType.CrmEnumSettingsMode:
						return CrmFieldTypeEnum.CrmEnumSettingsMode;
					case CrmFieldType.AttachedDiskfile:
						return CrmFieldTypeEnum.AttachedDiskfile;
					case CrmFieldType.RecurringParams:
						return CrmFieldTypeEnum.RecurringParams;
					case CrmFieldType.Variable:
						return CrmFieldTypeEnum.Variable;
					case CrmFieldType.AssociativeArray:
						return CrmFieldTypeEnum.AssociativeArray;
					case CrmFieldType.IndexArray:
						return CrmFieldTypeEnum.IndexArray;
					case CrmFieldType.Char:
						return CrmFieldTypeEnum.Char;
					case CrmFieldType.Text:
						return CrmFieldTypeEnum.Text;
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
					case CrmFieldType.CrmDeal:
						return CrmFieldTypeEnum.CrmDeal;
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
					case CrmFieldType.File:
						return CrmFieldTypeEnum.File;
					case CrmFieldType.CrmMultiField:
						return CrmFieldTypeEnum.CrmMultiField;
					default:
						throw new ArgumentOutOfRangeException();
				}
			}
			set {
				switch (value)
				{
					case CrmFieldTypeEnum.Boolean:
						TypeExt = CrmFieldType.Boolean;
						break;
					case CrmFieldTypeEnum.ProductPropertyEnumElement:
						TypeExt = CrmFieldType.ProductPropertyEnumElement;
						break;
					case CrmFieldTypeEnum.ProductFile:
						TypeExt = CrmFieldType.ProductFile;
						break;
					case CrmFieldTypeEnum.CurrencyLocalization:
						TypeExt = CrmFieldType.CurrencyLocalization;
						break;
					case CrmFieldTypeEnum.UfEnumElement:
						TypeExt = CrmFieldType.UfEnumElement;
						break;
					case CrmFieldTypeEnum.Int:
						TypeExt = CrmFieldType.Int;
						break;
					case CrmFieldTypeEnum.DiskFile:
						TypeExt = CrmFieldType.DiskFile;
						break;
					case CrmFieldTypeEnum.CrmActivityCommunication:
						TypeExt = CrmFieldType.CrmActivityCommunication; 
						break;
					case CrmFieldTypeEnum.CrmActivityBinding:
						TypeExt = CrmFieldType.CrmActivityBinding;
						break;
					case CrmFieldTypeEnum.Object:
						TypeExt = CrmFieldType.Object;
						break;
					case CrmFieldTypeEnum.Null:
						TypeExt = CrmFieldType.Null;
						break;
					case CrmFieldTypeEnum.CrmEnumFields:
						TypeExt = CrmFieldType.CrmEnumFields;
						break;
					case CrmFieldTypeEnum.CrmEnumOwnerType:
						TypeExt = CrmFieldType.CrmEnumOwnerType;
						break;
					case CrmFieldTypeEnum.CrmEnumContentType:
						TypeExt = CrmFieldType.CrmEnumContentType;
						break;
					case CrmFieldTypeEnum.CrmEnumActivityType:
						TypeExt = CrmFieldType.CrmEnumActivityType;
						break;
					case CrmFieldTypeEnum.CrmEnumActivityPriority:
						TypeExt = CrmFieldType.CrmEnumActivityPriority;
						break;
					case CrmFieldTypeEnum.CrmEnumActivityDirection:
						TypeExt = CrmFieldType.CrmEnumActivityDirection;
						break;
					case CrmFieldTypeEnum.CrmEnumActivityNotifyType:
						TypeExt = CrmFieldType.CrmEnumActivityNotifyType;
						break;
					case CrmFieldTypeEnum.CrmEnumAddressType:
						TypeExt = CrmFieldType.CrmEnumAddressType;
						break;
					case CrmFieldTypeEnum.CrmEnumActivityStatus:
						TypeExt = CrmFieldType.CrmEnumActivityStatus;
						break;
					case CrmFieldTypeEnum.CrmEnumSettingsMode:
						TypeExt = CrmFieldType.CrmEnumSettingsMode;
						break;
					case CrmFieldTypeEnum.AttachedDiskfile:
						TypeExt = CrmFieldType.AttachedDiskfile;
						break;
					case CrmFieldTypeEnum.RecurringParams:
						TypeExt = CrmFieldType.RecurringParams;
						break;
					case CrmFieldTypeEnum.Variable:
						TypeExt = CrmFieldType.Variable;
						break;
					case CrmFieldTypeEnum.AssociativeArray:
						TypeExt = CrmFieldType.AssociativeArray;
						break;
					case CrmFieldTypeEnum.IndexArray:
						TypeExt = CrmFieldType.IndexArray;
						break;
					case CrmFieldTypeEnum.Char:
						TypeExt = CrmFieldType.Char;
						break;
					case CrmFieldTypeEnum.Text:
						TypeExt = CrmFieldType.Text;
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
					case CrmFieldTypeEnum.CrmEntity:
						TypeExt = CrmFieldType.CrmEntity;
						break;
					case CrmFieldTypeEnum.ProductProperty:
						TypeExt = CrmFieldType.ProductProperty;
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
					case CrmFieldTypeEnum.File:
						TypeExt = CrmFieldType.File;
						break;
					case CrmFieldTypeEnum.CrmMultiField:
						TypeExt = CrmFieldType.CrmMultiField;
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

		[JsonProperty("upperName")]
		public string UpperName { get; set; }

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

		[JsonProperty("definition")]
		public FieldInfoDefinition Definition { get; set; }

		[JsonIgnore]
		public StringFieldSettings StringSettings {
            get
            {
				if (Settings == null || Type != CrmFieldTypeEnum.String)
					return null;

				return new StringFieldSettings
				{
					//DefaultValue = Settings.DefaultValue,
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
					//DefaultValue = Settings.DefaultValue
				};
			}

			set
			{
				throw new NotImplementedException();
			}
		}
	}
}
