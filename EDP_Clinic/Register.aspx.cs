using EDP_Clinic.App_Code;
using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;

namespace EDP_Clinic
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void RegisterBtn_Click(object sender, EventArgs e)
        {
            string email = HttpUtility.HtmlEncode(tbemail.Text.Trim());
            string name = HttpUtility.HtmlEncode(tbName.Text.Trim());
            string mobile = HttpUtility.HtmlEncode(tbMobile.Text.Trim());
            string password = HttpUtility.HtmlEncode(tbpassword.Text.Trim());
            string password2 = HttpUtility.HtmlEncode(tbConfirm.Text.Trim());

            bool validInput = ValidateInput(email, name, mobile, password, password2);

            //  Call recaptcha function here
            string captchaResponse = Request.Form["g-recaptcha-response"];
            RecaptchaValidation validCaptcha = new RecaptchaValidation();
            bool captchaResult = validCaptcha.ValidateCaptcha(captchaResponse);

            if (validInput == false || captchaResult == false)
            {
                return;
            }
            // If all input is correctly formatted and captcha is validated
            else
            {
                var errors = passwordcheck(password);

                Service1Client client = new Service1Client();

                var emailexist = client.CheckOneUser(email);
                Debug.WriteLine(emailexist);
                if (emailexist == 1)
                {
                    emailErrorMsg.Text = "Email already exists";
                    emailErrorMsg.ForeColor = Color.Red;
                    return;
                }

                if (errors != "")
                {
                    passwordErrorMsg.Text = errors;
                    passwordErrorMsg.ForeColor = Color.Red;
                    passwordErrorMsg.Visible = true;
                    return;
                }

                string pwd = tbpassword.Text.ToString();
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] saltByte = new byte[8];

                rng.GetBytes(saltByte);
                var salt = Convert.ToBase64String(saltByte);

                SHA512Managed hashing = new SHA512Managed();

                string pwdWithSalt = pwd + salt;
                // byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

                string finalHash = Convert.ToBase64String(hashWithSalt);

                var result = client.AddOneUser(name, finalHash, salt, email, tbMobile.Text, "Patient", "No");
                if (result == 0)
                {
                    errorMsg.Text = "unknown error has occured ";
                    errorMsg.ForeColor = Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
                else
                {
                    //  Use GUID as it is more random
                    string code = Guid.NewGuid().ToString();//MakeCode();
                    client.AddCode(email, code);

                    string subjectHeader = "Verify Account (MedPill)";
                    string link = "https://localhost:44310/Verify.aspx?value=" + code;
                    string message = "Please to verify account <br> <a>" + link + "</a>";

                    EmailService emailService = new EmailService();
                    emailService.SendEmail(email, subjectHeader, message);
                }
                ScriptManager.RegisterStartupScript(this, this.GetType(),
                    "Redit", "alert('Please check email to verify account'); window.location='" + 
                    Request.ApplicationPath + "Login.aspx';", true);
            }
        }
        protected string passwordcheck(string password)
        {
            var errors = "";
            if (password.Length < 8)
            {
                errors += "Password must at least be 8 characters long <br/>";
            }
            if (!Regex.IsMatch(password, "[a-s]"))
            {
                errors += "Password must contain lowercase letters <br/>";
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                errors += "Password must contain uppercase letters <br/>";
            }
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                errors += "Password must contain at least 1 number <br/>";
            }
            if (!Regex.IsMatch(password, "[^0-9a-zA-Z]"))
            {
                errors += "Password must contain at least one symbol <br/>";
            }
            return errors;
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

        protected bool ValidateInput(string email, string name,
            string mobileNo, string password, string passwordConfirm)
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

            //Checks if name is empty
            if (String.IsNullOrEmpty(name))
            {
                nameErrorMsg.Text = "Please enter name on card";
                nameErrorMsg.ForeColor = Color.Red;
                nameErrorMsg.Visible = true;
                return false;
            }
            else if (!Regex.IsMatch(name, "^[a-zA-Z0-9 ]*$"))
            {
                nameErrorMsg.Text = "Please enter a valid name";
                nameErrorMsg.ForeColor = Color.Red;
                nameErrorMsg.Visible = true;
                return false;
            }

            //Checks if mobile number is empty
            if (String.IsNullOrEmpty(mobileNo))
            {
                phoneErrorMsg.Text = "Please enter your mobile number";
                phoneErrorMsg.ForeColor = Color.Red;
                phoneErrorMsg.Visible = true;
                return false;
            }
            // Checks if phone number has 8 digits
            else if (!Regex.IsMatch(mobileNo, @"\d{8}"))
            {
                phoneErrorMsg.Text = "Enter valid phone number";
                phoneErrorMsg.ForeColor = Color.Red;
                phoneErrorMsg.Visible = true;
                return false;
            }

            // Validate password format
            if (String.IsNullOrEmpty(password))
            {
                passwordErrorMsg.Text = "Please enter your password";
                passwordErrorMsg.ForeColor = Color.Red;
                return false;
            }
            // Validate confirm password format
            else if (String.IsNullOrEmpty(passwordConfirm))
            {
                passwordConfirmErrorMsg.Text = "Please enter your password again";
                passwordConfirmErrorMsg.ForeColor = Color.Red;
                return false;
            }
            else if (password != passwordConfirm)
            {
                passwordConfirmErrorMsg.Text = "Please ensure both passwords are the same";
                passwordConfirmErrorMsg.ForeColor = Color.Red;
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}