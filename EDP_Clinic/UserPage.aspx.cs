using EDP_Clinic.EDP_DBReference;
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
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

            var email = Session["LoggedIn"].ToString();
            var user = client.GetOneUserByEmail(email);
            lblName.Text = user.Name.ToString();
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

        protected void changeinfoBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeInfo.aspx", false);

        }
    }
}