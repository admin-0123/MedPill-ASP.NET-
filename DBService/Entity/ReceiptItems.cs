using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
