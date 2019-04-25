using System;
using System.Collections;
using System.Collections.Generic;
using DigitalApi.Entities;
using Newtonsoft.Json;

namespace DigitalApi.Model
{
    public class Uses : AbstractEntity, IEnumerable
    {
        [JsonProperty(PropertyName = "list")]
        public static List<Use> List { get; set; } = new List<Use>();

        public IEnumerator GetEnumerator() => List.GetEnumerator();

        public void Add(Use use) => List.Add(use);

    }
}
