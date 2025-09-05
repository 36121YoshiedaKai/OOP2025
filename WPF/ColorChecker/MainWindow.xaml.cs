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

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        //すべてのスライダーから呼ばれるハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            colorArea.Background = new SolidColorBrush(Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value));
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            var getbc = colorArea.Background as SolidColorBrush;
            bool yescolor = false;
            if (getbc is null) {
                return;
            }


            var mycolor = new MyColor {
                Color = getbc.Color
            };
            foreach (var item in stocList.Items) {
                if (item is MyColor existingMyColor) {
                    if (existingMyColor.Color.Equals(mycolor.Color)) {
                        yescolor = true;
                        break;
                    }
                } 
            }
            if (!yescolor) {
                stocList.Items.Add(mycolor);
            }
        }
    }
}
