using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.Requisite.Preset.Field.Models;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Preset.Field
{
	//TODO не задействовано в коде
	/// <summary>
	/// Список полей из набора полей шаблона для определенного реквизита.
	/// </summary>
	public class CrmRequisitePresetFields: AbstractEntities<CrmRequisitePresetField>
	{
		public CrmRequisitePresetFields(IBitrix24Client client)
			:base(client, EntryPointPrefix.RequisitePresetField)
		{
		}
	}
}
