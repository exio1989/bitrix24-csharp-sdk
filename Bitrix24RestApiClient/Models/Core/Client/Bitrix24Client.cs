using Bitrix24ApiClient.src.Models;
using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;

namespace Bitrix24ApiClient.src
{
    public class Bitrix24Client: IBitrix24Client
    {
        private string webhookUrl;

        public Bitrix24Client(string webhookUrl)
        {
            this.webhookUrl = webhookUrl;
        }

        public async Task<ListResponse<TEntity>> List<TEntity>(string entityTypePrefix, CrmEntityListRequestArgs args)
        {
            return await SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, args);
        }

        public async Task<TEntity> Get<TEntity>(string entityTypePrefix, CrmEntityGetRequestArgs args) where TEntity : class
        {
            return await SendPostRequest<CrmEntityGetRequestArgs, TEntity>(entityTypePrefix, args);
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(string entityTypePrefix, CrmSearchRequestArgs args)
        {
            return await SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityTypePrefix, args);
        }

        public async Task<UpdateResponse> Update(string entityTypePrefix, CrmEntityUpdateArgs args)
        {
            return await SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, args);
        }
   
        public async Task<AddResponse> Add(string entityTypePrefix, CrmEntityAddArgs args)
        {
            return await SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, args);
        }

        public async Task<DeleteResponse> Delete(string entityTypePrefix, CrmEntityDeleteRequestArgs args)
        {
            return await SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityTypePrefix, args);
        }

        private async Task<TResponse> SendPostRequest<TArgs,TResponse>(string entityTypePrefix, TArgs args)
        {
            IFlurlResponse response = await webhookUrl
                   .AppendPathSegment(GetMethod(entityTypePrefix, EntityMethod.Delete))
                   .PostJsonAsync(args);

            return await response.GetJsonAsync<TResponse>();
        }

        private string GetMethod(string entityTypePrefix, EntityMethod method)
        {
            string entityMethodPart;
            switch (method)
            {
                case EntityMethod.Get:
                    entityMethodPart = "get.json";
                    break;
                case EntityMethod.List:
                    entityMethodPart = "list.json";
                    break;
                case EntityMethod.Search:
                    entityMethodPart = "search.json";
                    break;
                case EntityMethod.Add:
                    entityMethodPart = "add.json";
                    break;
                case EntityMethod.Update:
                    entityMethodPart = "update.json";
                    break;
                case EntityMethod.Delete:
                    entityMethodPart = "delete";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return $"{entityTypePrefix}.{entityMethodPart}";
        }
    }
}
