using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Masrofy4.WebForms
{
    public partial class ForgotPasswordAuth : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string legalName = legalNameTextBox.Text.Trim();
            string nationalID = nationalIDTextBox.Text.Trim();
            string mobileNum = mobileNumTextBox.Text.Trim();
            string username = usernameTextBox.Text.Trim();

            if (legalName.Length < 3 /*|| !legalName.All(Char.IsLetter)*/)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Legal name must be more than 3 characters and can't include digits');", true);
                return;
            }

            if (nationalID.Length < 14 || !nationalID.All(Char.IsDigit))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('National ID must be numbers - 14 digits');", true);
                return;
            }
            if (mobileNum.Length < 11 || !mobileNum.All(Char.IsDigit))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Mobile number must be 11 digits');", true);
                return;
            }

            // call to sql masrofy db to check for user
            using (Masrofy4Entities masrofyEnt = new Masrofy4Entities())
            {
                if (masrofyEnt.CheckUserExistence(nationalID, mobileNum, legalName, username).FirstOrDefault() == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User not registered');", true);
                    return;
                }
                // call to api to generate an otp
            }

            using (HttpClient apiClient = new HttpClient())
            {
                string baseURL = "https://localhost:44338/";
                string route = $"api/OTPGenerator/GenerateOTP?nationalID={nationalID}&mobileNum={mobileNum}";
                string apiKey = "";

                apiClient.BaseAddress = new Uri(baseURL);
                apiClient.DefaultRequestHeaders.Accept.Clear();
                apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = apiClient.GetAsync(baseURL + route).Result;

                if (response.IsSuccessStatusCode)
                {
                    string userOTP = response.Content.ReadAsStringAsync().Result;
                    // this account.otp = userOTP
                    using (Masrofy4Entities MasrofyEnt = new Masrofy4Entities())
                    {
                        MasrofyEnt.StoreOTP(nationalID, userOTP, new DateTime());
                        // comment later
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{userOTP}');", true);
                        Cache["nationalID"] = nationalID;
                        Response.Redirect("~/WebForms/ForgotPassword.aspx");                        
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Failed to generate OTP');", true);
                    return;
                }
            }

        }
    }
}