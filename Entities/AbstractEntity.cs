using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class AbstractEntity
    {
        [JsonProperty(PropertyName = "document")]
        public string Document { get; set; }

        [JsonProperty(PropertyName = "link")]
        public Link Link { get; set; }

    }
}
