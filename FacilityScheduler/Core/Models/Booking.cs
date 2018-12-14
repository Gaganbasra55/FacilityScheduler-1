using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler
{
	public class Booking
	{
		public int booking_id { get; set; }

		public int facility_id { get; set; }

		public int user_id { get; set; }

		public DateTime date { get; set; }

		public TimeSpan time_start { get; set; }

		public int time_slots { get; set; }

		public Booking() { }

        public Booking(int booking_id, int facility_id, int user_id, DateTime date, TimeSpan time_start, int time_slots) {
            this.booking_id = booking_id;
            this.facility_id = facility_id;
            this.user_id = user_id;
            this.date = date;
            this.time_start = time_start;
            this.time_slots = time_slots;
        }

    }
}