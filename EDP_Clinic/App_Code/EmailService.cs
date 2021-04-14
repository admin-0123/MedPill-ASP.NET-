using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace EDP_Clinic.App_Code
{
    public class EmailService
    {
        public string Email { get; set; }
        public string Url { get; set; }
        public string SubjectHeader { get; set; }

        public EmailService()
        {

        }

        public void SendEmail(string email, string url, string subjectHeader, string message)
        {
            SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587)
            {
                Credentials = new NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            MailMessage mail = new MailMessage
            {
                Subject = "Verify Account (MedPill)",
                SubjectEncoding = Encoding.UTF8,
                Body = "Please to verify account <br> <a>" + url + "</a>",
                IsBodyHtml = true,
                Priority = MailPriority.High,
                From = new MailAddress("bryanchinzw@gmail.com")
            };
            mail.To.Add(new MailAddress(email));
            emailClient.Send(mail);
        }
    }
}