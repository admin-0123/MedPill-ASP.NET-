using System;
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
using System.Net.Mail;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using PayPal.Api;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using System.Collections.Specialized;
using System.Configuration;

namespace EDP_Clinic
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["Login"] = "someone@example.com";

            //string guidToken = Guid.NewGuid().ToString();
            //Session["AuthToken"] = guidToken;
            //HttpCookie AuthToken = new HttpCookie("AuthToken");
            //AuthToken.Value = guidToken;
            //Response.Cookies.Add(AuthToken);


            //Checks user session
            //if (Session["Login"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("Login.aspx", false);
            //    }
            //    else
            //    {
            //        Debug.WriteLine("Going to payment page");
            retrieveCardInfo();
            //    }
            //}
            ////No credentials at all
            //else
            //{
            //    Response.Redirect("Login.aspx", false);
            //}
        }
        protected void retrieveCardInfo()
        {
            string userID = Session["LoggedIn"].ToString().Trim();

            List<CardInfo> cifList = new List<CardInfo>();
            Service1Client client = new Service1Client();
            cifList = client.GetAllCards(userID).ToList<CardInfo>();

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

                Debug.WriteLine(cardExpiry.Substring(0, 4));
                Debug.WriteLine(cardExpiry.Substring(5, 2));

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
                    var emailLink = resultPayment.ReceiptEmail;
                    var resultConfirmPayment = service.Confirm(paymentIntentID);
                    Debug.WriteLine(resultConfirmPayment);
                    Debug.WriteLine("+++++++++++++++++++++++++++++++++");
                    var receiptLink = resultConfirmPayment.Charges.Data[0].ReceiptUrl;
                    Debug.WriteLine(receiptLink);
                    Debug.WriteLine(resultConfirmPayment);
                    SendEmail(receiptLink, emailLink);


                    string userID = Session["LoggedIn"].ToString().Trim();
                    DateTime dateSale = DateTime.Now;
                    string guid = Guid.NewGuid().ToString();

                    Service1Client client = new Service1Client();

                    int result = client.CreateReceipt(userID, dateSale, 200, true, receiptLink, guid);

                    //Add if else for create receipt

                    //TwilioSMS();

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
            //Response.Redirect
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

                string cardName = cif.CardName;
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
                    var emailLink = resultPayment.ReceiptEmail;
                    //Debug.WriteLine(emailLink);
                    var resultConfirmPayment = service.Confirm(paymentIntentID);
                    var receiptLink = resultConfirmPayment.Charges.Data[0].ReceiptUrl;
                    Debug.WriteLine(receiptLink);
                    Debug.WriteLine(resultConfirmPayment);
                    SendEmail(receiptLink, emailLink);

                    DateTime dateSale = DateTime.Now;
                    string guid = Guid.NewGuid().ToString();

                    int result = client.CreateReceipt(userID, dateSale, 200, true, receiptLink, guid);

                    //TwilioSMS();
                    Response.Redirect("AfterPayment.aspx", false);
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

        //Send email function
        protected void SendEmail(string receiptLink, string emailLink)
        {
            SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
            emailClient.Credentials = new NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.Subject = "Payment Receipt";
            mail.SubjectEncoding = Encoding.UTF8;
            mail.Body = "This is your receipt. Click on the link below to view it. <br>" + receiptLink;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;

            mail.From = new MailAddress("bryanchinzw@gmail.com");
            mail.To.Add(new MailAddress(emailLink));
            emailClient.Send(mail);
        }

        //PayPal Payment
        protected void payPalBtn_Click(object sender, EventArgs e)
        {
            // Get a reference to the config
            var config = ConfigManager.Instance.GetProperties();

            // Use OAuthTokenCredential to request an access token from PayPal
            var accessToken = new OAuthTokenCredential(config).GetAccessToken();

            var apiContext = new APIContext(accessToken);

            string payerId = Request.Params["PayerID"];

            if (String.IsNullOrEmpty(payerId))
            {
                var itemList = new ItemList()
                {
                    items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "MedPill Services",
                            currency = "SGD",
                            price = "200",
                            quantity = "1",
                            sku = "sku"
                        }
                    }
                };


                var payer = new Payer() { payment_method = "paypal" };

                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Payment.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = redirectUrl + "&cancel=true",
                    return_url = redirectUrl
                };

                var details = new Details()
                {
                    tax = "0",
                    shipping = "0",
                    subtotal = "200"
                };

                var amount = new Amount()
                {
                    currency = "SGD",
                    total = "200.00", // Total must be equal to sum of shipping, tax and subtotal.
                    details = details
                };

                var transactionList = new List<Transaction>();

                transactionList.Add(new Transaction()
                {
                    description = "Transaction description.",
                    invoice_number = Guid.NewGuid().ToString(),
                    amount = amount,
                    item_list = itemList
                });

                var payments = new PayPal.Api.Payment()
                {
                    intent = "sale",
                    payer = payer,
                    transactions = transactionList,
                    redirect_urls = redirUrls
                };

                var createdPayment = payments.Create(apiContext);

                var links = createdPayment.links.GetEnumerator();

                var link = links.Current;

                //while (links.MoveNext())
                //{
                //    var link = links.Current;
                //    if (link.rel.ToLower().Trim().Equals("approval_url"))
                //    {
                //        var flow = RecordRedirectUrl("Redirect to PayPal to approve the payment...", link.href);
                //    }
                //}
                Session.Add(guid, createdPayment.id);
                //Session.Add("flow-" + guid, link.href);
            }
            else
            {

            }

            var payment = PayPal.Api.Payment.Get(apiContext, "PAY-0XL713371A312273YKE2GCNI");//Payment.Get(apiContext, "PAY-0XL713371A312273YKE2GCNI");

            Debug.WriteLine(payment.ConvertToJson());

            //// Initialize the apiContext's configuration with the default configuration for this application.
            //apiContext.Config = ConfigManager.Instance.GetProperties();

            //// Define any custom configuration settings for calls that will use this object.
            //apiContext.Config["connectionTimeout"] = "1000"; // Quick timeout for testing purposes

            //// Define any HTTP headers to be used in HTTP requests made with this APIContext object
            //if (apiContext.HTTPHeaders == null)
            //{
            //    apiContext.HTTPHeaders = new Dictionary<string, string>();
            //}
            //apiContext.HTTPHeaders["some-header-name"] = "some-value";

            //string payerId = Request.Params["PayerID"];
            //if (string.IsNullOrEmpty(payerId))
            //{
            //    // ###Items
            //    // Items within a transaction.
            //    var itemList = new ItemList()
            //    {
            //        items = new List<Item>()
            //        {
            //            new Item()
            //            {
            //                name = "Item Name",
            //                currency = "USD",
            //                price = "15",
            //                quantity = "5",
            //                sku = "sku"
            //            }
            //        }
            //    };

            //    // ###Payer
            //    // A resource representing a Payer that funds a payment
            //    // Payment Method
            //    // as `paypal`
            //    var payer = new Payer() { payment_method = "paypal" };

            //    // ###Redirect URLS
            //    // These URLs will determine how the user is redirected from PayPal once they have either approved or canceled the payment.
            //    var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/PaymentWithPayPal.aspx?";
            //    var guid = Convert.ToString((new Random()).Next(100000));
            //    var redirectUrl = baseURI + "guid=" + guid;
            //    var redirUrls = new RedirectUrls()
            //    {
            //        cancel_url = redirectUrl + "&cancel=true",
            //        return_url = redirectUrl
            //    };

            //    // ###Details
            //    // Let's you specify details of a payment amount.
            //    var details = new Details()
            //    {
            //        tax = "15",
            //        shipping = "10",
            //        subtotal = "75"
            //    };

            //    // ###Amount
            //    // Let's you specify a payment amount.
            //    var amount = new Amount()
            //    {
            //        currency = "USD",
            //        total = "100.00", // Total must be equal to sum of shipping, tax and subtotal.
            //        details = details
            //    };

            //    // ###Transaction
            //    // A transaction defines the contract of a
            //    // payment - what is the payment for and who
            //    // is fulfilling it. 
            //    var transactionList = new List<Transaction>();

            //    // The Payment creation API requires a list of
            //    // Transaction; add the created `Transaction`
            //    // to a List
            //    transactionList.Add(new Transaction()
            //    {
            //        description = "Transaction description.",
            //        invoice_number = Common.GetRandomInvoiceNumber(),
            //        amount = amount,
            //        item_list = itemList
            //    });

            //    // ###Payment
            //    // A Payment Resource; create one using
            //    // the above types and intent as `sale` or `authorize`
            //    var payment = new Payment()
            //    {
            //        intent = "sale",
            //        payer = payer,
            //        transactions = transactionList,
            //        redirect_urls = redirUrls
            //    };

            //    // ^ Ignore workflow code segment
            //    #region Track Workflow
            //    this.flow.AddNewRequest("Create PayPal payment", payment);
            //    #endregion

            //    // Create a payment using a valid APIContext
            //    var createdPayment = payment.Create(apiContext);

            //    // ^ Ignore workflow code segment
            //    #region Track Workflow
            //    this.flow.RecordResponse(createdPayment);
            //    #endregion

            //    // Using the `links` provided by the `createdPayment` object, we can give the user the option to redirect to PayPal to approve the payment.
            //    var links = createdPayment.links.GetEnumerator();
            //    while (links.MoveNext())
            //    {
            //        var link = links.Current;
            //        if (link.rel.ToLower().Trim().Equals("approval_url"))
            //        {
            //            this.flow.RecordRedirectUrl("Redirect to PayPal to approve the payment...", link.href);
            //        }
            //    }
            //    Session.Add(guid, createdPayment.id);
            //    Session.Add("flow-" + guid, this.flow);
            //}
            //else
            //{
            //    var guid = Request.Params["guid"];

            //    // ^ Ignore workflow code segment
            //    #region Track Workflow
            //    this.flow = Session["flow-" + guid] as RequestFlow;
            //    this.RegisterSampleRequestFlow();
            //    this.flow.RecordApproval("PayPal payment approved successfully.");
            //    #endregion

            //    // Using the information from the redirect, setup the payment to execute.
            //    var paymentId = Session[guid] as string;
            //    var paymentExecution = new PaymentExecution() { payer_id = payerId };
            //    var payment = new Payment() { id = paymentId };

            //    // ^ Ignore workflow code segment
            //    #region Track Workflow
            //    this.flow.AddNewRequest("Execute PayPal payment", payment);
            //    #endregion

            //    // Execute the payment.
            //    var executedPayment = payment.Execute(apiContext, paymentExecution);
            //    // ^ Ignore workflow code segment


            //    // For more information, please visit [PayPal Developer REST API Reference](https://developer.paypal.com/docs/api/).
            //}


            //HttpClient client = new HttpClient();

            //client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com/");
            //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("client_id", "AT9DJyeJMIR8vwF_hXg51sixRS0sEi3gKj6NZIzrlFq0JdlldbY5NKstWc6AYYNYiNIjZz4xLwnac153");
            //client.DefaultRequestHeaders
            //    .Accept
            //    .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Task<HttpResponseMessage> responseTask;
            //responseTask = client.GetAsync("v1/oauth2/token");
            //responseTask.Wait();

            //var result = responseTask.Result;
            //Debug.WriteLine(result.ToString());
            //Debug.WriteLine(result.StatusCode);
            ////Debug.WriteLine(result.Content.ReadAsStreamAsync());
            //var jsonResponse = result.Content.ReadAsStreamAsync();
            //Debug.WriteLine(jsonResponse.Result);

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