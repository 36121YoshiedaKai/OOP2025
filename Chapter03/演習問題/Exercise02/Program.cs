﻿
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> cities) {
            Console.WriteLine("都市名を入力。空行で終了");
            while (true) {
                var name = Console.ReadLine();
                if (string.IsNullOrEmpty(name)) break;
                var index = cities.FindIndex(s => s.Equals(name));
                Console.WriteLine(index);
            }

        }

        private static void Exercise2_2(List<string> cities) {
            Console.WriteLine(cities.Count(s => s.Contains('o')));
        }

        private static void Exercise2_3(List<string> cities) {
            var city = cities.Where(s => s.Contains('o'));
            foreach (var cityname in city) {
                Console.WriteLine(cityname);
            }
        }

        private static void Exercise2_4(List<string> cities) {
            var obj = cities.Where(s => s.StartsWith('B'))
                .Select(s => new { s, s.Length });
            foreach (var data in obj) {
                Console.WriteLine(data.s + ":" + data.Length);
            }
        }
    }
}
