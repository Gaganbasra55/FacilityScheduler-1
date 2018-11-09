using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacilityScheduler.Core.Models
{
    public class User
    {
        private int Id { get; set; }
        private string Email { get; set; }
        private string UserName { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }

        //Password dont need to be here

        private char Type { get; set; }

    }
}