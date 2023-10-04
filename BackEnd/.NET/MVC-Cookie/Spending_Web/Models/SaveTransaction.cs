namespace Spending_Web.Models
{
    public class SaveTransaction
    {
        public SaveTransaction() { }

        public int Id { get; set; }

        public string TypeCategory { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }

        public string Description { get; set; }

        public string CategoryRevenue { get; set; }

        public string CategorySpend { get; set; }

        public int IdAccount { get; set; }
    }
}
