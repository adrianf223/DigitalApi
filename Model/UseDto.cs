using System;
using DigitalApi.Entities;
using Newtonsoft.Json;

namespace DigitalApi.Model
{
    public class UseDto
    {
        [JsonProperty(PropertyName = "document")]
        public const string Document = "use";

        [JsonProperty(PropertyName = "use-id")]
        public string UseId { get; set; }

        [JsonProperty(PropertyName = "owner-id")]
        public string OwnerId { get; set; }

        [JsonProperty(PropertyName = "notebook-id")]
        public string NotebookId { get; set; }

        [JsonProperty(PropertyName = "mobile-id")]
        public string MobileId { get; set; }

    }
}
