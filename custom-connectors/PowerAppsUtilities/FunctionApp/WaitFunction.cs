using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace PowerPlatformConnectors.PowerAppsUtilitiesViaAzureFunctions
{
    public static class WaitFunction
    {
        [FunctionName("Wait")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var body = await req.ReadAsJsonAsync<RequestBody>();
            await Task.Delay(body.Milliseconds);

            return new OkResult();
        }

        private class RequestBody
        {
            [JsonRequired]
            public int Milliseconds { get; set; }
        }
    }
}
