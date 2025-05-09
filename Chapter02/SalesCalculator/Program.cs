namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter salse = new SalesCounter(SalesCounter.ReadSales(@"data\sales.csv"));
            Dictionary<string, int> amountsPerStore = salse.GetParStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }



        }


    }
}
