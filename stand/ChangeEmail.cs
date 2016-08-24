using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using PublicClass;

namespace stand
{
    public partial class ChangeEmail : Form
    {
        public ChangeEmail()
        {
            InitializeComponent();
        }

        private int _OldNum = -666;
        private int _NewNum = -888;
        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_Email.Text) || string.IsNullOrWhiteSpace(txt_NewPin.Text) ||
                string.IsNullOrWhiteSpace(txt_OldPin.Text))
            {
                MessageBox.Show(@"请将信息填写完整");
                return;
            }
            Regex regex = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$");
            if (!regex.IsMatch(txt_Email.Text.Trim()))
            {
                MessageBox.Show(@"请输入正确的邮箱!", @"邮箱错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (txt_OldPin.Text != _OldNum.ToString())
            {
                MessageBox.Show(@"原邮箱验证码错误");
                return;
            }
            if (txt_NewPin.Text != _NewNum.ToString())
            {
                MessageBox.Show(@"新邮箱验证码错误");
                return;
            }
            BLL.stand_User suBll = new stand_User();
            Model.stand_User suModel = new Model.stand_User();
            suModel = suBll.GetUserByAccount(Session.Account);
            suModel.Email = PublicClass.EnDeCode.Encode(txt_Email.Text);
            suBll.Update(suModel);
            MessageBox.Show(@"修改成功!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Dispose();
        }

        private void btn_OldPin_Click(object sender, EventArgs e)
        {
            try
            {                
                Random rd = new Random();
                _OldNum = rd.Next(100000, 1000000);
                string title = "标准";
                string body = _OldNum.ToString();

                if (PublicClass.SendEmail.Send(Session.Email, title, body))
                    MessageBox.Show(@"验证码已发送至原始邮箱，请注意查收");
            }
            catch
            {
                MessageBox.Show(@"出错了,请稍后再试");
            }
        }

        private void btn_NewPin_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txt_Email.Text))
                {
                    MessageBox.Show(@"请输入邮箱!");
                    return;
                }
                if (
                SqlHelper.Query("select * from stand_User where Email=@Email",
                    new SqlParameter("@Email", txt_Email.Text)).Tables[0].Rows.Count > 0)
                {
                    MessageBox.Show(@"该邮箱已被注册!", @"邮箱已注册", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Regex regex = new Regex(@"^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$");
                if (!regex.IsMatch(txt_Email.Text.Trim()))
                {
                    MessageBox.Show(@"请输入正确的邮箱!", @"邮箱错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                Random rd = new Random();
                _NewNum = rd.Next(100000, 1000000);
                string title = "标准";
                string body = _NewNum.ToString();

                if (PublicClass.SendEmail.Send(txt_Email.Text, title, body))
                    MessageBox.Show(@"验证码已发送至新邮箱，请注意查收");
            }
            catch
            {
                MessageBox.Show(@"出错了,请稍后再试");
            }
        }
    }
}
