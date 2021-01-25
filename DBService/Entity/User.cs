using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Add


using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBService.Entity
{
    public class User
    {
        // Let all properties start with caps
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Role { get; set; }
        public string Verified { get; set; }

        public User()
        {

        }

        public User(string id, string name, string password, string salt, string email, string phoneno, string role, string verified)
        {
            Id = id;
            Name = name;
            Password = password;
            Salt = salt;
            Email = email;
            PhoneNo = phoneno;
            Role = role;
            Verified = verified;

        }
        public User SelectByID(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [User] where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            User user = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Password = row["Password"].ToString();
                string Salt = row["Salt"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Role = row["Role"].ToString();
                string Verified = row["Verified"].ToString();

                user = new User(Id, Name, Password, Salt, Email, PhoneNo, Role, Verified);
            }
            return user;
        }
        public User SelectByEmail(string email)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            User user = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Password = row["Password"].ToString();
                string Salt = row["Salt"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Role = row["Role"].ToString();
                string Verified = row["Verified"].ToString();

                user = new User(Id, Name, Password, Salt, Email, PhoneNo, Role, Verified);
            }
            return user;
        }
        public int UpdateUser(string id, string name, string email, string mobile)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStatement = "UPDATE [User] SET Name = @Name, Email= @Email, PhoneNo = @PhoneNo  WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@PhoneNo", mobile);
            myConn.Open();
            int result = cmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }
        public int CheckUser(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStatement = "Select * from [User] WHERE Email = @paraEmail";
            SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
            cmd.Parameters.AddWithValue("@paraEmail", email);
            myConn.Open();
            int result = cmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }
        public int DeleteUser(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStatement = "DELETE FROM [User] WHERE Id = @id";
            SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
            cmd.Parameters.AddWithValue("@id", id);
            myConn.Open();
            int result = cmd.ExecuteNonQuery();
            myConn.Close();
            return result;

        }
        public List<User> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User]";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<User> userList = new List<User>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string Name = row["Name"].ToString();
                string Password = row["Password"].ToString();
                string Salt = row["Salt"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Role = row["Role"].ToString();
                string Verified = row["Verified"].ToString();

                User obj = new User(Id, Name, Password, Salt, Email, PhoneNo, Role, Verified);
                userList.Add(obj);
            }
            return userList;
        }

        public List<User> SelectAllPatients()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Role = @Role";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Role", "Patient");
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<User> userList = new List<User>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string Name = row["Name"].ToString();
                string Password = row["Password"].ToString();
                string Salt = row["Salt"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Role = row["Role"].ToString();
                string Verified = row["Verified"].ToString();

                User obj = new User(Id, Name, Password, Salt, Email, PhoneNo, Role, Verified);
                userList.Add(obj);
            }
            return userList;
        }
        public List<User> SelectAllEmployees()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Role = @Role or Role = @Role2 or Role = @Role3";

            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Role", "Nurse");
            da.SelectCommand.Parameters.AddWithValue("@Role2", "Receptionist");
            da.SelectCommand.Parameters.AddWithValue("@Role3", "Doctor");
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<User> userList = new List<User>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string Name = row["Name"].ToString();
                string Password = row["Password"].ToString();
                string Salt = row["Salt"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Role = row["Role"].ToString();
                string Verified = row["Verified"].ToString();

                User obj = new User(Id, Name, Password, Salt, Email, PhoneNo, Role, Verified);
                userList.Add(obj);
            }
            return userList;
        }




    }
}