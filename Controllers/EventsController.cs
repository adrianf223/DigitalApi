
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using DigitalApi.Model;

namespace DigitalApi
{
    public static class EventsController
    {
        [FunctionName("Events")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = Routes.Events)]HttpRequest req, TraceWriter log)
        {
            log.Info("GET HTTP Endpoint Events function processed a request.");

            return (ActionResult)new OkObjectResult(new Events());
        }
    }
}
