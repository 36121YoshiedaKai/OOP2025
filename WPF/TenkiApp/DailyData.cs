using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TenkiApp {
    public class DailyData {
        public List<double> temperature_2m_max { get; set; }
        public List<double> temperature_2m_min { get; set; }
        public List<double> wind_speed_10m_max { get; set; }
        public List<int> weathercode { get; set; } // 天気コード（アイコン表示などに利用）
    }
}
