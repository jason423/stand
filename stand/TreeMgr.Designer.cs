namespace stand
{
    partial class TreeMgr
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tree_GeneralPart = new System.Windows.Forms.TreeView();
            this.txt_EN_Name = new System.Windows.Forms.TextBox();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.lbl_Remark = new System.Windows.Forms.Label();
            this.lbl_ENNanme = new System.Windows.Forms.Label();
            this.btn_setTree = new System.Windows.Forms.Button();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.添加节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除节点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tree_GeneralPart);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txt_EN_Name);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Remark);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Remark);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_ENNanme);
            this.splitContainer1.Panel2.Controls.Add(this.btn_setTree);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Code);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Code);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Name);
            this.splitContainer1.Size = new System.Drawing.Size(635, 410);
            this.splitContainer1.SplitterDistance = 211;
            this.splitContainer1.TabIndex = 1;
            // 
            // tree_GeneralPart
            // 
            this.tree_GeneralPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_GeneralPart.Location = new System.Drawing.Point(0, 0);
            this.tree_GeneralPart.Name = "tree_GeneralPart";
            this.tree_GeneralPart.Size = new System.Drawing.Size(211, 410);
            this.tree_GeneralPart.TabIndex = 0;
            this.tree_GeneralPart.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tree_GeneralPart_AfterSelect);
            this.tree_GeneralPart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tree_GeneralPart_MouseDown);
            // 
            // txt_EN_Name
            // 
            this.txt_EN_Name.Location = new System.Drawing.Point(155, 120);
            this.txt_EN_Name.Name = "txt_EN_Name";
            this.txt_EN_Name.ReadOnly = true;
            this.txt_EN_Name.Size = new System.Drawing.Size(178, 21);
            this.txt_EN_Name.TabIndex = 20;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(155, 147);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ReadOnly = true;
            this.txt_Remark.Size = new System.Drawing.Size(178, 21);
            this.txt_Remark.TabIndex = 21;
            // 
            // lbl_Remark
            // 
            this.lbl_Remark.AutoSize = true;
            this.lbl_Remark.Location = new System.Drawing.Point(96, 147);
            this.lbl_Remark.Name = "lbl_Remark";
            this.lbl_Remark.Size = new System.Drawing.Size(35, 12);
            this.lbl_Remark.TabIndex = 19;
            this.lbl_Remark.Text = "备注:";
            // 
            // lbl_ENNanme
            // 
            this.lbl_ENNanme.AutoSize = true;
            this.lbl_ENNanme.Location = new System.Drawing.Point(72, 123);
            this.lbl_ENNanme.Name = "lbl_ENNanme";
            this.lbl_ENNanme.Size = new System.Drawing.Size(59, 12);
            this.lbl_ENNanme.TabIndex = 18;
            this.lbl_ENNanme.Text = "英文名称:";
            // 
            // btn_setTree
            // 
            this.btn_setTree.Location = new System.Drawing.Point(258, 178);
            this.btn_setTree.Name = "btn_setTree";
            this.btn_setTree.Size = new System.Drawing.Size(75, 23);
            this.btn_setTree.TabIndex = 17;
            this.btn_setTree.Text = "编辑分类树";
            this.btn_setTree.UseVisualStyleBackColor = true;
            this.btn_setTree.Click += new System.EventHandler(this.btn_setTree_Click);
            // 
            // txt_Code
            // 
            this.txt_Code.Location = new System.Drawing.Point(155, 66);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.ReadOnly = true;
            this.txt_Code.Size = new System.Drawing.Size(178, 21);
            this.txt_Code.TabIndex = 15;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(155, 93);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ReadOnly = true;
            this.txt_Name.Size = new System.Drawing.Size(178, 21);
            this.txt_Name.TabIndex = 16;
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(96, 69);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(35, 12);
            this.lbl_Code.TabIndex = 14;
            this.lbl_Code.Text = "码段:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(72, 93);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(59, 12);
            this.lbl_Name.TabIndex = 13;
            this.lbl_Name.Text = "中文名称:";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.添加节点ToolStripMenuItem,
            this.编辑节点ToolStripMenuItem,
            this.删除节点ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 70);
            // 
            // 添加节点ToolStripMenuItem
            // 
            this.添加节点ToolStripMenuItem.Name = "添加节点ToolStripMenuItem";
            this.添加节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.添加节点ToolStripMenuItem.Text = "添加节点";
            this.添加节点ToolStripMenuItem.Click += new System.EventHandler(this.添加节点ToolStripMenuItem_Click);
            // 
            // 编辑节点ToolStripMenuItem
            // 
            this.编辑节点ToolStripMenuItem.Name = "编辑节点ToolStripMenuItem";
            this.编辑节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.编辑节点ToolStripMenuItem.Text = "编辑节点";
            this.编辑节点ToolStripMenuItem.Click += new System.EventHandler(this.编辑节点ToolStripMenuItem_Click);
            // 
            // 删除节点ToolStripMenuItem
            // 
            this.删除节点ToolStripMenuItem.Name = "删除节点ToolStripMenuItem";
            this.删除节点ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.删除节点ToolStripMenuItem.Text = "删除节点";
            this.删除节点ToolStripMenuItem.Click += new System.EventHandler(this.删除节点ToolStripMenuItem_Click);
            // 
            // TreeMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Name = "TreeMgr";
            this.Size = new System.Drawing.Size(635, 410);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tree_GeneralPart;
        private System.Windows.Forms.TextBox txt_EN_Name;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label lbl_Remark;
        private System.Windows.Forms.Label lbl_ENNanme;
        private System.Windows.Forms.Button btn_setTree;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 添加节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑节点ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除节点ToolStripMenuItem;
    }
}
