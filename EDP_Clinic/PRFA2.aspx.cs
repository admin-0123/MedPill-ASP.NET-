using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            }
            
            // Search for the current profile selected and set the necessary contents like profileName.. etc
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            User current_user = svc_client.GetOneUser(Convert.ToInt32(Session["current_appt_profile"]));
            // For breadcrumb elements
            hl_bc_profileName.Text = current_user.Name;
            //
            profilePfp.ImageUrl = $"~/assets/images/{current_user.Photo.Trim()}.jpg";
            lbl_profileName.Text = current_user.Name;

            //repeater_appts.DataSource = GetApptsUser();
            //repeater_appts.DataBind();

            // On every postback, search for the session, check the current session value of viewstate and display the contents accordingly
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

        protected void btn_cancel_click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }


        // Get All Appts for one user regardless of the status
        public List<Appointment> GetApptsUser()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
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

            System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
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

            System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
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

            System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
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
            {
                lbtn_upcoming.CssClass = "lbtn_inactive";
                lbtn_past.CssClass = "lbtn_inactive";
                lbtn_missed.CssClass = "";
                Session["appt_viewstate"] = "missed";
                listview_appts.DataSource = GetApptsUserMissed();
                listview_appts.DataBind();
            }

        }
    }
}