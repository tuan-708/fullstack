namespace Spending_App
{
    partial class frmRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRegister));
            pn_register = new Panel();
            txt_repassword = new TextBox();
            lb_repassword = new Label();
            lb_here = new Label();
            lb_login = new Label();
            btn_register = new Button();
            txt_password = new TextBox();
            lb_password = new Label();
            txt_email = new TextBox();
            lb_email = new Label();
            pn_register.SuspendLayout();
            SuspendLayout();
            // 
            // pn_register
            // 
            pn_register.BackColor = Color.LightSteelBlue;
            pn_register.Controls.Add(txt_repassword);
            pn_register.Controls.Add(lb_repassword);
            pn_register.Controls.Add(lb_here);
            pn_register.Controls.Add(lb_login);
            pn_register.Controls.Add(btn_register);
            pn_register.Controls.Add(txt_password);
            pn_register.Controls.Add(lb_password);
            pn_register.Controls.Add(txt_email);
            pn_register.Controls.Add(lb_email);
            pn_register.Location = new Point(450, 36);
            pn_register.Name = "pn_register";
            pn_register.Size = new Size(254, 281);
            pn_register.TabIndex = 0;
            // 
            // txt_repassword
            // 
            txt_repassword.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_repassword.Location = new Point(124, 124);
            txt_repassword.Name = "txt_repassword";
            txt_repassword.Size = new Size(120, 22);
            txt_repassword.TabIndex = 10;
            // 
            // lb_repassword
            // 
            lb_repassword.AutoSize = true;
            lb_repassword.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_repassword.Location = new Point(15, 128);
            lb_repassword.Name = "lb_repassword";
            lb_repassword.Size = new Size(103, 18);
            lb_repassword.TabIndex = 9;
            lb_repassword.Text = "Re-Password";
            // 
            // lb_here
            // 
            lb_here.AutoSize = true;
            lb_here.Font = new Font("Arial Narrow", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_here.Location = new Point(199, 228);
            lb_here.Name = "lb_here";
            lb_here.Size = new Size(36, 20);
            lb_here.TabIndex = 8;
            lb_here.Text = "Here";
            // 
            // lb_login
            // 
            lb_login.AutoSize = true;
            lb_login.Cursor = Cursors.Hand;
            lb_login.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lb_login.ForeColor = Color.Red;
            lb_login.Location = new Point(139, 228);
            lb_login.Name = "lb_login";
            lb_login.Size = new Size(43, 17);
            lb_login.TabIndex = 7;
            lb_login.Text = "Login";
            lb_login.Click += lb_login_Click;
            // 
            // btn_register
            // 
            btn_register.BackColor = SystemColors.ButtonHighlight;
            btn_register.Cursor = Cursors.Hand;
            btn_register.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_register.ForeColor = SystemColors.ActiveCaptionText;
            btn_register.Location = new Point(71, 179);
            btn_register.Name = "btn_register";
            btn_register.Size = new Size(150, 36);
            btn_register.TabIndex = 6;
            btn_register.Text = "Register";
            btn_register.UseVisualStyleBackColor = false;
            btn_register.Click += btn_register_Click;
            // 
            // txt_password
            // 
            txt_password.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_password.Location = new Point(124, 84);
            txt_password.Name = "txt_password";
            txt_password.Size = new Size(120, 22);
            txt_password.TabIndex = 5;
            // 
            // lb_password
            // 
            lb_password.AutoSize = true;
            lb_password.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_password.Location = new Point(15, 88);
            lb_password.Name = "lb_password";
            lb_password.Size = new Size(78, 18);
            lb_password.TabIndex = 4;
            lb_password.Text = "Password";
            // 
            // txt_email
            // 
            txt_email.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            txt_email.Location = new Point(124, 43);
            txt_email.Name = "txt_email";
            txt_email.Size = new Size(120, 22);
            txt_email.TabIndex = 3;
            // 
            // lb_email
            // 
            lb_email.AutoSize = true;
            lb_email.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lb_email.Location = new Point(15, 44);
            lb_email.Name = "lb_email";
            lb_email.Size = new Size(48, 18);
            lb_email.TabIndex = 1;
            lb_email.Text = "Email";
            // 
            // frmRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(716, 352);
            Controls.Add(pn_register);
            Name = "frmRegister";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Register";
            Load += frmRegister_Load;
            pn_register.ResumeLayout(false);
            pn_register.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pn_register;
        private Label lb_email;
        private TextBox txt_email;
        private Label lb_password;
        private TextBox txt_password;
        private Button btn_login;
        private Label label4;
        private Label label5;
        private TextBox txt_repassword;
        private Label lb_repassword;
        private Label lb_here;
        private Label lb_login;
        private Button btn_register;
    }
}