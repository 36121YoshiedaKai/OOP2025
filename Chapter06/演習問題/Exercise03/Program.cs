
using System.Diagnostics.Metrics;
using System.Reflection;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

        }

        private static void Exercise1(string text) {
            //Console.Write("空白は");
            //Console.WriteLine(text.Count(c => c == ' '));
            //Console.WriteLine(text.Count(char.IsWhiteSpace));
            var spaces = text.Count(c => c == ' ');
            Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {
            
        }

        private static void Exercise4(string text) {
            var word = text.Split(' ');
            Console.WriteLine(word.Count());
        }

        private static void Exercise5(string text) {
            //var words = text.Split(' ').Where(s => s.Length <= 4);
            var word = text.Split(' ');
            foreach (var item in word.Where(s => s.Length <= 4)) {
                Console.WriteLine(item);
            }

        }
    }
}
