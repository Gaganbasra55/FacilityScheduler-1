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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["UserId"] != null)
                {
                    int id = Int16.Parse((string)Session["UserId"]);
                    User user = UserController.GetInstance().Recover(id);

                    HiddenFieldId.Value = id.ToString();
                    textboxEmail.Text = user.Email.Trim();
                    textboxEmail.Enabled = false;

                    textboxFirstName.Text = user.FirstName;
                    textboxLastName.Text = user.LastName;
                    //textboxPassword.Text - change the password

                    HiddenFieldType.Value = user.category.ToString();
                    HiddenFieldVerified.Value = user.Verified.ToString();

                    Registration.Visible = false;
                    buttonRegister.Visible = false;

                    if (Session["ForgotPwd"] != null 
                        && bool.Parse(Session["ForgotPwd"].ToString()))
                    {
                        Session.Remove("ForgotPwd");
                        textboxFirstName.Enabled = false;
                        textboxLastName.Enabled = false;
                    }
                }
                else
                {
                    Account.Visible = false;
                    buttonSave.Visible = false;
                }
            }
        }

        protected void buttonRegister_Click(object sender, EventArgs e)
        {
           User user = new User(textboxEmail.Text, textboxFirstName.Text, textboxLastName.Text, textboxPassword.Text, FacilityScheduler.Core.Models.User.Category.Student);
            Session["UserObj"] = user;
            /*UserController.GetInstance().InsertUser(user);            
            Response.Redirect("Login.aspx");*/
            Response.Redirect("ForgotPassword.aspx");
        }

        protected void CustomValidatorExistEmail_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string username = args.Value.ToLower();
            if (AuthenticationController.GetInstance().ExistsEmail(username) && (HiddenFieldId.Value == null || HiddenFieldId.Value.Length==0))
            {
                args.IsValid = false;
            }
        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            User user = new User( Int32.Parse(HiddenFieldId.Value), textboxEmail.Text, textboxFirstName.Text, 
                textboxLastName.Text, textboxPassword.Text, FacilityScheduler.Core.Models.User.ConvertCategory(HiddenFieldType.Value), bool.Parse(HiddenFieldVerified.Value));

            UserController.GetInstance().UpdateUser(user);
            Session.Remove("UserId");
            Response.Redirect("Login.aspx");
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("UserId");
            Response.Redirect("Login.aspx");
        }
    }
}