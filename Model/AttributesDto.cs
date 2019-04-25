using System;
using System.Collections.Generic;
using DigitalApi.Entities;
using Newtonsoft.Json;
using Attribute = DigitalApi.Entities.Attribute;

namespace DigitalApi.Model
{
    public class AttributesDto: AbstractEntity
    {

        [JsonProperty(PropertyName = "attributes")]
        public List <Attribute> List { get; set; }

    }
}
