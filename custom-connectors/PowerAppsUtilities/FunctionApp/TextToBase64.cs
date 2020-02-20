using System;
using System.IO;
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
    public static class TextToBase64
    {
        [FunctionName("TextToBase64")]
        public static async Task<HttpResponseMessage> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await req.ReadAsJsonAsync<RequestBody>();
            var bytes = Encoding.UTF8.GetBytes(body.text);
            var base64 = Convert.ToBase64String(bytes);

            return CreateResponseMessage.JsonData(base64);
        }

        private class RequestBody
        {
            /// <summary>The text to convert.</summary>
            /// <remarks>The text to encode to a base65 encoded string.</remarks>
            [JsonRequired]
            public string text { get; set; }
        }
    }
}
