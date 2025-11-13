using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {

            
            Console.Write("指定しいファイルを入力してください:");
            string path = Console.ReadLine();

            // @"C:\Users\infosys\source\repos\OOP2025\WPF\ConverterApp\MainWindow.xaml.cs";
            if (!string.IsNullOrWhiteSpace(path)) {
               path = path.Replace("\"", "");
            }else {
                path = @"";
            }
                TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
