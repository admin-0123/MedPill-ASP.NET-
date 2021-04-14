using EDP_Clinic.App_Code;
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
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void submitBtn_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            string email = HttpUtility.HtmlEncode(tbemail.Text.Trim());
            string password = HttpUtility.HtmlEncode(tbpassword.Text.Trim());
            string captchaResponse = Request.Form["g-recaptcha-response"];

            bool validInput = ValidateInput(email, password);
            RecaptchaValidation validCaptcha = new RecaptchaValidation();
            bool captchaResult = validCaptcha.ValidateCaptcha(captchaResponse);

            if (validInput == true && captchaResult == true)
            {
                Debug.WriteLine("All inputs are in valid formats and recaptcha successfully validated.");
            }
            else
            {
                //  Return empty
                Debug.WriteLine("Invalid input formats.");
                Debug.WriteLine("Failed Recaptcha Validation");
                return;
            }

            var emailexist = client.CheckOneUser(email);
            if (emailexist == 0)
            {
                emailErrorMsg.Text = "Please enter a valid email";
                emailErrorMsg.ForeColor = Color.Red;
                return;
            }

            User user = client.GetOneUserByEmail(email);
            string salt = user.Salt;
            string userPassword = user.Password;
            string verify = user.Verified;
            if (verify == "No")
            {
                errorMsg.Text = "Please verify your account";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;
            }

            string pwdWithSalt = password + salt;
            SHA512Managed hashing = new SHA512Managed();
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            string finalHash = Convert.ToBase64String(hashWithSalt);
            if (finalHash == userPassword)
            {
                string role = user.Role;
                Session["UserRole"] = role;
                Session["LoggedIn"] = email;
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
            else
            {
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