using System.IO;
using System.Numerics;

namespace DistanceConverter {
    internal class Program {
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

        static double FeetToMeter(int feet) {
            return feet * 0.3048;
        }

        static double MeterToFeet(int meter) {
            return meter / 0.3048;
        }

        static void PrintFrrtToMeterList(int strat, int end) {
            //フィートからメートル
            for (int feet = strat; feet <= end; feet++) {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");
            }
        }

        static void PrintMeterToFeet(int strat, int end) {
            //メートルからフィート
            for (int meter = strat; meter <= end; meter++) {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }
    }
}
