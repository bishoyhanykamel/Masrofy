using System;
using System.Linq;
using System.Collections;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.UI;
using Masrofy4.Classes;
using Masrofy4.Classes.People;
using System.Collections.Generic;

namespace Masrofy4
{
    public partial class Homepage : System.Web.UI.Page
    {
        public List<Child> childAccountsList = new List<Child>();
        private const int CHILD_COLUMNS = 3;

        public string name;
        public string bankAccountTableHTML = "";
        public string childAccountGridHTML = "";

        //public System.Collections.ArrayList bankAccounts = new System.Collections.ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            string nationalID = (string)Cache["data"];
            Cache["nationalID"] = nationalID;
            using (Masrofy4Entities ent = new Masrofy4Entities())
            {
                try
                {
                    name = ent.GetUserFullName(nationalID).FirstOrDefault().Trim();
                    Cache["userLegalName"] = name;
                    LoadBankAccountsData(nationalID);
                    LoadChildrenData(nationalID);
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to retrieve user name');", true);
                }
            }
            // TODO: API call to NBE to fetch account details by cached nationalID
            // TODO: try catch statement for the API - failure case action?


            //foreach (BankAccount acc in bankAccounts)
            //{
            //    bankAccountTableHTML += $"<tr> <td scope=\"col\">{acc.Number}</td> <td scope=\"col\">{acc.Balance} EGP</td> </tr>";
            //}
            //List<Child> childAccounts = new List<Child>();
            //childAccounts.Add(new Child("Bishoy", 10.20));
            //childAccounts.Add(new Child("Mariam", 3.2));
            //childAccounts.Add(new Child("Malak", 4.20));
            //childAccounts.Add(new Child("Mahmoud", 100.24));
            //childAccounts.Add(new Child("Ali", 10.20));
            //childAccounts.Add(new Child("Bayoumy", 10.20));
            //childAccounts.Add(new Child("Mai", 10.392));
            //childAccounts.Add(new Child("Salma", 1000.874));

            //childAccountsList = childAccounts;
            ////childAccountGridHTML = "<div class=\"row mb-3\">";

            //int childCounter = 0;
            //foreach (Child acc in childAccounts)
            //{
            //    // counter is zero - start a new row
            //    if (childCounter == 0)
            //    {
            //        childAccountGridHTML += "</div><div class=\"row mb-3\">";
            //    }

            //    // append html backend of child data
            //    childAccountGridHTML += "<div class=\"col\"><div class=\"text-center fw-bold\">";
            //    childAccountGridHTML += $"<img class=\"img\"src=\"../icons/defaultChild.png\" alt=\"{acc.name}\"width=\"72px\"height=\"72px\"/>";
            //    childAccountGridHTML += $"<p class=\"mt-1 text-dark\"><b><em>{acc.name}</em></b></p>";
            //    childAccountGridHTML += $"<p style=\"font-size: 12px\"><b>Current Balance: <span class=\"text-success\">{acc.balance} EGP</span></b></p>";
            //    childAccountGridHTML += "</div></div>";
            //    childCounter++;
            //    childCounter = (childCounter + 1) % CHILD_COLUMNS;
            //}
            //childAccountGridHTML += "</div>";        
        }

        protected void userImage_Click(object sender, ImageClickEventArgs e)
        {
            // response redirect
            Response.Redirect("~/WebForms/Account.aspx");            
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
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = apiClient.GetAsync(baseAddress + route).Result;
                if (response.IsSuccessStatusCode)
                {
                    // result 
                    var dataObjects = response.Content.ReadAsAsync<IEnumerable<BankAccount>>().Result;
                    // first loop for bank accounts
                    foreach(var bankAcc in dataObjects)
                    {
                        parentBankAccounts.Add(new BankAccount(bankAcc.accNum, bankAcc.balance));
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

        private void LoadChildrenData(string nationalID)
        {
            string baseAddress = "https://localhost:44338/";
            string route = $"api/HomePage/GetChildrenData?nationalID={nationalID}";
            string apiKey = "";
            ArrayList children = new ArrayList();

            using (var apiClient = new HttpClient())
            {
                apiClient.BaseAddress = new Uri(baseAddress);
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = apiClient.GetAsync(route).Result;
                if (response.IsSuccessStatusCode)
                {
                    var dataObjects = response.Content.ReadAsAsync<IEnumerable<Child>>().Result;
                    foreach (var child in dataObjects)
                        children.Add(child);
                    if (children.Count > 0)
                    {
                        childsAccountListView.DataSource = children;
                        childsAccountListView.DataBind();
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to retrieve children data');", true);

                }
            }
        }
    }
}