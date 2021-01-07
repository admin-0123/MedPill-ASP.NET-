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
        //public int CardID { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiry { get; set; }
        public string CVVNumber { get; set; }
        public bool StillValid { get; set; }
        public byte[] IV { get; set; }
        public byte[] Key { get; set; }

        //Empty Constructor
        public CardInfo()
        {

        }

        //Constructor with parameters to initialise all properties
        public CardInfo(string cardName, string cardNumber, DateTime cardExpiry, string cvvNumber, byte[] iv, byte[] key)
        {
            //CardID = cardID;
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpiry = cardExpiry;
            CVVNumber = cvvNumber;
            IV = iv;
            Key = key;
            StillValid = checkCardValidation();
        }
        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 - Create SQL Statement
            //string sqlStatement = "INSERT INTO CardInfo (CardName, CardNumber, CardExpiry, CVVNumber, StillValid, IV, Key)"
            //  + " VALUES (@paraCardName, @paraCardNumber, @paraCardExpiry, @paraCVVNumber, @paraStillValid, @paraIV, @paraKey)";

            string sqlStatement = "INSERT INTO CardInfo VALUES (@paraCardName, @paraCardNumber, @paraCardExpiry, @paraCVVNumber, @paraStillValid, @paraIV, @paraKey)";

            SqlCommand sqlCmd = new SqlCommand(sqlStatement, myConn);

            //Step 3 - Add info to each parameterised variables
            //sqlCmd.Parameters.AddWithValue("@paraCardID", CardID);
            sqlCmd.Parameters.AddWithValue("@paraCardName", CardName);
            sqlCmd.Parameters.AddWithValue("@paraCardNumber", CardNumber);
            sqlCmd.Parameters.AddWithValue("@paraCardExpiry", CardExpiry);
            sqlCmd.Parameters.AddWithValue("@paraCVVNumber", CVVNumber);
            sqlCmd.Parameters.AddWithValue("@paraStillValid", StillValid);

            //Key and IV
            sqlCmd.Parameters.AddWithValue("@paraIV", Convert.ToBase64String(IV));
            sqlCmd.Parameters.AddWithValue("@paraKey", Convert.ToBase64String(Key));

            //Step 4 - Open Connection to database
            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            //Step 5 - Close Connection to database
            myConn.Close();

            return result;
        }
        public CardInfo GetCardByCardNumber(string cardNumber)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 - Create DataAdapter to retrieve data from database table
            string sqlStatement = "SELECT * FROM CardInfo WHERE CardNumber = @paraCardNumber";
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn);
            da.SelectCommand.Parameters.AddWithValue("@paraCardNumber", cardNumber);

            //Step 3 - Create a dataset to store data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 - Use DataAdapter to fill dataset with retrieved data
            da.Fill(ds);

            //Step 5 - Read data from dataset
            CardInfo cif = null;
            int rec_cnt = ds.Tables[0].Rows.Count;
            if (rec_cnt == 1)
            {
                DataRow row = ds.Tables[0].Rows[0]; //Returns one record
                //int cardID = Convert.ToInt32(row["CardID"].ToString());
                string cardName = row["CardName"].ToString();
                //string cardNumber = row["CardNumber"].ToString();
                DateTime cardExpiry = Convert.ToDateTime(row["CardExpiry"].ToString());
                string cvvNumber = row["CVVNumber"].ToString();
                bool stillValid = Convert.ToBoolean(row["StillValid"].ToString());
                byte[] iv = Convert.FromBase64String(row["IV"].ToString());
                byte[] key = Convert.FromBase64String(row["IV"].ToString());
                cif = new CardInfo(cardName, cardNumber, cardExpiry, cvvNumber, iv, key);
            }
            return cif;
        }

        //Select all card info

        //BIG NOTE HERE
        //Make sure end product select cards based on userID
        //Because currently, we select all users' cards
        public List<CardInfo> SelectAllCards()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            //Step 2 -  Create a DataAdapter object to retrieve data from the database table
            string sqlStatement = "SELECT * FROM CardInfo";
            SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn);

            //Step 3 -  Create a DataSet to store the data to be retrieved
            DataSet ds = new DataSet();

            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
            da.Fill(ds);

            //Step 5 -  Read data from DataSet to List
            List<CardInfo> cifList = new List<CardInfo>();
            int rec_cnt = ds.Tables[0].Rows.Count;
            for (int i = 0; i < rec_cnt; i++)
            {
                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                //int cardID = Convert.ToInt32(row["CardID"].ToString());
                string cardName = row["CardName"].ToString();
                string cardNumber = row["CardNumber"].ToString();
                DateTime cardExpiry = Convert.ToDateTime(row["CardExpiry"].ToString());
                string cvvNumber = row["CVVNumber"].ToString();
                bool stillValid = Convert.ToBoolean(row["StillValid"].ToString());
                byte[] iv = Convert.FromBase64String(row["IV"].ToString());
                byte[] key = Convert.FromBase64String(row["IV"].ToString());
                CardInfo cif = new CardInfo(cardName, cardNumber, cardExpiry, cvvNumber, iv, key);
                cifList.Add(cif);
            }
            return cifList;
        }
        //Delete card by card number
        public int DeleteByCardNumber(string cardNumber)
        {

            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);
            //string sqlStatement = "SELECT * FROM CardInfo WHERE CardNumber = @paraCardNumber";
            string sqlStatement = "DELETE FROM CardInfo WHERE CardNumber = @paraCardNumber";
            //SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn);
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, myConn);
            sqlCmd.Parameters.AddWithValue("@paraCardNumber", cardNumber);
            //sqlCmd.SelectCommand.Parameters.AddWithValue("@paraCardID", cardID);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;

        }
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
