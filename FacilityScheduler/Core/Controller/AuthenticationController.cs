using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacilityScheduler.Core.DA;

namespace FacilityScheduler.Core.Controller
{
    public class AuthenticationController
    {
        private static AuthenticationController instance;
        private UserDA userDA;

        public static AuthenticationController getInstance()
        {
            if (instance == null)
            {
                instance = new AuthenticationController();
            }
            return instance;
        }

        AuthenticationController()
        {
            userDA = UserDA.getInstance();
        }
    }
}