using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            var email = tbemail.Text;
            var name = tbName.Text;
            var mobile = tbMobile.Text;
            var password = tbpassword.Text;
            var password2 = tbConfirm.Text;
            if (email ==""|| name == "" || mobile == ""|| password ==""|| password2 == "" )
            {
                errorMsg.Text = "Please input all fields";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }
            else
            {
                var valid = IsValidEmail(email);
                if (!valid)
                {
                    errorMsg.Text = "Enter valid email";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                if (password == password2)
                {
                    var errors = passwordcheck(password);
                    errorMsg.Text = errors;
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    return;

                }
                else
                {
                    errorMsg.Text = "Passwords not the same";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    return;
                }
                //password hashing and database stuff
            }
        }
        protected string passwordcheck(string password)
        {
            var errors = "";
            if (password.Length < 8)
            {
                errors = errors + "Password must at least be 8 characters long \n";
            }
            if (Regex.IsMatch(password, "[a-s]"))
            {
                errors = errors + "Password must contain lowercase letters \n";
            }
            if (Regex.IsMatch(password, "[A-Z]"))
            {
                errors = errors + "Password must contain uppercase letters \n";
            }
            if (Regex.IsMatch(password, "[0-9]"))
            {
                errors = errors + "Password must contain at least 1 number \n";
            }
            if (Regex.IsMatch(password, "[^0-9a-zA-Z]"))
            {
                errors = errors + "Password must contain at least one symbol \n";
            }
            return errors;
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

    }
}