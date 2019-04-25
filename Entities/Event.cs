using System;
using Newtonsoft.Json;

namespace DigitalApi.Entities
{
    public class Event: AbstractEntity
    {
        [JsonProperty(PropertyName = "event-id")]
        public string EventId { get; set; }

        private Use _use;
        [JsonProperty(PropertyName = "use-id")]
        public string UseId => _use.UseId;

        [JsonProperty(PropertyName = "timestamp")]
        public DateTime Timestamp { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public int Duration { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "value")]
        public object Value { get; set; }

        public Event(string eventId, Use use, DateTime timestamp, int duration, object value)
        {
            EventId = eventId;
            _use = use;
            Timestamp = timestamp;
            Duration = duration;
            Value = value;
        }
    }
}
