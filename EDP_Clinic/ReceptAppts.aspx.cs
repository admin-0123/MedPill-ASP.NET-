using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class ReceptAppts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // On initial load of the page, set the session variable for viewstate
            if (Session["LoggedIn"] != null)
            {
                if (Session["UserRole"].ToString() == "Receptionist")
                {
                    if (!IsPostBack)
                    {
                        Session["appt_viewstate_admin"] = "upcoming";
                        Session["appt_viewstate_admin_viewMode"] = "All";

                        profilePfp.Visible = false;
                        //leftArrow_redirect.Visible = false;
                        // On every postback, search for the session, check the current session value of viewstate and display the contents accordingly.
                        // Edit: Shifted the switch statement from page load to here initial page load only as it is causing
                        // System.ArgumentException: Invalid postback or callback argument.  Event validation is enabled using <pages enableEventValidation="true"/> in configuration or <%@ Page EnableEventValidation="true" %> in a page.  For security purposes, this feature verifies that arguments to postback or callback events originate from the server control that originally rendered them.  If the data is valid and expected, use the ClientScriptManager.RegisterForEventValidation method in order to register the postback or callback data for validation.

                        switch (Session["appt_viewstate_admin"])
                        {
                            case "upcoming":
                                if (Session["appt_viewstate_admin_viewMode"].ToString() == "Unassigned")
                                {
                                    listview_appts.DataSource = GetApptsAdminUpcomingUnassigned();
                                    listview_appts.DataBind();
                                }

                                else
                                {
                                    listview_appts.DataSource = GetApptsAdminUpcoming();
                                    listview_appts.DataBind();
                                }
                                lbl_viewMode.Visible = true;
                                ddl_viewMode.Visible = true;
                                break;
                            case "past":
                                listview_appts.DataSource = GetApptsAdminPast();
                                listview_appts.DataBind();
                                lbl_viewMode.Visible = false;
                                ddl_viewMode.Visible = false;
                                break;
                            case "missed":
                                listview_appts.DataSource = GetApptsAdminMissed();
                                listview_appts.DataBind();
                                lbl_viewMode.Visible = false;
                                ddl_viewMode.Visible = false;
                                break;

                        }
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

        // Get All Appts for one user where status is upcoming
        public List<Appointment> GetApptsAdminUpcoming()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            testList = svc_client.GetAllApptAdminUpcoming().ToList<Appointment>();

            List<Appointment> sortedList = new List<Appointment>();

            if (testList == null)
            {
                testList = new List<Appointment>();
            }


            sortedList = testList.OrderBy(x => x.dateTime).ToList();


            return sortedList;
        }


        public List<Appointment> GetApptsAdminUpcomingUnassigned()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            testList = svc_client.GetAllApptAdminUpcoming().ToList<Appointment>();


            if (testList == null)
            {
                testList = new List<Appointment>();
            }

            foreach (var i in testList.ToList())
            {
                if (i.doctorID != 0)
                {
                    testList.Remove(i);
                }
            }

            testList = testList.OrderBy(x => x.dateTime).ToList();

            return testList;
        }

        // Get All Appts for one user where status is past
        public List<Appointment> GetApptsAdminPast()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            testList = svc_client.GetAllApptAdminPast().ToList<Appointment>();

            if (testList == null)
            {
                testList = new List<Appointment>();
            }

            testList = testList.OrderBy(x => x.dateTime).ToList();
            return testList;
        }

        // Get All Appts for one user where status is missed
        public List<Appointment> GetApptsAdminMissed()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            testList = svc_client.GetAllApptAdminMissed().ToList<Appointment>();

            if (testList == null)
            {
                testList = new List<Appointment>();
            }

            testList = testList.OrderBy(x => x.dateTime).ToList();
            return testList;
        }

        // Navigate backwards arrow
        protected void leftArrow_redirect_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/receptionistPage.aspx");
        }

        // Go to Make Appointment Page
        protected void btn_makeAppt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CA_admin.aspx");
        }

        // Method that is called when page change for listview_appts control
        protected void listview_appts_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            //set current page startindex, max rows and rebind to false
            dp_listview_appt.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);

            //rebind List View

            switch (Session["appt_viewstate_admin"])
            {
                case "upcoming":
                    if (Session["appt_viewstate_admin_viewMode"].ToString() == "Unassigned")
                    {
                        listview_appts.DataSource = GetApptsAdminUpcomingUnassigned();
                        listview_appts.DataBind();
                    }

                    else
                    {
                        listview_appts.DataSource = GetApptsAdminUpcoming();
                        listview_appts.DataBind();
                    }

                    break;
                case "past":
                    listview_appts.DataSource = GetApptsAdminPast();
                    listview_appts.DataBind();
                    break;
                case "missed":
                    listview_appts.DataSource = GetApptsAdminMissed();
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

        protected String Convert_ID_To_Name(object id)
        {
            if (Convert.ToInt32(id) == 0)
            {
                return "Unassigned";
            }
            else
            {
                EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
                var user = svc_client.GetOneUser(id.ToString());

                if (user == null)
                {
                    user.Name = "No name found";
                }

                return user.Name.ToString();
            }
        }



        // Link Buttons to change the type of appointment records being displayed
        protected void lbtn_upcoming_Click(object sender, EventArgs e)
        {
            if (Session["appt_viewstate_admin"].ToString() != "upcoming")
            {
                // Line Below fixes the bug of being on page 2 or later in a viewstate and then changing to another viewstate, causing the indexes to still be there
                // Reset the page to the first
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                lbtn_upcoming.CssClass = "";
                lbtn_past.CssClass = "lbtn_inactive";
                lbtn_missed.CssClass = "lbtn_inactive";
                Session["appt_viewstate_admin"] = "upcoming";
                listview_appts.DataSource = GetApptsAdminUpcoming();
                listview_appts.DataBind();
                lbl_viewMode.Visible = true;
                ddl_viewMode.Visible = true;
            }

        }

        protected void lbtn_past_Click(object sender, EventArgs e)
        {
            if (Session["appt_viewstate_admin"].ToString() != "past")
            {
                // Line Below fixes the bug of being on page 2 or later in a viewstate and then changing to another viewstate, causing the indexes to still be there
                // Reset the page to the first
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                lbtn_upcoming.CssClass = "lbtn_inactive";
                lbtn_past.CssClass = "";
                lbtn_missed.CssClass = "lbtn_inactive";
                Session["appt_viewstate_admin"] = "past";
                listview_appts.DataSource = GetApptsAdminPast();
                listview_appts.DataBind();
                lbl_viewMode.Visible = false;
                ddl_viewMode.Visible = false;


            }


        }

        protected void lbtn_missed_Click(object sender, EventArgs e)
        {
            if (Session["appt_viewstate_admin"].ToString() != "missed")
            {
                // Line Below fixes the bug of being on page 2 or later in a viewstate and then changing to another viewstate, causing the indexes to still be there
                // Reset the page to the first
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                lbtn_upcoming.CssClass = "lbtn_inactive";
                lbtn_past.CssClass = "lbtn_inactive";
                lbtn_missed.CssClass = "";
                Session["appt_viewstate_admin"] = "missed";
                listview_appts.DataSource = GetApptsAdminMissed();
                listview_appts.DataBind();
                lbl_viewMode.Visible = false;
                ddl_viewMode.Visible = false;
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

            //Find the label control
            Label lblPID = (Label)item.FindControl("lbl_c_patient_id");
            //get the value
            string lblPID_value = lblPID.Text;


            Session["selected_appt_date"] = lblDT_value;
            Session["selected_appt_type"] = lblAT_value;
            Session["selected_appt_user"] = lblPID_value;
            Response.Redirect("~/RA_admin.aspx");
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


            //Find the label control
            Label lblPID = (Label)item.FindControl("lbl_c_patient_id");
            //get the value
            string lblPID_value = lblPID.Text;

            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            int delete_result = svc_client.DeleteOneAppt(Convert.ToInt32(lblPID_value), lblDT_value);

            if (delete_result == 1)
            {
                // Response.Write("<script>alert('Data deleted successfully')</script>");

                switch (Session["appt_viewstate_admin"])
                {
                    case "upcoming":
                        dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                        if (Session["appt_viewstate_admin_viewMode"].ToString() == "Unassigned")
                        {
                            listview_appts.DataSource = GetApptsAdminUpcomingUnassigned();
                            listview_appts.DataBind();
                        }

                        else
                        {
                            listview_appts.DataSource = GetApptsAdminUpcoming();
                            listview_appts.DataBind();
                        }
                        lbl_viewMode.Visible = true;
                        ddl_viewMode.Visible = true;
                        break;
                    case "past":
                        dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                        listview_appts.DataSource = GetApptsAdminPast();
                        listview_appts.DataBind();
                        lbl_viewMode.Visible = false;
                        ddl_viewMode.Visible = false;
                        break;
                    case "missed":
                        dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                        listview_appts.DataSource = GetApptsAdminMissed();
                        listview_appts.DataBind();
                        lbl_viewMode.Visible = false;
                        ddl_viewMode.Visible = false;
                        break;

                }


            }
            else
            {
                listview_appts.DataSource = GetApptsAdminUpcoming();
                listview_appts.DataBind();
            }
        }

        protected void btn_AdOnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            // Get the listviewitem from button
            ListViewItem item = (ListViewItem)(sender as Control).NamingContainer;

            // Find the label control
            Label lblDT = (Label)item.FindControl("lbl_c_dt");
            //get the value
            DateTime lblDT_value = Convert.ToDateTime(lblDT.Text.ToString());

            //Find the label control
            Label lblDN = (Label)item.FindControl("lbl_c_dn");
            //get the value
            string lblDN_value = lblDN.Text;

            //Find the label control
            Label lblPN = (Label)item.FindControl("lbl_c_patient");
            //get the value
            string lblPN_value = lblPN.Text;


            Session["selected_appt_date"] = lblDT_value;
            Session["doctor_name"] = lblDN_value;
            Session["patient_name"] = lblPN_value;

            Response.Redirect("~/ReceptAssignDoctor.aspx");
        }

        protected void ddl_viewMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_viewMode.SelectedValue == "Unassigned")
            {
                Session["appt_viewstate_admin_viewMode"] = "Unassigned";
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                listview_appts.DataSource = GetApptsAdminUpcomingUnassigned();
                listview_appts.DataBind();
            }

            else
            {
                Session["appt_viewstate_admin_viewMode"] = "All";
                dp_listview_appt.SetPageProperties(0, dp_listview_appt.MaximumRows, false);
                listview_appts.DataSource = GetApptsAdminUpcoming();
                listview_appts.DataBind();

            }
        }
    }
}