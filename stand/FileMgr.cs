using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace stand
{
    public partial class FileMgr : UserControl
    {
        public FileMgr()
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

                string sql = string.Format("PID='{0}'", ((DataRow)Root.Tag)["ID"]);
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
                        TreeNode child = Root.Nodes.Add(dr["Code"] + "-" + dr["Name"]);
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
,a.[FTPFileName],a.[Point],a.[UploadTime],a.[UploadUser],a.[IsDel],a.[IsVerify],b.Code as ClassifyThree,b.PID,c.Account from stand_File a left join stand_Tree b on a.treeId=b.ID left join stand_User c on a.UploadUser=c.Id where a.IsDel=0").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["StandardCode"] = dt.Rows[i]["StandardCode"].ToString().PadLeft(10, '0');
                dt.Rows[i]["Account"] = EnDeCode.Decode(dt.Rows[i]["Account"].ToString());
            }

            TreeMethod.GetCodeByTreeId(dt);
            dt.AcceptChanges();

            grid_StandardMgr.DataSource = dt;

        }
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {
                FileEdit fe=new FileEdit(grid_StandardMgr.ActiveRow);
                fe.ShowDialog();
                InitTable();
            }
            else
            {
                MessageBox.Show(@"请选择要编辑的行", @"提示");
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {
                if (MessageBox.Show(@"确定删除?",@"警告",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlHelper.Query("delete from stand_File where Id ='"+ grid_StandardMgr.ActiveRow.Cells["Id"].Value+ "'");
                    if (FTPFileUpDown.FTPFileCheckExist("standUploadFile",
                        grid_StandardMgr.ActiveRow.Cells["FTPFileName"].Value.ToString()))
                    {
                        FTPFileUpDown.FTPDeleteFileName(grid_StandardMgr.ActiveRow.Cells["FTPFileName"].Value.ToString(), "standUploadFile");
                    }
                    MessageBox.Show(@"删除成功", @"提示");
                    InitTable();
                }
            }
            else
            {
                MessageBox.Show(@"请选择要删除的对应行", @"提示");
            }
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
