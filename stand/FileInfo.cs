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
    public partial class FileInfo : Form
    {
        public FileInfo()
        {
            InitializeComponent();
            DataTable dt = SqlHelper.Query("select max(StandardCode) from stand_File").Tables[0];
            if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
            {
                txt_StandardCode.Text=1.ToString().PadLeft(10, '0');
            }
            else
            {
                txt_StandardCode.Text = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString().PadLeft(10, '0');
            }
            
        }
        public string CNName
        {
            get { return txt_CNName.Text; }
        }
        public string StandardCode
        {
            get { return txt_StandardCode.Text; }
        }
        public string EN_Name
        {
            get { return txt_EnName.Text; }
        }
        public string StandardNo
        {
            get { return txt_StandardNo.Text; }
        }
        public string Year
        {
            get { return txt_Year.Text; }
        }
        public string FilePath
        {
            get { return filepath; }
        }
        public string Remark
        {
            get { return txt_Remark.Text; }
        }
        private string filepath = string.Empty;
        private void btn_Confirm_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(filepath))
            {
                MessageBox.Show(@"请选择一个文件", @"提示");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_File_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = (@"所有文件(*.*)|*.*");
            ofd.ValidateNames = true;
            ofd.CheckFileExists = true;
            ofd.CheckPathExists = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filepath = ofd.FileName;
                lbl_File.Text = ofd.FileName;
            }
        }

    }
}
