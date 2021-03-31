using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class CardList : System.Web.UI.Page
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
                    Debug.WriteLine("Retrieving card info");
                    retrieveCardInfo();
                }
            }
            //No credentials at all
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void retrieveCardInfo()
        {
            string userID = Session["LoggedIn"].ToString().Trim();

            List<CardInfo> cifList = new List<CardInfo>();
            Service1Client client = new Service1Client();
            cifList = client.GetAllCards(userID).ToList<CardInfo>();

            cardListView.Visible = true;
            cardListView.DataSource = cifList;
            cardListView.DataBind();

            //If user has less than 3 cards
            //Allow user to add more cards
            if (cifList.Count < 3)
            {
                addCardInfo.Enabled = true;
            }
            //Else disable button
            else
            {
                addCardInfo.Enabled = false;
            }
        }

        protected void moreBtn_Click(object sender, EventArgs e)
        {
            //string cardNumber = CommandArgument
            //Response.Redirect("Authentication.aspx?="); //+ ((LinkButton)sender).Text);
        }

        protected void addCardInfo_Click(object sender, EventArgs e)
        {
            //Create intention for user to add card info
            string guid = Guid.NewGuid().ToString();
            Session["addCardInfo"] = guid;

            Response.Cookies.Add(new HttpCookie("addCardInfo", guid));
            Response.Redirect("Authentication.aspx", false);
        }

        protected void cardListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Checks if button clicked is view more button
            if (String.Equals(e.CommandName, "viewMore"))
            {
                Session["UniqueIdentifier"] = e.CommandArgument.ToString();

                //Create intention for user to view card info
                string guid = Guid.NewGuid().ToString();
                Session["viewCardInfo"] = guid;

                Response.Cookies.Add(new HttpCookie("viewCardInfo", guid));
                Response.Redirect("Authentication.aspx", false);
            }
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx", false);
        }
    }
}