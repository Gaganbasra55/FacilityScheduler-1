using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDProject_1.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }

        protected void linkButtonRegisterNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void linkButtonForgotAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }
    }
}