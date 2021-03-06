﻿namespace stand
{
    partial class FindPassword
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
            this.txt_Account = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_ShowPwd = new System.Windows.Forms.CheckBox();
            this.txt_ConfirmNewPwd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NewPwd = new System.Windows.Forms.TextBox();
            this.txt_Pin = new System.Windows.Forms.TextBox();
            this.btn_GetPin = new System.Windows.Forms.Button();
            this.lbl_Notice = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel1.Controls.Add(this.lbl_Notice);
            this.splitContainer1.Panel1.Controls.Add(this.btn_GetPin);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Account);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.chk_ShowPwd);
            this.splitContainer1.Panel1.Controls.Add(this.txt_ConfirmNewPwd);
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.txt_Pin);
            this.splitContainer1.Panel1.Controls.Add(this.txt_NewPwd);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btn_Quit);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Confirm);
            this.splitContainer1.Size = new System.Drawing.Size(284, 261);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 1;
            // 
            // txt_Account
            // 
            this.txt_Account.Location = new System.Drawing.Point(87, 12);
            this.txt_Account.Name = "txt_Account";
            this.txt_Account.Size = new System.Drawing.Size(190, 21);
            this.txt_Account.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "账号：";
            // 
            // chk_ShowPwd
            // 
            this.chk_ShowPwd.AutoSize = true;
            this.chk_ShowPwd.Location = new System.Drawing.Point(205, 184);
            this.chk_ShowPwd.Name = "chk_ShowPwd";
            this.chk_ShowPwd.Size = new System.Drawing.Size(72, 16);
            this.chk_ShowPwd.TabIndex = 5;
            this.chk_ShowPwd.Text = "显示密码";
            this.chk_ShowPwd.UseVisualStyleBackColor = true;
            this.chk_ShowPwd.CheckedChanged += new System.EventHandler(this.chk_ShowPwd_CheckedChanged);
            // 
            // txt_ConfirmNewPwd
            // 
            this.txt_ConfirmNewPwd.Location = new System.Drawing.Point(87, 157);
            this.txt_ConfirmNewPwd.Name = "txt_ConfirmNewPwd";
            this.txt_ConfirmNewPwd.PasswordChar = '*';
            this.txt_ConfirmNewPwd.Size = new System.Drawing.Size(190, 21);
            this.txt_ConfirmNewPwd.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "确认新密码：";
            // 
            // btn_Quit
            // 
            this.btn_Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Quit.Location = new System.Drawing.Point(197, 15);
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
            this.btn_Confirm.Location = new System.Drawing.Point(107, 15);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 6;
            this.btn_Confirm.Text = "确定";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "新密码：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "验证码：";
            // 
            // txt_NewPwd
            // 
            this.txt_NewPwd.Location = new System.Drawing.Point(87, 111);
            this.txt_NewPwd.Name = "txt_NewPwd";
            this.txt_NewPwd.PasswordChar = '*';
            this.txt_NewPwd.Size = new System.Drawing.Size(190, 21);
            this.txt_NewPwd.TabIndex = 3;
            // 
            // txt_Pin
            // 
            this.txt_Pin.Location = new System.Drawing.Point(87, 56);
            this.txt_Pin.Name = "txt_Pin";
            this.txt_Pin.PasswordChar = '*';
            this.txt_Pin.Size = new System.Drawing.Size(190, 21);
            this.txt_Pin.TabIndex = 2;
            // 
            // btn_GetPin
            // 
            this.btn_GetPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_GetPin.Location = new System.Drawing.Point(197, 82);
            this.btn_GetPin.Name = "btn_GetPin";
            this.btn_GetPin.Size = new System.Drawing.Size(75, 23);
            this.btn_GetPin.TabIndex = 14;
            this.btn_GetPin.Text = "获取验证码";
            this.btn_GetPin.UseVisualStyleBackColor = true;
            this.btn_GetPin.Click += new System.EventHandler(this.btn_GetPin_Click);
            // 
            // lbl_Notice
            // 
            this.lbl_Notice.AutoSize = true;
            this.lbl_Notice.Location = new System.Drawing.Point(85, 87);
            this.lbl_Notice.Name = "lbl_Notice";
            this.lbl_Notice.Size = new System.Drawing.Size(107, 12);
            this.lbl_Notice.TabIndex = 15;
            this.lbl_Notice.Text = "已发送,请注意查收";
            this.lbl_Notice.Visible = false;
            // 
            // FindPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FindPassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "找回密码";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FindPassword_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Account;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chk_ShowPwd;
        private System.Windows.Forms.TextBox txt_ConfirmNewPwd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Pin;
        private System.Windows.Forms.TextBox txt_NewPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.Button btn_GetPin;
        private System.Windows.Forms.Label lbl_Notice;
    }
}