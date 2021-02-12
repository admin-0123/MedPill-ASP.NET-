using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Receipt : System.Web.UI.Page
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
            //var result = client.SelectAllReceipt(userID).ToList<Receipt>();
            //Debug.WriteLine(result);
            //List<Receipt> repList = result.ToList();
            //List<CardInfo> cifList = new List<CardInfo>();
            ////Service1Client client = new Service1Client();
            //cifList = client.GetAllCards(userID).ToList<CardInfo>();


            receiptListView.DataSource = repList;
            receiptListView.Visible = true;

            if(repList.Count == 0 || repList == null)
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
            //PrintNodeNet
        }
    }
}