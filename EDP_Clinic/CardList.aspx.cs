using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class CardList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<CardInfo> cifList = new List<CardInfo>();
            Service1Client client = new Service1Client();
            cifList = client.GetAllCards().ToList<CardInfo>();

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

        }

        protected void cardListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Checks if button clicked is view more button
            if (String.Equals(e.CommandName, "viewMore"))
            {
                //Card number will be encrypted later on
                //For now, just pass a plain-text number
                Response.Redirect("PaymentInformation.aspx?cardNumber=" + e.CommandArgument);
            }
        }
    }
}