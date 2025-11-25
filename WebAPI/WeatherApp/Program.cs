using System.Net.Http.Json;

namespace WeatherApp {
    internal class Program {
        // 例：東京（緯度 35.0, 経度 139.0）の現在の気温などを取得
        private const string Url =
            "https://api.open-meteo.com/v1/forecast?latitude=36.3894&longitude=139.0628&current=temperature_2m,wind_speed_10m,relative_humidity_2m";

        static async Task Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=== Open-Meteo API サンプル ===");

            using var http = new HttpClient();

            try {
                // JSON デシリアライズ
                var weather = await http.GetFromJsonAsync<WeatherResponse>(Url);

                if (weather?.current != null) {
                    Console.WriteLine($"取得時刻：{weather.current.time}");
                    Console.WriteLine($"気温：{weather.current.temperature_2m} ℃");
                    Console.WriteLine($"風速：{weather.current.wind_speed_10m} m/s");
                    Console.WriteLine($"湿度：{weather.current.relative_humidity_2m} %");
                } else {
                    Console.WriteLine("データが取得できませんした。");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"エラー：{ex.Message}");
            }
        }

        private double CalculateWindChill(double temp, double wind) {
            // 気温10℃以下・風速1.3m/s以上で有効
            if (temp <= 10 && wind >= 1.3) {
                return 13.12 + 0.6215 * temp
                    - 11.37 * Math.Pow(wind, 0.16)
                    + 0.3965 * temp * Math.Pow(wind, 0.16);
            }

            return temp; // それ以外は体感 = 気温
        }

    }
}
