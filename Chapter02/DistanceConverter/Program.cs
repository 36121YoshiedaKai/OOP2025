using System.IO;
using System.Numerics;

namespace DistanceConverter {
    internal class Program {
        //コマンドライン引数
        static void Main(string[] args) {

            //string → int (int.Parse())
            int strat = int.Parse(args[1]);
            int end = int.Parse(args[2]);


            if (args.Length >= 1 && args[0] == "-tom") {

                PrintFrrtToMeterList(strat, end);

            } else if (args.Length >= 1 && args[0] == "-tof") {

                PrintMeterToFeet(strat, end);

            }

        }


        //フィートからメートル
        static void PrintFrrtToMeterList(int strat, int end) {
            //FeetConverter fc = new FeetConverter();
            for (int feet = strat; feet <= end; feet++) {
                double meter = FeetConverter.ToFeet(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }

        //メートルからフィート
        static void PrintMeterToFeet(int strat, int end) {
            //FeetConverter fc = new FeetConverter();
            for (int meter = strat; meter <= end; meter++) {
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

    }
}
