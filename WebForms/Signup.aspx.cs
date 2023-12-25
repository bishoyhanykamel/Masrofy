using System;
using System.Linq;
using System.Net.Http;
using System.Web.UI;


namespace Masrofy4
{
    public partial class Signup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void signupBtn_Click(object sender, EventArgs e)
        {
            Masrofy4Entities ent = new Masrofy4Entities();

            string nationalID = nidTxt.Text.Trim();
            string mobileNum = mobNoTxt.Text.Trim();
            string userLegalName = nameTxt.Text.Trim();
            string userName = usrNameInput.Text.Trim();
            string userPassword = Classes.Parent.HashPassword(pwdInput.Text.Trim());

            /*  -------- User data rules --------
                - nationalID must be 14 digits only
                - mobileNum must be 11 digits only
                - userLegalName must be at least 3 characters 
                - userPassword must be a mix of letters and digits
                - userName must NOT exist in db
            */

            /*
            string t1 = $"national id: {nationalID.All(Char.IsDigit)} {nationalID.Length == 14}";
            string t2 = $"mobileNum: {mobileNum.All(Char.IsDigit)} {mobileNum.Length == 11}";
            string t3 = $"userLegalName: {!userLegalName.All(Char.IsDigit)} {userLegalName.Length >= 3}";
            */

            if (nationalID.All(Char.IsDigit) && nationalID.Length == 14 &&
                    mobileNum.All(Char.IsDigit) && mobileNum.Length == 11 &&
                    !userLegalName.All(Char.IsDigit) && userLegalName.Length >= 3)
            {
                // Checking for redudant userName
                var userNameFound = ent.FindUsernames(userName).FirstOrDefault();
                if (userNameFound >= 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Username already exists')", true);
                    return;
                }

                // Checking for redudant nationalID - if true - exception thrown for duplicate primary keys
                try
                {
                    ent.Signup(nationalID, mobileNum, userLegalName, userName, userPassword);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Successfully registered')", true);
                    using (var apiClient = new HttpClient())
                    {
                        string baseURL = "https://localhost:44338/";
                        string route = $"api/LoginPage/RegisterUserAsNBE?nationalID={nationalID}&name={userLegalName}";
                        string apiKey = "";

                        apiClient.BaseAddress = new Uri(baseURL);
                        var response = apiClient.GetAsync(route).Result;
                        if (response.IsSuccessStatusCode)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User registered successfully');", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('User NOT registered');", true);
                        }
                    }
                    Response.Redirect("~/WebForms/LoginPage.aspx");
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('National ID already registered')", true);
                }
            }

            // User didn't follow input rules
            else
            {
                //string alertMessage = "National ID must be 14 digits only\nMobile accNum must be 11 digits only\n" +
                //                        "Your legal name must be at least 3 characters\nPassword must be a mix of numbers and letters";
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{alertMessage}');", true);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Input data didn't follow format')", true);
            }

        }
    }
}