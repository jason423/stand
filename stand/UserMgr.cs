using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BLL;
using PublicClass;

namespace stand
{
    public partial class UserMgr : UserControl
    {
        public UserMgr()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DataTable dt = SqlHelper.Query("select *,(case Role when 1 then '管理员' when 2 then '用户' end) as jiaose from stand_User").Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                dr["Account"] = PublicClass.EnDeCode.Decode(dr["Account"].ToString());
                dr["Password"] = PublicClass.EnDeCode.Decode(dr["Password"].ToString());
                dr["Phone"] = PublicClass.EnDeCode.Decode(dr["Phone"].ToString());
            }
            gridUser.DataSource = dt;
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            EditUser eu = new EditUser(null);
            eu.ShowDialog();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (this.gridUser.Selected.Rows.Count == 0)
            {
                MessageBox.Show(@"请选择你要编辑的角色！");
            }
            else
            {
                stand_User bllSu = new stand_User();
                Model.stand_User modelUser = bllSu.GetModel(int.Parse(gridUser.ActiveRow.Cells["Id"].ToString()));
                EditUser eu = new EditUser(modelUser);
                eu.ShowDialog();

            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (this.gridUser.Selected.Rows.Count == 0)
            {
                MessageBox.Show(@"请选择你要删除的角色！");
            }
            else
            {
                if (MessageBox.Show(@"确认删除?", @"确认信息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    stand_User bllSu = new stand_User();
                    bllSu.Delete(int.Parse(gridUser.ActiveRow.Cells["Id"].ToString()));

                    //删除界面的选中行
                    gridUser.DeleteSelectedRows(false);

                    MessageBox.Show(@"删除成功", @"提示");

                }
            }
        }
    }
}
