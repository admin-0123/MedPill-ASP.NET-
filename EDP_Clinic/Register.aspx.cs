using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
    public partial class Register : System.Web.UI.Page
    {
        //string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
        static string finalHash;
        SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
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
                Debug.WriteLine(emailexist);
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
                if (!Regex.IsMatch(mobile, @"\d{8}"))
                {
                    errorMsg.Text = "Enter valid phone number";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
                    if (password == password2)
                {
                    var errors = passwordcheck(password);
                    if (errors != "")
                    {
                        errorMsg.Text = errors;
                        errorMsg.ForeColor = System.Drawing.Color.Red;
                        errorMsg.Visible = true;
                        return;
                    }
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

                var result = client.AddOneUser(name, finalHash, salt, email, tbMobile.Text, "Patient", "No");
                if (result == 0)
                {
                    errorMsg.Text = "unknown error has occured ";
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
                else
                {
                    var code = makeCode();
                    var codeExist = client.CheckCodeExist(code);
                    while (codeExist == 1)
                    {
                        code = makeCode();
                        codeExist = client.CheckCodeExist(code);
                    }
                    client.AddCode(email, code);
                    var link = "https://localhost:44310/Verify.aspx?value=" + code;
                    emailClient.Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
                    emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    emailClient.EnableSsl = true;
                    MailMessage mail = new MailMessage();
                    mail.Subject = "Verify Account (MedPill)";
                    mail.SubjectEncoding = System.Text.Encoding.UTF8;
                    mail.Body = "Please to verify account <br> <a>" + link +"</a>";
                    mail.IsBodyHtml = true;
                    mail.Priority = MailPriority.High;
                    mail.From = new MailAddress("bryanchinzw@gmail.com");
                    mail.To.Add(new MailAddress(email));
                    emailClient.Send(mail);
                }


                ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('Please check email to verify account'); window.location='" + Request.ApplicationPath + "Login.aspx';", true);

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
        public string makeCode()
        {
            var exist = 1;
            string r = "yes";
            while (exist == 1)
            {
                Random generator = new Random();
                r = generator.Next(0, 1000000).ToString("D6");
                exist = client.CheckCodeExist(r);
            }

            return r;
        }

    }
}