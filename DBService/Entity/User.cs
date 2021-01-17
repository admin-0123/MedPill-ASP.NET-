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
        // Non-Default Constructor (Mandatory properties recorded upon registration)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNo { get; set; }

        public string Photo { get; set; }

        public string Role { get; set; }

        public bool Verified { get; set; }

        // End

        //Optional Properties

        public int CareReceiverID { get; set; }

        public bool Certified_CG { get; set; }


        public User()
        {

        }

        public User(int id, string name, string password, string email, string phoneno, string photo, string role, bool verified, int crid, bool certified_CG)
        {
            Id = id;
            Name = name;
            Password = password;
            Email = email;
            PhoneNo = phoneno;
            Photo = photo;
            Role = role;
            Verified = verified;
            CareReceiverID = crid;
            Certified_CG = certified_CG;
        }

        public User SelectByID(int id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [User] where id = @paraId";
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
                int Id = Convert.ToInt32(row["Id"].ToString());
                string Name = row["name"].ToString();
                string Password = row["password"].ToString();
                string Email = row["email"].ToString();
                string PhoneNo = row["phoneno"].ToString();
                string Photo = row["photo"].ToString();
                string Role = row["role"].ToString();
                bool Verified = Convert.ToBoolean(Convert.ToInt32(row["verified"]));

                bool Certified_CG = Convert.ToBoolean(Convert.ToInt32(row["certified_CG"]));
                //bool Certified_CG = true;

                // Fixing problem where unable to retrieve the value of carereceiver column (where value always = 0 )
                // Make sure properties in non-default constructors do not have null value otherwise when you convert them will get a : 'Object cannot be cast from DBNull to other types.' error



                // Using the TryParse method to if carereceiverID is NULL
                // Then set the CareReceiverID accordingly, 0 if it is NULL
                int noCR; // noCR will be the resultant value set to either the valid value if not null or 0 if null
                bool haveCR = Int32.TryParse(row["carereceiverID"].ToString(), out noCR);
                if (haveCR)
                {
                    CareReceiverID = Convert.ToInt32(row["carereceiverID"]);
                }

                else
                {
                    CareReceiverID = 0;
                }




                user = new User(Id, Name, Password, Email, PhoneNo, Photo, Role, Verified, CareReceiverID, Certified_CG);
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
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Name = row["name"].ToString();
                string Password = row["password"].ToString();
                string Email = row["email"].ToString();
                string PhoneNo = row["phoneno"].ToString();
                string Photo = row["photo"].ToString();
                string Role = row["role"].ToString();

                bool Verified = Convert.ToBoolean(Convert.ToInt32(row["verified"]));
                bool Certified_CG = Convert.ToBoolean(Convert.ToInt32(row["certified_CG"]));
                //bool Certified_CG = true;

                // Fixing problem where unable to retrieve the value of carereceiver column (where value always = 0 )
                // Make sure properties in non-default constructors do not have null value otherwise when you convert them will get a : 'Object cannot be cast from DBNull to other types.' error
                int CareReceiverID = Convert.ToInt32(row["carereceiverID"]);

                User obj = new User(Id, Name, Password, Email, PhoneNo, Photo, Role, Verified, CareReceiverID, Certified_CG);
                userList.Add(obj);
            }
            return userList;
        }



    }
}