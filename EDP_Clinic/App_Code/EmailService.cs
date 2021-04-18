using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace EDP_Clinic.App_Code
{
    public class EmailService
    {
        public string ReceipientEmail { get; set; }
        public string SenderEmail { get; set; }
        public string Url { get; set; }
        public string SubjectHeader { get; set; }

        public EmailService()
        {

        }

        public void SendEmail(string receipientEmail, string subjectHeader, string message)
        {
            SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587)
            {
                Credentials = new NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC"),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true
            };
            MailMessage mail = new MailMessage
            {
                Subject = subjectHeader,
                SubjectEncoding = Encoding.UTF8,
                Body = message,
                IsBodyHtml = true,
                Priority = MailPriority.High,
                From = new MailAddress("bryanchinzw@gmail.com")
            };
            mail.To.Add(new MailAddress(receipientEmail));
            try
            {
                emailClient.Send(mail);
            }
            catch (SmtpFailedRecipientException ex)
            {
                throw ex;
            }
            finally
            {
                Debug.WriteLine("Email Service is called!");
            }
        }
    }
}