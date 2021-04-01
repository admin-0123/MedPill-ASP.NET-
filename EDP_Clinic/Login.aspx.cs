using EDP_Clinic.EDP_DBReference;
using System;
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

            var emailexist = client.CheckOneUser(email);
            if (emailexist == 0)
            {
                errorMsg.Text = "Email does not exists";
                errorMsg.ForeColor = Color.Red;
                return;
            }
            var valid = IsValidEmail(email);
            if (!valid)
            {
                errorMsg.Text = "Enter valid email";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;

            }
            var user = client.GetOneUserByEmail(email);
            var verify = user.Verified;
            if (verify == "No")
            {
                errorMsg.Text = "Please verify account";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;
            }
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
                    Response.Redirect("Home.aspx", false);
                }
                else if (role == "Admin")
                {
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Redirect("AdminPage.aspx", false);
                }
                else
                {
                    Response.Cookies.Add(new HttpCookie("AuthToken", guid));
                    Response.Redirect("Home.aspx", false);
                }
            }
            else
            {
                errorMsg.Text = "Wrong Email/Password";
                errorMsg.ForeColor = Color.Red;
                return;
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
        // Redirects user to phone login page
        protected void phoneBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PhoneLogin.aspx", false);
        }
    }
}