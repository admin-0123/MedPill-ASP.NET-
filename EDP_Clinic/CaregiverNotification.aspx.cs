using EDP_Clinic.App_Code;
using EDP_Clinic.EDP_DBReference;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace EDP_Clinic
{
    public partial class CaregiverNotification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null || Session["Selected_CR"] != null)
            {
                Service1Client svc_client = new Service1Client();
                string cr_id = Session["Selected_CR"].ToString();

                var selected_patient_obj = svc_client.GetOneUser(cr_id);
                var current_user_obj = svc_client.GetOneUserByEmail(Session["LoggedIn"].ToString());
                var selected_patient_obj_code = svc_client.CheckCodeByEmail(selected_patient_obj.Email);
                var current_user_obj_code = svc_client.CheckCodeByEmail(current_user_obj.Email);

                string receipientEmail = selected_patient_obj.Email.ToString();
                string subjectHeader = "Allow Caregiver request (MedPill Clinic)";
                string link = $"https://localhost:44310/CaregiverApproval.aspx?value={current_user_obj.Id}&value2={selected_patient_obj.Id}&emailCode={current_user_obj_code}&emailCode2={selected_patient_obj_code}";
                string message = "Please Click link to approve the caregiver for you <br>" + link;

                EmailService emailService = new EmailService();
                emailService.SendEmail(receipientEmail, subjectHeader, message);

                lbl_notification.Text = $"An email has been sent to {selected_patient_obj.Name}";
            }
            else
            {
                Response.Redirect("404.aspx", false);
            }
        }
    }
}