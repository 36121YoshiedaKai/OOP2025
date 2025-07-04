namespace CarReportSystem {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            dptDate = new DateTimePicker();
            cbAuthor = new ComboBox();
            groupBox1 = new GroupBox();
            rbSubaru = new RadioButton();
            rbather = new RadioButton();
            rbImport = new RadioButton();
            rbHonda = new RadioButton();
            rbNissan = new RadioButton();
            rbToyota = new RadioButton();
            cbCarName = new ComboBox();
            tbReport = new TextBox();
            dgvRecode = new DataGridView();
            pbPicture = new PictureBox();
            btpicOpen = new Button();
            btpicDelete = new Button();
            btRCAdd = new Button();
            btRCDelete = new Button();
            btRCModfy = new Button();
            ofdPicFileOpen = new OpenFileDialog();
            btNewRecord = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecode).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label1.Location = new Point(60, 52);
            label1.Name = "label1";
            label1.Size = new Size(55, 30);
            label1.TabIndex = 0;
            label1.Text = "日付";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label2.Location = new Point(60, 133);
            label2.Name = "label2";
            label2.Size = new Size(76, 30);
            label2.TabIndex = 0;
            label2.Text = "記録者";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label3.Location = new Point(60, 214);
            label3.Name = "label3";
            label3.Size = new Size(71, 30);
            label3.TabIndex = 0;
            label3.Text = "メーカー";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label4.Location = new Point(60, 295);
            label4.Name = "label4";
            label4.Size = new Size(55, 30);
            label4.TabIndex = 0;
            label4.Text = "車名";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label5.Location = new Point(60, 376);
            label5.Name = "label5";
            label5.Size = new Size(74, 30);
            label5.TabIndex = 0;
            label5.Text = "レポート";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label6.Location = new Point(60, 500);
            label6.Name = "label6";
            label6.Size = new Size(55, 30);
            label6.TabIndex = 0;
            label6.Text = "一蘭";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Yu Gothic UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 128);
            label7.Location = new Point(588, 52);
            label7.Name = "label7";
            label7.Size = new Size(55, 30);
            label7.TabIndex = 0;
            label7.Text = "画像";
            // 
            // dptDate
            // 
            dptDate.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            dptDate.Location = new Point(162, 50);
            dptDate.Name = "dptDate";
            dptDate.Size = new Size(200, 33);
            dptDate.TabIndex = 1;
            // 
            // cbAuthor
            // 
            cbAuthor.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbAuthor.FormattingEnabled = true;
            cbAuthor.Location = new Point(162, 131);
            cbAuthor.Name = "cbAuthor";
            cbAuthor.Size = new Size(200, 33);
            cbAuthor.TabIndex = 2;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(rbSubaru);
            groupBox1.Controls.Add(rbather);
            groupBox1.Controls.Add(rbImport);
            groupBox1.Controls.Add(rbHonda);
            groupBox1.Controls.Add(rbNissan);
            groupBox1.Controls.Add(rbToyota);
            groupBox1.Location = new Point(162, 197);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(369, 48);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            // 
            // rbSubaru
            // 
            rbSubaru.AutoSize = true;
            rbSubaru.Location = new Point(176, 22);
            rbSubaru.Name = "rbSubaru";
            rbSubaru.Size = new Size(54, 19);
            rbSubaru.TabIndex = 3;
            rbSubaru.TabStop = true;
            rbSubaru.Text = "スバル";
            rbSubaru.UseVisualStyleBackColor = true;
            // 
            // rbather
            // 
            rbather.AutoSize = true;
            rbather.Location = new Point(303, 22);
            rbather.Name = "rbather";
            rbather.Size = new Size(56, 19);
            rbather.TabIndex = 3;
            rbather.TabStop = true;
            rbather.Text = "その他";
            rbather.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            rbImport.AutoSize = true;
            rbImport.Location = new Point(236, 22);
            rbImport.Name = "rbImport";
            rbImport.Size = new Size(61, 19);
            rbImport.TabIndex = 3;
            rbImport.TabStop = true;
            rbImport.Text = "輸入車";
            rbImport.UseVisualStyleBackColor = true;
            // 
            // rbHonda
            // 
            rbHonda.AutoSize = true;
            rbHonda.Location = new Point(117, 22);
            rbHonda.Name = "rbHonda";
            rbHonda.Size = new Size(53, 19);
            rbHonda.TabIndex = 2;
            rbHonda.TabStop = true;
            rbHonda.Text = "ホンダ";
            rbHonda.UseVisualStyleBackColor = true;
            // 
            // rbNissan
            // 
            rbNissan.AutoSize = true;
            rbNissan.Location = new Point(62, 22);
            rbNissan.Name = "rbNissan";
            rbNissan.Size = new Size(49, 19);
            rbNissan.TabIndex = 1;
            rbNissan.TabStop = true;
            rbNissan.Text = "日産";
            rbNissan.UseVisualStyleBackColor = true;
            // 
            // rbToyota
            // 
            rbToyota.AutoSize = true;
            rbToyota.Location = new Point(6, 22);
            rbToyota.Name = "rbToyota";
            rbToyota.Size = new Size(50, 19);
            rbToyota.TabIndex = 0;
            rbToyota.TabStop = true;
            rbToyota.Text = "トヨタ";
            rbToyota.UseVisualStyleBackColor = true;
            // 
            // cbCarName
            // 
            cbCarName.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbCarName.FormattingEnabled = true;
            cbCarName.Location = new Point(162, 293);
            cbCarName.Name = "cbCarName";
            cbCarName.Size = new Size(200, 33);
            cbCarName.TabIndex = 2;
            // 
            // tbReport
            // 
            tbReport.Location = new Point(162, 376);
            tbReport.Multiline = true;
            tbReport.Name = "tbReport";
            tbReport.Size = new Size(420, 104);
            tbReport.TabIndex = 4;
            // 
            // dgvRecode
            // 
            dgvRecode.AllowUserToAddRows = false;
            dgvRecode.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRecode.Location = new Point(166, 501);
            dgvRecode.MultiSelect = false;
            dgvRecode.Name = "dgvRecode";
            dgvRecode.ReadOnly = true;
            dgvRecode.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRecode.Size = new Size(902, 146);
            dgvRecode.TabIndex = 5;
            dgvRecode.Click += dgvRecode_Click;
            // 
            // pbPicture
            // 
            pbPicture.BorderStyle = BorderStyle.FixedSingle;
            pbPicture.Location = new Point(588, 95);
            pbPicture.Name = "pbPicture";
            pbPicture.Size = new Size(480, 311);
            pbPicture.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPicture.TabIndex = 6;
            pbPicture.TabStop = false;
            // 
            // btpicOpen
            // 
            btpicOpen.FlatStyle = FlatStyle.Flat;
            btpicOpen.Location = new Point(912, 59);
            btpicOpen.Name = "btpicOpen";
            btpicOpen.Size = new Size(75, 23);
            btpicOpen.TabIndex = 7;
            btpicOpen.Text = "開く...";
            btpicOpen.UseVisualStyleBackColor = true;
            btpicOpen.Click += btpicOpen_Click;
            // 
            // btpicDelete
            // 
            btpicDelete.FlatStyle = FlatStyle.Flat;
            btpicDelete.Location = new Point(993, 59);
            btpicDelete.Name = "btpicDelete";
            btpicDelete.Size = new Size(75, 23);
            btpicDelete.TabIndex = 8;
            btpicDelete.Text = "削除";
            btpicDelete.UseVisualStyleBackColor = true;
            btpicDelete.Click += btpicDelete_Click;
            // 
            // btRCAdd
            // 
            btRCAdd.FlatStyle = FlatStyle.Flat;
            btRCAdd.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRCAdd.Location = new Point(621, 432);
            btRCAdd.Name = "btRCAdd";
            btRCAdd.Size = new Size(75, 56);
            btRCAdd.TabIndex = 9;
            btRCAdd.Text = "追加";
            btRCAdd.UseVisualStyleBackColor = true;
            btRCAdd.Click += btRCAdd_Click;
            // 
            // btRCDelete
            // 
            btRCDelete.FlatStyle = FlatStyle.Flat;
            btRCDelete.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRCDelete.Location = new Point(805, 432);
            btRCDelete.Name = "btRCDelete";
            btRCDelete.Size = new Size(75, 56);
            btRCDelete.TabIndex = 9;
            btRCDelete.Text = "削除";
            btRCDelete.UseVisualStyleBackColor = true;
            btRCDelete.Click += btRCDelete_Click;
            // 
            // btRCModfy
            // 
            btRCModfy.FlatStyle = FlatStyle.Flat;
            btRCModfy.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRCModfy.Location = new Point(713, 432);
            btRCModfy.Name = "btRCModfy";
            btRCModfy.Size = new Size(75, 56);
            btRCModfy.TabIndex = 9;
            btRCModfy.Text = "修正";
            btRCModfy.UseVisualStyleBackColor = true;
            btRCModfy.Click += btRCModfy_Click;
            // 
            // ofdPicFileOpen
            // 
            ofdPicFileOpen.AddExtension = false;
            ofdPicFileOpen.FileName = "openFileDialog1";
            // 
            // btNewRecord
            // 
            btNewRecord.FlatStyle = FlatStyle.Flat;
            btNewRecord.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btNewRecord.Location = new Point(407, 50);
            btNewRecord.Name = "btNewRecord";
            btNewRecord.Size = new Size(124, 57);
            btNewRecord.TabIndex = 10;
            btNewRecord.Text = "新規";
            btNewRecord.UseVisualStyleBackColor = true;
            btNewRecord.Click += btNewRecord_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1080, 658);
            Controls.Add(btNewRecord);
            Controls.Add(btRCModfy);
            Controls.Add(btRCDelete);
            Controls.Add(btRCAdd);
            Controls.Add(btpicDelete);
            Controls.Add(btpicOpen);
            Controls.Add(pbPicture);
            Controls.Add(dgvRecode);
            Controls.Add(tbReport);
            Controls.Add(groupBox1);
            Controls.Add(cbCarName);
            Controls.Add(cbAuthor);
            Controls.Add(dptDate);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label7);
            Controls.Add(label1);
            Name = "Form1";
            Text = "試乗レポート管理システム";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvRecode).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbPicture).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private DateTimePicker dptDate;
        private ComboBox cbAuthor;
        private GroupBox groupBox1;
        private RadioButton rbToyota;
        private RadioButton rbSubaru;
        private RadioButton rbather;
        private RadioButton rbImport;
        private RadioButton rbHonda;
        private RadioButton rbNissan;
        private ComboBox cbCarName;
        private TextBox tbReport;
        private DataGridView dgvRecode;
        private PictureBox pbPicture;
        private Button btpicOpen;
        private Button btpicDelete;
        private Button btRCAdd;
        private Button btRCDelete;
        private Button btRCModfy;
        private OpenFileDialog ofdPicFileOpen;
        private Button btNewRecord;
    }
}
