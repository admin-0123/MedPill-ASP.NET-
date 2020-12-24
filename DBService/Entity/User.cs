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
        public string Job { get; set; }

        public User()
        {

        }

        public User(string id, string name, string job)
        {
            Id = id;
            Name = name;
            Job = job;
        }

        public User SelectByNric(string nric)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from User where id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", Id);

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
                string Job = row["Job"].ToString();

                /*                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                                string name = row["name"].ToString();
                                DateTime dob = Convert.ToDateTime(row["birthdate"].ToString());
                                string dept = row["department"].ToString();
                                string payStr = row["mthlySalary"].ToString();
                                double pay = Convert.ToDouble(payStr);*/
                user = new User(Id, Name, Job);
            }
            return user;
        }
        public List<User> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from User";
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
                string Job = row["Job"].ToString();
                /*                string nric = row["nric"].ToString();
                                string name = row["name"].ToString();
                                DateTime dob = Convert.ToDateTime(row["birthdate"].ToString());
                                string dept = row["department"].ToString();
                                string payStr = row["mthlySalary"].ToString();
                                double pay = Convert.ToDouble(payStr);*/
                User obj = new User(Id, Name, Job);
                userList.Add(obj);
            }
            return userList;
        }



    }
}