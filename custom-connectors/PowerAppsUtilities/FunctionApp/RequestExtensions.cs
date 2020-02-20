using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;
using System.Threading.Tasks;

namespace PowerPlatformConnectors.PowerAppsUtilitiesViaAzureFunctions
{
    internal static class RequestExtensions
    {
        public static async Task<T> ReadAsJsonAsync<T>(this HttpRequest req)
        {
            // TODO: Add automatic handling of JsonException so it returns a 400 instead of 500.
            string bodyJson = await req.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(bodyJson);
        }
    }
}
