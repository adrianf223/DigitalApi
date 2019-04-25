using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Feature: AbstractEntity
    {
        [JsonProperty(PropertyName = "name")]
        public String Name { get; set; }
    }
}
