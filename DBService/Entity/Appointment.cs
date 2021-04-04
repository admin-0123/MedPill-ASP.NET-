using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

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

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            // Step 2 - Create a SqlCommand object to add record with INSERT statement
            string sqlStmt = "INSERT INTO Appointment (patientID, appointmentType, dateTime, status) " +
                "VALUES (@paraPatientID, @paraAppointmentType, @paraDateTime, @paraStatus)";
            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            // Step 3 : Add each parameterised variable with value

            // Values from user input
            sqlCmd.Parameters.AddWithValue("@paraPatientID", patientID);
            sqlCmd.Parameters.AddWithValue("@paraAppointmentType", appointmentType);
            sqlCmd.Parameters.AddWithValue("@paraDateTime", dateTime);
            sqlCmd.Parameters.AddWithValue("@paraStatus", status);

            // Default values since business side will decide who will be the doctor etc...


            // Step 4 Open connection the execute NonQuery of sql command   
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            // Step 5 :Close connection
            myConn.Close();

            return result;
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

                /*
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
                */

                int patientID = Convert.ToInt32(row["patientID"]);
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }

                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public List<Appointment> SelectAllForAdminUpcoming()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where status=@apptStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@apptStatus", "upcoming");

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }

                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public List<Appointment> SelectAllForAdminPast()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where status=@apptStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@apptStatus", "past");

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }

                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public List<Appointment> SelectAllForAdminMissed()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where status=@apptStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@apptStatus", "missed");

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }
                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public List<Appointment> SelectAllForOneUserUpcoming(int uid)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where patientID=@paraUID and status=@apptStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUID", uid);
            da.SelectCommand.Parameters.AddWithValue("@apptStatus", "upcoming");

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }
                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public List<Appointment> SelectAllForOneUserPast(int uid)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where patientID=@paraUID and status=@apptStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUID", uid);
            da.SelectCommand.Parameters.AddWithValue("@apptStatus", "past");

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }
                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public List<Appointment> SelectAllForOneUserMissed(int uid)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where patientID=@paraUID and status=@apptStatus";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUID", uid);
            da.SelectCommand.Parameters.AddWithValue("@apptStatus", "missed");

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
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }
                Appointment obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);

                apptList.Add(obj);
            }
            return apptList;
        }
        public Appointment SelectOne(int uid, DateTime appt_datetime)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStmt = "Select * from Appointment where patientID=@paraUID and dateTime=@dateTime";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraUID", uid);
            da.SelectCommand.Parameters.AddWithValue("@dateTime", appt_datetime);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            Appointment obj = new Appointment();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record

                int patientID = Convert.ToInt32(row["patientID"]);
                int doctorID = 0;
                int nurseID = 0;
                int caregiverID = 0;
                string appointmentType = row["appointmentType"].ToString();
                string prescription = "none";
                string remarks = "none";
                DateTime dateTime = Convert.ToDateTime(row["dateTime"]);
                string followUp = "none";
                string status = row["status"].ToString();

                if (row.IsNull("doctorID") == false)
                {
                    doctorID = Convert.ToInt32(row["doctorID"]);
                }
                if (row.IsNull("nurseID") == false)
                {
                    nurseID = Convert.ToInt32(row["nurseID"]);
                }
                if (row.IsNull("caregiverID") == false)
                {
                    caregiverID = Convert.ToInt32(row["caregiverID"]);
                }
                if (row.IsNull("prescription") == false)
                {
                    prescription = row["prescription"].ToString();
                }
                if (row.IsNull("remarks") == false)
                {
                    remarks = row["remarks"].ToString();
                }
                if (row.IsNull("followUp") == false)
                {
                    followUp = row["followUp"].ToString();
                }
                obj = new Appointment(patientID, doctorID, nurseID, caregiverID, appointmentType, prescription, remarks, dateTime, followUp, status);
            }
            return obj;
        }
        public int UpdateOne(int uid, string appointmentType, DateTime old_time, DateTime new_time)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Appointment SET dateTime = @newTime, appointmentType=@newApptType where patientID =  @uid and dateTime = @oldTime";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@uid", uid);
            sqlCmd.Parameters.AddWithValue("@oldTime", old_time);
            sqlCmd.Parameters.AddWithValue("@newTime", new_time);
            sqlCmd.Parameters.AddWithValue("@newApptType", appointmentType);
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
        public int UpdateDoctor(int uid, DateTime old_time, int doctor_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE Appointment SET doctorID = @newDoctor where patientID =  @uid and dateTime = @oldTime";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@uid", uid);
            sqlCmd.Parameters.AddWithValue("@oldTime", old_time);
            sqlCmd.Parameters.AddWithValue("@newDoctor", doctor_id);
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
        public int DeleteOne(int uid, DateTime dateTime)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "DELETE FROM Appointment WHERE patientID=@uid and dateTime=@dateTime";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);

            sqlCmd.Parameters.AddWithValue("@uid", uid);
            sqlCmd.Parameters.AddWithValue("@dateTime", dateTime);
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }
    }
}