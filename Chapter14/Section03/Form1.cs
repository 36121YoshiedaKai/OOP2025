using System.Diagnostics;
using System.Threading.Tasks;

namespace Section03 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }


        private async void button1_Click(object sender, EventArgs e) {
            toolStripStatuLabel1.Text = "";
            var elapsed = await DoLongTimeWorkAsync(4000);
            toolStripStatuLabel1.Text = $"{elapsed}ƒ~ƒŠ•b";

        }

        private async Task<long> DoLongTimeWorkAsync(int milliseconds) {
            var sw = Stopwatch.StartNew();
            await Task.Run(() => {
                System.Threading.Thread.Sleep(milliseconds);
            });
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        //”ñ“¯Šú‚ß‚»‚Á‚Ç
        private async Task DoLongTimeWork() {
            await Task.Run(() => {
                System.Threading.Thread.Sleep(5000);
            });
        }
    }
}

