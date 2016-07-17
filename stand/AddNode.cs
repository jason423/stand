using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace stand
{
    public partial class AddNode : Form
    {
        public AddNode()
        {
            InitializeComponent();
        }
        public AddNode(string Name, string Code, string EN_Name, string Remark)
        {
            InitializeComponent();
            this.txt_Name.Text = Name;
            this.txt_Code.Text = Code;
            this.txt_Remark.Text = Remark;
            this.txt_EN_Name.Text = EN_Name;
        }
        public string name
        {
            get { return txt_Name.Text; }
        }
        public string Code
        {
            get { return txt_Code.Text; }
        }
        public string EN_Name
        {
            get { return txt_EN_Name.Text; }
        }
        public string Remark
        {
            get { return txt_Remark.Text; }
        }
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
