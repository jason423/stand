namespace stand
{
    partial class FileEdit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tree_GeneralPart = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_Year = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ENName = new System.Windows.Forms.TextBox();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.lbl_Remark = new System.Windows.Forms.Label();
            this.lbl_ENNanme = new System.Windows.Forms.Label();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tree_GeneralPart
            // 
            this.tree_GeneralPart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tree_GeneralPart.HideSelection = false;
            this.tree_GeneralPart.Location = new System.Drawing.Point(0, 0);
            this.tree_GeneralPart.Name = "tree_GeneralPart";
            this.tree_GeneralPart.Size = new System.Drawing.Size(228, 508);
            this.tree_GeneralPart.TabIndex = 0;
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
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Year);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_ENName);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Remark);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Remark);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_ENNanme);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Ok);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Code);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Name);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Code);
            this.splitContainer1.Panel2.Controls.Add(this.lbl_Name);
            this.splitContainer1.Size = new System.Drawing.Size(687, 508);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 2;
            // 
            // txt_Year
            // 
            this.txt_Year.Location = new System.Drawing.Point(163, 77);
            this.txt_Year.Name = "txt_Year";
            this.txt_Year.Size = new System.Drawing.Size(178, 21);
            this.txt_Year.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "年代号:";
            // 
            // txt_ENName
            // 
            this.txt_ENName.Location = new System.Drawing.Point(163, 131);
            this.txt_ENName.Name = "txt_ENName";
            this.txt_ENName.Size = new System.Drawing.Size(178, 21);
            this.txt_ENName.TabIndex = 20;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(163, 158);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(178, 21);
            this.txt_Remark.TabIndex = 21;
            // 
            // lbl_Remark
            // 
            this.lbl_Remark.AutoSize = true;
            this.lbl_Remark.Location = new System.Drawing.Point(116, 158);
            this.lbl_Remark.Name = "lbl_Remark";
            this.lbl_Remark.Size = new System.Drawing.Size(35, 12);
            this.lbl_Remark.TabIndex = 19;
            this.lbl_Remark.Text = "备注:";
            // 
            // lbl_ENNanme
            // 
            this.lbl_ENNanme.AutoSize = true;
            this.lbl_ENNanme.Location = new System.Drawing.Point(92, 134);
            this.lbl_ENNanme.Name = "lbl_ENNanme";
            this.lbl_ENNanme.Size = new System.Drawing.Size(59, 12);
            this.lbl_ENNanme.TabIndex = 18;
            this.lbl_ENNanme.Text = "英文名称:";
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(163, 203);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 17;
            this.btn_Ok.Text = "确定";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // txt_Code
            // 
            this.txt_Code.Location = new System.Drawing.Point(163, 50);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(178, 21);
            this.txt_Code.TabIndex = 15;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(163, 104);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(178, 21);
            this.txt_Name.TabIndex = 16;
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(104, 53);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(47, 12);
            this.lbl_Code.TabIndex = 14;
            this.lbl_Code.Text = "标准号:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(92, 104);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(59, 12);
            this.lbl_Name.TabIndex = 13;
            this.lbl_Name.Text = "中文名称:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(266, 203);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 24;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // FileEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 508);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FileEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑文件";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tree_GeneralPart;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Year;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ENName;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label lbl_Remark;
        private System.Windows.Forms.Label lbl_ENNanme;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Button btn_Cancel;
    }
}