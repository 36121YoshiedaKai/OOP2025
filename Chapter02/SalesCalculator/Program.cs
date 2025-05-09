namespace SalesCalculator {
    internal class Program {
        static void Main(string[] args) {
            SalesCounter salse = new SalesCounter(ReadSales(@"data\sales.csv"));
            Dictionary<string, int> amountsPerStore = salse.GetParStoreSales();
            foreach (KeyValuePair<string, int> obj in amountsPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }


        }

        //売り上げデータを読み込み、Saleオブジェクトのリストを返す
        static List<Sale> ReadSales(string filePath) {
            //売り上げデータを入れるリストオブジェクトを生成
            List<Sale> sales = new List<Sale>();
            //ファイルを一気に読み込む
            string[] lines = File.ReadAllLines(filePath);
            //読み込んだ行数分繰り返し
            foreach (string line in lines) {
                string[] items = line.Split(',');
                //Saleオブジェクトを生成
                Sale sale = new Sale() {
                    ShopName = items[0],
                    ProductCategory = items[1],
                    Amount = int.Parse(items[2])
                };
                sales.Add(sale);

            }

            return sales;

        }
    }
}
