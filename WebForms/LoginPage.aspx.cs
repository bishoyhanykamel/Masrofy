using System;
using System.Linq;
using System.Web.UI;


namespace Masrofy4
{
    public partial class LoginPage : System.Web.UI.Page
    {
        public string name;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Masrofy4Entities ent = new Masrofy4Entities();
            string userName = usrTxt.Text;
            string userPassword = pwdTxt.Text;
            string hashedPassword = Masrofy4.Classes.Parent.HashPassword(userPassword);
            if (userName.Length <= 0 || userPassword.Length <= 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Missing username or password');", true);
            
            try
            {
                string queryResult = ent.UserLogin4(this.usrTxt.Text, hashedPassword).FirstOrDefault().Trim();
                Cache["data"] = queryResult;
                Response.Redirect("~/WebForms/Homepage.aspx");                
            }
            catch (Exception nullexc)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Invalid account')", true);
            }

        }
    }
}