﻿namespace stand
{
    partial class UserLogin
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
            this.btn_UserLogin = new System.Windows.Forms.Button();
            this.btn_UserQuit = new System.Windows.Forms.Button();
            this.lbl_UserAccount = new System.Windows.Forms.Label();
            this.lbl_UserPassword = new System.Windows.Forms.Label();
            this.txt_UserPassword = new System.Windows.Forms.TextBox();
            this.chk_KeepInfo = new System.Windows.Forms.CheckBox();
            this.comBox_Account = new System.Windows.Forms.ComboBox();
            this.btn_ChangePwd = new System.Windows.Forms.Button();
            this.btn_Reg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_UserLogin
            // 
            this.btn_UserLogin.Location = new System.Drawing.Point(72, 136);
            this.btn_UserLogin.Name = "btn_UserLogin";
            this.btn_UserLogin.Size = new System.Drawing.Size(75, 23);
            this.btn_UserLogin.TabIndex = 0;
            this.btn_UserLogin.Text = "登录";
            this.btn_UserLogin.UseVisualStyleBackColor = true;
            this.btn_UserLogin.Click += new System.EventHandler(this.btn_UserLogin_Click);
            // 
            // btn_UserQuit
            // 
            this.btn_UserQuit.Location = new System.Drawing.Point(180, 136);
            this.btn_UserQuit.Name = "btn_UserQuit";
            this.btn_UserQuit.Size = new System.Drawing.Size(75, 23);
            this.btn_UserQuit.TabIndex = 1;
            this.btn_UserQuit.Text = "退出";
            this.btn_UserQuit.UseVisualStyleBackColor = true;
            this.btn_UserQuit.Click += new System.EventHandler(this.btn_UserQuit_Click);
            // 
            // lbl_UserAccount
            // 
            this.lbl_UserAccount.AutoSize = true;
            this.lbl_UserAccount.Location = new System.Drawing.Point(25, 31);
            this.lbl_UserAccount.Name = "lbl_UserAccount";
            this.lbl_UserAccount.Size = new System.Drawing.Size(41, 12);
            this.lbl_UserAccount.TabIndex = 2;
            this.lbl_UserAccount.Text = "账号：";
            // 
            // lbl_UserPassword
            // 
            this.lbl_UserPassword.AutoSize = true;
            this.lbl_UserPassword.Location = new System.Drawing.Point(25, 81);
            this.lbl_UserPassword.Name = "lbl_UserPassword";
            this.lbl_UserPassword.Size = new System.Drawing.Size(41, 12);
            this.lbl_UserPassword.TabIndex = 3;
            this.lbl_UserPassword.Text = "密码：";
            // 
            // txt_UserPassword
            // 
            this.txt_UserPassword.Location = new System.Drawing.Point(72, 78);
            this.txt_UserPassword.Name = "txt_UserPassword";
            this.txt_UserPassword.PasswordChar = '*';
            this.txt_UserPassword.Size = new System.Drawing.Size(183, 21);
            this.txt_UserPassword.TabIndex = 5;
            this.txt_UserPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_UserPassword_KeyDown);
            // 
            // chk_KeepInfo
            // 
            this.chk_KeepInfo.AutoSize = true;
            this.chk_KeepInfo.Location = new System.Drawing.Point(275, 80);
            this.chk_KeepInfo.Name = "chk_KeepInfo";
            this.chk_KeepInfo.Size = new System.Drawing.Size(72, 16);
            this.chk_KeepInfo.TabIndex = 6;
            this.chk_KeepInfo.Text = "保存密码";
            this.chk_KeepInfo.UseVisualStyleBackColor = true;
            // 
            // comBox_Account
            // 
            this.comBox_Account.FormattingEnabled = true;
            this.comBox_Account.Location = new System.Drawing.Point(72, 28);
            this.comBox_Account.Name = "comBox_Account";
            this.comBox_Account.Size = new System.Drawing.Size(183, 20);
            this.comBox_Account.TabIndex = 7;
            this.comBox_Account.SelectedIndexChanged += new System.EventHandler(this.comBox_Account_SelectedIndexChanged);
            this.comBox_Account.TextChanged += new System.EventHandler(this.comBox_Account_TextChanged);
            // 
            // btn_ChangePwd
            // 
            this.btn_ChangePwd.Location = new System.Drawing.Point(272, 102);
            this.btn_ChangePwd.Name = "btn_ChangePwd";
            this.btn_ChangePwd.Size = new System.Drawing.Size(75, 23);
            this.btn_ChangePwd.TabIndex = 8;
            this.btn_ChangePwd.Text = "修改密码";
            this.btn_ChangePwd.UseVisualStyleBackColor = true;
            this.btn_ChangePwd.Click += new System.EventHandler(this.btn_ChangePwd_Click);
            // 
            // btn_Reg
            // 
            this.btn_Reg.Location = new System.Drawing.Point(272, 26);
            this.btn_Reg.Name = "btn_Reg";
            this.btn_Reg.Size = new System.Drawing.Size(75, 23);
            this.btn_Reg.TabIndex = 9;
            this.btn_Reg.Text = "注册账号";
            this.btn_Reg.UseVisualStyleBackColor = true;
            this.btn_Reg.Click += new System.EventHandler(this.btn_Reg_Click);
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(363, 182);
            this.Controls.Add(this.btn_Reg);
            this.Controls.Add(this.btn_ChangePwd);
            this.Controls.Add(this.comBox_Account);
            this.Controls.Add(this.chk_KeepInfo);
            this.Controls.Add(this.txt_UserPassword);
            this.Controls.Add(this.lbl_UserPassword);
            this.Controls.Add(this.lbl_UserAccount);
            this.Controls.Add(this.btn_UserQuit);
            this.Controls.Add(this.btn_UserLogin);
            this.MaximizeBox = false;
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.Load += new System.EventHandler(this.UserLogin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_UserLogin;
        private System.Windows.Forms.Button btn_UserQuit;
        private System.Windows.Forms.Label lbl_UserAccount;
        private System.Windows.Forms.Label lbl_UserPassword;
        private System.Windows.Forms.TextBox txt_UserPassword;
        private System.Windows.Forms.CheckBox chk_KeepInfo;
        private System.Windows.Forms.ComboBox comBox_Account;
        private System.Windows.Forms.Button btn_ChangePwd;
        private System.Windows.Forms.Button btn_Reg;
    }
}