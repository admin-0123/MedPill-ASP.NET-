using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Medical_Condition_Create : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_Medical_Condition.aspx");
        }

        protected void btn_submit_click(object sender, EventArgs e)
        {
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            string id = "1";
            string patient = tb_patient.Text.ToString();
            string med_condition = tb_med_condition.Text.ToString();
            string date = tb_date.Text.ToString();
            string doctor = tb_doctor.Text.ToString();
            string clinic = tb_clinic.Text.ToString();
            string treatment = tb_treatment.Text.ToString();
            string condition_desc = tb_condition_desc.Text.ToString();
            string patient_condition = tb_patient_condition.Text.ToString();
            string comments = tb_comments.Text.ToString();
            int Medical_Condition = client.CreateMedicalCondition(id, patient, med_condition, date, doctor, clinic, treatment, condition_desc, patient_condition, comments);
            Response.Redirect("Patient_Medical_Condition.aspx");
        }
    }
}