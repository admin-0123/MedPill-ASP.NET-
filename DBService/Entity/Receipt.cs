using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Diagnostics;

namespace DBService.Entity
{
    public class Receipt
    {
        //public string ReceiptID { get; set; }
        public string UserID { get; set; }
        public DateTime DateSale { get; set; }
        public double TotalSum { get; set; }
        public bool IsPaid { get; set; }
        public string ReceiptLink { get; set; }
        public string UniqueIdentifier { get; set; }
        public Receipt()
        {

        }

        public Receipt(string userID, DateTime dateSale, double totalSum,
            bool isPaid, string receiptLink, string uniqueIdentifier)
        {
            //ReceiptID = receiptID;
            UserID = userID;
            DateSale = dateSale;
            TotalSum = totalSum;
            IsPaid = isPaid;
            ReceiptLink = receiptLink;
            UniqueIdentifier = uniqueIdentifier;
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "INSERT INTO Receipt VALUES (@paraUserID, @paraDateSale, @paraTotalSum, @IsPaid, @paraReceiptLink, @paraUniqueIdentifier)";
                using (SqlCommand sqlCmd = new SqlCommand(sqlStatement))
                {
                    sqlCmd.Parameters.AddWithValue("@paraUserID", UserID);
                    sqlCmd.Parameters.AddWithValue("@paraDateSale", DateSale);
                    sqlCmd.Parameters.AddWithValue("@paraTotalSum", TotalSum);
                    sqlCmd.Parameters.AddWithValue("@IsPaid", IsPaid);
                    sqlCmd.Parameters.AddWithValue("@paraReceiptLink", ReceiptLink);
                    sqlCmd.Parameters.AddWithValue("@paraUniqueIdentifier", UniqueIdentifier);

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
        public Receipt SelectByReceiptID(string userID, string uniqueIdentifier)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "SELECT * FROM Receipt WHERE UserId = @paraUserID, UniqueIdentifier = @paraUniqueIdentifier";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@paraUserID", userID);
                    da.SelectCommand.Parameters.AddWithValue("@paraUniqueIdentifier", uniqueIdentifier);
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            da.Fill(ds);
                            Receipt rep = null;

                            int rec_cnt = ds.Tables[0].Rows.Count;
                            if (rec_cnt == 1)
                            {
                                DataRow row = ds.Tables[0].Rows[0];
                                DateTime dateSale = Convert.ToDateTime(row["DateSale"].ToString());
                                double totalSum = Convert.ToDouble(row["TotalSum"].ToString());
                                bool isPaid = Convert.ToBoolean(row["IsPaid"].ToString());
                                string receiptLink = row["ReceiptLink"].ToString();

                                rep = new Receipt(userID, dateSale, totalSum, isPaid, receiptLink, uniqueIdentifier);
                            }
                            return rep;
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                        finally
                        {
                            Debug.WriteLine("Retrieve ReceiptInfo Complete!");
                        }
                    }
                }
            }
        }

        public List<Receipt> SelectAllReceipts(string userID)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "SELECT * FROM Receipt WHERE UserId = @paraUserID";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@paraUserID", userID);
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            da.Fill(ds);

                            List<Receipt> repList = new List<Receipt>();
                            int rec_cnt = ds.Tables[0].Rows.Count;
                            for (int i = 0; i < rec_cnt; i++)
                            {
                                DataRow row = ds.Tables[0].Rows[i];
                                DateTime dateSale = Convert.ToDateTime(row["DateSale"].ToString());
                                double totalSum = Convert.ToDouble(row["TotalSum"].ToString());
                                bool isPaid = Convert.ToBoolean(row["IsPaid"].ToString());
                                string receiptLink = row["ReceiptLink"].ToString();
                                string uniqueIdentifier = row["UniqueIdentifier"].ToString();

                                Receipt rep = new Receipt(userID, dateSale, totalSum, isPaid, receiptLink, uniqueIdentifier);
                                repList.Add(rep);
                            }
                            return repList;
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                        finally
                        {
                            Debug.WriteLine("Retrieve all Receipt Complete!");
                        }
                    }
                }
            }
        }
    }
}
