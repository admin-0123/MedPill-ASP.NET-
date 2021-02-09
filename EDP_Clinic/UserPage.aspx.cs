using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class UserPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void appointmentBtn_Click(object sender, EventArgs e)
        {

        }

        protected void medicationBtn_Click(object sender, EventArgs e)
        {

        }


        //Hasan's Stuff
        protected void paymentMethodBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CardList.aspx", false);
        }

        protected void paymentHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReceiptList.aspx", false);
        }
    }
}