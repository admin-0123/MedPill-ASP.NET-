using EDP_Clinic.EDP_DBReference;
using System;
using System.Drawing;
using System.Globalization;
using System.Web;

namespace EDP_Clinic
{
    public partial class Patient_Update_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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
                string id = Request.QueryString["id"];
                Report eList = new Report();
                Service1Client client = new Service1Client();
                eList = client.GetReportById(id);
                dp_doctor.SelectedValue = eList.Dname;
                tb_patient.Text = eList.Pname;
                dp_clinic.SelectedValue = eList.Clinic;
                tb_date.Text = eList.Date_of_report;
                tb_details.Text = eList.Details;
            }
        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("~/MedicalReports.aspx");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            styles = DateTimeStyles.None;

            int update;
            string id = Request.QueryString["id"];
            string dname = dp_doctor.SelectedValue.ToString();
            string pname = HttpUtility.HtmlEncode(tb_patient.Text.ToString());
            var clinic = dp_clinic.SelectedValue.ToString();
            var date = HttpUtility.HtmlEncode(tb_date.Text.ToString());
            string details = HttpUtility.HtmlEncode(tb_details.Text.ToString());
            if (pname == "" || date == "" || details == "")
            {
                lb_error.Text = "Missing Inputs";
            }
            else if (dname == "--Select--" || clinic == "--Select--")
            {
                lb_error.Text = "Select the dropdown options";
            }
            else if (DateTime.TryParse(date, culture, styles, out dateResult) == false)
            {
                lb_error.Text = "Invaild Date";
                lb_error.ForeColor = Color.Red;
            }
            else
            {
                Service1Client client = new Service1Client();
                update = client.UpdateReportById(id, dname, pname, clinic, date, details);
                Response.Redirect("~/MedicalReports.aspx");
            }
        }
    }
}