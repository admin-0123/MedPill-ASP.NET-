using EDP_Clinic.EDP_DBReference;
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
            //Card Number 3122131312132131
            string cardNumber = Request.QueryString["cardNumber"];
            Service1Client client = new Service1Client();
            CardInfo cif = client.GetCardByCardNumber(cardNumber);

            DateTime cardExpiryDate = cif.CardExpiry;

            cardNameText.Text = cif.CardName;
            cardNumberText.Text = cif.CardNumber;
            cardExpiryText.Text = cardExpiryDate.ToString("MMMM yyyy");//Convert.ToDateTime.ToMon(cif.CardExpiry);
            cvvNumberText.Text = cif.CVVNumber;
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            //Redirect to userpage
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            //Create intention for user to delete card info
            string guid = Guid.NewGuid().ToString();
            Session["deleteCardInfo"] = guid;

            string cardNumber = Request.QueryString["cardNumber"];
            Service1Client client = new Service1Client();
            CardInfo cif = client.GetCardByCardNumber(cardNumber);
            //Delete at authentication page
            Session["cardNumber"] = cif.CardNumber;

            Response.Cookies.Add(new HttpCookie("deleteCardInfo", guid));
            Response.Redirect("Authentication.aspx", false);
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            //Create intention for user to update card info
            string guid = Guid.NewGuid().ToString();
            Session["changeCardInfo"] = guid;

            string cardNumber = Request.QueryString["cardNumber"];
            Service1Client client = new Service1Client();
            CardInfo cif = client.GetCardByCardNumber(cardNumber);
            //Update at updateCard page
            Session["cardNumber"] = cif.CardNumber;

            Response.Cookies.Add(new HttpCookie("changeCardInfo", guid));
            Response.Redirect("Authentication.aspx", false);
        }
    }
}