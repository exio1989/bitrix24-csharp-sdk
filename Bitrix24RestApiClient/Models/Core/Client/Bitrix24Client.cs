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
            return await SendPostRequest<CrmEntityListRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethodEnum.List, args);
        }

        public async Task<TEntity> Get<TEntity>(string entityTypePrefix, CrmEntityGetRequestArgs args) where TEntity : class
        {
            return await SendPostRequest<CrmEntityGetRequestArgs, TEntity>(entityTypePrefix, EntityMethodEnum.Get, args);
        }

        public async Task<ListResponse<TEntity>> Search<TEntity>(string entityTypePrefix, CrmSearchRequestArgs args)
        {
            return await SendPostRequest<CrmSearchRequestArgs, ListResponse<TEntity>>(entityTypePrefix, EntityMethodEnum.Search, args);
        }

        public async Task<UpdateResponse> Update(string entityTypePrefix, CrmEntityUpdateArgs args)
        {
            return await SendPostRequest<CrmEntityUpdateArgs, UpdateResponse>(entityTypePrefix, EntityMethodEnum.Update, args);
        }
   
        public async Task<AddResponse> Add(string entityTypePrefix, CrmEntityAddArgs args)
        {
            return await SendPostRequest<CrmEntityAddArgs, AddResponse>(entityTypePrefix, EntityMethodEnum.Add, args);
        }

        public async Task<UpdateResponse> Set<TEntity>(string entityTypePrefix, CrmEntitySetArgs<TEntity> args)
        {
            return await SendPostRequest<CrmEntitySetArgs<TEntity>, UpdateResponse>(entityTypePrefix, EntityMethodEnum.Set, args);
        }

        public async Task<DeleteResponse> Delete(string entityTypePrefix, CrmEntityDeleteRequestArgs args)
        {
            return await SendPostRequest<CrmEntityDeleteRequestArgs, DeleteResponse>(entityTypePrefix, EntityMethodEnum.Delete, args);
        }

        public async Task<FieldsResponse> Fields(string entityTypePrefix)
        {
            return await SendPostRequest<object, FieldsResponse>(entityTypePrefix, EntityMethodEnum.Fields, new { });
        }

        public async Task<TResponse> SendPostRequest<TArgs,TResponse>(string entityTypePrefix, EntityMethodEnum entityMethod, TArgs args) where TResponse : class
        {
            TResponse responseBody = null;

            try
            {
                IFlurlResponse response = await webhookUrl
                       .AppendPathSegment(GetMethod(entityTypePrefix, entityMethod))
                       .PostJsonAsync(args);

                responseBody = await response.GetJsonAsync<TResponse>();
                return responseBody;
            }
            catch(FlurlHttpException ex)
            {
                try
                {
                    string errorResponseBody = await ex.Call.Response.GetStringAsync();
                    throw new Exception(errorResponseBody, ex);
                }
                catch
                {
                    throw;
                }
            }
            finally
            {
                logger.LogInformation($"Bitrix24 API request\r\n\tMethod: {GetMethod(entityTypePrefix, entityMethod)}\r\n\tArgs: {JsonConvert.SerializeObject(args)}\r\n\tBody: {JsonConvert.SerializeObject(responseBody)}\r\n");
            }
        }

        private string GetMethod(string entityTypePrefix, EntityMethodEnum method)
        {
            string entityMethodPart;
            switch (method)
            {
                case EntityMethodEnum.Get:
                    entityMethodPart = "get.json";
                    break;
                case EntityMethodEnum.Set:
                    entityMethodPart = "set.json";
                    break;
                case EntityMethodEnum.List:
                    entityMethodPart = "list.json";
                    break;
                case EntityMethodEnum.Search:
                    entityMethodPart = "search.json";
                    break;
                case EntityMethodEnum.Add:
                    entityMethodPart = "add.json";
                    break;
                case EntityMethodEnum.Update:
                    entityMethodPart = "update.json";
                    break;
                case EntityMethodEnum.Delete:
                    entityMethodPart = "delete";
                    break;
                case EntityMethodEnum.Fields:
                    entityMethodPart = "fields";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return $"{entityTypePrefix}.{entityMethodPart}";
        }
    }
}
