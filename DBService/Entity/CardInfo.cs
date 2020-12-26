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
    public class CardInfo
    {
        //Properties of CardInfo
        public string CardID { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiry { get; set; }
        public string CVVNumber { get; set; }
        public bool StillValid { get; set; }

        //Empty Constructor
        public CardInfo()
        {

        }

        //Constructor with parameters to initialise all properties
        public CardInfo(string cardID, string cardName, string cardNumber, DateTime cardExpiry, string cvvNumber)
        {
            CardID = cardID;
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpiry = cardExpiry;
            CVVNumber = cvvNumber;
            StillValid = checkCardValidation();
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
        //public CardInfo SelectByCardID(string cardID)
        //{
        //    return CardInfo;
        //}

        //public List<CardInfo> SelectAll()
        //{

        //}
        public bool checkCardValidation()
        {
            DateTime currentDate = DateTime.Now;

            //Compares month difference by subtracting currentDate from CardExpiry, i.e. CardExpiry - currentDate
            double monthDifference = CardExpiry.Subtract(currentDate).Days / (365.25 / 12);
            if (monthDifference < 3)
            {
                return false;
            }
            // More than 3 months hence valid
            else
            {
                return true;
            }
        }
    }
}
