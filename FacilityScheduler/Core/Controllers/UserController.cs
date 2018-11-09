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
    public class UserController
    {
        private static UserController Instance;
        private UserDA UserDA;

        public static UserController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UserController();
            }
            return Instance;
        }

        UserController()
        {
            UserDA = UserDA.GetInstance();
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public int InsertUser(string UserName, string Email, string FirstName, string LastName, string Password)
        {
            int key = -1;
            UserDA.openConnection();
            SqlTransaction transaction = UserDA.BeginTransaction();
            try
            {
                //insert the user
                int userKey = UserDA.InsertUser(new User(UserName, Email, FirstName, LastName, Password, User.Category.Student));
                transaction.Commit();
                key = userKey;
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.Write("Hello via Console!");
                System.Diagnostics.Debug.Write("Hello via Debug!");
                System.Diagnostics.Trace.Write("Hello via Trace!");
            }
            finally
            {
                UserDA.closeConnection();
            }
            return key;
        }
    }
}