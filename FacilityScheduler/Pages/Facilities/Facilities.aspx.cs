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
    public partial class Facilities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable("");
        }
        protected void addFacility_Click(object sender, EventArgs e)
        {
            Response.Redirect("ManageFacilities.aspx");
        }


        private void LoadTable (String search)
        {
            //string search = TextBoxSearchFacility.Text;
            List<Facility> facilities;
            if (System.Configuration.ConfigurationManager.AppSettings["AUTHENTICATION_MODE"].Equals("ENABLED"))
            {
                facilities = FacilityController.GetInstance().SearchFacility(search);

            } else
            {
                facilities = new List<Facility>();
            }

            //show or not the table
            tableFacilities.Visible = facilities.Count > 0;
            NoFacilityElements.Visible = facilities.Count < 1;
            FacilitiesTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 106, 169, 80);
            TableCell cell01 = new TableCell();
            cell01.Text = "Facility";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "Time Slot";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            TableCell cell03 = new TableCell();
            cell03.Text = " Start Time";
            cell03.Font.Bold = true;
            row0.Cells.Add(cell03);

            TableCell cell04 = new TableCell();
            cell04.Text = "End Time";
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
            FacilitiesTable.Rows.Add(row0);

            foreach (Facility f in facilities)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = f.Name;
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = f.timeSlot + "";
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = f.StartTime.ToString("HH:mm tt");
                row.Cells.Add(cell3);

                TableCell cell4 = new TableCell();
                cell4.Text = f.EndTime.ToString("HH:mm tt");
                row.Cells.Add(cell4);
                FacilitiesTable.Rows.Add(row);

                TableCell cell5 = new TableCell();
                Button buttonEdit = new Button();
                buttonEdit.Text = "Edit";
                buttonEdit.CommandArgument = f.Id.ToString();
                buttonEdit.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                buttonEdit.Click += Edit_Click;
                cell5.Controls.Add(buttonEdit);
                row.Cells.Add(cell5);
                FacilitiesTable.Rows.Add(row);

                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = f.Id.ToString();
                buttonDelete.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                buttonDelete.Click += Delete_Click;
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);
                FacilitiesTable.Rows.Add(row);
            }

        }

        private void Delete_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            FacilityController.GetInstance().DeleteFacility(Int16.Parse(id));
            Response.Redirect("Facilities.aspx");
        }

        private void Edit_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            Session["facultyId"] = id;
            Response.Redirect("ManageFacilities.aspx");
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            LoadTable(TextBoxSearchFacility.Text);
        }
    }
}
