using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjiznica.Model
{
    public class TeamEvent
    {
        [JsonProperty(propertyName: "type_of_event")]
        public string EventType { get; set; }
        [JsonProperty(propertyName: "player")]
        public string PlayerName { get; set; }
    }
}
