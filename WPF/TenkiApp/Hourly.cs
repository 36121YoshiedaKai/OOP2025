using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkiApp {
    public class Hourly {
        public string Time { get; set; }
        public string Temperature { get; set; }
        public string WindSpeed { get; set; }
        public List<string> time { get; set; }
        public List<double> temperature_2m { get; set; }
        public List<double> wind_speed_10m { get; set; }
    }

    
}
