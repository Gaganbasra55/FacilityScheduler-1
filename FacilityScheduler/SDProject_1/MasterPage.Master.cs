using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SDProject_1
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            timeAndDate.Text = DateTime.Now.ToString();
        }


        protected void MoveTofacebook(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.facebook.com/", true);
        }

        protected void MoveToTwitter(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://twitter.com/?lang=en", true);
        }

        protected void MoveToYoutube(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.youtube.com/", true);
        }
        //protected void lnkLogout_Click(object sender, EventArgs e)
        //{
        //    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
        //    authenticationManager.SignOut();

        //    Response.Redirect("~/Index.aspx");
        }
}