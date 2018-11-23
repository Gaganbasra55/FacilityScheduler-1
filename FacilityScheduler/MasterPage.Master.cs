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
                menu.Visible = false;

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
                    DoLogout();
                    Response.Redirect("~/Pages/Account/Login.aspx");
                } else if (!IsPrivateAccess(sender) && (Session["UserId"]== null))
                {
                    //send the user to the first page if is a public
                    if (c.Value == "Admin")
                    {
                        Response.Redirect("~/Pages/Facilities/Facilities.aspx");
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
                        Response.Redirect("~/Pages/Management.aspx");
                    }

                }
            }
        }

        protected void Menu_Home_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Home.aspx");
        }

        protected void Menu_Logout_Click(object sender, EventArgs e)
        {
            DoLogout();
            Response.Redirect("~/Pages/Account/Login.aspx");
        }

        private void DoLogout()
        {
            Session.Abandon();
            if (Request.Cookies["UserID"] != null)
            {
                Response.Cookies["UserID"].Expires = DateTime.Now.AddDays(-1);
                Application.RemoveAll();
                Session.RemoveAll();
            }
        }

        protected void Menu_Facility_Click(object sender, EventArgs e)
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

        protected void Menu_Account_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                Session["UserId"] = userCookie.Value;
            }
            Response.Redirect("~/Pages/Account/Register.aspx");

        }
    }
}
