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
using System.Reflection;

namespace ColorChecker {
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window {

        MyColor currentCorlor;
        
 
        public MainWindow() {
            InitializeComponent();
            colorSelectComboBox.DataContext = GetColorList();
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



            currentCorlor = new MyColor {
                Color = getbc.Color,
                Name = GetColorNameFromColor(getbc.Color)
            };
            foreach (var item in stocList.Items) {
                if (item is MyColor existingMyColor) {
                    if (existingMyColor.Color.Equals(currentCorlor.Color)) {
                        yescolor = true;
                        break;
                    }
                }
            }
            if (!yescolor) {
                stocList.Items.Add(currentCorlor);
            } else {
                MessageBox.Show("その色は登録済みです。");
            }
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
               .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (((ComboBox)sender).SelectedItem is MyColor mycolor) {
                var color = mycolor.Color;

                rSlider.Value = color.R;
                gSlider.Value = color.G;
                bSlider.Value = color.B;
            }
        }
        private string GetColorNameFromColor(Color color) {
            var colors = GetColorList();
            foreach (var c in colors) {
                if (c.Color.Equals(color)) {
                    if (!string.IsNullOrEmpty(c.Name)) {
                        return c.Name;
                    }
                }
            }
            return $"R:{color.R},G:{color.G},B:{color.B}";
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e) {
            if (stocList.SelectedItem is MyColor selectedColor) {
                stocList.Items.Remove(selectedColor);
            } else {
                MessageBox.Show("色が選択されていません。");
            }
        }

        private void stocList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stocList.SelectedItem is MyColor selectColor) {
                rSlider.Value = selectColor.Color.R;
                gSlider.Value = selectColor.Color.G;
                bSlider.Value = selectColor.Color.B;
            }
        }
    }
}
