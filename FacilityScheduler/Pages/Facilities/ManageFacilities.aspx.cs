using FacilityScheduler.Core.Controllers;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FacilityScheduler.Pages
{
    public partial class ManageFacilities : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["facultyId"] != null)
                {
                    int id = Int16.Parse((string)Session["facultyId"]);
                    Facility facility = FacilityController.GetInstance().Recover(id);
                    HiddenFieldFacilityId.Value = facility.Id.ToString();


                    textboxFacityName.Text = facility.Name;
                    DropDownListTimeSlot.SelectedValue = facility.timeSlot.ToString();
                

                    DropDownListStartTime.SelectedValue = Int16.Parse(facility.StartTime.ToString("hh", CultureInfo.InvariantCulture)).ToString();
                    DropDownListStartMinutes.SelectedValue = Int16.Parse(facility.StartTime.ToString("mm", CultureInfo.InvariantCulture)).ToString();
                    DropDownListStartPeriod.SelectedValue = facility.StartTime.ToString("tt", CultureInfo.InvariantCulture);

                    DropDownListEndTime.SelectedValue = Int16.Parse(facility.EndTime.ToString("hh", CultureInfo.InvariantCulture)).ToString();
                    DropDownListEndMinutes.SelectedValue = Int16.Parse(facility.EndTime.ToString("mm", CultureInfo.InvariantCulture)).ToString();
                    DropDownListEndDayPeriod.SelectedValue = facility.EndTime.ToString("tt", CultureInfo.InvariantCulture);

                    buttonCreateFacility.Visible = false;
                } else
                {
                    buttonUpdateFacility.Visible = false;
                }
            }

        }
        protected void buttonCreateFacility_Click(object sender, EventArgs e)
        {            
            if (validateTimes())
            {
                FacilityController.GetInstance().InsertFacility(buildFacility());
                Response.Redirect("Facilities.aspx");
            }
        }

        private Facility buildFacility ()
        {
            string name = textboxFacityName.Text;
            string timeSlot = DropDownListTimeSlot.SelectedValue;
            int slot = Int16.Parse(timeSlot);

            string startTime = DropDownListStartTime.SelectedValue;
            string startTimeMinutes = DropDownListStartMinutes.SelectedValue;
            string startTimePeriod = DropDownListStartPeriod.SelectedValue;

            DateTime starting = FacilityUtil.ConvertDateTime(startTime, startTimeMinutes, startTimePeriod);

            string endTime = DropDownListEndTime.SelectedValue;
            string endTimeMinutes = DropDownListEndMinutes.SelectedValue;
            string endTimePeriod = DropDownListEndDayPeriod.SelectedValue;

            DateTime ending = FacilityUtil.ConvertDateTime(endTime, endTimeMinutes, endTimePeriod);
            return new Facility(name, slot, starting, ending);
        }

        protected void buttonUpdateFacility_Click(object sender, EventArgs e)
        {
            if (validateTimes())
            {
                Facility facility = buildFacility();
                facility.Id = Int16.Parse(HiddenFieldFacilityId.Value);
                FacilityController.GetInstance().UpdateFacility(facility);

                Response.Redirect("Facilities.aspx");
            }
        }

        protected void buttonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Facilities.aspx");
        }


        public void CustomValidator_ValidateTimes(object source, ServerValidateEventArgs args)
        {

            string startTime = DropDownListStartTime.SelectedValue;
            string startTimeMinutes = DropDownListStartMinutes.SelectedValue;
            string startTimePeriod = DropDownListStartPeriod.SelectedValue;

            DateTime starting = FacilityUtil.ConvertDateTime(startTime, startTimeMinutes, startTimePeriod);

            string endTime = DropDownListEndTime.SelectedValue;
            string endTimeMinutes = DropDownListEndMinutes.SelectedValue;
            string endTimePeriod = DropDownListEndDayPeriod.SelectedValue;

            DateTime ending = FacilityUtil.ConvertDateTime(endTime, endTimeMinutes, endTimePeriod);

            if (!validateTimes())
            {
                args.IsValid = false;
            }
        }

        private bool validateTimes()
        {
            string startTime = DropDownListStartTime.SelectedValue;
            string startTimeMinutes = DropDownListStartMinutes.SelectedValue;
            string startTimePeriod = DropDownListStartPeriod.SelectedValue;

            DateTime starting = FacilityUtil.ConvertDateTime(startTime, startTimeMinutes, startTimePeriod);

            string endTime = DropDownListEndTime.SelectedValue;
            string endTimeMinutes = DropDownListEndMinutes.SelectedValue;
            string endTimePeriod = DropDownListEndDayPeriod.SelectedValue;

            DateTime ending = FacilityUtil.ConvertDateTime(endTime, endTimeMinutes, endTimePeriod);

            return starting.CompareTo(ending) < 0;
        }

       
    }
}