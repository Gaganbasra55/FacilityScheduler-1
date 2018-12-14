using FacilityScheduler.Core.Controller;
using FacilityScheduler.Core.Controllers;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages
{
    public partial class UserAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> dataSource = new List<string>();
                dataSource.Add("All Roles");
                dataSource.Add(Core.Models.User.Category.Admin.ToString());
                dataSource.Add(Core.Models.User.Category.Faculty.ToString());
                dataSource.Add(Core.Models.User.Category.Moderator.ToString());
                dataSource.Add(Core.Models.User.Category.Staff.ToString());
                dataSource.Add(Core.Models.User.Category.Student.ToString());
                DropDownListCategory.DataSource = dataSource;
                //DropDownListCategory.CssClass = "w3-dropdown-content w3-bar-block w3-border";
                DropDownListCategory.DataBind();
                //LoadTable("");            
            }
                LoadTable(TextBoxSearchUserAccount.Text);
        }

        private void LoadTable (string search)
        {
            //string search = TextBoxSearchFacility.Text;
            String category = DropDownListCategory.SelectedValue;
            bool isVerified = CheckBoxSearchUserAccount.Checked;

            if (DropDownListCategory.SelectedIndex == 0)//all Roles
            {
                category = "";
            }

            List<User> users = UserController.GetInstance().SearchUserAccount(category, isVerified, search);

            //show or not the table
            tableUserAccount.Visible = users.Count > 0;
            NoUserAccountElements.Visible = users.Count < 1;
            UserAccountTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 106, 169, 80);

            TableCell cell01 = new TableCell();
            cell01.Text = "Last Name";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "First Name";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            TableCell cell03 = new TableCell();
            cell03.Text = "E-mail";
            cell03.Font.Bold = true;
            row0.Cells.Add(cell03);

            TableCell cell04 = new TableCell();
            cell04.Text = "Role";
            cell04.Font.Bold = true;
            row0.Cells.Add(cell04);

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);
            UserAccountTable.Rows.Add(row0);

            foreach (User u in users)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = u.LastName;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = u.FirstName;
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = u.Email;
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = u.category.ToString();
                row.Cells.Add(cell4);
                UserAccountTable.Rows.Add(row);

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = u.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                buttonEdit.Command += Edit_Click;
                buttonEdit.Attributes.Add("autopostback", "false");
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);
                UserAccountTable.Rows.Add(row);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = u.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                buttonDelete.Click += Delete_Click;
                buttonDelete.Attributes.Add("autopostback", "false");
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);
                UserAccountTable.Rows.Add(row);

                //row0.BackColor = System.Drawing.Color.FromArgb(255, 106, 169, 80);
            }

        }

        private void Delete_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            UserController.GetInstance().DeleteUser(Int16.Parse(id));
            Response.Redirect("~/Pages/UserAccount/UserAccount.aspx");
        }

        private void Edit_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            Session["UserAccountId"] = id;
            Response.Redirect("~/Pages/UserAccount/ManageUserAccount.aspx");
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            LoadTable(TextBoxSearchUserAccount.Text);
        }
    }
}