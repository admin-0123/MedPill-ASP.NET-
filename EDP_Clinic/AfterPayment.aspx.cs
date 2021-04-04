using System;
using System.Diagnostics;

namespace EDP_Clinic
{
    public partial class AfterPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks user session
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("~/Login.aspx", false);
                }
                else
                {
                    //No error
                    Debug.WriteLine("Currently at after payment page");
                }
            }
            //No credentials at all
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }


        protected void goToReceipt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReceiptList.aspx", false);
        }

        protected void goHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPage.aspx", false);
        }
    }
}