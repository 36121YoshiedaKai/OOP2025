using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ConverterApp {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void ImperialUnitToMetric_Click(object sender, RoutedEventArgs e) {
            if (string.IsNullOrWhiteSpace(ImperialValue.Text) || ImperialUnit.SelectedItem == null || MetricUnit.SelectedItem == null) {
                MessageBox.Show("数値が入力されていないか単位が選択せれていません");
                return;
            }

            double value = double.Parse(ImperialValue.Text);
            string fromUnit = ((ComboBoxItem)ImperialUnit.SelectedItem).Content.ToString();
            string toUnit = ((ComboBoxItem)MetricUnit.SelectedItem).Content.ToString();
            double result = LengthUnitConverter.Convert(value, fromUnit, toUnit);
            MetricValue.Text = result.ToString();
        }

        private void MetricToImperialUnit_Click(object sender, RoutedEventArgs e) {

            if (string.IsNullOrWhiteSpace(MetricValue.Text) || ImperialUnit.SelectedItem == null || MetricUnit.SelectedItem == null) {
                MessageBox.Show("数値が入力されていないか単位が選択せれていません");
                return;
            }
            double value = double.Parse(MetricValue.Text);
            string fromUnit = ((ComboBoxItem)MetricUnit.SelectedItem).Content.ToString();
            string toUnit = ((ComboBoxItem)ImperialUnit.SelectedItem).Content.ToString();
            double result = LengthUnitConverter.Convert(value, fromUnit, toUnit);
            ImperialValue.Text = result.ToString();
        }
    }
}

public static class LengthUnitConverter {
    private static readonly Dictionary<string, double> UnitToMeters = new Dictionary<string, double>{
        { "mm", 0.001 },
        { "cm", 0.01 },
        { "m", 1 },
        { "hm", 100 },
        { "km", 1000 }
    };


    public static double Convert(double value, string fromUnit, string toUnit) {
        if (UnitToMeters.ContainsKey(fromUnit) && UnitToMeters.ContainsKey(toUnit)) {
            double valueInMeters = value * UnitToMeters[fromUnit];
            return valueInMeters / UnitToMeters[toUnit];
        }
        throw new ArgumentException("Invalid units.");
    }
}

