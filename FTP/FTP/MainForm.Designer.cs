namespace FTP
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LogoutBtn = new System.Windows.Forms.Button();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.PasswordTxt = new System.Windows.Forms.TextBox();
            this.UsernameTxt = new System.Windows.Forms.TextBox();
            this.DomainNameTxt = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.IPLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.LocalTreeView = new System.Windows.Forms.TreeView();
            this.FileIcon = new System.Windows.Forms.ImageList(this.components);
            this.LocalListView = new System.Windows.Forms.ListView();
            this.LocalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocalSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocalCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LocalContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ServerListView = new System.Windows.Forms.ListView();
            this.ServerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerCreateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ServerContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.DownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MakeDirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Log = new System.Windows.Forms.ListBox();
            this.LogContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ClearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.LocalContextMenuStrip.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.ServerContextMenuStrip.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.LogContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.LogoutBtn);
            this.groupBox1.Controls.Add(this.LoginBtn);
            this.groupBox1.Controls.Add(this.PasswordTxt);
            this.groupBox1.Controls.Add(this.UsernameTxt);
            this.groupBox1.Controls.Add(this.DomainNameTxt);
            this.groupBox1.Controls.Add(this.PasswordLabel);
            this.groupBox1.Controls.Add(this.UsernameLabel);
            this.groupBox1.Controls.Add(this.IPLabel);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1149, 88);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "建立连接";
            // 
            // LogoutBtn
            // 
            this.LogoutBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LogoutBtn.Location = new System.Drawing.Point(978, 29);
            this.LogoutBtn.Name = "LogoutBtn";
            this.LogoutBtn.Size = new System.Drawing.Size(100, 30);
            this.LogoutBtn.TabIndex = 7;
            this.LogoutBtn.Text = "断开";
            this.LogoutBtn.UseVisualStyleBackColor = true;
            this.LogoutBtn.Click += new System.EventHandler(this.LogoutBtn_Click);
            // 
            // LoginBtn
            // 
            this.LoginBtn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LoginBtn.Location = new System.Drawing.Point(841, 29);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(100, 30);
            this.LoginBtn.TabIndex = 6;
            this.LoginBtn.Text = "连接";
            this.LoginBtn.UseVisualStyleBackColor = true;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // PasswordTxt
            // 
            this.PasswordTxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordTxt.Location = new System.Drawing.Point(525, 34);
            this.PasswordTxt.Name = "PasswordTxt";
            this.PasswordTxt.Size = new System.Drawing.Size(241, 25);
            this.PasswordTxt.TabIndex = 5;
            // 
            // UsernameTxt
            // 
            this.UsernameTxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UsernameTxt.Location = new System.Drawing.Point(338, 34);
            this.UsernameTxt.Name = "UsernameTxt";
            this.UsernameTxt.Size = new System.Drawing.Size(135, 25);
            this.UsernameTxt.TabIndex = 4;
            // 
            // DomainNameTxt
            // 
            this.DomainNameTxt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.DomainNameTxt.Location = new System.Drawing.Point(95, 34);
            this.DomainNameTxt.Name = "DomainNameTxt";
            this.DomainNameTxt.Size = new System.Drawing.Size(178, 25);
            this.DomainNameTxt.TabIndex = 3;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(482, 37);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(37, 15);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "密码";
            this.PasswordLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(285, 37);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(52, 15);
            this.UsernameLabel.TabIndex = 1;
            this.UsernameLabel.Text = "用户名";
            this.UsernameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IPLabel
            // 
            this.IPLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.IPLabel.AutoSize = true;
            this.IPLabel.Location = new System.Drawing.Point(9, 37);
            this.IPLabel.Name = "IPLabel";
            this.IPLabel.Size = new System.Drawing.Size(82, 15);
            this.IPLabel.TabIndex = 0;
            this.IPLabel.Text = "服务器域名";
            this.IPLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(584, 307);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本地目录";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 21);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.LocalTreeView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LocalListView);
            this.splitContainer2.Size = new System.Drawing.Size(578, 283);
            this.splitContainer2.SplitterDistance = 146;
            this.splitContainer2.TabIndex = 0;
            // 
            // LocalTreeView
            // 
            this.LocalTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalTreeView.ImageIndex = 0;
            this.LocalTreeView.ImageList = this.FileIcon;
            this.LocalTreeView.Location = new System.Drawing.Point(0, 0);
            this.LocalTreeView.Name = "LocalTreeView";
            this.LocalTreeView.SelectedImageIndex = 0;
            this.LocalTreeView.Size = new System.Drawing.Size(578, 146);
            this.LocalTreeView.TabIndex = 0;
            this.LocalTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.LocalTreeView_AfterSelect);
            // 
            // FileIcon
            // 
            this.FileIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.FileIcon.ImageSize = new System.Drawing.Size(16, 16);
            this.FileIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LocalListView
            // 
            this.LocalListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LocalName,
            this.LocalSize,
            this.LocalCreateTime});
            this.LocalListView.ContextMenuStrip = this.LocalContextMenuStrip;
            this.LocalListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LocalListView.HideSelection = false;
            this.LocalListView.Location = new System.Drawing.Point(0, 0);
            this.LocalListView.Name = "LocalListView";
            this.LocalListView.Size = new System.Drawing.Size(578, 133);
            this.LocalListView.SmallImageList = this.FileIcon;
            this.LocalListView.TabIndex = 1;
            this.LocalListView.UseCompatibleStateImageBehavior = false;
            this.LocalListView.View = System.Windows.Forms.View.Details;
            this.LocalListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LocalListView_MouseDoubleClick);
            // 
            // LocalName
            // 
            this.LocalName.Text = "名称";
            this.LocalName.Width = 263;
            // 
            // LocalSize
            // 
            this.LocalSize.Text = "大小";
            this.LocalSize.Width = 86;
            // 
            // LocalCreateTime
            // 
            this.LocalCreateTime.Text = "创建时间";
            this.LocalCreateTime.Width = 205;
            // 
            // LocalContextMenuStrip
            // 
            this.LocalContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LocalContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UploadToolStripMenuItem});
            this.LocalContextMenuStrip.Name = "LocalContextMenuStrip";
            this.LocalContextMenuStrip.Size = new System.Drawing.Size(109, 28);
            // 
            // UploadToolStripMenuItem
            // 
            this.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem";
            this.UploadToolStripMenuItem.Size = new System.Drawing.Size(108, 24);
            this.UploadToolStripMenuItem.Text = "上传";
            this.UploadToolStripMenuItem.Click += new System.EventHandler(this.UploadToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ServerListView);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(561, 307);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "服务器目录";
            // 
            // ServerListView
            // 
            this.ServerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ServerName,
            this.ServerSize,
            this.ServerCreateTime});
            this.ServerListView.ContextMenuStrip = this.ServerContextMenuStrip;
            this.ServerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerListView.HideSelection = false;
            this.ServerListView.Location = new System.Drawing.Point(3, 21);
            this.ServerListView.Name = "ServerListView";
            this.ServerListView.Size = new System.Drawing.Size(555, 283);
            this.ServerListView.SmallImageList = this.FileIcon;
            this.ServerListView.TabIndex = 0;
            this.ServerListView.UseCompatibleStateImageBehavior = false;
            this.ServerListView.View = System.Windows.Forms.View.Details;
            this.ServerListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ServerListView_MouseDoubleClick);
            // 
            // ServerName
            // 
            this.ServerName.Text = "名称";
            this.ServerName.Width = 267;
            // 
            // ServerSize
            // 
            this.ServerSize.Text = "大小";
            this.ServerSize.Width = 90;
            // 
            // ServerCreateTime
            // 
            this.ServerCreateTime.Text = "创建时间";
            this.ServerCreateTime.Width = 191;
            // 
            // ServerContextMenuStrip
            // 
            this.ServerContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ServerContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DownloadToolStripMenuItem,
            this.DeleteToolStripMenuItem,
            this.MakeDirToolStripMenuItem});
            this.ServerContextMenuStrip.Name = "ServerContextMenuStrip";
            this.ServerContextMenuStrip.Size = new System.Drawing.Size(139, 76);
            // 
            // DownloadToolStripMenuItem
            // 
            this.DownloadToolStripMenuItem.Name = "DownloadToolStripMenuItem";
            this.DownloadToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.DownloadToolStripMenuItem.Text = "下载";
            this.DownloadToolStripMenuItem.Click += new System.EventHandler(this.DownloadToolStripMenuItem_Click);
            // 
            // DeleteToolStripMenuItem
            // 
            this.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            this.DeleteToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.DeleteToolStripMenuItem.Text = "删除";
            this.DeleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItem_Click);
            // 
            // MakeDirToolStripMenuItem
            // 
            this.MakeDirToolStripMenuItem.Name = "MakeDirToolStripMenuItem";
            this.MakeDirToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.MakeDirToolStripMenuItem.Text = "新建目录";
            this.MakeDirToolStripMenuItem.Click += new System.EventHandler(this.MakeDirToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.Log);
            this.groupBox4.Location = new System.Drawing.Point(0, 407);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1149, 215);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "日志";
            // 
            // Log
            // 
            this.Log.ContextMenuStrip = this.LogContextMenuStrip;
            this.Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Log.FormattingEnabled = true;
            this.Log.ItemHeight = 15;
            this.Log.Location = new System.Drawing.Point(3, 21);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(1143, 191);
            this.Log.TabIndex = 0;
            // 
            // LogContextMenuStrip
            // 
            this.LogContextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LogContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClearToolStripMenuItem});
            this.LogContextMenuStrip.Name = "LogContextMenuStrip";
            this.LogContextMenuStrip.Size = new System.Drawing.Size(211, 56);
            // 
            // ClearToolStripMenuItem
            // 
            this.ClearToolStripMenuItem.Name = "ClearToolStripMenuItem";
            this.ClearToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.ClearToolStripMenuItem.Text = "清空";
            this.ClearToolStripMenuItem.Click += new System.EventHandler(this.ClearToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 94);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1149, 307);
            this.splitContainer1.SplitterDistance = 584;
            this.splitContainer1.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1149, 622);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "FTP Client";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.LocalContextMenuStrip.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ServerContextMenuStrip.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.LogContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button LogoutBtn;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.TextBox PasswordTxt;
        private System.Windows.Forms.TextBox UsernameTxt;
        private System.Windows.Forms.TextBox DomainNameTxt;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Label IPLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView LocalListView;
        private System.Windows.Forms.ImageList FileIcon;
        private System.Windows.Forms.TreeView LocalTreeView;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView ServerListView;
        private System.Windows.Forms.ListBox Log;
        private System.Windows.Forms.ColumnHeader LocalName;
        private System.Windows.Forms.ColumnHeader LocalSize;
        private System.Windows.Forms.ColumnHeader LocalCreateTime;
        private System.Windows.Forms.ColumnHeader ServerName;
        private System.Windows.Forms.ColumnHeader ServerSize;
        private System.Windows.Forms.ColumnHeader ServerCreateTime;
        private System.Windows.Forms.ContextMenuStrip LocalContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem UploadToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip ServerContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem DownloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MakeDirToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip LogContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ClearToolStripMenuItem;
    }
}