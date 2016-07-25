using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace stand
{
    public partial class MyFiles : UserControl
    {
        public MyFiles()
        {
            InitializeComponent();
            InitData();
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {

                try
                {

                    SaveFileDialog sfd = new SaveFileDialog();
                    sfd.CheckFileExists = false;
                    sfd.CheckPathExists = true;
                    sfd.Filter = @"所有文件(*.*)|*.*";
                    sfd.FileName = grid_StandardMgr.ActiveRow.Cells["FileName"].Value.ToString();
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        FTPFileUpDown.DownloadFtp(sfd.FileName, "standUploadFile",
                            grid_StandardMgr.ActiveRow.Cells["FTPFileName"].Value.ToString());
                        File.SetAttributes(sfd.FileName, FileAttributes.ReadOnly);
                        MessageBox.Show(@"下载成功", @"提示");

                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show(@"请选择要下载的对应行", @"提示");
            }
        }
        private void InitData()
        {
            DataTable dt = SqlHelper.Query(@"select *,b.Code as ClassifyThree,b.PID,null as ClassifyOne ,null as ClassifyTwo from stand_File a left join stand_Tree b on a.treeId=b.ID where UploadUser=@UploadUser",new SqlParameter("@UploadUser",PublicClass.EnDeCode.Encode(Session.Account))).Tables[0];
            grid_StandardMgr.DataSource = dt;
        }
    }
}
