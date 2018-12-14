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
    public partial class ValidateBooking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["BookingId"] != null)
                {
                    int id = Int16.Parse((string)Session["BookingId"]);
                    Booking booking = BookingController.GetInstance().Recover(id);
                    bool exists = AccessCodeController.GetInstance().ExistsAccessCode(booking.user_id, booking.booking_id);

                    if (exists)
                    {
                        CheckCode.Visible = true;
                        SendCode.Visible = false;
                    } else
                    {
                        SendCode.Visible = true;
                        CheckCode.Visible = false;
                    }
                    HiddenFieldId.Value = id.ToString();
                    HiddenFieldUserId.Value = booking.user_id.ToString();
                }
            }
        }

        protected void buttonResendCode_Click(object sender, EventArgs e)
        {
            string code = AccessCodeController.GetInstance().GenerateCodeAndSend(Int16.Parse(HiddenFieldUserId.Value), Int16.Parse(HiddenFieldId.Value));
            Session.Remove("BookingId");
            Response.Redirect("~/Pages/Bookings/SearchBooking.aspx");
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Session.Remove("BookingId");
            Response.Redirect("~/Pages/Bookings/SearchBooking.aspx");
        }

        protected void buttonCheckCode_Click(object sender, EventArgs e)
        {
            AccessCode valid = AccessCodeController.GetInstance().RetrieveAccessCode(Int16.Parse(HiddenFieldUserId.Value), Int16.Parse(HiddenFieldId.Value));
            if (valid != null)
            {
                valid.status = AccessCode.Status.Validated;
                AccessCodeController.GetInstance().UpdateAccessCode(valid);
                Session.Remove("BookingId");
                Response.Redirect("~/Pages/Bookings/SearchBooking.aspx");
            }
        }

        protected void CustomValidatorMatchCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool valid = AccessCodeController.GetInstance().ExistsAccessCode(Int16.Parse(HiddenFieldUserId.Value), Int16.Parse(HiddenFieldId.Value));
            if (!valid)
            {
                args.IsValid = false;
            }
        }
    }
}