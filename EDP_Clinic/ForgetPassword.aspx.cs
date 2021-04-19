using EDP_Clinic.App_Code;
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
            string existingcode = client.CheckCodeByEmail(email);
            Debug.WriteLine(existingcode);
            if (existingcode == "error")
            {
                code = Guid.NewGuid().ToString();
                client.AddCode(email, code);
            }
            else
            {
                code = existingcode;
            }

            string subjectHeader = "Reset Password (MedPill)";
            string link = "https://localhost:44310/ChangePassword.aspx?value=" + code;
            string message = "Please Click link to change password <br>" + link;

            EmailService emailService = new EmailService();
            emailService.SendEmail(email, subjectHeader, message);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Redit", "alert('A link to reset your password has been sent to your email'); window.location='" + Request.ApplicationPath + "Login.aspx';", true);
            Context.ApplicationInstance.CompleteRequest();
        }
    }
}