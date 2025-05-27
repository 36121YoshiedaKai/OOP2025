
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];

            Console.WriteLine("7.1.1");
            Exercise1(numbers);

            Console.WriteLine("7.1.2");
            Exercise2(numbers);

            Console.WriteLine("7.1.3");
            Exercise3(numbers);

            Console.WriteLine("7.1.4");
            Exercise4(numbers);

            Console.WriteLine("7.1.5");
            Exercise5(numbers);
        }

        private static void Exercise1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise2(int[] numbers) {
            //var i = numbers.Count() - 2;
            //Console.WriteLine(numbers[i]);
            //Console.WriteLine(numbers[i + 1]);
            foreach (var n in numbers.Skip(numbers.Length - 2)) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise3(int[] numbers) {
            var num = numbers.Select(n => n.ToString("000")).ToList();
            for (int i = 0; i < numbers.Length; i++) {
                Console.WriteLine(num[i]);
            }


        }

        private static void Exercise4(int[] numbers) {
            var sortnumbers = numbers.OrderBy(n => n).ToList();
            for (int i = 0; i < 3; i++) {
                Console.WriteLine(sortnumbers[i]);
            }
        }

        private static void Exercise5(int[] numbers) {
            var disnumbers = numbers.Distinct().ToList();
            Console.WriteLine(disnumbers.Count(n => n > 10));
        }
    }
}
