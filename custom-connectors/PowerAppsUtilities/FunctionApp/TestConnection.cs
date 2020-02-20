using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace PowerPlatformConnectors.PowerAppsUtilitiesViaAzureFunctions
{
    public static class TestConnection
    {
        // TODO: Need to verify this is configured correctly for custom connectors.
        [FunctionName("TestConnection")]
        public static IActionResult Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            return new OkResult();
        }
    }
}
