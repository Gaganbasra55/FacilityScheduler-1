using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FacilityScheduler.Core.Models;
using System.Runtime.CompilerServices;

namespace FacilityScheduler.Core.DA
{
    public class FacilityDA : AbstractDA
    {
        private static FacilityDA Instance;

        public static FacilityDA GetInstance()
        {
            if (Instance == null)
            {
                Instance = new FacilityDA();
            }
            return Instance;
        }


        public override SqlParameter[] GetDAParameters(string[] values)
        {
            SqlParameter[] parameters = new SqlParameter[values.Length];

            parameters[0] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
            parameters[1] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.NChar, Value = values[1] };
            parameters[2] = new SqlParameter() { ParameterName = "@time_slot_length", SqlDbType = System.Data.SqlDbType.Int, Value = values[2] };
            parameters[3] = new SqlParameter() { ParameterName = "@day_start_time", SqlDbType = System.Data.SqlDbType.Time, Value = values[3] };
            parameters[4] = new SqlParameter() { ParameterName = "@day_end_time", SqlDbType = System.Data.SqlDbType.Time, Value = values[4] };

            return parameters;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertFacility(Facility Facility)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.NChar, Value = Facility.Name };
            parameters[1] = new SqlParameter() { ParameterName = "@time_slot_length", SqlDbType = System.Data.SqlDbType.NChar, Value = Facility.timeSlot };
            parameters[2] = new SqlParameter() { ParameterName = "@day_start_time", SqlDbType = System.Data.SqlDbType.Time, Value = FacilityUtil.ConvertDateTimeToTimeString(Facility.StartTime) };
            parameters[3] = new SqlParameter() { ParameterName = "@day_end_time", SqlDbType = System.Data.SqlDbType.Time, Value = FacilityUtil.ConvertDateTimeToTimeString(Facility.EndTime) };

            InsertUsingTransaction(parameters);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateFacility(Facility Facility)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter() { ParameterName = "@name", SqlDbType = System.Data.SqlDbType.NChar, Value = Facility.Name };
            parameters[1] = new SqlParameter() { ParameterName = "@time_slot_length", SqlDbType = System.Data.SqlDbType.NChar, Value = Facility.timeSlot };
            parameters[2] = new SqlParameter() { ParameterName = "@day_start_time", SqlDbType = System.Data.SqlDbType.Time, Value = FacilityUtil.ConvertDateTimeToTimeString(Facility.StartTime) };
            parameters[3] = new SqlParameter() { ParameterName = "@day_end_time", SqlDbType = System.Data.SqlDbType.Time, Value = FacilityUtil.ConvertDateTimeToTimeString(Facility.EndTime) };

            UpdateUsingTransaction(parameters, Facility.Id);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteFacility(int id)
        {
            DeleteUsingTransaction(id);
        }

        public List<Facility> SearchFacility(string argument)
        {
            List<Facility> list = new List<Facility>();
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            string query;
            bool validArgs = argument != null && argument.Length > 0;
            if (validArgs)
            {
                query = "select * from " + GetTableName() + " where name like @name;";
            } else
            {
                query = "select * from " + GetTableName() + ";";
            }
            SqlCommand command = new SqlCommand(query, connection);
            if(validArgs)
            {
                command.Parameters.Add("@name", System.Data.SqlDbType.NChar);
                command.Parameters["@name"].Value = "%" + argument+ "%";
            }

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add((Facility)CreateObject(reader));
            }

            reader.Close();
            connection.Close();
            return list;
        }

        public override string GetTableName()
        {
            return "[dbo].[Facility]";
        }

        public override string GetTableKeyName()
        {
            return "facility_id";
        }

        public override string GetColumns()
        {
            return "name, time_slot_length, day_start_time, day_end_time";
        }

        public override Object CreateObject(SqlDataReader reader)
        {
            return new Facility((int)reader["facility_id"], (string)reader["name"],
                (int)reader["time_slot_length"], FacilityUtil.ConvertTimeStringToDateTime(((TimeSpan)reader["day_start_time"]).ToString()),
                FacilityUtil.ConvertTimeStringToDateTime(((TimeSpan)reader["day_end_time"]).ToString()));
        }
    }
}