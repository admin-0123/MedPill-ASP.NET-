using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace EDP_Clinic
{
    public partial class PRFA2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On initial load of the page, set the session variable for viewstate
            if (!IsPostBack)
            {
                Session["appt_viewstate"] = "upcoming";

                // On every postback, search for the session, check the current session value of viewstate and display the contents accordingly.
                // Edit: Shifted the switch statement from page load to here initial page load only as it is causing
                // System.ArgumentException: Invalid postback or callback argument.  Event validation is enabled using <pages enableEventValidation="true"/> in configuration or <%@ Page EnableEventValidation="true" %> in a page.  For security purposes, this feature verifies that arguments to postback or callback events originate from the server control that originally rendered them.  If the data is valid and expected, use the ClientScriptManager.RegisterForEventValidation method in order to register the postback or callback data for validation.

                switch (Session["appt_viewstate"])
                {
                    case "upcoming":
                        listview_appts.DataSource = GetApptsUserUpcoming();
                        listview_appts.DataBind();
                        break;
                    case "past":
                        listview_appts.DataSource = GetApptsUserPast();
                        listview_appts.DataBind();
                        break;
                    case "missed":
                        listview_appts.DataSource = GetApptsUserMissed();
                        listview_appts.DataBind();
                        break;

                }
            }
            
            // Search for the current profile selected and set the necessary contents like profileName.. etc
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            User current_user = svc_client.GetOneUser(Session["current_appt_profile"].ToString());
            // For breadcrumb elements
            hl_bc_profileName.Text = current_user.Name;
            //

            Photo current_user_photo_obj = svc_client.GetOnePhoto(current_user.Id);
            //profilePfp.ImageUrl = $"~/assets/images/{current_user_photo_obj.Photo_Resource.Trim()}.jpg";
            lbl_profileName.Text = current_user.Name;


            var exist3 = svc_client.CheckPhotoExist(current_user.Id);
            if (exist3 == 1)
            {
                var photo = svc_client.GetOnePhoto(current_user.Id);
                var fileName = photo.Photo_Resource.ToString();
                var path = "~/UserImg/" + fileName;
                profilePfp.ImageUrl = path;
            }

            //repeater_appts.DataSource = GetApptsUser();
            //repeater_appts.DataBind();



            var test123 = listview_appts.SelectedIndex;
            //System.Diagnostics.Debug.WriteLine($"SELECTED INDEX IS {test123}");
        }

