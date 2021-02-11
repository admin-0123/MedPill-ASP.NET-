using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Entity
{
    public class displayPatient
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Verified { get; set; }
        public string IsCaretaker { get; set; }
        public displayPatient()
        {

        }
        public displayPatient(string name, string email, string phoneno, string verified, string iscaretaker)
        {
            Name = name;
            Email = email;
            PhoneNo = phoneno;
            Verified = verified;
            IsCaretaker = iscaretaker;
        }
        public displayPatient PatientDisplayByEmail(string email)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [User] where Email = @paraEmail";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraEmail", email);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            displayPatient user = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Verified = row["Verified"].ToString();
                string IsCaretaker = row["IsCaretaker"].ToString();

                user = new displayPatient(Name, Email, PhoneNo, Verified, IsCaretaker);
            }
            return user;
        }
        public List<displayPatient> DisplayAllPatients()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Role = @Role AND IsDeleted = 'No'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Role", "Patient");
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<displayPatient> userList = new List<displayPatient>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Verified = row["Verified"].ToString();
                string IsCaretaker = row["IsCaretaker"].ToString();

                displayPatient obj = new displayPatient(Name, Email, PhoneNo, Verified, IsCaretaker);
                userList.Add(obj);
            }
            return userList;
        }
        public List<displayPatient> DisplayAllCaretakers()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Role = @Role AND IsDeleted = 'No' AND IsCaretaker = 'Yes'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Role", "Patient");
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<displayPatient> userList = new List<displayPatient>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Verified = row["Verified"].ToString();
                string IsCaretaker = row["IsCaretaker"].ToString();

                displayPatient obj = new displayPatient(Name, Email, PhoneNo, Verified, IsCaretaker);
                userList.Add(obj);
            }
            return userList;
        }
        public List<displayPatient> DisplayAllPatientsOnly()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Role = @Role AND IsDeleted = 'No' AND IsCaretaker = 'Yes'";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Role", "Patient");
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<displayPatient> userList = new List<displayPatient>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Verified = row["Verified"].ToString();
                string IsCaretaker = row["IsCaretaker"].ToString();

                displayPatient obj = new displayPatient(Name, Email, PhoneNo, Verified, IsCaretaker);
                userList.Add(obj);
            }
            return userList;
        }
        public List<displayPatient> DisplayAllSearchPatients(string name)
        {
            name = name + "%";
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from [User] WHERE Role = @Role AND IsDeleted = 'No' AND Name LIKE @Name";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Role", "Patient");
            da.SelectCommand.Parameters.AddWithValue("@Name", name);
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<displayPatient> userList = new List<displayPatient>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Name = row["Name"].ToString();
                string Email = row["Email"].ToString();
                string PhoneNo = row["PhoneNo"].ToString();
                string Verified = row["Verified"].ToString();
                string IsCaretaker = row["IsCaretaker"].ToString();

                displayPatient obj = new displayPatient(Name, Email, PhoneNo, Verified, IsCaretaker);
                userList.Add(obj);
            }
            return userList;
        }
    }
}
