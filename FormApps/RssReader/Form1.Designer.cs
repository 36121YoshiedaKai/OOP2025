namespace RssReader {
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
            tbUrl = new TextBox();
            btRssGet = new Button();
            lbTitles = new ListBox();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            btBack = new Button();
            btGo = new Button();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // tbUrl
            // 
            tbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            tbUrl.Location = new Point(26, 34);
            tbUrl.Name = "tbUrl";
            tbUrl.Size = new Size(553, 33);
            tbUrl.TabIndex = 0;
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(585, 34);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 32);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(26, 73);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(662, 256);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(26, 335);
            webView21.Name = "webView21";
            webView21.Size = new Size(662, 310);
            webView21.TabIndex = 3;
            webView21.ZoomFactor = 1D;
            // 
            // btBack
            // 
            btBack.Location = new Point(26, 5);
            btBack.Name = "btBack";
            btBack.Size = new Size(75, 23);
            btBack.TabIndex = 4;
            btBack.Text = "戻る";
            btBack.UseVisualStyleBackColor = true;
            btBack.Click += btBack_Click;
            // 
            // btGo
            // 
            btGo.Location = new Point(107, 5);
            btGo.Name = "btGo";
            btGo.Size = new Size(75, 23);
            btGo.TabIndex = 5;
            btGo.Text = "進む";
            btGo.UseVisualStyleBackColor = true;
            btGo.Click += btGo_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 647);
            Controls.Add(btGo);
            Controls.Add(btBack);
            Controls.Add(webView21);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Controls.Add(tbUrl);
            Name = "Form1";
            Text = "RSSリーダー";
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUrl;
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private Button btBack;
        private Button btGo;
    }
}
