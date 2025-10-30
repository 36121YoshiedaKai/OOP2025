
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            Exercise1_2();
            Console.WriteLine();
            Exercise1_3();
            Console.WriteLine();
            Exercise1_4();
            Console.WriteLine();
            Exercise1_5();
            Console.WriteLine();
            Exercise1_6();
            Console.WriteLine();
            Exercise1_7();
            Console.WriteLine();
            Exercise1_8();

            Console.ReadLine();
        }

        private static void Exercise1_2() {
            var book = Library.Books.MaxBy(b => b.Price);
            Console.WriteLine(book);
        }

        private static void Exercise1_3() {
            var groups = Library.Books.GroupBy(b => b.PublishedYear).OrderBy(g => g.Key);
            foreach (var group in groups) {
                Console.WriteLine($"{group.Key} : {group.Count()}");
            }
        }

        private static void Exercise1_4() {
            var selected = Library.Books
                .OrderByDescending(b => b.PublishedYear)
                .ThenByDescending(b => b.Price);
            foreach (var book in selected) { 
                Console.WriteLine($"{book.PublishedYear}年 {book.Price}円 {book.Title} ");
            }
        }

        private static void Exercise1_5() {
            var books = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    Category = category.Name,
                    book.PublishedYear
                }).Where(b => b.PublishedYear == 2022).Distinct();
            foreach (var book in books) {
                Console.WriteLine($"{book.Category}");
            }
        }

        private static void Exercise1_6() {
            var books = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    book.Title,
                    Category = category.Name,
                }).GroupBy(b => b.Category);
            foreach (var item in books) {
                Console.WriteLine($"# {item.Key}");
                foreach (var book in item) {
                    Console.WriteLine($"    {book.Title}");

                }
            }
        }

        private static void Exercise1_7() {
            var books = Library.Books
                .Join(Library.Categories,
                book => book.CategoryId,
                category => category.Id,
                (book, category) => new {
                    book.Title,
                    Category = category.Name,
                    book.PublishedYear
                }).Where(c => c.Category == "Development")
                .GroupBy(b => b.PublishedYear);
            foreach (var item in books) {
                Console.WriteLine($"# {item.Key}");
                foreach (var book in item) {
                    Console.WriteLine($"    {book.Title}");

                }
            }

        }

        private static void Exercise1_8() {
            var cbooks = Library.Categories.GroupJoin(Library.Books,
                c => c.Id,
                b => b.CategoryId,
                (c, books) => new {
                    Category = c.Name,
                    Count = books.Count(),
                }).Where(b => b.Count >= 4);
            foreach (var item in cbooks) {
                Console.WriteLine($"{item.Category}");
            }
        }
    }
}
