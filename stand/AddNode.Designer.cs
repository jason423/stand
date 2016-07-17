namespace stand
{
    partial class AddNode
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.txt_EN_Name = new System.Windows.Forms.TextBox();
            this.lbl_Remark = new System.Windows.Forms.Label();
            this.lbl_ENName = new System.Windows.Forms.Label();
            this.txt_Code = new System.Windows.Forms.TextBox();
            this.lbl_Code = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txt_Remark);
            this.splitContainer1.Panel1.Controls.Add(this.txt_EN_Name);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Remark);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_ENName);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Code);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Code);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Name);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Name);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Confirm);
            this.splitContainer1.Size = new System.Drawing.Size(436, 234);
            this.splitContainer1.SplitterDistance = 188;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(108, 142);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(249, 21);
            this.txt_Remark.TabIndex = 29;
            // 
            // txt_EN_Name
            // 
            this.txt_EN_Name.Location = new System.Drawing.Point(108, 104);
            this.txt_EN_Name.Name = "txt_EN_Name";
            this.txt_EN_Name.Size = new System.Drawing.Size(249, 21);
            this.txt_EN_Name.TabIndex = 28;
            // 
            // lbl_Remark
            // 
            this.lbl_Remark.AutoSize = true;
            this.lbl_Remark.Location = new System.Drawing.Point(67, 145);
            this.lbl_Remark.Name = "lbl_Remark";
            this.lbl_Remark.Size = new System.Drawing.Size(35, 12);
            this.lbl_Remark.TabIndex = 27;
            this.lbl_Remark.Text = "备注:";
            // 
            // lbl_ENName
            // 
            this.lbl_ENName.AutoSize = true;
            this.lbl_ENName.Location = new System.Drawing.Point(43, 107);
            this.lbl_ENName.Name = "lbl_ENName";
            this.lbl_ENName.Size = new System.Drawing.Size(59, 12);
            this.lbl_ENName.TabIndex = 26;
            this.lbl_ENName.Text = "英文名称:";
            // 
            // txt_Code
            // 
            this.txt_Code.Location = new System.Drawing.Point(108, 38);
            this.txt_Code.Name = "txt_Code";
            this.txt_Code.Size = new System.Drawing.Size(249, 21);
            this.txt_Code.TabIndex = 22;
            // 
            // lbl_Code
            // 
            this.lbl_Code.AutoSize = true;
            this.lbl_Code.Location = new System.Drawing.Point(67, 38);
            this.lbl_Code.Name = "lbl_Code";
            this.lbl_Code.Size = new System.Drawing.Size(35, 12);
            this.lbl_Code.TabIndex = 25;
            this.lbl_Code.Text = "码段:";
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(43, 73);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(59, 12);
            this.lbl_Name.TabIndex = 24;
            this.lbl_Name.Text = "中文名称:";
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(108, 73);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(249, 21);
            this.txt_Name.TabIndex = 23;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(349, 3);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 21;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Location = new System.Drawing.Point(250, 3);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 20;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // AddNode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 234);
            this.Controls.Add(this.splitContainer1);
            this.Name = "AddNode";
            this.Text = "添加编辑节点";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.TextBox txt_EN_Name;
        private System.Windows.Forms.Label lbl_Remark;
        private System.Windows.Forms.Label lbl_ENName;
        private System.Windows.Forms.TextBox txt_Code;
        private System.Windows.Forms.Label lbl_Code;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
    }
}