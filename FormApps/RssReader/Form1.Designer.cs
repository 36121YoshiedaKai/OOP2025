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
            btRssGet = new Button();
            lbTitles = new ListBox();
            wvRssLink = new Microsoft.Web.WebView2.WinForms.WebView2();
            btBack = new Button();
            btGo = new Button();
            cbUrl = new ComboBox();
            tbFavorite = new TextBox();
            btFavorite = new Button();
            btDel = new Button();
            ((System.ComponentModel.ISupportInitialize)wvRssLink).BeginInit();
            SuspendLayout();
            // 
            // btRssGet
            // 
            btRssGet.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            btRssGet.Location = new Point(538, 33);
            btRssGet.Name = "btRssGet";
            btRssGet.Size = new Size(75, 34);
            btRssGet.TabIndex = 1;
            btRssGet.Text = "取得";
            btRssGet.UseVisualStyleBackColor = true;
            btRssGet.Click += btRssGet_Click;
            // 
            // lbTitles
            // 
            lbTitles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbTitles.DrawMode = DrawMode.OwnerDrawFixed;
            lbTitles.Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 128);
            lbTitles.FormattingEnabled = true;
            lbTitles.ItemHeight = 21;
            lbTitles.Location = new Point(26, 131);
            lbTitles.Name = "lbTitles";
            lbTitles.Size = new Size(237, 508);
            lbTitles.TabIndex = 2;
            lbTitles.Click += lbTitles_Click;
            lbTitles.DrawItem += lbTitles_DrawItem;
            // 
            // wvRssLink
            // 
            wvRssLink.AllowExternalDrop = true;
            wvRssLink.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            wvRssLink.CreationProperties = null;
            wvRssLink.DefaultBackgroundColor = Color.White;
            wvRssLink.Location = new Point(270, 73);
            wvRssLink.Name = "wvRssLink";
            wvRssLink.Size = new Size(591, 566);
            wvRssLink.TabIndex = 3;
            wvRssLink.ZoomFactor = 1D;
            wvRssLink.NavigationCompleted += wvRssLink_NavigationCompleted;
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
            // cbUrl
            // 
            cbUrl.Font = new Font("Yu Gothic UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 128);
            cbUrl.FormattingEnabled = true;
            cbUrl.Location = new Point(26, 34);
            cbUrl.Name = "cbUrl";
            cbUrl.Size = new Size(506, 33);
            cbUrl.TabIndex = 6;
            // 
            // tbFavorite
            // 
            tbFavorite.Location = new Point(26, 73);
            tbFavorite.Name = "tbFavorite";
            tbFavorite.Size = new Size(156, 23);
            tbFavorite.TabIndex = 7;
            // 
            // btFavorite
            // 
            btFavorite.Location = new Point(188, 73);
            btFavorite.Name = "btFavorite";
            btFavorite.Size = new Size(75, 23);
            btFavorite.TabIndex = 8;
            btFavorite.Text = "お気に入り";
            btFavorite.UseVisualStyleBackColor = true;
            btFavorite.Click += btFavorite_Click;
            // 
            // btDel
            // 
            btDel.Location = new Point(188, 102);
            btDel.Name = "btDel";
            btDel.Size = new Size(75, 23);
            btDel.TabIndex = 9;
            btDel.Text = "削除";
            btDel.UseVisualStyleBackColor = true;
            btDel.Click += btDel_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(873, 648);
            Controls.Add(btDel);
            Controls.Add(btFavorite);
            Controls.Add(tbFavorite);
            Controls.Add(cbUrl);
            Controls.Add(btGo);
            Controls.Add(btBack);
            Controls.Add(wvRssLink);
            Controls.Add(lbTitles);
            Controls.Add(btRssGet);
            Name = "Form1";
            Text = "RSSリーダー";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wvRssLink).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btRssGet;
        private ListBox lbTitles;
        private Microsoft.Web.WebView2.WinForms.WebView2 wvRssLink;
        private Button btBack;
        private Button btGo;
        private ComboBox cbUrl;
        private TextBox tbFavorite;
        private Button btFavorite;
        private Button btDel;
    }
}
