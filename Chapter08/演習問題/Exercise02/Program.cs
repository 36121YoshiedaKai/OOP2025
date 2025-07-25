﻿namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            // コンストラクタの呼び出し
            var abbrs = new Abbreviations();
            Console.WriteLine(abbrs.Count);
            Console.WriteLine();

            if (abbrs.Remove("NTP")) Console.WriteLine(abbrs.Count);
            if (!abbrs.Remove("NTP")) Console.WriteLine("削除できません");
            Console.WriteLine();
            // Addメソッドの呼び出し例
            abbrs.Add("IOC", "国際オリンピック委員会");
            abbrs.Add("NPT", "核兵器不拡散条約");


            var query = abbrs.GetAll().Where(x => x.Key.Length == 3);

            // Getメソッドの利用例
            var names = new[] { "WHO", "FIFA", "NPT", };
            foreach (var name in names) {
                var fullname = abbrs.Get(name);
                if (fullname is null) {
                    Console.WriteLine($"{name}は見つかりません");
                } else {
                    Console.WriteLine($"{name}={fullname}");
                }
            }
            Console.WriteLine();

            // ToAbbreviationメソッドの利用例
            var japanese = "東南アジア諸国連合";
            var abbreviation = abbrs.ToAbbreviation(japanese);
            if (abbreviation is null) {
                Console.WriteLine($"{japanese} は見つかりません");
            } else {
                Console.WriteLine($"「{japanese}」の略語は {abbreviation} です");
            }
            Console.WriteLine();

            // FindAllメソッドの利用例
            foreach (var (key, value) in abbrs.FindAll("国際")) {
                Console.WriteLine($"{key}={value}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
