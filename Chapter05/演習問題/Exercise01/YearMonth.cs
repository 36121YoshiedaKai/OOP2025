using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise01 {
    // 5.1.1
    public class YearMonth {
        public int Year { get; init; }
        public int Month { get; init; }

        public YearMonth(int year, int month) {
            Year = year;
            Month = month;
        }

        //5.1.2
        public bool Is21Century => Year >= 2001 && Year <= 2100;

        //5.1.3
        public YearMonth AddOneMonth() {
            var nextYear = Year;
            var nextMonth = Month;
            if (nextMonth == 12) {
                nextYear += 1;
                nextMonth = 1;
            } else {
                nextMonth += 1;
            }
            return new YearMonth(nextYear, nextMonth) ;
        }

        //5.1.4
        public override string ToString() => Year + "年" + Month + "月";


    }
}
