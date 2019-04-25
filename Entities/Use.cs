using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Use: AbstractEntity
    {
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
