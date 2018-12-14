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
    public partial class FacultyDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadTable();

        }

        private void LoadTable()
        {
            HttpCookie userCookie;
            int user_id = -1;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                user_id = Convert.ToInt32(userCookie.Value);
            }
            List<Booking> bookings = BookingController.GetInstance().SearchBooking(user_id,
                DateTime.Now,
                DateTime.Now.AddDays(7));

            //show or not the table
            table.Visible = bookings.Count > 0;
            NoElements.Visible = bookings.Count < 1;
            DashboardTable.Rows.Clear();

            TableRow row0 = new TableRow();
            row0.BackColor = System.Drawing.Color.FromArgb(255, 106, 169, 80);
            TableCell cell01 = new TableCell();
            cell01.Text = "Facility";
            cell01.Font.Bold = true;
            row0.Cells.Add(cell01);

            TableCell cell02 = new TableCell();
            cell02.Text = "User";
            cell02.Font.Bold = true;
            row0.Cells.Add(cell02);

            TableCell cell05 = new TableCell();
            cell05.Text = "Date";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);

            TableCell cell03 = new TableCell();
            cell03.Text = "Time Start";
            cell03.Font.Bold = true;
            row0.Cells.Add(cell03);

            TableCell cell04 = new TableCell();
            cell04.Text = "Code Status";
            cell04.Font.Bold = true;
            row0.Cells.Add(cell04);

            DashboardTable.Rows.Add(row0);

            foreach (Booking b in bookings)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = FacilityController.GetInstance().GetFacilityName(b.facility_id);
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = UserController.GetInstance().GetUserName(b.user_id);
                row.Cells.Add(cell2);

                TableCell cell15 = new TableCell();
                cell15.Text = FacilityUtil.ConvertDateTimeToDateString(b.date);
                row.Cells.Add(cell15);

                TableCell cell3 = new TableCell();
                cell3.Text = b.time_start.ToString();
                row.Cells.Add(cell3);

                String status = AccessCodeController.GetInstance().RetrieveStatus(b.user_id, b.booking_id).ToString();
                TableCell cell4 = new TableCell();
                cell4.Text = status;
                row.Cells.Add(cell4);

                DashboardTable.Rows.Add(row);
            }

        }
    }
}