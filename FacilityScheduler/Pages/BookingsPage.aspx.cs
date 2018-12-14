using FacilityScheduler.Core.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages
{
	public partial class BookingsPage : System.Web.UI.Page
	{
		SqlConnection con;

		List<Booking> bookings;

		List<DateTime> days;

		List<TimeSpan> timeSlots;

		public int f_id;

		protected void Page_Load(object sender, EventArgs e)
		{
			con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
			con.Open();
			try
			{
				if (!IsPostBack)
				{
					string firstname = Session["Facility_id"].ToString();
					System.Diagnostics.Debug.WriteLine("Firstname = *" + firstname);
					f_id = Convert.ToInt32(firstname);

					DropDownList.SelectedIndex = f_id - 1;

					int genFor = Convert.ToInt32(Session["TableGeneratedFor"].ToString());

					if (genFor != f_id)
					{
						generateTable(f_id);
					}
				}
				else
				{
					int genFor = Convert.ToInt32(Session["TableGeneratedFor"].ToString());
					generateTable(genFor);
				}
			}
			catch (Exception)
			{
				generateTable(1);
				Session["Facility_id"] = "1";
			}

		}

		protected void DropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			int facility_id;
			try
			{
				facility_id = Convert.ToInt32(DropDownList.SelectedValue);
				f_id = facility_id;
				Session["Facility_id"] = DropDownList.SelectedValue;
				Response.Redirect("~/Pages/BookingsPage.aspx");
			}
			catch (Exception)
			{
			}

			//System.Diagnostics.Debug.WriteLine("Value = "+DropDownList.SelectedValue);

			//generateTable(facility_id);
		}

		private void generateTable(int facility_id)
		{

            HttpCookie userCookie;
            int user_id_session = -1;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                user_id_session = Convert.ToInt32(userCookie.Value);
            }

            try
			{
				Session["TableGeneratedFor"] = facility_id.ToString();

				tableContent.Rows.Clear();

				#region getting facility data

				string getFacility = "SELECT * FROM [Facility] WHERE ([facility_id] = @facility_id)";

				SqlCommand facility_cmd = new SqlCommand(getFacility, con);

				facility_cmd.Parameters.AddWithValue("@facility_id", facility_id);

				var resultFacility = facility_cmd.ExecuteReader();

				TimeSpan startTime = TimeSpan.Zero;

				//DateTime startTime = DateTime.Now;
				int timeSlotLength = 1;
				TimeSpan endTime = TimeSpan.Zero;

				if (resultFacility.Read())
				{
					startTime = resultFacility.GetTimeSpan(3);
					endTime = resultFacility.GetTimeSpan(4);
					timeSlotLength = resultFacility.GetInt32(2);
				}

				int totalRows = (endTime.Hours - startTime.Hours) / timeSlotLength;

				resultFacility.Close();
				#endregion

				#region getting booking data

				string getbooking = "SELECT * FROM [Booking] WHERE (([facility_id] = @facility_id) AND ([date] >= @date))";

				SqlCommand booking_cmd = new SqlCommand(getbooking, con);

				booking_cmd.Parameters.AddWithValue("@facility_id", facility_id);

				DateTime datetoFetch = DateTime.Now.AddDays(1);

				booking_cmd.Parameters.AddWithValue("@date", DateTime.Now);

				var resultbookings = booking_cmd.ExecuteReader();

				bookings = new List<Booking>();

				while (resultbookings.Read())
				{
					Booking b = new Booking();

					b.booking_id = resultbookings.GetInt32(0);
					b.facility_id = resultbookings.GetInt32(1);
					b.user_id = resultbookings.GetInt32(2);
					b.date = resultbookings.GetDateTime(3);
					b.time_start = resultbookings.GetTimeSpan(4);
					b.time_slots = resultbookings.GetInt32(5);

					bookings.Add(b);
				}

				resultbookings.Close();

				#endregion

				#region days for booking
				days = new List<DateTime>();

				DateTime today = datetoFetch;

				while (days.Count < 7)
				{
					if (today.DayOfWeek == DayOfWeek.Saturday || today.DayOfWeek == DayOfWeek.Sunday)
						today = today.AddDays(1);
					else
					{
						days.Add(today);
						today = today.AddDays(1);
					}
				}

				//foreach(var i in days)
				//{
				//    temp += i.Date.ToShortDateString() + " : " + i.DayOfWeek+"<br/>";
				//}
				int totalColumns = days.Count;
				#endregion

				#region created time slots

				timeSlots = new List<TimeSpan>();

				TimeSpan currentTime = startTime;

				TimeSpan timeIncrement = new TimeSpan(timeSlotLength, 0, 0);

				while (currentTime.Hours < endTime.Hours)
				{
					timeSlots.Add(currentTime);
					currentTime = currentTime.Add(timeIncrement);
				}
				timeSlots.Add(endTime);

				string temp = "";
				foreach (var i in timeSlots)
				{
					temp += i.ToString() + "<br/>";
				}

				#endregion

				#region creating table
				HtmlTableRow row = new HtmlTableRow();
				HtmlTableCell cell = new HtmlTableCell();

				// heading row
				cell.InnerText = "\t";
				row.Cells.Add(cell);
				foreach (var i in days)
				{
					cell = new HtmlTableCell();
					cell.InnerHtml = i.Day + " " + i.Date.ToString("MMMM") + "<br/>" + i.DayOfWeek;
					row.Cells.Add(cell);
				}
				tableContent.Rows.Add(row);

				// content rows
				for (int i = 0; i < timeSlots.Count - 1; i++)
				{
					row = new HtmlTableRow();

					cell = new HtmlTableCell();
					string timeSlotString = "<div class='w3-center w3-small'>" + timeSlots[i].ToString() + "<br/>to<br/>" + timeSlots[i + 1].ToString() + "</div>";
					cell.InnerHtml = timeSlotString;
					row.Cells.Add(cell);

					int col = 0;

					foreach (var j in days)
					{
						cell = new HtmlTableCell();
						bool isBooking = false;
						bool isUserBooking = false;

						int booking_id = 0;
						//check if a booking exists in this slot
						foreach (var k in bookings)
						{
							if (j.Date.Day != k.date.Day)
							{
								isBooking = false;
								continue;
							}
							TimeSpan start = k.time_start;
							TimeSpan end = k.time_start.Add(new TimeSpan(k.time_slots, 0, 0));

							if ((timeSlots[i].Hours >= start.Hours) && (timeSlots[i].Hours < end.Hours))
							{
								System.Diagnostics.Debug.WriteLine("++++++++++++++++ : " + timeSlots[i].Hours + " start " + startTime.Hours + " end " + end.Hours);
								isBooking = true;

								if (k.user_id == user_id_session)
								{
									isUserBooking = true;
									booking_id = k.booking_id;
								}

								break;
							}
							else
							{
								isBooking = false;
							}
						}

						if (isBooking)
						{
							if (isUserBooking)
							{
								cell.BgColor = "Yellow";
								HtmlInputButton input = new HtmlInputButton();
								input.ID = "b" + booking_id + "r" + i + "c" + col;
								input.Value = "Delete";
								input.ServerClick += deleteClick;
								input.Attributes.Add("autopostback", "false");
								//input.ServerClick += new EventHandler(buttonClick);
								//input.Attributes.Add("onclick", "buttonClick");

								cell.Controls.Add(input);
							}
							else
							{
								cell.BgColor = "Red";
							}
						}
						else
						{
							cell.BgColor = "White";
							//string htmltext = "<input id='r" + i + "c" + col + "' type='button' value='button' runat='server' onserverclick='buttonClick'/>";
							//cell.InnerHtml = htmltext;

							HtmlInputButton input = new HtmlInputButton();
							input.ID = "f" + facility_id + "r" + i + "c" + col;
							input.Value = "Book";
							input.ServerClick += buttonClick;
							input.Attributes.Add("autopostback", "false");
							//input.ServerClick += new EventHandler(buttonClick);
							//input.Attributes.Add("onclick", "buttonClick");

							cell.Controls.Add(input);
							//System.Diagnostics.Debug.WriteLine("button text is : " + htmltext);
						}

						row.Cells.Add(cell);
						col++;
					}
					tableContent.Rows.Add(row);
				}
				#endregion
			}
			catch (Exception ex)
			{
				lbl_error.Text = ex.ToString();
			}
		}

		protected void buttonClick(object sender, EventArgs e)
		{
			HtmlInputButton b = sender as HtmlInputButton;

			int c_pos = b.ID.IndexOf('c');
			int r_pos = b.ID.IndexOf('r');
			string rowval = b.ID.Substring(r_pos + 1, (c_pos - r_pos - 1));
			string colval = b.ID.Substring(c_pos + 1);

			int row = Convert.ToInt32(rowval);
			int col = Convert.ToInt32(colval);

			var date = days[col];
			var timeslot = timeSlots[row];

			string makeBooking = "INSERT INTO [Booking] ([facility_id],[user_id],[date],[time_start],[time_slots]) VALUES (@facility_id,@user_id,@date,@time_start,@time_slots); SELECT SCOPE_IDENTITY()";

			SqlCommand booking_cmd = new SqlCommand(makeBooking, con);

			int facility_id = Convert.ToInt32(DropDownList.SelectedValue);

            HttpCookie userCookie;
            int user_id_session = -1;
            userCookie = Request.Cookies["UserID"];
            if (userCookie != null)
            {
                user_id_session = Convert.ToInt32(userCookie.Value);
            }

            booking_cmd.Parameters.AddWithValue("@facility_id", facility_id);
			booking_cmd.Parameters.AddWithValue("@date", date);
			booking_cmd.Parameters.AddWithValue("@user_id", user_id_session);
			booking_cmd.Parameters.AddWithValue("@time_start", timeslot);
			booking_cmd.Parameters.AddWithValue("@time_slots", 1);

			try
			{
				int id = Convert.ToInt32(booking_cmd.ExecuteScalar());

                AccessCodeController.GetInstance().GenerateCodeAndSend(user_id_session, id);


                Response.Write("<script>alert('Booking Successful');</script>");
				tableContent.Rows[row + 1].Cells[col + 1].BgColor = "Yellow";
				tableContent.Rows[row + 1].Cells[col + 1].Controls.Clear();

				HtmlInputButton input = new HtmlInputButton();
				input.ID = "b" + id + "r" + row + "c" + col;
				input.Value = "Delete";
				input.ServerClick += deleteClick;
				input.Attributes.Add("autopostback", "false");

				tableContent.Rows[row + 1].Cells[col + 1].Controls.Add(input);
			}
			catch (Exception ex)
			{
				Response.Write("<script>alert('Booking UnSuccessful');</script>");
			}
		}

		protected void deleteClick(Object sender, EventArgs e)
		{
			HtmlInputButton b = sender as HtmlInputButton;

			int c_pos = b.ID.IndexOf('c');
			int r_pos = b.ID.IndexOf('r');
			string rowval = b.ID.Substring(r_pos + 1, (c_pos - r_pos - 1));
			string colval = b.ID.Substring(c_pos + 1);
			int b_id = Convert.ToInt32(b.ID.Substring(1, r_pos - 1));

			int row = Convert.ToInt32(rowval);
			int col = Convert.ToInt32(colval);

			var date = days[col];
			var timeslot = timeSlots[row];

			string makeBooking = "DELETE FROM [Booking] WHERE [booking_id] = @booking_id";
			SqlCommand booking_cmd = new SqlCommand(makeBooking, con);

			int facility_id = Convert.ToInt32(DropDownList.SelectedValue);

			booking_cmd.Parameters.AddWithValue("@booking_id", b_id);

			int rows_affected = booking_cmd.ExecuteNonQuery();

			if (rows_affected > 0)
			{
				Response.Write("<script>alert('Delete Successful');</script>");

				tableContent.Rows[row + 1].Cells[col + 1].BgColor = "White";
				tableContent.Rows[row + 1].Cells[col + 1].Controls.Clear();

				HtmlInputButton input = new HtmlInputButton();
				input.ID = "f" + facility_id + "r" + row + "c" + col;
				input.Value = "Book";
				input.ServerClick += buttonClick;
				input.Attributes.Add("autopostback", "false");

				tableContent.Rows[row + 1].Cells[col + 1].Controls.Add(input);
			}
			else
			{
				Response.Write("<script>alert('Delete UnSuccessful');</script>");
			}
		}
	}
}