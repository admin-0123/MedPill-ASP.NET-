using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace EDP_Clinic
{
    public partial class PaymentInfo : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;
        byte[] Key;
        byte[] IV;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            DateTime currentDate = DateTime.Now;
            //Checks if card name is empty
            if (String.IsNullOrEmpty(nameOnCardTB.Text))
            {
                nameOnCardError.Text = "Please enter name on card";
                nameOnCardError.ForeColor = Color.Red;
                nameOnCardError.Visible = true;
            }
            else if(!Regex.IsMatch(nameOnCardTB.Text, "^[a-zA-Z0-9 ]*$"))
            {
                nameOnCardError.Text = "Please enter valid card name";
                nameOnCardError.ForeColor = Color.Red;
                nameOnCardError.Visible = true;
            }
            else
            {
                nameOnCardError.Text = "";
                nameOnCardError.Visible = false;
            }

            //result = int.TryParse(cardNumberTB.Text, out cardNumber);
            //checks if card number is actually numbers     
            //checks if there is other character other than numbers
            if (!Regex.IsMatch(cardNumberTB.Text, "^[0-9]*$"))
            {
                //cardNumberError.Text = "Testing";
                cardNumberError.Text = "Please enter a valid card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
            }
            //checks if its empty or null
            else if (String.IsNullOrEmpty(cardNumberTB.Text))
            {
                cardNumberError.Text = "Please enter card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
            }
            else if(cardNumberTB.Text.Length > 16)
            {
                cardNumberError.Text = "Please enter a valid card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
            }
            else
            {
                cardNumberError.Text = "";
                cardNumberError.Visible = false;
            }

            //Checks Card CVV Number
            if (!Regex.IsMatch(CVVTB.Text, "^[0-9]*$"))
            {
                CVVError.Text = "Please enter a valid CVV number";
                CVVError.ForeColor = Color.Red;
                CVVError.Visible = true;
            }
            //checks if its empty or null
            else if (String.IsNullOrEmpty(CVVTB.Text))
            {
                CVVError.Text = "Please enter CVV number";
                CVVError.ForeColor = Color.Red;
                CVVError.Visible = true;
            }
            else if (CVVTB.Text.Length != 4)
            {
                CVVError.Text = "Please enter a 4 digit CVV number";
                CVVError.ForeColor = Color.Red;
                CVVError.Visible = true;
            }
            else
            {
                CVVError.Text = "";
                CVVError.Visible = false;
            }

            //Checks if card expiry date is chosen or not
            if (String.IsNullOrEmpty(cardExpiryTB.Text))
            {
                cardExpiryError.Text = "Please select card expiry date";
                cardExpiryError.ForeColor = Color.Red;
                cardExpiryError.Visible = true;
            }
            else
            {
                //int currentYear = DateTime.Now.Year;
                //int currentMonth = DateTime.Now.Month;
                //int currentDay = DateTime.Now.Day;

                //cardExpiryError.Text = currentMonth.ToString();
                //cardExpiryError.Text = cardExpiryTB.Text;
                DateTime inputDate = Convert.ToDateTime(cardExpiryTB.Text);
                double monthDifference = inputDate.Subtract(currentDate).Days / (365.25 / 12);
                if(monthDifference < 3)
                {
                    cardExpiryError.Text = "Please ensure that your expiry date is at least 3 months from current date";
                    //cardExpiryError.Text = monthDifference.ToString();
                    cardExpiryError.ForeColor = Color.Red;
                    cardExpiryError.Visible = true;
                }
                else
                {
                    //cardExpiryError.Text = monthDifference.ToString();
                    //cardExpiryError.ForeColor = Color.Black;
                    cardExpiryError.Text = "";
                    cardExpiryError.Visible = false;
                }
            }

            //checks if any error labels is empty or not
            if (String.IsNullOrEmpty(cardNumberError.Text)
                && String.IsNullOrEmpty(nameOnCardError.Text)
                && String.IsNullOrEmpty(cardExpiryError.Text)
                && String.IsNullOrEmpty(CVVError.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();
            
            //checks if all input has been validated
            if (validInput == true)
            {
                nameOnCardError.Visible = false;
                cardNumberError.Visible = false;
                cardExpiryError.Visible = false;
                CVVError.Visible = false;
                Response.Redirect("/PaymentInformation.aspx");
            }
            else
            {
                nameOnCardError.Visible = true;
                cardNumberError.Visible = true;
                cardExpiryError.Visible = true;
                CVVError.Visible = true;
            }
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

        //Initialise an object to store Recaptcha response
        public class reCaptchaResponseObject
        {
            public string success { get; set; }
            public List<string> ErrorMessage { get; set; }
        }

        public bool ValidateCaptcha()
        {
            bool result = true;

            //Retrieves captcha response from captcha api
            string captchaResponse = Request.Form["g-recaptcha-response"];

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://www.google.com/recaptcha/api/siteverify?secret=6LejmBwaAAAAAN_gzUf_AT0q_3ZrPbD5WP5oaTml &response=" + captchaResponse);

            try
            {
                using (WebResponse wResponse = req.GetResponse())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        //Read entire json response from recaptcha
                        string jsonResponse = readStream.ReadToEnd();

                        JavaScriptSerializer js = new JavaScriptSerializer();

                        reCaptchaResponseObject jsonObject = js.Deserialize<reCaptchaResponseObject>(jsonResponse);

                        //Console.WriteLine("--- Testing ---");
                        //Console.WriteLine(jsonObject);
                        //Read success property in json object
                        result = Convert.ToBoolean(jsonObject.success);
                    }
                }
                return result;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}