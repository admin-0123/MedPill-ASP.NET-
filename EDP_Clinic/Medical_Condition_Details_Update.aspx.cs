using EDP_Clinic.EDP_DBReference;
using System;

namespace EDP_Clinic
{
    public partial class Medical_Condition_Details_Update : System.Web.UI.Page
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
                Medical_Condition eList = new Medical_Condition();
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                eList = client.GetMedicalConditionById(id);
                patient.Text = eList.Name;
                condition.Text = eList.Med_Condition;
                date.Text = eList.Date_Diagnosis;
                doctor.Text = eList.Doctor;
                clinic.Text = eList.Clinic;
                treatment.Text = eList.Treatment;
                description.Text = eList.Condition_Desc;
                tb_patient_condition.Text = eList.Patient_Codition;
                tb_comments.Text = eList.Comments;
            }
        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string url = "Medical_Condition_Details.aspx?id=" + id;
            Response.Redirect(url);
        }

        protected void btn_update_click(object sender, EventArgs e)
        {
            int update;
            string id = Request.QueryString["id"];
            var Patient_Condition = HttpUtility.HtmlEncode(tb_patient_condition.Text.ToString());
            var Comments = HttpUtility.HtmlEncode(tb_comments.Text.ToString());
            if (Patient_Condition == "" || Comments == "")
            {
                lb_error.Text = "Missing Inputs";
            }
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            update = client.UpdateMedicalConditionById(id, Patient_Condition, Comments);
            Response.Redirect("Patient_Medical_Condition.aspx");
        }
    }
}