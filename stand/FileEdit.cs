using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using PublicClass;

namespace stand
{
    public partial class FileEdit : Form
    {
        private UltraGridRow _ugr;
        private TreeNode _node;
        public FileEdit(UltraGridRow ugr)
        {
            InitializeComponent();
            _ugr = ugr;
            txt_Remark.Text = ugr.Cells["Remark"].Value.ToString();
            txt_Code.Text = ugr.Cells["StandardNo"].Value.ToString();
            txt_ENName.Text = ugr.Cells["EN_Name"].Value.ToString();
            txt_Name.Text = ugr.Cells["CN_Name"].Value.ToString();
            txt_Year.Text = ugr.Cells["YearNo"].Value.ToString();
            InitTreeData();
            tree_GeneralPart.SelectedNode = _node;
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
                        if (dr["Id"].ToString() == _ugr.Cells["treeId"].Value.ToString())
                        {
                            _node = child;
                        }
                        child.Tag = dr;
                        GetChildNode(child);
                    }
                    else
                    {
                        TreeNode child = Root.Nodes.Add(dr["Code"].ToString() + "-" + dr["Name"].ToString());
                        if (dr["Id"].ToString() == _ugr.Cells["treeId"].Value.ToString())
                        {
                            _node = child;
                        }
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

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (tree_GeneralPart.SelectedNode == null)
            {
                MessageBox.Show(@"必须在树中选择分类", @"提示");
                return;
            }
            if (tree_GeneralPart.SelectedNode.FirstNode != null)
            {
                MessageBox.Show(@"分类树必须选择最底层节点", @"提示");
                return;
            }
            if (MessageBox.Show(@"确定修改?", @"提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql =
                    string.Format(
                        "update stand_File set treeId='{0}',StandardNo='{1}',YearNo='{2}',CN_Name='{3}',EN_Name='{4}',Remark='{5}' where Id='{6}'",
                        ((DataRow) tree_GeneralPart.SelectedNode.Tag)["Id"], txt_Code.Text, txt_Year.Text, txt_Name.Text,
                        txt_ENName.Text, txt_Remark.Text,_ugr.Cells["Id"].Value
                        );
                SqlHelper.Query(sql);
                MessageBox.Show(@"修改成功", @"提示");
                this.Dispose();
            }
        }
    }

}
