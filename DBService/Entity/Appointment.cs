using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Entity
{
    class Appointment
    {
        public int id { get; set; }
        public int patientID { get; set; }

        public int doctorID { get; set; }

        public int nurseID { get; set; }

        public int caregiverID { get; set; }
        public string appointmentType { get; set; }
        public string prescription { get; set; }
        public string remarks { get; set; }
        public string dateTime { get; set; }

        public string followUp { get; set; }
        public string status { get; set; }

        public Appointment()
        {

        }


/*        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 - Create SQL Statement
            string sqlStatement = "INSERT INTO Appointment (CardID, CardName, CardNumber, CardExpiry, CVVNumber, StillValid)"
                + "VALUES (@paraCardID, @paraCardName, @paraCardNumber, @paraCardExpiry, @paraCVVNumber, @paraStillValid)";

            SqlCommand sqlCmd = new SqlCommand(sqlStatement, myConn);

            //Step 3 - Add info to each parameterised variables
            sqlCmd.Parameters.AddWithValue("paraCardID", CardID);
            sqlCmd.Parameters.AddWithValue("paraCardName", CardName);
            sqlCmd.Parameters.AddWithValue("paraCardNumber", CardNumber);
            sqlCmd.Parameters.AddWithValue("paraCardExpiry", CardExpiry);
            sqlCmd.Parameters.AddWithValue("paraCVVNumber", CVVNumber);
            sqlCmd.Parameters.AddWithValue("paraStillValid", StillValid);

            //Step 4 - Open Connection to database
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            //Step 5 - Close Connection to database
            myConn.Close();

            return result;
        }*/





    }


}
