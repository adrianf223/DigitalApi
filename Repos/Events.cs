using System;
using System.Collections;
using System.Collections.Generic;
using DigitalApi.Entities;
using Newtonsoft.Json;

namespace DigitalApi.Model
{
    public class Events : AbstractEntity, IEnumerable
    {
        [JsonProperty(PropertyName = "list")]
        public List<Event> List { get; set; }

        public IEnumerator GetEnumerator() => List.GetEnumerator();

    }
}
