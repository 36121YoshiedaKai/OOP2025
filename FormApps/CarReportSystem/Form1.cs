using System.ComponentModel;

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
            var carReport = new CarReport {
                Date = dptDate.Value,
                Author = cbAuthor.Text,
                Maker = GetRadioButtonMaker(),
                CarName = cbCarName.Text,
                Report = tbReport.Text,
                Picture = pbPicture.Image,
            };
            listCarReport.Add(carReport);
            setCbAuthor(cbAuthor.Text);
            setCbCarName(cbCarName.Text);
            InputItemesAllClear();
        }


        private void InputItemesAllClear() {
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



        private CarReport.MakerGroup GetRadioButtonMaker() {

            if (rbToyota.Checked) return CarReport.MakerGroup.�g���^;
            if (rbNissan.Checked) return CarReport.MakerGroup.���Y;
            if (rbHonda.Checked) return CarReport.MakerGroup.�z���_;
            if (rbSubaru.Checked) return CarReport.MakerGroup.�X�o��;
            if (rbImport.Checked) return CarReport.MakerGroup.�A����;
            if (rbather.Checked) return CarReport.MakerGroup.���̑�;
            return CarReport.MakerGroup.�Ȃ�;

        }

        private void dgvRecode_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) {

            } else {
                dptDate.Value = (DateTime)dgvRecode.CurrentRow.Cells["Date"].Value;
                cbAuthor.Text = (String)dgvRecode.CurrentRow.Cells["Author"].Value;
                setRadioButtonMaker((CarReport.MakerGroup)dgvRecode.CurrentRow.Cells["Maker"].Value);
                cbCarName.Text = (String)dgvRecode.CurrentRow.Cells["CarName"].Value;
                tbReport.Text = (String)dgvRecode.CurrentRow.Cells["Report"].Value;
                pbPicture.Image = (Image)dgvRecode.CurrentRow.Cells["Picture"].Value;
            }

        }

        private void setRadioButtonMaker(CarReport.MakerGroup targetMaker) {
            switch (targetMaker) {
                case CarReport.MakerGroup.�g���^:
                    rbToyota.Checked = true;
                    break;
                case CarReport.MakerGroup.���Y:
                    rbNissan.Checked = true;
                    break;
                case CarReport.MakerGroup.�z���_:
                    rbHonda.Checked = true;
                    break;
                case CarReport.MakerGroup.�X�o��:
                    rbSubaru.Checked = true;
                    break;
                case CarReport.MakerGroup.�A����:
                    rbImport.Checked = true;
                    break;
                case CarReport.MakerGroup.���̑�:
                    rbather.Checked = true;
                    break;
                default:
                    break;
            }
        }




        private void setCbAuthor(string author) {
            //�o�^�ς݂��m�F
            if (!cbAuthor.Items.Contains(author))
                //���o�^�Ȃ�o�^
                cbAuthor.Items.Add(author);

        }

        private void setCbCarName(string carName) {
            //�o�^�ς݂��m�F
            if (!cbCarName.Items.Contains(carName))
                //���o�^�Ȃ�o�^
                cbCarName.Items.Add(carName);

        }

        private void btNewRecord_Click(object sender, EventArgs e) {
            InputItemesAllClear();
        }

        private void btRCModfy_Click(object sender, EventArgs e) {

        }
        private void btRCDelete_Click(object sender, EventArgs e) {
            foreach (var del in listCarReport) {
            }
        }
        private void Form1_Load(object sender, EventArgs e) {
            InputItemesAllClear();
        }


    }
}
