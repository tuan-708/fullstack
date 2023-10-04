using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using BussinessObject.BusinessObject;
using BussinessObject.DataAccess;
using BussinessObject.Repository;
using Spending_App.Validation;

namespace Spending_App
{
    public partial class frmLogin : Form
    {
        IAccountRepository accountRepository = new AccountRepository();

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

        public frmLogin()
        {
            InitializeComponent();
            txt_password.PasswordChar = '*';
        }

        // add border
        private void frmLogin_Load(object sender, EventArgs e)
        {
            pn_login.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pn_login.Width, pn_login.Height, 30, 30));
        }

        // Login account
        private void btn_login_Click(object sender, EventArgs e)
        {
            try
            {
                string accountName = txt_account_name.Text;
                string password = txt_password.Text;

                // Valid Email
                if (!Validator.IsValidEmail(accountName))
                {
                    MessageBox.Show("Email invalid.", "Error");
                    return;
                }

                //Check account exist.
                Account auth = accountRepository.AuthenAccount(new Account { AccountName=accountName, Password=password});
                if(auth == null)
                {
                    MessageBox.Show("Account does not exist.", "Error");
                    return;
                }
                // Login success
                else if( auth != null  && auth.Role == "user")
                {
                    MessageBox.Show("Login Successfully.", "Status");
                    frmSpendingManagement frmSpendingManagement = new frmSpendingManagement(auth);
                    frmSpendingManagement.Show();
                    this.Hide();
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

        }

        // Register account
        private void lb_register_Click(object sender, EventArgs e)
        {
            frmRegister frmRegister = new frmRegister { accountRepository = accountRepository };

            frmRegister.Show();
            this.Hide(); return;
        }

    }
}
