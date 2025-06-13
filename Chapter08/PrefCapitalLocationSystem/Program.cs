namespace PrefCapitalLocationSystem {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();

        static void Main(string[] args) {
            String? pref, prefCaptalLocation;
            var i = 10;

            //入力処理
            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");
            
            while (true) {
                if (i < 1) Environment.Exit(0);
                //①都道府県の入力
                Console.Write("都道府県:");

                pref = Console.ReadLine();

                if (pref == null) break;    //無限ループを抜ける(Ctrl + 'Z')

                //県庁所在地の入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();
                if (prefCaptalLocation == null) break;


                //既に都道府県が登録されているか？
                //ヒント：ContainsKeyを使用して調べる
                if (prefOfficeDict.ContainsKey(pref)) {
                    //登録済みなら確認して上書き処理、上書きしない場合はもう一度都道府県の入力…①へ
                    Console.WriteLine("上書きしますか？(Y/N)");
                    var yorn = Console.ReadLine();
                    if (yorn == null) break;
                    if (yorn.Equals("n", StringComparison.CurrentCultureIgnoreCase)) {
                        Console.WriteLine();
                        i = 10;
                        continue;
                    } else if(yorn.Equals("y", StringComparison.CurrentCultureIgnoreCase)) {
                        prefOfficeDict[pref] = prefCaptalLocation;
                        i = 10;
                    } else {
                        Console.WriteLine("YまたはNで答えてください。");
                        i--;
                        Console.WriteLine("あと" + i + "回間違えるとプログラムを終了します");
                        continue;
                    }
                } else {
                    prefOfficeDict.Add(pref, prefCaptalLocation);
                }


                Console.WriteLine();//改行
            }

            Boolean endFlag = false;    //終了フラグ（無限ループを抜け出す用）
            
            while (!endFlag) {
                switch (menuDisp()) {
                    case "1":                        //一覧出力処理
                        allDisp();
                        break;


                    case "2"://検索処理
                        searchPrefCaptalLocation();
                        break;


                    case "9"://無限ループを抜ける
                        endFlag = true;
                        break;
                }
            }
        }

        //メニュー表示
        private static string? menuDisp() {
            Console.WriteLine("\n**** メニュー ****");
            Console.WriteLine("1：一覧表示");
            Console.WriteLine("2：検索");
            Console.WriteLine("9：終了");
            Console.Write(">");
            var menuSelect = Console.ReadLine();
            return menuSelect;
        }


        //一覧表示処理
        private static void allDisp() {

            //*　ここに入力　*******************//
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"都道府県:{item.Key} 県庁所在地:{item.Value}");
            }
        }

        //検索処理
        private static void searchPrefCaptalLocation() {
            Console.Write("都道府県:");
            String? searchPref = Console.ReadLine();
            
            if (searchPref is null) {
                Console.WriteLine("入力されていません");
                return;
            }

            if (prefOfficeDict.ContainsKey(searchPref))
                Console.WriteLine($"{searchPref} の県庁所在地は{prefOfficeDict[searchPref]}です");
            else
                Console.WriteLine("登録されていません");
        }
    }
}
