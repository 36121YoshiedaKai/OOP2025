namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("並列なし");

            Parallel.For(0, 100, i => {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep(100);
                Console.WriteLine($"処理{i}終了");
            });

            Console.WriteLine("並列あり");

            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"処理{i}開始");
                Thread.Sleep(100);
                Console.WriteLine($"処理{i}終了");
            }
        }
    }
}
