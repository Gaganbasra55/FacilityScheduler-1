using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages.Account
{
    public partial class Search_User_Account_Page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {

        }

        protected void addUserAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}