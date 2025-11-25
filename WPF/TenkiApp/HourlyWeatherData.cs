using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkiApp {
    public class HourlyWeatherData {
        public List<string> time { get; set; }
        public List<double> temperature_2m { get; set; }
        public List<double> wind_speed_10m { get; set; }
        public List<int> weathercode { get; set; }
    }

}
