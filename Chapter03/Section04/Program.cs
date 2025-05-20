using System.Data.Common;

namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };



            var query = cities.Where(s => s.Length <= 5);　//.ToArray();    //即時実行

            foreach (var item in query) {
                Console.WriteLine(item);
            }
            Console.WriteLine("------");

            cities[0] = "Osaka";            //- cities[0]を変更 
            foreach (var item in query) {   //- 再度、queryの内容を取り出す  遅延実行
                Console.WriteLine(item);
            }


            //IEnumerable<string> query = cities
            //    //.Where(s => s.Length <= 5)      //条件に合ったものを抽出
            //    //.Select(s => s.ToLower());      //別のオブジェクトへ変換（新しい型へ射影する）
            //    //.Select(s => s.ToUpper());
            //    .OrderBy(s => s);

            //foreach (var s in query) {
            //    Console.WriteLine(s);
            //}



        }
    }
}
