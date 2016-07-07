using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using Model;
using PublicClass;

namespace stand
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
        }
        Dictionary<string, User> users = new Dictionary<string, User>();
        private void btn_UserQuit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private string defaultPwd = @"密码";
        private string defaultAccount = @"账号/手机号";
        private void btn_UserLogin_Click(object sender, EventArgs e)
        {
            SaveUserInfo();
            
            if (this.comBox_Account.Text != "")
            {
                if (this.txt_UserPassword.Text != defaultPwd)
                {
                    try
                    {
                        BLL.stand_User userBll = new BLL.stand_User();
                        Model.stand_User userModel= userBll.GetUserByAccountPwd(comBox_Account.Text, txt_UserPassword.Text);
                        if (userModel!=null)
                        {
                            Session.Account = userModel.Account;
                            Session.Email = userModel.Email;
                            Session.Phone = userModel.Phone;
                            Session.Points = userModel.Points;
                            Session.Role = userModel.Role;
                            Session.UserId = userModel.Id;
                            Session.UserName = userModel.UserName;
                            this.Dispose();
                            ChangePwd dk = new ChangePwd();                                              
                            dk.ShowDialog();
                            
                        }
                        else
                        {
                            MessageBox.Show(@"登陆失败！请检查你输入的账号或密码");
                        }
                    }
                    catch
                    {
                        MessageBox.Show(@"登陆失败！请检查你的网络是否通畅");
                    }
                }
                else
                {
                     MessageBox.Show(@"密码不能为空");
                     return;
                }
            }
            else
            {
                MessageBox.Show(@"账号/手机号/邮箱不能为空");
                return;
            }
            
        }

        private void SaveUserInfo()
        {
           
            User user = new User();
            // 登录时 如果没有Data.bin文件就创建、有就打开
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            BinaryFormatter bf = new BinaryFormatter();
            // 保存在实体类属性中
            user.LoginID = PublicClass.EnDeCode.Encode(comBox_Account.Text.Trim());
            //保存密码选中状态
            if (chk_KeepInfo.Checked)
                user.Pwd = PublicClass.EnDeCode.Encode(txt_UserPassword.Text.Trim());
            else
                user.Pwd = PublicClass.EnDeCode.Encode("");
            //选在集合中是否存在用户名 
            if (users.ContainsKey(user.LoginID))
            {
                //如果有清掉
                users.Remove(user.LoginID);
            }
            //添加用户信息到集合
            users.Add(user.LoginID, user);
            //写入文件
            bf.Serialize(fs, users);
            //关闭
            fs.Close();
        }
        private void DisplayUserInfo()
        {

            string key = PublicClass.EnDeCode.Encode(comBox_Account.Text.Trim());
            //查找用户Id
            if (users.ContainsKey(key) == false)
            {               
                txt_UserPassword.PasswordChar = new char();
                txt_UserPassword.ForeColor = Color.Silver;
                txt_UserPassword.Text = defaultPwd;
                return;
            }
            //查找到赋值
            User user = users[key];
            
            if (string.IsNullOrWhiteSpace(PublicClass.EnDeCode.Decode(user.Pwd)))
            {
                SetPwdSilver();
            }
            else
            {
                txt_UserPassword.Text = PublicClass.EnDeCode.Decode(user.Pwd);
                SetPwdBlack();
            }
            // 如有有密码 选中复选框
            chk_KeepInfo.Checked = txt_UserPassword.Text.Trim().Length > 0 ? true : false;
        }

        private void UserLogin_Load(object sender, EventArgs e)
        {
            LoadUserInfo();
        }
        private void LoadUserInfo()
        {
            //读取文件流对象
            FileStream fs = new FileStream("data.bin", FileMode.OpenOrCreate);
            if (fs.Length > 0)
            {
                BinaryFormatter bf = new BinaryFormatter();
                //读出存在Data.bin 里的用户信息
                users = bf.Deserialize(fs) as Dictionary<string, User>;
                //循环添加到Combox1
                foreach (User user in users.Values)
                {
                    comBox_Account.Items.Add(PublicClass.EnDeCode.Decode(user.LoginID));
                }

                //combox1 用户名默认选中第一个
                if (comBox_Account.Items.Count > 0)
                    comBox_Account.SelectedIndex = comBox_Account.Items.Count - 1;
                comBox_Account.ForeColor = Color.Black;
                SetPwdBlack();
            }
            fs.Close();
        }

        private void comBox_Account_TextChanged(object sender, EventArgs e)
        {
            DisplayUserInfo();
        }

        private void comBox_Account_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayUserInfo();
        }

        private void txt_UserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btn_UserLogin.PerformClick();
            }
        }

        private void btn_ChangePwd_Click(object sender, EventArgs e)
        {
            ChangePwd cp = new ChangePwd();
            cp.ShowDialog();
           
            
        }

        private void btn_Reg_Click(object sender, EventArgs e)
        {
            Register re = new Register();
            re.ShowDialog();
        }

        private void txt_UserPassword_Enter(object sender, EventArgs e)
        {
            if (txt_UserPassword.Text== defaultPwd)
            {
                SetPwdBlack();
                txt_UserPassword.Text = "";
            }
        }

        private void txt_UserPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_UserPassword.Text))
            {
                SetPwdSilver();
            }

        }

        private void comBox_Account_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(comBox_Account.Text))
            {
                comBox_Account.ForeColor = Color.Silver;
                comBox_Account.Text = defaultAccount;
            }
        }

        private void comBox_Account_Enter(object sender, EventArgs e)
        {
            if (comBox_Account.Text == defaultAccount)
            {               
                comBox_Account.Text = "";
            }
            comBox_Account.ForeColor = Color.Black;
        }

        private void SetPwdBlack()
        {
            txt_UserPassword.PasswordChar = '*';
            txt_UserPassword.ForeColor = Color.Black;
        }

        private void SetPwdSilver()
        {
            txt_UserPassword.PasswordChar = new char();
            txt_UserPassword.ForeColor = Color.Silver;
            txt_UserPassword.Text = defaultPwd;
        }

        private void UserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//判断回车键
            {
                this.btn_UserLogin_Click(sender, e);//触发按钮事件
            }
        }
    }
}
