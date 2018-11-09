using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler.Core.Models
{
    public class Facility
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int timeSlot { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Facility(int Id, string Name, int timeSlot, DateTime StartTime, DateTime EndTime)
        {
            this.Id = Id;
            this.Name = Name;
            this.timeSlot = timeSlot;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
        public Facility(string Name, int timeSlot, DateTime StartTime, DateTime EndTime)
        {
            this.Name = Name;
            this.timeSlot = timeSlot;
            this.StartTime = StartTime;
            this.EndTime = EndTime;
        }
    }
}