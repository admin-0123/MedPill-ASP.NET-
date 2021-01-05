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
    public class Appointment
    {
        public int Id { get; set; }
        public int patientID { get; set; }

        public int doctorID { get; set; }

        public int nurseID { get; set; }

        public int caregiverID { get; set; }
        public string appointmentType { get; set; }
        public string prescription { get; set; }
        public string remarks { get; set; }
        public DateTime dateTime { get; set; }

        public string followUp { get; set; }
        public string status { get; set; }

        public Appointment()
        {

        }

        public Appointment(int patientID, int doctorID, int nurseID, int caregiverID, string appointmentType, string prescription, string remarks, DateTime dateTime, string followUp, string status)
        {
            this.patientID = patientID;
            this.doctorID = doctorID;
            this.nurseID = nurseID;
            this.caregiverID = caregiverID;
            this.appointmentType = appointmentType;
            this.prescription = prescription;
            this.remarks = remarks;
            this.dateTime = dateTime;
            this.followUp = followUp;
            this.status = status;
        }

        public List<Appointment> SelectAllForAdmin()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Appointment> apptList = new List<Appointment>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record

                int patientID = Convert.ToInt32(row["patientID"]);
                int doctorID = Convert.ToInt32(row["doctorID"]);
                int nurseID = Convert.ToInt32(row["nurseID"]);
                int caregiverID = Convert.ToInt32(row["caregiverID"]);
                string appointmentType = row["appointmentType"].ToString();
                string prescription = row["prescription"].ToString();
                string remarks = row["remarks"].ToString();
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = row["followUp"].ToString();
                string status = row["status"].ToString();
                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);
                
                apptList.Add(obj);
            }
            return apptList;
        }

        public List<Appointment> SelectAllForOneUser(int uid)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where patientID=@paraUID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUID", uid);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<Appointment> apptList = new List<Appointment>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record

                int patientID = Convert.ToInt32(row["patientID"]);
                int doctorID = Convert.ToInt32(row["doctorID"]);
                int nurseID = Convert.ToInt32(row["nurseID"]);
                int caregiverID = Convert.ToInt32(row["caregiverID"]);
                string appointmentType = row["appointmentType"].ToString();
                string prescription = row["prescription"].ToString();
                string remarks = row["remarks"].ToString();
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = row["followUp"].ToString();
                string status = row["status"].ToString();
                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }

    }


}
