using System;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;
using System.Net.Mime;
using Newtonsoft.Json.Linq;

namespace PowerPlatformConnectors.PowerAppsUtilitiesViaAzureFunctions
{
    internal static class CreateResponseMessage
    {
        public static HttpResponseMessage BadRequest(string errorMessage)
        {
            var json = JsonConvert.SerializeObject(new JObject { ["message"] = errorMessage });
            return new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json)
            };
        }

        public static HttpResponseMessage JsonData<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json)
            };
        }
    }
}
