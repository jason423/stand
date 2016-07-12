namespace stand
{
    partial class ChangeEmail
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
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Confirm = new System.Windows.Forms.Button();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_NewPin = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_NewPin = new System.Windows.Forms.Button();
            this.btn_OldPin = new System.Windows.Forms.Button();
            this.txt_OldPin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(196, 112);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(84, 23);
            this.btn_Cancel.TabIndex = 17;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Confirm
            // 
            this.btn_Confirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Confirm.Location = new System.Drawing.Point(72, 112);
            this.btn_Confirm.Name = "btn_Confirm";
            this.btn_Confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirm.TabIndex = 14;
            this.btn_Confirm.Text = "确认修改";
            this.btn_Confirm.UseVisualStyleBackColor = true;
            this.btn_Confirm.Click += new System.EventHandler(this.btn_Confirm_Click);
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(87, 43);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(203, 21);
            this.txt_Email.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "新邮箱：";
            // 
            // txt_NewPin
            // 
            this.txt_NewPin.Location = new System.Drawing.Point(87, 81);
            this.txt_NewPin.Name = "txt_NewPin";
            this.txt_NewPin.Size = new System.Drawing.Size(60, 21);
            this.txt_NewPin.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "新验证码：";
            // 
            // btn_NewPin
            // 
            this.btn_NewPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_NewPin.Location = new System.Drawing.Point(196, 79);
            this.btn_NewPin.Name = "btn_NewPin";
            this.btn_NewPin.Size = new System.Drawing.Size(84, 23);
            this.btn_NewPin.TabIndex = 20;
            this.btn_NewPin.Text = "获取验证码";
            this.btn_NewPin.UseVisualStyleBackColor = true;
            this.btn_NewPin.Click += new System.EventHandler(this.btn_NewPin_Click);
            // 
            // btn_OldPin
            // 
            this.btn_OldPin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_OldPin.Location = new System.Drawing.Point(196, 10);
            this.btn_OldPin.Name = "btn_OldPin";
            this.btn_OldPin.Size = new System.Drawing.Size(84, 23);
            this.btn_OldPin.TabIndex = 23;
            this.btn_OldPin.Text = "获取验证码";
            this.btn_OldPin.UseVisualStyleBackColor = true;
            this.btn_OldPin.Click += new System.EventHandler(this.btn_OldPin_Click);
            // 
            // txt_OldPin
            // 
            this.txt_OldPin.Location = new System.Drawing.Point(118, 12);
            this.txt_OldPin.Name = "txt_OldPin";
            this.txt_OldPin.Size = new System.Drawing.Size(60, 21);
            this.txt_OldPin.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 21;
            this.label3.Text = "原始邮箱验证码：";
            // 
            // ChangeEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 154);
            this.Controls.Add(this.btn_OldPin);
            this.Controls.Add(this.txt_OldPin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_NewPin);
            this.Controls.Add(this.txt_NewPin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Confirm);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeEmail";
            this.Text = "修改邮箱";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Confirm;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_NewPin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_NewPin;
        private System.Windows.Forms.Button btn_OldPin;
        private System.Windows.Forms.TextBox txt_OldPin;
        private System.Windows.Forms.Label label3;
    }
}