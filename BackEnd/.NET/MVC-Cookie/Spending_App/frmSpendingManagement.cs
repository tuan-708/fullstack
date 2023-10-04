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
using Microsoft.Data.SqlClient;

namespace Spending_App
{
    public partial class frmSpendingManagement : Form
    {
        public Account account { get; set; }
        List<TransactionRevenue> listTransactionRevenus { get; set; }

        List<TransactionSpend> listTransactionSpends { get; set; }

        decimal totalAmountRevenue = 0;
        decimal totalAmountSpend = 0;

        ITransactionRevenueRepository transactionRevenueRepository = new TransactionRevenueRepository();
        ITransactionSpendRepository transactionSpendRepository = new TransactionSpendRepository();

        public frmSpendingManagement(Account acc)
        {
            InitializeComponent();
            account = acc;
        }

        // Load transaction revenue in to datagridview 
        private void loadTransactionRevenue()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Amount", typeof(Decimal));
            dt.Columns.Add("Category Revenue", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            foreach (var transaction in listTransactionRevenus)
            {
                dt.Rows.Add(transaction.Id, transaction.DateRevenue, Decimal.Round(transaction.Amount, 1), transaction.CategoryRevenue, transaction.Description);
            }

            dgv_2.DataSource = dt;
            dgv_2.Columns[0].Visible = false;
            dgv_2.Columns[1].Width = 60;
            dgv_2.Columns[2].Width = 80;
            dgv_2.Columns[3].Width = 110;
            dgv_2.Columns[4].Width = 155;

            totalAmountRevenue = 0;
            foreach (TransactionRevenue dr in listTransactionRevenus)
            {
                totalAmountRevenue += Decimal.Round(dr.Amount, 1);
            }

            txt_revenue.Text = totalAmountRevenue.ToString();
        }

        // Load spend revenue in to datagridview 
        private void loadTransactionSpend()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(Int32));
            dt.Columns.Add("Date", typeof(DateTime));
            dt.Columns.Add("Amount", typeof(Decimal));
            dt.Columns.Add("Category Spend", typeof(string));
            dt.Columns.Add("Description", typeof(string));

            foreach (var transaction in listTransactionSpends)
            {
                dt.Rows.Add(transaction.Id, transaction.DateSpend, Decimal.Round(transaction.Amount, 1), transaction.CategorySpend, transaction.Description);
            }

            dgv_3.DataSource = dt;
            dgv_3.Columns[0].Visible = false;
            dgv_3.Columns[1].Width = 60;
            dgv_3.Columns[2].Width = 80;
            dgv_3.Columns[3].Width = 130;
            dgv_3.Columns[4].Width = 130;

            totalAmountSpend = 0;
            foreach (TransactionSpend dr in listTransactionSpends)
            {
                totalAmountSpend += Decimal.Round(dr.Amount, 1);
            }

