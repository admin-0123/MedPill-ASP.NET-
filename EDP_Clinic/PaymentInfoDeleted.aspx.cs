using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class PaymentInfoDeleted : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks user session
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    //No error
                    Debug.WriteLine("Currently at deleted card info page");
                }
            }
            //No credentials at all
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void goHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx",false);
        }

        protected void paymentListBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CardList.aspx",false);
        }
    }
}