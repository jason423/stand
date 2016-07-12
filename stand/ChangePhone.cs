using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BLL;
using PublicClass;

namespace stand
{
    public partial class ChangePhone : Form
    {
        public ChangePhone()
        {
            InitializeComponent();
            txt_PhoneNo.Text =PublicClass.EnDeCode.Decode(Session.Phone);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_PhoneNo.Text))
            {
                MessageBox.Show(@"请填写手机号!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Regex regex = new Regex(@"^(13[0-9]|14[5|7]|15[0|1|2|3|5|6|7|8|9]|18[0|1|2|3|5|6|7|8|9])\d{8}$");
            if (!regex.IsMatch(txt_PhoneNo.Text.Trim()))
            {
                MessageBox.Show(@"请输入正确的手机号!", @"手机号错误", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            BLL.stand_User suBll=new stand_User();
            Model.stand_User suModel = new Model.stand_User();
            suModel=suBll.GetUserByAccount(txt_PhoneNo.Text);
            if (suModel == null)
            {
                suModel = suBll.GetUserByAccount(Session.Account);
                suModel.Phone = PublicClass.EnDeCode.Encode(txt_PhoneNo.Text);
                suBll.Update(suModel);
                MessageBox.Show(@"修改成功!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Dispose();
            }
            else
            {
                MessageBox.Show(@"该手机号已存在!", @"提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
