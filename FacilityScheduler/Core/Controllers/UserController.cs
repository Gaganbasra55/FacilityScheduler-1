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
        public void InsertUser(User user)
        {
            UserDA.openConnection();
            SqlTransaction transaction = UserDA.BeginTransaction();
            try
            {
                //insert the user
                UserDA.InsertUser(user);
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

        public User Recover(int id)
        {
            return (User)UserDA.Recover(id);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateUser(User user)
        {
            UserDA.openConnection();
            SqlTransaction transaction = UserDA.BeginTransaction();
            try
            {
                //update the facility
                UserDA.UpdateUser(user);
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