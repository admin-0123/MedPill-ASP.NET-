using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Web;

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
                    string userID = Session["LoggedIn"].ToString().Trim();
                    string cardNumber = Session["UniqueIdentifier"].ToString();//Request.QueryString["cardNumber"];
                    Service1Client client = new Service1Client();
                    CardInfo cif = client.GetCardByCardNumber(userID, cardNumber);

                    string cardStartNum = cif.CardNumber.Substring(0, 1);

                    //Visa
                    if (cardStartNum == "4")
                    {
                        cardIcon.ImageUrl = "~/assets/images/VBM_COF.png";
                    }
                    //Mastercard
                    else if (cardStartNum == "5")
                    {
                        cardIcon.ImageUrl = "~/assets/images/mc_vrt_opt_pos_53_3x.png";
                    }
                    //Discover Card
                    else if (cardStartNum == "6")
                    {
                        //
                    }
                    else
                    {
                        //Add codes to show other cards
                    }
                    Debug.WriteLine(cif.CardNumber.Substring(0, 1));

                    DateTime cardExpiryDate = cif.CardExpiry;

                    cardNameText.Text = cif.CardName;
                    string cardNumberDisplay = cif.CardNumber.Substring(12, 4);
                    cardNumberText.Text = "**** **** **** " + cardNumberDisplay;
                    cardExpiryText.Text = cardExpiryDate.ToString("MMMM yyyy");//Convert.ToDateTime.ToMon(cif.CardExpiry);

                    //Display card expiry status
                    DateTime currentDate = DateTime.Now;
                    double monthDifference = cardExpiryDate.Subtract(currentDate).Days / (365.25 / 12);
                    if (monthDifference > 3)
                    {
                        cardExpiryStatus.Text = "Your card exipiry date is valid.";
                        cardExpiryStatus.ForeColor = Color.Green;
                    }
                    else if (monthDifference <= 3 && monthDifference > 0)
                    {
                        cardExpiryStatus.Text = "Please ensure that your card expiry date is 3 months from current date.";
                        cardExpiryStatus.ForeColor = Color.Red;
                    }
                    else
                    {
                        cardExpiryStatus.Text = "Please update your card information immediately by deleting and then adding a new card information.";
                        cardExpiryStatus.ForeColor = Color.Red;
                    }
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
            Session.Remove("UniqueIdentifier");
            Session.Remove("authOTPVToken");
            Response.Cookies["authOTPVToken"].Value = string.Empty;
            Response.Cookies["authOTPVToken"].Expires = DateTime.Now.AddMonths(-20);

            Response.Redirect("CardList.aspx", false);
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

            string cardNumber = Session["UniqueIdentifier"].ToString();
            Service1Client client = new Service1Client();

            Response.Cookies.Add(new HttpCookie("deleteCardInfo", guid));
            Response.Redirect("Authentication.aspx", false);
        }

    }
}