using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            string[] texts = [
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            ];
            foreach (var line in texts) {
                var matches = Regex.Matches(line,@"\b(time)\b",RegexOptions.IgnoreCase);
                foreach(Match match in matches) {
                    Console.WriteLine($"{line}:{match.Index}");
                }
            }
            

        }
    }
}
