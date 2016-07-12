using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace stand
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private int num =-666;
        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(text_UserAccount.Text))
            {
                MessageBox.Show(@"请输入账号!");
                return;
            }
            if (string.IsNullOrWhiteSpace(text_Password.Text))
            {
                MessageBox.Show(@"请输入密码!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Pwd.Text))
            {
                MessageBox.Show(@"请输入确认密码!");
                return;
            }
            if (text_Password.Text!=txt_Pwd.Text)
            {
                MessageBox.Show(@"两次填写的密码不一致,请重新输入!");
                return;
            }
            if (string.IsNullOrWhiteSpace(text_PhoneNumber.Text))
            {
                MessageBox.Show(@"请输入手机号!");
                return;
            }
            if (string.IsNullOrWhiteSpace(text_EMail.Text))
            {
                MessageBox.Show(@"请输入邮箱!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Pin.Text))
            {
                MessageBox.Show(@"请输入验证码!");
                return;
            }
            Regex regexEmail = new Regex(@"[\\w-\\.]+@([\\w-]+\\.)+[a-z]{2,3}");
            if (!regexEmail.IsMatch(text_EMail.Text.Trim()))
            {
                MessageBox.Show(@"请输入正确的邮箱!", @"邮箱错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (num.ToString() != txt_Pin.Text)
            {
                MessageBox.Show(@"验证码错误!");
                return;
            }
            Regex regex = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$");
            if (!regex.IsMatch(text_PhoneNumber.Text.Trim()))
            {
                MessageBox.Show(@"请输入正确的手机号!", @"手机号错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            BLL.stand_User suBll = new BLL.stand_User();
            if (suBll.HasUserByAccount(text_UserAccount.Text))
            {
                MessageBox.Show(@"账号已存在!", @"账号已存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (suBll.HasUserByAccount(text_PhoneNumber.Text))
            {
                MessageBox.Show(@"手机号已存在!", @"手机号已存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Model.stand_User suModel = new Model.stand_User();
            suModel.Account = PublicClass.EnDeCode.Encode(text_UserAccount.Text);
            suModel.Email = text_EMail.Text;
            suModel.Password = PublicClass.EnDeCode.Encode(txt_Pwd.Text);
            suModel.Phone = PublicClass.EnDeCode.Encode(text_PhoneNumber.Text);
            //初始化积分
            suBll.Add(suModel);
            MessageBox.Show(@"注册成功!", @"注册成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(text_EMail.Text))
                {
                    MessageBox.Show(@"请输入邮箱!");
                    return;
                }
                Regex regex = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$");
                if (!regex.IsMatch(text_EMail.Text.Trim()))
                {
                    MessageBox.Show(@"请输入正确的邮箱!", @"邮箱错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }                
                Random rd = new Random();
                num = rd.Next(100000, 1000000);
                string title = "标准";
                string body = num.ToString();

                if (PublicClass.SendEmail.Send(text_EMail.Text, title, body))
                MessageBox.Show(@"验证码已发送至邮箱，请注意查收");
                lbl_notice.Visible = true;
            }
            catch
            {
                MessageBox.Show(@"出错了,请稍后再试");
            }
        }

        private void Register_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.btn_Save_Click(sender, e);//触发按钮事件
            }
        }
    }
}
