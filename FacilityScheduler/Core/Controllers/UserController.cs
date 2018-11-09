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
        public void InsertUser(string UserName, string Email, string FirstName, string LastName, string Password)
        {
            UserDA.openConnection();
            SqlTransaction transaction = UserDA.BeginTransaction();
            try
            {
                //insert the user
                UserDA.InsertUser(new User(Email, FirstName, LastName, Password, User.Category.Student));
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                Console.Write(e.StackTrace);
                System.Diagnostics.Debug.Write(e.StackTrace);
                System.Diagnostics.Trace.Write(e.StackTrace);
            }
            finally
            {
                UserDA.closeConnection();
            }
        }
    }
}