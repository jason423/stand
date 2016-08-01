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
    public partial class FileVerify : UserControl
    {
        public FileVerify()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DataTable dt = SqlHelper.Query(@"select a.*,b.Code as ClassifyThree,b.PID,null as ClassifyOne ,null as ClassifyTwo from stand_File a left join stand_Tree b on a.treeId=b.ID where a.IsDel=0 and a.IsVerify=0").Tables[0];
            grid_StandardMgr.DataSource = dt;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {
                SqlHelper.Query(@"update stand_File set IsVerify=2 where Id=" + grid_StandardMgr.ActiveRow.Cells["Id"].Value);
                MessageBox.Show(@"驳回成功", @"提示");
                InitData();
            }
            else
            {
                MessageBox.Show(@"请先选择一行", @"提示");
            }
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (grid_StandardMgr.ActiveRow != null)
            {
                SqlHelper.Query(@"update stand_File set IsVerify=1 where Id=" + grid_StandardMgr.ActiveRow.Cells["Id"].Value);
                MessageBox.Show(@"通过成功", @"提示");
                InitData();
            }
            else
            {
                MessageBox.Show(@"请先选择一行", @"提示");
            }
        }
    }
}
