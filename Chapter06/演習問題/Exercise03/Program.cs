
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";

            Console.WriteLine("6.3.1");
            Exercise1(text);

            Console.WriteLine("6.3.2");
            Exercise2(text);

            Console.WriteLine("6.3.3");
            Exercise3(text);

            Console.WriteLine("6.3.4");
            Exercise4(text);

            Console.WriteLine("6.3.5");
            Exercise5(text);

            Console.WriteLine("6.3.99");
            Exercise6(text);

        }

        private static void Exercise1(string text) {
            //Console.Write("空白は");
            //Console.WriteLine(text.Count(c => c == ' '));
            //Console.WriteLine(text.Count(char.IsWhiteSpace));
            var spaces = text.Count(c => c == ' ');
            Console.WriteLine("空白数:{0}", spaces);
        }

        private static void Exercise2(string text) {
            Console.WriteLine(text.Replace("big", "small"));
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            var sb = new StringBuilder();
            //var i = 0;
            foreach (var item in array) {
                sb.Append(item + " ");
                //i = i + 1;
                //if (i < array.Length)
                //    sb.Append(' ');
                //else if (i == array.Length)
                //    sb.Append('.');
            }
            var ans = sb.ToString().TrimEnd();

            Console.WriteLine(ans + ".");

        }

        private static void Exercise4(string text) {
            var word = text.Split(' ');
            Console.WriteLine(word.Count());
        }

        private static void Exercise5(string text) {
            //var words = text.Split(' ').Where(s => s.Length <= 4);
            var word = text.Split(' ');
            foreach (var item in word.Where(s => s.Length <= 4)) {
                Console.WriteLine(item);
            }

        }

        private static void Exercise6(string text) {
            //var atoz = new int[26];
            //var smalltext = text.ToLower().Replace(" ", "");
            //foreach (var c in smalltext) {
            //    switch (c) {
            //        case 'a':
            //            atoz[0] += 1;
            //            break;
            //        case 'b':
            //            atoz[1] += 1;
            //            break;
            //        case 'c':
            //            atoz[2] += 1;
            //            break;
            //        case 'd':
            //            atoz[3] += 1;
            //            break;
            //        case 'e':
            //            atoz[4] += 1;
            //            break;
            //        case 'f':
            //            atoz[5] += 1;
            //            break;
            //        case 'g':
            //            atoz[6] += 1;
            //            break;
            //        case 'h':
            //            atoz[7] += 1;
            //            break;
            //        case 'i':
            //            atoz[8] += 1;
            //            break;
            //        case 'j':
            //            atoz[9] += 1;
            //            break;
            //        case 'k':
            //            atoz[10] += 1;
            //            break;
            //        case 'l':
            //            atoz[11] += 1;
            //            break;
            //        case 'm':
            //            atoz[12] += 1;
            //            break;
            //        case 'n':
            //            atoz[13] += 1;
            //            break;
            //        case 'o':
            //            atoz[14] += 1;
            //            break;
            //        case 'p':
            //            atoz[15] += 1;
            //            break;
            //        case 'q':
            //            atoz[16] += 1;
            //            break;
            //        case 'r':
            //            atoz[17] += 1;
            //            break;
            //        case 's':
            //            atoz[18] += 1;
            //            break;
            //        case 't':
            //            atoz[19] += 1;
            //            break;
            //        case 'u':
            //            atoz[20] += 1;
            //            break;
            //        case 'v':
            //            atoz[21] += 1;
            //            break;
            //        case 'w':
            //            atoz[22] += 1;
            //            break;
            //        case 'x':
            //            atoz[23] += 1;
            //            break;
            //        case 'y':
            //            atoz[24] += 1;
            //            break;
            //        case 'z':
            //            atoz[25] += 1;
            //            break;
            //        default:
            //            Console.WriteLine("エラー");
            //            break;
            //    }
            //}
            //char az = 'a';
            //for (int i = 0; i < 26; i++) {
            //    Console.WriteLine((az) + ":" + atoz[i]);
            //    az++;
            //}


            var atoz = new int[26];
            var smalltext = text.ToLower().Replace(" ", "");

            foreach (var c in smalltext) {
                if (c >= 'a' && c <= 'z')
                    atoz[c - 'a']++;
                else
                    Console.WriteLine("エラー");
            }

            for (int i = 0; i < 26; i++) {
                Console.WriteLine($"{(char)('a' + i)}: {atoz[i]}");
            }

            //辞書を使う
            //var smalltext = text.ToLower().Replace(" ", "");
            //var alphDicCount = Enumerable.Range('a', 26)
            //    .ToDictionary(n =>((char) n).ToString(),n => 0);
            //foreach (var alph in smalltext) {
            //    alphDicCount[alph.ToString()]++;
            //}
            //foreach (var item in alphDicCount) {
            //    Console.WriteLine($"{item.Key}:{item.Value}");

            //}

            //aから順にカウントして出力
            //for (char ch = 'a'; ch <= 'z'; ch++) {
            //    Console.WriteLine($"{ch}:{text.Count(tc => tc == ch)}");
            //}
        }
    }

}

