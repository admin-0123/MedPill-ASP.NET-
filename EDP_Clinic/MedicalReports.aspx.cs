using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Create_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else
            {
                if (Session["UserRole"].ToString() != "Doctor" && Session["UserRole"].ToString() != "Nurse")
                {
                    Response.Redirect("~/Home.aspx", false);
                }
            }
        }

        protected void gv_report_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView(0);
                gv_report.DataBind();
            }

        }
        protected void btn_submit_add(object sender, EventArgs e)
        {
            Response.Redirect("~/AddMedicalReports.aspx");
        }

        private void RefreshGridView(int pageNumber)
        {
            List<Report> eList = new List<Report>();
            Service1Client client = new Service1Client();
            eList = client.GetAllReport().ToList<Report>();
            gv_report.PageIndex = pageNumber;
            gv_report.DataSource = eList;
            gv_report.Visible = true;
            // using gridview to bind to the list of employee objects


        }
        protected void gv_report_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_report.PageIndex = e.NewPageIndex;
            Debug.WriteLine("Yes " + gv_report.PageIndex);
            RefreshGridView(gv_report.PageIndex);
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

                string url = "~/UpdateMedicalReports.aspx?id=" + id;
                Response.Redirect(url);

            }
        }
    }
}