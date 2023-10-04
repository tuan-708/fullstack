using BussinessObject.BusinessObject;
using BussinessObject.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Spending_App
{
    public partial class frmAddTransaction : Form
    {
        // refresh datagridview
        public delegate void DoEvent();
        public event DoEvent RefreshDgv;

        public Account account { get; set; }
        ICategoryRevenueRepository categoryRevenueRepository = new CategoryRevenueRepository();
        ICategorySpendRepository categorySpendRepository = new CategorySpendRepository();
        ITransactionRevenueRepository transactionRevenueRepository = new TransactionRevenueRepository();
        ITransactionSpendRepository transactionSpendRepository = new TransactionSpendRepository();

        // initial when open window
        public frmAddTransaction(Account acc)
        {
            InitializeComponent();
            account = acc;
            cb_type_category.SelectedIndex = 0;

            cb_category.Items.Clear();
            List<CategoryRevenue> categoryRevenues = categoryRevenueRepository.getCategorys();
            foreach (var item in categoryRevenues)
            {
                cb_category.Items.Add(item.Category);
            }
            cb_category.SelectedIndex = 0;
        }

        public void clearTex()
        {
            txt_amount.Text = "";
            txt_description.Text = "";
        }

        // save transaction account
        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                string type_categoty = cb_type_category.Text;
                if (cb_type_category.Text == "Category Revenue")
                {
                    TransactionRevenue transaction = new TransactionRevenue();
                    transaction.DateRevenue = dt_date.Value;
                    transaction.Amount = Convert.ToDecimal(txt_amount.Text);
                    transaction.Description = txt_description.Text;
                    transaction.CategoryRevenue = cb_category.Text;
                    transaction.IdAccount = account.Id;
                    transactionRevenueRepository.InsertTransactionRevenue(transaction);
                    clearTex();
                    MessageBox.Show("Add Transaction Revenue successfully.", "Infor");
                }
                else
                {
                    TransactionSpend transaction = new TransactionSpend();
                    transaction.DateSpend = dt_date.Value;
                    transaction.Amount = Convert.ToDecimal(txt_amount.Text);
                    transaction.Description = txt_description.Text;
                    transaction.CategorySpend = cb_category.Text;
                    transaction.IdAccount = account.Id;
                    transactionSpendRepository.InsertTransactionSpend(transaction);
                    clearTex();
                    MessageBox.Show("Add Transaction Spend successfully.", "Infor");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.ToString(), "Error");
            }

            this.RefreshDgv();
        }

        // change category follow type category
        private void cb_type_category_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string type_categoty = cb_type_category.Text;
            if (cb_type_category.Text == "Category Revenue")
            {
                cb_category.Items.Clear();
                List<CategoryRevenue> categoryRevenues = categoryRevenueRepository.getCategorys();
                foreach (var item in categoryRevenues)
                {
                    cb_category.Items.Add(item.Category);
                }
                cb_category.SelectedIndex = 0;
            }
            else
            {
                cb_category.Items.Clear();
                List<CategorySpend> categorySpends = categorySpendRepository.getCategorys();
                foreach (var item in categorySpends)
                {
                    cb_category.Items.Add(item.Category);
                }
                cb_category.SelectedIndex = 0;
            }
        }
    }
}
