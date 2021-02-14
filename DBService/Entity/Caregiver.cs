using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBService.Entity
{
    public class Caregiver
    {
        public string Id { get; set; }

        public string Carereceiver_id { get; set; }

        public int Certified_cg { get; set; }
        
        public Caregiver()
        {

        }

        public Caregiver(string id, string carereceiver_id, int certified_cg)
        {
            Id = id;
            Carereceiver_id = carereceiver_id;
            Certified_cg = certified_cg;
        }

        public Caregiver SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [Caregiver] WHERE Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Caregiver caregiver = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string ID = row["Id"].ToString();
                string carereceiver_id = row["carereceiver_id"].ToString();
                int certified_cg = Convert.ToInt32(row["certified_cg"]);

                caregiver = new Caregiver(ID, carereceiver_id, certified_cg);
            }
            return caregiver;
        }


        public Caregiver SelectByCRId(string cr_id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [Caregiver] WHERE carereceiver_id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", cr_id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Caregiver caregiver = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string ID = row["Id"].ToString();
                string carereceiver_id = row["carereceiver_id"].ToString();
                int certified_cg = Convert.ToInt32(row["certified_cg"]);

                caregiver = new Caregiver(ID, carereceiver_id, certified_cg);
            }
            return caregiver;
        }

        public int ApproveCaregiver(string cg_id, string patient_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStatement = "INSERT INTO [Caregiver] VALUES(@cg_id, @patient_id, @cg_verify)";
            SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
            cmd.Parameters.AddWithValue("@cg_id", cg_id);
            cmd.Parameters.AddWithValue("@patient_id", patient_id);
            cmd.Parameters.AddWithValue("@cg_verify", 1);

            myConn.Open();
            int result = cmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }


        public int RemoveCaregiver(string cg_id, string patient_id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStatement = "DELETE FROM [Caregiver] WHERE Id = @cg_id AND carereceiver_id = @patient_id";
            SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
            cmd.Parameters.AddWithValue("@cg_id", cg_id);
            cmd.Parameters.AddWithValue("@patient_id", patient_id);

            myConn.Open();
            int result = cmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }







        /*        public int ApproveCaregiver(string cg_id, string patient_id)
                {
                    string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
                    SqlConnection myConn = new SqlConnection(DBConnect);
                    string sqlStatement = "UPDATE [Caregiver] SET IsCaretaker = @Caretaker WHERE Id = @id";
                    SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
                    cmd.Parameters.AddWithValue("@id", );
                    cmd.Parameters.AddWithValue("@Caretaker", "Yes");
                    myConn.Open();
                    int result = cmd.ExecuteNonQuery();
                    myConn.Close();
                    return result;
                }*/
    }
}
