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

namespace EDP_Clinic
{
    public partial class Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        private bool ValidateInput()
        {
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
                OTPError.Text = "";
                OTPError.Visible = false;
            }

            if (String.IsNullOrEmpty(OTPError.Text))
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

            //Retrieve keys from web.config
            NameValueCollection myKeys = ConfigurationManager.AppSettings;

            //Reading keys
            var twilioAccSid = myKeys["TWILIO_ACCOUNT_SID"];
            var twilioAuth = myKeys["TWILIO_AUTH_TOKEN"];

            if (ValidInput == true && validCaptcha == true)
            {
                OTPError.Visible = false;
                string guid = Guid.NewGuid().ToString();
                Session["AuthOTPToken"] = guid;
                //A bunch of if else statements here to redirect user to respective pages
                /*if ()
                {

                }
                else if ()
                {

                }
                else
                {

                }*/
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