using System.Collections;
using System.Collections.Generic;
using DigitalApi.Entities;
using Newtonsoft.Json;

namespace DigitalApi.Model
{
    public class Attributes: AbstractEntity, IEnumerable
    {
        [JsonProperty(PropertyName = "list")]
        static public List<Attribute> List { get; set; } = new List<Attribute>();

        public IEnumerator GetEnumerator() => List.GetEnumerator();
        public void Add(Attribute attribute) => List.Add(attribute);

    }
}
