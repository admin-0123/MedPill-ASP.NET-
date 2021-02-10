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
            //Session["Login"] = "someone@example.com";

            //string guidToken = Guid.NewGuid().ToString();
            //Session["AuthToken"] = guidToken;
            //HttpCookie AuthToken = new HttpCookie("AuthToken");
            //AuthToken.Value = guidToken;
            //Response.Cookies.Add(AuthToken);


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
                    Debug.WriteLine("Retrieving deleted card info");
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

        }

        protected void paymentListBtn_Click(object sender, EventArgs e)
        {

        }
    }
}