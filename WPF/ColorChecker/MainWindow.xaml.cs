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

        MyColor currentColor;


        public MainWindow() {
            InitializeComponent();
            colorSelectComboBox.DataContext = GetColorList();
        }

        //すべてのスライダーから呼ばれるハンドラ
        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {

            var color = Color.FromRgb((byte)rSlider.Value, (byte)gSlider.Value, (byte)bSlider.Value);
            colorArea.Background = new SolidColorBrush(color);
            UpdateColorCode(color);

            bool flg1 = false;
 
            foreach (var item in colorSelectComboBox.Items) {
                if (item is MyColor myColor && myColor.Color.Equals(color)) {
                    colorSelectComboBox.SelectedItem = myColor;
                    flg1 = true;
                    break;
                } 
            }
            if (!flg1) {
                colorSelectComboBox.SelectedIndex = -1;
            }
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {

            var getbc = colorArea.Background as SolidColorBrush;
            bool yescolor = false;
            if (getbc is null) {
                return;
            }



            currentColor = new MyColor {
                Color = getbc.Color,
                Name = GetColorNameFromColor(getbc.Color)
            };
            foreach (var item in stocList.Items) {
                if (item is MyColor existingMyColor) {
                    if (existingMyColor.Color.Equals(currentColor.Color)) {
                        yescolor = true;
                        break;
                    }
                }
            }
            if (!yescolor) {
                stocList.Items.Add(currentColor);
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

                setSliberval(color);
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
                setSliberval(selectColor.Color);
                
            }
        }

        private void setSliberval(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;

        }

        private void UpdateColorCode(Color color) {
            colorcodetext.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }

        private void colorcodetext_KeyDown(object sender, KeyEventArgs e) {
            if (e.Key == Key.Enter) {


                try {
                    string text = colorcodetext.Text.TrimStart('#');
                    if (text.Length == 6) {
                        if (text.ToLower() == "rrggbb") {
                            MessageBox.Show("そういうことじゃないです");
                            return;
                        }
                        byte r = Convert.ToByte(text.Substring(0, 2), 16);
                        byte g = Convert.ToByte(text.Substring(2, 2), 16);
                        byte b = Convert.ToByte(text.Substring(4, 2), 16);
                        setSliberval(Color.FromRgb(r, g, b));
                        colorArea.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
                    } else {
                        MessageBox.Show("#以外に1～Fまでを6字入力してください");
                    }
                }
                catch {
                    MessageBox.Show("#RRGGBB形式で入力してください");
                }
            }
        }
    }
}
