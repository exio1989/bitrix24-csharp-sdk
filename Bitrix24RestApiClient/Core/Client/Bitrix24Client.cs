using System;
using Flurl;
using Flurl.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using Bitrix24RestApiClient.Core.Models.Enums;
using System.Threading;

namespace Bitrix24RestApiClient.Core.Client
{
    public class Bitrix24Client: IBitrix24Client
    {
        private string webhookUrl;
        private ILogger<Bitrix24Client> logger;
        private static DateTimeOffset _lastRequestDate = DateTimeOffset.UtcNow;
        private static TimeSpan DELAY_BETWEEN_SEQ_REQUESTS = TimeSpan.FromMilliseconds(1000);
        private static SemaphoreSlim _importEntitiesSemaphore = new SemaphoreSlim(1, 1);

        public Bitrix24Client(string webhookUrl, ILogger<Bitrix24Client> logger)
        {
            this.webhookUrl = webhookUrl;
            this.logger = logger;
        }

        public async Task<TResponse> SendPostRequest<TArgs, TResponse>(EntryPointPrefix entityTypePrefix, EntityMethod entityMethod, TArgs args, CancellationToken ct = default) where TResponse : class
        {
            await _importEntitiesSemaphore.WaitAsync(ct);

            var passedTime = DateTimeOffset.UtcNow - _lastRequestDate;
            if (DELAY_BETWEEN_SEQ_REQUESTS > passedTime)
            {
                var delay = DELAY_BETWEEN_SEQ_REQUESTS - passedTime;
                await Task.Delay(delay);
            }
            _lastRequestDate = DateTimeOffset.UtcNow;

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
            catch (FlurlHttpException ex)
            {
                try
                {
                    responseBodyStr = "";
                    if (ex.Call.Response == null)
                    {
                        throw;
                    }

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
                _importEntitiesSemaphore.Release();
            }
        }

        private string GetMethod(EntryPointPrefix entityTypePrefix, EntityMethod method)
        {
            if (method.Value == EntityMethod.None.Value)
                return entityTypePrefix.Value;

            return $"{entityTypePrefix.Value}.{method.Value}";
        }
    }
}
