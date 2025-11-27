using CustomerApp.Data;
using Microsoft.Win32;
using SQLite;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomerApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private List<Customer> _customer = new List<Customer>();

    public MainWindow() {
        InitializeComponent();
        ReadDatabese();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {



        var customer = new Customer() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
            Address = AddressTextBox.Text,
            Picture = ImageToByteArray(image: (BitmapImage)PictureBox.Source),
        };

        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Insert(customer);
        }

        ReadDatabese();

    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;
        if (item is null) {
            return;
        }
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            var customer = new Customer() {
                Id = item.Id,
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
                Address = AddressTextBox.Text,
                Picture = ImageToByteArray(image: (BitmapImage)PictureBox.Source),
            };
            connection.Update(customer);
            ReadDatabese();

        }
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;
        if (item == null) {
            MessageBox.Show("行を選択してください");
            return;
        }
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Customer>();
            connection.Delete(item);        //データベースから選択されているレコードの削除
            ReadDatabese();


        }
    }

    private void ReadDatabese() {
        using (var item = new SQLiteConnection(App.databasePath)) {
            item.CreateTable<Customer>();
            _customer = item.Table<Customer>().ToList();
        }
        CustomerListView.ItemsSource = _customer;
    }

    private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e) {
        var filterList = _customer.Where(p => p.Name.Contains(SearchTextBox.Text));

        CustomerListView.ItemsSource = filterList;
    }

    private void CustomerListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
        var item = CustomerListView.SelectedItem as Customer;
        if (item is null) {
            return;
        }
        NameTextBox.Text = item.Name;
        PhoneTextBox.Text = item.Phone;
        AddressTextBox.Text = item.Address;
        if (item.Picture != null && item.Picture.Length > 0) {
            using (MemoryStream stream = new MemoryStream(item.Picture)) {
                BitmapImage bit = new BitmapImage();
                bit.BeginInit();
                bit.StreamSource = stream;
                bit.CacheOption = BitmapCacheOption.OnLoad;
                bit.EndInit();
                PictureBox.Source = bit;
            }
        } else {
            PictureBox.Source = null;
        }
    }

    private void PictureButton_Click(object sender, RoutedEventArgs e) {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
        if (openFileDialog.ShowDialog() ?? false) {
            string file = openFileDialog.FileName;

            BitmapImage bit = new BitmapImage();
            using (FileStream strean = File.OpenRead(file)) {
                bit.BeginInit();
                bit.CacheOption = BitmapCacheOption.OnLoad;
                bit.StreamSource = strean;
                bit.EndInit();
            }
            PictureBox.Source = bit;
        } else {
            PictureBox.Source = null;
        }
    }

    private byte[]? ImageToByteArray(BitmapImage image) {
        if (image is null) {
            return null;
        }
        using (MemoryStream stream = new MemoryStream()) {
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            encoder.Save(stream);
            return stream.ToArray();
        }
    }

    private void ClearButton_Click(object sender, RoutedEventArgs e) {
        PictureBox.Source = null;
    }

    private async void PostCodeSearchButton_Click(object sender, RoutedEventArgs e) {
        string postCode = PostCodeTextBox.Text.Replace("-", "").Trim();

        if (string.IsNullOrEmpty(postCode) || postCode.Length != 7) {
            MessageBox.Show("正しい郵便番号を入力してください");
            return;
        }

        try {
            // JP Postal Code APIにリクエストを送る
            string url = $"https://jp-postal-code-api.ttskch.com/api/v1/{postCode}.json";
            Console.WriteLine("リクエストURL: " + url);  // URLを表示して確認

            using (HttpClient client = new HttpClient()) {
                var response = await client.GetStringAsync(url);
                Console.WriteLine("APIレスポンス: " + response);  // レスポンス内容を表示

                var json = JsonSerializer.Deserialize<PostalCodeResponse>(response);
                if (json != null && json.addresses != null && json.addresses.Count > 0) {
                    var address = json.addresses[0];  // 最初の住所情報を取得
                    string fullAddress = $"{address.ja.prefecture}{address.ja.address1}{address.ja.address2}";

                    // 住所が見つかればTextBoxに設定
                    AddressTextBox.Text = fullAddress;
                } else {
                    MessageBox.Show("住所が見つかりませんでした");
                }
            }
        }
        catch (Exception ex) {
            MessageBox.Show("エラーが発生しました: " + ex.Message);
        }
    }


}

public class PostalCodeResponse {
    public string postalCode { get; set; }
    public List<Address> addresses { get; set; }
}

public class Address {
    public string prefectureCode { get; set; }
    public AddressDetails ja { get; set; }
    public AddressDetails kana { get; set; }
    public AddressDetails en { get; set; }
}

public class AddressDetails {
    public string prefecture { get; set; }
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string address3 { get; set; }
    public string address4 { get; set; }
}


