using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarReportSystem {
    public class Settings {

        private static Settings instance;

        //格納した色情報を格納
        public int MainFormBackColor { get; set; }

        //コンストラクタ（priveteでNEWできない）
        private Settings() { }

        public static Settings getInstance() {
            if(instance == null) {
                instance = new Settings();
            }
            return instance;
        }
    }
}
