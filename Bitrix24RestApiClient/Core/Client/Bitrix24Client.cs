using Bitrix24ApiClient.src.Models;
using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Bitrix24RestApiClient.src.Models.Crm.Core.Client;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Web;
using System.Text.RegularExpressions;

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

        public async Task<TResponse> SendPostRequest<TArgs,TResponse>(string entityTypePrefix, EntityMethod entityMethod, TArgs args) where TResponse : class
        {
            string responseBodyStr = null;

            try
            {
                IFlurlResponse response = await webhookUrl
                       .AppendPathSegment(GetMethod(entityTypePrefix, entityMethod))
                       .PostJsonAsync(args);

                TResponse responseBody = await response.GetJsonAsync<TResponse>();
                responseBodyStr = JsonConvert.SerializeObject(responseBody);
                return responseBody;
            }
            catch(FlurlHttpException ex)
            {
                try
                {
                    responseBodyStr = Regex.Unescape(await ex.Call.Response.GetStringAsync());
                    throw new Exception(responseBodyStr, ex);
                }
                catch
                {
                    throw;
                }
            }
            finally
            {
                int partLength = 300;
                string bodyStr = responseBodyStr.Length <= partLength*2
                    ? responseBodyStr
                    : $"{responseBodyStr.Substring(0, partLength)} ... {responseBodyStr.Substring(responseBodyStr.Length - partLength, partLength)}";

                logger.LogInformation($"Bitrix24 API request\r\n\tMethod: {GetMethod(entityTypePrefix, entityMethod)}\r\n\tArgs: {JsonConvert.SerializeObject(args)}\r\n\tBody: {bodyStr}\r\n");
            }
        }

        private string GetMethod(string entityTypePrefix, EntityMethod method)
        {
            if (method.Value == EntityMethod.None.Value)
                return entityTypePrefix;

            return $"{entityTypePrefix}.{method.Value}";
        }
    }
}
