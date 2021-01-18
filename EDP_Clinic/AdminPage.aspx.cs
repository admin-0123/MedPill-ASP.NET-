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

namespace EDP_Clinic
{
    public partial class AdminPage : System.Web.UI.Page
    {
        byte[] Key;
        byte[] IV;
        string deleteid;
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
        Service1Client client = new Service1Client();
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
                Service1Client client = new Service1Client();
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
                    Debug.WriteLine("rip u screwed up yes");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            refreshgrid();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Yes", "closeEditModal();", true);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var email = tbAddEmail.Text;
            var name = tbAddName.Text;
            var mobile = tbAddMobile.Text;
            var role = AddRole.SelectedValue.ToString();
            if (email == "" || name == "" || mobile == "")
            {
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
                    RijndaelManaged cipher = new RijndaelManaged();
                    cipher.GenerateKey();
                    Key = cipher.Key;
                    IV = cipher.IV;
                    var key = Encoding.UTF8.GetString(Key);
                    var iv = Encoding.UTF8.GetString(IV);
                    try
                    {
                        using (SqlConnection con = new SqlConnection(MYDBConnectionString))
                        {

                            using (SqlCommand cmd = new SqlCommand("INSERT INTO [User] VALUES(@Name, @Password, @Salt, @Email, @PhoneNo, @Role, @Verified)"))
                            {
                                using (SqlDataAdapter sda = new SqlDataAdapter())
                                {

                                    cmd.CommandType = CommandType.Text;
                                    cmd.Parameters.AddWithValue("@Name", name);
                                    cmd.Parameters.AddWithValue("@Password", "placeholder");
                                    cmd.Parameters.AddWithValue("@Salt", salt);
                                    cmd.Parameters.AddWithValue("@Email", email);
                                    cmd.Parameters.AddWithValue("@PhoneNo", mobile);
                                    cmd.Parameters.AddWithValue("@Role", role);
                                    cmd.Parameters.AddWithValue("@Verified", "Yes");// change to no after 2FA is added
                                    cmd.Connection = con;
                                    con.Open();
                                    cmd.ExecuteNonQuery();
                                    con.Close();
                                    var token = Convert.ToBase64String(encryptData(email));
                                    Debug.WriteLine("Employee created");
                                    Debug.WriteLine("https://localhost:44310/EmployeePasswordSet.aspx?value=" + email);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                }

            }
        }
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException ex)
            {
                return false;
            }
            catch (ArgumentException ex)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        
        public void refreshgrid()
        {
            List<displayUser> patientList = new List<displayUser>();
            List<User> userlist = new List<User>();
            patientList = client.ShowAllPatients().ToList<displayUser>();
            //patientList = client.ShowAllEmployees().ToList<displayUser>();
            EmployeeGridView.Visible = true;
            EmployeeGridView.DataSource = patientList;
            EmployeeGridView.DataBind();
        }

        
        protected byte[] encryptData(string data)
        {
            byte[] cipherText = null;
            try
            {
                RijndaelManaged cipher = new RijndaelManaged();
                cipher.IV = IV;
                cipher.Key = Key;
                ICryptoTransform encryptTransform = cipher.CreateEncryptor();
                byte[] plainText = Encoding.UTF8.GetBytes(data);
                cipherText = encryptTransform.TransformFinalBlock(plainText, 0, plainText.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally { }
            return cipherText;
        }
    }
}