using System;
using DigitalApi.Entities;
using Newtonsoft.Json;

namespace DigitalApi.Model
{
    public class AttributeDto
    {
        [JsonProperty(PropertyName = "document")]
        public const string Document = "attribute";

        [JsonProperty(PropertyName = "attribute-id")]
        public string AttributeId { get; set; }

        [JsonProperty(PropertyName = "use-id")]
        public string UseId { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        [JsonProperty(PropertyName = "link")]
        public Link Link { get; set; }

    }
}
