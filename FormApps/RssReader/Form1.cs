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
            try {
                using (var hc = new HttpClient()) {
                    string xml = await hc.GetStringAsync(cbUrl.Text);
                    XDocument xdoc = XDocument.Parse(xml);

                    //var url = hc.OpenRead(cbUrl.Text);
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
            catch (Exception) {

                throw;
            }




        }

        private void lbTitles_Click(object sender, EventArgs e) {
            if (lbTitles is not null && lbTitles.SelectedItem != null) {
                wvRssLink.Source = new Uri(items[lbTitles.SelectedIndex].Link);
                btBack.Enabled = true;
            }
            //foreach (var item in items) {
            //    if (item.Title == lbTitles.SelectedItem) {
            //        wvRssLink.Source = new Uri(item.Link ?? "https://yahoo.co.jp");
            //    }
            //}

            //wvRssLink.Source = new Uri("https://yahoo.co.jp");
        }

        private void btBack_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoBack) {
                wvRssLink.GoBack();
            }
        }

        private void btGo_Click(object sender, EventArgs e) {
            if (wvRssLink.CanGoForward) {
                wvRssLink.GoForward();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            setCbUrl("https://news.yahoo.co.jp/rss/topics/top-picks.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/domestic.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/world.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/business.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/entertainment.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/sports.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/it.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/science.xml");
            setCbUrl("https://news.yahoo.co.jp/rss/topics/local.xml");

            GoBtset();
        }

        private void wvRssLink_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e) {
            GoBtset();
        }

        private void GoBtset() {
            btBack.Enabled = wvRssLink.CanGoBack;
            btGo.Enabled = wvRssLink.CanGoForward;
        }

        private void setCbUrl(string author) {
            //登録済みか確認
            if (!cbUrl.Items.Contains(author))
                //未登録なら登録
                cbUrl.Items.Add(author);

        }

    }
}
