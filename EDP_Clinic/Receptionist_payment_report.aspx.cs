using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Receptionist_payment_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }
        private void RefreshGridView()
        {
            List<Payment_Report> eList = new List<Payment_Report>();
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            eList = client.GetAllPayment_Report().ToList<Payment_Report>();

            // using gridview to bind to the list of employee objects
            gv_payment_report.Visible = true;
            gv_payment_report.DataSource = eList;
            gv_payment_report.DataBind();
        }
    }
}