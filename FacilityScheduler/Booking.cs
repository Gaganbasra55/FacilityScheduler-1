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
	}
}