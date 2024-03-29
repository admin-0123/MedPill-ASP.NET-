using EDP_Clinic.App_Code;
using EDP_Clinic.EDP_DBReference;
using Stripe;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace EDP_Clinic
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks user session
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("~/Login.aspx", false);
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
                Response.Redirect("~/Login.aspx", false);
            }
        }
        protected void retrieveCardInfo()
        {
            string userID = Session["LoggedIn"].ToString().Trim();

            Service1Client client = new Service1Client();
            List<CardInfo> cifList = client.GetAllCards(userID).ToList<CardInfo>();

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
            RecaptchaValidation validCaptcha = new RecaptchaValidation();
            string captchaResponse = Request.Form["g-recaptcha-response"];

            bool validInput = ValidateInput();

            bool captchaResult = validCaptcha.ValidateCaptcha(captchaResponse);

            if (validInput == true && captchaResult == true)
            {
                string cardNumber = HttpUtility.HtmlEncode(cardNumberTB.Text.Trim());

                // string cardName = HttpUtility.HtmlEncode(nameOnCardTB.Text.Trim());
                string cardExpiry = HttpUtility.HtmlEncode(cardExpiryTB.Text.Trim());
                string cardCVV = HttpUtility.HtmlEncode(CVVTB.Text.Trim());

                long cardYear = Convert.ToInt32(cardExpiry.Substring(0, 4));
                long cardMonth = Convert.ToInt32(cardExpiry.Substring(5, 2));

                Debug.WriteLine(cardExpiry.Substring(0, 4));
                Debug.WriteLine(cardExpiry.Substring(5, 2));

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

                    var options = new PaymentIntentCreateOptions
                    {
                        //We will change the total amount charged here
                        Amount = 20000,
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
                    var receipientEmail = resultPayment.ReceiptEmail;
                    var resultConfirmPayment = service.Confirm(paymentIntentID);
                    Debug.WriteLine(resultConfirmPayment);
                    Debug.WriteLine("+++++++++++++++++++++++++++++++++");
                    var receiptLink = resultConfirmPayment.Charges.Data[0].ReceiptUrl;
                    Debug.WriteLine(receiptLink);
                    Debug.WriteLine(resultConfirmPayment);

                    string subjectHeader = "Payment Receipt";
                    string message = "This is your receipt. Click on the link below to view it. <br>" + receiptLink;

                    EmailService emailService = new EmailService();
                    emailService.SendEmail(receipientEmail, subjectHeader, message);


                    string userID = Session["LoggedIn"].ToString().Trim();
                    DateTime dateSale = DateTime.Now;
                    string guid = Guid.NewGuid().ToString();

                    Service1Client client = new Service1Client();

                    int result = client.CreateReceipt(userID, dateSale, 200, true, receiptLink, guid);

                    TwilioSMS();
                    Response.Redirect("~/AfterPayment.aspx", false);
                }
                catch (StripeException ex)
                {
                    var errorCode = ex.StripeError.Code.ToString();
                    if (errorCode == "incorrect_number")
                    {
                        errorMsg.Text = "Please enter a correct card number";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else if (errorCode == "incorrect_cvc")
                    {
                        errorMsg.Text = "Please enter a correct card number";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else if (errorCode == "invalid_expiry_month")
                    {
                        errorMsg.Text = "Please enter a correct expiry card month";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else if (errorCode == "invalid_expiry_year")
                    {
                        errorMsg.Text = "Please enter a correct expiry card year";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else
                    {
                        errorMsg.Text = "Please correct card credentials";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                        Debug.WriteLine(ex.ToString());
                    }
                    //throw new Exception(ex.ToString());
                }
            }
            else
            {
                //Reset to empty fields
                nameOnCardTB.Text = "";
                cardNumberTB.Text = "";
                cardExpiryTB.Text = "";
                CVVTB.Text = "";
                Debug.WriteLine("Wrong format or a bot");
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PRFA2.aspx", false);
        }

        protected void cardListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Checks if button clicked is view more button
            if (String.Equals(e.CommandName, "payNow"))
            {
                string userID = Session["LoggedIn"].ToString().Trim();

                Service1Client client = new Service1Client();

                string uniqueIdentifier = e.CommandArgument.ToString().Trim();

                CardInfo cif = client.GetCardByCardNumber(userID, uniqueIdentifier);

                string cardNumber = cif.CardNumber;

                // string cardName = cif.CardName;
                DateTime cardExpiry = cif.CardExpiry;
                string cardCVV = cif.CVVNumber;

                long cardYear = cardExpiry.Year;
                long cardMonth = cardExpiry.Month;

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

                    var options = new PaymentIntentCreateOptions
                    {
                        //We will change the total amount charged here

                        Amount = 20000,
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
                    var receipientEmail = resultPayment.ReceiptEmail;
                    //Debug.WriteLine(emailLink);

                    var resultConfirmPayment = service.Confirm(paymentIntentID);
                    var receiptLink = resultConfirmPayment.Charges.Data[0].ReceiptUrl;

                    Debug.WriteLine(receiptLink);
                    Debug.WriteLine(resultConfirmPayment);
                    // SendEmail(receiptLink, receipientEmail);

                    string subjectHeader = "Payment Receipt";
                    string message = "This is your receipt. Click on the link below to view it. <br>" + receiptLink;

                    EmailService emailService = new EmailService();
                    emailService.SendEmail(receipientEmail, subjectHeader, message);

                    DateTime dateSale = DateTime.Now;
                    string guid = Guid.NewGuid().ToString();

                    int result = client.CreateReceipt(userID, dateSale, 200, true, receiptLink, guid);

                    //TwilioSMS();
                    Response.Redirect("~/AfterPayment.aspx", false);
                }
                catch (StripeException ex)
                {
                    var errorCode = ex.StripeError.Code.ToString();
                    if (errorCode == "incorrect_number")
                    {
                        errorMsg.Text = "Please enter a correct card number";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else if (errorCode == "incorrect_cvc")
                    {
                        errorMsg.Text = "Please enter a correct card number";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else if (errorCode == "invalid_expiry_month")
                    {
                        errorMsg.Text = "Please enter a correct expiry card month";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else if (errorCode == "invalid_expiry_year")
                    {
                        errorMsg.Text = "Please enter a correct expiry card year";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                    }
                    else
                    {
                        errorMsg.Text = "Please correct card credentials";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                        Debug.WriteLine(ex.ToString());
                    }
                    //throw new Exception(ex.ToString());
                }
            }
        }

        protected void TwilioSMS()
        {
            Debug.WriteLine("Calling Twilio SMS Function");
            //Retrieve keys from web.config
            NameValueCollection myKeys = ConfigurationManager.AppSettings;

            //Reading keys
            var twilioAccSid = myKeys["TWILIO_ACCOUNT_SID"];
            var twilioAuth = myKeys["TWILIO_AUTH_TOKEN"];
            //const string serviceSid = "IS118b50a34ccf7d845af153585b800f7b";

            TwilioClient.Init(twilioAccSid, twilioAuth);
            //(205) 946 - 1964
            //  + 1 213 279 6783
            var message = MessageResource.Create(
            body: "Dear user, you have successfully paid your appointment.",
            from: new Twilio.Types.PhoneNumber("+12132796783"),
            to: new Twilio.Types.PhoneNumber("+6590251744")
        );

            Debug.WriteLine(message.Sid);
        }
    }
}