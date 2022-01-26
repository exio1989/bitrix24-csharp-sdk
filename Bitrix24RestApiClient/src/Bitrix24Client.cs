using Bitrix24ApiClient.src.Models;
using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Bitrix24ApiClient.src
{
    public class Bitrix24Client
    {
        private string webhookUrl;

        public Bitrix24Client(string webhookUrl)
        {
            this.webhookUrl = webhookUrl;
        }

        public async Task<ListResponse<TEntity>> List<TEntity>(EntityType entityType, ListRequestArgs args = null)
        {
            var postBody = args == null
                ? new object{ }
                : new CrmListRequestArgs(args);

            var json = JsonConvert.SerializeObject(postBody);

            IFlurlResponse response = await webhookUrl
                .AppendPathSegment(GetMethod(entityType, EntityMethod.List))
                .PostJsonAsync(postBody);
            return await response.GetJsonAsync<ListResponse<TEntity>>();
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(EntityType entityType, List<Filter> filter)
        {
            var postBody = new SearchRequestArgs(filter);

            IFlurlResponse response = await webhookUrl
                .AppendPathSegment(GetMethod(entityType, EntityMethod.List))
                .PostJsonAsync(postBody);
            return await response.GetJsonAsync<ListResponse<TEntity>>();
        }
        
        public async Task<TEntity> First<TEntity>(EntityType entityType, ListRequestArgs args = null)
        {
            ListResponse<TEntity> list = await List<TEntity>(entityType, args);
            return list.Result.FirstOrDefault();
        }
        public async Task<UpdateResponse> Update(EntityType entityType, CrmEntityUpdateArgs args)
        {
            IFlurlResponse response = await webhookUrl
                .AppendPathSegment(GetMethod(entityType, EntityMethod.Update))
                .PostJsonAsync(args);

            return await response.GetJsonAsync<UpdateResponse>();
        }

        public async Task<AddResponse> Add(EntityType entityType, object postBody)
        {
            var json = JsonConvert.SerializeObject(postBody);
            IFlurlResponse response = await webhookUrl
                .AppendPathSegment(GetMethod(entityType, EntityMethod.Add))
                .PostJsonAsync(postBody);

            return await response.GetJsonAsync<AddResponse>();
        }
                
        public async Task<AddResponse> Add(EntityType entityType, Dictionary<string, string> fields)
        {
            var postBody = new { fields = fields };

            IFlurlResponse response = await webhookUrl
                .AppendPathSegment(GetMethod(entityType, EntityMethod.Add))
                .PostJsonAsync(postBody);

            return await response.GetJsonAsync<AddResponse>();
        }

        public async Task Delete(EntityType entityType, string dealId)
        {
            IFlurlResponse response = await webhookUrl
                   .AppendPathSegment(GetMethod(entityType, EntityMethod.Delete))
                   .PostJsonAsync(new { id = dealId });
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
                case EntityMethod.List:
                    if(entityType == EntityType.User)//TODO грязь
                        entityMethodPart = "search.json";
                    else
                        entityMethodPart = "list.json";
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
