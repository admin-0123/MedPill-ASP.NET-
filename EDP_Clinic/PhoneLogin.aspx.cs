using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using Twilio;
using Twilio.Rest.Verify.V2.Service;

namespace EDP_Clinic
{
    public partial class PhoneLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            string captchaResponse = Request.Form["g-recaptcha-response"];
            RecaptchaValidation validCaptcha = new RecaptchaValidation();
            bool captchaResult = validCaptcha.ValidateCaptcha(captchaResponse);

            string phoneNo = HttpUtility.HtmlEncode(tbPhoneNo.Text.Trim());
            if (String.IsNullOrEmpty(phoneNo) || captchaResult == false)
            {
                phoneErrorMsg.Text = "Enter proper phone number";
                phoneErrorMsg.ForeColor = Color.Red;
                return;
            }
            else if (!Regex.IsMatch(phoneNo, @"\d{8}"))
            {
                phoneErrorMsg.Text = "Enter proper phone number";
                phoneErrorMsg.ForeColor = Color.Red;
                return;
            }
            else
            {
                Service1Client client = new Service1Client();
                var exist = client.CheckPhoneNo(phoneNo);
                if (exist == 1)
                {
                    var user = client.GetOneUserByPhoneNo(phoneNo);
                    var verified = user.Verified;
                    if (verified == "No")
                    {
                        phoneErrorMsg.Text = "Enter proper phone number";
                        phoneErrorMsg.ForeColor = Color.Red;
                        return;
                    }
                    else
                    {
                        SendOTP(phoneNo);

                        ScriptManager.RegisterStartupScript(this, this.GetType(),
                            "Redit", "alert('Check your phone'); window.location='" +
                            Request.ApplicationPath + "PhoneOTP.aspx';", true);
                    }
                }
                else
                {
                    phoneErrorMsg.Text = "Phone number not registered";
                    phoneErrorMsg.ForeColor = Color.Red;
                    return;
                }
            }
        }
        protected void SendOTP(string phoneNo)
        {
            //Retrieve keys from web.config
            NameValueCollection myKeys = ConfigurationManager.AppSettings;

            //Reading keys
            var twilioAccSid = myKeys["TWILIO_ACCOUNT_SID"];
            var twilioAuth = myKeys["TWILIO_AUTH_TOKEN"];
            TwilioClient.Init(twilioAccSid, twilioAuth);

            Debug.WriteLine("Calling Twilio OTP Function");
            var phoneNumber = "+65" + phoneNo;
            //Sends OTP

            var verification = VerificationResource.Create(
                to: phoneNumber,
                channel: "sms",
                pathServiceSid: "VA4ceee8345f84c5be3a44bc9ab3db5790"
            );

            Debug.WriteLine(verification.Sid);
            Session["MobileLogin"] = phoneNo;
        }
    }
}