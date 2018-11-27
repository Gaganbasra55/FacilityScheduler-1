using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using FacilityScheduler.Core.Models;

namespace FacilityScheduler.Core.DA
{
    public abstract class AbstractDA
    {
        private static SqlTransaction transaction;
        private static SqlConnection connection;

        public abstract string GetTableName();
        public abstract string GetTableKeyName();
        public abstract string GetColumns();
        public abstract Object CreateObject(SqlDataReader reader);
        public abstract SqlParameter[] GetDAParameters(string[] values);

        public SqlConnection GetConection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            }
            return connection;
        }

        public void openConnection()
        {
            GetConection();
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void closeConnection()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public SqlTransaction BeginTransaction()
        {
            if (connection == null)
            {
                openConnection();
            }
            transaction = connection.BeginTransaction();
            return transaction;
        }

        public Object Recover(int id)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select * from " + GetTableName() + " where " + GetTableKeyName() + " = @id;", connection);
            command.Parameters.Add("@id", System.Data.SqlDbType.Int);
            command.Parameters["@id"].Value = id;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            Object obj = null;
            if (reader.Read())
            {
                obj = CreateObject(reader);
            }

            reader.Close();
            connection.Close();
            return obj;
        }

        public void InsertUsingTransaction(SqlParameter[] parameters)
        {
            string par;
            object val;

            string parametersInsert = "";
            int count = 0;
            foreach (SqlParameter parameter in parameters)
            {
                par = parameter.ParameterName;
                val = parameter.Value;
                parametersInsert += par;
                count++;
                if (count < parameters.Length)
                {
                    parametersInsert += ",";
                }
                //command.Parameters.Add(parameter);
            }
            SqlCommand command = new SqlCommand(
                "Insert into " + GetTableName() + " (" + GetColumns() + ") values (" + parametersInsert + ")", connection);
            command.Parameters.AddRange(parameters);

            command.Transaction = transaction;

            command.ExecuteNonQuery();

        }

        public void UpdateUsingTransaction(SqlParameter[] parameters, int id)
        {
            string par;
            string[] columns = GetColumns().Split(',');
            string parametersUpdate = "";
            int count = 0;
            foreach (SqlParameter parameter in parameters)
            {
                par = parameter.ParameterName;
                parametersUpdate += columns[count] + " = " + par;
                if (count < parameters.Length - 1)
                {
                    parametersUpdate += ",";
                }
                count++;
            }
            SqlCommand command = new SqlCommand(
                "Update " + GetTableName() + 
                " set " + parametersUpdate + " where " + 
                GetTableKeyName() + " = @id;", connection);

            command.Parameters.AddRange(parameters);

            command.Parameters.Add("@id", System.Data.SqlDbType.Int);
            command.Parameters["@id"].Value = id;

            command.Transaction = transaction;

            command.ExecuteNonQuery();

        }

        public void DeleteUsingTransaction(int id)
        {            
            SqlCommand command = new SqlCommand(
                "Delete from " + GetTableName() + 
                " where " + 
                GetTableKeyName() + " = @id;", connection);

            command.Parameters.Add("@id", System.Data.SqlDbType.Int);
            command.Parameters["@id"].Value = id;

            command.Transaction = transaction;

            command.ExecuteNonQuery();
        }

        public void Insert(SqlParameter[] parameters)
        {
            string par;
            object val;

            string parametersInsert = "";
            int count = 0;
            foreach (SqlParameter parameter in parameters)
            {
                par = parameter.ParameterName;
                val = parameter.Value;
                parametersInsert += par;
                count++;
                if (count < parameters.Length)
                {
                    parametersInsert += ",";
                }
                //command.Parameters.Add(parameter);
            }
            SqlCommand command = new SqlCommand(
                "Insert into " + GetTableName() + " (" + GetColumns() + ") values (" + parametersInsert + ")", connection);
            command.Parameters.AddRange(parameters);

            openConnection();
            command.ExecuteNonQuery();
            closeConnection();
        }

        public int GetNextValue()
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("Select coalesce (max(" + GetTableKeyName() + "),0 ) as Id from " + GetTableName() + ";", connection);
            connection.Open();
            int nextId = (int)command.ExecuteScalar() + 1;
            connection.Close();
            return nextId;
        }

    }
}