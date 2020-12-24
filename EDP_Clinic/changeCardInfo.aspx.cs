using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Text.RegularExpressions;
using System.Drawing;

namespace EDP_Clinic
{
    public partial class PaymentInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private bool ValidateInput()
        {
            if(String.IsNullOrEmpty(nameOnCardTB.Text))
            {
                nameOnCardError.Text = "Please enter name on card";
                nameOnCardError.ForeColor = Color.Red;
                nameOnCardError.Visible = true;
                //return false;

            }
            else
            {
                nameOnCardError.Text = "";
                nameOnCardError.Visible = false;
            }
            if (String.IsNullOrEmpty(cardNumberTB.Text))
            {
                cardNumberError.Text = "Please enter card number";
                cardNumberError.ForeColor = Color.Red;
                cardNumberError.Visible = true;
                //return false;
            }
            else
            {
                cardNumberError.Text = "";
                cardNumberError.Visible = false;
            }

            if (String.IsNullOrEmpty(cardNumberError.Text) && String.IsNullOrEmpty(nameOnCardError.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();
            
            if (validInput == true)
            {
                nameOnCardError.Visible = false;
                cardNumberError.Visible = false;
                Response.Redirect("/PaymentInformation.aspx");
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "scriptkey", "alert('your message');");
            }
            else
            {
                nameOnCardError.Visible = true;
                cardNumberError.Visible = true;
            }
        }
    }
}