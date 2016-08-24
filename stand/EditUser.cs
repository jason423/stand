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
using Model;
using PublicClass;

namespace stand
{
    public partial class EditUser : Form
    {
        public EditUser()
        {
            InitializeComponent();
            
        }

        private stand_User _modelUser = null;
        public EditUser(Model.stand_User modelStandUser)
        {
            InitializeComponent();
            if (modelStandUser == null) return;
            Name = "编辑用户";
            txt_Point.Text = modelStandUser.Points.ToString();
            text_EMail.Text = modelStandUser.Email;
            text_Password.Text = PublicClass.EnDeCode.Decode(modelStandUser.Password);
            text_UserAccount.Text = PublicClass.EnDeCode.Decode(modelStandUser.Account);
            comb_Role.Text = modelStandUser.Role == "1" ? @"管理员" : @"用户";
            text_PhoneNumber.Text= PublicClass.EnDeCode.Decode(modelStandUser.Phone);
            _modelUser = modelStandUser;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (
                SqlHelper.Query("select * from stand_User where Email=@Email",
                    new SqlParameter("@Email", text_EMail.Text)).Tables[0].Rows.Count > 0)
            {
                MessageBox.Show(@"该邮箱已被注册!", @"邮箱已注册", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Dispose();
        }

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
            if (string.IsNullOrWhiteSpace(comb_Role.Text))
            {
                MessageBox.Show(@"请选择角色!");
                return;
            }
            if (string.IsNullOrWhiteSpace(txt_Point.Text))
            {
                MessageBox.Show(@"请输入积分!");
                return;
            }
            Regex regexEmail = new Regex("[\\w-\\.]+@([\\w-]+\\.)+[a-z]{2,3}");
            if (!regexEmail.IsMatch(text_EMail.Text.Trim()))
            {
                MessageBox.Show(@"请输入正确的邮箱!", @"邮箱错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            Regex regex = new Regex(@"^1[3|4|5|7|8]\d{9}$");
            if (!regex.IsMatch(text_PhoneNumber.Text.Trim()))
            {
                MessageBox.Show(@"请输入正确的手机号!", @"手机号错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
            BLL.stand_User bllUser=new BLL.stand_User();
            if (_modelUser != null)
            {
                if (PublicClass.EnDeCode.Encode(text_UserAccount.Text)!=_modelUser.Account)
                {
                    if (bllUser.HasUserByAccount(text_UserAccount.Text))
                    {
                        MessageBox.Show(@"账号已存在!", @"账号已存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                if (PublicClass.EnDeCode.Encode(text_PhoneNumber.Text) != _modelUser.Phone)
                {
                    if (bllUser.HasUserByAccount(text_PhoneNumber.Text))
                    {
                        MessageBox.Show(@"手机号已存在!", @"手机号已存在", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                _modelUser.Phone = PublicClass.EnDeCode.Encode(text_PhoneNumber.Text);
                _modelUser.Account = PublicClass.EnDeCode.Encode(text_UserAccount.Text);
                _modelUser.Password = PublicClass.EnDeCode.Encode(text_Password.Text);
                _modelUser.Email = text_EMail.Text;
                _modelUser.Points = Int32.Parse(txt_Point.Text);
                _modelUser.Role = (comb_Role.Text == @"管理员" ? "1" : "2");
                bllUser.Update(_modelUser);
                MessageBox.Show(@"编辑成功!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dispose();
            }
            else
            {
                _modelUser=new stand_User();
                _modelUser.Phone = PublicClass.EnDeCode.Encode(text_PhoneNumber.Text);
                _modelUser.Account = PublicClass.EnDeCode.Encode(text_UserAccount.Text);
                _modelUser.Password = PublicClass.EnDeCode.Encode(text_Password.Text);
                _modelUser.Email = text_EMail.Text;
                _modelUser.Points = Int32.Parse(txt_Point.Text);
                _modelUser.Role = (comb_Role.Text==@"管理员" ? "1" : "2");
                bllUser.Add(_modelUser);
                MessageBox.Show(@"新增成功!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dispose();
            }
        }

        private void txt_Point_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
