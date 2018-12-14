using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using FacilityScheduler.Core.Models;
using System.Runtime.CompilerServices;

namespace FacilityScheduler.Core.DA
{
    public class UserDA : AbstractDA
    {
        private static UserDA Instance;

        public static UserDA GetInstance()
        {
            if (Instance == null)
            {
                Instance = new UserDA();
            }
            return Instance;
        }


        public override SqlParameter[] GetDAParameters(string[] values)
        {
            SqlParameter[] parameters = new SqlParameter[values.Length];

            parameters[0] = new SqlParameter() { ParameterName = "@user_id", SqlDbType = System.Data.SqlDbType.Int, Value = values[0] };
            parameters[1] = new SqlParameter() { ParameterName = "@firstname", SqlDbType = System.Data.SqlDbType.NChar, Value = values[1] };
            parameters[2] = new SqlParameter() { ParameterName = "@lastname", SqlDbType = System.Data.SqlDbType.NChar, Value = values[2] };
            parameters[3] = new SqlParameter() { ParameterName = "@email", SqlDbType = System.Data.SqlDbType.NChar, Value = values[3] };
            parameters[4] = new SqlParameter() { ParameterName = "@category", SqlDbType = System.Data.SqlDbType.NChar, Value = values[4] };
            parameters[5] = new SqlParameter() { ParameterName = "@password", SqlDbType = System.Data.SqlDbType.NChar, Value = values[5] };
            parameters[6] = new SqlParameter() { ParameterName = "@admin_verified", SqlDbType = System.Data.SqlDbType.Bit, Value = values[6] };

            return parameters;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void InsertUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter() { ParameterName = "@firstname", SqlDbType = System.Data.SqlDbType.NChar, Value = user.FirstName };
            parameters[1] = new SqlParameter() { ParameterName = "@lastname", SqlDbType = System.Data.SqlDbType.NChar, Value = user.LastName };
            parameters[2] = new SqlParameter() { ParameterName = "@email", SqlDbType = System.Data.SqlDbType.NChar, Value = user.Email };
            parameters[3] = new SqlParameter() { ParameterName = "@category", SqlDbType = System.Data.SqlDbType.NChar, Value = user.category };
            parameters[4] = new SqlParameter() { ParameterName = "@password", SqlDbType = System.Data.SqlDbType.NChar, Value = user.Password };
            parameters[5] = new SqlParameter() { ParameterName = "@admin_verified", SqlDbType = System.Data.SqlDbType.Bit, Value = user.Verified };

            InsertUsingTransaction(parameters);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void UpdateUser(User user)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter() { ParameterName = "@firstname", SqlDbType = System.Data.SqlDbType.NChar, Value = user.FirstName };
            parameters[1] = new SqlParameter() { ParameterName = "@lastname", SqlDbType = System.Data.SqlDbType.NChar, Value = user.LastName };
            parameters[2] = new SqlParameter() { ParameterName = "@email", SqlDbType = System.Data.SqlDbType.NChar, Value = user.Email };
            parameters[3] = new SqlParameter() { ParameterName = "@category", SqlDbType = System.Data.SqlDbType.NChar, Value = user.category };
            parameters[4] = new SqlParameter() { ParameterName = "@password", SqlDbType = System.Data.SqlDbType.NChar, Value = user.Password };
            parameters[5] = new SqlParameter() { ParameterName = "@admin_verified", SqlDbType = System.Data.SqlDbType.Bit, Value = user.Verified };

            UpdateUsingTransaction(parameters, user.Id);
        }

        public User RecoverUser(string email, string password)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select * from [dbo].[Users] where rtrim(email) = rtrim(@email) and rtrim(password)= rtrim(@password);", connection);
            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = email;
            command.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            command.Parameters["@password"].Value = password;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            User account = null;
            if (reader.Read())
            {
                return new User((int)reader["user_id"], (string)reader["email"], (string)reader["password"], (string)reader["firstname"],
                (string)reader["lastname"], User.ConvertCategory((string)reader["category"]), (bool)reader["admin_verified"]);
            }

            reader.Close();
            connection.Close();
            return account;
        }

