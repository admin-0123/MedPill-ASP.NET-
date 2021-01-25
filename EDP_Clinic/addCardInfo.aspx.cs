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
using System.Diagnostics;
using EDP_Clinic.EDP_DBReference;

namespace EDP_Clinic
{
    public partial class addCardInfo : System.Web.UI.Page
    {
        byte[] Key;
        byte[] IV;
        protected void Page_Load(object sender, EventArgs e)
        {
            /*  We will check user session here soon TM */


            //We check sessions here
            //  Checks if user pass is to add card info
            if (Session["authOTPAToken"] != null && Request.Cookies["authOTPAToken"] != null)
            {
                if (!Session["authOTPAToken"].ToString().Equals(Request.Cookies["authOTPAToken"].Value))
                {
                    Response.Redirect("CardList.aspx", false);
                }
                else
                {
                    //Nothing to put here since all credentials are there
                }
            }
            else
            {
                Response.Redirect("CardList.aspx", false);
            }
        }

        private bool ValidateInput()
        {
            DateTime currentDate = DateTime.Now;
            var greenColor = Color.Green;

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
                nameOnCardError.Text = "Excellent";
                nameOnCardError.ForeColor = Color.Green;
                nameOnCardError.Visible = true;
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
                cardNumberError.Text = "Excellent";
                cardNumberError.ForeColor = Color.Green;
                cardNumberError.Visible = true;
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
                CVVError.Text = "Excellent";
                CVVError.ForeColor = Color.Green;
                CVVError.Visible = true;
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
                    cardExpiryError.Text = "Excellent";
                    cardExpiryError.ForeColor = Color.Green;
                    cardExpiryError.Visible = true;
                }
            }

            //checks if any error labels is green or not
            if (cardNumberError.ForeColor == greenColor
                && nameOnCardError.ForeColor == greenColor
                && cardExpiryError.ForeColor == greenColor
                && CVVError.ForeColor == greenColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Update button is actually add card btn
        protected void addBtn_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();

            bool validCaptcha = ValidateCaptcha();
            
            //checks if all input has been validated
            if (validInput == true && validCaptcha == true)
            {
                //Will add another if else statement to check if card number already exists or not
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.GenerateKey();
                Key = cipher.Key;
                IV = cipher.IV;

                Service1Client client = new Service1Client();
                bool resultCheck = client.CheckCardByCardNumber(cardNumberTB.Text.Trim());
                //Checks if there is an existing card here
                //It will return null if there is 2 cards here
                //CardInfo cif = null;
                if(resultCheck == true)
                {

                    cardNumberError.Text = "Please enter a valid card information";
                    cardNumberError.Visible = true;
                    cardNumberError.ForeColor = Color.Red;
                    Debug.WriteLine("Card existed in database");
                }
                else
                {
                    string guid = Guid.NewGuid().ToString();
                    Debug.WriteLine(guid);
                    string cardNumberInput = cardNumberTB.Text.Trim().Substring(12, 4);
                    string uniqueIdentifier = cardNumberInput + "-" + guid;
                    Debug.WriteLine(uniqueIdentifier);
                    //Service1Client client = new Service1Client();
                    int result = client.CreateCardInfo(nameOnCardTB.Text.Trim(), cardNumberTB.Text.Trim(),
                        Convert.ToDateTime(cardExpiryTB.Text), CVVTB.Text.Trim(), IV, Key, true, uniqueIdentifier);
                    if (result == 1)
                    {
                        //Remove pass to add card info
                        Session.Remove("authOTPAToken");
                        Response.Cookies["authOTPAToken"].Value = string.Empty;
                        Response.Cookies["authOTPAToken"].Expires = DateTime.Now.AddMonths(-20);

                        Response.Redirect("CardList.aspx");
                    }
                    else
                    {
                        errorMsg.Text = "Please enter valid information";
                    }

                    /*
                    nameOnCardError.Visible = false;
                    cardNumberError.Visible = false;
                    cardExpiryError.Visible = false;
                    CVVError.Visible = false;*/
                }
            }
            else
            {
                nameOnCardError.Visible = true;
                cardNumberError.Visible = true;
                cardExpiryError.Visible = true;
                CVVError.Visible = true;
            }
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

        protected void backBtn_Click(object sender, EventArgs e)
        {
            //Remove pass to add card info
            Session.Remove("authOTPAToken");
            Response.Cookies["authOTPAToken"].Value = string.Empty;
            Response.Cookies["authOTPAToken"].Expires = DateTime.Now.AddMonths(-20);

            Response.Redirect("CardList.aspx", false);
        }
    }
}