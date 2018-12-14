using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler
{
    public class AccessCode
    {
        public int Id { get; set; }
        public int booking_id { get; set; }

        public int user_id { get; set; }

        public string accessCode { get; set; }

        public Status status { get; set; }

        public enum Status { Sent, Validated, Ended, Pending};

        public AccessCode(int booking_id, int user_id, string accessCode, Status status)
        {
            this.booking_id = booking_id;
            this.user_id = user_id;
            this.accessCode = accessCode;
        }

        public AccessCode(int Id, int booking_id, int user_id, string accessCode, Status status)
        {
            this.booking_id = booking_id;
            this.Id = Id;
            this.user_id = user_id;
            this.accessCode = accessCode;
            this.status = status;
        }

        public static Status ConvertStatus(string status)
        {
            if (status == null)
                return Status.Pending;
            switch (status.Trim())
            {
                case "Sent":
                    return Status.Sent;
                case "Validated":
                    return Status.Validated;
                case "Ended":
                    return Status.Ended;               
                default:
                    return Status.Pending;
            }
        }
    }
}