using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.Requisite.Bankdetail.Models;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Bankdetail
{
	//TODO не задействовано в коде
	/// <summary>
	/// Банковские реквизиты
	/// </summary>
	public class CrmRequisiteBankdetails: AbstractEntities<CrmRequisiteBankdetail>
	{
		public CrmRequisiteBankdetails(IBitrix24Client client)
			:base(client, EntryPointPrefix.RequisiteBankdetail)
		{
		}
	}
}
