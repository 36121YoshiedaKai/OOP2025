namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {

            InchToMeter();

        }

        //インチからメートル
        static void InchToMeter() {
            for (int Inch = 1; Inch <= 10; Inch++) {
                double meter = InchConverter.ToInch(Inch);
                Console.WriteLine($"{Inch}in = {meter:0.0000}m");
            }
        }
    }
}
