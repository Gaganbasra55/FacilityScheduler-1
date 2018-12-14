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
    public class AccessController
    {
        private static Random random = new Random();

        private static AccessController Instance;

        private AccessDA AccessDA;

        public static AccessController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AccessController();
            }
            return Instance;
        }

        AccessController()
        {
            AccessDA = AccessDA.GetInstance();
        }

        public Access Recover(int id)
        {
            return (Access)AccessDA.Recover(id);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertAccess(Access access)
        {
            AccessDA.openConnection();
            SqlTransaction transaction = AccessDA.BeginTransaction();
            try
            {
                //insert the access
                AccessDA.InsertAccess(access);
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
                AccessDA.closeConnection();
            }
        }



        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateAccess(Access access)
        {
            AccessDA.openConnection();
            SqlTransaction transaction = AccessDA.BeginTransaction();
            try
            {
                //update the access
                AccessDA.UpdateAccess(access);
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
                AccessDA.closeConnection();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteAccess(int id)
        {
            AccessDA.openConnection();
            SqlTransaction transaction = AccessDA.BeginTransaction();
            try
            {
                //delete the access
                AccessDA.DeleteAccess(id);
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
                AccessDA.closeConnection();
            }
        }

        public bool ExistsAccess(int facility_id, string role)
        {
            return AccessDA.ExistsAccess(facility_id, role);
        }

        public Access RetrieveAccess(int facility_id, string role)
        {
            return AccessDA.RetrieveAccess(facility_id, role);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public Access RetrieveAccessCreateIfNotExists(int facility_id, string role)
        {
            Access access = AccessDA.RetrieveAccess(facility_id, role);
            if (access == null)
            {
                access = new Access(facility_id, true, role);
                InsertAccess(access);
                return AccessDA.RetrieveAccess(facility_id, role); ;
            } else
            {
                return access;
            }
        }
    }
}