using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var email = HttpUtility.HtmlEncode(tbEmail.Text);
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
            if (existingcode == "error") { 
                code = makeCode();
                client.AddCode(email, code);
            }
            else
            {
                code = existingcode;
            }
            var link = "https://localhost:44310/ChangePassword.aspx?value=" + code;
            emailClient.Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Reset Password (MedPill)";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Please Click link to change password <br>" + link;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.From = new MailAddress("bryanchinzw@gmail.com");
            mail.To.Add(new MailAddress(email));
            emailClient.Send(mail);
            Response.Redirect("Login.aspx",false);
            Context.ApplicationInstance.CompleteRequest();



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