using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class ReceiptListAdmin : System.Web.UI.Page
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
                    Debug.WriteLine("Currently at receiptList Admin page");
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
            repList = client.SelectAllReceiptsAdmin().ToList<Receipt>();

            receiptListAdminView.DataSource = repList;
            receiptListAdminView.Visible = true;

            if (repList.Count == 0 || repList == null)
            {
                receiptListAdminPager.Visible = false;
            }
            else
            {
                receiptListAdminPager.Visible = true;
            }
        }

        protected void receiptListAdminPager_PreRender(object sender, EventArgs e)
        {
            getReceiptList();
            receiptListAdminView.DataBind();
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            //Response.Redirect("UserPage.aspx", false);
        }
    }
}