using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Configuration;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
using Twilio;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Rest.Notify;
using EDP_Clinic.EDP_DBReference;
using System.Diagnostics;
using Twilio.Rest.Api.V2010.Account;

namespace EDP_Clinic
{
    public partial class Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session code implemented on 27/01/2021

            Session["Login"] = "someone@example.com";

            string guidToken = Guid.NewGuid().ToString();
            Session["AuthToken"] = guidToken;
            HttpCookie AuthToken = new HttpCookie("AuthToken");
            AuthToken.Value = guidToken;
            Response.Cookies.Add(AuthToken);

            if (Session["Login"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Debug.WriteLine("Currently at Authentication page");
                    //Checks a list of sessions to give authentication

                    //For testing purposes
                    //Each session should store random GUID
                    //Session["addCardInfo"] = "111";
                    //Session["changeCardInfo"] = "222";
                    //Session["deleteCardInfo"] = "333";


                    //Cookies
                    //Comment out for testing purposes
                    //Response.Cookies["addCardInfo"].Value = "111";
                    //Response.Cookies["addCardInfo"].Expires = DateTime.Now.AddMinutes(15);

                    //Response.Cookies["changeCardInfo"].Value = "222";
                    //Response.Cookies["changeCardInfo"].Expires = DateTime.Now.AddMinutes(15);

                    //Response.Cookies["deleteCardInfo"].Value = "333";
                    //Response.Cookies["deleteCardInfo"].Expires = DateTime.Now.AddMinutes(15);


                    //addCardCookie.Values.add(true);
                    //Response.Cookies.Add(addCardCookie);

                    //This resulting value will direct user to respective pages
                    int validSessionReason = checkIntention();

                    if (validSessionReason == 0)
                    {
                        Response.Redirect("CardList.aspx");
                    }
                    //Else if statements are for testing purposes only
                    /*
                    else if(validSessionReason == 1)
                    {
                        OTPError.Text = "Add Card";
                    }
                    else if (validSessionReason == 2)
                    {
                        OTPError.Text = "Change Card";
                    }
                    else if (validSessionReason == 3)
                    {
                        OTPError.Text = "Delete Card";
                    }*/

                    //Calls Twilio API
                    else
                    {
                        //Might put the Twilio Verify API into a function - 6/1/2021

                        //Retrieve keys from web.config
                        NameValueCollection myKeys = ConfigurationManager.AppSettings;

                        //Reading keys
                        var twilioAccSid = myKeys["TWILIO_ACCOUNT_SID"];
                        var twilioAuth = myKeys["TWILIO_AUTH_TOKEN"];
                        TwilioClient.Init(twilioAccSid, twilioAuth);

                        Debug.WriteLine("Calling Twilio OTP Function");

                        //Sends OTP

                        /*var verification = VerificationResource.Create(
                            to: "+6590251744",
                            channel: "sms",
                            pathServiceSid: "VA4ceee8345f84c5be3a44bc9ab3db5790"
                        );

                        Debug.WriteLine(verification.Sid);
                        //Console.WriteLine(verification.Sid);*/
                    }
                }
            }
            else
            {
                Response.Redirect("Login.aspx", false);
            }

        }
        //Checks Sessions and Cookies which are GUIDs
        private int checkIntention()
        {
            int resultNum;
            //  Checks if users intention is to add cards
            if (Session["addCardInfo"] != null && Request.Cookies["addCardInfo"] != null)
            {
                if (!Session["addCardInfo"].ToString().Equals(Request.Cookies["addCardInfo"].Value))
                {
                    //Response.Redirect("CardList.aspx");
                    resultNum = 0;
                    return resultNum;
                }
                else
                {
                    //OTPError.Text = "Add Card";
                    resultNum = 1;
                    return resultNum;
                }
            }
            //  Checks if users intention is to change cards
            else if (Session["changeCardInfo"] != null && Request.Cookies["changeCardInfo"] != null)
            {
                if (!Session["changeCardInfo"].ToString().Equals(Request.Cookies["changeCardInfo"].Value))
                {
                    //Response.Redirect("CardList.aspx");
                    resultNum = 0;
                    return resultNum;
                }
                else
                {
                    //OTPError.Text = "Change Card";
                    resultNum = 2;
                    return resultNum;
                }
            }
            //  Checks if users intention is to delete card
            else if (Session["deleteCardInfo"] != null && Request.Cookies["deleteCardInfo"] != null)
            {
                if (!Session["deleteCardInfo"].ToString().Equals(Request.Cookies["deleteCardInfo"].Value))
                {
                    //Response.Redirect("CardList.aspx");
                    resultNum = 0;
                    return resultNum;
                }
                else
                {
                    //OTPError.Text = "Delete Card";
                    resultNum = 3;
                    return resultNum;
                }
            }
            //  Checks if users intention is to delete card
            else if (Session["viewCardInfo"] != null && Request.Cookies["viewCardInfo"] != null)
            {
                if (!Session["viewCardInfo"].ToString().Equals(Request.Cookies["viewCardInfo"].Value))
                {
                    //Response.Redirect("CardList.aspx");
                    resultNum = 0;
                    return resultNum;
                }
                else
                {
                    //OTPError.Text = "Delete Card";
                    resultNum = 4;
                    return resultNum;
                }
            }
            else
            {
                //Response.Redirect("CardList.aspx");
                resultNum = 0;
                return resultNum;
            }
        }

        //Checks OTP sent to user's phone no.
        private bool checkOTP()
        {

            //Checks OTP
            var verificationCheck = VerificationCheckResource.Create(
                to: "+6590251744",
                code: OTPTB.Text.ToString().Trim(),
                pathServiceSid: "VA4ceee8345f84c5be3a44bc9ab3db5790"
            );

            //For debugging purposes
            //Refer to https://www.twilio.com/docs/verify/api/verification-check
            Console.WriteLine(verificationCheck.Status);

            string otpResult = verificationCheck.Status;

            //If user enters the right OTP 
            if (otpResult == "approved")
            {
                return true;
            }
            else if (otpResult == "pending")
            {
                return false;
            }
            else if (otpResult == "canceled")
            {
                return false;
            }
            else
            {
                return false;
            }
        }

        //Checks user inputs
        private bool ValidateInput()
        {
            var greenColor = Color.Green;

            //Checks if OTP is empty or null
            if (String.IsNullOrEmpty(OTPTB.Text))
            {
                OTPError.Text = "Please enter 6-digit OTP";
                OTPError.ForeColor = Color.Red;
                OTPError.Visible = true;
            }
            //Ensures that OTP consist of numbers
            else if (!Regex.IsMatch(OTPTB.Text, "^[0-9]*$"))
            {
                OTPError.Text = "Please enter a valid 6-digit OTP";
                OTPError.ForeColor = Color.Red;
                OTPError.Visible = true;
            }
            //Checks if OTP contains 6 digits long
            else if (OTPTB.Text.Length != 6)
            {
                OTPError.Text = "Please enter a 6-digit OTP";
                OTPError.ForeColor = Color.Red;
                OTPError.Visible = true;
            }
            //Valid
            else
            {
                OTPError.Text = "Excellent";
                OTPError.ForeColor = Color.Green;
                OTPError.Visible = true;
            }

            if (OTPError.ForeColor == greenColor)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Twilio SMS API
        //Will need to put in parameters to add in phone number and personalise message
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
            body: "Dear user, an authentication has been made on your account.",
            from: new Twilio.Types.PhoneNumber("+12132796783"),
            to: new Twilio.Types.PhoneNumber("+6590251744")
        );

            Debug.WriteLine(message.Sid);
        }

        protected void verifyBtn_Click(object sender, EventArgs e)
        {
            bool ValidInput = ValidateInput();

            bool validCaptcha = ValidateCaptcha();

            int validSessionReason = checkIntention();

            bool validOTP = true;// checkOTP();

            //Checks if user enters a valid OTP format and is not a bot
            if (ValidInput == true && validCaptcha == true)
            {
                //OTPError.Visible = false;
                //string guid = Guid.NewGuid().ToString();
                //Session["AuthOTPToken"] = guid;

                //If OTP is valid
                if (validOTP == true)
                {
                    //Call Twilio SMS Function
                    //TwilioSMS();

                    //A bunch of if else statements here to redirect user to respective pages
                    if (validSessionReason == 1)
                    {
                        //Remove add card info session and cookie
                        Session.Remove("addCardInfo");
                        Response.Cookies["addCardInfo"].Value = string.Empty;
                        Response.Cookies["addCardInfo"].Expires = DateTime.Now.AddMonths(-20);

                        //Create valid pass for user to add card info
                        string guid = Guid.NewGuid().ToString();
                        Session["authOTPAToken"] = guid;

                        Response.Cookies.Add(new HttpCookie("authOTPAToken", guid));
                        Response.Redirect("addCardInfo.aspx", false);
                    }

                    //Remove change card function
                    else if (validSessionReason == 2)
                    {
                        //Remove change card info session and cookie
                        Session.Remove("changeCardInfo");
                        Response.Cookies["changeCardInfo"].Value = string.Empty;
                        Response.Cookies["changeCardInfo"].Expires = DateTime.Now.AddMonths(-20);

                        //Create valid pass for user to change card info
                        string guid = Guid.NewGuid().ToString();
                        Session["authOTPCToken"] = guid;

                        string cardNumber = Session["cardNumber"].ToString();

                        Response.Cookies.Add(new HttpCookie("authOTPCToken", guid));
                        Response.Redirect("changeCardInfo.aspx?cardNumber=" + cardNumber, false);
                    }
                    //Perform delete here
                    //And then redirect to delete page
                    else if (validSessionReason == 3)
                    {
                        //Delete process above
                        string uniqueIdentifier = Session["UniqueIdentifier"].ToString();
                        Service1Client client = new Service1Client();

                        int result = client.DeleteByCardNumber(uniqueIdentifier);

                        if (result == 1)
                        {
                            //Remove delete card info session and cookie
                            Session.Remove("UniqueIdentifier");
                            Session.Remove("deleteCardInfo");
                            Response.Cookies["deleteCardInfo"].Value = string.Empty;
                            Response.Cookies["deleteCardInfo"].Expires = DateTime.Now.AddMonths(-20);

                            Response.Redirect("CardList.aspx", false);
                        }
                        else
                        {
                            Response.Redirect("CardList.aspx", false);
                        }
                    }
                    //View more card information
                    else if (validSessionReason == 4)
                    {
                        //Remove view more card info session and cookie
                        Session.Remove("viewCardInfo");
                        Response.Cookies["viewCardInfo"].Value = string.Empty;
                        Response.Cookies["viewCardInfo"].Expires = DateTime.Now.AddMonths(-20);

                        //string cardNumber = Session["cardNumber"].ToString();

                        //Create valid pass for user to view more card info
                        string guid = Guid.NewGuid().ToString();
                        Session["authOTPVToken"] = guid;

                        Response.Cookies.Add(new HttpCookie("authOTPVToken", guid));
                        Response.Redirect("PaymentInformation.aspx?", false);
                    }

                    //Just in case there is some error here
                    else
                    {
                        Response.Redirect("CardList.aspx");
                    }
                }
                //If OTP is invalid
                else
                {
                    Response.Redirect("Authentication.aspx");
                }

            }
            else
            {
                OTPError.Visible = true;
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
    }
}