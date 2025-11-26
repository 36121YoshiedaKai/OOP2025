using System.Net.Http;
using System.Net.Http.Json;
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
using System.Windows.Threading;

namespace TenkiApp {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        private DispatcherTimer _timer;

        public MainWindow() {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);    // 1秒ごとに Tick
            _timer.Tick += Timer_Tick;
            _timer.Start();

            List<string> prefectures = new List<string>
            {
                "北海道(道南)","北海道(道央)","北海道(道北)","北海道(道東)",
                "青森県","岩手県","宮城県","秋田県","山形県","福島県",
                "茨城県","栃木県","群馬県","埼玉県","千葉県","東京都","神奈川県",
                "新潟県","富山県","石川県","福井県",
                "山梨県","長野県","岐阜県",
                "静岡県","愛知県",
                "三重県","滋賀県","京都府","大阪府","兵庫県","奈良県","和歌山県",
                "鳥取県","島根県","岡山県","広島県","山口県",
                "徳島県","香川県","愛媛県","高知県",
                "福岡県","佐賀県","長崎県","熊本県","大分県","宮崎県","鹿児島県","沖縄県"
            };

            // ComboBox にデータを設定
            PrefecturesList.ItemsSource = prefectures;

            // 任意で最初のアイテムを選択
            PrefecturesList.SelectedIndex = 12;
        }

        private void Timer_Tick(object? sender, EventArgs e) {
            // 現在時刻をフォーマットして表示
            nowtime.Text = "現在時刻：" + DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private async void PrefecturesList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (PrefecturesList.SelectedItem == null) return;

            string prefecture = PrefecturesList.SelectedItem.ToString();

            FetchWeeklyWeather(prefecture);

            if (!PrefectureLocations.ContainsKey(prefecture)) return;

            var (lat, lon) = PrefectureLocations[prefecture];

            string url =
                $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}" +
                "&current=temperature_2m,relative_humidity_2m,wind_speed_10m,weathercode" +
                "&hourly=temperature_2m,wind_speed_10m,weathercode" +
                "&timezone=Asia%2FTokyo";

            try {
                using var http = new HttpClient();
                var result = await http.GetFromJsonAsync<WeatherResponse>(url);

                if (result?.current != null) {

                    double temp = result.current.temperature_2m;
                    double wind = result.current.wind_speed_10m;
                    TempValue.Text = $"{result.current.temperature_2m} ℃";
                    HumidityValue.Text = $"{result.current.relative_humidity_2m} %";
                    WindSpeedValue.Text = $"{result.current.wind_speed_10m} m/s";
                    double feels = CalculateWindChill(temp, wind);
                    Sensibletemperature.Text = $"{Math.Round(feels, 1)} ℃";
                    SetWeatherIcon(result.current.weathercode);
                }

                if (result?.hourly != null) {
                    // 現在時刻を取得
                    DateTime currentTime = DateTime.Now;

                    // 7時間分のデータを格納するリスト
                    List<Hourly> hourlyData = new List<Hourly>();

                    // 現在時刻から7時間分のデータを取得
                    for (int i = 0; i < 7; i++) {
                        // 1時間後の時刻を計算
                        DateTime timeAtHour = currentTime.AddHours(i);
                        hourlyData.Add(new Hourly {
                            Time = timeAtHour.ToString("HH:mm"), // 時間をHH:mm形式で表示
                            Temperature = $"{result.hourly.temperature_2m[i]} ℃",
                            WindSpeed = $"{result.hourly.wind_speed_10m[i]} m/s"
                        });
                    }

                    // Grid に動的に追加する
                    HourlyWeatherGrid.Children.Clear();  // 既存のアイテムをクリア

                    // 行の定義
                    HourlyWeatherGrid.RowDefinitions.Clear();
                    for (int i = 0; i < 3; i++) {
                        HourlyWeatherGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto }); // 行の高さを自動に設定
                    }

                    // ヘッダーの時間、気温、風速を表示
                    var timeHeader = new TextBlock {
                        Text = "時間",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        Margin = new Thickness(5)
                    };
                    Grid.SetRow(timeHeader, 0);  // 1行目に配置
                    Grid.SetColumn(timeHeader, 0);  // 1列目
                    HourlyWeatherGrid.Children.Add(timeHeader);

                    var tempHeader = new TextBlock {
                        Text = "気温",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        Margin = new Thickness(5)
                    };
                    Grid.SetRow(tempHeader, 1);  // 2行目に配置
                    Grid.SetColumn(tempHeader, 0);  // 1列目
                    HourlyWeatherGrid.Children.Add(tempHeader);

                    var windHeader = new TextBlock {
                        Text = "風速",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        VerticalAlignment = VerticalAlignment.Center,
                        FontSize = 16,
                        Margin = new Thickness(5)
                    };
                    Grid.SetRow(windHeader, 2);  // 3行目に配置
                    Grid.SetColumn(windHeader, 0);  // 1列目
                    HourlyWeatherGrid.Children.Add(windHeader);

                    // 1時間ごとのデータを横に追加するために列を動的に作成
                    HourlyWeatherGrid.ColumnDefinitions.Clear();
                    for (int i = 0; i < hourlyData.Count; i++) {
                        // 1列ごとに新しい定義を追加
                        HourlyWeatherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    }

                    // 1時間ごとのデータを格納
                    for (int i = 0; i < hourlyData.Count; i++) {
                        // 時間、気温、風速を表示するための TextBlock を作成

                        // 1行目（時間）
                        var timeTextBlock = new TextBlock {
                            Text = hourlyData[i].Time,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 16,
                            Margin = new Thickness(20, 5, 10, 5)
                        };
                        Grid.SetRow(timeTextBlock, 0); // 1行目に配置
                        Grid.SetColumn(timeTextBlock, i + 1); // 横に並べるために列を動的に追加
                        HourlyWeatherGrid.Children.Add(timeTextBlock);

                        // 2行目（気温）
                        var tempTextBlock = new TextBlock {
                            Text = hourlyData[i].Temperature,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 16,
                            Margin = new Thickness(20, 5, 10, 5)
                        };
                        Grid.SetRow(tempTextBlock, 1); // 2行目に配置
                        Grid.SetColumn(tempTextBlock, i + 1); // 横に並べるために列を動的に追加
                        HourlyWeatherGrid.Children.Add(tempTextBlock);

                        // 3行目（風速）
                        var windTextBlock = new TextBlock {
                            Text = hourlyData[i].WindSpeed,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 16,
                            Margin = new Thickness(20, 5, 10, 5)
                        };
                        Grid.SetRow(windTextBlock, 2); // 3行目に配置
                        Grid.SetColumn(windTextBlock, i + 1); // 横に並べるために列を動的に追加
                        HourlyWeatherGrid.Children.Add(windTextBlock);
                    }

                    // 横に並べるための列定義を動的に追加
                    for (int i = 0; i < hourlyData.Count; i++) {
                        HourlyWeatherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    }
                }


            }
            catch (Exception ex) {
                MessageBox.Show("天気情報の取得に失敗しました：\n" + ex.Message);
            }
        }

        private readonly Dictionary<string, (double lat, double lon)> PrefectureLocations = new Dictionary<string, (double lat, double lon)>() {
            { "北海道(道南)", (41.7950, 140.7567) }, 
            { "北海道(道央)", (43.0642, 141.3469) },
            { "北海道(道北)", (44.3526, 142.4570) },
            { "北海道(道東)", (42.9848, 144.3816) },
            { "青森県", (40.8246, 140.7400) },
            { "岩手県", (39.7036, 141.1527) },
            { "宮城県", (38.2688, 140.8721) },
            { "秋田県", (39.7186, 140.1024) },
            { "山形県", (38.2404, 140.3633) },
            { "福島県", (37.7608, 140.4747) },
            { "茨城県", (36.3418, 140.4468) },
            { "栃木県", (36.5658, 139.8836) },
            { "群馬県", (36.3894, 139.0628) },
            { "埼玉県", (35.8617, 139.6454) },
            { "千葉県", (35.6047, 140.1233) },
            { "東京都", (35.6895, 139.6917) },
            { "神奈川県", (35.4478, 139.6425) },
            { "新潟県", (37.9026, 139.0230) },
            { "富山県", (36.6953, 137.2113) },
            { "石川県", (36.5944, 136.6256) },
            { "福井県", (36.0652, 136.2216) },
            { "山梨県", (35.6639, 138.5683) },
            { "長野県", (36.6513, 138.1810) },
            { "岐阜県", (35.3912, 136.7222) },
            { "静岡県", (34.9769, 138.3831) },
            { "愛知県", (35.1802, 136.9066) },
            { "三重県", (34.7303, 136.5086) },
            { "滋賀県", (35.0045, 135.8686) },
            { "京都府", (35.0116, 135.7681) },
            { "大阪府", (34.6937, 135.5023) },
            { "兵庫県", (34.6913, 135.1830) },
            { "奈良県", (34.6853, 135.8327) },
            { "和歌山県", (34.2260, 135.1675) },
            { "鳥取県", (35.5039, 134.2377) },
            { "島根県", (35.4723, 133.0505) },
            { "岡山県", (34.6551, 133.9195) },
            { "広島県", (34.3963, 132.4594) },
            { "山口県", (34.1858, 131.4705) },
            { "徳島県", (34.0658, 134.5593) },
            { "香川県", (34.3401, 134.0434) },
            { "愛媛県", (33.8416, 132.7661) },
            { "高知県", (33.5597, 133.5311) },
            { "福岡県", (33.5902, 130.4017) },
            { "佐賀県", (33.2634, 130.3009) },
            { "長崎県", (32.7448, 129.8737) },
            { "熊本県", (32.7898, 130.7417) },
            { "大分県", (33.2382, 131.6126) },
            { "宮崎県", (31.9111, 131.4239) },
            { "鹿児島県", (31.5602, 130.5581) },
            { "沖縄県", (26.2124, 127.6809) }
        };

        private double CalculateWindChill(double temp, double wind) {
            // 気温10℃以下・風速1.3m/s以上で有効
            if (temp <= 10 && wind >= 1.3) {
                return 13.12 + 0.6215 * temp
                    - 11.37 * Math.Pow(wind, 0.16)
                    + 0.3965 * temp * Math.Pow(wind, 0.16);
            }

            return temp; // それ以外は体感 = 気温
        }

        private void SetWeatherIcon(int code) {
            string iconPath = code switch {
                0 or 1 or 2 or 3 => "Images/Sun.png",    // 晴れ
                45 or 48 => "Images/Cloud.png",           // 曇り
                51 or 53 or 55 or 56 or 57 or 61 or 63 or 65 or 66 or 67 or 80 or 81 or 82 => "Images/Rain.png", // 雨
                71 or 73 or 75 or 77 or 85 or 86 => "Images/Snow.png", // 雪
                95 or 96 or 99 => "Images/Thunder.png",    // 雷
                _ => "Images/Sun.png"                    // デフォルト
            };

            string weatherDescription = code switch {
                0 or 1 or 2 or 3 => "晴れ",    // 晴れ
                45 or 48 => "曇り",          // 曇り
                51 or 53 or 55 or 56 or 57 or 61 or 63 or 65 or 66 or 67 or 80 or 81 or 82 => "雨", // 雨
                71 or 73 or 75 or 77 or 85 or 86 => "雪", // 雪
                95 or 96 or 99 => "雷",      // 雷
                _ => "不明"                   // デフォルト
            };

            // Wname に天気状態をセット
            Wname.Text = weatherDescription;

            WeatherIcon.Source = new BitmapImage(new Uri(iconPath, UriKind.Relative));
        }

        private async void FetchWeeklyWeather(string prefecture) {
            if (!PrefectureLocations.ContainsKey(prefecture)) return;

            var (lat, lon) = PrefectureLocations[prefecture];

            string url = $"https://api.open-meteo.com/v1/forecast?latitude={lat}&longitude={lon}&daily=temperature_2m_max,temperature_2m_min,wind_speed_10m_max&timezone=Asia%2FTokyo";

            try {
                using var http = new HttpClient();
                var result = await http.GetFromJsonAsync<WeatherResponse>(url);

                if (result?.daily != null) {
                    // 今日の曜日を取得（例: 水曜日）
                    DateTime currentDate = DateTime.Now;
                    DayOfWeek currentDayOfWeek = currentDate.DayOfWeek;

                    // 曜日をリストとして保持 (日曜日=0, 土曜日=6)
                    List<string> daysOfWeek = new List<string> { "日曜日", "月曜日", "火曜日", "水曜日", "木曜日", "金曜日", "土曜日" };

                    // 今日から数えて1週間分のデータを取得
                    List<string> weeklyDays = new List<string>();

                    // 今日から1週間分の曜日を取得 (今日の次の日から表示)
                    for (int i = 1; i <= 7; i++) {
                        int dayIndex = (int)(currentDayOfWeek + i) % 7; // 今日の次の日から数えて1週間
                        weeklyDays.Add(daysOfWeek[dayIndex]);
                    }

                    WeeklyWeatherGrid.Children.Clear();  // UIをクリア

                    // 行定義の追加
                    for (int i = 0; i < 4; i++) {
                        WeeklyWeatherGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    }

                    // 曜日列 (TextBlockを動的に追加)
                    for (int i = 0; i < 7; i++) {
                        var dayTextBlock = new TextBlock {
                            Text = weeklyDays[i],
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 15, // フォントサイズを調整
                            Margin = new Thickness(5)
                        };
                        Grid.SetRow(dayTextBlock, 0);  // 1行目（曜日）に配置
                        Grid.SetColumn(dayTextBlock, i); // 横に並べる
                        WeeklyWeatherGrid.Children.Add(dayTextBlock);
                    }

                    // 列の定義を1回だけ動的に追加
                    WeeklyWeatherGrid.ColumnDefinitions.Clear();
                    for (int i = 0; i < 7; i++) {
                        WeeklyWeatherGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    }

                    // 気温列 (TextBlockを動的に追加)
                    for (int i = 0; i < 7; i++) {
                        var maxTemp = result.daily.temperature_2m_max[i];
                        var minTemp = result.daily.temperature_2m_min[i];
                        var tempTextBlock = new TextBlock {
                            Text = $"{maxTemp}°C / {minTemp}°C",
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 15,  // フォントサイズを調整
                            Margin = new Thickness(5)
                        };
                        Grid.SetRow(tempTextBlock, 1);  // 2行目（気温）に配置
                        Grid.SetColumn(tempTextBlock, i); // 横に並べる
                        WeeklyWeatherGrid.Children.Add(tempTextBlock);
                    }

                    // 風速列 (TextBlockを動的に追加)
                    for (int i = 0; i < 7; i++) {
                        var maxWindSpeed = result.daily.wind_speed_10m_max[i]; // 最大風速
                        var windSpeedTextBlock = new TextBlock {
                            Text = $"{maxWindSpeed} m/s",
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 15,  // フォントサイズを調整
                            Margin = new Thickness(5)
                        };
                        Grid.SetRow(windSpeedTextBlock, 2);  // 3行目（風速）に配置
                        Grid.SetColumn(windSpeedTextBlock, i); // 横に並べる
                        WeeklyWeatherGrid.Children.Add(windSpeedTextBlock);
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("天気情報の取得に失敗しました：" + ex.Message);
            }
        }


    }
}