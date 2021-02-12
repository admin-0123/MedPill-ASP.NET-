using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class ChangeInfo : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            var redColor = Color.Red;
            var user = client.GetOneUserByEmail(Session["LoggedIn"].ToString());
            var name = HttpUtility.HtmlEncode(nameTB.Text);
            var email = HttpUtility.HtmlEncode(emailTB.Text);
            var phoneNo = HttpUtility.HtmlEncode(phoneTB.Text);
            var password = HttpUtility.HtmlEncode(passwordTB.Text);
            var password2 = HttpUtility.HtmlEncode(password2TB.Text);
            
            if (name == "")
            {
                name = user.Name.ToString();
            }
            if (!IsValidEmail(email))
            {
                if (email == "")
                {
                    email = user.Email.ToString();
                }
                else
                {
                    emailError.Text = "Enter proper email";
                    emailError.ForeColor = Color.Red;
                    emailError.Visible = true;
                }
            }
            else
            {
                var exist = client.CheckOneUser(email);
                if (exist == 1)
                {
                    emailError.Text = "Email already in use";
                    emailError.ForeColor = Color.Red;
                    emailError.Visible = true;
                }
            }
            if (phoneNo == "")
            {
                phoneNo = user.PhoneNo.ToString();
            }
            else
            {
                if (!Regex.IsMatch(phoneNo, @"\d{8}"))
                {
                    phoneError.Text = "Enter proper phone number";
                    phoneError.ForeColor = Color.Red;
                    phoneError.Visible = true;
                }
                else
                {
                    var exist = client.CheckPhoneNo(phoneNo);
                    if (exist == 1)
                    {
                        phoneError.Text = "Phone number already in use";
                        phoneError.ForeColor = Color.Red;
                        phoneError.Visible = true;
                    }
                }
            }
            if (password2 != "")
            {
                var errors = passwordcheck(password2);
                if (errors != "")
                {
                    pass2Error.Text = errors;
                    pass2Error.ForeColor = Color.Red;
                    pass2Error.Visible = true;
                    return;
                }
            }
            var salt = user.Salt;
            var pwdWithSalt = password + salt;
            SHA512Managed hashing = new SHA512Managed();
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
            var finalHash = Convert.ToBase64String(hashWithSalt);
            var passInDB = user.Password.ToString();
            if (finalHash != passInDB)
            {
                passError.Text = "Incorrect password";
                passError.ForeColor = Color.Red;
                passError.Visible = true;
                return;
            }
            if (emailError.ForeColor == Color.Red || phoneError.ForeColor == Color.Red || passError.ForeColor == Color.Red || pass2Error.ForeColor == Color.Red)
            {
                return;
            }
            else
            {
                var id = user.Id;
                if (password2 != "")
                {
                    var pwd2WithSalt = password2 + salt;
                    byte[] hash2WithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd2WithSalt));
                    var finalHash2 = Convert.ToBase64String(hash2WithSalt);
                    client.UpdateOneUser(id, name, email, phoneNo, finalHash2);
                    Response.Redirect("UserPage.aspx", false);
                }
                else
                {
                    client.UpdateOneUser(id, name, email, phoneNo, passInDB);
                    Response.Redirect("UserPage.aspx", false);
                }
            }
        }
        public static bool IsValidEmail(string email)
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
        protected string passwordcheck(string password)
        {
            var errors = "";
            if (password.Length < 8)
            {
                errors = errors + "Password must at least be 8 characters long <br/>";
            }
            if (!Regex.IsMatch(password, "[a-s]"))
            {
                errors = errors + "Password must contain lowercase letters <br/>";
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                errors = errors + "Password must contain uppercase letters <br/>";
            }
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                errors = errors + "Password must contain at least 1 number <br/>";
            }
            if (!Regex.IsMatch(password, "[^0-9a-zA-Z]"))
            {
                errors = errors + "Password must contain at least one symbol <br/>";
            }
            return errors;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx", false);
        }
    }
}