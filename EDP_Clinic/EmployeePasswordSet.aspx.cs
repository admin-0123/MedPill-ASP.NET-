﻿using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace EDP_Clinic
{
    public partial class EmployeePasswordSet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string code = Request.QueryString["value"];
            if (code == null)
            {
                Response.Redirect("~/Home.aspx", false);
            }
            Debug.WriteLine(code);
            codeLbl.Text = code;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string finalHash;
            string salt;

            string password = HttpUtility.HtmlEncode(tbpassword.Text.ToString().Trim());
            string password2 = HttpUtility.HtmlEncode(tbpassword2.Text.ToString().Trim());
            if (password == password2)
            {
                var errors = passwordcheck(password);
                if (errors != "")
                {
                    errorMsg.Text = errors;
                    errorMsg.ForeColor = Color.Red;
                    errorMsg.Visible = true;
                    return;
                }
            }
            else
            {
                errorMsg.Text = "Passwords not the same";
                errorMsg.ForeColor = Color.Red;
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
                errorMsg.Text = "Unknown error has occured";
                errorMsg.ForeColor = Color.Red;
                errorMsg.Visible = true;
                return;
            }
            Response.Redirect("~/Login.aspx", false);
        }
        protected string passwordcheck(string password)
        {
            var errors = "";
            if (password.Length < 8)
            {
                errors += "Password must at least be 8 characters long <br/>";
            }
            if (!Regex.IsMatch(password, "[a-s]"))
            {
                errors += "Password must contain lowercase letters <br/>";
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                errors += "Password must contain uppercase letters <br/>";
            }
            if (!Regex.IsMatch(password, "[0-9]"))
            {
                errors += "Password must contain at least 1 number <br/>";
            }
            if (!Regex.IsMatch(password, "[^0-9a-zA-Z]"))
            {
                errors += "Password must contain at least one symbol <br/>";
            }
            return errors;
        }
    }
}