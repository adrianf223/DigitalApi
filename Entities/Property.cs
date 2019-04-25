using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Property: AbstractEntity
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
    }
}