/*        protected void btn_cancel_click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }*/


        // Get All Appts for one user regardless of the status
        public List<Appointment> GetApptsUser()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            //System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
            testList = svc_client.GetAllApptUser(Convert.ToInt32(Session["current_appt_profile"].ToString())).ToList<Appointment>();
            
            if (testList == null)
            {
                testList = new List<Appointment>();
            }
            return testList;
        }

        // Get All Appts for one user where status is upcoming
        public List<Appointment> GetApptsUserUpcoming()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            //System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
            testList = svc_client.GetAllApptUserUpcoming(Convert.ToInt32(Session["current_appt_profile"].ToString())).ToList<Appointment>();

            if (testList == null)
            {
                testList = new List<Appointment>();
            }

            return testList;
        }

        // Get All Appts for one user where status is upcoming
        public List<Appointment> GetApptsUserPast()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            //System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
            testList = svc_client.GetAllApptUserPast(Convert.ToInt32(Session["current_appt_profile"].ToString())).ToList<Appointment>();

            if (testList == null)
            {
                testList = new List<Appointment>();
            }
            return testList;
        }

        // Get All Appts for one user where status is upcoming
        public List<Appointment> GetApptsUserMissed()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            //System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
            testList = svc_client.GetAllApptUserMissed(Convert.ToInt32(Session["current_appt_profile"].ToString())).ToList<Appointment>();

            if (testList == null)
            {
                testList = new List<Appointment>();
            }
            return testList;
        }

        // Navigate backwards arrow
        protected void leftArrow_redirect_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/PFA.aspx");
        }

        // Go to Make Appointment Page
        protected void btn_makeAppt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CA.aspx");
        }

        // Method that is called when page change for listview_appts control
        protected void listview_appts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            dp_listview_appt.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //rebind List View

            switch (Session["appt_viewstate"])
            {
                case "upcoming":
                    listview_appts.DataSource = GetApptsUserUpcoming();
                    listview_appts.DataBind();
                    break;
                case "past":
                    listview_appts.DataSource = GetApptsUserPast();
                    listview_appts.DataBind();
                    break;
                case "missed":
                    listview_appts.DataSource = GetApptsUserMissed();
                    listview_appts.DataBind();
                    break;

            }
        }

        // Display Helper Methods
        protected String Convert_Placebo(object id)
        {
            if (Convert.ToInt32(id) == 0)
            {
                return "Unassigned";
            }
            else
            {
                return id.ToString();
            }
        }


        // Link Buttons to change the type of appointment records being displayed
        protected void lbtn_upcoming_Click(object sender, EventArgs e)
        {
            if (Session["appt_viewstate"].ToString() != "upcoming")
            {
                // Line Below fixes the bug of being on page 2 or later in a viewstate and then changing to another viewstate, causing the indexes to still be there
                // Reset the page to the first
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                lbtn_upcoming.CssClass = "";
                lbtn_past.CssClass = "lbtn_inactive";
                lbtn_missed.CssClass = "lbtn_inactive";
                Session["appt_viewstate"] = "upcoming";
                listview_appts.DataSource = GetApptsUserUpcoming();
                listview_appts.DataBind();
            }

        }

        protected void lbtn_past_Click(object sender, EventArgs e)
        {
            if (Session["appt_viewstate"].ToString() != "past")
            {
                // Line Below fixes the bug of being on page 2 or later in a viewstate and then changing to another viewstate, causing the indexes to still be there
                // Reset the page to the first
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                lbtn_upcoming.CssClass = "lbtn_inactive";
                lbtn_past.CssClass = "";
                lbtn_missed.CssClass = "lbtn_inactive";
                Session["appt_viewstate"] = "past";
                listview_appts.DataSource = GetApptsUserPast();
                listview_appts.DataBind();
                
                
            }


        }

        protected void lbtn_missed_Click(object sender, EventArgs e)
        {
            if (Session["appt_viewstate"].ToString() != "missed")
            {   // Line Below fixes the bug of being on page 2 or later in a viewstate and then changing to another viewstate, causing the indexes to still be there
                // Reset the page to the first
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                lbtn_upcoming.CssClass = "lbtn_inactive";
                lbtn_past.CssClass = "lbtn_inactive";
                lbtn_missed.CssClass = "";
                Session["appt_viewstate"] = "missed";
                listview_appts.DataSource = GetApptsUserMissed();
                listview_appts.DataBind();
            }

        }

        protected void btn_RschOnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // Get the listviewitem from button
            ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;

            // Find the label control
            Label lblDT = (Label)item.FindControl("lbl_c_dt");
            //get the value
            DateTime lblDT_value = Convert.ToDateTime(lblDT.Text.ToString());

            //Find the label control
            Label lblAT = (Label)item.FindControl("lbl_c_at");
            //get the value
            string lblAT_value = lblAT.Text;

            //Find the label control
            Label lblDN = (Label)item.FindControl("lbl_c_dn");
            //get the value
            string lblDN_value = lblDN.Text;

            // lbl_profileName.Text = lblDT_value.ToString();

            Session["selected_appt_date"] = lblDT_value;
            Session["selected_appt_type"] = lblAT_value;
            Response.Redirect("~/RA.aspx");
        }

        protected void btn_CancelOnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // Get the listviewitem from button
            ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;

            // Find the label control
            Label lblDT = (Label)item.FindControl("lbl_c_dt");
            //get the value
            DateTime lblDT_value = Convert.ToDateTime(lblDT.Text.ToString());

            //Find the label control
            Label lblAT = (Label)item.FindControl("lbl_c_at");
            //get the value
            string lblAT_value = lblAT.Text;

            //Find the label control
            Label lblDN = (Label)item.FindControl("lbl_c_dn");
            //get the value
            string lblDN_value = lblDN.Text;

            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            int delete_result = svc_client.DeleteOneAppt(Convert.ToInt32(Session["current_appt_profile"]), lblDT_value);

            if (delete_result == 1)
            {
                // Response.Write("<script>alert('Data deleted successfully')</script>");

                switch (Session["appt_viewstate"])
                {
                    case "upcoming":
                        dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                        listview_appts.DataSource = GetApptsUserUpcoming();
                        listview_appts.DataBind();
                        break;
                    case "past":
                        dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                        listview_appts.DataSource = GetApptsUserPast();
                        listview_appts.DataBind();
                        break;
                    case "missed":
                        dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                        listview_appts.DataSource = GetApptsUserMissed();
                        listview_appts.DataBind();
                        break;

                }


            }
            else
            {
                // Response.Write("<script>alert('Data deleted unsuccessfully')</script>");
                listview_appts.DataSource = GetApptsUserUpcoming();
                listview_appts.DataBind();
            }
        }

        protected void btn_PaymentOnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Payment.aspx");
        }

        protected void listview_appts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}