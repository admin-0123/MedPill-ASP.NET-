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

namespace EDP_Clinic
{
    public partial class Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Before entering this page
            //Check if user is authenticated first
            //Though code is not here yet 6/1/2021

            //if (Session["Login"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            //{
            //    if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
            //    {
            //        Response.Redirect("Login.aspx", false);
            //    }
            //    else
            //    {
            //        messageLbl.Text = "Congratulations !, you are logged in!";
            //        messageLbl.ForeColor = System.Drawing.Color.Green;
            //        logoutBtn.Visible = true;
            //    }
            //}
            //else
            //{
            //    Response.Redirect("Login.aspx", false);
            //}

            //Checks a list of sessions to give authentication

            //For testing purposes
            //Each session should store random GUID
            Session["addCardInfo"] = "111";
            Session["changeCardInfo"] = "222";
            Session["deleteCardInfo"] = "333";


            //Cookies
            //Comment out for testing purposes
            //Response.Cookies["addCardInfo"].Value = "111";
            //Response.Cookies["addCardInfo"].Expires = DateTime.Now.AddMinutes(15);

            Response.Cookies["changeCardInfo"].Value = "222";
            Response.Cookies["changeCardInfo"].Expires = DateTime.Now.AddMinutes(15);

            //Response.Cookies["deleteCardInfo"].Value = "333";
            //Response.Cookies["deleteCardInfo"].Expires = DateTime.Now.AddMinutes(15);


            //HttpCookie addCardCookie = new HttpCookie("addCardInfo");
            //addCardCookie.Value = 

            //addCardCookie.Values.add(true);
            //Response.Cookies.Add(addCardCookie);

            //This resulting value will direct user to respective pages
            int validSessionReason = checkIntention();

            if(validSessionReason == 0)
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

                //Sends OTP
                
                var verification = VerificationResource.Create(
                    to: "+6590251744",
                    channel: "sms",
                    pathServiceSid: "VA4ceee8345f84c5be3a44bc9ab3db5790"
                );

                Console.WriteLine(verification.Sid);

                //string name = "123";
                //Response.Redirect("CardList.aspx");
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
            if(otpResult == "approved")
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
            else if(!Regex.IsMatch(OTPTB.Text, "^[0-9]*$"))
            {
                OTPError.Text = "Please enter a valid 6-digit OTP";
                OTPError.ForeColor = Color.Red;
                OTPError.Visible = true;
            }
            //Checks if OTP contains 6 digits long
            else if(OTPTB.Text.Length != 6)
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

        protected void verifyBtn_Click(object sender, EventArgs e)
        {
            bool ValidInput = ValidateInput();

            bool validCaptcha = ValidateCaptcha();

            int validSessionReason = checkIntention();

            bool validOTP = checkOTP();

            //Checks if user enters a valid OTP format and is not a bot
            if (ValidInput == true && validCaptcha == true)
            {
                //OTPError.Visible = false;
                //string guid = Guid.NewGuid().ToString();
                //Session["AuthOTPToken"] = guid;

                //If OTP is valid
                if(validOTP == true)
                {
                    //A bunch of if else statements here to redirect user to respective pages
                    if (validSessionReason == 1)
                    {
                        Response.Redirect("addCardInfo.aspx");
                    }
                    else if (validSessionReason == 2)
                    {
                        Response.Redirect("changeCardInfo.aspx");
                    }
                    //Perform delete here
                    //And then redirect to delete page
                    else if (validSessionReason == 3)
                    {
                        //Delete process above
                        Response.Redirect("PaymentInfoDeleted.aspx");
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