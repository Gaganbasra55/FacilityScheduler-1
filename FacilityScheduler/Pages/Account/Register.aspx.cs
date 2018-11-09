using FacilityScheduler.Core.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages.Account
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void buttonRegister_Click(object sender, EventArgs e)
        {
            int key = UserController.GetInstance().InsertUser(textboxUserName.Text, textboxEmail.Text, textboxFirstName.Text, textboxLastName.Text, textboxPassword.Text);
            if (key == -1)
            {
                //Redirect to the error page
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}