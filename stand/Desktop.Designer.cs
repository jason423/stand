namespace stand
{
    partial class Desktop
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改绑定邮箱ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改个人信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toollbl_Account = new System.Windows.Forms.ToolStripStatusLabel();
            this.我的上传ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文件审批ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.树维护ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.LightBlue;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem,
            this.系统菜单ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.我的上传ToolStripMenuItem,
            this.修改绑定邮箱ToolStripMenuItem,
            this.修改个人信息ToolStripMenuItem,
            this.修改密码ToolStripMenuItem});
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "菜单";
            // 
            // 修改绑定邮箱ToolStripMenuItem
            // 
            this.修改绑定邮箱ToolStripMenuItem.Name = "修改绑定邮箱ToolStripMenuItem";
            this.修改绑定邮箱ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改绑定邮箱ToolStripMenuItem.Text = "修改绑定邮箱";
            this.修改绑定邮箱ToolStripMenuItem.Click += new System.EventHandler(this.修改绑定邮箱ToolStripMenuItem_Click);
            // 
            // 修改个人信息ToolStripMenuItem
            // 
            this.修改个人信息ToolStripMenuItem.Name = "修改个人信息ToolStripMenuItem";
            this.修改个人信息ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改个人信息ToolStripMenuItem.Text = "修改手机号";
            this.修改个人信息ToolStripMenuItem.Click += new System.EventHandler(this.修改个人信息ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toollbl_Account});
            this.statusStrip.Location = new System.Drawing.Point(0, 0);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(1008, 25);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip";
            // 
            // toollbl_Account
            // 
            this.toollbl_Account.Name = "toollbl_Account";
            this.toollbl_Account.Size = new System.Drawing.Size(192, 17);
            this.toollbl_Account.Text = "登录账号：                               ";
            // 
            // 我的上传ToolStripMenuItem
            // 
            this.我的上传ToolStripMenuItem.Name = "我的上传ToolStripMenuItem";
            this.我的上传ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.我的上传ToolStripMenuItem.Text = "我的上传";
            // 
            // 系统菜单ToolStripMenuItem
            // 
            this.系统菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件审批ToolStripMenuItem,
            this.树维护ToolStripMenuItem});
            this.系统菜单ToolStripMenuItem.Name = "系统菜单ToolStripMenuItem";
            this.系统菜单ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.系统菜单ToolStripMenuItem.Text = "系统菜单";
            this.系统菜单ToolStripMenuItem.Visible = false;
            // 
            // 文件审批ToolStripMenuItem
            // 
            this.文件审批ToolStripMenuItem.Name = "文件审批ToolStripMenuItem";
            this.文件审批ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.文件审批ToolStripMenuItem.Text = "文件审批";
            // 
            // 树维护ToolStripMenuItem
            // 
            this.树维护ToolStripMenuItem.Name = "树维护ToolStripMenuItem";
            this.树维护ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.树维护ToolStripMenuItem.Text = "树维护";
            this.树维护ToolStripMenuItem.Click += new System.EventHandler(this.树维护ToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.statusStrip);
            this.splitContainer1.Size = new System.Drawing.Size(1008, 704);
            this.splitContainer1.SplitterDistance = 675;
            this.splitContainer1.TabIndex = 6;
            // 
            // Desktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Desktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "标准下载";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改个人信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toollbl_Account;
        private System.Windows.Forms.ToolStripMenuItem 修改绑定邮箱ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 我的上传ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文件审批ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 树维护ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}