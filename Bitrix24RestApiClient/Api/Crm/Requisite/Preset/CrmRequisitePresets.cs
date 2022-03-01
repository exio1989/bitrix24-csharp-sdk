using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.Requisite.Preset.Models;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Preset
{
	//TODO не задействовано в коде
	/// <summary>
	/// Шаблоны реквизитов
	/// </summary>
	public class CrmRequisitePresets: AbstractEntities<CrmRequisitePreset>
	{
		public CrmRequisitePresets(IBitrix24Client client)
			:base(client, EntryPointPrefix.RequisitePreset)
		{
		}
	}
}
