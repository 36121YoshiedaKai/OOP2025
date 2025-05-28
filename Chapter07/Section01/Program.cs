using System.ComponentModel;
using System.Diagnostics;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {

            var books = Books.GetBooks();

            //①本の平均金額
            Console.WriteLine("①");
            Console.WriteLine(books.Average(x => x.Price));

            //②本のページを合計
            Console.WriteLine("②");
            Console.WriteLine(books.Sum(x => x.Pages));

            //③金額が安い書籍名と金額を表示
            Console.WriteLine("③");

            var book = books.Where(x => x.Price == books.Min(b => b.Price));
            foreach(var item in book) {
                Console.WriteLine(item.Title + ":" + item.Price);
            }
            

            //var minbook = books.Min(x => x.Price);
            //foreach (var yasbook in books) {
            //    if (minbook == yasbook.Price)
            //        Console.WriteLine(yasbook.Title + ":" + yasbook.Price);
            //}

            //④ページが多い書籍名とページ数を表示
            Console.WriteLine("④");

            var maxbooks = books.Where(x => x.Pages == books.Max(b => b.Pages));
            foreach (var item in maxbooks) {
                Console.WriteLine(item.Title + ":" + item.Pages);
            }

            //var maxbook = books.Max(x => x.Pages);
            //foreach (var pagebook in books) {
            //    if (maxbook == pagebook.Pages)
            //        Console.WriteLine(pagebook.Title + ":" + pagebook.Pages);
            //}



            //⑤タイトルに「物語」が含まれている書籍名をすべて表示
            Console.WriteLine("⑤");

            var titles = books.Where(x => x.Title.Contains("物語"));
            foreach (var item in titles) {
                Console.WriteLine(item.Title);
            }

            //foreach (var monobook in books) {
            //    if (monobook.Title.Contains("物語"))
            //        Console.WriteLine(monobook.Title);
            //}


        }
    }
}
