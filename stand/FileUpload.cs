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
    public partial class FileUpload : UserControl
    {
        public FileUpload()
        {
            InitializeComponent();
        }

        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                MessageBox.Show(@"请先在树中选择分类", @"提示");
                return;
            }
            if (tree.SelectedNode.FirstNode!= null)
            {
                MessageBox.Show(@"分类树必须选择最底层节点", @"提示");
                return;
            }
            FileInfo fi=new FileInfo();
            if (fi.ShowDialog() == DialogResult.OK)
            {
                string changeName = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1, 10000)+"."+Path.GetExtension(fi.FilePath);
                FTPFileUpDown.UploadFileInFTP(fi.FilePath, "standUploadFile", changeName);
                string sql =
                    @"insert into stand_File(treeId,,StandardNo,YearNo,CN_Name,EN_Name,StandardCode,Remark,FileName,FTPFileName,Point,UploadTime,UploadUser,IsDel,IsVerify) 
                            values(@treeId,,@StandardNo,@YearNo,@CN_Name,@EN_Name,@StandardCode,@Remark,@FileName,@FTPFileName,2,"+DateTime.Now+","+PublicClass.EnDeCode.Decode(Session.Account)+",0,0)";
                SqlHelper.Query(sql,new SqlParameter("@treeId",((DataRow)tree.SelectedNode.Tag)["ID"].ToString()), new SqlParameter("@StandardNo", fi.StandardNo), new SqlParameter("@YearNo", fi.Year), 
                    new SqlParameter("@CN_Name", fi.CNName), new SqlParameter("@EN_Name", fi.EN_Name), 
                    new SqlParameter("@StandardCode", fi.StandardCode), new SqlParameter("@Remark", fi.Remark), 
                    new SqlParameter("@FileName", Path.GetFileName(fi.FilePath)), new SqlParameter("@FTPFileName", changeName));
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (grid_StandardMgr.ActiveRow != null)
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.CheckFileExists = false;
                        sfd.CheckPathExists = true;
                        sfd.Filter = @"所有文件(*.*)|*.*";
                        sfd.FileName = grid_StandardMgr.ActiveRow.Cells["FileName"].Value.ToString();
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            FTPFileUpDown.DownloadFtp(sfd.FileName,"", grid_StandardMgr.ActiveRow.Cells["FTPFileName"].Value.ToString());
                            File.SetAttributes(sfd.FileName, FileAttributes.ReadOnly);
                            MessageBox.Show(@"下载成功", @"提示");

                        }
                        else
                        {
                            MessageBox.Show(@"请选择要下载的对应行", @"提示");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
