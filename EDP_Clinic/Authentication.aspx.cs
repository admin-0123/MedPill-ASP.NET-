using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Drawing;

namespace EDP_Clinic
{
    public partial class Authentication : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

            if(ValidInput == true)
            {
                OTPError.Visible = false;
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
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
    }
}