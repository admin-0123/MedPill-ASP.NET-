using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //public bool StillValid { get; set; }

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
            ///StillValid = checkCardValidation()
        }
        public int Insert()
        {
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
            return false;
        }
    }
}
