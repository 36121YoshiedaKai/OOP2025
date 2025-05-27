
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {

            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);

        }

        private static void Exercise1(List<string> langs) {
            //foreach文
            foreach (var s in langs) {
                if (s.Contains('S'))
                    Console.WriteLine(s);
            }

            Console.WriteLine();

            //for文
            for (var i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S'))
                    Console.WriteLine(langs[i]);
            }

            Console.WriteLine();

            //while文
            var index = 0;
            while (index < langs.Count) {
                if (langs[index].Contains('S'))
                    Console.WriteLine(langs[index]);
                index++;


            }
        }

        private static void Exercise2(List<string> langs) {
            var index = langs.Where(s => s.Contains('S'));
            foreach (var lang in index) {
                Console.WriteLine(lang);
            }
        }

        private static void Exercise3(List<string> langs) {

            var getfind = langs.Find(s => s.Length == 10) ?? "unknown";
            Console.WriteLine(getfind);
        }




































    }
}