        public User RecoverUser(string email)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select * from [dbo].[Users] where rtrim(email) = rtrim(@email);", connection);
            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = email;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            User account = null;
            if (reader.Read())
            {
                return new User((int)reader["user_id"], (string)reader["email"], (string)reader["password"], (string)reader["firstname"],
                (string)reader["lastname"], User.ConvertCategory((string)reader["category"]), (bool)reader["admin_verified"]);
            }

            reader.Close();
            connection.Close();
            return account;
        }

        public bool ValidateUser(string user, string password)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from [dbo].[Users] where rtrim(email) = rtrim(@email) and rtrim(password)= rtrim(@password);", connection);
            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = user;
            command.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            command.Parameters["@password"].Value = password;
            connection.Open();
            exists = (int)command.ExecuteScalar() > 0;
            connection.Close();
            return exists;
        }

        public bool ExistsEmail(string email)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from [dbo].[Users] where rtrim(LOWER(email)) = rtrim(LOWER(@email));", connection);
            command.Parameters.Add("@email", System.Data.SqlDbType.VarChar);
            command.Parameters["@email"].Value = email;
            connection.Open();
            exists = (int)command.ExecuteScalar() > 0;
            connection.Close();
            return exists;
        }

        public bool ExistsPassword(string password)
        {
            bool exists = false;
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            SqlCommand command = new SqlCommand("select count(*) from [dbo].[Users] where rtrim(LOWER(password)) = rtrim(LOWER(@password));", connection);
            command.Parameters.Add("@password", System.Data.SqlDbType.VarChar);
            command.Parameters["@password"].Value = password;
            connection.Open();
            exists = (int)command.ExecuteScalar() > 0;
            connection.Close();
            return exists;
        }

        public override string GetTableName()
        {
            return "[dbo].[Users]";
        }

        public override string GetTableKeyName()
        {
            return "user_id";
        }

        public override string GetColumns()
        {
            return "firstname, lastname, email, category, password, admin_verified";
        }

        public override Object CreateObject(SqlDataReader reader)
        {
            return new User((int)reader["user_id"], (string)reader["email"],
                (string)reader["firstname"], (string)reader["lastname"],
                (string)reader["password"], User.ConvertCategory((string)reader["category"]), (bool)reader["admin_verified"]);
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public void DeleteUserAccount(int id)
        {
            DeleteUsingTransaction(id);
        }

        public List<User> SearchUserAccount(string category, bool verified, string argument)
        {
            List<User> list = new List<User>();
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            string query;
            bool validArgs = argument != null && argument.Length > 0;
            bool validCategory = category != null && category.Length > 0;
            if (validArgs)
            {
                query = "select * from " + GetTableName() + " where " +
                    " (firstname like rtrim(@name) " +
                    " OR lastname like rtrim(@name) " +
                    " OR email like rtrim(@name)) ";
            }
            else
            {
                query = "select * from " + GetTableName() + " where " + 
                    "1 = 1 ";

            }
            if (validCategory)
            {
                query = query +
                " AND rtrim(category) like rtrim(@category) ";
            }

            query = query +
            " AND admin_verified = @verified " +
            ";";

            SqlCommand command = new SqlCommand(query, connection);
            if (validArgs)
            {
                command.Parameters.Add("@name", System.Data.SqlDbType.NChar);
                command.Parameters["@name"].Value = "%" + argument + "%";
            }

            if (validCategory)
            {
                command.Parameters.Add("@category", System.Data.SqlDbType.NChar);
                command.Parameters["@category"].Value = "%" + category + "%";
            }

            command.Parameters.Add("@verified", System.Data.SqlDbType.Bit);
            command.Parameters["@verified"].Value = verified ? 1 : 0;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add((User)CreateObject(reader));
            }

            reader.Close();
            connection.Close();
            return list;
        }

        public string GetUserName(int key)
        {
            SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionStringSQL"].ConnectionString);
            string query = "select firstname, lastname  from " + GetTableName() + " where user_id = @user_id;";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Add("@user_id", System.Data.SqlDbType.Int);
            command.Parameters["@user_id"].Value = key;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            string name = "";
            if (reader.Read())
            {
                name = (string)reader["firstname"] + " " + (string)reader["lastname"];
            }

            reader.Close();
            connection.Close();
            return name;
        }
    }
}