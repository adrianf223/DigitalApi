
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using DigitalApi.Model;
using DigitalApi.Entities;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Collections.Generic;

namespace DigitalApi
{
    public static class UsesController
    {
        static List<Use> uses = Uses.List;


        [FunctionName("GetUses")]
        public static IActionResult GetUses([HttpTrigger(AuthorizationLevel.Function, "get", Route = Routes.Uses)]HttpRequest req, TraceWriter log)
        {
            Contract.Ensures(Contract.Result<IActionResult>() != null);
            log.Info("GET HTTP Endpoint Uses function processed a request.");

            return (ActionResult)new OkObjectResult(new UsesDto {Link = new Link("self", Routes.Uses), Uses = uses});
        }

        [FunctionName("PutUse")]
        public static async System.Threading.Tasks.Task<IActionResult> PutUseAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = Routes.Use)]HttpRequest req, string id, TraceWriter log)
        {
            var target = uses.FirstOrDefault(u => u.UseId.ToString() == id);


            string requestBody =  await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<UseDto>(requestBody);

            if (target == null)
            {
                var newuse = new Use
                {
                    Document = "Use",
                    UseId = id,
                    OwnerId = data.OwnerId,
                    NotebookId = data.NotebookId,
                    MobileId = data.NotebookId,
                    Link = new Link("self", Routes.Uses + id)
                    
                };
                uses.Add(newuse);
                return (ActionResult)new OkObjectResult(newuse);
            }

            var updated = new Use
            {
                Document = "Use",
                UseId = data.UseId,
                OwnerId = data.OwnerId,
                NotebookId = data.NotebookId,
                MobileId = data.NotebookId,
                Link = new Link("self", Routes.Uses + id)
            };

            // Replace in collection
            if (uses.IndexOf(uses.First(i => i.UseId == updated.UseId)) != -1)
            {
                uses[uses.IndexOf(uses.First(i => i.UseId == updated.UseId))] = updated;
            }

            return (ActionResult)new OkObjectResult(updated);
        }

        [FunctionName("GetUse")]
        public static IActionResult GetUse([HttpTrigger(AuthorizationLevel.Function, "get", Route = Routes.Use)]HttpRequest req, string id, TraceWriter log)
        {

            return (ActionResult)new OkObjectResult(uses.Find(u => u.UseId.ToString() == id));
        }
    }
}
