using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Masrofy4
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        public string userOTP = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Masrofy4Entities Masrofy4Ent = new Masrofy4Entities())
            {
                var userOTPVAR = Masrofy4Ent.GetOTP((string)Cache["nationalID"]).FirstOrDefault();
                if (userOTPVAR != null)
                {
                    userOTP = JsonConvert.DeserializeObject(userOTPVAR.otpKey.ToString()).ToString();
                    //userOTP = userOTPVAR.otpKey.ToString();
                }
            }
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            if (userOTP == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP was not generated correctly');", true);
                return;
            }
            string enteredOTP = otpTxt.Text.Trim();
            string tempNewPwd = pwdTxt.Text.Trim();
            string cnfrmPwd = pwdCnfrmTxt.Text.Trim();

            if (!userOTP.Equals(enteredOTP))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('OTP mismatch');", true);
                return;
            }
            if (tempNewPwd.Equals(cnfrmPwd))
            {
                using (Masrofy4Entities MasrofyEnt = new Masrofy4Entities())
                {
                    MasrofyEnt.ChangePasswordByOTP((string)Cache["nationalID"], Classes.Parent.HashPassword(cnfrmPwd));                    
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password changed')", true);
                Response.Redirect("~/WebForms/LoginPage.aspx");
                Server.Transfer("LoginPage.aspx");
            }
            else
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password mismatch')", true);
            
        }
    }
}