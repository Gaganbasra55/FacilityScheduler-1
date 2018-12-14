using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FacilityScheduler.Core.Models;
using System.Runtime.CompilerServices;

namespace FacilityScheduler.Core.DA
{
    public class BookingDA : AbstractDA
    {
        private static BookingDA Instance;

        public static BookingDA GetInstance()
        {
            if (Instance == null)
            {
                Instance = new BookingDA();
            }
            return Instance;
        }


        public override SqlParameter[] GetDAParameters(string[] values)
        {
            SqlParameter[] parameters = new SqlParameter[values.Length];

            parameters[0] = new SqlParameter() { ParameterName = "@booking_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
            parameters[1] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[1] };
            parameters[2] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[2] };
            parameters[3] = new SqlParameter() { ParameterName = "@date", SqlDbType = System.Data.SqlDbType.DateTime, Value = values[3] };
            parameters[4] = new SqlParameter() { ParameterName = "@time_start", SqlDbType = System.Data.SqlDbType.Time, Value = values[4] };
            parameters[5] = new SqlParameter() { ParameterName = "@time_slots", SqlDbType = System.Data.SqlDbType.Int, Value = values[5] };

            return parameters;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertBooking(Booking Booking)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = Booking.facility_id };
            parameters[1] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.Int, Value = Booking.user_id };
            parameters[2] = new SqlParameter() { ParameterName = "@date", SqlDbType = System.Data.SqlDbType.DateTime, Value = Booking.date };
            parameters[3] = new SqlParameter() { ParameterName = "@time_start", SqlDbType = System.Data.SqlDbType.Time, Value = Booking.time_start };
            parameters[4] = new SqlParameter() { ParameterName = "@time_slots", SqlDbType = System.Data.SqlDbType.Int, Value = Booking.time_slots };

            InsertUsingTransaction(parameters);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateBooking(Booking Booking)
        {
            SqlParameter[] parameters = new SqlParameter[5];
            parameters[0] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = Booking.facility_id };
            parameters[1] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.Int, Value = Booking.user_id };
            parameters[2] = new SqlParameter() { ParameterName = "@date", SqlDbType = System.Data.SqlDbType.DateTime, Value = Booking.date };
            parameters[3] = new SqlParameter() { ParameterName = "@time_start", SqlDbType = System.Data.SqlDbType.Time, Value = Booking.time_start };
            parameters[4] = new SqlParameter() { ParameterName = "@time_slots", SqlDbType = System.Data.SqlDbType.Int, Value = Booking.time_slots };

            UpdateUsingTransaction(parameters, Booking.booking_id);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteBooking(int id)
        {
            DeleteUsingTransaction(id);
        }

        public List<Booking> SearchBooking(DateTime date)
        {
            List<Booking> list = new List<Booking>();
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            string query = "select * from " + GetTableName() + " where date = @date order by date;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@date", System.Data.SqlDbType.Date);
            command.Parameters["@date"].Value = date;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add((Booking)CreateObject(reader));
            }

            reader.Close();
            connection.Close();
            return list;
        }

        public List<Booking> SearchBooking(int user_id, DateTime date, DateTime dateEnd)
        {
            List<Booking> list = new List<Booking>();
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            string query = "select * from " + GetTableName() + " where date >= @date " +
                " AND date < @dateEnd " +
                " AND user_id = @user_id" +
                " order by date;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@date", System.Data.SqlDbType.Date);
            command.Parameters["@date"].Value = date;

            command.Parameters.Add("@dateEnd", System.Data.SqlDbType.Date);
            command.Parameters["@dateEnd"].Value = dateEnd;

            command.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            command.Parameters["@user_id"].Value = user_id;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add((Booking)CreateObject(reader));
            }

            reader.Close();
            connection.Close();
            return list;
        }

        public override string GetTableName()
        {
            return "[dbo].[Booking]";
        }

        public override string GetTableKeyName()
        {
            return "booking_id";
        }

        public override string GetColumns()
        {
            return "facility_id, user_id, date, time_start, time_slots";
        }

        public override Object CreateObject(SqlDataReader reader)
        {
            return new Booking((int)reader["booking_id"], (int)reader["facility_id"], (int)reader["user_id"],
                (DateTime)reader["date"], (TimeSpan)reader["time_start"],
                (int)reader["time_slots"]);
        }
    }
}