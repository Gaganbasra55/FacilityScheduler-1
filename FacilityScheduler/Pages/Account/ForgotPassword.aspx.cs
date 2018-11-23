using FacilityScheduler.Core.Controller;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;

namespace FacilityScheduler.Pages.Account
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            bool secondStep = Session["CodeValidation"] != null && (bool)Session["CodeValidation"];
            if (Session["UserObj"] != null)
            {
                if (!IsPostBack)
                {
                    User user = (User)Session["UserObj"];
                    string code = AuthenticationController.GetInstance().GenerateCodeAndSend(user.Email);
                    secondStep = true;
                    Session["CodeGenerated"] = code;
                    Session["CodeValidation"] = true;
                    Session["Email"] = user.Email;
                }
            }

            if (secondStep)
            {
                RequestEmail.Visible = false;
                CheckCode.Visible = true;
            }
            else
            {
                RequestEmail.Visible = true;
                CheckCode.Visible = false;
            }
        }

        protected void buttonForgotPassword_Click(object sender, EventArgs e)
        {
            string email = textboxForgotPassword.Text;
/*
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;

            smtp.Credentials = new NetworkCredential("schedulerfacilities@gmail.com", "f123s456");

            Random r = new Random(986532);
            MailMessage mail = new MailMessage("schedulerfacilities@gmail.com", email, "verification code", (r.NextDouble() * 999999).ToString());
            smtp.Send(mail);
*/
            if (AuthenticationController.GetInstance().ExistsEmail(email))
            {
                string code = AuthenticationController.GetInstance().ForgotPassword(email);
                Session["CodeGenerated"] = code;
                Session["Email"] = email;
                Session["CodeValidation"] = true;
                Response.Redirect("ForgotPassword.aspx");
            }
        }

        protected void buttonResendCode_Click(object sender, EventArgs e)
        {
            string code = AuthenticationController.GetInstance().GenerateCodeAndSend(Session["Email"].ToString());
            Session.Remove("CodeGenerated");
            Session["CodeGenerated"] = code;
        }

        protected void buttonCheckCode_Click(object sender, EventArgs e)
        {
            string code = (string)Session["CodeGenerated"];
            if (code!= null && code.Equals(textCode.Text))
            {
                if (Session["UserObj"] != null)
                {
                    User user = (User)Session["UserObj"];
                    UserController.GetInstance().InsertUser(user);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    User user = AuthenticationController.GetInstance().AuthenticateAndValidate((String)Session["Email"]);
                    Session["UserId"] = user.Id.ToString();
                    Session["ForgotPwd"] = true.ToString();
                    Response.Redirect("Register.aspx");
                }
                Session.Remove("Email");
                Session.Remove("CodeGenerated");
                Session.Remove("CodeValidation");

            }
        }

        protected void CustomValidatorExistEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string email = args.Value.ToLower();
            if (!AuthenticationController.GetInstance().ExistsEmail(email))
            {
                args.IsValid = false;
            }
        }
        protected void CustomValidatorMatchCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string codeRequested = args.Value.ToLower();
            string code = (String)Session["CodeGenerated"];
            if (code != null && code.Equals(codeRequested))
            {
                args.IsValid = false;
            }
        }
    }
}
