using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
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
            txt_Account.Text = PublicClass.EnDeCode.Decode(account);
            txt_Account.ReadOnly = true;
            this.ActiveControl = txt_OldPwd;
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (txt_Account.Text == "" || txt_ConfirmNewPwd.Text == "" || txt_NewPwd.Text == "" || txt_OldPwd.Text == "")
            {
                MessageBox.Show("请将信息填写完整", "提示");
                return;
            }

            try
            {
                BLL.stand_User suBll = new stand_User();
                Model.stand_User suModel = suBll.GetUserByAccountPwd(txt_Account.Text, txt_OldPwd.Text);
                if (suModel == null)
                {
                    MessageBox.Show("账号或密码错误", "提示");
                    return;
                }
                if (txt_NewPwd.Text.Equals(txt_ConfirmNewPwd.Text))
                {
                    suModel.Password = PublicClass.EnDeCode.Encode(txt_NewPwd.Text);
                    suBll.Update(suModel);
                    MessageBox.Show(@"密码修改成功,请重新登录",@"提示");
                    Application.Restart();

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
            Dispose();
        }

        private void chk_ShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ShowPwd.Checked == true)
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
