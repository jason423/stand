using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace stand
{
    public partial class Desktop : Form
    {
        public Desktop()
        {
            InitializeComponent();
            toollbl_Account.Text = @"当前登录账号:"+PublicClass.EnDeCode.Decode(Session.Account);
            if (Session.Role == "1")
            {
                系统菜单ToolStripMenuItem.Visible = true;
            }
            FileUpload fu = new FileUpload();
            fu.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Add(fu);
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePwd cp=new ChangePwd(Session.Account);
            cp.ShowDialog();
        }

        private void 修改个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePhone cp=new ChangePhone();
            cp.ShowDialog();
        }

        private void 修改绑定邮箱ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeEmail ce=new ChangeEmail();
            ce.ShowDialog();
        }

        private void 树维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            TreeMgr tree = new TreeMgr();
            tree.Dock = DockStyle.Fill;

            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(tree);
        }

        private void 我的上传ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyFiles mf=new MyFiles();
            mf.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(mf);
        }

        private void 文件审批ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileVerify fv = new FileVerify();
            fv.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(fv);
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserMgr um = new UserMgr();
            um.Dock = DockStyle.Fill;
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(um);
        }

        private void 首页ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileUpload fu = new FileUpload {Dock = DockStyle.Fill};
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(fu);

        }

        private void 文件管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileMgr fm = new FileMgr { Dock = DockStyle.Fill };
            this.splitContainer1.Panel1.Controls.Clear();
            this.splitContainer1.Panel1.Controls.Add(fm);
        }
    }
}
