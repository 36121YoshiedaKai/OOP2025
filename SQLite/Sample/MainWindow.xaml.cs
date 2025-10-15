using Sample.Data;
using SQLite;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
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

namespace Sample;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
    private ObservableCollection<Person> _persons = new ObservableCollection<Person>();

    public MainWindow() {
        InitializeComponent();
        //ReadDatabese();
        _persons.Add(new Person { Id = 1, Name = "藤本ヒロユキ", Phone = "144" });
        PersonListView.ItemsSource = _persons;

    }

    private void ReadDatabese() {
        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            //_persons = connection.Table<Person>().ToList();
        }
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e) {

        var person = new Person() {
            Name = NameTextBox.Text,
            Phone = PhoneTextBox.Text,
        };



        using (var connection = new SQLiteConnection(App.databasePath)) {
            connection.CreateTable<Person>();
            connection.Insert(person);
        }

    }

    private void ReadButton_Click(object sender, RoutedEventArgs e) {

        _persons.Add(new Person { Id = 2, Name = "須永リクと", Phone = "55" });

        //ReadDatabese();
    }
}