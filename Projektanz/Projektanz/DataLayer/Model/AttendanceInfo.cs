using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjiznica.Model
{
    public class AttendanceInfo
    {
        [JsonProperty(propertyName: "location")]
        public string Location { get; set; }
        [JsonProperty(propertyName: "attendance")]
        public string Attendance { get; set; }
        [JsonProperty(propertyName: "home_team_country")]
        public string HomeTeam { get; set; }
        [JsonProperty(propertyName: "away_team_country")]
        public string AwayTeam { get; set; }
    }
}
