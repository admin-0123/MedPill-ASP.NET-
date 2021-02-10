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
    public class CardInfo
    {
        //Properties of CardInfo Entity
        //public int CardID { get; set; }
        public string UserID { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpiry { get; set; }
        public string CVVNumber { get; set; }
        public bool StillValid { get; set; }
        public byte[] IV { get; set; }
        public byte[] Key { get; set; }
        public string UniqueIdentifier { get; set; }

        //Empty Constructor
        public CardInfo()
        {

        }

        //Constructor with parameters to initialise all properties
        public CardInfo(string userID, string cardName, string cardNumber,
            DateTime cardExpiry, string cvvNumber, byte[] iv,
            byte[] key, bool stillValid, string uniqueIdentifier)
        {
            //CardID = cardID;
            UserID = userID;
            CardName = cardName;
            CardNumber = cardNumber;
            CardExpiry = cardExpiry;
            CVVNumber = cvvNumber;
            IV = iv;
            Key = key;
            StillValid = stillValid;
            UniqueIdentifier = uniqueIdentifier;
        }

        public int Insert()
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                //Step 2 - Create SQL Statement
                string sqlStatement = "INSERT INTO CardInfo VALUES (@paraCardName, @paraCardNumber, @paraCardExpiry, @paraCVVNumber, @paraStillValid, @paraIV, @paraKey, @paraUniqueIdentifier)";
                using (SqlCommand sqlCmd = new SqlCommand(sqlStatement))
                {
                    //Step 3 - Add info to each parameterised variables
                    //sqlCmd.Parameters.AddWithValue("@paraCardID", CardID);
                    sqlCmd.Parameters.AddWithValue("@paraUserID", UserID);
                    sqlCmd.Parameters.AddWithValue("@paraCardName", Convert.ToBase64String(encryptData(CardName)));
                    sqlCmd.Parameters.AddWithValue("@paraCardNumber", Convert.ToBase64String(encryptData(CardNumber)));
                    sqlCmd.Parameters.AddWithValue("@paraCardExpiry", Convert.ToBase64String(encryptData(CardExpiry.ToString())));
                    sqlCmd.Parameters.AddWithValue("@paraCVVNumber", Convert.ToBase64String(encryptData(CVVNumber)));
                    sqlCmd.Parameters.AddWithValue("@paraStillValid", Convert.ToBase64String(encryptData(StillValid.ToString())));
                    sqlCmd.Parameters.AddWithValue("@paraUniqueIdentifier", UniqueIdentifier);

                    //Key and IV
                    sqlCmd.Parameters.AddWithValue("@paraIV", Convert.ToBase64String(IV));
                    sqlCmd.Parameters.AddWithValue("@paraKey", Convert.ToBase64String(Key));

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
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        //Step 5 - Close Connection to database
                        myConn.Close();
                    }
                }
            }
        }
        public CardInfo GetCardByCardNumber(string uniqueIdentifier)
        {
            //Step 1 -  Define a connection to the database by getting
            //          the connection string from App.config
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                //Step 2 - Create DataAdapter to retrieve data from database table
                string sqlStatement = "SELECT * FROM CardInfo WHERE UniqueIdentifier = @paraUniqueIdentifier";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn))
                {
                    da.SelectCommand.Parameters.AddWithValue("@paraUniqueIdentifier", uniqueIdentifier);

                    //Step 3 - Create a dataset to store data to be retrieved
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            //Step 4 - Use DataAdapter to fill dataset with retrieved data
                            da.Fill(ds);

                            //Step 5 - Read data from dataset
                            CardInfo cif = null;
                            int rec_cnt = ds.Tables[0].Rows.Count;
                            if (rec_cnt == 1)
                            {
                                DataRow row = ds.Tables[0].Rows[0]; //Returns one record
                                //int cardID = Convert.ToInt32(row["Id"].ToString());
                                string userID = row["UserId"].ToString();
                                byte[] cardName = Convert.FromBase64String(row["CardName"].ToString());
                                byte[] cardNumber = Convert.FromBase64String(row["CardNumber"].ToString());
                                byte[] cardExpiry = Convert.FromBase64String(row["CardExpiry"].ToString());
                                byte[] cvvNumber = Convert.FromBase64String(row["CVVNumber"].ToString());
                                byte[] stillValid = Convert.FromBase64String(row["StillValid"].ToString());

                                byte[] iv = Convert.FromBase64String(row["IV"].ToString());
                                byte[] key = Convert.FromBase64String(row["Key"].ToString());

                                cif = new CardInfo(userID, decryptData(iv, key, cardName), decryptData(iv, key, cardNumber), Convert.ToDateTime(decryptData(iv, key, cardExpiry))
                                , decryptData(iv, key, cvvNumber), iv, key, Convert.ToBoolean(decryptData(iv, key, stillValid)), uniqueIdentifier);

                            }
                            return cif;
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                        finally
                        {
                            Debug.WriteLine("Retrieve CardInfo complete!");
                        }

                    }
                }
            }

        }

        public bool CheckCardByCardNumber(string cardNumber)
        {
            /*string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "SELECT CardNumber FROM CardInfo WHERE CardNumber = @paraCardNumber";
                using (SqlCommand sqlCmd = new SqlCommand(sqlStatement))
                {
                    sqlCmd.Parameters.AddWithValue("@paraCardNumber", cardNumber);
                    sqlCmd.Connection = myConn;
                    try
                    {
                        myConn.Open();
                        using(SqlDataReader reader = sqlCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                if(reader["CardNumber"] != null)
                                {
                                    if(reader["CardNumber"] != DBNull.Value)
                                    {
                                        byte[] iv = Convert.FromBase64String(reader["Iv"].ToString());
                                        byte[] key = Convert.FromBase64String(reader["Key"].ToString());
                                        //string cardNumberDBResult = decryptData(iv, key, reader["CardNumber"]);
                                        //string cardNumberResult = reader["CardNumber"].ToString();

                                        if(cardNumberResult == cardNumber)
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        return false;
                                    }
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }

                    finally { myConn.Close(); }
                    return false;
                }
            }*/
            //Hard code for a while
            return false;
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
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                //Step 2 -  Create a DataAdapter object to retrieve data from the database table
                string sqlStatement = "SELECT * FROM CardInfo";
                using (SqlDataAdapter da = new SqlDataAdapter(sqlStatement, myConn))
                {
                    //Step 3 -  Create a DataSet to store the data to be retrieved
                    using (DataSet ds = new DataSet())
                    {
                        try
                        {
                            //Step 4 -  Use the DataAdapter to fill the DataSet with data retrieved
                            da.Fill(ds);

                            //Step 5 -  Read data from DataSet to List
                            List<CardInfo> cifList = new List<CardInfo>();
                            int rec_cnt = ds.Tables[0].Rows.Count;
                            for (int i = 0; i < rec_cnt; i++)
                            {
                                DataRow row = ds.Tables[0].Rows[i];  // Sql command returns only one record
                                //int cardID = Convert.ToInt32(row["Id"].ToString());
                                string userID = row["UserId"].ToString();
                                byte[] cardName = Convert.FromBase64String(row["CardName"].ToString());
                                byte[] cardNumber = Convert.FromBase64String(row["CardNumber"].ToString());
                                byte[] cardExpiry = Convert.FromBase64String(row["CardExpiry"].ToString());
                                byte[] cvvNumber = Convert.FromBase64String(row["CVVNumber"].ToString());
                                byte[] stillValid = Convert.FromBase64String(row["StillValid"].ToString());

                                byte[] iv = Convert.FromBase64String(row["IV"].ToString());
                                byte[] key = Convert.FromBase64String(row["Key"].ToString());

                                string uniqueIdentifier = row["UniqueIdentifier"].ToString();

                                CardInfo cif = new CardInfo(userID, decryptData(iv, key, cardName), decryptData(iv, key, cardNumber), Convert.ToDateTime(decryptData(iv, key, cardExpiry))
                                   , decryptData(iv, key, cvvNumber), iv, key, Convert.ToBoolean(decryptData(iv, key, stillValid)), uniqueIdentifier);
                                cifList.Add(cif);
                            }
                            return cifList;
                        }
                        catch (SqlException ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                        finally
                        {
                            Debug.WriteLine("Retrieve all CardInfo Complete!");
                        }
                    }
                }
            }
        }
        //Delete card by card number
        public int DeleteByCardNumber(string uniqueIdentifier)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            using (SqlConnection myConn = new SqlConnection(DBConnect))
            {
                string sqlStatement = "DELETE FROM CardInfo WHERE UniqueIdentifier = @paraUniqueIdentifier";
                using (SqlCommand sqlCmd = new SqlCommand(sqlStatement, myConn))
                {
                    sqlCmd.Parameters.AddWithValue("@paraUniqueIdentifier", uniqueIdentifier);

                    try
                    {
                        myConn.Open();
                        int result = sqlCmd.ExecuteNonQuery();
                        return result;
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.ToString());
                    }
                    finally
                    {
                        myConn.Close();
                    }
                }
            }
        }

        //Will remove this method below later
        public int UpdateByCardNumber(string previousCardNumber, string cardName, string cardNumber, DateTime cardExpiry, string cvvNumber)
        {
            string DBConnect = ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
            SqlConnection myConn = new SqlConnection(DBConnect);

            string sqlStatement = "UPDATE CardInfo SET CardName = @paraCardName, CardNumber = @paraCardNumber, CardExpiry = @paraCardExpiry, CVVNumber = @paraCVVNumber, StillValid = @paraStillValid WHERE CardNumber = @paraPreviousCardNumber";
            SqlCommand sqlCmd = new SqlCommand(sqlStatement, myConn);

            //Previous card number
            sqlCmd.Parameters.AddWithValue("@paraPreviousCardNumber", previousCardNumber);

            //New updated card Info
            sqlCmd.Parameters.AddWithValue("@paraCardName", cardName);
            sqlCmd.Parameters.AddWithValue("@paraCardNumber", cardNumber);
            sqlCmd.Parameters.AddWithValue("@paraCardExpiry", cardExpiry);
            sqlCmd.Parameters.AddWithValue("@paraCVVNumber", cvvNumber);
            sqlCmd.Parameters.AddWithValue("@paraStillValid", StillValid);

            myConn.Open();
            int result = sqlCmd.ExecuteNonQuery();

            myConn.Close();

            return result;
        }

        //Might consider putting encryption and decryption inside this function
        protected string decryptData(byte[] iv, byte[] key, byte[] cipherText)
        {
            string plainText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = iv;
                cipher.Key = key;
                // Create a decrytor to perform the stream transform.
                ICryptoTransform decryptTransform = cipher.CreateDecryptor();
                //Create the streams used for decryption

                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptTransform, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            //Read the decrypted bytes from the decrypting stream
                            //and place them in a string
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return plainText;
        }
        protected byte[] encryptData(string data)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                cipher.Key = Key;
                ICryptoTransform encryptTransform = cipher.CreateEncryptor();
                //ICryptoTransform decryptTransform = cipher.CreateDecryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0,
               plainText.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return cipherText;
        }

    }
}
