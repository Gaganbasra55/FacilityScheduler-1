using FacilityScheduler.Core.DA;
using FacilityScheduler.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace FacilityScheduler.Core.Controllers
{
    public class AccessCodeController
    {
        private static Random random = new Random();

        private static AccessCodeController Instance;

        private AccessCodeDA AccessCodeDA;

        public static AccessCodeController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AccessCodeController();
            }
            return Instance;
        }

        AccessCodeController()
        {
            AccessCodeDA = AccessCodeDA.GetInstance();
        }

        public AccessCode Recover(int id)
        {
            return (AccessCode)AccessCodeDA.Recover(id);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertAccessCode(AccessCode accessCode)
        {
            AccessCodeDA.openConnection();
            SqlTransaction transaction = AccessCodeDA.BeginTransaction();
            try
            {
                //insert the accessCode
                AccessCodeDA.InsertAccessCode(accessCode);
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
                AccessCodeDA.closeConnection();
            }
        }



        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateAccessCode(AccessCode accessCode)
        {
            AccessCodeDA.openConnection();
            SqlTransaction transaction = AccessCodeDA.BeginTransaction();
            try
            {
                //update the accessCode
                AccessCodeDA.UpdateAccessCode(accessCode);
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
                AccessCodeDA.closeConnection();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteAccessCode(int id)
        {
            AccessCodeDA.openConnection();
            SqlTransaction transaction = AccessCodeDA.BeginTransaction();
            try
            {
                //delete the accessCode
                AccessCodeDA.DeleteAccessCode(id);
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
                AccessCodeDA.closeConnection();
            }
        }

        public bool ExistsAccessCode(int user_id, int booking_id)
        {
            return AccessCodeDA.ExistsAccessCode(user_id, booking_id);
        }

        public AccessCode RetrieveAccessCode(int user_id, int booking_id)
        {
            return AccessCodeDA.RetrieveAccessCode(user_id, booking_id);
        }

        public AccessCode.Status RetrieveStatus(int user_id, int booking_id)
        {
            return AccessCodeDA.RetrieveStatus(user_id, booking_id);
        }

        public bool ValidateBookingCode(string code, int booking_id)
        {
            return AccessCodeDA.ValidateBookingCode(code, booking_id);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public string GenerateCodeAndSend(int user_id, int booking_id)
        {
            User u = (User)UserDA.GetInstance().Recover(user_id);

            string code = RandomString(10);
            EmailServiceController.SendEmailAccessCode(u.Email, code);
            AccessCode accessCode = new AccessCode(booking_id, user_id, code, AccessCode.Status.Sent);
            InsertAccessCode(accessCode);
            return code;
        }
    }
}