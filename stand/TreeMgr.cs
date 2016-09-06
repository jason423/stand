using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PublicClass;

namespace stand
{
    public partial class TreeMgr : UserControl
    {
        public TreeMgr()
        {
            InitializeComponent();
            InitTreeData();
            LockTree();

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

                    TreeNode root = this.tree_GeneralPart.Nodes.Add(dr["Code"].ToString() + "-" + dr["Name"].ToString());
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


        private void 添加节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node;
            if (tree_GeneralPart.SelectedNode == null)
            {
                node = tree_GeneralPart.Nodes.Add("请输入节点名称");

            }
            else
            {
                node = tree_GeneralPart.SelectedNode.Nodes.Add("请输入节点名称");


            }
            tree_GeneralPart.SelectedNode = node;
            AddNode an = new AddNode();
            an.ShowDialog();
            if (an.DialogResult == DialogResult.OK)
            {
                txt_Name.Text = an.name;
                txt_Code.Text = an.Code;
                txt_EN_Name.Text = an.EN_Name;
                txt_Remark.Text = an.Remark;
                an.Dispose();
                if (txt_Code.Text == "")
                {
                    tree_GeneralPart.SelectedNode.Text = txt_Name.Text;
                }
                else
                {
                    tree_GeneralPart.SelectedNode.Text = txt_Code.Text + "-" + txt_Name.Text;
                }
                if (node.Parent == null)
                {
                    try
                    {
                        //将无父节点的节点信息存入数据库并保存节点Tag值
                        string sqlAddNewNode = string.Format(@"insert into stand_Tree(Name,Code,EN_Name,Remark) values ('{0}','{1}','{2}','{3}') select @@identity", txt_Name.Text, txt_Code.Text, txt_EN_Name.Text, txt_Remark.Text);
                        //插入数据并拿出刚插入的数据的ID
                        object newID = SqlHelper.Query(sqlAddNewNode).Tables[0].Rows[0][0];
                        string sqlNewNode = string.Format("select * from stand_Tree where ID='{0}'", newID);
                        DataRow newNode = SqlHelper.Query(sqlNewNode).Tables[0].Rows[0];
                        node.Tag = newNode;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        //将有父节点的节点信息存入数据库并保存节点Tag值
                        string sqlAddNewNode = string.Format(@"insert into stand_Tree(Name,PID,Code,EN_Name,Remark) values ('{0}','{1}','{2}','{3}','{4}') select @@identity", txt_Name.Text,
                            ((DataRow)node.Parent.Tag)["ID"], txt_Code.Text, txt_EN_Name.Text, txt_Remark.Text);
                        //插入数据并拿出刚插入的数据的ID
                        object newID = SqlHelper.Query(sqlAddNewNode).Tables[0].Rows[0][0];
                        string sqlNewNode = string.Format(@"select * from stand_Tree where ID='{0}'", newID);
                        DataRow newNode = SqlHelper.Query(sqlNewNode).Tables[0].Rows[0];
                        node.Tag = newNode;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                tree_GeneralPart.SelectedNode.Remove();
            }
        }

        private void 编辑节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree_GeneralPart.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点", "提示");
            }
            else
            {
                AddNode an = new AddNode(((DataRow)tree_GeneralPart.SelectedNode.Tag)["Name"].ToString(),
                    ((DataRow)tree_GeneralPart.SelectedNode.Tag)["Code"].ToString(), ((DataRow)tree_GeneralPart.SelectedNode.Tag)["EN_Name"].ToString(), ((DataRow)tree_GeneralPart.SelectedNode.Tag)["Remark"].ToString());
                an.ShowDialog();
                if (an.DialogResult == DialogResult.OK)
                {
                    txt_Name.Text = an.name;
                    txt_Code.Text = an.Code;
                    txt_EN_Name.Text = an.EN_Name;
                    txt_Remark.Text = an.Remark;
                    an.Dispose();
                    if (txt_Code.Text == "")
                    {
                        tree_GeneralPart.SelectedNode.Text = txt_Name.Text;
                    }
                    else
                    {
                        tree_GeneralPart.SelectedNode.Text = txt_Code.Text + "-" + txt_Name.Text;
                    }
                    try
                    {
                        string sqlEditNode = string.Format(@"update stand_Tree set Name='{0}',Code='{1}',EN_Name='{2}',Remark='{3}' where ID='{4}' ", txt_Name.Text, txt_Code.Text, txt_EN_Name.Text, txt_Remark.Text, ((DataRow)tree_GeneralPart.SelectedNode.Tag)["ID"].ToString());
                        SqlHelper.Query(sqlEditNode);
                        string sqlNewTag = string.Format(@"select * from stand_Tree where ID='{0}'", ((DataRow)tree_GeneralPart.SelectedNode.Tag)["ID"].ToString());
                        DataRow editNode = SqlHelper.Query(sqlNewTag).Tables[0].Rows[0];
                        tree_GeneralPart.SelectedNode.Tag = editNode;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void 删除节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tree_GeneralPart.SelectedNode == null)
            {
                MessageBox.Show("请选择一个节点", "提示");
            }
            else
            {
                if (MessageBox.Show("是否确认删除！", "警告！", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {

                    if (tree_GeneralPart.SelectedNode.Tag == null)
                    {
                        tree_GeneralPart.SelectedNode.Remove();
                    }
                    else
                    {
                        try
                        {
                            string sqlDeleteNode = string.Format(@"delete from stand_Tree where ID ='{0}'", (((DataRow)tree_GeneralPart.SelectedNode.Tag)["ID"]).ToString());
                            SqlHelper.Query(sqlDeleteNode);
                            DeleteChildNode(int.Parse(((DataRow)tree_GeneralPart.SelectedNode.Tag)["ID"].ToString()));
                            tree_GeneralPart.SelectedNode.Remove();
                            MessageBox.Show("删除成功！", "提示！");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }
        //遍历删除数据库中的选中节点子节点信息
        public void DeleteChildNode(int DeletNodeID)
        {
            try
            {
                string deleteNode = string.Format(@"select * from stand_Tree where PID='{0}'", DeletNodeID);
                DataTable dt = SqlHelper.Query(deleteNode).Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    string sqlDeleteChild = string.Format(@"delete from stand_Tree where ID='{0}'", dr["ID"].ToString());
                    SqlHelper.Query(sqlDeleteChild);
                    DeleteChildNode(int.Parse(dr["ID"].ToString()));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tree_GeneralPart_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeNode tnSelect = tree_GeneralPart.GetNodeAt(new Point(e.X, e.Y));
                this.tree_GeneralPart.SelectedNode = this.tree_GeneralPart.GetNodeAt(new Point(e.X, e.Y));
                contextMenuStrip1.Show(this, new Point(e.X, e.Y));
            }
        }
        /// <summary>
        /// 用于锁定树编辑功能
        /// </summary>
        public void LockTree()
        {
            this.编辑节点ToolStripMenuItem.Enabled = false;
            this.添加节点ToolStripMenuItem.Enabled = false;
            this.删除节点ToolStripMenuItem.Enabled = false;
            this.导入树ToolStripMenuItem.Enabled = false;
            this.btn_setTree.Text = "编辑树";

        }

        public void UnLockTree()
        {
            this.编辑节点ToolStripMenuItem.Enabled = true;
            this.添加节点ToolStripMenuItem.Enabled = true;
            this.删除节点ToolStripMenuItem.Enabled = true;
            this.导入树ToolStripMenuItem.Enabled = true;
            this.btn_setTree.Text = "锁定树";
        }
        private void btn_setTree_Click(object sender, EventArgs e)
        {
            if (this.btn_setTree.Text == "编辑树")
            {
                UnLockTree();
            }
            else
            {
                LockTree();
            }
        }

        private void tree_GeneralPart_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tree_GeneralPart.SelectedNode.Tag == null)
            {

            }
            else
            {
                txt_Code.Text = ((DataRow)tree_GeneralPart.SelectedNode.Tag)["Code"].ToString();
                txt_EN_Name.Text = ((DataRow)tree_GeneralPart.SelectedNode.Tag)["EN_Name"].ToString();
                txt_Name.Text = ((DataRow)tree_GeneralPart.SelectedNode.Tag)["Name"].ToString();
                txt_Remark.Text = ((DataRow)tree_GeneralPart.SelectedNode.Tag)["Remark"].ToString();
            }
        }

        private void 导入树ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Excel文件";
                ofd.FileName = "";
                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                ofd.Filter = "Excel文件(*.xls,*.xlsx)|*.xls;*.xlsx";
                ofd.ValidateNames = true;
                ofd.CheckFileExists = true;
                ofd.CheckPathExists = true;
                string strName = string.Empty;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ExcelHelper eh=new ExcelHelper(ofd.FileName);
                    DataTable dt = eh.ExcelToDataTable("stand", true);
                    DataRow[] pRows = dt.Select("PID is null or PID=''");
                    if (pRows.Length > 0)
                    {
                        foreach (DataRow dr in pRows)
                        {
                            string sqlAddNewNode =
                                string.Format(
                                    @"insert into stand_Tree(Name,Code,EN_Name,Remark) values (@Name,@Code,@EN_Name,@Remark) ;select @@identity");
                            //插入数据并拿出刚插入的数据的ID
                            object newID = SqlHelper.Query(sqlAddNewNode, new SqlParameter("@Name", dr["Name"]),
                        new SqlParameter("@Code", dr["Code"]), new SqlParameter("@EN_Name", dr["EN_Name"]),
                        new SqlParameter("@Remark", dr["Remark"])).Tables[0].Rows[0][0];
                            InsertChild(dr["ID"].ToString(), newID.ToString(), dt);
                        }
                    }

                }
            }
            catch(Exception ex)
            {

                MessageBox.Show(ex.ToString(), @"提示");
                
            }
        }

        private void InsertChild(string PId, string newPId,DataTable dt)
        {
            DataRow[] pRows = dt.Select("PID='"+ PId + "'");
            if (pRows.Length > 0)
            {
                foreach (DataRow dr in pRows)
                {
                    string sqlAddNewNode =
                        string.Format(
                            @"insert into stand_Tree(Name,Code,EN_Name,Remark,PID) values (@Name,@Code,@EN_Name,@Remark,@PID); select @@identity");
                    //插入数据并拿出刚插入的数据的ID
                    object newID = SqlHelper.Query(sqlAddNewNode,new SqlParameter("@Name", dr["Name"]), 
                        new SqlParameter("@Code", dr["Code"]), new SqlParameter("@EN_Name", dr["EN_Name"]),
                        new SqlParameter("@Remark", dr["Remark"]), new SqlParameter("@PID", newPId)).Tables[0].Rows[0][0];
                    InsertChild(dr["ID"].ToString(), newID.ToString(), dt);
                }
            }
        }
    }
}
