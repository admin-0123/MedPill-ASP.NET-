using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                        hl_bc_profileName.Text = $"{Session["patient_name"]}'s Appointment on {Convert.ToDateTime(Session["selected_appt_date"])}";
                        Service1Client svc_client = new Service1Client();
                        List<User> doc_list = svc_client.GetAllDoctors().ToList();
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
                    Response.Redirect("~/Home.aspx", false);
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx", false);
            }
        }

        protected void btn_assignDoctor_Click(object sender, EventArgs e)
        {
            Service1Client svc_client = new Service1Client();

            Debug.WriteLine("DOCTOR NAME IS " + Session["doctor_name"].ToString());
            Debug.WriteLine("PATIENT NAME IS " + Session["patient_name"].ToString());
            Debug.WriteLine("APPT DATE IS " + Convert.ToDateTime(Session["selected_appt_date"]));

            var doctor_obj = svc_client.GetOneDoctor(ddl_chooseDoctors.SelectedValue.ToString());
            Debug.WriteLine("NEW DOCTOR NAME IS " + ddl_chooseDoctors.SelectedValue.ToString());
            try
            {
                User patient_obj = svc_client.GetPatientByName(Session["patient_name"].ToString());

                DateTime date_time = Convert.ToDateTime(Session["selected_appt_date"]);

                Debug.WriteLine("PATIENT ID IS " + patient_obj.Id);

                Debug.WriteLine("DOCTOR ID IS " + doctor_obj.Id);
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