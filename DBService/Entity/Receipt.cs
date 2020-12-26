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
        public string ReceiptID { get; set; }
        public DateTime DateSale { get; set; }
        public double TotalSum { get; set; }
        public bool IsPaid { get; set; }
        public Receipt()
        {

        }

        public Receipt(string receiptID, DateTime dateSale, double totalSum, bool isPaid)
        {
            ReceiptID = receiptID;
            DateSale = dateSale;
            TotalSum = totalSum;
            IsPaid = isPaid;
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //will continue adding more here
            return 0;
        }
        //public Receipt SelectByReceiptID(string cardID)
        //{
        //    return Receipt;
        //}

        //public List<Receipt> SelectAll()
        //{

        //}
    }
}
