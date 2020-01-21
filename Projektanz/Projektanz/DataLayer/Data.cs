using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Knjiznica.Model;
using System.IO;

namespace Knjiznica
{
    public static class Data
    {
        private static System.Net.WebRequest WebRequest { get; set; }
        //Pulling countries with RestSharp
        public static async Task<List<Country>> GetCountries(string url)
        {
            var client = new RestClient(url);

            var response = await client.ExecuteTaskAsync<List<Country>>(new RestRequest());

            return response.Data;
        }

        //Pulling players with Newtonsoft
        public static async Task<List<Player>> GetPlayersForCountry(string url, string fifaCode)
        {
            List<TeamEvent> teamEvents;
            List<Player> players;
            using (WebClient wc = new WebClient())
            {
                var matchesString = wc.DownloadString(url);

                JArray matches = JArray.Parse(matchesString);

                string homeTeam = matches[0]["home_team"]["code"].ToString();

                if (homeTeam == fifaCode)
                {
                    var starters = await Task.Run(() => JsonConvert.DeserializeObject<List<Player>>(matches[0]["home_team_statistics"]["starting_eleven"].ToString()));
                    var substitutes = await Task.Run(() => JsonConvert.DeserializeObject<List<Player>>(matches[0]["home_team_statistics"]["substitutes"].ToString()));
                    players = new List<Player>(starters.Union(substitutes));
                }
                else
                {
                    var starters = await Task.Run(() => JsonConvert.DeserializeObject<List<Player>>(matches[0]["away_team_statistics"]["starting_eleven"].ToString()));
                    var substitutes = await Task.Run(() => JsonConvert.DeserializeObject<List<Player>>(matches[0]["away_team_statistics"]["substitutes"].ToString()));
                    players = new List<Player>(starters.Union(substitutes));
                }

                foreach (var match in matches)
                {
                    string homeTeamInMatch = match["home_team"]["code"].ToString();
                    string teamEventsString;
                    if (homeTeamInMatch == fifaCode)
                    {
                        teamEventsString = match["home_team_events"].ToString();
                        teamEvents = await Task.Run(() => JsonConvert.DeserializeObject<List<TeamEvent>>(teamEventsString));
                        foreach (var evt in teamEvents)
                        {
                            if (evt.EventType == "yellow-card" || evt.EventType == "goal-penalty" || evt.EventType == "goal")
                            {
                                foreach (var player in players)
                                {
                                    if (player.Name.ToLower() == evt.PlayerName.ToLower())
                                    {
                                        if (evt.EventType == "yellow-card")
                                        {
                                            player.YellowCards++;
                                            break;
                                        }
                                        else if (evt.EventType == "goal-penalty" || evt.EventType == "goal")
                                        {
                                            player.Goals++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        teamEventsString = match["away_team_events"].ToString();
                        teamEvents = await Task.Run(() => JsonConvert.DeserializeObject<List<TeamEvent>>(teamEventsString));
                        foreach (var evt in teamEvents)
                        {
                            if (evt.EventType == "yellow-card" || evt.EventType == "goal-penalty" || evt.EventType == "goal")
                            {
                                foreach (var player in players)
                                {
                                    if (player.Name.ToLower() == evt.PlayerName.ToLower())
                                    {
                                        if (evt.EventType == "yellow-card")
                                        {
                                            player.YellowCards++;
                                            break;
                                        }
                                        else if (evt.EventType == "goal-penalty" || evt.EventType == "goal")
                                        {
                                            player.Goals++;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    } 
                }
                return players;
            }
        }

        //Pulling attendance data with Newtonsoft
        public static async Task<List<AttendanceInfo>> GetAttendanceInfoForCountry(string url)
        {
            List<AttendanceInfo> attendanceList = new List<AttendanceInfo>();
            using (WebClient wc = new WebClient())
            {
                var matchesString = wc.DownloadString(url);

                JArray matches = JArray.Parse(matchesString);

                foreach (var match in matches)
                {
                    var matchAttendanceInfo = await Task.Run(() => JsonConvert.DeserializeObject<AttendanceInfo>(match.ToString()));
                    attendanceList.Add(matchAttendanceInfo);
                }
                return attendanceList;
            }
        }

        #region
        //public static async Task<List<Matches>> GetMatchesForCountry(string url)
        //{
        //    //List<TeamEvent> teamEvents;
        //    //List<Matches> players;
        //    //using (WebClient wc = new WebClient())
        //    //{
        //    //    var matchesString = wc.DownloadString(url);

        //    //    JArray matches = JArray.Parse(matchesString);

        //    //    string homeTeam = matches[0]["home_team"]["code"].ToString();

        //    //    if (homeTeam == fifaCode)
        //    //    {
        //    //        var starters = await Task.Run(() => JsonConvert.DeserializeObject<List<Matches>>(matches[0]["home_team"]["country"]["code"].ToString()));
        //    //        var substitutes = await Task.Run(() => JsonConvert.DeserializeObject<List<Matches>>(matches[0]["home_team_statistics"]["substitutes"].ToString()));
        //    //        players = new List<Matches>(starters.Union(substitutes));
        //    //    }
        //    //    else
        //    //    {
        //    //        var starters = await Task.Run(() => JsonConvert.DeserializeObject<List<Matches>>(matches[0]["away_team"]["country"]["code"].ToString()));
        //    //       var substitutes = await Task.Run(() => JsonConvert.DeserializeObject<List<Matches>>(matches[0]["away_team_statistics"]["substitutes"].ToString()));
        //    //        players = new List<Matches>(starters.Union(substitutes));
        //    //    }


        //    //    return players;

        //    var client = new RestClient(url);

        //    var response = await client.ExecuteTaskAsync<List<Matches>>(new RestRequest());

        //    return response.Data;
        //}
        #endregion

        public static async Task<List<Matches>> GetMatches(String fifa_code)
        {
            WebRequest = WebRequest.Create($"https://worldcup.sfg.io/matches/country?fifa_code={fifa_code}") as HttpWebRequest;
            using (var stream = WebRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    return
                        await Task.Run(() => JsonConvert
                        .DeserializeObject<List<Matches>>(contributorsAsJson))
                        .ConfigureAwait(false);
                }
            }
        }
        public async static Task<List<Country>> GetTeams()
        {
            WebRequest = WebRequest.Create("https://worldcup.sfg.io/teams/results") as HttpWebRequest;
            using (var stream = WebRequest.GetResponse().GetResponseStream())
            {
                using (var sr = new StreamReader(stream))
                {
                    var contributorsAsJson = sr.ReadToEnd();
                    return
                        await Task.Run(() => JsonConvert
                        .DeserializeObject<List<Country>>(contributorsAsJson))
                        .ConfigureAwait(false);
                }
            }
        }
    }
}
