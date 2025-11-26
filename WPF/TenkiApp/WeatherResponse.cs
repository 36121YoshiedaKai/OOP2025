using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkiApp {
    public class WeatherResponse {
        public Current? current { get; set; }
        public HourlyWeatherData hourly { get; set; }
        public DailyData daily { get; set; }
    }
}