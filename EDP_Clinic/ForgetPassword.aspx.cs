using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;

namespace EDP_Clinic
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        readonly Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submitBtn_Click(object sender, EventArgs e)
        {
            string email = HttpUtility.HtmlEncode(tbEmail.Text.Trim());
            var emailexist = client.CheckOneUser(email);
            Debug.WriteLine(emailexist);
            if (emailexist == 0)
            {
                errorMsg.Text = "Email not registered";
                errorMsg.ForeColor = Color.Red;
                return;
            }
            string code;
            var existingcode = client.CheckCodeByEmail(email);
            Debug.WriteLine(existingcode);
            if (existingcode == "error")
            {
                code = makeCode();
                client.AddCode(email, code);
            }
            else
            {
                code = existingcode;
            }
            string link = "https://localhost:44310/ChangePassword.aspx?value=" + code;
            SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587)
            {
                Credentials = new NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            MailMessage mail = new MailMessage
            {
                Subject = "Reset Password (MedPill)",
                SubjectEncoding = Encoding.UTF8,
                Body = "Please Click link to change password <br>" + link,
                IsBodyHtml = true,
                Priority = MailPriority.High,
                From = new MailAddress("bryanchinzw@gmail.com")
            };
            mail.To.Add(new MailAddress(email));
            emailClient.Send(mail);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('A link to reset your password has been sent to your email'); window.location='" + Request.ApplicationPath + "Login.aspx';", true);
            Context.ApplicationInstance.CompleteRequest();
        }
        // Replace this with guid
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