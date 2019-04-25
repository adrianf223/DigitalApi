
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using DigitalApi.Model;
using DigitalApi.Entities;
using System.Linq;
using System.Collections.Generic;

namespace DigitalApi
{
    public static class AttributesController
    {
        static List<Attribute> attributes = Attributes.List;
        static List<Use> uses = Uses.List;

        [FunctionName("GetAttributes")]
        public static IActionResult GetAttributes([HttpTrigger(AuthorizationLevel.Function, "get", Route = Routes.Attributes)]HttpRequest req, TraceWriter log)
        {
            if (req == null)
            {
                throw new System.ArgumentNullException(nameof(req));
            }

            log.Info("GET HTTP Endpoint Uses function processed a request.");

            var returning = new AttributesDto
            {
                List = attributes
            };

            return (ActionResult)new OkObjectResult(returning);
        }

        [FunctionName("PutAttribute")]
        public static async System.Threading.Tasks.Task<IActionResult> PutAttributeAsync([HttpTrigger(AuthorizationLevel.Function, "put", Route = Routes.Attribute)]HttpRequest req, string id, TraceWriter log)
        {
            log.Info("PUT HTTP Endpoint Attribute function processed a request.");

            var target = attributes.FirstOrDefault(a => a.AttributeId.ToString() == id);

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<AttributeDto>(requestBody);
            var refer = uses.FirstOrDefault(u => u.UseId.ToString() == data.UseId);
            if (refer == null)
            {
                return (ActionResult)new BadRequestResult();
            }


            if (target == null)
            {
                var newattribute = new Attribute(id, refer, data.Timestamp, data.Duration, data.Name, data.Value)
                {
                    Document = "attribute",
                    Link = new Link("self", Routes.Attributes + id)
                };

                attributes.Add(newattribute);
                return (ActionResult)new OkObjectResult(newattribute);
            }

            var updated = new Attribute(id, refer, data.Timestamp, data.Duration, data.Name, data.Value);
            updated.Document = "attribute";
            updated.Link = new Link("self", Routes.Attributes + id);

            // Replace in collection
            if (attributes.IndexOf(attributes.First(i => i.UseId == updated.UseId)) != -1)
            {
                attributes[attributes.IndexOf(attributes.First(i => i.UseId == updated.UseId))] = updated;
            }

            return (ActionResult)new OkObjectResult(updated);
        }

        [FunctionName("GetAttribute")]
        public static IActionResult GetAttribute([HttpTrigger(AuthorizationLevel.Function, "get", Route = Routes.Attribute)]HttpRequest req, string id, TraceWriter log)
        {
            if (req == null)
            {
                throw new System.ArgumentNullException(nameof(req));
            }

            log.Info("GET HTTP Endpoint Attribute function processed a request.");

            var refer = attributes.Find(u => u.AttributeId.ToString() == id);
            var target = new AttributeDto {
                AttributeId = refer.AttributeId,
                UseId = refer.UseId,

            };

            return refer == null
                ? (ActionResult)new BadRequestResult()
                : (ActionResult)new OkObjectResult(attributes.Find(u => u.AttributeId.ToString() == id));
        }

    }
}
