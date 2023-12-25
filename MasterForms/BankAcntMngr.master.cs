using Masrofy4.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Masrofy4.MasterForms
{
    public partial class BankAcntMngr : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string nationalID = (string)Cache["nationalID"];
            LoadBankAccountsData(nationalID);
        }

        private void LoadBankAccountsData(string nationalID)
        {
            string baseAddress = "https://localhost:44338/";
            string route = $"api/HomePage/GetBankAccounts?nationalID={nationalID}";
            string apiKey = "";
            ArrayList parentBankAccounts = new ArrayList();

            using (var apiClient = new HttpClient())
            {
                apiClient.BaseAddress = new Uri(baseAddress);
                apiClient.DefaultRequestHeaders.Accept.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = apiClient.GetAsync(baseAddress + route).Result;
                if (response.IsSuccessStatusCode)
                {
                    // result 
                    var dataObjects = response.Content.ReadAsAsync<IEnumerable<BankAccount>>().Result;
                    // first loop for bank accounts
                    foreach (var bankAcc in dataObjects)
                    {
                        parentBankAccounts.Add(new BankAccount(bankAcc.accNum, bankAcc.balance, bankAcc.accType));
                    }
                    // new call for children
                    if (parentBankAccounts.Count > 0)
                    {
                        parentBankAcc_GridView.DataSource = parentBankAccounts;
                        parentBankAcc_GridView.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to retrieve bank accounts');", true);
                }
                apiClient.Dispose();
            }
        }
    }
}