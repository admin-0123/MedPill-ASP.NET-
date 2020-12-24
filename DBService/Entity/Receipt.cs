using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBService.Entity
{
    public class Receipt
    {
        public string ReceiptID { get; set; }
        public DateTime DateSale { get; set; }
        public double TotalSum { get; set; }
        public Receipt()
        {

        }

        public Receipt(string receiptID, DateTime dateSale, double totalSum)
        {
            ReceiptID = receiptID;
            DateSale = dateSale;
            TotalSum = totalSum;
        }
        public int Insert()
        {
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
