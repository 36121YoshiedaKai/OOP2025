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

        using (var sr = new StreamReader(filePath, Encoding.UTF8)) {
            var fileContent = System.IO.File.ReadLinesAsync(filePath);
            await foreach (var item in fileContent) {
                filetext.Text += item + Environment.NewLine;
            }
        }

    }
}