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
using System.Text.RegularExpressions;

namespace EDP_Clinic
{
    public partial class EmployeePasswordSet : System.Web.UI.Page
    {
        static string finalHash;
        static string salt;

        protected void Page_Load(object sender, EventArgs e)
        {
            var code = Request.QueryString["value"];
            Debug.WriteLine(code);
            codeLbl.Text = code;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var password = tbpassword.Text;
            var password2 = tbpassword2.Text;
            if (password == password2)
            {
                var errors = passwordcheck(password);
                if (errors != "")
                {
                    errorMsg.Text = errors;
                    errorMsg.ForeColor = System.Drawing.Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
            }
            else
            {
                errorMsg.Text = "Passwords not the same";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
                return;
            }
            Service1Client client = new Service1Client();
            var theEmail = client.GetEmailbyCode(codeLbl.Text);
            User employee = client.GetOneUserByEmail(theEmail);
            salt = employee.Salt;
            string pwd = tbpassword.Text.ToString();
            string pwdWithSalt = pwd + salt;
            SHA512Managed hashing = new SHA512Managed();
            byte[] plainHash = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            byte[] hashWithSalt = hashing.ComputeHash(Encoding.UTF8.GetBytes(pwdWithSalt));

            finalHash = Convert.ToBase64String(hashWithSalt);
            var result = client.ChangePassword(finalHash, theEmail);
            if (result == 0)
            {
                errorMsg.Text = "unknown error has occured ";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Visible = true;
                return;
            }
            Response.Redirect("Login.aspx", false);
        }
        protected string passwordcheck(string password)
        {
            var errors = "";
            if (password.Length < 8)
            {
                errors = errors + "Password must at least be 8 characters long <br/>";
            }
            if (Regex.IsMatch(password, "[a-s]"))
            {
                errors = errors + "Password must contain lowercase letters <br/>";
            }
            if (Regex.IsMatch(password, "[A-Z]"))
            {
                errors = errors + "Password must contain uppercase letters <br/>";
            }
            if (Regex.IsMatch(password, "[0-9]"))
            {
                errors = errors + "Password must contain at least 1 number <br/>";
            }
            if (Regex.IsMatch(password, "[^0-9a-zA-Z]"))
            {
                errors = errors + "Password must contain at least one symbol <br/>";
            }
            return errors;
        }

    }
    

}