            txt_spend.Text = totalAmountSpend.ToString();
        }

        // function to call load datagridview
        private void loadDGV(DateTime DTFrom, DateTime DTTo)
        {
            listTransactionRevenus = transactionRevenueRepository.GetTransactionRevenue(account, DTFrom, DTTo);
            listTransactionSpends = transactionSpendRepository.GetTransactionSpend(account, DTFrom, DTTo);

            loadTransactionRevenue();
            loadTransactionSpend();

            decimal totalremaining = totalAmountRevenue - totalAmountSpend;
            txt_remaining.Text = totalremaining.ToString();
        }

        // load datagridview when start
        private void frmSpendingManagement_Load(object sender, EventArgs e)
        {
            DateTime DTTo = DateTime.Now;

            TimeSpan aInterval = new TimeSpan(30, 0, 0, 0);

            DateTime DTFrom = DTTo.Subtract(aInterval);
            DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);
            dt_from.Value = DTFrom;

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when change time
        private void dt_from_ValueChanged(object sender, EventArgs e)
        {
            DateTime DTFrom = dt_from.Value;
            DateTime DTTo = dt_to.Value;

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when change time
        private void dt_to_ValueChanged(object sender, EventArgs e)
        {
            DateTime DTFrom = dt_from.Value;
            DateTime DTTo = dt_to.Value;

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when click btn today
        private void btn_today_Click(object sender, EventArgs e)
        {

            DateTime DTTo = DateTime.Now;
            DateTime DTFrom = new DateTime(DTTo.Year, DTTo.Month, DTTo.Day - 1, 23, 59, 59);

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when click btn yesterday
        private void btn_yesterday_Click(object sender, EventArgs e)
        {
            DateTime DTTo = DateTime.Now;
            DTTo = new DateTime(DTTo.Year, DTTo.Month, DTTo.Day - 1, 23, 59, 59);
            TimeSpan aInterval = new TimeSpan(1, 0, 0, 0);


            DateTime DTFrom = DTTo.Subtract(aInterval);
            DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);

            dt_from.Value = DTFrom;

            loadDGV(DTFrom, DTTo);
        }


        // load datagridview when click btn this week
        private void btn_this_week_Click(object sender, EventArgs e)
        {
            DateTime DTTo = DateTime.Now;

            int startOfWeek = (int)DayOfWeek.Monday;

            int daysSinceStartOfWeek = ((int)DTTo.DayOfWeek + 7 - startOfWeek) % 7;

            DateTime DTFrom = DTTo.AddDays(-daysSinceStartOfWeek);
            DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when click btn last week
        private void btn_last_week_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;

            int startOfWeek = (int)DayOfWeek.Monday;

            int daysSinceStartOfWeek = ((int)dtNow.DayOfWeek + 7 - startOfWeek) % 7;

            DateTime DTTo = dtNow.AddDays(-daysSinceStartOfWeek);

            DateTime DTFrom = dtNow.AddDays(-daysSinceStartOfWeek - 7);
            DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when click btn this month
        private void btn_this_month_Click(object sender, EventArgs e)
        {
            DateTime DTTo = DateTime.Now;
            var DTFrom = new DateTime(DTTo.Year, DTTo.Month, 1);

            loadDGV(DTFrom, DTTo);
        }

        // load datagridview when click btn last month
        private void btn_last_month_Click(object sender, EventArgs e)
        {
            DateTime dtNow = DateTime.Now;
            var dateOfStartMonth = new DateTime(dtNow.Year, dtNow.Month, 1);

            TimeSpan aInterval = new TimeSpan(1, 0, 0, 0, 0);

            DateTime DTTo = dateOfStartMonth.Subtract(aInterval);

            var DTFrom = new DateTime(DTTo.Year, DTTo.Month, 1);

            loadDGV(DTFrom, DTTo);
        }

        // show window add transaction
        private void btn_add_transaction_Click_1(object sender, EventArgs e)
        {
            frmAddTransaction frmAddTransaction = new frmAddTransaction(account);
            frmAddTransaction.RefreshDgv += new frmAddTransaction.DoEvent(fm_RefreshDgv);
            frmAddTransaction.Show();
        }

        // function to refresh datagridview
        void fm_RefreshDgv()
        {
            DateTime DTTo = DateTime.Now;

            TimeSpan aInterval = new TimeSpan(30, 0, 0, 0);

            DateTime DTFrom = DTTo.Subtract(aInterval);
            DTFrom = new DateTime(DTFrom.Year, DTFrom.Month, DTFrom.Day - 1, 23, 59, 59);

            dt_from.Value = DTFrom;
            dt_to.Value = DTTo;

            loadDGV(DTFrom, DTTo);
        }

        // cell double click datatable revenue to open edit delete window
        private void dgv_2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TransactionRevenue transactionRevenue = new TransactionRevenue();
                DataGridViewRow row = dgv_2.Rows[e.RowIndex];
                transactionRevenue.Id = (int)row.Cells["ID"].Value;
                transactionRevenue.DateRevenue = (DateTime)row.Cells["Date"].Value;
                transactionRevenue.Amount = (Decimal)row.Cells["Amount"].Value;
                transactionRevenue.CategoryRevenue = (string)row.Cells["Category Revenue"].Value;
                transactionRevenue.Description = (string)row.Cells["Description"].Value;
                transactionRevenue.IdAccount = account.Id;

                frmUpdateDeleteTransaction frmUpdateDeleteTransaction = new frmUpdateDeleteTransaction(transactionRevenue, "Category Revenue", null);
                frmUpdateDeleteTransaction.RefreshDgv += new frmUpdateDeleteTransaction.DoEvent(fm_RefreshDgv);
                frmUpdateDeleteTransaction.Show();
            }
            catch
            {
                MessageBox.Show("Select row transaction.", "Warning");
            }

        }

        // cell double click datatable spend to open edit delete window
        private void dgv_3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                TransactionSpend transactionSpend = new TransactionSpend();
                DataGridViewRow row = dgv_3.Rows[e.RowIndex];
                transactionSpend.Id = (int)row.Cells["ID"].Value;
                transactionSpend.DateSpend = (DateTime)row.Cells["Date"].Value;
                transactionSpend.Amount = (Decimal)row.Cells["Amount"].Value;
                transactionSpend.CategorySpend = (string)row.Cells["Category Spend"].Value;
                transactionSpend.Description = (string)row.Cells["Description"].Value;
                transactionSpend.IdAccount = account.Id;

                frmUpdateDeleteTransaction frmUpdateDeleteTransaction = new frmUpdateDeleteTransaction(null, "Category Spend", transactionSpend);
                frmUpdateDeleteTransaction.RefreshDgv += new frmUpdateDeleteTransaction.DoEvent(fm_RefreshDgv);
                frmUpdateDeleteTransaction.Show();
            }
            catch
            {
                MessageBox.Show("Select row transaction.", "Warning");
            }
        }

    }
}
