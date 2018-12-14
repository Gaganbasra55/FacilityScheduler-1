using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler
{
    public class Access
    {
        public int Id { get; set; }
        public int facility_id { get; set; }

        public bool granted { get; set; }

        public string role { get; set; }

        public Access(int facility_id, bool granted, string role)
        {
            this.facility_id = facility_id;
            this.granted = granted;
            this.role = role;
        }

        public Access(int Id, int facility_id, bool granted, string role)
        {
            this.Id = Id;
            this.facility_id = facility_id;
            this.granted = granted;
            this.role = role;
        }
    }
}