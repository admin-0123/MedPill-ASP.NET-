using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Register : System.Web.UI.Page
    {
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
        static string finalHash;
        static string salt;
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("ok");

            var email = tbemail.Text;
            var name = tbName.Text;
            var mobile = tbMobile.Text;
            var password = tbpassword.Text;
            var password2 = tbConfirm.Text;
            if (email == "" || name == "" || mobile == "" || password == "" || password2 == "")
            {
                errorMsg.Text = "Please input all fields";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
                Debug.WriteLine("ok");
                return;
            }
            else
            {
                var emailexist = client.CheckOneUser(email);
                if (emailexist == 1)
                {
                    errorMsg.Text = "Email already exists";
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
                if (password == password2)
                {
                    var errors = passwordcheck(password);
                    errorMsg.Text = errors;
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    errorMsg.Visible = true;
                }
                else
                {
                    errorMsg.Text = "Passwords not the same";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    errorMsg.Visible = true;
                    return;
                }

                //add checker if email is in use

                string pwd = tbpassword.Text.ToString();
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                byte[] saltByte = new byte[8];

                rng.GetBytes(saltByte);
                var salt = Convert.ToBase64String(saltByte);

                SHA512Managed hashing = new SHA512Managed();

                string pwdWithSalt = pwd + salt;
                byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

                finalHash = Convert.ToBase64String(hashWithSalt);

                //store info in database
                try
                {
                    using (SqlConnection con = new SqlConnection(MYDBConnectionString))
                    {

                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [User] VALUES(@Name, @Password, @Salt, @Email, @PhoneNo, @Role, @Verified)"))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {

                                cmd.CommandType = CommandType.Text;
                                cmd.Parameters.AddWithValue("@Name", name);
                                cmd.Parameters.AddWithValue("@Password", finalHash);
                                cmd.Parameters.AddWithValue("@Salt", salt);
                                cmd.Parameters.AddWithValue("@Email", email);
                                cmd.Parameters.AddWithValue("@PhoneNo", tbMobile.Text);
                                cmd.Parameters.AddWithValue("@Role", "Patient");
                                cmd.Parameters.AddWithValue("@Verified", "Yes");  // change to no after 2FA is added
                                cmd.Connection = con;
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                                //create link by encrpyting email
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

                Response.Redirect("Login.aspx", false);

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