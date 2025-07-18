using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;
        

        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            using (var hc = new HttpClient()) {

                string xml = await hc.GetStringAsync(tbUrl.Text);
                XDocument xdoc = XDocument.Parse(xml);

                //var url = hc.OpenRead(tbUrl.Text);
                //XDocument xdoc = XDocument.Load(url);   //RSSの取得

                //RSSを解析して必要な要素を取得
                items = xdoc.Root.Descendants("item")
                    .Select(x => new ItemData {
                        Title = (string?)x.Element("title"),
                        Link = (string?)x.Element("link"),
                    }).ToList();


                //リストボックスへタイトル表示
                lbTitles.Items.Clear();
                //foreach (var item in items) {
                //    lbTitles.Items.Add(item.Title);
                //}
                items.ForEach(item => lbTitles.Items.Add(item.Title));

            }



        }

        private void lbTitles_Click(object sender, EventArgs e) {
            webView21.Source = new Uri(items[lbTitles.SelectedIndex].Link);
            //foreach (var item in items) {
            //    if (item.Title == lbTitles.SelectedItem) {
            //        webView21.Source = new Uri(item.Link ?? "https://yahoo.co.jp");
            //    }
            //}

            //webView21.Source = new Uri("https://yahoo.co.jp");
        }

        private void btBack_Click(object sender, EventArgs e) {
            if (webView21.CanGoBack) {
                webView21.GoBack();
            }
        }

        private void btGo_Click(object sender, EventArgs e) {
            if (webView21.CanGoForward) {
                webView21.GoForward();
            }
        }
    }
}
