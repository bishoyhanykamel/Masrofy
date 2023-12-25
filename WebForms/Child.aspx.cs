using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Net.Http;
using System.Net.Http.Headers;
using Masrofy4.Classes;
using System.Collections;
using Newtonsoft.Json;

namespace Masrofy4.WebForms
{
    public partial class Child : System.Web.UI.Page
    {
        string connnectionString = @"";
        /********************************************************************************************
        ***************************On Page Load *****************************************************/

        protected void Page_Load(object sender, EventArgs e)
        {

            nameBox.Text = "Malak";
            balanceBox.Text = "600";
            limbox.Text = "50";
            LoadChildBackEnd("999");

        }

        /********************************************************************************************
         ***************************Button Clicks *****************************************************/

        /****** Block Button *******/

        protected void BlockBtn_click(object sender, EventArgs e)
        {
            //Masrofy4Entities ent = new Masrofy4Entities();
            try
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Child is Block')", true);
                blkbtn.Text = "Unblock Child";
                limbox.Text = "0";

            }
            catch (Exception nullexc)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Technical Error')", true);
            }
        }


        /****** Change/update name Button *******/
        protected void ChangeBtn_click(object sender, EventArgs e)
        {
            Masrofy4Entities ent = new Masrofy4Entities();
            String newName = nameBox.Text;
            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Name Changed')", true);
                //ent.UpdateName(newName);
            }
            catch (Exception nullexc)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Technical Error')", true);
            }

        }

        protected void SetLimBtn_click(object sender, EventArgs e)
        {
            Masrofy4Entities ent = new Masrofy4Entities();
            String newLimit = limbox.Text;

            try
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('New Limit is Set')", true);
                //ent.UpdateLimit(newLimit);
            }
            catch (Exception nullexc)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Technical Error')", true);
            }

        }

        protected void RechargeBtn_click(object sender, EventArgs e)
        {

            String AccountNum = accountNum.Text;
            decimal Amount = Decimal.Parse(amount.Text);
            String Purpose = purpo.Text;
            String AutomaticRech = autoRech.Checked.ToString();
            String RechPeriod = period.Text;


            string childID = "999";

            //SaveRechargeData(childID, AccountNum, Amount, Purpose, AutomaticRech, RechPeriod);
            RechargeBackEnd(AccountNum, Amount, childID);



        }

        /********************************************************************************************
         ***************** Functions connecting with API Project  **********************************/




        /****** Loading child transactions in Grid ****/
        private void LoadChildBackEnd(string childID)
        {
            string baseAddress = "https://localhost:44338/";
            string route = $"api/ChildPage/GetTransactions?childID={childID}";
            string apiKey = "";

            using (var apiClient = new HttpClient())
            {
                ArrayList childTransac = new ArrayList();
                apiClient.BaseAddress = new Uri(baseAddress);

                apiClient.DefaultRequestHeaders.Accept.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage res = apiClient.GetAsync(baseAddress + route).Result;
                if (res.IsSuccessStatusCode)
                {

                    // result 
                    var dataObjects = res.Content.ReadAsAsync<IEnumerable<ChildTransaction>>().Result;
                    // first loop for bank accounts
                    foreach (var transac in dataObjects)
                    {
                        childTransac.Add(new ChildTransaction(transac.transactionDate, transac.transactionPlace, transac.transactionAmount));

                    }
                    // new call for children
                    if (childTransac.Count > 0)
                    {
                        transaction_GridView.DataSource = childTransac;
                        transaction_GridView.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to retrieve bank accounts');", true);
                }
                apiClient.Dispose();
            }
        }


        /**** Recharge backend (deduct amount from parent balance and add it to child account)****/
        //todo - check if amount is more than parent balance

        private void RechargeBackEnd(string accNum, decimal amount, string childID)
        {
            string baseAddress = "https://localhost:44338/";
            string route = $"api/ChildPage/GetRecharge?accNum={accNum}&amount={amount}&childID={childID}";
            string apiKey = "";

            using (var apiClient = new HttpClient())
            {
                ArrayList rechargeChild = new ArrayList();
                apiClient.BaseAddress = new Uri(baseAddress);

                apiClient.DefaultRequestHeaders.Accept.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = apiClient.GetAsync(baseAddress + route).Result;
                if (response.IsSuccessStatusCode)
                {

                    // result 
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Recharge Successful');", true);
                    balanceBox.Text = response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Recharge Failed');", true);
                }
                apiClient.Dispose();
            }
        }

        //private async void SaveRechargeData(string childID, string accNum, decimal amount, string purpose, string autoRech, string rechPeriod)
        //{
        //    string baseAddress = "https://localhost:44338/";
        //    string route = $"api/ChildPage/PostRechargeData?childID={childID}&accNum={accNum}&amount={amount}&purpose={purpose}&autoRech={autoRech}&rechPeriod={rechPeriod}";
        //    //string apiKey = "";
        //    // new recharge
        //    RechargeData rech = new RechargeData(childID, accNum, amount, purpose, autoRech, rechPeriod);
        //    var jsonObject = JsonConvert.SerializeObject(rech);
        //    using (var apiClient = new HttpClient())
        //    {
        //        apiClient.BaseAddress = new Uri(baseAddress);
        //        var response = apiClient.PostAsJsonAsync(route, jsonObject);
        //        var result = response.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Recharge Data Inserted');", true);
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Recharge Data Not Inserted');", true);
        //        }
        //    }
        //}
    }
}