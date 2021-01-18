using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.IO;
using EDP_Clinic.EDP_DBReference;

namespace EDP_Clinic
{
    public partial class EmployeePasswordSet : System.Web.UI.Page
    {
        string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;
        static string finalHash;
        static string salt;

        protected void Page_Load(object sender, EventArgs e)
        {
            var email = Request.QueryString["value"];
            Debug.WriteLine(email);
            emailLbl.Text = email;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            User employee = client.GetOneUserByEmail(emailLbl.Text);
            salt = employee.Salt;
            //check if passwords are the same
            string pwd = tbpassword.Text.ToString();
            string pwdWithSalt = pwd + salt;
            SHA512Managed hashing = new SHA512Managed();
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

            finalHash = Convert.ToBase64String(hashWithSalt);

            //store info in database
            try
            {
                using (SqlConnection con = new SqlConnection(MYDBConnectionString))
                {

                    using (SqlCommand cmd = new SqlCommand("UPDATE [User] SET Password = @Password, Verified = @Verified WHERE Email = @Email"))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.Parameters.AddWithValue("Email", emailLbl.Text);
                            cmd.Parameters.AddWithValue("@Password", finalHash);
                            cmd.Parameters.AddWithValue("@Verified", "Yes");
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            Response.Redirect("Login.aspx", false);
        }
        
    }
    

}