namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var ym = new YearMonth(2100,2);
            Console.WriteLine(ym.Is21Century);
            Console.WriteLine(ym.AddOneMonth());
            Console.WriteLine(ym.ToString());
        }
    }
}
