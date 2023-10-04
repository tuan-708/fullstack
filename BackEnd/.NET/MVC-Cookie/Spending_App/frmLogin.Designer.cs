namespace Spending_App
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            label5 = new Label();
            lb_register = new Label();
            label3 = new Label();
            btn_login = new Button();
            txt_password = new TextBox();
            txt_account_name = new TextBox();
            lb_password = new Label();
            lb_email = new Label();
            pn_login = new Panel();
            pn_login.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Narrow", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(194, 205);
            label5.Name = "label5";
            label5.Size = new Size(36, 20);
            label5.TabIndex = 7;
            label5.Text = "Here";
            // 
            // lb_register
            // 
            lb_register.AutoSize = true;
            lb_register.Cursor = Cursors.Hand;
            lb_register.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_register.ForeColor = Color.Red;
            lb_register.Location = new Point(114, 205);
            lb_register.Name = "lb_register";
            lb_register.Size = new Size(63, 17);
            lb_register.TabIndex = 6;
            lb_register.Text = "Register";
            lb_register.Click += lb_register_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(15, 205);
            label3.Name = "label3";
            label3.Size = new Size(78, 17);
            label3.TabIndex = 5;
            label3.Text = "New user?";
            // 
            // btn_login
            // 
            btn_login.BackColor = SystemColors.ButtonHighlight;
            btn_login.Cursor = Cursors.Hand;
            btn_login.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_login.ForeColor = SystemColors.ActiveCaptionText;
            btn_login.Location = new Point(58, 148);
            btn_login.Name = "btn_login";
            btn_login.Size = new Size(150, 36);
            btn_login.TabIndex = 4;
            btn_login.Text = "Login";
            btn_login.UseVisualStyleBackColor = false;
            btn_login.Click += btn_login_Click;
            // 
            // txt_password
            // 
            txt_password.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_password.Location = new Point(99, 98);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(136, 22);
            txt_password.TabIndex = 3;
            // 
            // txt_account_name
            // 
            txt_account_name.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_account_name.Location = new Point(99, 43);
            txt_account_name.Name = "txt_account_name";
            txt_account_name.Size = new Size(138, 22);
            txt_account_name.TabIndex = 2;
            // 
            // lb_password
            // 
            lb_password.AutoSize = true;
            lb_password.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_password.Location = new Point(15, 99);
            lb_password.Name = "lb_password";
            lb_password.Size = new Size(78, 18);
            lb_password.TabIndex = 1;
            lb_password.Text = "Password";
            // 
            // lb_email
            // 
            lb_email.AutoSize = true;
            lb_email.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_email.Location = new Point(15, 44);
            lb_email.Name = "lb_email";
            lb_email.Size = new Size(48, 18);
            lb_email.TabIndex = 0;
            lb_email.Text = "Email";
            // 
            // pn_login
            // 
            pn_login.BackColor = SystemColors.ButtonHighlight;
            pn_login.Controls.Add(txt_account_name);
            pn_login.Controls.Add(lb_register);
            pn_login.Controls.Add(label5);
            pn_login.Controls.Add(label3);
            pn_login.Controls.Add(lb_email);
            pn_login.Controls.Add(lb_password);
            pn_login.Controls.Add(txt_password);
            pn_login.Controls.Add(btn_login);
            pn_login.Location = new Point(450, 36);
            pn_login.Name = "pn_login";
            pn_login.Size = new Size(254, 281);
            pn_login.TabIndex = 8;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            ClientSize = new Size(716, 352);
            Controls.Add(pn_login);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += frmLogin_Load;
            pn_login.ResumeLayout(false);
            pn_login.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label5;
        private Label lb_register;
        private Label label3;
        private Button btn_login;
        private TextBox txt_password;
        private TextBox txt_account_name;
        private Label lb_password;
        private Label lb_email;
        private Panel pn_login;
    }
}