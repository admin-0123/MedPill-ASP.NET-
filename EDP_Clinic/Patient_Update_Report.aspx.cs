using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    if (Session["UserRole"].ToString() != "Doctor" && Session["UserRole"].ToString() != "Nurse")
                    {
                        Response.Redirect("Home.aspx", false);
                    }
                }
                string id = Request.QueryString["id"];
                Report eList = new Report();
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
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
            Response.Redirect("Create_Report.aspx");
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
            var dname = tb_doctor.Text.ToString();
            var pname = tb_patient.Text.ToString();
            var clinic = tb_clinic.Text.ToString();
            var date = tb_date.Text.ToString();
            var details = HttpUtility.HtmlEncode(tb_details.Text.ToString());
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
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                update = client.UpdateReportById(id, dname, pname, clinic, date, details);
                Response.Redirect("Create_Report.aspx");
            }

        }
    }
}