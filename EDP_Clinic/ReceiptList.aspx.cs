using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
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
            //getReceiptList();
            
        }

        protected void getReceiptList()
        {
            List<CardInfo> cifList = new List<CardInfo>();
            Service1Client client = new Service1Client();
            cifList = client.GetAllCards().ToList<CardInfo>();

            receiptListView.DataSource = cifList;
            receiptListView.Visible = true;
            //receiptListView.DataBind();
        }

        //Rename datapager 1 to receiptListPager
        protected void DataPager1_PreRender(object sender, EventArgs e)
        {
            getReceiptList();
            receiptListView.DataBind();
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {

        }
    }
}