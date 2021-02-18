using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;

using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Web;

namespace EDP_Clinic
{
    public partial class PatientOverview : System.Web.UI.Page
    {
        SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Session["UserRole"].ToString() == "Patient")
                {
                    Response.Redirect("Home.aspx", false);
                }
            }
            List<displayPatient> patientList = new List<displayPatient>();
            patientList = client.DisplayAllPatients().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        protected void ViewPatients_Click(object sender, EventArgs e)
        {
            List<displayPatient> patientList = new List<displayPatient>();
            List<User> userlist = new List<User>();
            patientList = client.DisplayPatientsOnly().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        protected void ViewCaretaker_Click(object sender, EventArgs e)
        {
            List<displayPatient> patientList = new List<displayPatient>();
            List<User> userlist = new List<User>();
            patientList = client.DisplayCaretakers().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
            refreshgrid();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            var search = HttpUtility.HtmlEncode(searchtb.Text);
            List<displayPatient> patientList = new List<displayPatient>();
            patientList = client.DisplayAllSearchedPatients(search).ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }

        public void refreshgrid()
        {
            List<displayPatient> patientList = new List<displayPatient>();
            List<User> userlist = new List<User>();
            patientList = client.DisplayAllPatients().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }

        protected void ViewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create_Report.aspx");
        }

        protected void Med_Condition_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_Medical_Condition.aspx");
        }

        protected void btn_send_cert_Click(object sender, EventArgs e)
        {
            string path = Server.MapPath(@"assets\images\medical_certificate.jpg");
            var str = "<img src=cid:MyImage  id='img' alt='' width='300px' height='200px'/>";
            LinkedResource Img = new LinkedResource(path, MediaTypeNames.Image.Jpeg);
            Img.ContentId = "MyImage";
            emailClient.Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
            emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            emailClient.EnableSsl = true;
            MailMessage mail = new MailMessage();
            mail.Subject = "Medical Certificate";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = str;
            AlternateView AV = AlternateView.CreateAlternateViewFromString(str, null, MediaTypeNames.Text.Html);
            AV.LinkedResources.Add(Img);
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            mail.From = new MailAddress("bryanchinzw@gmail.com");
            mail.AlternateViews.Add(AV);
            mail.To.Add(new MailAddress("wetifav260@wirese.com"));
            emailClient.Send(mail);
        }
    }
}
//C:\Users\owenn\Source\Repos\wilfredhuang\Entreprise_Development_Project\EDP_Clinic\assets\images\medical_certificate.jpg