﻿using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Web;
using Twilio.Rest.Verify.V2.Service;

namespace EDP_Clinic
{
    public partial class PhoneOTP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MobileLogin"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string phoneNo = Session["MobileLogin"].ToString();
            string phoneNumber = "+65" + phoneNo;
            var otp = HttpUtility.HtmlEncode(phoneOTP.Text.ToString());
            var result = checkOTP(phoneNumber, otp);
            if (!result)
            {
                errorMsg.Text = "Wrong code";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;
            }
            else
            {
                Service1Client client = new Service1Client();
                var user = client.GetOneUserByPhoneNo(phoneNo);
                string role = user.Role;
                Session["UserRole"] = role;
                Session["LoggedIn"] = user.Email.ToString();
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
                Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                if (role == "Patient")
                {
                    Response.Redirect("~/Home.aspx", false);
                }
                else if (role == "Admin")
                {
                    Response.Redirect("~/AdminPage.aspx", false);
                }
                else
                {
                    Response.Redirect("~/Home.aspx", false);
                }
            }
        }
        private bool checkOTP(string phoneNo, string otp)
        {
            //Checks OTP
            var verificationCheck = VerificationCheckResource.Create(
                to: phoneNo,
                code: otp,
                pathServiceSid: "VA4ceee8345f84c5be3a44bc9ab3db5790"
            );

            //For debugging purposes
            //Refer to https://www.twilio.com/docs/verify/api/verification-check
            Debug.WriteLine(verificationCheck.Status);

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
    }
}