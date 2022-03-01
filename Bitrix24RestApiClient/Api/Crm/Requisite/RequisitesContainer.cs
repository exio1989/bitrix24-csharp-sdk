using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.Requisite.Models;

namespace Bitrix24RestApiClient.Api.Crm.Requisite
{
	/// <summary>
	/// Реквизиты
	/// </summary>
	public class RequisitesContainer: AbstractEntities<CrmRequisite>
	{
		public RequisitesContainer(IBitrix24Client client)
			:base(client, EntryPointPrefix.Requisite)
		{
		}
	}
}
