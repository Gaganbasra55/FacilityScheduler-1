using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using FacilityScheduler.Core.DA;
using FacilityScheduler.Core.Models;

namespace FacilityScheduler.Core.Controller
{
    public class AuthenticationController
    {
        private static AuthenticationController Instance;
        private UserDA UserDA;

        public static AuthenticationController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AuthenticationController();
            }
            return Instance;
        }

        AuthenticationController()
        {
            UserDA = UserDA.GetInstance();
        }

        public User AuthenticateAndValidate(string email, string password)
        {
            User account = UserDA.RecoverUser(email, password);
            if (account == null && ExistsEmail(email))
            {
               //Needs to validate?
               //Wrong credentials               
            }
            return account;
        }

        public bool ExistsEmail(string email)
        {
            return UserDA.ExistsEmail(email);
        }
    }
}