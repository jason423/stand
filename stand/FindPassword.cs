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
    public partial class FindPassword : Form
    {
        public FindPassword()
        {
            InitializeComponent();
        }
        public FindPassword(string account)
        {
            InitializeComponent();
            txt_Account.Text = PublicClass.EnDeCode.Decode(account);
            txt_Account.ReadOnly = true;
            this.ActiveControl = txt_Pin;
        }
        private int _num = -666;
        
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Account.Text)|| string.IsNullOrWhiteSpace(txt_ConfirmNewPwd.Text) || string.IsNullOrWhiteSpace(txt_NewPwd.Text) || string.IsNullOrWhiteSpace(txt_Pin.Text))
            {
                MessageBox.Show(@"请将信息填写完整", @"提示");
                return;
            }
            if (txt_Pin.Text != _num.ToString())
            {
                MessageBox.Show(@"验证码错误!", @"提示");
                return;
            }
            if (txt_NewPwd.Text.Equals(txt_ConfirmNewPwd.Text))
            {
                BLL.stand_User suBll = new stand_User();
                Model.stand_User suModel = new Model.stand_User();
                suModel = suBll.GetUserByAccount(txt_Account.Text);
                suModel.Password = PublicClass.EnDeCode.Encode(txt_NewPwd.Text);
                suBll.Update(suModel);
                if (string.IsNullOrWhiteSpace(Session.Account))
                {
                    MessageBox.Show(@"密码修改成功", @"提示");
                    Dispose();
                }
                else
                {
                    MessageBox.Show(@"密码修改成功,请重新登录", @"提示");
                    Application.Restart();
                }

            }
            else
            {
                MessageBox.Show(@"两次输入的新密码不同，请重新输入",@"提示");
                return;
            }
        }
        private void chk_ShowPwd_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_ShowPwd.Checked == true)
            {
                txt_ConfirmNewPwd.PasswordChar = '\0';
                txt_NewPwd.PasswordChar = '\0';
                txt_Pin.PasswordChar = '\0';
            }
            else
            {
                txt_ConfirmNewPwd.PasswordChar = '*';
                txt_NewPwd.PasswordChar = '*';
                txt_Pin.PasswordChar = '*';
            }
        }

        private void FindPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.btn_Confirm_Click(sender, e);//触发按钮事件
            }
        }

        

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btn_GetPin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Account.Text))
                {
                    MessageBox.Show(@"请输入账号!");
                    return;
                }
                Random rd = new Random();
                _num = rd.Next(100000, 1000000);
                string title = "标准";
                string body = _num.ToString();
                BLL.stand_User suBll = new stand_User();
                Model.stand_User suModel = new Model.stand_User();
                suModel = suBll.GetUserByAccount(txt_Account.Text);
                if(suModel== null)
                {
                    MessageBox.Show(@"账号不存在!");
                    return;;
                }
                else
                {
                    if (PublicClass.SendEmail.Send(suModel.Email, title, body))
                    {
                        MessageBox.Show(@"验证码已发送至邮箱，请注意查收");
                        lbl_Notice.Visible = true;
                    }
                }
                
            }
            catch
            {
                MessageBox.Show(@"出错了,请稍后再试");
            }
        }
    }
}
