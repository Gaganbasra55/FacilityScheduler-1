﻿using FacilityScheduler.Core.Controller;
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
            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                //Nothing to do

            }
            else
            {
                //Response.Redirect("~/Pages/Home.aspx");
            }
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {

            HttpCookie userCookie;
            userCookie = Request.Cookies["UserID"];
            if (userCookie == null)
            {
                // "Cookie Does not exists! Creating a cookie  now.";
                string email = textboxUserName.Text;
                string password = textboxPassword.Text;

                //Do the authentication
                string mode = System.Configuration.ConfigurationManager.AppSettings["AUTHENTICATION_MODE"];
                bool auth = mode.Equals("ENABLED");
                User user;
                if (auth)
                {
                    user = AuthenticationController.GetInstance().AuthenticateAndValidate(email, password);
                } else
                {
                    user = new User("Email.com", "FirstName", "LastName", "12345678", FacilityScheduler.Core.Models.User.Category.Admin);
                }
                if (user == null)
                {
                    //show error message
                    //Response.Redirect("~/Pages/Error.aspx");
                    //do nothing
                }
                else
                {
                    userCookie = new HttpCookie("UserID", "" + user.Id);
                    userCookie.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(userCookie);

                    HttpCookie c0 = new HttpCookie("UserCategory", "" + user.category);

                    Session["role"] = user.category.ToString();

                    c0.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c0);

                    String userName = user.FirstName + " " + user.LastName;

                    HttpCookie c1 = new HttpCookie("UserName", userName);
                    c1.Expires = DateTime.Now.AddMinutes(30);
                    Response.Cookies.Add(c1);

                    Response.Redirect("~/Pages/Account/Login.aspx");
                    /*
                    if (user.IsAdmin())
                    {
                    }
                    else if (user.IsStudent())
                    {
                        //suposed to be the dashboard
                        Response.Redirect("~/Pages/Management.aspx");
                    }*/
                }
            }
        }

        protected void linkButtonRegisterNow_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void linkButtonForgotPassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void AuthenticateUser(object source, ServerValidateEventArgs args)
        {
            if (!ValidateUser())
            {
                args.IsValid = false;
            }
        }

        private bool ValidateUser()
        {
            string email = textboxUserName.Text;
            string password = textboxPassword.Text;

            //Do the authentication
            string mode = System.Configuration.ConfigurationManager.AppSettings["AUTHENTICATION_MODE"];
            bool auth = mode.Equals("ENABLED");
            User user;
            if (auth)
            {
                //change to exists
                user = AuthenticationController.GetInstance().AuthenticateAndValidate(email, password);
                if (user == null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}