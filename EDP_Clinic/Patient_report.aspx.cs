using System;

namespace EDP_Clinic
{
    public partial class Patient_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_info(object sender, EventArgs e)
        {
            var id = "1";
            var dname = tb_doctor.Text.ToString();
            var pname = tb_patient.Text.ToString();
            var clinic = tb_clinic.Text.ToString();
            var date = tb_date.Text.ToString();
            var details = tb_details.Text.ToString();

            if (dname == "" || pname == "" || clinic == "" || date == "" || details == "")
            {
                lb_error.Text = "Missing Inputs";
            }
            else
            {
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                int report = client.CreateReport(id, dname, pname, clinic, date, details);
                //var url = "Create Report.aspx?dname=" + dname + "&pname=" + pname + "&clinic= "+clinic+"&date="+date+"&details=" + details;

                Response.Redirect("Create Report.aspx");
            }

        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("Create Report.aspx");
        }

    }
}