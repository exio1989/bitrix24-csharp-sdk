using Bitrix24RestApiClient.Core;
using Bitrix24RestApiClient.Core.Client;
using Bitrix24RestApiClient.Core.Models.Enums;
using Bitrix24RestApiClient.Api.Crm.Requisite.Link.Models;

namespace Bitrix24RestApiClient.Api.Crm.Requisite.Link
{
	//TODO не задействовано в коде
	/// <summary>
	/// Связи реквизитов. Связи определяют, какие реквизиты выбраны для сделки, предложения или счёта. При этом реквизиты должны принадлежать выбранной компании или контакту. Так, если в счёте в качестве покупателя выбрана компания, то реквизиты покупателя должны принадлежать этой компании. В качестве продавца может быть выбрана только компания из справочника "Реквизиты ваших компаний".
	/// </summary>
	public class CrmRequisiteLinks
	{
		public CrmRequisiteLinks(IBitrix24Client client)
		{
		}
	}
}
