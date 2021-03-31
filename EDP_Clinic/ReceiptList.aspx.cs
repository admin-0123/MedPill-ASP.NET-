using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class ReceiptList : System.Web.UI.Page
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
                    Debug.WriteLine("Currently at receiptList page");
                }
            }
            //No credentials at all
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void getReceiptList()
        {
            string userID = Session["LoggedIn"].ToString().Trim();

            List<Receipt> repList = new List<Receipt>();
            Service1Client client = new Service1Client();
            repList = client.SelectAllReceipts(userID).ToList();

            receiptListView.DataSource = repList;
            receiptListView.Visible = true;

            if (repList.Count == 0 || repList == null)
            {
                receiptListPager.Visible = false;
            }
            else
            {
                receiptListPager.Visible = true;
            }
        }

        //Rename datapager 1 to receiptListPager
        protected void receiptListPager_PreRender(object sender, EventArgs e)
        {
            getReceiptList();
            receiptListView.DataBind();
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx", false);
        }

        protected void receiptListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Checks if button clicked is view more button
            if (String.Equals(e.CommandName, "viewMore"))
            {
                string userID = Session["LoggedIn"].ToString().Trim();
                string uniqueIdentifier = e.CommandArgument.ToString().Trim();
                Service1Client client = new Service1Client();
                Receipt rep = client.SelectByReceiptID(userID, uniqueIdentifier);
                string receiptLink = rep.ReceiptLink.ToString().Trim();
                Response.Redirect(receiptLink, false);
            }
        }
    }
}