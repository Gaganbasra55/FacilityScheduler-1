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
    public class FacilityController
    {

        private static FacilityController Instance;

        private FacilityDA FacilityDA;

        public static FacilityController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FacilityController();
            }
            return Instance;
        }

        FacilityController()
        {
            FacilityDA = FacilityDA.GetInstance();
        }

        public Facility Recover(int id)
        {
            return (Facility) FacilityDA.Recover(id);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertFacility(Facility facility)
        {
            FacilityDA.openConnection();
            SqlTransaction transaction = FacilityDA.BeginTransaction();
            try
            {
                //insert the facility
                FacilityDA.InsertFacility(facility);
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
                FacilityDA.closeConnection();
            }
        }



        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateFacility(Facility facility)
        {
            FacilityDA.openConnection();
            SqlTransaction transaction = FacilityDA.BeginTransaction();
            try
            {
                //update the facility
                FacilityDA.UpdateFacility(facility);
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
                FacilityDA.closeConnection();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteFacility(int id)
        {
            FacilityDA.openConnection();
            SqlTransaction transaction = FacilityDA.BeginTransaction();
            try
            {
                //delete the facility
                FacilityDA.DeleteFacility(id);
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
                FacilityDA.closeConnection();
            }
        }

        public List<Facility> SearchFacility (string argument)
        {
            return FacilityDA.GetInstance().SearchFacility(argument);
        }
    }
}