using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knjiznica.Model
{
   public class Weather
    {
        public string Humidity { get; set; }
        public string Temp_Celsius { get; set; }
        public string Temp_Farenheit { get; set; }
        public string Wind_Speed { get; set; }
        public string Description { get; set; }
    }
}
