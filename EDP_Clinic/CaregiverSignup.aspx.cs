using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace EDP_Clinic
{
    public partial class CaregiverSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                if (!IsPostBack)
                {
                    LoadPatients();
                }
            }
            else
            {
                Response.Redirect("404.aspx", false);
            }
        }
        protected void LoadPatients()
        {
            Service1Client svc_client = new Service1Client();
            var current_user_obj = svc_client.GetOneUserByEmail(Session["LoggedIn"].ToString());
            var patientList = svc_client.GetAllPatients();
            var new_list = new List<String>();
            foreach (var i in patientList)
            {
                // Check whether the id of the current item is either a care giver or a receiver
                // Do not allow either one to be added to list of available patients
                var cg_object = svc_client.GetOneCG(i.Id);
                var cg_objectbyCR = svc_client.GetOneCGByCRID(i.Id);

                if (cg_object != null || cg_objectbyCR != null)
                {

                }
                else
                {
                    new_list.Add(i.Name);
                }
            }

            // Remove the current user himself from list of selectable care receivers.
            if (new_list.Contains(current_user_obj.Name))
            {
                new_list.Remove(current_user_obj.Name);
            }

            ddl_allPatients.DataSource = new_list;
            ddl_allPatients.DataBind();

            if (current_user_obj.IsCaretaker == "No" || current_user_obj.IsCaretaker == null)
            {
                lbl_cgstatus.Text = "Not currently a caregiver";
            }
            else
            {
                lbl_cgstatus.Text = "You currently a caregiver";
                lbl_cgstatus.ForeColor = Color.Green;
                ddl_allPatients.Visible = false;
                lbl_instruction.Visible = false;
                btn_stopCG.Visible = true;
                btn_becomeCG.Visible = false;
                //btn_becomeCG.Text = "Remove Care Receiver";
                /*                btn_becomeCG.Click -= btn_becomeCG_Click;
                                btn_becomeCG.Click += btn_stopCG_Click;*/
                //btn_becomeCG.Click -= new EventHandler(btn_becomeCG_Click);
                //btn_becomeCG.Click += new EventHandler(btn_stopCG_Click);
            }
        }

        // User becomes a caregiver
        protected void btn_becomeCG_Click(object sender, EventArgs e)
        {
            Service1Client svc_client = new Service1Client();
            var selected_cr = svc_client.GetPatientByName(ddl_allPatients.SelectedValue.ToString());
            Session["Selected_CR"] = selected_cr.Id;
            //string messageContent = "alert(\"You decoded to become a caregiver!\");";
            //ScriptManager.RegisterStartupScript(this, GetType(),
            // "ServerControlScript", messageContent, true);
            //Response.Redirect("~/CaregiverSignup.aspx");
            Response.Redirect("~/CaregiverNotification.aspx");
        }

        // User chooses not to become a caregiver
        protected void btn_stopCG_Click(object sender, EventArgs e)
        {
            Service1Client svc_client = new Service1Client();
            var current_user = svc_client.GetOneUserByEmail(Session["LoggedIn"].ToString());
            var selected_cr = svc_client.GetOneCG(current_user.Id);
            Session["Selected_CR"] = selected_cr.Carereceiver_id;
            // string messageContent = "alert(\"You have stopped being a caregiver!\");";

            //ScriptManager.RegisterStartupScript(this, GetType(),
            //             "ServerControlScript", messageContent, true);
            //Response.Redirect("~/CaregiverSignup.aspx");
            Response.Redirect("~/CaregiverRemoval.aspx");
        }

        // Goes back to user page
        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPage.aspx", false);
        }
    }
}