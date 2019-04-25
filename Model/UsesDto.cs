using System;
using System.Collections.Generic;
using DigitalApi.Entities;
using Newtonsoft.Json;

namespace DigitalApi.Model
{
    public class UsesDto: AbstractEntity
    {
        [JsonProperty(PropertyName = "uses")]
        public List<Use> Uses { get; set; }
    }
}
