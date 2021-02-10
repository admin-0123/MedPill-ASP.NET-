using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Drawing;
using System.Net.Mail;

namespace EDP_Clinic
{
    public partial class AdminPage : System.Web.UI.Page
    {
        byte[] Key;
        byte[] IV;
        string deleteid;
        Service1Client client = new Service1Client();
        SmtpClient emailClient = new SmtpClient("smtp-relay.sendinblue.com", 587);
       
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    refreshgrid();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
           
        }
        protected void EmployeeGridView_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "changeinfo")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = EmployeeGridView.Rows[index];
                string id = selectedRow.Cells[3].Text;
                Debug.WriteLine(id);
                editLbl.Text = id;
                User employee = new User();
                employee = client.GetOneUser(id);
                tbEditName.Text = employee.Name;
                tbEditEmail.Text = employee.Email;
                tbEditMobile.Text = employee.PhoneNo;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Yes", "openEditModal();", true);
            }
            if (e.CommandName == "deleteinfo")
            {
                Debug.WriteLine("delete clicked");
                
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow selectedRow = EmployeeGridView.Rows[index];
                var deleteid = selectedRow.Cells[3].Text;
                delLbl.Text = deleteid;
                Debug.WriteLine(deleteid);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ok", "openDeleteModal();", true);

            }
        }
        protected void delBtn_Click(object sender, EventArgs e)
        {
            var id = delLbl.Text;
            try
            {
               var result =  client.DeleteOneUser(id);
                if (result == 1)
                {
                    Debug.WriteLine("success");
                }
                else
                {
                    Debug.WriteLine("rip u screwed up");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            refreshgrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Yes", "closeDeleteModal();", true);

        }
        protected void editBtn_Click(object sender, EventArgs e)
        {
            var name = tbEditName.Text;
            var email = tbEditEmail.Text;
            var mobile = tbEditMobile.Text;
            var id = editLbl.Text;
            Debug.WriteLine("id:"+id);
            Debug.WriteLine(email);

            try
            {
                var result = client.EditOneUser(id, name, email, mobile);
                if (result == 1)
                {
                    Debug.WriteLine("success");
                }
                else
                {
                    Debug.WriteLine("edit error");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            refreshgrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Yes", "closeEditModal();", true);

        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            var search = HttpUtility.HtmlEncode(searchtb.Text);
            List<displayUser> patientList = new List<displayUser>();
            List<User> userlist = new List<User>();
            //patientList = client.ShowAllPatients().ToList<displayUser>();
            patientList = client.ShowSearchedEmployees(search).ToList<displayUser>();
            EmployeeGridView.Visible = true;
            EmployeeGridView.DataSource = patientList;
            EmployeeGridView.DataBind();

        }
        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
            refreshgrid();
        }
            protected void Button1_Click(object sender, EventArgs e)
        {
            var email = tbAddEmail.Text;
            var name = tbAddName.Text;
            var mobile = tbAddMobile.Text;
            var role = AddRole.SelectedValue.ToString();
            if (email == "" || name == "" || mobile == "")
            {
                //add error msg for modal
                return;
            }
            else
            {
                var valid = IsValidEmail(email);
                if (!valid)
                {
                    return;
                }
                else
                {
                    var exist = client.CheckOneUser(email);
                    if (exist == 1)
                    {
                        addError.Text = "Email already exists";
                        addError.ForeColor = Color.Red;
                        return;
                    }
                    RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                    byte[] saltByte = new byte[8];
                    rng.GetBytes(saltByte);
                    var salt = Convert.ToBase64String(saltByte);
                    var result  =  client.AddOneUser(name, "placeholder", salt, email, mobile, role, "No");
                    if (result == 0)
                    {
                        return;
                    }
                    else
                    {
                        var code = makeCode();
                        var codeExist = client.CheckCodeExist(code);
                        while (codeExist == 1)
                        {
                            code = makeCode();
                            codeExist = client.CheckCodeExist(code);
                        }
                        client.AddCode(email, code);
                        var link = "https://localhost:44310/EmployeePasswordSet.aspx?value=" + code;
                        emailClient.Credentials = new System.Net.NetworkCredential("bryanchinzw@gmail.com", "vPDBKArZRY7HcIJC");
                        emailClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                        emailClient.EnableSsl = true;
                        MailMessage mail = new MailMessage();
                        mail.Subject = "Set Password (MedPill)";
                        mail.SubjectEncoding = System.Text.Encoding.UTF8;
                        mail.Body = "Please Click link to change password <br> <a>" + link + "</a>";
                        mail.IsBodyHtml = true;
                        mail.Priority = MailPriority.High;
                        mail.From = new MailAddress("bryanchinzw@gmail.com");
                        mail.To.Add(new MailAddress(email));
                        try
                        {
                            emailClient.Send(mail);
                        }
                        catch (SmtpFailedRecipientException ex)
                        {
                            Debug.WriteLine(ex);
                        }
                    }
                    
                }

            }
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
        
        public void refreshgrid()
        {
            List<displayUser> patientList = new List<displayUser>();
            List<User> userlist = new List<User>();
            //patientList = client.ShowAllPatients().ToList<displayUser>();
            patientList = client.ShowAllEmployees().ToList<displayUser>();
            EmployeeGridView.Visible = true;
            EmployeeGridView.DataSource = patientList;
            EmployeeGridView.DataBind();
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