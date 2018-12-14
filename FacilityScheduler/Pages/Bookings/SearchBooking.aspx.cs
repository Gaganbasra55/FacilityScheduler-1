using FacilityScheduler.Core.Controller;
using FacilityScheduler.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages.Bookings
{
    public partial class SearchBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string dateString = FacilityUtil.ConvertDateTimeToDateStringCalendar(DateTime.Now);
                TextBoxSearchBooking.Text = dateString;
                LoadTable(dateString);
            } else
            {
                LoadTable(TextBoxSearchBooking.Text);
            }

        }

        private void LoadTable(String search)
        {
            //string search = TextBoxSearchFacility.Text;
            List<Booking> bookings = BookingController.GetInstance().SearchBooking(FacilityUtil.ConvertDateStringFromCalendarToDateTime(search));

            //show or not the table
            tableBookings.Visible = bookings.Count > 0;
            NoBookingElements.Visible = bookings.Count < 1;
            BookingsTable.Rows.Clear();

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

            TableCell cell03 = new TableCell();
            cell03.Text = "Time Start";
            cell03.Font.Bold = true;
            row0.Cells.Add(cell03);            

            TableCell cell04 = new TableCell();
            cell04.Text = "Code Status";
            cell04.Font.Bold = true;
            row0.Cells.Add(cell04);

            TableCell cell05 = new TableCell();
            cell05.Text = " ";
            cell05.Font.Bold = true;
            row0.Cells.Add(cell05);
            /*
            TableCell cell06 = new TableCell();
            cell06.Text = " ";
            cell06.Font.Bold = true;
            row0.Cells.Add(cell06);*/

            BookingsTable.Rows.Add(row0);

            foreach (Booking b in bookings)
            {
                TableRow row = new TableRow();
                TableCell cell1 = new TableCell();
                cell1.Text = FacilityController.GetInstance().GetFacilityName(b.facility_id);
                row.Cells.Add(cell1);

                TableCell cell2 = new TableCell();
                cell2.Text = UserController.GetInstance().GetUserName(b.user_id);
                row.Cells.Add(cell2);

                TableCell cell3 = new TableCell();
                cell3.Text = b.time_start.ToString();
                row.Cells.Add(cell3);

                String status = AccessCodeController.GetInstance().RetrieveStatus(b.user_id, b. booking_id).ToString();
                TableCell cell4 = new TableCell();
                cell4.Text = status;
                row.Cells.Add(cell4);

                TableCell cell5 = new TableCell();
                if (AccessCode.ConvertStatus(status) == AccessCode.Status.Validated)
                {
                    Button buttonEndAccess = new Button();
                    buttonEndAccess.Text = "End Access";
                    buttonEndAccess.CommandArgument = b.booking_id.ToString();
                    buttonEndAccess.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                    buttonEndAccess.Attributes.Add("autopostback", "false");
                    buttonEndAccess.Click += End_Access_Click;
                    cell5.Controls.Add(buttonEndAccess);
                } else if (AccessCode.ConvertStatus(status) == AccessCode.Status.Ended)
                {
                    cell5.Text = " ";
                }
                else
                {
                    Button buttonValidateAccess = new Button();
                    buttonValidateAccess.Text = "Validate Access Code";
                    buttonValidateAccess.CommandArgument = b.booking_id.ToString();
                    buttonValidateAccess.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                    buttonValidateAccess.Attributes.Add("autopostback", "false");
                    buttonValidateAccess.Click += Validate_Click;
                    cell5.Controls.Add(buttonValidateAccess);
                }
                row.Cells.Add(cell5);

                /*
                TableCell cell6 = new TableCell();
                Button buttonDelete = new Button();
                buttonDelete.Text = "Delete";
                buttonDelete.CommandArgument = b.booking_id.ToString();
                buttonDelete.CssClass = "w3-button w3-black w3-padding w3-small w3-round";
                buttonDelete.Attributes.Add("autopostback", "false");
                buttonDelete.Click += Delete_Click;
                cell6.Controls.Add(buttonDelete);
                row.Cells.Add(cell6);*/
                BookingsTable.Rows.Add(row);
            }

        }

        private void Delete_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            BookingController.GetInstance().DeleteBooking(Int16.Parse(id));
            Response.Redirect("~/Pages/Bookings/SearchBooking.aspx");
        }

        private void Validate_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            Session["BookingId"] = id;
            Response.Redirect("~/Pages/Bookings/ValidateBooking.aspx");
        }

        private void End_Access_Click(object sender, System.EventArgs args)
        {
            string id = ((Button)sender).CommandArgument;
            Booking booking = BookingController.GetInstance().Recover(Int16.Parse(id));
            AccessCode accessCode = AccessCodeController.GetInstance().RetrieveAccessCode(booking.user_id, booking.booking_id);
            if (accessCode != null)
            {
                accessCode.status = AccessCode.Status.Ended;
                AccessCodeController.GetInstance().UpdateAccessCode(accessCode);
            }
            Response.Redirect("~/Pages/Bookings/SearchBooking.aspx");
        }


        protected void SearchButton_Click(object sender, EventArgs e)
        {
            if (ValidateDate(TextBoxSearchBooking.Text))
            {
                LoadTable(TextBoxSearchBooking.Text);
            }
        }

        protected void CustomValidatorDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string date = args.Value;
            if(!ValidateDate(date))
            {
                args.IsValid = false;

            }
        }

        private bool ValidateDate(String date)
        {
            try
            {
                FacilityUtil.ConvertDateStringFromCalendarToDateTime(date);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}