using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class PFA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Validation if no valid user session, redirect to error page
            Session["UserID"] = 1;
            Session["LoggedIn"] = "placeholder";
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
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            User userobj = client.GetOneUser(Convert.ToInt32(Session["UserID"]));
            if (userobj != null)
            {
                //lbl_profileName.Text = "NAME: " + userobj.Name;
                lbl_profileName.Text = userobj.Name;
                System.Diagnostics.Debug.WriteLine("CARE RECEIVER ID IS " + userobj.CareReceiverID);
                User care_receiverobj = client.GetOneUser(userobj.CareReceiverID);
                if (care_receiverobj != null)
                {
                    lbl_crName.Text = care_receiverobj.Name;

                    //userPfp.ImageUrl = $"~/assets/images/{userobj.Photo}.png";
                    crPfp.ImageUrl = "~/assets/images/rightArrow.png";
                }

                else
                {
                    lbl_crName.Text = "Null";

                }
            }

        }

    }
}