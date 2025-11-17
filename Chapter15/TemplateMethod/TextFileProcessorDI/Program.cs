namespace TextFileProcessorDI {
    internal class Program {
        static void Main(string[] args) {
            //var servise = new LineCounterService();
            //var prcessor = new TextFileProcessor(servise);
            var servise = new LineOutputService();
            var prcessor = new TextFileProcessor(servise);
            Console.Write("ぱすの入力");
            prcessor.Run(Console.ReadLine().Replace("\"", ""));
        }
    }
}
