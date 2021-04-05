using EDP_Clinic.EDP_DBReference;
using System;

namespace EDP_Clinic
{
    public partial class CaregiverApproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadApproval();
        }

        protected void LoadApproval()
        {
            Service1Client svc_client = new Service1Client();
            var caregiver_id = Request.QueryString["value"];
            var patient_id = Request.QueryString["value2"];
            var caregiver_code = Request.QueryString["emailCode"];
            var patient_code = Request.QueryString["emailCode2"];

            if (caregiver_id != null || patient_id != null || caregiver_code != null || patient_code != null)
            {
                var cg_obj = svc_client.GetOneUser(caregiver_id);
                var patient_obj = svc_client.GetOneUser(patient_id);
                svc_client.CheckCodeExist(caregiver_code);
                svc_client.CheckCodeExist(patient_code);

                // Don't need to assign values if you just need to call it
                // var checkCGCodeExists = svc_client.CheckCodeExist(caregiver_code);
                // var checkPatientCodeExists = svc_client.CheckCodeExist(patient_code);

                var checkCGEmail = svc_client.GetEmailbyCode(caregiver_code);
                var checkPatientEmail = svc_client.GetEmailbyCode(patient_code);
                /*            if (checkCGCodeExists == 1 && checkPatientCodeExists == 1)
                            {
                            }*/

                if (checkCGEmail == cg_obj.Email && checkPatientEmail == patient_obj.Email)
                {
                    var addCT = svc_client.AddCaretaker(cg_obj.Id);
                    var approveCG = svc_client.ApproveCaregiver(cg_obj.Id, patient_obj.Id);

                    // If update for both tables succeeds
                    if (addCT == 1 && approveCG == 1)
                    {
                        lbl_test.Text = $"You have approved {cg_obj.Name}'s request to be a caregiver for you. \n Caregiver Name: {cg_obj.Name} \n Care Receiver: {patient_obj.Name}";
                    }
                    // If the crendentials match but the server couldnt update
                    else
                    {
                        lbl_test.Text = $"You have approved {cg_obj.Name}'s request to be a caregiver for you. \n But it seems like there is a problem with the server, please request again";
                    }
                }
                else
                {
                    Response.Redirect("~/Home.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Home.aspx");
            }
        }
    }
}