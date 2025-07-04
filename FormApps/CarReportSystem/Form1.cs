using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> listCarReport = new BindingList<CarReport>();

        public Form1() {
            InitializeComponent();
            dgvRecode.DataSource = listCarReport;
        }

        private void btpicOpen_Click(object sender, EventArgs e) {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                pbPicture.Image = Image.FromFile(ofdPicFileOpen.FileName);
            }
        }

        private void btpicDelete_Click(object sender, EventArgs e) {
            pbPicture.Image = null;
        }

        private void btRCAdd_Click(object sender, EventArgs e) {
            if ((string.IsNullOrEmpty(cbAuthor.Text)) ||
                (string.IsNullOrEmpty(cbCarName.Text))) {
                tsslbMessage.Text = "記入者、または車名が未記入です";
                return;
            } else {
                tsslbMessage.Text = string.Empty;
                var carReport = new CarReport {
                    Date = dptDate.Value,
                    Author = cbAuthor.Text,
                    Maker = getRadioButtonMaker(),
                    CarName = cbCarName.Text,
                    Report = tbReport.Text,
                    Picture = pbPicture.Image,
                };
                listCarReport.Add(carReport);
                setCbAuthor(cbAuthor.Text);
                setCbCarName(cbCarName.Text);
                inputItemesAllClear();
            }
        }


        private void inputItemesAllClear() {
            dptDate.Value = DateTime.Today;
            cbAuthor.Text = string.Empty;
            if (rbToyota.Checked) rbToyota.Checked = false;
            if (rbNissan.Checked) rbNissan.Checked = false;
            if (rbHonda.Checked) rbHonda.Checked = false;
            if (rbSubaru.Checked) rbSubaru.Checked = false;
            if (rbImport.Checked) rbImport.Checked = false;
            if (rbather.Checked) rbather.Checked = false;
            cbCarName.Text = string.Empty;
            tbReport.Text = string.Empty;
            pbPicture.Image = null;


        }



        private CarReport.MakerGroup getRadioButtonMaker() {

            if (rbToyota.Checked) return CarReport.MakerGroup.トヨタ;
            if (rbNissan.Checked) return CarReport.MakerGroup.日産;
            if (rbHonda.Checked) return CarReport.MakerGroup.ホンダ;
            if (rbSubaru.Checked) return CarReport.MakerGroup.スバル;
            if (rbImport.Checked) return CarReport.MakerGroup.輸入車;
            if (rbather.Checked) return CarReport.MakerGroup.その他;
            return CarReport.MakerGroup.なし;

        }

        //レコードの呼び出し
        private void dgvRecode_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) return;

            dptDate.Value = (DateTime)dgvRecode.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecode.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvRecode.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecode.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecode.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecode.CurrentRow.Cells["Picture"].Value;

        }

        //ラジオボタン
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.トヨタ:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.日産:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ホンダ:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.スバル:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.輸入車:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.その他:
                    rbather.Checked = true;
                    break;
                default:
                    rbToyota.Checked = false;
                    rbNissan.Checked = false;
                    rbHonda.Checked = false;
                    rbSubaru.Checked = false;
                    rbImport.Checked = false;
                    rbather.Checked = false;
                    break;

            }
        }



        //記録者登録
        private void setCbAuthor(string author) {
            //登録済みか確認
            if (!cbAuthor.Items.Contains(author))
                //未登録なら登録
                cbAuthor.Items.Add(author);

        }
        //車の名前登録
        private void setCbCarName(string carName) {
            //登録済みか確認
            if (!cbCarName.Items.Contains(carName))
                //未登録なら登録
                cbCarName.Items.Add(carName);

        }
        //新規
        private void btNewRecord_Click(object sender, EventArgs e) {
            inputItemesAllClear();
        }
        //修正
        private void btRCModfy_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) return;
            //if ((dgvRecode.CurrentRow is null) ||
            //(!dgvRecode.CurrentRow.Selected)) return;
            if ((string.IsNullOrEmpty(cbAuthor.Text)) ||
                (string.IsNullOrEmpty(cbCarName.Text))) {
                tsslbMessage.Text = "記入者、または車名が未記入です";
                return;
            } else {
                tsslbMessage.Text = string.Empty;
                int index = dgvRecode.CurrentRow.Index;
                listCarReport[index].Date = dptDate.Value;
                listCarReport[index].Author = cbAuthor.Text;
                listCarReport[index].Maker = getRadioButtonMaker();
                listCarReport[index].CarName = cbCarName.Text;
                listCarReport[index].Report = tbReport.Text;
                listCarReport[index].Picture = pbPicture.Image;
                setCbAuthor(cbAuthor.Text);
                setCbCarName(cbCarName.Text);
                dgvRecode.Refresh();
                inputItemesAllClear();
            }
        }
        //削除
        private void btRCDelete_Click(object sender, EventArgs e) {
            //if (dgvRecode.RowCount != 0) {
            if ((dgvRecode.CurrentRow is null) ||
                (!dgvRecode.CurrentRow.Selected)) return;
            int index = dgvRecode.CurrentRow.Index;

            listCarReport.RemoveAt(index);
            //}
        }
        private void Form1_Load(object sender, EventArgs e) {
            inputItemesAllClear();
        }


    }
}
