using Bitrix24ApiClient.src.Models;
using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Bitrix24ApiClient.src
{
    public class Bitrix24Client: IBitrix24Client
    {
        private string webhookUrl;
        private ILogger<Bitrix24Client> logger;

        public Bitrix24Client(string webhookUrl, ILogger<Bitrix24Client> logger)
        {
            this.webhookUrl = webhookUrl;
            this.logger = logger;
        }

        public async Task<ListResponse<TEntity>> List<TEntity>(string entityTypePrefix, CrmEntityListRequestArgs args)
        {
            return await SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.List, args);
        }

        public async Task<TEntity> Get<TEntity>(string entityTypePrefix, CrmEntityGetRequestArgs args) where TEntity : class
        {
            return await SendPostRequest<CrmEntityGetRequestArgs, TEntity>(entityTypePrefix, EntityMethod.Get, args);
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(string entityTypePrefix, CrmSearchRequestArgs args)
        {
            return await SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethod.Search, args);
        }

        public async Task<UpdateResponse> Update(string entityTypePrefix, CrmEntityUpdateArgs args)
        {
            return await SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethod.Update, args);
        }
   
        public async Task<AddResponse> Add(string entityTypePrefix, CrmEntityAddArgs args)
        {
            return await SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethod.Add, args);
        }

        public async Task<DeleteResponse> Delete(string entityTypePrefix, CrmEntityDeleteRequestArgs args)
        {
            return await SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityTypePrefix, EntityMethod.Delete, args);
        }

        private async Task<TResponse> SendPostRequest<TArgs,TResponse>(string entityTypePrefix, EntityMethod entityMethod, TArgs args)
        {
            try
            {
                logger.LogTrace($"Bitrix24 API request. Endpoint: {entityTypePrefix}, Args: {JsonConvert.SerializeObject(args)}");
                IFlurlResponse response = await webhookUrl
                       .AppendPathSegment(GetMethod(entityTypePrefix, entityMethod))
                       .PostJsonAsync(args);

                return await response.GetJsonAsync<TResponse>();
            }
            catch(FlurlHttpException ex)
            {
                throw;
            }
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
