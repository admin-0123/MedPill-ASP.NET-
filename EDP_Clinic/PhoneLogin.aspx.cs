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
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string phoneNo = HttpUtility.HtmlEncode(tbPhoneNo.Text);
            if (phoneNo == "")
            {
                errorMsg.Text = "Enter proper phone number";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;
            }
            else
            {
                if (!Regex.IsMatch(phoneNo, @"\d{8}"))
                {
                    errorMsg.Text = "Enter proper phone number";
                    errorMsg.ForeColor = Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
                else
                {
                    var exist = client.CheckPhoneNo(phoneNo);
                    if (exist == 1)
                    {
                        var user = client.GetOneUserByPhoneNo(phoneNo);
                        var verified = user.Verified;
                        if (verified == "No")
                        {
                            errorMsg.Text = "Enter proper phone number";
                            errorMsg.ForeColor = Color.Red;
                            errorMsg.Visible = true;
                            return;
                        }
                        //Might put the Twilio Verify API into a function - 6/1/2021

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
                        //Console.WriteLine(verification.Sid);
                        Session["MobileLogin"] = phoneNo;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('Check your phone'); window.location='" + Request.ApplicationPath + "PhoneOTP.aspx';", true);

                    }
                    else
                    {
                        errorMsg.Text = "Phone number not registered";
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                        return;
                    }
                }
            }
        }
    }
}