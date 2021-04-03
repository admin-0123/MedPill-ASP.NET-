using System;
using System.Drawing;
using System.Globalization;
using System.Web;

namespace EDP_Clinic
{
    public partial class Patient_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else
            {
                if (Session["UserRole"].ToString() != "Doctor")
                {
                    Response.Redirect("~/Home.aspx", false);
                }
            }
        }

        protected void btn_submit_info(object sender, EventArgs e)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            styles = DateTimeStyles.None;

            var id = "1";
            //var dname = HttpUtility.HtmlEncode(tb_doctor.Text.ToString());
            var dname = dp_doctor.SelectedValue.ToString();
            string pname = HttpUtility.HtmlEncode(tb_patient.Text.ToString());
            var clinic = dp_clinic.SelectedValue.ToString();
            var date = HttpUtility.HtmlEncode(tb_date.Text.ToString());
            string details = HttpUtility.HtmlEncode(tb_details.Text.ToString());

            if (dname == "" || pname == "" || clinic == "" || date == "" || details == "")
            {
                lb_error.Text = "Missing Inputs";
                lb_error.ForeColor = Color.Red;
            }
            else if (dname == "--Select--" || clinic == "--Select--")
            {
                lb_error.Text = "Select the dropdown";
                lb_error.ForeColor = Color.Red;
            }
            else if (DateTime.TryParse(date, culture, styles, out dateResult) == false)
            {
                lb_error.Text = "Invaild Date";
                lb_error.ForeColor = Color.Red;
            }
            else
            {
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                int report = client.CreateReport(id, dname, pname, clinic, date, details);
                //var url = "Create Report.aspx?dname=" + dname + "&pname=" + pname + "&clinic= "+clinic+"&date="+date+"&details=" + details;

                Response.Redirect("~/MedicalReports.aspx");
            }

        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("~/MedicalReports.aspx");
        }
    }
}