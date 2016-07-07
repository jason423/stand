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
    public partial class ChangePwd : Form
    {
        public ChangePwd()
        {
            InitializeComponent();
        }
        public ChangePwd(string account)
        {
            InitializeComponent();
            txt_Account.Text = account;
            txt_Account.ReadOnly = true;
            this.ActiveControl = txt_OldPwd;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if(txt_Account.Text==""||txt_ConfirmNewPwd.Text==""||txt_NewPwd.Text==""||txt_OldPwd.Text=="")
            {
                MessageBox.Show("请将信息填写完整", "提示");
                return;
            }
            
            try
            {
                string sql = string.Format(@"select * from MDM_usertable where ACCOUNT='{0}'", txt_Account.Text);
                DataTable dt = SqlHelper.Query(sql).Tables[0];
                if(dt.Rows.Count==0)
                {
                    MessageBox.Show("账号不存在", "提示");
                    txt_Account.Clear();
                    return;
                }
                if (txt_NewPwd.Text.Equals(txt_ConfirmNewPwd.Text))
                {
                    if (txt_OldPwd.Text.Equals(dt.Rows[0]["PASSWORD"].ToString())) 
                    {
                        //string sqlUpdata = string.Format(@"update MDM_usertable set PASSWORD='{0}' where ACCOUNT='{1}'", txt_NewPwd.Text, txt_Account.Text);
                        //SqlHelper.ExecuteScalar(sqlUpdata);
                        //MessageBox.Show("密码修改成功,请重新登录", "提示");
                        //Application.Restart();
                    }
                    else
                    {
                        MessageBox.Show("原始密码错误,请重新输入","提示");
                        txt_OldPwd.Clear();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("两次输入的新密码不同，请重新输入", "提示");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void chk_ShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if(chk_ShowPwd.Checked==true)
            {
                txt_ConfirmNewPwd.PasswordChar = '\0';
                txt_NewPwd.PasswordChar = '\0';
                txt_OldPwd.PasswordChar = '\0';
            }
            else
            {
                txt_ConfirmNewPwd.PasswordChar = '*';
                txt_NewPwd.PasswordChar = '*';
                txt_OldPwd.PasswordChar = '*';
            }
        }

        private void ChangePwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.btn_Confirm_Click(sender, e);//触发按钮事件
            }
        }
    }
}
