using System.Net.WebSockets;
using System.Text.RegularExpressions;

namespace Exercise04 {
    internal class Program {
        static void Main(string[] args) {
            var lines = File.ReadAllLines("sample.txt");

            var newlines = lines.Select(s => Regex.Replace(s, @"((v|V)ersion)\s*=\s*""v4.0""",@"$1=""v5.0"""));

            File.WriteAllLines("sampleChange.text", newlines);

            var text = File.ReadAllText("sampleChange.text");
            Console.WriteLine(text);
        }
    }
}
