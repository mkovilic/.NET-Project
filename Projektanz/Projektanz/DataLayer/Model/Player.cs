using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;
using Newtonsoft.Json;

namespace Knjiznica.Model
{
    public class Player
    {
        private const char _del = '|';

        [JsonProperty(propertyName: "name")]
        public string Name { get; set; }
        [JsonProperty(propertyName: "captain")]
        public bool IsCaptain { get; set; }
        [JsonProperty(propertyName: "shirt_number")]
        public string Number { get; set; }
        [JsonProperty(propertyName: "position")]
        public string Position { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public bool Favorite { get; set; }

        internal string FormatForWriting() => $"{Name}{_del}{IsCaptain}{_del}{Number}{_del}{Position}{_del}{Favorite}";


        internal static Player ParseFromFileLine(string line)
        {
            string[] splittedLines = line.Split(_del);

            return new Player
            {
                Name = splittedLines[0],
                IsCaptain = (splittedLines[1] == "true") ? true : false,
                Number = splittedLines[2],
                Position = splittedLines[3],
                Favorite = (splittedLines[4] == "true") ? true : false
            };
        }
    }
}