using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

namespace EDP_Clinic
{
    public partial class PFA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validation if no valid user session, redirect to error page
            //Session["UserID"] = 1;
            //Session["LoggedIn"] = "placeholder";
            // Session["userName"]

            if (Session["LoggedIn"] != null) {
                LoadProfile();
            }

            else
            {
                Response.Redirect("404.aspx", false);
            }


        }


        protected void LoadProfile()
        {
            Service1Client client = new Service1Client();

            Debug.WriteLine("SESSION EMAIL IS " + Session["LoggedIn"].ToString());

            User userobj = client.GetOneUserByEmail(Session["LoggedIn"].ToString());

            Debug.WriteLine("USER ID IS " + userobj.Id);

            Photo photo_obj = client.GetOnePhoto(userobj.Id);

            if (userobj != null)
            {
                //lbl_profileName.Text = "NAME: " + userobj.Name;
                lbl_profileName.Text = userobj.Name;
                // Need to trim the string variable, or the image url will not display properly due to encoded whitespaces %20%20
                if (photo_obj != null)
                {
                    // Add ImageURL line here
                    userPfp.ImageUrl = $"~/assets/images/{photo_obj.Photo_Resource.Trim()}.jpg";
                }

                Debug.WriteLine("CARE GIVER ID IS " + userobj.Id);
                Caregiver caregiver_obj = client.GetOneCG(userobj.Id);

                Debug.WriteLine("CARE RECEIVER ID IS " + caregiver_obj.Carereceiver_id);
                User care_receiverobj = client.GetOneUser(caregiver_obj.Carereceiver_id);
                Debug.WriteLine("CARE RECEIVER NAME IS " + care_receiverobj.Name);
                Debug.WriteLine("CARE RECEIVER ID IS " + care_receiverobj.Id);

                Photo photo_obj_cr = client.GetOnePhoto(caregiver_obj.Carereceiver_id);


                if (care_receiverobj != null)
                {    
                    lbl_crName.Text = care_receiverobj.Name;
                    crPfp.ImageUrl = $"~/assets/images/{photo_obj_cr.Photo_Resource.Trim()}.jpg";
                }

                else
                {
                    crPfp.Visible = false;
                    crArrow.Visible = false;
                    lbl_crName.Text = "You do not have any care receivers";
                }
            }

        }

        protected void View_Appt_Patient(object sender, ImageClickEventArgs e)
        {
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            User userobj = client.GetOneUserByEmail(Session["LoggedIn"].ToString());
            Session["current_appt_profile"] = userobj.Id;
            Response.Redirect("~/PRFA2.aspx");
        }

        protected void View_Appt_CR(object sender, ImageClickEventArgs e)
        {
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            User userobj = client.GetOneUserByEmail(Session["LoggedIn"].ToString());
            Caregiver caregiver_obj = client.GetOneCG(userobj.Id);
            User care_receiverobj = client.GetOneUser(caregiver_obj.Carereceiver_id);

            Session["current_appt_profile"] = care_receiverobj.Id;
            Response.Redirect("~/PRFA2.aspx");
        }
    }
}