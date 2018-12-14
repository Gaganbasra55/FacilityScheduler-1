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
                }
                else if (!IsPrivateAccess(sender) && (Session["UserId"] == null))
                {

                    ManageMenuVisibility(c.ToString());
                    //send the user to the first page if is a public
                    if (c.Value == "Admin")
                    {
                        Response.Redirect("~/Pages/Dashboard/AdminDashboard.aspx");
                    }
                    else if (c.Value == "Moderator")
                    {
                        Response.Redirect("~/Pages/Dashboard/ModeratorDashboard.aspx");
                    }
                    else if (c.Value == "Faculty")
                    {
                        Response.Redirect("~/Pages/Dashboard/FacultyDashboard.aspx");
                    }
                    else if (c.Value == "Staff")
                    {
                        Response.Redirect("~/Pages/Dashboard/StaffDashboard.aspx");
                    }
                    else if (c.Value == "Student")
                    {
                        Response.Redirect("~/Pages/Dashboard/StudentDashboard.aspx");
                    }

                }
            }
        }

        public void ManageMenuVisibility(string categoryCookie)
        {
            Core.Models.User.Category category = Core.Models.User.ConvertCategory(categoryCookie);
            switch (category)
            {
                case Core.Models.User.Category.Admin:
                    break;
                case Core.Models.User.Category.Faculty:
                    break;
                case Core.Models.User.Category.Moderator:
                    break;
                case Core.Models.User.Category.Staff:
                    break;
                case Core.Models.User.Category.Student:
                    break;

            }
            Menu_LinkMenuLogout.Visible = true;

        }

        protected void Menu_Home_Click(object sender, EventArgs e)
        {
            //Forcing re-evaluation of user an redirect to home
            Response.Redirect("~/Pages/Account/Login.aspx");
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

        protected void Menu_User_Account_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                Session["UserId"] = userCookie.Value;
            }
            Response.Redirect("~/Pages/UserAccount/UserAccount.aspx");

        }

        protected void Menu_Booking_Click(object sender, EventArgs e)
        {
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                Session["UserId"] = userCookie.Value;
            }
            Response.Redirect("~/Pages/BookingsPage.aspx");

        }
        protected void Menu_FacilityAccess_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Access/AccessManagement.aspx");
        }

        protected void Menu_Bookings_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Pages/Bookings/SearchBooking.aspx");
        }

        protected void Menu_Admin_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/AdminDashboard.aspx");
        }
        protected void Menu_Moderator_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/ModeratorDashboard.aspx");
        }
        protected void Menu_Faculty_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/FacultyDashboard.aspx");
        }
        protected void Menu_Staff_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/StaffDashboard.aspx");
        }
        
        protected void Menu_Student_Dashboard_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Dashboard/StudentDashboard.aspx");
        }

    }
}