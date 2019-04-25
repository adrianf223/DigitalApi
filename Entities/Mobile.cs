using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Mobile: AbstractEntity
    {
        [JsonProperty(PropertyName = "brand")]
        public String Brand { get; set; }

        [JsonProperty(PropertyName = "model")]
        public String Model { get; set; }
    }
}
