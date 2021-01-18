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
    public class Receipt
    {
        //public string ReceiptID { get; set; }
        public DateTime DateSale { get; set; }
        public double TotalSum { get; set; }
        public bool IsPaid { get; set; }
        public Receipt()
        {

        }

        public Receipt(DateTime dateSale, double totalSum, bool isPaid)
        {
            //ReceiptID = receiptID;
            DateSale = dateSale;
            TotalSum = totalSum;
            IsPaid = isPaid;
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "INSERT INTO Receipt VALUES (@paraDateSale, @paraTotalSum, @IsPaid)";
                using (SqlCommand sqlCmd = new SqlCommand(sqlStatement))
                {
                    sqlCmd.Parameters.AddWithValue("@paraDateSale", DateSale);
                    sqlCmd.Parameters.AddWithValue("@paraTotalSum", TotalSum);
                    sqlCmd.Parameters.AddWithValue("@IsPaid", IsPaid);

                    sqlCmd.Connection = myConn;

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

            //will continue adding more here
        }
        /*public Receipt SelectByReceiptID(string cardID)
        {
            Step 1 -  Define a connection to the database by getting
                      the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
        //    return Receipt;
        }*/

        /*public List<Receipt> SelectAll()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
        }*/
    }
}
