﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Stripe;
using Stripe.Checkout;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using EDP_Clinic.EDP_DBReference;
using System.Diagnostics;
using System.Net.Http;

namespace EDP_Clinic
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = "someone@example.com";

            string guidToken = Guid.NewGuid().ToString();
            Session["AuthToken"] = guidToken;
            HttpCookie AuthToken = new HttpCookie("AuthToken");
            AuthToken.Value = guidToken;
            Response.Cookies.Add(AuthToken);


            //Checks user session
            if (Session["Login"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Debug.WriteLine("Going to payment page");
                    retrieveCardInfo();
                }
            }
            //No credentials at all
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }
        protected void retrieveCardInfo()
        {
            List<CardInfo> cifList = new List<CardInfo>();
            Service1Client client = new Service1Client();
            cifList = client.GetAllCards().ToList<CardInfo>();

            cardListView.Visible = true;
            cardListView.DataSource = cifList;
            cardListView.DataBind();
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
            else if (!Regex.IsMatch(nameOnCardTB.Text, "^[a-zA-Z0-9 ]*$"))
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
            //If its not 16-digits
            else if (cardNumberTB.Text.Length != 16)
            {
                cardNumberError.Text = "Please enter a 16-digit card number";
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
            else if (CVVTB.Text.Length != 3)
            {
                CVVError.Text = "Please enter a 3 digit CVV number";
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
                DateTime inputDate = Convert.ToDateTime(cardExpiryTB.Text);
                double monthDifference = inputDate.Subtract(currentDate).Days / (365.25 / 12);
                if (monthDifference < 3)
                {
                    cardExpiryError.Text = "Please ensure that your expiry date is at least 3 months from current date";
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

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();

            bool validCaptcha = ValidateCaptcha();

            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://localhost:44310/");

            if (validInput == true && validCaptcha == true)
            {

                string cardNumber = HttpUtility.HtmlEncode(cardNumberTB.Text.Trim());

                string cardName = HttpUtility.HtmlEncode(nameOnCardTB.Text.Trim());
                string cardExpiry = HttpUtility.HtmlEncode(cardExpiryTB.Text.Trim());
                string cardCVV = HttpUtility.HtmlEncode(CVVTB.Text.Trim());

                long cardYear = Convert.ToInt32(cardExpiry.Substring(0, 4));
                long cardMonth = Convert.ToInt32(cardExpiry.Substring(5, 2));

                Debug.WriteLine(cardNumber);

                Debug.WriteLine(cardExpiry.Substring(0, 4));
                Debug.WriteLine(cardExpiry.Substring(5, 2));

                Debug.WriteLine(cardMonth);


                //Consolidate Stripe Payment API by 3/2/2021


                //Testing Stripe
                StripeConfiguration.ApiKey = "sk_test_51HveuKAVRV4JC5fkn1zDUAxrUGZgetyR05RVCIGpNFFAlZczY6xwAQtn60BO1stWGXHJJJOh1DZQozuL4RtJSW4700ONZrgRzD";

                try
                {
                    var paymentMethod = new PaymentMethodCreateOptions
                    {
                        Type = "card",
                        Card = new PaymentMethodCardOptions
                        {
                            Number = cardNumber,
                            ExpMonth = cardMonth,
                            ExpYear = cardYear,
                            Cvc = cardCVV,
                        },
                    };
                    var paymentMethodService = new PaymentMethodService();
                    var resultPay = paymentMethodService.Create(paymentMethod);
                    var paymentId = resultPay.Id;
                    Debug.WriteLine(resultPay.Id);
                    Debug.WriteLine(resultPay.Object);
                    Debug.WriteLine(resultPay.Card.Brand);

                    var options = new PaymentIntentCreateOptions
                    {
                        //We will change the total amount charged here


                        Amount = 1000,
                        Currency = "sgd",
                        PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                        ReceiptEmail = "cilipadi270@gmail.com",
                        PaymentMethod = paymentId,
                        Description = "Paying for medical appointment",
                    };
                    var service = new PaymentIntentService();
                    var resultPayment = service.Create(options);
                    var paymentIntentID = resultPayment.Id;
                    var resultConfirmPayment = service.Confirm(paymentIntentID);
                    Debug.WriteLine(resultConfirmPayment);
                    Debug.WriteLine("+++++++++++++++++++++++++++++++++");
                    //Debug.WriteLine(options);
                    //Debug.WriteLine(resultPayment);
                    //Debug.WriteLine(resultPayment.Id);
                    //Debug.WriteLine("===========================================");
                    //Debug.WriteLine(resultPayment.Status);

                    //var service = new PaymentIntentService();
                    //var paymentIntent = service.Create(options);
                    //Debug.WriteLine(paymentIntent);

                    //var service = new PaymentMethodService();
                    //service.Create(options);

                    //var options = new SessionCreateOptions
                    //{
                    //    SuccessUrl = "https://localhost:44310/Home.aspx",
                    //    CancelUrl = "https://example.com/cancel",
                    //    PaymentMethodTypes = new List<string>
                    //  {
                    //    "card",
                    //  },
                    //    LineItems = new List<SessionLineItemOptions>
                    //  {
                    //    new SessionLineItemOptions
                    //    {
                    //      Price = "price_1IFcWdAVRV4JC5fkywjZt6Tf",
                    //      Quantity = 1,
                    //    },
                    //  },
                    //    Mode = "payment",
                    //};
                    //var service = new SessionService();
                    //service.Create(options);


                    //Debug.WriteLine(service);
                    Response.Redirect("AfterPayment.aspx", false);
                }
                catch (StripeException ex)
                {

                    //Add more error functions here
                    Debug.WriteLine(ex.ToString());
                    throw new Exception(ex.ToString());
                }
            }
            else
            {
                //Error code here
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

        }

        protected void cardListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Checks if button clicked is view more button
            if (String.Equals(e.CommandName, "payNow"))
            {
                Service1Client client = new Service1Client();

                string uniqueIdentifier = e.CommandArgument.ToString();

                CardInfo cif = client.GetCardByCardNumber(uniqueIdentifier);

                string cardNumber = cif.CardNumber;

                string cardName = cif.CardName;
                DateTime cardExpiry = cif.CardExpiry;
                string cardCVV = cif.CVVNumber;

                long cardYear = cardExpiry.Year;
                long cardMonth = cardExpiry.Month;

                Debug.WriteLine(cardNumber);
                Debug.WriteLine(cardName);
                Debug.WriteLine(cardYear);
                Debug.WriteLine(cardMonth);
                Debug.WriteLine(cardCVV);

                Debug.WriteLine("===============");
                Debug.WriteLine(e.CommandArgument.ToString());
                //Testing Stripe
                StripeConfiguration.ApiKey = "sk_test_51HveuKAVRV4JC5fkn1zDUAxrUGZgetyR05RVCIGpNFFAlZczY6xwAQtn60BO1stWGXHJJJOh1DZQozuL4RtJSW4700ONZrgRzD";

                try
                {
                    var paymentMethod = new PaymentMethodCreateOptions
                    {
                        Type = "card",
                        Card = new PaymentMethodCardOptions
                        {
                            Number = cardNumber,
                            ExpMonth = cardMonth,
                            ExpYear = cardYear,
                            Cvc = cardCVV,
                        },
                    };
                    var paymentMethodService = new PaymentMethodService();
                    var resultPay = paymentMethodService.Create(paymentMethod);
                    var paymentId = resultPay.Id;
                    Debug.WriteLine(resultPay.Id);
                    Debug.WriteLine(resultPay.Object);
                    Debug.WriteLine(resultPay.Card.Brand);

                    var options = new PaymentIntentCreateOptions
                    {
                        //We will change the total amount charged here


                        Amount = 1000,
                        Currency = "sgd",
                        PaymentMethodTypes = new List<string>
                {
                    "card",
                },
                        ReceiptEmail = "cilipadi270@gmail.com",
                        PaymentMethod = paymentId,
                        Description = "Paying for medical appointment",
                    };
                    var service = new PaymentIntentService();
                    var resultPayment = service.Create(options);
                    var paymentIntentID = resultPayment.Id;
                    var resultConfirmPayment = service.Confirm(paymentIntentID);
                    Debug.WriteLine(resultConfirmPayment);
                    Debug.WriteLine("+++++++++++++++++++++++++++++++++");
                    Response.Redirect("AfterPayment.aspx", false);
                }
                catch (StripeException ex)
                {

                    //Add more error functions here
                    Debug.WriteLine(ex.ToString());
                    throw new Exception(ex.ToString());
                }

            }
        }
    }
}