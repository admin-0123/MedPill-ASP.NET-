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
    class EmailCode
    {
        public string Email { get; set; }
        public string Code { get; set; }
        public EmailCode()
        {

        }
        public EmailCode(string email, string code)
        {
            Email = email;
            Code = code;
        }
        public string SelectByCode(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter to retrieve data from the database table
            string sqlStmt = "Select * from [EmailCode] WHERE Code = @paraCode";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraCode", code);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            EmailCode user = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Email = row["Email"].ToString();
                string Code = row["Code"].ToString();

                user = new EmailCode(Email,Code);
            }
            return user.Email;
        }
        public string CheckCodeByEmail(string email)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStmt = "Select * from [EmailCode] WHERE Email = @Email";
            SqlDataAdapter da = new SqlDataAdapter(sqlStmt, myConn);
            da.SelectCommand.Parameters.AddWithValue("@Email", email);
            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet.
            EmailCode user = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0];  // Sql command returns only one record
                string Email = row["Email"].ToString();
                string Code = row["Code"].ToString();

                user = new EmailCode(Email, Code);
            }
            if (user == null)
            {
                var result = "error";
                return result;
            }
            return user.Code;
        }
        public int CheckCode(string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            string sqlStatement = "Select * from [EmailCode] WHERE Code = @paraCode";
            SqlCommand cmd = new SqlCommand(sqlStatement, myConn);
            cmd.Parameters.AddWithValue("@paraCode", code);
            myConn.Open();
            int result = cmd.ExecuteNonQuery();
            myConn.Close();
            return result;
        }
        public int Insert(string email, string code)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "INSERT INTO [EmailCode] VALUES (@paraEmail, @paraCode)";
                using (SqlCommand sqlCmd = new SqlCommand(sqlStatement,myConn))
                {
                    sqlCmd.Parameters.AddWithValue("@paraEmail", email);
                    sqlCmd.Parameters.AddWithValue("@paraCode", code);
                    try
                    {
                        //Step 4 - Open Connection to database
                        myConn.Open();
                        int result = sqlCmd.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        //Add error code here
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        //Step 5 - Close Connection to database
                        myConn.Close();
                    }
                }
            }
        }
    }
}
