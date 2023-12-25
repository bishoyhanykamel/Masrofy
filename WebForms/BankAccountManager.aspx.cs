using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.UI;
using Masrofy4.Classes;
using Newtonsoft.Json;


namespace Masrofy4.WebForms
{
    public partial class BankAccountManager : System.Web.UI.Page
    {
        public bool testing = true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBankAccBtn_Click(object sender, EventArgs e)
        {
            //if (accNameHolderLabel.Text.ToString().Trim() != (string)Cache["userLegalName"])
            //{
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User legal names mismatch');", true);
            //    return;
            //}

            string accNum = accNumTextBox.Text.ToString().Trim();
            string accType = "Credit";
            if (accTypeDropList.SelectedIndex == 1)
                accType = "Debit";
            else if (accTypeDropList.SelectedIndex == 2)
                accType = "Savings";
            

            // should check if account data matches NBE
            // instead use post
            AddNewBankAccount((string)Cache["nationalID"], accNum, accType);
            //if (accNum.Length > 0 && accNum.All(Char.IsDigit))
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('consume post api');", true);
                

        }

        protected void goBackBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForms/Homepage.aspx");
        }
        
        private void AddNewBankAccount(string nationalID, string accNum, string acctype)
        {
            string baseURL = "https://localhost:44338/";
            string route = $"api/BankAccount/PostNewAccount?nationalID={nationalID}";
            Random rand = new Random();
            double bal = rand.NextDouble() * 10000.0;
            BankAccount acc = new BankAccount(accNum, bal, acctype);
            var jsonObj = JsonConvert.SerializeObject(acc);
            var dataContent = new StringContent(jsonObj);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseURL);
                var response = client.PostAsJsonAsync(route, jsonObj);
                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Bank account linked');", true);
                }
                else
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Return code: Bad request');", true);
            }

        }
    }
}