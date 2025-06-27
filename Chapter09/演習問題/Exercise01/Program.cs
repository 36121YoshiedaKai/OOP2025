using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            var dateTime = DateTime.Now;
            DisplayPattern1(dateTime);
            DisplayPattern2(dateTime);
            DisplayPattern3(dateTime);

        }

        private static void DisplayPattern1(DateTime dateTime) {
            //string.Format
            var date = string.Format($"{dateTime:yyyy/MM/dd HH:mm}");
            Console.WriteLine(date);
        }

        private static void DisplayPattern2(DateTime dateTime) {
            //DateTime.ToString
            var date = dateTime.ToString($"{dateTime:yyyy年MM月dd日 HH時mm分ss秒}");
            Console.WriteLine(date);
        }

        private static void DisplayPattern3(DateTime dateTime) {
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var dayofweek = culture.DateTimeFormat.GetDayName(dateTime.DayOfWeek);

            var str = dateTime.ToString("ggyy年M月d日", culture);
            Console.WriteLine(str + "(" + dayofweek + ")");

            //ゼロサプレス
            var cul = dateTime.ToString("gg", culture);
            var year = int.Parse(dateTime.ToString("yy", culture));
            var str2 = string.Format($"{cul}{year,2}年{dateTime.Month,2}月{dateTime.Day,2}日({dayofweek})");
            Console.WriteLine(str2);

        }
    }
}
