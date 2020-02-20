using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;

namespace PowerPlatformConnectors.PowerAppsUtilitiesViaAzureFunctions
{
    public static class BlobToText
    {
        [FunctionName("BlobToText")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await req.ReadAsJsonAsync<RequestBody>();
            var bytes = Convert.FromBase64String(body.blob);
            var text = Encoding.UTF8.GetString(bytes);

            return CreateResponseMessage.JsonData(text);
        }

        private class RequestBody
        {
            /// <summary>The PowerApps Blob data.</summary>
            [JsonRequired]
            public string blob { get; set; }
        }
    }
}
