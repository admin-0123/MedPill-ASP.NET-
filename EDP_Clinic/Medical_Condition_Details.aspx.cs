using EDP_Clinic.EDP_DBReference;
using System;

namespace EDP_Clinic
{
    public partial class Medical_Condition_Details : System.Web.UI.Page
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
                Service1Client client = new Service1Client();
                Medical_Condition eList = client.GetMedicalConditionById(id);
                patient.Text = eList.Name;
                condition.Text = eList.Med_Condition;
                date.Text = eList.Date_Diagnosis;
                doctor.Text = eList.Doctor;
                clinic.Text = eList.Clinic;
                treatment.Text = eList.Treatment;
                description.Text = eList.Condition_Desc;
                patient_condition.Text = eList.Patient_Codition;
                comments.Text = eList.Comments;
            }
        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("~/Patient_Medical_Condition.aspx");
        }

        protected void btn_update_click(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            string url = "~/Medical_Condition_Details_Update.aspx?id=" + id;
            Response.Redirect(url);
        }
    }
}