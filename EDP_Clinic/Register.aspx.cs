using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
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
        //string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
        static string finalHash;
        readonly Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string email = HttpUtility.HtmlEncode(tbemail.Text.Trim());
            string name = HttpUtility.HtmlEncode(tbName.Text.Trim());
            string mobile = HttpUtility.HtmlEncode(tbMobile.Text.Trim());
            string password = HttpUtility.HtmlEncode(tbpassword.Text.Trim());
            string password2 = HttpUtility.HtmlEncode(tbConfirm.Text.Trim());
            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(name)
                || String.IsNullOrEmpty(mobile) || String.IsNullOrEmpty(password)
                || String.IsNullOrEmpty(password2))
            {
                errorMsg.Text = "Please input all fields correctly";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                Debug.WriteLine("Some fields are invalid");
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
                    errorMsg.ForeColor = Color.Red;
                    errorMsg.Visible = true;
                    return;

                }
                if (!Regex.IsMatch(mobile, @"\d{8}"))
                {
                    errorMsg.Text = "Enter valid phone number";
                    errorMsg.ForeColor = Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
                if (password == password2)
                {
                    var errors = passwordcheck(password);
                    if (errors != "")
                    {
                        errorMsg.Text = errors;
                        errorMsg.ForeColor = Color.Red;
                        errorMsg.Visible = true;
                        return;
                    }
                }
                else
                {
                    errorMsg.Text = "Passwords not the same";
                    errorMsg.ForeColor = Color.Red;
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
                // byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

                finalHash = Convert.ToBase64String(hashWithSalt);

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
                    var code = MakeCode();
                    var codeExist = client.CheckCodeExist(code);
                    while (codeExist == 1)
                    {
                        code = MakeCode();
                        codeExist = client.CheckCodeExist(code);
                    }
                    client.AddCode(email, code);
                    var link = "https://localhost:44310/Verify.aspx?value=" + code;
                    SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587)
                    {
                        Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC"),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        EnableSsl = true
                    };
                    MailMessage mail = new MailMessage
                    {
                        Subject = "Verify Account (MedPill)",
                        SubjectEncoding = Encoding.UTF8,
                        Body = "Please to verify account <br> <a>" + link + "</a>",
                        IsBodyHtml = true,
                        Priority = MailPriority.High,
                        From = new MailAddress("bryanchinzw@gmail.com")
                    };
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
        public string MakeCode()
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