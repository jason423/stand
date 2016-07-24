namespace stand
{
    partial class FileInfo
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
            this.txt_CNName = new System.Windows.Forms.TextBox();
            this.lbl_CNName = new System.Windows.Forms.Label();
            this.txt_StandardNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_EnName = new System.Windows.Forms.TextBox();
            this.txt_StandardCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.txt_Year = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_File = new System.Windows.Forms.Button();
            this.lbl_File = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_File);
            this.splitContainer1.Panel1.Controls.Add(this.btn_File);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Year);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.txt_CNName);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_CNName);
            this.splitContainer1.Panel1.Controls.Add(this.txt_StandardNo);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txt_EnName);
            this.splitContainer1.Panel1.Controls.Add(this.txt_StandardCode);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Quit);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Confirm);
            this.splitContainer1.Size = new System.Drawing.Size(306, 402);
            this.splitContainer1.SplitterDistance = 350;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_CNName
            // 
            this.txt_CNName.Location = new System.Drawing.Point(87, 12);
            this.txt_CNName.Name = "txt_CNName";
            this.txt_CNName.Size = new System.Drawing.Size(190, 21);
            this.txt_CNName.TabIndex = 1;
            // 
            // lbl_CNName
            // 
            this.lbl_CNName.AutoSize = true;
            this.lbl_CNName.Location = new System.Drawing.Point(28, 15);
            this.lbl_CNName.Name = "lbl_CNName";
            this.lbl_CNName.Size = new System.Drawing.Size(65, 12);
            this.lbl_CNName.TabIndex = 13;
            this.lbl_CNName.Text = "中文名称：";
            // 
            // txt_StandardNo
            // 
            this.txt_StandardNo.Location = new System.Drawing.Point(87, 148);
            this.txt_StandardNo.Name = "txt_StandardNo";
            this.txt_StandardNo.PasswordChar = '*';
            this.txt_StandardNo.Size = new System.Drawing.Size(190, 21);
            this.txt_StandardNo.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "标准号：";
            // 
            // txt_EnName
            // 
            this.txt_EnName.Location = new System.Drawing.Point(87, 56);
            this.txt_EnName.Name = "txt_EnName";
            this.txt_EnName.PasswordChar = '*';
            this.txt_EnName.Size = new System.Drawing.Size(190, 21);
            this.txt_EnName.TabIndex = 2;
            // 
            // txt_StandardCode
            // 
            this.txt_StandardCode.Location = new System.Drawing.Point(87, 102);
            this.txt_StandardCode.Name = "txt_StandardCode";
            this.txt_StandardCode.PasswordChar = '*';
            this.txt_StandardCode.Size = new System.Drawing.Size(190, 21);
            this.txt_StandardCode.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "英文名称：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "标准编码：";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Quit.Location = new System.Drawing.Point(202, 22);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(75, 23);
            this.btn_Quit.TabIndex = 1;
            this.btn_Quit.Text = "退出";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Confirm.Location = new System.Drawing.Point(112, 22);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 6;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // txt_Year
            // 
            this.txt_Year.Location = new System.Drawing.Point(87, 192);
            this.txt_Year.Name = "txt_Year";
            this.txt_Year.PasswordChar = '*';
            this.txt_Year.Size = new System.Drawing.Size(190, 21);
            this.txt_Year.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 195);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 15;
            this.label3.Text = "年代号：";
            // 
            // btn_File
            // 
            this.btn_File.Location = new System.Drawing.Point(30, 313);
            this.btn_File.Name = "btn_File";
            this.btn_File.Size = new System.Drawing.Size(75, 23);
            this.btn_File.TabIndex = 16;
            this.btn_File.Text = "选择文件";
            this.btn_File.UseVisualStyleBackColor = true;
            this.btn_File.Click += new System.EventHandler(this.btn_File_Click);
            // 
            // lbl_File
            // 
            this.lbl_File.AutoSize = true;
            this.lbl_File.Location = new System.Drawing.Point(111, 318);
            this.lbl_File.Name = "lbl_File";
            this.lbl_File.Size = new System.Drawing.Size(0, 12);
            this.lbl_File.TabIndex = 17;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(87, 231);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.PasswordChar = '*';
            this.txt_Remark.Size = new System.Drawing.Size(190, 76);
            this.txt_Remark.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "备注：";
            // 
            // FileInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 402);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FileInfo";
            this.Text = "上传标准";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_CNName;
        private System.Windows.Forms.Label lbl_CNName;
        private System.Windows.Forms.TextBox txt_StandardNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_EnName;
        private System.Windows.Forms.TextBox txt_StandardCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.TextBox txt_Year;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_File;
        private System.Windows.Forms.Button btn_File;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label2;
    }
}