using FacilityScheduler.Core.Controller;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            User user = AuthenticationController.GetInstance().AuthenticateAndValidate(textboxUserName.Text, textboxPassword.Text);
            if (user == null)
            {
                Response.Redirect("~/Pages/Error.aspx");
            }
            if (FacilityScheduler.Core.Models.User.Category.Admin == user.category)
            {
                Response.Redirect("~/Pages/Facilities/Facilities.aspx");
            } else
            {
                Response.Redirect("~/Pages/Home.aspx");
            }
        }

        protected void linkButtonRegisterNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void linkButtonForgotAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void textboxUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}