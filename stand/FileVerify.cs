﻿using System;
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
    public partial class FileVerify : UserControl
    {
        public FileVerify()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            DataTable dt = SqlHelper.Query(@"select a.[Id],a.[treeId],a.[StandardNo],a.[YearNo],a.[CN_Name],a.[EN_Name],cast(a.standardcode AS varchar(max))as standardcode,a.[Remark],a.[FileName]
,a.[FTPFileName],a.[Point],a.[UploadTime],a.[UploadUser],a.[IsDel],a.[IsVerify],b.Code as ClassifyThree,b.PID,c.Account from stand_File a left join stand_Tree b on a.treeId=b.ID left join stand_User c on a.UploadUser=c.Id where a.IsDel=0 and a.IsVerify=0").Tables[0];
            PublicClass.TreeMethod.GetCodeByTreeId(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["StandardCode"] = dt.Rows[i]["StandardCode"].ToString().PadLeft(10, '0');
                dt.Rows[i]["Account"] = PublicClass.EnDeCode.Decode(dt.Rows[i]["Account"].ToString());
            }
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
                BLL.stand_User suBll = new stand_User();
                Model.stand_User suModel = suBll.GetModel(Convert.ToInt32(grid_StandardMgr.ActiveRow.Cells["UploadUser"].Value.ToString()));
                suModel.Points += 2;
                suBll.Update(suModel);
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
