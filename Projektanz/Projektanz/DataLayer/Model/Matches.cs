using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjiznica.Model
{
  public  class Matches
    {
        public string Venue { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public string Time { get; set; }
        public string Fifa_Id { get; set; }
        public Weather Weather { get; set; }
        public string Attendance { get; set; }
        public List<string> Officials { get; set; }
        public string Stage_Name { get; set; }
        public string Home_Team_Country { get; set; }
        public string Away_Team_Country { get; set; }
        public string Datetime { get; set; }
        public string Winner { get; set; }
        public string Winner_Code { get; set; }
        public Team Home_Team { get; set; }
        public Team Away_Team { get; set; }
        public List<TeamEvent> Home_Team_Events { get; set; }
        public List<TeamEvent> Away_Team_Events { get; set; }
        public CountryStatistics Home_Team_Statistics { get; set; }
        public CountryStatistics Away_Team_Statistics { get; set; }
        public string Last_Eleven_Update_At { get; set; }
        public string Last_Score_Update_At { get; set; }
    }
}
