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
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            LoadTable();
        }

        private void LoadTable()
        {

            List<User> users = UserController.GetInstance().SearchUserAccount("", false, "");

            //show or not the table
            table.Visible = users.Count > 0;
            NoElements.Visible = users.Count < 1;
            DashboardTable.Rows.Clear();

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

            DashboardTable.Rows.Add(row0);

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
                DashboardTable.Rows.Add(row);

            }

        }

    }
}