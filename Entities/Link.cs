using System;
using System.Collections.Generic;

namespace DigitalApi.Entities
{
    public class Link
    {
        private Dictionary<string, Dictionary<string, string>> _link;

        public string Rel { get; set; }

        public string Href { get; set; }

        public Link(string rel, string href)
        {
            Rel = rel;
            Href = href;

            _link = new Dictionary<string, Dictionary<string, string>>
            {
                { rel, new Dictionary<string, string> { { "href", href } } }
            };

        }
    }
}
