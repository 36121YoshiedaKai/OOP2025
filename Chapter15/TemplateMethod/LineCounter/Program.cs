using TextFileProcessor;

namespace LineCounter {
    internal class Program {
        static void Main(string[] args) {

            
            Console.Write("指定しいファイルを入力してください:");
            string path = Console.ReadLine();

            // @"C:\Users\infosys\source\repos\OOP2025\WPF\ConverterApp\MainWindow.xaml.cs";
            if (!string.IsNullOrWhiteSpace(path)) {
                
            }else {
                path = @"%SystemRoot%\\System32";
            }
                TextProcessor.Run<LineCounterProcessor>(path);
        }
    }
}
