using System.ComponentModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration;
using System.Xml;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace CarReportSystem {
    public partial class Form1 : Form {
        BindingList<CarReport> listCarReport = new BindingList<CarReport>();

        //�ݒ�N���X�̃C���X�^���X����
        Settings settings = new Settings();

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
            if ((cbAuthor.Text == string.Empty) ||
                (cbCarName.Text == string.Empty)) {
                tsslbMessage.Text = "�L���ҁA�܂��͎Ԗ������L���ł�";
                return;
            }
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

            if (rbToyota.Checked) return CarReport.MakerGroup.�g���^;
            if (rbNissan.Checked) return CarReport.MakerGroup.���Y;
            if (rbHonda.Checked) return CarReport.MakerGroup.�z���_;
            if (rbSubaru.Checked) return CarReport.MakerGroup.�X�o��;
            if (rbImport.Checked) return CarReport.MakerGroup.�A����;
            if (rbather.Checked) return CarReport.MakerGroup.���̑�;
            return CarReport.MakerGroup.�Ȃ�;

        }

        //���R�[�h�̌Ăяo��
        private void dgvRecode_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) return;
            if ((dgvRecode.CurrentRow is null) ||
                (!dgvRecode.CurrentRow.Selected)) return;

            dptDate.Value = (DateTime)dgvRecode.CurrentRow.Cells["Date"].Value;
            cbAuthor.Text = (string)dgvRecode.CurrentRow.Cells["Author"].Value;
            setRadioButtonMaker((CarReport.MakerGroup)dgvRecode.CurrentRow.Cells["Maker"].Value);
            cbCarName.Text = (string)dgvRecode.CurrentRow.Cells["CarName"].Value;
            tbReport.Text = (string)dgvRecode.CurrentRow.Cells["Report"].Value;
            pbPicture.Image = (Image)dgvRecode.CurrentRow.Cells["Picture"].Value;

        }

        //���W�I�{�^��
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
                    rbToyota.Checked = false;
                    rbNissan.Checked = false;
                    rbHonda.Checked = false;
                    rbSubaru.Checked = false;
                    rbImport.Checked = false;
                    rbather.Checked = false;
                    break;

            }
        }



        //�L�^�ғo�^
        private void setCbAuthor(string author) {
            //�o�^�ς݂��m�F
            if (!cbAuthor.Items.Contains(author))
                //���o�^�Ȃ�o�^
                cbAuthor.Items.Add(author);

        }
        //�Ԃ̖��O�o�^
        private void setCbCarName(string carName) {
            //�o�^�ς݂��m�F
            if (!cbCarName.Items.Contains(carName))
                //���o�^�Ȃ�o�^
                cbCarName.Items.Add(carName);

        }
        //�V�K
        private void btNewRecord_Click(object sender, EventArgs e) {
            inputItemesAllClear();
        }
        //�C��
        private void btRCModfy_Click(object sender, EventArgs e) {
            if (dgvRecode.RowCount == 0) return;
            //if ((dgvRecode.CurrentRow is null) ||
            //(!dgvRecode.CurrentRow.Selected)) return;
            if ((cbAuthor.Text == string.Empty) ||
                (cbCarName.Text == string.Empty)) {
                tsslbMessage.Text = "�L���ҁA�܂��͎Ԗ������L���ł�";
                return;
            }
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
        //�폜
        private void btRCDelete_Click(object sender, EventArgs e) {
            //if (dgvRecode.RowCount != 0) {
            if ((dgvRecode.CurrentRow is null) ||
                (!dgvRecode.CurrentRow.Selected)) return;
            int index = dgvRecode.CurrentRow.Index;

            listCarReport.RemoveAt(index);
            //}
        }


        private void tsmiExit_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void tsmiAbout_Click(object sender, EventArgs e) {
            var fmv = new fmVersion();
            fmv.ShowDialog();
        }

        private void �F�ݒ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            if (cdColor.ShowDialog() == DialogResult.OK) {

                this.BackColor = cdColor.Color;
                //�ݒ�t�@�C���֕ۑ�
                settings.MainFormBackColor = cdColor.Color.ToArgb();//�w�i�F��ݒ�C���X�^���X�֐ݒ�

            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            inputItemesAllClear();


            //���݂ɐF��ݒ�@�f�[�^�O���b�h�r���[
            dgvRecode.DefaultCellStyle.BackColor = Color.LightGreen;
            dgvRecode.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            //�ݒ�t�@�C����ǂݍ��ݔw�i�F��ݒ肷��i�t�V���A�����j
            try {
                using (var reader = XmlReader.Create("settings.xml")) {
                    var serializer = new XmlSerializer(typeof(Settings));
                    var set = serializer.Deserialize(reader) as Settings;
                    if (set is null) {
                        return;
                    }

                    Color color = Color.FromArgb(set.MainFormBackColor);
                    BackColor = color;

                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);

            }

        }

        //�t�@�C���Z�[�u
        private void reportSaveFile() {
            if (sfdReportFileSave.ShowDialog() == DialogResult.OK) {
                try {
                    //�o�C�i���`���ŃV���A����
#pragma warning disable SYSLIB0011
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011

                    using (FileStream fs = File.Open(
                        sfdReportFileSave.FileName, FileMode.Create)) {

                        bf.Serialize(fs, listCarReport);
                    }
                }
                catch (Exception ex) {
                    tsslbMessage.Text = "�t�@�C�������o���G���[";
                    MessageBox.Show(ex.Message);
                }


            }
        }
        //�t�@�C���I�[�v��
        private void reportOpenFile() {
            if (ofdPicFileOpen.ShowDialog() == DialogResult.OK) {
                try {
                    //�t�V���A����
#pragma warning disable SYSLIB0011 // �^�܂��̓����o�[�����^���ł�
                    var bf = new BinaryFormatter();
#pragma warning restore SYSLIB0011 // �^�܂��̓����o�[�����^���ł�

                    using (FileStream fs = File.Open(ofdPicFileOpen.FileName,
                        FileMode.Open, FileAccess.Read)) {

                        listCarReport = (BindingList<CarReport>)bf.Deserialize(fs);
                        dgvRecode.DataSource = listCarReport;

                        cbAuthor.Items.Clear();
                        cbCarName.Items.Clear();

                        //�R���{�{�b�N�X�ɓo�^
                        foreach (var item in listCarReport) {
                            setCbAuthor(item.Author);
                            setCbCarName(item.CarName);
                        }



                    }

                }
                catch (Exception) {

                    tsslbMessage.Text = "�t�@�C���`�����Ⴂ�܂�";
                }
            }
        }

        private void �ۑ�ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportSaveFile();
        }

        private void �J��ToolStripMenuItem_Click(object sender, EventArgs e) {
            reportOpenFile();
        }

        //�t�H�[���������Ƃ��Ă΂��
        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {

            //�ݒ�t�@�C���֐F����ۑ����鏈���i�V���A�����j
            using (var writer = XmlWriter.Create("settings.xml")) {
                var serializer = new XmlSerializer(settings.GetType());
                serializer.Serialize(writer, settings);
            }

        }
    }
}
