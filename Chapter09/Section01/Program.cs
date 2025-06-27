using System.Globalization;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var today = new DateTime(2025, 7, 12); //日付p.196あたりから
            //var now = DateTime.Now;     //日付と時刻


            //Console.WriteLine($"Today : {today}");
            //Console.WriteLine($"Now : {now}");

            //①自分の生年月日は何曜日かをプログラムで調べる
            Console.WriteLine("日付を入力");
            Console.Write("西暦:");
            var by = int.Parse(Console.ReadLine());
            Console.Write("月:");
            var bm = int.Parse(Console.ReadLine());
            Console.Write("日:");
            var bd = int.Parse(Console.ReadLine());
            var b = new DateTime(by, bm, bd);


            //元号
            var culture = new CultureInfo("ja-JP");
            culture.DateTimeFormat.Calendar = new JapaneseCalendar();
            //var era = culture.DateTimeFormat.Calendar.GetEra(b);
            //var eraName = culture.DateTimeFormat.GetEraName(era);
            var str = b.ToString("ggyy年M月d日", culture);


            //曜日を日本語に
            var dayofweek = culture.DateTimeFormat.GetDayName(b.DayOfWeek);
            Console.WriteLine($"{str}は{dayofweek}です");

            //日数経過
            var today = DateTime.Today;
            var fday = today - b;
            Console.WriteLine($"生まれてから{fday.TotalDays}日目です");

            //歳
            var old = today.Year - b.Year;
            if (today < b.AddYears(old))old --;

            Console.WriteLine($"あなたは{ old}歳です！");

            //１月１日から何日か
            Console.WriteLine(today.DayOfYear);
            

            //うるう年
            Console.Write("西暦入力:");
            var year = int.Parse(Console.ReadLine());
            var leap = DateTime.IsLeapYear(year);
            if (leap)
                Console.WriteLine($"{year}は閏年です");
            else
                Console.WriteLine($"{year}は閏年ではありません");

        }
    }
}
