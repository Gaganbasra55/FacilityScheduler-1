using FacilityScheduler.Core.Controller;
using FacilityScheduler.Core.Controllers;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages.Bookings
{
    public partial class AccessManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            List<string> dataRoles = new List<string>();
            dataRoles.Add(Core.Models.User.Category.Admin.ToString());
            dataRoles.Add(Core.Models.User.Category.Faculty.ToString());
            dataRoles.Add(Core.Models.User.Category.Moderator.ToString());
            dataRoles.Add(Core.Models.User.Category.Staff.ToString());
            dataRoles.Add(Core.Models.User.Category.Student.ToString());


            //show or not the table
            FacilityTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 106, 169, 80);
            TableCell cell01 = new TableCell();
            cell01.Text = "Facility";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            foreach (string role in dataRoles)
            {
                TableCell cell02 = new TableCell();
                cell02.Text = role;
                cell02.Font.Bold = true;
                row0.Cells.Add(cell02);
            }
            FacilityTable.Rows.Add(row0);

            List<Facility> facilities = FacilityController.GetInstance().ListFacility();


            foreach (Facility facility in facilities)
            {
                TableRow row = new TableRow();
                TableCell cell001 = new TableCell();
                cell001.Text = facility.Name;
                row.Cells.Add(cell001);

                foreach (string role in dataRoles)
                {
                    Access access = AccessController.GetInstance().RetrieveAccessCreateIfNotExists(facility.Id, role);                    
                    TableCell cell002 = new TableCell();
                    cell002.Text = role;
                    CheckBox cb = new CheckBox();
                    cb.ID = access.Id.ToString();
                    cb.Checked = access.granted;
                    cb.CheckedChanged += Checked_Changed;
                    cb.CssClass = "w3-padding";

                    cell002.Controls.Add(cb);
                    row.Cells.Add(cell002);
                }

                
                FacilityTable.Rows.Add(row);
            }
        }

        void Checked_Changed(Object sender, EventArgs e)
        {
            CheckBox cb = (CheckBox)sender;
            int id = Int16.Parse(cb.ID);
            Access access = AccessController.GetInstance().Recover(id);
            access.granted = cb.Checked;
            AccessController.GetInstance().UpdateAccess(access);
            Response.Redirect("~/Pages/Access/AccessManagement.aspx");
        }
    }
}