using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Web.UI;

namespace Masrofy4.WebForms
{
    public partial class Account : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Masrofy4Entities ent = new Masrofy4Entities();
                try
                {
                    string nationalID = (string)Cache["data"];
                    nameTxt.Text = ent.GetName(nationalID).FirstOrDefault().Trim();
                    numTxt.Text = ent.GetMobilenum(nationalID).FirstOrDefault().Trim();
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Failed to retrieve user name');", true);
                }
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Masrofy4Entities ent = new Masrofy4Entities();
            string nationalID = (string)Cache["data"];
            if (nameTxt.Text.ToString().Trim().Length <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Enter name')", true);
            }
            try
            {
                ent.ChangeName(nameTxt.Text, nationalID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Success: Name changed')", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Technical Error')", true);
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string mobileNum = numTxt.Text;
            string nationalID = (string)Cache["data"];
            Masrofy4Entities ent = new Masrofy4Entities();
            if (numTxt.Text.Length != 11)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Wrong Number')", true);
            try
            {
                ent.ChangeMobilenum(mobileNum, nationalID);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Success: Mobile Number changed')", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Technical Error')", true);
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            string old = currPwdTxt.Text;
            string newpwd = newpwdTxt.Text;
            Masrofy4Entities ent = new Masrofy4Entities();
            string nationalID = (string)Cache["data"];
            if (newpwd.Equals(old) || newpwd.Length == 0 || old.Length == 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Enter a new password')", true);
            try
            {
                if (Masrofy4.Classes.Parent.HashPassword(old).Equals(ent.GetPwd(nationalID).FirstOrDefault().Trim()))
                {
                    ent.ChangePwd(nationalID, Masrofy4.Classes.Parent.HashPassword(newpwd.Trim()));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Success: Password changed')", true);
                }
                else { 
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Current Password is wrong')", true);

                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Technical Error')", true);
            }
        }


        protected void Button4_Click1(object sender, EventArgs e)
        {
            string baseURL = "https://localhost:44338/";
            string nationalID = (string)Cache["data"];
            string route = $"api/AccountPage/PostAddChild?nationalID={nationalID}";
            decimal limit_amount = 0;
            if (decimal.TryParse(limitTxt.Text, out limit_amount))
            {
                Classes.People.Child child = new Classes.People.Child(cName.Text, childID.Text, DropDownList1.SelectedValue, limit_amount);
                var jsonObj = JsonConvert.SerializeObject(child);
                var dataContent = new StringContent(jsonObj);
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseURL);
                    var response = client.PostAsJsonAsync(route, jsonObj);
                    var result = response.Result;
                    //var response = await client.PostAsync(route, dataContent);
                    //string result = response.Content.ReadAsStringAsync().Result;

                    if (result.IsSuccessStatusCode)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Child added');", true);
                    }
                    else
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Return code: Bad request');", true);
                }
            }
        }
    }
}