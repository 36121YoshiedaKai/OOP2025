namespace Section01 {
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

            /* var exists = cities.Exists(s => s[0] == 'P');
             Console.WriteLine(exists);
             Console.WriteLine();

             var find = cities.Find(s => s.Length == 6);
             Console.WriteLine(find);
             Console.WriteLine();

             var index = cities.FindIndex(s => s == "Berlin");
             Console.WriteLine(index);
             Console.WriteLine();

             var names = cities.FindAll(s => s.Length <= 5);

             cities.ForEach(s => Console.WriteLine(s));
             Console.WriteLine();*/

                                                   //ToUpper 大文字
            var lowerList = cities.ConvertAll(s => s.ToLower());
            lowerList.ForEach(s => Console.WriteLine(s));




        }

    }
}
