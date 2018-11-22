using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public bool IsPrivateAccess(object sender)
        {
            return !((System.Web.UI.Control)sender).Page.Page.AppRelativeVirtualPath.Contains("Login.aspx") &&
                !((System.Web.UI.Control)sender).Page.Page.AppRelativeVirtualPath.Contains("Register.aspx") &&
                !((System.Web.UI.Control)sender).Page.Page.AppRelativeVirtualPath.Contains("ForgotPassword.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string userName = "";
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                if (IsPrivateAccess(sender))
                {
                    Response.Redirect("~/Pages/Account/Login.aspx");
                }

            }
            else
            {

                HttpCookie c1 = Request.Cookies["UserName"];
                if (c1 == null)
                {
                    userName = "user";
                }
                else
                {
                    userName = c1.Value;
                }

                HttpCookie c = Request.Cookies["UserCategory"];
                if (c == null)
                {
                    Response.Redirect("~/Pages/Account/Login.aspx");
                }
                else if (c.Value == "Admin")
                {
                    
                }
                else if (c.Value == "Moderator")
                {

                }
                else if (c.Value == "Faculty")
                {

                }
                else if (c.Value == "Staff")
                {

                }
                else if (c.Value == "Student")
                {
                    
                }
            }
        }

        protected void Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            if (Request.Cookies["UserID"] != null)
            {
                Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
                Application.RemoveAll();
            }
            Response.Redirect("~/Pages/Account/Login.aspx");
        }

        protected void Facility_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Facilities/Facilities.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            //Logout COde
            Response.Cookies.Remove("UserID");
            Response.Redirect("~/Pages/Account/Login.aspx");

        }

            //protected void lnkLogout_Click(object sender, EventArgs e)
            //{
            //    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            //    authenticationManager.SignOut();

            //    Response.Redirect("~/Index.aspx");
        }
}