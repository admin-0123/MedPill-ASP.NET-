using System;
using System.Collections.Generic;

namespace EDP_Clinic
{
    public partial class ReceptAssignDoctor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {

                if (Session["UserRole"].ToString() == "Receptionist")
                {
                    if (!IsPostBack)
                    {
                        hl_bc_profileName.Text = $"{Session["patient_name"].ToString()}'s Appointment on {Convert.ToDateTime(Session["selected_appt_date"])}";
                        EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
                        var doc_list = svc_client.GetAllDoctors();
                        var new_list = new List<String>();
                        foreach (var i in doc_list)
                        {
                            new_list.Add(i.Name);
                        }
                        ddl_chooseDoctors.DataSource = new_list;
                        ddl_chooseDoctors.DataBind();
                    }
                }

                else
                {
                    Response.Redirect("Home.aspx", false);
                }
            }

            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void btn_assignDoctor_Click(object sender, EventArgs e)
        {
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            System.Diagnostics.Debug.WriteLine("DOCTOR NAME IS " + Session["doctor_name"].ToString());
            System.Diagnostics.Debug.WriteLine("PATIENT NAME IS " + Session["patient_name"].ToString());
            System.Diagnostics.Debug.WriteLine("APPT DATE IS " + Convert.ToDateTime(Session["selected_appt_date"]));

            var doctor_obj = svc_client.GetOneDoctor(ddl_chooseDoctors.SelectedValue.ToString());
            System.Diagnostics.Debug.WriteLine("NEW DOCTOR NAME IS " + ddl_chooseDoctors.SelectedValue.ToString());
            try
            {
                var patient_obj = svc_client.GetPatientByName(Session["patient_name"].ToString());

                var date_time = Convert.ToDateTime(Session["selected_appt_date"]);

                System.Diagnostics.Debug.WriteLine("PATIENT ID IS " + patient_obj.Id);

                System.Diagnostics.Debug.WriteLine("DOCTOR ID IS " + doctor_obj.Id);
                var updateDoctor = svc_client.UpdateDoctor(Convert.ToInt32(patient_obj.Id), date_time, Convert.ToInt32(doctor_obj.Id));
                if (updateDoctor == 1)
                {
                    lbl_updateResult.Text = "Update Successful";
                }
            }

            // Problem only occur if trying to assign doctor to an appointment that is created with receptionist account, line of code below to handle the error.
            catch (NullReferenceException)
            {
                lbl_updateResult.Text = "Update Failed, cannot assign doctor to an appointment without a valid patient";
            }






        }
    }
}