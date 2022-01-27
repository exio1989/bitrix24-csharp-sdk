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

        public async Task<ListResponse<TEntity>> List<TEntity>(EntityType entityType, CrmEntityListRequestArgs args)
        {
            return await SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityType, args);
        }

        public async Task<TEntity> Get<TEntity>(EntityType entityType, CrmEntityGetRequestArgs args) where TEntity : class
        {
            return await SendPostRequest<CrmEntityGetRequestArgs, TEntity>(entityType, args);
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(EntityType entityType, CrmSearchRequestArgs args)
        {
            return await SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityType, args);
        }

        public async Task<UpdateResponse> Update(EntityType entityType, CrmEntityUpdateArgs args)
        {
            return await SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityType, args);
        }
   
        public async Task<AddResponse> Add(EntityType entityType, CrmEntityAddArgs args)
        {
            return await SendPostRequest<CrmEntityAddArgs, AddResponse>(entityType, args);
        }

        public async Task<DeleteResponse> Delete(EntityType entityType, CrmEntityDeleteRequestArgs args)
        {
            return await SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityType, args);
        }

        private async Task<TResponse> SendPostRequest<TArgs,TResponse>(EntityType entityType, TArgs args)
        {
            IFlurlResponse response = await webhookUrl
                   .AppendPathSegment(GetMethod(entityType, EntityMethod.Delete))
                   .PostJsonAsync(args);

            return await response.GetJsonAsync<TResponse>();
        }

        private string GetMethod(EntityType entityType, EntityMethod method)
        {
            string entityNamePart;
            switch (entityType)
            {
                case EntityType.Company:
                    entityNamePart = "crm.company";
                    break;
                case EntityType.Deal:
                    entityNamePart = "crm.deal";
                    break;
                case EntityType.DealUserFields:
                    entityNamePart = "crm.deal.userfield";
                    break;                    
                case EntityType.Contact:
                    entityNamePart = "crm.contact";
                    break;
                case EntityType.TimelineComment:
                    entityNamePart = "crm.timeline.comment";
                    break;
                case EntityType.User:
                    entityNamePart = "user";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

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

            return $"{entityNamePart}.{entityMethodPart}";
        }
    }
}
