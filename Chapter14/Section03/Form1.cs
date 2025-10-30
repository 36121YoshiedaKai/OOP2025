using System.Diagnostics;
using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatuLabel1.Text = "";
            await DoLongTimeWork();
            toolStripStatuLabel1.Text = $"I—¹";

        }

        //”ñ“¯Šú‚ß‚»‚Á‚Ç
        private async Task DoLongTimeWork() {
            await Task.Run(() => {
                System.Threading.Thread.Sleep(5000);
            });
        }
    }
}

