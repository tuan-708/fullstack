using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessObject.BusinessObject;
using BussinessObject.Repository;

namespace Spending_App
{
    public partial class frmUpdateDeleteTransaction : Form
    {
        // event refresh datagridview
        public delegate void DoEvent();
        public event DoEvent RefreshDgv;

        TransactionRevenue passtransactionRevenue { get; set; }
        TransactionSpend passTransactionSpend { get; set; }

        ICategoryRevenueRepository categoryRevenueRepository = new CategoryRevenueRepository();
        ICategorySpendRepository categorySpendRepository = new CategorySpendRepository();
        ITransactionRevenueRepository transactionRevenueRepository = new TransactionRevenueRepository();
        ITransactionSpendRepository transactionSpendRepository = new TransactionSpendRepository();

        // initial when open window
        public frmUpdateDeleteTransaction(TransactionRevenue tsRevenue, string type_category, TransactionSpend tsSpend)
        {
            InitializeComponent();

            if (type_category == "Category Revenue")
            {
                passtransactionRevenue = tsRevenue;
                lb_type_category.Text = type_category;

                cb_category.Items.Clear();
                List<CategoryRevenue> categoryRevenues = categoryRevenueRepository.getCategorys();
                foreach (var item in categoryRevenues)
                {
                    cb_category.Items.Add(item.Category);
                }
                cb_category.Text = tsRevenue.CategoryRevenue;

                lb_id_transaction.Text = tsRevenue.Id.ToString();
                dt_date.Value = tsRevenue.DateRevenue;
                txt_amount.Text = tsRevenue.Amount.ToString();
                txt_description.Text = tsRevenue.Description;
            }
            if (type_category == "Category Spend")
            {
                passTransactionSpend = tsSpend;

                lb_type_category.Text = type_category;
                cb_category.Items.Clear();

                List<CategorySpend> categorySpends = categorySpendRepository.getCategorys();
                foreach (var item in categorySpends)
                {
                    cb_category.Items.Add(item.Category);
                }
                cb_category.Text = tsSpend.CategorySpend;

                lb_id_transaction.Text = tsSpend.Id.ToString();
                dt_date.Value = tsSpend.DateSpend;
                txt_amount.Text = tsSpend.Amount.ToString();
                txt_description.Text = tsSpend.Description;
            }
        }

        // delete transaction revenue or spend
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (lb_type_category.Text == "Category Revenue")
            {
                transactionRevenueRepository.DeleteTransactionRevenue(passtransactionRevenue.Id);
                MessageBox.Show("Delete successfully transaction revenue.", "Infor");
                this.RefreshDgv();
            }
            if (lb_type_category.Text == "Category Spend")
            {
                transactionSpendRepository.DeleteTransactionSpend(passTransactionSpend.Id);
                MessageBox.Show("Delete successfully transaction spend.", "Infor");
                this.RefreshDgv();
            }
        }

        // close window
        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // update transaction account
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (lb_type_category.Text == "Category Revenue")
            {
                TransactionRevenue transaction = new TransactionRevenue();
                transaction.Id = Convert.ToInt32(lb_id_transaction.Text);
                transaction.CategoryRevenue = cb_category.Text;
                transaction.Amount = Convert.ToDecimal(txt_amount.Text.ToString());
                transaction.DateRevenue = dt_date.Value;
                transaction.Description = txt_description.Text;
                transaction.IdAccount = passtransactionRevenue.IdAccount;
                transactionRevenueRepository.UpdateTransactionRevenue(transaction);
                MessageBox.Show("Update successfully transaction revenue.", "Infor");
                this.RefreshDgv();
            }
            if (lb_type_category.Text == "Category Spend")
            {
                TransactionSpend transaction = new TransactionSpend();
                transaction.Id = Convert.ToInt32(lb_id_transaction.Text);
                transaction.CategorySpend = cb_category.Text;
                transaction.Amount = Convert.ToDecimal(txt_amount.Text.ToString());
                transaction.DateSpend = dt_date.Value;
                transaction.Description = txt_description.Text;
                transaction.IdAccount = passTransactionSpend.IdAccount;
                transactionSpendRepository.UpdateTransactionSpend(transaction);
                MessageBox.Show("Update successfully transaction spend.", "Infor");
                this.RefreshDgv();
            }
        }
    }
}
