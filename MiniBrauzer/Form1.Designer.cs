namespace MiniBrauzer
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnForward = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.panelRight = new System.Windows.Forms.Panel();
            this.lblFav = new System.Windows.Forms.Label();
            this.listFavorites = new System.Windows.Forms.ListBox();
            this.lblHistory = new System.Windows.Forms.Label();
            this.listHistory = new System.Windows.Forms.ListBox();
            this.btnAddFav = new System.Windows.Forms.Button();
            this.panelTop.SuspendLayout();
            this.panelRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            this.panelTop.Controls.Add(this.btnBack);
            this.panelTop.Controls.Add(this.btnForward);
            this.panelTop.Controls.Add(this.btnRefresh);
            this.panelTop.Controls.Add(this.btnHome);
            this.panelTop.Controls.Add(this.txtUrl);
            this.panelTop.Controls.Add(this.btnGo);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(770, 46);
            this.panelTop.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.White;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.Location = new System.Drawing.Point(8, 8);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(38, 30);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = "\u2190";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnForward
            // 
            this.btnForward.BackColor = System.Drawing.Color.White;
            this.btnForward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnForward.Location = new System.Drawing.Point(52, 8);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(38, 30);
            this.btnForward.TabIndex = 1;
            this.btnForward.Text = "\u2192";
            this.btnForward.UseVisualStyleBackColor = false;
            this.btnForward.Click += new System.EventHandler(this.btnForward_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.White;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(96, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(38, 30);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "\u21BB";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.White;
            this.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHome.Location = new System.Drawing.Point(140, 8);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(38, 30);
            this.btnHome.TabIndex = 3;
            this.btnHome.Text = "\u2302";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(188, 11);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(486, 25);
            this.txtUrl.TabIndex = 4;
            this.txtUrl.Text = "https://www.example.com";
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.BackColor = System.Drawing.Color.FromArgb(200, 245, 215);
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnGo.Location = new System.Drawing.Point(682, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(80, 30);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Get";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 46);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(770, 554);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tabControl1_MouseUp);
            // 
            // panelRight
            // 
            this.panelRight.BackColor = System.Drawing.Color.FromArgb(246, 249, 252);
            this.panelRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRight.Controls.Add(this.lblFav);
            this.panelRight.Controls.Add(this.listFavorites);
            this.panelRight.Controls.Add(this.lblHistory);
            this.panelRight.Controls.Add(this.listHistory);
            this.panelRight.Controls.Add(this.btnAddFav);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRight.Location = new System.Drawing.Point(770, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(230, 600);
            this.panelRight.TabIndex = 2;
            // 
            // lblFav
            // 
            this.lblFav.AutoSize = true;
            this.lblFav.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblFav.Location = new System.Drawing.Point(10, 12);
            this.lblFav.Name = "lblFav";
            this.lblFav.Size = new System.Drawing.Size(118, 17);
            this.lblFav.TabIndex = 0;
            this.lblFav.Text = "Seçilmişlər (ListBox)";
            // 
            // listFavorites
            // 
            this.listFavorites.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listFavorites.FormattingEnabled = true;
            this.listFavorites.IntegralHeight = false;
            this.listFavorites.ItemHeight = 17;
            this.listFavorites.Location = new System.Drawing.Point(10, 36);
            this.listFavorites.Name = "listFavorites";
            this.listFavorites.Size = new System.Drawing.Size(206, 140);
            this.listFavorites.TabIndex = 1;
            this.listFavorites.DoubleClick += new System.EventHandler(this.listFavorites_DoubleClick);
            this.listFavorites.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listFavorites_KeyDown);
            // 
            // lblHistory
            // 
            this.lblHistory.AutoSize = true;
            this.lblHistory.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblHistory.Location = new System.Drawing.Point(10, 192);
            this.lblHistory.Name = "lblHistory";
            this.lblHistory.Size = new System.Drawing.Size(100, 17);
            this.lblHistory.TabIndex = 2;
            this.lblHistory.Text = "Tarixçə (ListBox)";
            // 
            // listHistory
            // 
            this.listHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listHistory.FormattingEnabled = true;
            this.listHistory.IntegralHeight = false;
            this.listHistory.ItemHeight = 17;
            this.listHistory.Location = new System.Drawing.Point(10, 216);
            this.listHistory.Name = "listHistory";
            this.listHistory.Size = new System.Drawing.Size(206, 130);
            this.listHistory.TabIndex = 3;
            this.listHistory.DoubleClick += new System.EventHandler(this.listHistory_DoubleClick);
            // 
            // btnAddFav
            // 
            this.btnAddFav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFav.BackColor = System.Drawing.Color.FromArgb(255, 252, 200);
            this.btnAddFav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFav.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddFav.Location = new System.Drawing.Point(10, 362);
            this.btnAddFav.Name = "btnAddFav";
            this.btnAddFav.Size = new System.Drawing.Size(206, 34);
            this.btnAddFav.TabIndex = 4;
            this.btnAddFav.Text = "Seçilmişlərə əlavə et";
            this.btnAddFav.UseVisualStyleBackColor = false;
            this.btnAddFav.Click += new System.EventHandler(this.btnAddFav_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelRight);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(720, 420);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1 - Mini Brauzer (WinForms + WebView2)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnForward;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.Label lblFav;
        private System.Windows.Forms.ListBox listFavorites;
        private System.Windows.Forms.Label lblHistory;
        private System.Windows.Forms.ListBox listHistory;
        private System.Windows.Forms.Button btnAddFav;
    }
}
