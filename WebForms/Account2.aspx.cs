using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Masrofy4.WebForms
{
    public partial class Account : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            Masrofy4Entities ent = new Masrofy4Entities();
            try
            {
                nameTxt.Text = (string)Cache["data"];
                numTxt.Text = "01550577732";
                //nameTxt.Text, numTxt.Text = ent.GetUserFullName(nationalID).FirstOrDefault().Trim();
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Failed to retrieve user name');", true);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Masrofy4Entities ent1 = new Masrofy4Entities();

            try
            {
                //ent1.Account(nameTxt.Text);
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
            Masrofy4Entities ent2 = new Masrofy4Entities();
            if (mobileNum.Length != 11)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Wrong Number')", true);
            try
            {
                //ent2.Account(mobileNum);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Success: Mobile Number changed')", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Technical Error')", true);
            }
        }

        protected void submitNewPwBtn_Click(object sender, EventArgs e)
        {
            string old = currPwdTxt.Text;
            string newpwd = newpwdTxt.Text;
            Masrofy4Entities ent3 = new Masrofy4Entities();
            if (newpwd.Equals(old))
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Password can't be the same again')", true);
            try
            {
                //if (old.Equals(ent3.GetUserpwd(nationalID).FirstOrDefault().Trim()))
                //{
                //    ent3.Account(newpwdTxt.Text);
                //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Success: Password changed')", true);
                //}

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Technical Error')", true);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            Masrofy4Entities ent4 = new Masrofy4Entities();
            string cname = cName.Text;
            string limit = limitTxt.Text;
            string lperiod = DropDownList1.SelectedValue;
            if (FileUpload1.HasFile)
            {
                string str = FileUpload1.FileName;
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Upload/" + str));
                string pic = "~/Upload" + str.ToString();

            }
            if (cname.Length == 0 || limit.Length == 0 || lperiod.Length == 0)
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Empty fields')", true);
            try
            {
                //ent4.Account(cname, pic, limit, lperiod);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Success: Child added')", true);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Error: Technical Error')", true);
            }


        }
    }
}