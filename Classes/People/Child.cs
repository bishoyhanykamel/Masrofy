

using Newtonsoft.Json;

namespace Masrofy4.Classes.People
{
    public class Child : Person
    {
        public string childID { get; set; }
        public decimal balance { get; set; }
        public decimal dailyLimit { get; set; }
        public decimal weeklyLimit { get; set; }
        public decimal monthlyLimit { get; set; }        
        public decimal totalSpending { get; set; }
        public string limitType { get; set; }        
        public decimal limitAmount { get; set; }


        // childID, balance, limitType, limitAmount, child.name

        [JsonConstructor]
        public Child (string childid, decimal balance, string limit_type, decimal amount, string name)
        {
            this.childID = childid;
            this.balance = balance;
            this.limitType = limitType;
            this.limitAmount = amount;
            this.name = name;
        }
        public Child(string name, string id, string limit_type, decimal limitAmount)
        {
            this.name = name;
            this.childID = id;
            this.limitType = limit_type;
            this.limitAmount = limitAmount;
        }
        public Child(string name, decimal balance = 0, string limit_type = "Daily", string mobileNum="None", decimal dailyLimit=0, decimal weeklyLimit=0, decimal monthlyLimit = 0, decimal totalSpending=0)
        {
            this.name = name;
            this.balance = balance;
            this.mobileNum = mobileNum;
            this.dailyLimit = dailyLimit;
            this.weeklyLimit = weeklyLimit;
            this.monthlyLimit = monthlyLimit;
            this.totalSpending = 0;
        }


    }
}