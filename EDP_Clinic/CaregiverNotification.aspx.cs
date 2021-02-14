using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class CaregiverNotification : System.Web.UI.Page
    {
        SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
        protected void Page_Load(object sender, EventArgs e)
        {
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            var cr_id = Session["Selected_CR"].ToString();
            var selected_patient_obj = svc_client.GetOneUser(cr_id);
            var current_user_obj = svc_client.GetOneUserByEmail(Session["LoggedIn"].ToString());
            var selected_patient_obj_code = svc_client.CheckCodeByEmail(selected_patient_obj.Email);
            var current_user_obj_code = svc_client.CheckCodeByEmail(current_user_obj.Email);


            var link = $"https://localhost:44310/CaregiverApproval.aspx?value={current_user_obj.Id}&value2={selected_patient_obj.Id}&emailCode={current_user_obj_code}&emailCode2={selected_patient_obj_code}";
            emailClient.Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Allow Caregiver request (MedPill Clinic)";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = "Please Click link to approve the caregiver for you <br>" + link;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.From = new MailAddress("bryanchinzw@gmail.com");
            mail.To.Add(new MailAddress(selected_patient_obj.Email));
            emailClient.Send(mail);

            lbl_notification.Text = $"An email has been sent to {selected_patient_obj.Name}";
        }
    }
}