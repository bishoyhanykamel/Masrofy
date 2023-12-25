namespace Masrofy4.Classes
{
    public class ChildTransaction
    {
        public string transactionDate { get; set; }
        public string transactionPlace { get; set; }
        public double transactionAmount { get; set; }


        public ChildTransaction(string date, string place, double amount)
        {
            this.transactionDate = date;
            this.transactionPlace = place;
            this.transactionAmount = amount;
        }
    }
}