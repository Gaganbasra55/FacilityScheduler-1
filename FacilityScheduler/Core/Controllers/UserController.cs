using FacilityScheduler.Core.DA;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

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
                //update the user
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
        /*
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateUserAccount(User user)
        {
            UserDA.openConnection();
            SqlTransaction transaction = UserDA.BeginTransaction();
            try
            {
                //update the user
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
        }*/

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteUser(int id)
        {
            UserDA.openConnection();
            SqlTransaction transaction = UserDA.BeginTransaction();
            try
            {
                //delete the user
                UserDA.DeleteUserAccount(id);
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

        public List<User> SearchUserAccount(String category, bool verified, string argument)
        {
            return UserDA.GetInstance().SearchUserAccount(category, verified, argument);
        }

        public string GetUserName(int key)
        {
            return UserDA.GetInstance().GetUserName(key);
        }
    }
}