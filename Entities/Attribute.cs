using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Attribute : AbstractEntity
    {
        [JsonProperty(PropertyName = "attribute-id")]
        public string AttributeId { get; set; }

        [JsonProperty(PropertyName = "use-id")]
        public string UseId { get; private set; }


        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }


        public Attribute(string attributeId, Use use, DateTime timestamp, int duration,string name, object value )
        {
            AttributeId = attributeId;
            UseId = use.UseId;
            Timestamp = timestamp;
            Duration = duration;
            Name = name;
            Value = value;
        }

    }
}
