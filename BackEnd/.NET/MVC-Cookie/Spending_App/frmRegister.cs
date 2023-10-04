using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessObject.BusinessObject;
using BussinessObject.Repository;
using Spending_App.Validation;

namespace Spending_App
{
    public partial class frmRegister : Form
    {
        public IAccountRepository accountRepository { get; set; }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public frmRegister()
        {
            InitializeComponent();
            txt_password.PasswordChar = '*';
            txt_repassword.PasswordChar = '*';
        }

        // Change window login
        private void lb_login_Click(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
            this.Hide();
        }

        // add border
        private void frmRegister_Load(object sender, EventArgs e)
        {
            pn_register.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_register.Width, pn_register.Height, 30, 30));
        }

        // clear text view
        private void ClearText()
        {
            txt_email.Text = "";
            txt_password.Text = "";
            txt_repassword.Text = "";
        }

        // register account
        private void btn_register_Click(object sender, EventArgs e)
        {
            try
            {
                string accountName = txt_email.Text.Trim();
                string password = txt_password.Text.Trim();
                string repassword = txt_repassword.Text.Trim();

                // Validate email
                if (!Validator.IsValidEmail(accountName))
                {
                    MessageBox.Show("Email invalid.", "Error Input");
                    return;
                }

                // password not duplicate
                if (!(password == repassword))
                {
                    MessageBox.Show("Password not duplicate.", "Error");
                    return;
                }

                // Validate password
                if (!Validator.IsValidPassword(password) | !Validator.IsValidPassword(repassword))
                {
                    MessageBox.Show("1. The password must be at least 8 characters long." +
                                    "\r\n2. The password must contain at least one uppercase letter." +
                                    "\r\n3. The password must contain at least one lowercase letter." +
                                    "\r\n4. The password must contain at least one digit." +
                                    "\r\n5. The password must contain at least one special character such as !@#$%^&*()_+{}|:\"<>?-=[];',./`~.", "Erorr Input");
                    return;
                }

                // Check account exist.
                Account auth = accountRepository.GetAccountByAccountName(accountName);

                if(auth != null)
                {
                    MessageBox.Show("Account already exists.", "Error");
                    return;
                }
                else
                {
                    // Insert account
                    accountRepository.InsertAccount(new Account { AccountName = accountName.ToLower(), Password = password,Role = "user" }); ;
                    
                    MessageBox.Show("Register account succesfully.","Success");

                    //Clear text
                    ClearText();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
            
        }
    }
}
