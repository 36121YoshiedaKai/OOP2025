using Microsoft.Win32;
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
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() ?? false) {
            var filePath = openFileDialog.FileName;

            try {
                var fileContent = System.IO.File.ReadLinesAsync(filePath);
                await foreach (var item in fileContent) {
                    filetext.Text += item + Environment.NewLine;
                }
            }
            catch{
            }
        }
    }
}