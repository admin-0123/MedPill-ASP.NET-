using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DBService.Entity
{
    public class Photo
    {
        public string Id { get; set; }
        public string Photo_Resource { get; set; }
        public Photo()
        {

        }

        public Photo(string id, string photo_resource)
        {
            Id = id;
            Photo_Resource = photo_resource;
        }

        public Photo SelectById(string id)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [Photo] WHERE Id = @paraId";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraId", id);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            Photo photo = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string ID = row["Id"].ToString();
                string photo_resource = row["photo_resource"].ToString();

                photo = new Photo(ID, photo_resource);
            }
            return photo;
        }
        public int PhotoExist(string id)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "SELECT * from [Photo]  WHERE Id = @paraId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            myConn.Open();
            var result = sqlCmd.ExecuteScalar();
            myConn.Close();
            if (result != null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int AddPhoto(string id, string photo)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "INSERT INTO  [Photo] VALUES(@paraId, @paraNewPhoto)";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            sqlCmd.Parameters.AddWithValue("@paraNewPhoto", photo);
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }
        public int UpdatePhoto(string id, string new_photo)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStmt = "UPDATE [Photo] SET photo_resource = @paraNewPhoto WHERE Id = @paraId";

            SqlCommand sqlCmd = new SqlCommand(sqlStmt, myConn);
            sqlCmd.Parameters.AddWithValue("@paraNewPhoto", new_photo);
            sqlCmd.Parameters.AddWithValue("@paraId", id);
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }


    }
}
