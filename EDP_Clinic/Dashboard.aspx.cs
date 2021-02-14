using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_report_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create Report.aspx");
        }

        protected void btn_condition_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_Medical_Condition.aspx");
        }

        protected void btn_particulars_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_view_details.aspx");
        }

        protected void btn_late_Click(object sender, EventArgs e)
        {
            Response.Redirect("Receptionist_payment_report.aspx");
        }
        protected void btn_mc_Click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_MC.aspx");
        }
    }
}