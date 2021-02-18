using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBService.Entity
{
    public class Details
    {
        public string Name { get; set; }
        public string Nric { get; set; }
        public string Date_of_birth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Postal { get; set; }

        public Details()
        {

        }

        public Details(string name, string nric, string date_of_birth, string gender, string phone, string email, string address, string postal)
        {
            Name = name;
            Nric = nric;
            Date_of_birth = date_of_birth;
            Gender = gender;
            Phone = phone;
            Email = email;
            Address = address;
            Postal = postal;
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Patient_Details (Name, NRIC, Date_of_birth, Gender, Phone_Number, Email, Address, Postal_Code) " +
                "VALUES (@paraName, @paraNRIC, @paraDate_of_birth,@paraGender,@paraPhone_Number,@paraEmail,@paraAddress,@paraPostal_Code)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraNRIC", Nric);
            sqlCmd.Parameters.AddWithValue("@paraDate_of_birth", Date_of_birth);
            sqlCmd.Parameters.AddWithValue("@paraGender", Gender);
            sqlCmd.Parameters.AddWithValue("@paraPhone_Number", Phone);
            sqlCmd.Parameters.AddWithValue("@paraEmail", Email);
            sqlCmd.Parameters.AddWithValue("@paraAddress", Address);
            sqlCmd.Parameters.AddWithValue("@paraPostal_Code", Postal);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public Details SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Patient_Details where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Details emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string name = row["Name"].ToString();
                string nric = row["NRIC"].ToString();
                string dob = row["Date_of_birth"].ToString();
                string gender = row["Gender"].ToString();
                string phone = row["Phone_Number"].ToString();
                string email = row["Email"].ToString();
                string address = row["Address"].ToString();
                string postal = row["Postal_Code"].ToString();
                emp = new Details(name, nric, dob, gender, phone, email, address, postal);
            }
            return emp;
        }
        public List<Details> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Patient_Details";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Details> empList = new List<Details>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string name = row["Name"].ToString();
                string nric = row["NRIC"].ToString();
                string dob = row["Date_of_birth"].ToString();
                string gender = row["Gender"].ToString();
                string phone = row["Phone_Number"].ToString();
                string email = row["Email"].ToString();
                string address = row["Address"].ToString();
                string postal = row["Postal_Code"].ToString();
                Details obj = new Details(name, nric, dob, gender, phone, email, address, postal);
                empList.Add(obj);
            }
            return empList;
        }
        public int UpdateDetailsById(string id, string name, string nric, string date_of_birth, string gender, string phone, string email, string address, string postal)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Patient_Details SET Name = @paraName, NRIC = @paraNric, Date_Of_Birth = @paraDate_of_birth, Gender = @paraGender, Phone_Number = @paraPhone_number, Email = @paraEmail, Address = @paraAddress, Postal_Code = @paraPostal_code where Id = @paraId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraName", name);
            sqlCmd.Parameters.AddWithValue("@paraNric", nric);
            sqlCmd.Parameters.AddWithValue("@paraDate_of_birth", date_of_birth);
            sqlCmd.Parameters.AddWithValue("@paraGender", gender);
            sqlCmd.Parameters.AddWithValue("@paraPhone_number", phone);
            sqlCmd.Parameters.AddWithValue("@paraEmail", email);
            sqlCmd.Parameters.AddWithValue("@paraAddress", address);
            sqlCmd.Parameters.AddWithValue("@paraPostal_code", postal);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}
