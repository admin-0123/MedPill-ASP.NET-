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
    public class Report
    {
        public string Id { get; set; }
        public string Dname { get; set; }
        public string Pname { get; set; }
        public string Clinic { get; set; }
        public string Date_of_report { get; set; }
        public string Details { get; set; }

        public Report()
        {

        }
        
        public Report(string id, string dname, string pname, string clinic, string date_of_report, string details)
        {
            Id = id;
            Dname = dname;
            Pname = pname;
            Clinic = clinic;
            Date_of_report = date_of_report;
            Details = details;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Patient_Report (doctor, patient, clinic, date_of_report, details) " +
                "VALUES (@paraDoctor, @paraPatient, @paraClinic, @paraDate_of_report, @paraDetails)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraDoctor", Dname);
            sqlCmd.Parameters.AddWithValue("@paraPatient", Pname);
            sqlCmd.Parameters.AddWithValue("@paraClinic", Clinic);
            sqlCmd.Parameters.AddWithValue("@paraDate_of_report", Date_of_report);
            sqlCmd.Parameters.AddWithValue("@paraDetails", Details);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public Report SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Patient_Report where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Report emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string dname = row["doctor"].ToString();
                string pname = row["patient"].ToString();
                string clinic = row["clinic"].ToString();
                string date_of_report = row["date_of_report"].ToString();
                string detail = row["details"].ToString();
                emp = new Report(Id,dname,pname,clinic, date_of_report, detail);
            }
            return emp;
        }
        public List<Report> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Patient_Report";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Report> empList = new List<Report>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string Id = row["Id"].ToString();
                string dname = row["doctor"].ToString();
                string pname = row["patient"].ToString();
                string clinic = row["clinic"].ToString();
                string date_of_report = row["date_of_report"].ToString();
                string detail = row["details"].ToString();
                Report obj = new Report(Id, dname, pname, clinic, date_of_report, detail);
                empList.Add(obj);
            }
            return empList;
        }
        public int UpdateReportById(string id, string dname, string pname, string clinic, string date_of_report, string details)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Patient_Report SET doctor = @paraDoctor, patient = @paraPatient, clinic = @paraClinic, date_of_report = @paraDate_of_report, details = @paraDetails where Id = @paraId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@paraDoctor", dname);
            sqlCmd.Parameters.AddWithValue("@paraPatient", pname);
            sqlCmd.Parameters.AddWithValue("@paraClinic", clinic);
            sqlCmd.Parameters.AddWithValue("@paraDate_of_report", date_of_report);
            sqlCmd.Parameters.AddWithValue("@paraDetails", details);
            sqlCmd.Parameters.AddWithValue("@paraId", id);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}
