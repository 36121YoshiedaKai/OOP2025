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
                tsslbMessage.Text = "ãLì¸é“ÅAÇ‹ÇΩÇÕé‘ñºÇ™ñ¢ãLì¸Ç≈Ç∑";
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

            if (rbToyota.Checked) return CarReport.MakerGroup.ÉgÉàÉ^;
            if (rbNissan.Checked) return CarReport.MakerGroup.ì˙éY;
            if (rbHonda.Checked) return CarReport.MakerGroup.ÉzÉìÉ_;
            if (rbSubaru.Checked) return CarReport.MakerGroup.ÉXÉoÉã;
            if (rbImport.Checked) return CarReport.MakerGroup.óAì¸é‘;
            if (rbather.Checked) return CarReport.MakerGroup.ÇªÇÃëº;
            return CarReport.MakerGroup.Ç»Çµ;

        }

        //ÉåÉRÅ[ÉhÇÃåƒÇ—èoÇµ
        private void dgvRecode_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) return;

            dptDate.Value = (DateTime)dgvRecode.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecode.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvRecode.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecode.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecode.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecode.CurrentRow.Cells["Picture"].Value;

        }

        //ÉâÉWÉIÉ{É^Éì
        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.ÉgÉàÉ^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.ì˙éY:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.ÉzÉìÉ_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.ÉXÉoÉã:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.óAì¸é‘:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.ÇªÇÃëº:
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



        //ãLò^é“ìoò^
        private void setCbAuthor(string author) {
            //ìoò^çœÇ›Ç©ämîF
            if (!cbAuthor.Items.Contains(author))
                //ñ¢ìoò^Ç»ÇÁìoò^
                cbAuthor.Items.Add(author);

        }
        //é‘ÇÃñºëOìoò^
        private void setCbCarName(string carName) {
            //ìoò^çœÇ›Ç©ämîF
            if (!cbCarName.Items.Contains(carName))
                //ñ¢ìoò^Ç»ÇÁìoò^
                cbCarName.Items.Add(carName);

        }
        //êVãK
        private void btNewRecord_Click(object sender, EventArgs e) {
            inputItemesAllClear();
        }
        //èCê≥
        private void btRCModfy_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) return;
            //if ((dgvRecode.CurrentRow is null) ||
            //(!dgvRecode.CurrentRow.Selected)) return;
            if ((string.IsNullOrEmpty(cbAuthor.Text)) ||
                (string.IsNullOrEmpty(cbCarName.Text))) {
                tsslbMessage.Text = "ãLì¸é“ÅAÇ‹ÇΩÇÕé‘ñºÇ™ñ¢ãLì¸Ç≈Ç∑";
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
        //çÌèú
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
