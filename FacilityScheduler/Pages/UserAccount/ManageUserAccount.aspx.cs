using FacilityScheduler.Core.Controller;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages
{
    public partial class ManageUserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            User user = null;
            if (!IsPostBack)
            {
                if (Session["UserAccountId"] != null)
                {
                    int id = Int16.Parse((string)Session["UserAccountId"]);
                    user = UserController.GetInstance().Recover(id);

                    HiddenFieldId.Value = id.ToString();
                    textboxEmail.Text = user.Email.Trim();

                    textboxFirstName.Text = user.FirstName;
                    textboxLastName.Text = user.LastName;

                    HiddenFieldPW.Value = user.Password;
                    HiddenFieldVerified.Value = user.Verified.ToString();

                }
                else
                {
                    Account.Visible = false;
                    buttonSave.Visible = false;
                }
            }

            if (user != null)
            {

                List<string> dataSource = new List<string>();
                dataSource.Add(Core.Models.User.Category.Admin.ToString());
                dataSource.Add(Core.Models.User.Category.Faculty.ToString());
                dataSource.Add(Core.Models.User.Category.Moderator.ToString());
                dataSource.Add(Core.Models.User.Category.Staff.ToString());
                dataSource.Add(Core.Models.User.Category.Student.ToString());
                DropDownListCategory.DataSource = dataSource;
                switch (user.category)
                {
                    case Core.Models.User.Category.Admin:
                        DropDownListCategory.SelectedIndex = 0;
                        break;

                    case Core.Models.User.Category.Faculty:
                        DropDownListCategory.SelectedIndex = 1;
                        break;

                    case Core.Models.User.Category.Moderator:
                        DropDownListCategory.SelectedIndex = 2;
                        break;

                    case Core.Models.User.Category.Staff:
                        DropDownListCategory.SelectedIndex = 3;
                        break;

                    case Core.Models.User.Category.Student:
                        DropDownListCategory.SelectedIndex = 4;
                        break;

                }
                //DropDownListCategory.CssClass = "w3-dropdown-content w3-bar-block w3-border";
                DropDownListCategory.DataBind();                
            }

        }

        protected void buttonSave_Click(object sender, EventArgs e)
        {
            //DropDownList dropDownCategory = CategoryPanel.FindControl("DropDownListCategory") as DropDownList;

            User user = new User(Int32.Parse(HiddenFieldId.Value), textboxEmail.Text, textboxFirstName.Text,
                textboxLastName.Text, HiddenFieldPW.Value,
                Core.Models.User.ConvertCategory(DropDownListCategory.SelectedValue),
                 true);

            UserController.GetInstance().UpdateUser(user);
            Session.Remove("UserAccountId");
            Response.Redirect("~/Pages/UserAccount/UserAccount.aspx");
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("UserAccountId");
            Response.Redirect("~/Pages/UserAccount/UserAccount.aspx");
        }
    }
}