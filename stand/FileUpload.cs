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
using BLL;
using PublicClass;

namespace stand
{
    public partial class FileUpload : UserControl
    {
        public FileUpload()
        {
            InitializeComponent();
            InitTreeData();
            InitTable();
        }
        public static DataTable Tree;
        public void InitTreeData()
        {
            try
            {
                string sql = string.Format(@"select * from stand_Tree order by Code,Name");
                Tree = SqlHelper.Query(sql).Tables[0];

                DataRow[] rows = Tree.Select("PID is null", "Code,Name");
                foreach (DataRow dr in rows)
                {

                    TreeNode root = this.tree.Nodes.Add(dr["Code"].ToString() + "-" + dr["Name"].ToString());
                    root.Tag = dr;
                    GetChildNode(root);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //递归获取所有子节点
        public void GetChildNode(TreeNode Root)
        {
            try
            {

                string sql = string.Format("PID='{0}'", ((DataRow)Root.Tag)["ID"].ToString());
                DataRow[] rows = Tree.Select(sql, "Code,Name asc");

                foreach (DataRow dr in rows)
                {
                    if (dr["Code"].ToString() == "")
                    {
                        TreeNode child = Root.Nodes.Add(dr["Name"].ToString());
                        child.Tag = dr;
                        GetChildNode(child);
                    }
                    else
                    {
                        TreeNode child = Root.Nodes.Add(dr["Code"].ToString() + "-" + dr["Name"].ToString());
                        child.Tag = dr;
                        GetChildNode(child);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void InitTable()
        {
            DataTable dt = SqlHelper.Query(@"select *,b.Code as ClassifyThree,b.PID,null as ClassifyOne ,null as ClassifyTwo from stand_File a left join stand_Tree b on a.treeId=b.ID where a.IsDel=0 and a.IsVerify=1").Tables[0];
            grid_StandardMgr.DataSource = dt;

        }
        private void btn_upload_Click(object sender, EventArgs e)
        {
            if (tree.SelectedNode == null)
            {
                MessageBox.Show(@"请先在树中选择分类", @"提示");
                return;
            }
            if (tree.SelectedNode.FirstNode != null)
            {
                MessageBox.Show(@"分类树必须选择最底层节点", @"提示");
                return;
            }
            FileInfo fi = new FileInfo();
            if (fi.ShowDialog() == DialogResult.OK)
            {
                string changeName = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1, 10000) + "." + Path.GetExtension(fi.FilePath);
                FTPFileUpDown.UploadFileInFTP(fi.FilePath, "standUploadFile", changeName);
                string sql =
                    @"insert into stand_File(treeId,,StandardNo,YearNo,CN_Name,EN_Name,StandardCode,Remark,FileName,FTPFileName,Point,UploadTime,UploadUser,IsDel,IsVerify) 
                            values(@treeId,,@StandardNo,@YearNo,@CN_Name,@EN_Name,@StandardCode,@Remark,@FileName,@FTPFileName,2," + DateTime.Now + "," + PublicClass.EnDeCode.Decode(Session.Account) + ",0,0)";
                SqlHelper.Query(sql, new SqlParameter("@treeId", ((DataRow)tree.SelectedNode.Tag)["ID"].ToString()), new SqlParameter("@StandardNo", fi.StandardNo), new SqlParameter("@YearNo", fi.Year),
                    new SqlParameter("@CN_Name", fi.CNName), new SqlParameter("@EN_Name", fi.EN_Name),
                    new SqlParameter("@StandardCode", fi.StandardCode), new SqlParameter("@Remark", fi.Remark),
                    new SqlParameter("@FileName", Path.GetFileName(fi.FilePath)), new SqlParameter("@FTPFileName", changeName));
                MessageBox.Show(@"上传成功,请等待审核通过", @"提示");
                BLL.stand_User suBll = new stand_User();
                Model.stand_User suModel = suBll.GetModel(Session.UserId);
                suModel.Points += 2;
                suBll.Update(suModel);
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {
                try
                {
                    if (Session.Points < int.Parse(grid_StandardMgr.ActiveRow.Cells["Points"].ToString()))
                    {
                        MessageBox.Show(@"分数不够,请上传文件获取分数", @"提示");
                    }
                    else
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
                            BLL.stand_User suBll = new stand_User();
                            Model.stand_User suModel = suBll.GetModel(Session.UserId);
                            suModel.Points -= 2;
                            suBll.Update(suModel);
                        }

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

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree.SelectedNode != null)
            {
                if (tree.SelectedNode.FirstNode==null)
                {
                    DataTable dt = SqlHelper.Query(@"select *,b.Code as ClassifyThree,b.PID,null as ClassifyOne ,null as ClassifyTwo from stand_File a left join stand_Tree b on a.treeId=b.ID where a.IsDel=0 and a.IsVerify=1 and treeId=@treeId",new SqlParameter("@treeId",((DataRow)tree.SelectedNode.Tag)["Id"])).Tables[0];
                    grid_StandardMgr.DataSource = dt;
                }
            }
        }
    }
}
