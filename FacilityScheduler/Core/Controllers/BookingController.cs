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
    public class BookingController
    {
        private static BookingController Instance;

        private BookingDA BookingDA;

        public static BookingController GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BookingController();
            }
            return Instance;
        }

        BookingController()
        {
            BookingDA = BookingDA.GetInstance();
        }

        public Booking Recover(int id)
        {
            return (Booking) BookingDA.Recover(id);
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertBooking(Booking booking)
        {
            BookingDA.openConnection();
            SqlTransaction transaction = BookingDA.BeginTransaction();
            try
            {
                //insert the booking
                BookingDA.InsertBooking(booking);
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
                BookingDA.closeConnection();
            }
        }



        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateBooking(Booking booking)
        {
            BookingDA.openConnection();
            SqlTransaction transaction = BookingDA.BeginTransaction();
            try
            {
                //update the booking
                BookingDA.UpdateBooking(booking);
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
                BookingDA.closeConnection();
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteBooking(int id)
        {
            BookingDA.openConnection();
            SqlTransaction transaction = BookingDA.BeginTransaction();
            try
            {
                //delete the booking
                BookingDA.DeleteBooking(id);
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
                BookingDA.closeConnection();
            }
        }

        public List<Booking> SearchBooking (DateTime date)
        {
            return BookingDA.GetInstance().SearchBooking(date);
        }

        public List<Booking> SearchBooking (int user_id, DateTime date, DateTime dateEnd)
        {
            return BookingDA.GetInstance().SearchBooking(user_id, date, dateEnd);
        }
    }
}