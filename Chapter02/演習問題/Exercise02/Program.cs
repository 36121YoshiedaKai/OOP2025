namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("はじめ");

            //コンソール入力
            Console.WriteLine("１：インチからメートル");
            Console.WriteLine("２：メートルからインチ");
            Console.Write("＞");
            int oneortwo = int.Parse(Console.ReadLine());
            Console.Write("はじめ：");
            int start = int.Parse(Console.ReadLine());
            Console.Write("おわり：");
            int end = int.Parse(Console.ReadLine());

            if (oneortwo == 1) {
                PrintInchToMeter(start, end);
            }else if(oneortwo == 2) {
                PrintMeterToInch(start, end);
            } else {
                Console.WriteLine("エラー");
            }

        }

        //インチからメートル
        static void PrintInchToMeter(int strat, int end) {
            for (int Inch = strat; Inch <= end; Inch++) {
                double meter = InchConverter.ToInch(Inch);
                Console.WriteLine($"{Inch}in = {meter:0.0000}m");
            }
        }

        //メートルからインチ
        static void PrintMeterToInch(int strat, int end) {
            for (int meter = strat; meter <= end; meter++) {
                double Inch = InchConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {Inch:0.0000}in");
            }
        }
    }
}
