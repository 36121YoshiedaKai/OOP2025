using System.Net;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RssReader {
    public partial class Form1 : Form {

        private List<ItemData> items;

        Dictionary<string, string> rssUrlDict = new Dictionary<string, string>(){
            { "主要", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "国内", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "国際", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "経済", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "エンタメ", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "スポーツ", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "科学", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "地域", "https://news.yahoo.co.jp/rss/topics/local.xml" },
        };



        public Form1() {
            InitializeComponent();
        }

        private async void btRssGet_Click(object sender, EventArgs e) {
            //foreach (var item in rssUrlDict) {
            //    if (cbUrl.Text == item.Key) {
            //        cbUrl.Text = item.Value;
            //    }
            //}
            if (string.IsNullOrEmpty(cbUrl.Text)) {
                MessageBox.Show("何も入力されていません");
                return;
            }
            if (!Uri.IsWellFormedUriString(cbUrl.Text, UriKind.Absolute) || !cbUrl.Text.EndsWith(".xml")) {
                MessageBox.Show("URLが違います");
                return;
            }

            try {
                using (var hc = new HttpClient()) {
                    string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
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

            //foreach (var item in rssUrlDict) {
            //    if (item.Value == cbUrl.Text) {
            //        cbUrl.Text = item.Key;
            //    }
            //}

        }
        //コンボボックスから文字列をチェックしてアクセス可能なURLを返却する
        private string getRssUrl(string str) {
            if (rssUrlDict.ContainsKey(str)) {
                return rssUrlDict[str];
            }
            return str;
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
            wvRssLink.Source = new Uri("https://yahoo.co.jp");
            foreach (var item in rssUrlDict) {
                setCbUrl(item.Key);
            }

            //if (File.Exists("rssUrlDict.xml")) {
            //    try {
            //        using (var reader = XmlReader.Create("rssUrlDict.xml")) {
            //            var serializer = new XmlSerializer(typeof(Dictionary<string, string>));
            //            var set = serializer.Deserialize(reader) as Dictionary<string, string>;
            //            if (set is null) {
            //                return;
            //            }
            //            foreach (var item in set) {
            //                if (!rssUrlDict.ContainsKey(item.Key)) {
            //                    rssUrlDict.Add(item.Key, item.Value);
            //                }
            //            }

            //        }
            //    }
            //    catch (Exception ex) {

            //        MessageBox.Show(ex.Message);

            //    }
            //}

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

        private void btFavorite_Click(object sender, EventArgs e) {
            var text = tbFavorite.Text;
            if (text != null && cbUrl.Text != null) {
                foreach (var item in rssUrlDict) {
                    if (item.Key == cbUrl.Text) {
                        return;
                    }
                }
                if (!rssUrlDict.ContainsKey(text)) {
                    rssUrlDict.Add(text, cbUrl.Text);
                    MessageBox.Show(text + "がお気に入り登録されました");
                }
                setCbUrl(text);

            }
        }

        //フォームが閉じたとき呼ばれる
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            //try {
            //    using (var writer = XmlWriter.Create("rssUrlDict.xml")) {
            //        var serializer = new XmlSerializer(typeof(Dictionary<string, string>));
            //        serializer.Serialize(writer, rssUrlDict);
            //    }
            //}
            //catch (Exception ex) {
            //    MessageBox.Show(ex.Message);
            //}



        }

        //削除
        private void btDel_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedIndex != -1) {
                MessageBox.Show(cbUrl.Text + "が消去されました");
                cbUrl.Items.RemoveAt(cbUrl.SelectedIndex);
            }
        }

        private void lbTitles_DrawItem(object sender, DrawItemEventArgs e) {
            var idx = e.Index;                                                      //描画対象の行
            if (idx == -1) return;                                                  //範囲外なら何もしない
            var sts = e.State;                                                      //セルの状態
            var fnt = e.Font;                                                       //フォント
            var _bnd = e.Bounds;                                                    //描画範囲(オリジナル)
            var bnd = new RectangleF(_bnd.X, _bnd.Y, _bnd.Width, _bnd.Height);     //描画範囲(描画用)
            var txt = (string)lbTitles.Items[idx];                                  //リストボックス内の文字
            var bsh = new SolidBrush(lbTitles.ForeColor);                           //文字色
            var sel = (DrawItemState.Selected == (sts & DrawItemState.Selected));   //選択行か
            var odd = (idx % 2 == 1);                                               //奇数行か
            var fore = Brushes.Gold;                                         //偶数行の背景色
            var bak = Brushes.Salmon;                                           //奇数行の背景色

            e.DrawBackground();                                                     //背景描画

            //奇数項目の背景色を変える（選択行は除く）
            if (odd && !sel) {
                e.Graphics.FillRectangle(bak, bnd);
            } else if (!odd && !sel) {
                e.Graphics.FillRectangle(fore, bnd);
            }

            //文字を描画
            e.Graphics.DrawString(txt, fnt, bsh, bnd);

        }
    }
}
