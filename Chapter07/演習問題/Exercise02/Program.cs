﻿
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var books = new List<Book> {
                new Book { Title = "C#プログラミングの新常識", Price = 3800, Pages = 378 },
                new Book { Title = "ラムダ式とLINQの極意", Price = 2500, Pages = 312 },
                new Book { Title = "ワンダフル・C#ライフ", Price = 2900, Pages = 385 },
                new Book { Title = "一人で学ぶ並列処理プログラミング", Price = 4800, Pages = 464 },
                new Book { Title = "フレーズで覚えるC#入門", Price = 5300, Pages = 604 },
                new Book { Title = "私でも分かったASP.NET Core", Price = 3200, Pages = 453 },
                new Book { Title = "楽しいC#プログラミング教室", Price = 2540, Pages = 348 },
            };

            Console.WriteLine("7.2.1");
            Exercise1(books);

            Console.WriteLine("7.2.2");
            Exercise2(books);

            Console.WriteLine("7.2.3");
            Exercise3(books);

            Console.WriteLine("7.2.4");
            Exercise4(books);

            Console.WriteLine("7.2.5");
            Exercise5(books);

            Console.WriteLine("7.2.6");
            Exercise6(books);

            Console.WriteLine("7.2.7");
            Exercise7(books);
        }

        private static void Exercise1(List<Book> books) {
            var book = books.FirstOrDefault(x => x.Title.Equals("ワンダフル・C#ライフ"));
            if (book is not null) 
                Console.WriteLine(book.Price + "円　" + book.Pages + "ページ");
            

        }

        private static void Exercise2(List<Book> books) {
            var count = books.Count(b => b.Title.Contains("C#"));
            Console.WriteLine(count + "冊");
        }

        private static void Exercise3(List<Book> books) {
            var titles = books.Where(x => x.Title.Contains("C#"));
            Console.WriteLine( "平均：" + titles.Average(x => x.Pages) + "ページ");
        }

        private static void Exercise4(List<Book> books) {
            var book = books.FirstOrDefault(b => b.Price >= 4000);
            if (book is not null)
                Console.WriteLine("タイトル：" + book.Title);
            else
                Console.WriteLine("4,000円未満しかない");
        }

        private static void Exercise5(List<Book> books) {
            var book = books.Where(x => x.Price < 4000);
            Console.WriteLine(book.Max(x => x.Pages) + "ページ");
        }

        private static void Exercise6(List<Book> books) {
            var book = books.Where(x => x.Pages >= 400);
            var sortbook = book.OrderByDescending(x => x.Price);
            foreach (var item in sortbook) {
                Console.WriteLine("タイトル：" + item.Title + "　" + item.Price + "円" );
            }
            
        }

        private static void Exercise7(List<Book> books) {
            var book = books.Where(x => x.Title.Contains("C#") && x.Pages <= 500);
            foreach (var item in book) {
                Console.WriteLine("タイトル：" + item.Title);
            }
        }
    }
}
