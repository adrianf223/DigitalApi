using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Notebook: AbstractEntity
    {
        [JsonProperty(PropertyName = "manufacturer")]
        public string Manufacturer { get; set; }

        [JsonProperty(PropertyName = "procesor")]
        public string Procesor { get; set; }

        [JsonProperty(PropertyName = "os")]
        public string OperatingSystem { get; set; }
    }
}
