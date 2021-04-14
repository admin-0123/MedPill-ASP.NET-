using EDP_Clinic.EDP_DBReference;
using System;
using System.Drawing;
using System.Globalization;
using System.Web;

namespace EDP_Clinic
{
    public partial class Medical_Condition_Create : System.Web.UI.Page
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

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Patient_Medical_Condition.aspx");
        }

        protected void btn_submit_click(object sender, EventArgs e)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            styles = DateTimeStyles.None;

            Service1Client client = new Service1Client();
            string id = "1";
            string patient = HttpUtility.HtmlEncode(tb_patient.Text.ToString());
            string med_condition = HttpUtility.HtmlEncode(tb_med_condition.Text.ToString());
            string date = HttpUtility.HtmlEncode(tb_date.Text.ToString());
            string doctor = dp_doctor.SelectedValue.ToString();
            string clinic = dp_clinic.SelectedValue.ToString();
            string treatment = HttpUtility.HtmlEncode(tb_treatment.Text.ToString());
            string condition_desc = HttpUtility.HtmlEncode(tb_condition_desc.Text.ToString());
            string patient_condition = HttpUtility.HtmlEncode(tb_patient_condition.Text.ToString());
            string comments = HttpUtility.HtmlEncode(tb_comments.Text.ToString());
            if (patient == "" || med_condition == "" || date == "" || treatment == "" || condition_desc == "" || patient_condition == "" || comments == "")
            {
                lb_error.Text = "Missing Inputs";
            }
            else if (doctor == "--Select--" || clinic == "--Select--")
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
                int Medical_Condition = client.CreateMedicalCondition(id, patient, med_condition, date, doctor, clinic, treatment, condition_desc, patient_condition, comments);
                Response.Redirect("~/Patient_Medical_Condition.aspx");
            }

        }
    }
}