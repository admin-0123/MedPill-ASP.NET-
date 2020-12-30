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
    public class ReceiptItems
    {
        public string ItemID { get; set; }
        public double ItemCost { get; set; }
        public int ItemQuantity { get; set; }
        public string ItemDescription { get; set; }
        public double Subtotal { get; set; }
        public ReceiptItems()
        {

        }
        public ReceiptItems(string itemID,double itemCost, int itemQuantity, string itemDescription, double subtotal)
        {
            ItemID = itemID;
            ItemCost = itemCost;
            ItemQuantity = itemQuantity;
            ItemDescription = itemDescription;
            Subtotal = subtotal;
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
        //public ReceiptItems SelectByReceiptItemID(string cardID)
        //{
        //    return ReceiptItems;
        //}

        //public List<ReceiptItems> SelectAll()
        //{

        //}
    }
}
