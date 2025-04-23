using System.Diagnostics.Metrics;
using System.Threading;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {


            //コンソール入力
            /* Console.WriteLine("１：インチからメートル");
             Console.WriteLine("２：メートルからインチ");*/
            Console.WriteLine("１：ヤードからメートル");
            Console.WriteLine("２：メートルからヤード");
            Console.Write("＞");
            int oneortwo = int.Parse(Console.ReadLine());

            Console.Write("変換する数字：");
            int convertno = int.Parse(Console.ReadLine());

            /*Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());

            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());

            if (oneortwo == 1) {
                PrintInchToMeter(start, end);
            } else if (oneortwo == 2) {
                PrintMeterToInch(start, end);
            } else {
                Console.WriteLine("エラー");
            }*/

            if (oneortwo == 1) {
                PrintYardToMeter(convertno);
            } else if (oneortwo == 2) {
                PrintMeterToYard(convertno);
            } else {
                Console.WriteLine("エラー");
            }

        }

        //インチからメートル
        static void PrintInchToMeter(int strat, int end) {
            for (int Inch = strat; Inch <= end; Inch++) {
                double meter = InchConverter.ToInch(Inch);
                Console.WriteLine($"{Inch}inch = {meter:0.0000}m");
            }
        }

        //メートルからインチ
        static void PrintMeterToInch(int strat, int end) {
            for (int meter = strat; meter <= end; meter++) {
                double Inch = InchConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {Inch:0.0000}inch");
            }
        }


        //ヤードからメートル
        static void PrintYardToMeter(int Yard) {
            /* for (int Yard = strat; Yard <= end; Yard++) {
                 double meter = YardConverter.ToYard(Yard);
                 Console.WriteLine($"{Yard}yard = {meter:0.0000}m");
             }*/
            double meter = YardConverter.ToYard(Yard);
            Console.WriteLine($"変更前（ヤード）：{Yard}yard ");
            Console.WriteLine($"変更後（メートル）：{ meter: 0.0000}m");

        }

        //メートルからヤード
        static void PrintMeterToYard(int meter) {
            /*for (int meter = strat; meter <= end; meter++) {
                double Yard = YardConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {Yard:0.0000}yard");
            }*/
            double Yard = YardConverter.FromMeter(meter);
            Console.WriteLine($"変更前（メートル）：{meter}m ");
            Console.WriteLine($"変更後（ヤード）：{Yard: 0.0000}yard");
        }
    }
}
