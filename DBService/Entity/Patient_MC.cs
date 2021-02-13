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
    public class Patient_MC
    {
        public string Reg_no { get; set; }
        public string Name { get; set; }
        public string Nric { get; set; }
        public string Duration { get; set; }
        public string Type_of_leave { get; set; }
        public string Clinic { get; set; }
        public string Signature { get; set; }
        public string Date { get; set; }

        public Patient_MC()
        {

        }

        public Patient_MC(string reg_no, string name, string nric, string duration, string type_of_leave, string clinic, string signature, string date)
        {
            Reg_no = reg_no;
            Name = name;
            Nric = nric;
            Duration = duration;
            Type_of_leave = type_of_leave;
            Clinic = clinic;
            Signature = signature;
            Date = date;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Patient_MC (Reg_no, Name, Nric, Duration, Type_of_leave, Clinic, Signature, Date) " +
                "VALUES (@paraReg_no, @paraName, @paraNric,@paraDuration,@paraType_of_leave,@paraClinic,@paraSignature,@paraDate)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraReg_no", Reg_no);
            sqlCmd.Parameters.AddWithValue("@paraName", Name);
            sqlCmd.Parameters.AddWithValue("@paraNric", Nric);
            sqlCmd.Parameters.AddWithValue("@paraDuration", Duration);
            sqlCmd.Parameters.AddWithValue("@paraType_of_leave", Type_of_leave);
            sqlCmd.Parameters.AddWithValue("@paraClinic", Clinic);
            sqlCmd.Parameters.AddWithValue("@paraSignature", Signature);
            sqlCmd.Parameters.AddWithValue("@paraDate", Date);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public Patient_MC SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Patient_MC where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Patient_MC emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string reg_no = row["Reg_no"].ToString();
                string name = row["Name"].ToString();
                string nric = row["Nric"].ToString();
                string duration = row["Duration"].ToString();
                string type_of_leave = row["Type_of_leave"].ToString();
                string clinic = row["Clinic"].ToString();
                string signature = row["Signature"].ToString();
                string date = row["Date"].ToString();
                emp = new Patient_MC(reg_no, name, nric, duration, type_of_leave, clinic, signature, date);
            }
            return emp;
        }
        public List<Patient_MC> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Patient_MC";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Patient_MC> empList = new List<Patient_MC>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string reg_no = row["Reg_no"].ToString();
                string name = row["Name"].ToString();
                string nric = row["Nric"].ToString();
                string duration = row["Duration"].ToString();
                string type_of_leave = row["Type_of_leave"].ToString();
                string clinic = row["Clinic"].ToString();
                string signature = row["Signature"].ToString();
                string date = row["Date"].ToString();
                Patient_MC obj = new Patient_MC(reg_no, name, nric, duration, type_of_leave, clinic, signature, date);
                empList.Add(obj);
            }
            return empList;
        }
    }
}
