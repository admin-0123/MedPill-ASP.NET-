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
            //  Checks if users intention is to view more card info
            if (Session["authOTPVToken"] != null && Request.Cookies["authOTPVToken"] != null)
            {
                if (!Session["authOTPVToken"].ToString().Equals(Request.Cookies["authOTPVToken"].Value))
                {
                    Response.Redirect("CardList.aspx", false);
                }
                else
                {
                    //Might put these codes below into a function
                    string cardNumber = Request.QueryString["cardNumber"];
                    Service1Client client = new Service1Client();
                    CardInfo cif = client.GetCardByCardNumber(cardNumber);

                    DateTime cardExpiryDate = cif.CardExpiry;

                    cardNameText.Text = cif.CardName;
                    cardNumberText.Text = cif.CardNumber;
                    cardExpiryText.Text = cardExpiryDate.ToString("MMMM yyyy");//Convert.ToDateTime.ToMon(cif.CardExpiry);
                    cvvNumberText.Text = cif.CVVNumber;
                }
            }
            else
            {
                Response.Redirect("CardList.aspx", false);
            }

        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            //Redirect to userpage
            //Remove pass to view more card info session and cookie
            Session.Remove("authOTPVToken");
            Response.Cookies["authOTPVToken"].Value = string.Empty;
            Response.Cookies["authOTPVToken"].Expires = DateTime.Now.AddMonths(-20);
        }

        protected void deleteBtn_Click(object sender, EventArgs e)
        {
            //Remove pass to view more card info session and cookie
            Session.Remove("authOTPVToken");
            Response.Cookies["authOTPVToken"].Value = string.Empty;
            Response.Cookies["authOTPVToken"].Expires = DateTime.Now.AddMonths(-20);

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
            //Remove pass to view more card info session and cookie
            Session.Remove("authOTPVToken");
            Response.Cookies["authOTPVToken"].Value = string.Empty;
            Response.Cookies["authOTPVToken"].Expires = DateTime.Now.AddMonths(-20);

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