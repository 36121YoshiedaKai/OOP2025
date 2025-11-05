using Microsoft.Win32;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise01_WPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    public MainWindow() {
        InitializeComponent();
    }

    private async void filebutton_Click(object sender, RoutedEventArgs e) {

        var filePath = "走れメロス.txt";

        StringBuilder sb = new StringBuilder();
        using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
           
            while (!sr.EndOfStream) {
                string? line = await sr.ReadLineAsync();
                sb.AppendLine(line);
                await Task.Delay(10);
            }
        }
        filetext.Text = sb.ToString();

    }
}