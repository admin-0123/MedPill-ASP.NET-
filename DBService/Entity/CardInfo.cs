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

            //Step 2 - Create SQL Statement
            string sqlStatement = "INSERT INTO CardInfo (CardID, CardName, CardNumber, CardExpiry, CVVNumber, StillValid)"
                + "VALUES (@paraCardID, @paraCardName, @paraCardNumber, @paraCardExpiry, @paraCVVNumber, @paraStillValid)";

            SqlCommand sqlCmd = new SqlCommand(sqlStatement, myConn);

            //Step 3 - Add info to each parameterised variables
            sqlCmd.Parameters.AddWithValue("paraCardID", CardID);
            sqlCmd.Parameters.AddWithValue("paraCardName", CardName);
            sqlCmd.Parameters.AddWithValue("paraCardNumber",CardNumber);
            sqlCmd.Parameters.AddWithValue("paraCardExpiry",CardExpiry);
            sqlCmd.Parameters.AddWithValue("paraCVVNumber",CVVNumber);
            sqlCmd.Parameters.AddWithValue("paraStillValid",StillValid);

            //Step 4 - Open Connection to database
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            //Step 5 - Close Connection to database
            myConn.Close();

            return result;
        }
        public CardInfo SelectByCardID(string cardID)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 - Create DataAdapter to retrieve data from database table
            string sqlStatement = "SELECT * FROM CardInfo WHERE CardID = @paraCardID";
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraCardID", cardID);

            //Step 3 - Create a dataset to store data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 - Use DataAdapter to fill dataset with retrieved data
            da.Fill(ds);

            //Step 5 - Read data from dataset
            CardInfo cif = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if(rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0]; //Returns one record
                //string cardID = row["CardID"].ToString();
                string cardName = row["CardName"].ToString();
                string cardNumber = row["CardNumber"].ToString();
                DateTime cardExpiry = Convert.ToDateTime(row["CardExpiry"].ToString());
                string cvvNumber = row["CVVNumber"].ToString();
                bool stillValid = Convert.ToBoolean(row["CardName"].ToString());
                cif = new CardInfo(cardID, cardName, cardNumber, cardExpiry, cvvNumber);
            }
            return cif;
        }

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
