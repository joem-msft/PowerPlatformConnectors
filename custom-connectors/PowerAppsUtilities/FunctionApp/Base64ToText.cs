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
    public static class Base64ToText
    {
        [FunctionName("Base64ToText")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await req.ReadAsJsonAsync<RequestBody>();
            var bytes = Convert.FromBase64String(body.base64String);
            var text = Encoding.UTF8.GetString(bytes);

            return CreateResponseMessage.JsonData(text);
        }

        private class RequestBody
        {
            /// <summary>base64 encoded string.</summary>
            /// <remarks>The base65 encoded string to convert.</remarks>
            [JsonRequired]
            public string base64String { get; set; }
        }
    }
}
