using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace EDP_Clinic
{
    public partial class Login : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string email = HttpUtility.HtmlEncode(tbemail.Text.Trim());
            string password = HttpUtility.HtmlEncode(tbpassword.Text.Trim());

            bool validInput = ValidateInput(email, password);

            if (validInput == true)
            {
                Debug.WriteLine("All inputs are in valid formats.");
                string captchaResponse = Request.Form["g-recaptcha-response"];

                RecaptchaValidation validCaptcha = new RecaptchaValidation();
                bool captchaResult = validCaptcha.ValidateCaptcha(captchaResponse);
                Debug.WriteLine(captchaResult);

                if(captchaResult == true)
                {
                    Debug.WriteLine("Successful Recaptcha Validation");
                }
                else
                {
                    Debug.WriteLine("Failed Recaptcha Validation");
                    return;
                }
            }
            else
            {
                //Return empty
                Debug.WriteLine("Invalid input formats.");
                return;
            }

            var emailexist = client.CheckOneUser(email);
            if (emailexist == 0)
            {
                errorMsg.Text = "Email does not exists";
                errorMsg.ForeColor = Color.Red;
                return;
            }
            //var valid = IsValidEmail(email);
            //if (!valid)
            //{
            //    errorMsg.Text = "Enter valid email";
            //    errorMsg.ForeColor = Color.Red;
            //    errorMsg.Visible = true;
            //    return;

            //}
            var user = client.GetOneUserByEmail(email);
            string verify = user.Verified;
            if (verify == "No")
            {
                errorMsg.Text = "Please verify account";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;
            }


            //Shift all the code below to a dedicated function
            var salt = user.Salt;
            var pwdWithSalt = password + salt;
            SHA512Managed hashing = new SHA512Managed();
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            var finalHash = Convert.ToBase64String(hashWithSalt);
            var userPassword = user.Password;
            if (finalHash == userPassword)
            {
                var role = user.Role;
                Session["UserRole"] = role;
                Session["LoggedIn"] = email;
                string guid = Guid.NewGuid().ToString();
                Session["AuthToken"] = guid;
                if (role == "Patient")
                {
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Redirect("~/Home.aspx", false);
                }
                else if (role == "Admin")
                {
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Redirect("~/AdminPage.aspx", false);
                }
                else
                {
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Redirect("~/Home.aspx", false);
                }
            }
            else
            {
                //errorMsg.Text = "Wrong Email/Password";
                //errorMsg.ForeColor = Color.Red;
                Response.Redirect("~/Login.aspx", false);
                return;
            }
        }
        public bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        protected bool ValidateInput(string email, string password)
        {
            // Validate email format
            if (String.IsNullOrEmpty(email))
            {
                emailErrorMsg.Text = "Please enter your email";
                emailErrorMsg.ForeColor = Color.Red;
                return false;
            }
            else if (IsValidEmail(email) == false)
            {
                emailErrorMsg.Text = "Please enter a valid email";
                emailErrorMsg.ForeColor = Color.Red;
                return false;
            }

            // Validate password format
            if (String.IsNullOrEmpty(password))
            {
                passwordErrorMsg.Text = "Please enter your password";
                passwordErrorMsg.ForeColor = Color.Red;
                return false;
            }
            else if (password.Length < 8)
            {
                passwordErrorMsg.Text = "Please enter a valid password";
                passwordErrorMsg.ForeColor = Color.Red;
                return false;
            }
            else
            {
                emailErrorMsg.Text = "Excellent";
                emailErrorMsg.ForeColor = Color.Green;
                passwordErrorMsg.Text = "Excellent";
                passwordErrorMsg.ForeColor = Color.Green;
                return true;
            }
        }
        // Redirects user to phone login page
        protected void phoneBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PhoneLogin.aspx", false);
        }
    }
}