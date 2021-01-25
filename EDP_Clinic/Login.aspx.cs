using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Login : System.Web.UI.Page
    {
        //string MYDBConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["EDP_DB"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            /*var email = HttpUtility.HtmlEncode(tbemail.Text);
            var password = HttpUtility.HtmlEncode(tbpassword.Text);

            using (var con = new SqlConnection(MYDBConnectionString))
            {

                var check = "SELECT * FROM [User] WHERE Email = @Email";
                using (var checkC = new SqlCommand(check, con))
                {
                    checkC.Parameters.AddWithValue("@Email", email);
                    con.Open();
                    bool exist = Convert.ToBoolean(checkC.ExecuteScalar());
                    con.Close();
                    if (!exist)
                    {
                        errorMsg.Text = "Email and Password is/are incorrect";
                        errorMsg.ForeColor = Color.Red;   
                    }
                    else
                    {
                        SHA512Managed hashing = new SHA512Managed();
                        string gethash = "SELECT Password FROM [User] WHERE Email = @Email";
                        string getsalt = "SELECT Salt FROM [User] WHERE Email = @Email";
                        using (SqlConnection connection = new SqlConnection(MYDBConnectionString))
                        {
                            SqlCommand hashcommand = new SqlCommand(gethash, connection);
                            SqlCommand saltcommand = new SqlCommand(getsalt, connection);
                            hashcommand.Parameters.AddWithValue("@Email", email);
                            saltcommand.Parameters.AddWithValue("@Email", email);
                            connection.Open();
                            string hash = hashcommand.ExecuteScalar().ToString();
                            string salt = saltcommand.ExecuteScalar().ToString();
                            connection.Close();
                            var pwdWithSalt = password + salt;
                            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));
                            var finalHash = Convert.ToBase64String(hashWithSalt);
                            if (hash == finalHash)
                            {
                                Service1Client client = new Service1Client();
                                User user = client.GetOneUserByEmail(email);
                                var role = user.Role;
                                Session["UserRole"] = role;
                                Session["LoggedIn"] = email;
                                string guid = Guid.NewGuid().ToString();
                                Session["AuthToken"] = guid;
                                if (role == "Patient")
                                {
                                    Response.Redirect("UserPage.aspx", false);
                                }
                                else if (role == "Admin")
                                {
                                    Response.Redirect("AdminPage.aspx", false);
                                }
                                else
                                {
                                    Response.Redirect("PatientOverview.aspx", false);
                                }
                                
                            }
                            else
                            {
                                errorMsg.Text = "Wrong Email/Password";
                                errorMsg.ForeColor = Color.Red;
                                return;
                            }
                        }
                    }
                }
            }*/

        }
    }
}