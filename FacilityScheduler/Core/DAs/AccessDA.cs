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
    public class AccessDA : AbstractDA
    {
        private static AccessDA Instance;

        public static AccessDA GetInstance()
        {
            if (Instance == null)
            {
                Instance = new AccessDA();
            }
            return Instance;
        }


        public override SqlParameter[] GetDAParameters(string[] values)
        {
            SqlParameter[] parameters = new SqlParameter[values.Length];

            parameters[0] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
            parameters[1] = new SqlParameter() { ParameterName = "@granted", SqlDbType = System.Data.SqlDbType.Bit, Value = values[1] };
            parameters[2] = new SqlParameter() { ParameterName = "@role", SqlDbType = System.Data.SqlDbType.NChar, Value = values[2] };

            return parameters;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertAccess(Access access)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = access.facility_id };
            parameters[1] = new SqlParameter() { ParameterName = "@granted", SqlDbType = System.Data.SqlDbType.Bit, Value = access.granted };
            parameters[2] = new SqlParameter() { ParameterName = "@role", SqlDbType = System.Data.SqlDbType.NChar, Value = access.role };

            InsertUsingTransaction(parameters);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateAccess(Access access)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter() { ParameterName = "@facility_id", SqlDbType = System.Data.SqlDbType.Int, Value = access.facility_id };
            parameters[1] = new SqlParameter() { ParameterName = "@granted", SqlDbType = System.Data.SqlDbType.Bit, Value = access.granted };
            parameters[2] = new SqlParameter() { ParameterName = "@role", SqlDbType = System.Data.SqlDbType.NChar, Value = access.role };

            UpdateUsingTransaction(parameters, access.Id);
        }

        public bool ExistsAccess(int facility_id, string role)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from [dbo].[FacilityAccess] " +
                " where facility_id = @facility_id " +
                " AND rtrim(role) = rtrim(@role)" +
                ";", connection);
            command.Parameters.Add("@facility_id", System.Data.SqlDbType.Int);
            command.Parameters["@facility_id"].Value = facility_id;

            command.Parameters.Add("@role", System.Data.SqlDbType.NVarChar);
            command.Parameters["@role"].Value = role;
            connection.Open();
            exists = (int)command.ExecuteScalar() > 0;
            connection.Close();
            return exists;
        }

        public Access RetrieveAccess(int facility_id, string role)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select * from [dbo].[FacilityAccess] " +
                " where facility_id = @facility_id " +
                " AND rtrim(role) = rtrim(@role)" +
                ";", connection);
            command.Parameters.Add("@facility_id", System.Data.SqlDbType.Int);
            command.Parameters["@facility_id"].Value = facility_id;

            command.Parameters.Add("@role", System.Data.SqlDbType.NVarChar);
            command.Parameters["@role"].Value = role;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Access ac = null;
            if (reader.Read())
            {
                ac = (Access)CreateObject(reader);
            }

            reader.Close();
            connection.Close();
            return ac;
        }


        public override string GetTableName()
        {
            return "[dbo].[FacilityAccess]";
        }

        public override string GetTableKeyName()
        {
            return "Id";
        }

        public override string GetColumns()
        {
            return "facility_id, access_granted, role";
        }


        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteAccess(int id)
        {
            DeleteUsingTransaction(id);
        }

        public override Object CreateObject(SqlDataReader reader)
        {
            return new Access((int)reader["Id"], (int)reader["facility_id"], (bool)reader["access_granted"],
                (string)reader["role"]);
        }
    }
}