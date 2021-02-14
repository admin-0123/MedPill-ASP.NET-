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
    public class Payment_Report
    {
        public string Date_of_appointment { get; set; }
        public string Purpose_visit { get; set; }
        public string Fees { get; set; }

        public Payment_Report()
        {

        }

        public Payment_Report(string date_of_appointment, string purpose_visit, string fees)
        {
            Date_of_appointment = date_of_appointment;
            Purpose_visit = purpose_visit;
            Fees = fees;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Payment_Report (date_of_appointment, purpose_visit, fees) " +
                "VALUES (@paraDate_of_appointment, @paraPurpose_visit, @paraFees)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value
            sqlCmd.Parameters.AddWithValue("@paraDate_of_appointment", Date_of_appointment);
            sqlCmd.Parameters.AddWithValue("@paraPurpose_visit", Purpose_visit);
            sqlCmd.Parameters.AddWithValue("@paraFees", Fees);


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
        }
        public Payment_Report SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from Payment_Report where Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Payment_Report emp = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string date_of_appointment = row["date_of_appointment"].ToString();
                string purpose_visit = row["purpose_visit"].ToString();
                string fees = row["fees"].ToString();
                emp = new Payment_Report(date_of_appointment, purpose_visit, fees);
            }
            return emp;
        }
        public List<Payment_Report> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Payment_Report";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Payment_Report> empList = new List<Payment_Report>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                string date_of_appointment = row["date_of_appointment"].ToString();
                string purpose_visit = row["purpose_visit"].ToString();
                string fees = row["fees"].ToString();
                Payment_Report obj = new Payment_Report(date_of_appointment, purpose_visit, fees);
                empList.Add(obj);
            }
            return empList;
        }
    }
}
