using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class PaymentInformation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            //Redirect to userpage
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Authentication.aspx", false);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Authentication.aspx", false);
        }
    }
}