using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FacilityScheduler.Core.Models;
using System.Runtime.CompilerServices;
using static FacilityScheduler.AccessCode;

namespace FacilityScheduler.Core.DA
{
    public class AccessCodeDA : AbstractDA
    {
        private static AccessCodeDA Instance;

        public static AccessCodeDA GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AccessCodeDA();
            }
            return Instance;
        }


        public override SqlParameter[] GetDAParameters(string[] values)
        {
            SqlParameter[] parameters = new SqlParameter[values.Length];

            parameters[0] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
            parameters[1] = new SqlParameter() { ParameterName = "@booking_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[1] };
            parameters[2] = new SqlParameter() { ParameterName = "@verification_code", SqlDbType = System.Data.SqlDbType.NChar, Value = values[2] };
            parameters[3] = new SqlParameter() { ParameterName = "@status", SqlDbType = System.Data.SqlDbType.NChar, Value = values[3] };

            return parameters;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertAccessCode(AccessCode accessCode)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.Int, Value = accessCode.user_id };
            parameters[1] = new SqlParameter() { ParameterName = "@booking_id", SqlDbType = System.Data.SqlDbType.Int, Value = accessCode.booking_id };
            parameters[2] = new SqlParameter() { ParameterName = "@verification_code", SqlDbType = System.Data.SqlDbType.NChar, Value = accessCode.accessCode };
            parameters[3] = new SqlParameter() { ParameterName = "@status", SqlDbType = System.Data.SqlDbType.NChar, Value = accessCode.status.ToString() };

            InsertUsingTransaction(parameters);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateAccessCode(AccessCode accessCode)
        {
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.NChar, Value = accessCode.user_id };
            parameters[1] = new SqlParameter() { ParameterName = "@booking_id", SqlDbType = System.Data.SqlDbType.NChar, Value = accessCode.booking_id };
            parameters[2] = new SqlParameter() { ParameterName = "@verification_code", SqlDbType = System.Data.SqlDbType.NChar, Value = accessCode.accessCode };
            parameters[3] = new SqlParameter() { ParameterName = "@status", SqlDbType = System.Data.SqlDbType.NChar, Value = accessCode.status.ToString() };

            UpdateUsingTransaction(parameters, accessCode.Id);
        }


        public bool ValidateBookingCode(string code, int booking_id)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from [dbo].[UserVerification] " +
                " where rtrim(LOWER(verification_code)) = rtrim(LOWER(@code)) " +
                " AND booking_id = @booking_id" +
                ";", connection);
            command.Parameters.Add("@code", System.Data.SqlDbType.VarChar);
            command.Parameters["@code"].Value = code;

            command.Parameters.Add("@booking_id", System.Data.SqlDbType.Int);
            command.Parameters["@booking_id"].Value = booking_id;
            connection.Open();
            exists = (int)command.ExecuteScalar() > 0;
            connection.Close();
            return exists;
        }

        public bool ExistsAccessCode(int user_id, int booking_id)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from [dbo].[UserVerification] " +
                " where user_id = @user_id " +
                " AND booking_id = @booking_id" +
                ";", connection);
            command.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            command.Parameters["@user_id"].Value = user_id;

            command.Parameters.Add("@booking_id", System.Data.SqlDbType.Int);
            command.Parameters["@booking_id"].Value = booking_id;
            connection.Open();
            exists = (int)command.ExecuteScalar() > 0;
            connection.Close();
            return exists;
        }

        public AccessCode RetrieveAccessCode(int user_id, int booking_id)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select * from [dbo].[UserVerification] " +
                " where user_id = @user_id " +
                " AND booking_id = @booking_id" +
                ";", connection);
            command.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            command.Parameters["@user_id"].Value = user_id;

            command.Parameters.Add("@booking_id", System.Data.SqlDbType.Int);
            command.Parameters["@booking_id"].Value = booking_id;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            AccessCode ac = null;
            if (reader.Read())
            {
                ac = (AccessCode)CreateObject(reader);
            }

            reader.Close();
            connection.Close();
            return ac;
        }

        public Status RetrieveStatus(int user_id, int booking_id)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select status from [dbo].[UserVerification] " +
                " where user_id = @user_id " +
                " AND booking_id = @booking_id" +
                ";", connection);
            command.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            command.Parameters["@user_id"].Value = user_id;

            command.Parameters.Add("@booking_id", System.Data.SqlDbType.Int);
            command.Parameters["@booking_id"].Value = booking_id;
            connection.Open();
            string status = (string)command.ExecuteScalar();
            connection.Close();
            return AccessCode.ConvertStatus(status);
        }

        public override string GetTableName()
        {
            return "[dbo].[UserVerification]";
        }

        public override string GetTableKeyName()
        {
            return "Id";
        }

        public override string GetColumns()
        {
            return "user_id, booking_id, verification_code, status";
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteAccessCode(int id)
        {
            DeleteUsingTransaction(id);
        }

        public override Object CreateObject(SqlDataReader reader)
        {
            return new AccessCode((int)reader["Id"], (int)reader["booking_id"], (int)reader["user_id"],
                (string)reader["verification_code"], AccessCode.ConvertStatus((string)reader["status"]));
        }
    }
}