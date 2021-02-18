using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Create_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView();
            }
        }

        protected void btn_submit_add(object sender, EventArgs e)
        {
            Response.Redirect("Patient_report.aspx");
        }

        private void RefreshGridView()
        {
            List<Report> eList = new List<Report>();
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            eList = client.GetAllReport().ToList<Report>();

            // using gridview to bind to the list of employee objects
            gv_report.Visible = true;
            gv_report.DataSource = eList;
            gv_report.DataBind();
        }

        protected void gv_report_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editing")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gv_report.Rows[index - 1];
                string id = selectedRow.Cells[0].Text;

                string url = "Patient_Update_report.aspx?id=" + id;
                Response.Redirect(url);

            }
        }
    }
}