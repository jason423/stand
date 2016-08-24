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
            try
            {
                DataTable dt =
                    SqlHelper.Query(
                        @"select a.[Id],a.[treeId],a.[StandardNo],a.[YearNo],a.[CN_Name],a.[EN_Name],cast(a.standardcode AS varchar(max))as standardcode,a.[Remark],a.[FileName]
,a.[FTPFileName],a.[Point],a.[UploadTime],a.[UploadUser],a.[IsDel],a.[IsVerify],b.Code as ClassifyThree,b.PID,(case Isverify when 0 then '未审批' when 1 then '审批通过' when 2 then '审批未通过' end) as verify from stand_File a left join stand_Tree b on a.treeId=b.ID where UploadUser=@UploadUser",
                        new SqlParameter("@UploadUser", Session.UserId)).Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["StandardCode"] = dt.Rows[i]["StandardCode"].ToString().PadLeft(10, '0');

                }
                PublicClass.TreeMethod.GetCodeByTreeId(dt);
                grid_StandardMgr.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
