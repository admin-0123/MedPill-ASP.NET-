using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Login : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var email = HttpUtility.HtmlEncode(tbemail.Text);
            var password = HttpUtility.HtmlEncode(tbpassword.Text);

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
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
                return;

            }
            var user = client.GetOneUserByEmail(email);
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
                    Response.Redirect("UserPage.aspx", false);
                }
                else if (role == "Admin")
                {
                    Response.Redirect("AdminPage.aspx", false);
                }
                else
                {
                    Response.Redirect("PatientOverview.aspx", false);
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
    }
}