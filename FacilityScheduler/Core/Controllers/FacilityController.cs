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


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertFacility(string Name, int timeSlot, DateTime StartTime, DateTime EndTime)
        {
            FacilityDA.openConnection();
            SqlTransaction transaction = FacilityDA.BeginTransaction();
            try
            {
                //insert the facility
                FacilityDA.InsertFacility(new Facility(Name, timeSlot, StartTime, EndTime));
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
    }
}