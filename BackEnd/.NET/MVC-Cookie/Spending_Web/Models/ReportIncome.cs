namespace Spending_Web.Models
{
    public class ReportIncome
    {
        public int Year { get; set; }   

        public int Month { get; set; }

        public decimal AmountRevenue { get; set; }

        public decimal AmountSpend { get; set; }
    }
}
