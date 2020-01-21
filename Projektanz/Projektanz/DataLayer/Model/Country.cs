using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Deserializers;

namespace Knjiznica.Model
{
    public class Country
    {
        private const char _del = '|';

        [DeserializeAs(Name = "id")]
        public int Id { get; set; }
        [DeserializeAs(Name = "country")]
        public string CountryName { get; set; }
        [DeserializeAs(Name = "alternate_name")]
        public string AlternateName { get; set; }
        [DeserializeAs(Name = "fifa_code")]
        public string FifaCode { get; set; }
        [DeserializeAs(Name = "group_id")]
        public string GroupId { get; set; }
        [DeserializeAs(Name = "group_letter")]
        public string GroupLetter { get; set; }
        [DeserializeAs(Name = "wins")]
        public int Wins { get; set; }
        [DeserializeAs(Name = "draws")]
        public int Draws { get; set; }
        [DeserializeAs(Name = "losses")]
        public int Losses { get; set; }
        [DeserializeAs(Name = "games_played")]
        public int GamesPlayed { get; set; }
        [DeserializeAs(Name = "points")]
        public int Points { get; set; }
        [DeserializeAs(Name = "goals_for")]
        public int GoalsFor { get; set; }
        [DeserializeAs(Name = "goals_against")]
        public int GoalsAgainst { get; set; }
        [DeserializeAs(Name = "goal_differential")]
        public int GoalDifferential { get; set; }

        internal string FormatForWriting() => $"{Id}{_del}{CountryName}{_del}{AlternateName}{_del}{FifaCode}"+
        $"{_del}{GroupId}{_del}{GroupLetter}{_del}{Wins}{_del}{Draws}" +
        $"{_del}{Losses}{_del}{GamesPlayed}{_del}{Points}{_del}{GoalsFor}" +
       $"{_del}{GoalsAgainst}{_del}{GoalDifferential}{_del}";

        public string TeamName() => $"{CountryName} {FifaCode}";


        internal static Country ParseFromFileLine(string line)
        {
            string[] splittedLines = line.Split(_del);

            return new Country
            {
                Id = int.Parse(splittedLines[0]),
                CountryName = splittedLines[1],
                AlternateName = splittedLines[2],
                FifaCode = splittedLines[3],
                GroupId = splittedLines[4],
                GroupLetter = splittedLines[5],
                Wins = int.Parse(splittedLines[6]),
                Draws = int.Parse(splittedLines[7]),
                Losses = int.Parse(splittedLines[8]),
                GamesPlayed = int.Parse(splittedLines[9]),
                Points = int.Parse(splittedLines[10]),
                GoalsFor = int.Parse(splittedLines[11]),
                GoalsAgainst = int.Parse(splittedLines[12]),
                GoalDifferential = int.Parse(splittedLines[13])
            };
        }
    }
}
