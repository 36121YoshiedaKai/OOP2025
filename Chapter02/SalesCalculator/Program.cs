namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            var salse = new SalesCounter(@"data\sales.csv");
            var amountsPerStore = salse.GetParStoreSales();
            foreach (var obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }
    }
}
