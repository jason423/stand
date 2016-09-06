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
            tree.SelectedNode = null;
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
            DataTable dt = SqlHelper.Query(@"select a.[Id],a.[treeId],a.[StandardNo],a.[YearNo],a.[CN_Name],a.[EN_Name],cast(a.standardcode AS varchar(max))as standardcode,a.[Remark],a.[FileName]
,a.[FTPFileName],a.[Point],a.[UploadTime],a.[UploadUser],a.[IsDel],a.[IsVerify],b.Code as ClassifyThree,b.PID,c.Account from stand_File a left join stand_Tree b on a.treeId=b.ID left join stand_User c on a.UploadUser=c.Id where a.IsDel=0 and a.IsVerify=1").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["StandardCode"] = dt.Rows[i]["StandardCode"].ToString().PadLeft(10, '0');
                dt.Rows[i]["Account"] = PublicClass.EnDeCode.Decode(dt.Rows[i]["Account"].ToString());
            }

            PublicClass.TreeMethod.GetCodeByTreeId(dt);
            dt.AcceptChanges();

            grid_StandardMgr.DataSource = dt;

        }
        private void btn_upload_Click(object sender, EventArgs e)
        {
            try
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
                    foreach (string path in fi.FilePath)
                    {
                        string changeName = DateTime.Now.ToString("yyyyMMddHHmmss") + new Random().Next(1, 10000) +Guid.NewGuid().ToString().Substring(0,4)+ Path.GetExtension(path);
                        string standardCode = string.Empty;
                        FTPFileUpDown.UploadFileInFTP(path, "standUploadFile", changeName);
                        DataTable dt = SqlHelper.Query("select max(StandardCode) from stand_File").Tables[0];
                        if (string.IsNullOrEmpty(dt.Rows[0][0].ToString()))
                        {
                            standardCode = "1";
                        }
                        else
                        {
                            standardCode = (int.Parse(dt.Rows[0][0].ToString()) + 1).ToString();
                        }

                        string sql =
                        @"insert into stand_File(treeId,StandardNo,YearNo,CN_Name,EN_Name,StandardCode,Remark,FileName,FTPFileName,Point,UploadTime,UploadUser,IsDel,IsVerify) 
                            values(@treeId,@StandardNo,@YearNo,@CN_Name,@EN_Name,@StandardCode,@Remark,@FileName,@FTPFileName,2,'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "'," + Session.UserId + ",0,0)";
                        SqlHelper.Query(sql, new SqlParameter("@treeId", ((DataRow)tree.SelectedNode.Tag)["ID"].ToString()), new SqlParameter("@StandardNo", fi.StandardNo), new SqlParameter("@YearNo", fi.Year),
                            new SqlParameter("@CN_Name", fi.CNName), new SqlParameter("@EN_Name", fi.EN_Name),
                            new SqlParameter("@StandardCode", standardCode), new SqlParameter("@Remark", fi.Remark),
                            new SqlParameter("@FileName", Path.GetFileName(path)), new SqlParameter("@FTPFileName", changeName));
                    }
                    
                    MessageBox.Show(@"上传成功,请等待审核通过", @"提示");

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btn_download_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {
                try
                {
                    DataTable dt = SqlHelper.Query("select * from stand_UserDowload where FIleID=@FIleID and UserID=@UserID", new SqlParameter("@FIleID", grid_StandardMgr.ActiveRow.Cells["Id"].Value)
                        , new SqlParameter("@UserID", Session.UserId)).Tables[0];
                    if (dt.Rows.Count > 0)
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
                    else
                    {
                        if (Session.Points < int.Parse(grid_StandardMgr.ActiveRow.Cells["Point"].Value.ToString()))
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
            
        }

        private void selectChildId(ref string forS, string PID)
        {
            DataRow[] drs = Tree.Select("PID='" + PID + "'");
            for (int i = 0; i < drs.Length; i++)
            {
                forS += drs[i]["Id"] + ",";
                selectChildId(ref forS, drs[i]["Id"].ToString());
            }
        }
    }
}
