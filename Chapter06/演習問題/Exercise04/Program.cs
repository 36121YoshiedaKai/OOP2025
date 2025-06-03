using System;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var line = "Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886";
            var words = line.Split(';');

            foreach (var item in words) {
                var word = item.Split('=');
                Console.WriteLine($"{ToJapanese(word[0])}:{word[1]}");
            }

        }

        /// <summary>
        /// 引数の単語を日本語へ変換します
        /// </summary>
        /// <param name="key">"Novelist","BestWork","Born"</param>
        /// <returns>"「作家」,「代表作」,「誕生年」</returns>
        static string ToJapanese(string key) {

            //switch (key) {
            //    case "Novelist":
            //        var nov = key.Replace("Novelist", "作家");
            //        return (nov);
            //    case "BestWork":
            //        var bw = key.Replace("BestWork", "代表作");
            //        return (bw);
            //    case "Born":
            //        var born = key.Replace("Born", "誕生年");
            //        return (born);
            //    default:
            //        return "正しい値ではない";
            //}

            return key switch {
                "Novelist" => "作家",
                "BestWork" => "代表作",
                "Born" => "誕生年",
                _ => "正しい値ではない"
            };



        }
    }
}