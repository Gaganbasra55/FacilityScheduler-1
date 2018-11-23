using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using FacilityScheduler.Core.Controllers;
using FacilityScheduler.Core.DA;
using FacilityScheduler.Core.Models;

namespace FacilityScheduler.Core.Controller
{
    public class AuthenticationController
    {
        private static Random random = new Random();
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

        public User AuthenticateAndValidate(string email)
        {
            User account = UserDA.RecoverUser(email);
            if (account == null && ExistsEmail(email))
            {           
            }
            return account;
        }

        public bool ExistsEmail(string email)
        {
            return UserDA.ExistsEmail(email);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public string ForgotPassword(string email)
        {
            string code = "";
            if (ExistsEmail(email))
            {
                code = GenerateCodeAndSend(email);
            }
            return code;
        }

        public string GenerateCodeAndSend(string email)
        {
            string code = RandomString(10);
            EmailServiceController.SendEmail(email, code);
            return code;
        }
    }
}