using System;
using System.Net.Mail;

namespace EDP_Clinic
{
    public partial class CaregiverRemoval : System.Web.UI.Page
    {
        SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null || Session["Selected_CR"] != null)
            {
                LoadRemoval();
            }

            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }

        protected void LoadRemoval()
        {
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();


            var cr_id = Session["Selected_CR"].ToString();
            var selected_patient_obj = svc_client.GetOneUser(cr_id);
            var current_user_obj = svc_client.GetOneUserByEmail(Session["LoggedIn"].ToString());

            var removeResult = svc_client.RemoveCaregiver(current_user_obj.Id, selected_patient_obj.Id);
            var removeResult2 = svc_client.RemoveCaretaker(current_user_obj.Id);


            if (removeResult == 1)
            {
                emailClient.Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
                emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                emailClient.EnableSsl = true;
                MailMessage mail = new MailMessage();
                mail.Subject = "Removal of Caregiver request (MedPill Clinic)";
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                mail.Body = $"This email is to notify you that {current_user_obj.Name} has stopped being your Caregiver.  <br>";
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.High;
                mail.From = new MailAddress("bryanchinzw@gmail.com");
                mail.To.Add(new MailAddress(selected_patient_obj.Email));
                emailClient.Send(mail);

                lbl_notification.Text = $"You have stopped being a Caregiver for {selected_patient_obj.Name} \n An email has been sent to {selected_patient_obj.Name} to notify them";
            }

            else
            {
                lbl_notification.Text = "Seems like something went wrong with the removal process, please try again";
            }
        }
    }
}