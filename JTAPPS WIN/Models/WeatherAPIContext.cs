using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTAPPS_WIN.Models
{
    internal class WeatherAPIContext
    {

        public class weather
        {
            public string icon { get; set; }

        }
        public class main
        {
            public double temp { get; set; }
        }

        public class root
        {
            public List<weather> weather { get; set; }
            public main main { get; set; }

        }
        public string IconWeatherImageLocation { get; set; }
        public string SuhuText { get; set; }
        public string FeelsLikeText { get; set; }
    }
}
