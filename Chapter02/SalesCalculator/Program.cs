namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter salse = new SalesCounter(@"data\sales.csv");
            IDictionary<string, int> amountsPerStore = salse.GetParStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }
    }
}
