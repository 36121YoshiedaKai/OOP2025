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
            { "��v", "https://news.yahoo.co.jp/rss/topics/top-picks.xml" },
            { "����", "https://news.yahoo.co.jp/rss/topics/domestic.xml" },
            { "����", "https://news.yahoo.co.jp/rss/topics/world.xml" },
            { "�o��", "https://news.yahoo.co.jp/rss/topics/business.xml" },
            { "�G���^��", "https://news.yahoo.co.jp/rss/topics/entertainment.xml" },
            { "�X�|�[�c", "https://news.yahoo.co.jp/rss/topics/sports.xml" },
            { "IT", "https://news.yahoo.co.jp/rss/topics/it.xml" },
            { "�Ȋw", "https://news.yahoo.co.jp/rss/topics/science.xml" },
            { "�n��", "https://news.yahoo.co.jp/rss/topics/local.xml" },
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

            try {
                using (var hc = new HttpClient()) {
                    string xml = await hc.GetStringAsync(getRssUrl(cbUrl.Text));
                    XDocument xdoc = XDocument.Parse(xml);

                    //var url = hc.OpenRead(cbUrl.Text);
                    //XDocument xdoc = XDocument.Load(url);   //RSS�̎擾

                    //RSS����͂��ĕK�v�ȗv�f���擾
                    items = xdoc.Root.Descendants("item")
                        .Select(x => new ItemData {
                            Title = (string?)x.Element("title"),
                            Link = (string?)x.Element("link"),
                        }).ToList();


                    //���X�g�{�b�N�X�փ^�C�g���\��
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
        //�R���{�{�b�N�X���當������`�F�b�N���ăA�N�Z�X�\��URL��ԋp����
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
            //�o�^�ς݂��m�F
            if (!cbUrl.Items.Contains(author))
                //���o�^�Ȃ�o�^
                cbUrl.Items.Add(author);

        }

        private void btFavorite_Click(object sender, EventArgs e) {
            var text = tbFavorite.Text;
            if (text != null && cbUrl.Text != null) {
                if (!rssUrlDict.ContainsKey(text)) {
                    rssUrlDict.Add(text, cbUrl.Text);
                }
                setCbUrl(text);

            }
        }

        //�t�H�[���������Ƃ��Ă΂��
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

        //�폜
        private void btDel_Click(object sender, EventArgs e) {
            if (cbUrl.SelectedIndex != -1) {
                cbUrl.Items.RemoveAt(cbUrl.SelectedIndex);
            }
        }
    }
}
