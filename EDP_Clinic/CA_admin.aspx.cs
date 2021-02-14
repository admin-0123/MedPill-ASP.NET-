using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class CA_admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null)
            {
                if (Session["UserRole"].ToString() == "Receptionist")
                {



                    EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
                    if (!IsPostBack)
                    {
                        Session["admin_userInput"] = "nothing";
                    }


                    tb_startdate_CalendarExtender.StartDate = DateTime.Now.AddDays(1);
                    tb_startdate_CalendarExtender.EndDate = DateTime.Now.AddMonths(2);
                    if (Session["gv_timeSlot"] == null)
                    {
                        Session["startDate"] = DateTime.Now.AddDays(1);
                        DateTime startDate = Convert.ToDateTime(Session["startDate"]);
                        DateTime endDate = DateTime.Now.AddMonths(2);
                        lbl_validDates.Text = $"You may only pick a date between {startDate.Day} {startDate.ToString("MMMM")} to {endDate.Day} {endDate.ToString("MMMM")}";
                        Session["gv_timeSlot"] = "Testing";

                        /*               List<DateTime> openSlots = new List<DateTime>();
                                       for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
                                       {
                                           dt = new DateTime(dt.Year, dt.Month, dt.Day, 9, 00, 00);

                                           while (dt.Hour != 17)
                                           {
                                               // Query from appointment table and check if timeslot alr exist (to be added)
                                               openSlots.Add(dt);
                                               dt = dt.AddMinutes(30);
                                           }


                                       }*/

                        gv_timeslots.Visible = true;
                        gv_timeslots.DataSource = Onload_Retrieve_Available_Appts();
                        gv_timeslots.DataBind();

                    }

                    else
                    {
                        gv_timeslots.Visible = true;
                        gv_timeslots.DataSource = Search_AvailableAppts();
                        gv_timeslots.DataBind();
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

        protected void btn_searchSlot_Click(object sender, EventArgs e)
        {

            DateTime checkdate_input;
            var checkdate_bool = DateTime.TryParse(tb_startdate.Text, out checkdate_input);

            // if input is a valid date, run the code block
            if (checkdate_bool != false)
            {
                if (Convert.ToDateTime(tb_startdate.Text) < DateTime.Now)
                {
                    Session["startDate"] = DateTime.Now.AddDays(1);
                    lbl_validDates.Text = $"Invalid past date searched";
                    lbl_validDates.ForeColor = Color.Red;
                }

                else
                {
                    Session["startDate"] = Convert.ToDateTime(tb_startdate.Text);
                    gv_timeslots.DataSource = Search_AvailableAppts();
                    gv_timeslots.DataBind();

                    DateTime startDate = Convert.ToDateTime(Session["startDate"]);
                    DateTime endDate = DateTime.Now.AddMonths(2);


                    if (startDate < endDate)
                    {
                        //lbl_validDates.Text = $"You may only pick a date between {startDate.Day} {startDate.ToString("MMMM")} to {endDate.Day} {endDate.ToString("MMMM")}";
                        lbl_validDates.Text = $"You may only pick a date between {DateTime.Now.AddDays(1).Day} {DateTime.Now.AddDays(1).ToString("MMMM")} to {endDate.Day} {endDate.ToString("MMMM")}";
                        lbl_validDates.ForeColor = Color.Black;
                    }

                    else
                    {
                        lbl_validDates.Text = $"Sorry, you can't enter a date later than two months of the current day";
                        lbl_validDates.ForeColor = Color.Red;
                    }
                }
            }


        }

        protected void gv_timeslots_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gv_timeslots_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_timeslots.PageIndex = e.NewPageIndex;
            gv_timeslots.DataSource = Search_AvailableAppts();
            gv_timeslots.DataBind();
        }

        // Method to retrieve available appointments on first load
        public List<DateTime> Onload_Retrieve_Available_Appts()
        {

            List<DateTime> openSlots = new List<DateTime>();
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime endDate = DateTime.Now.AddMonths(2);
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            List<Appointment> Current_ApptList = svc_client.GetAllApptAdmin().ToList();
            bool matching_appt_record = false;

            // Loop through each day
            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, 9, 00, 00);

                // Loop through the time until it reaches 5pm
                while (dt.Hour != 17)
                {
                    // Query from appointment table and check if timeslot alr exist (to be added)
                    // Loop through every appt in DB for matches
                    foreach (var booked_appt in Current_ApptList)
                    {
                        if (dt == Convert.ToDateTime(booked_appt.dateTime))
                        {
                            //System.Diagnostics.Debug.WriteLine("Booked timeslot found");
                            //System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(booked_appt.dateTime));
                            matching_appt_record = true;
                        }

                    }
                    // If match is found, skip and reset the check counter
                    if (matching_appt_record == true)
                    {
                        matching_appt_record = false;
                    }

                    else
                    {
                        openSlots.Add(dt);
                    }
                    dt = dt.AddMinutes(30);
                }


            }

            return openSlots;
        }

        public List<DateTime> Search_AvailableAppts()
        {

            List<DateTime> openSlots = new List<DateTime>();
            DateTime startDate = Convert.ToDateTime(Session["startDate"]);
            DateTime endDate = DateTime.Now.AddMonths(2);
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            List<Appointment> Current_ApptList = svc_client.GetAllApptAdmin().ToList();
            bool matching_appt_record = false;

            // Loop through each day
            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, 9, 00, 00);

                // Loop through the time until it reaches 5pm
                while (dt.Hour != 17)
                {
                    // Query from appointment table and check if timeslot alr exist (to be added)
                    // Loop through every appt in DB for matches
                    foreach (var booked_appt in Current_ApptList)
                    {
                        if (dt == Convert.ToDateTime(booked_appt.dateTime))
                        {
                            //System.Diagnostics.Debug.WriteLine("Booked timeslot found");
                            //System.Diagnostics.Debug.WriteLine(Convert.ToDateTime(booked_appt.dateTime));
                            matching_appt_record = true;
                        }

                    }
                    // If match is found, skip and reset the check counter
                    if (matching_appt_record == true)
                    {
                        matching_appt_record = false;
                    }

                    else
                    {
                        openSlots.Add(dt);
                    }
                    dt = dt.AddMinutes(30);
                }


            }

            return openSlots;
        }

        protected void leftArrow_redirect_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/ReceptAppts.aspx");
        }


        private bool ValidateInput()
        {
            bool result = true;

            // If radio button no input
            if (Request["rb_apptslot"] == null)
            {
                result = false;
                lbl_error_make_appt.ForeColor = Color.Red;
                lbl_error_make_appt.Text = "You did not select an appointment timeslot";
            }

            else if (Session["admin_userInput"].ToString() == "nothing" )
            {
                result = false;
                lbl_error_make_appt.ForeColor = Color.Red;
                lbl_error_make_appt.Text = "You did not search an actual user";
            }

            return result;

        }

        protected void btn_createAppt_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();

            if (validInput)
            {
                // Get the data needed

                int current_profile = Convert.ToInt32(Session["admin_userInput"]);
                string appointmentType = ddl_apptType.SelectedValue;
                DateTime rb_userinput = Convert.ToDateTime(Request["rb_apptslot"]);
                string status = "upcoming";

                EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
                int insert_result = svc_client.CreateAppointment(current_profile, appointmentType, rb_userinput, status);
                if (insert_result == 1)
                {

                    lbl_error_make_appt.ForeColor = Color.Green;
                    lbl_error_make_appt.Text = "Appointment Made Successfully!";
                    gv_timeslots.DataSource = Search_AvailableAppts();
                    gv_timeslots.DataBind();

                    var appt_success_dict = new Dictionary<string, string>(){
    {"appointmentType", appointmentType.ToString()},
    {"dateTime", rb_userinput.ToString()},
    {"status", status.ToString() }
};
                    Session["successful_appt_details"] = appt_success_dict;
                    Response.Redirect("~/CA_admin_Success.aspx");
                }
                else
                {
                    lbl_error_make_appt.ForeColor = Color.Red;
                    lbl_error_make_appt.Text = "Booking failed, exit the page and try again.";
                    gv_timeslots.DataSource = Search_AvailableAppts();
                    gv_timeslots.DataBind();
                }



            }
        }

        protected void btn_cancelAppt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReceptAppts.aspx");
        }

        protected void btn_searchUser_Click(object sender, EventArgs e)
        {
            var userInput = tb_searchUser.Text.Trim();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            var userObj = svc_client.GetOneUserByPhoneNo(userInput);


            if (userObj != null)
            {
                Session["admin_userInput"] = userObj.Id;
                lbl_searchUserResult.Text = $"Successfully found user {userObj.Name} with email address of {userObj.Email}";
                lbl_searchUserResult.ForeColor = Color.Black;
                var exist = svc_client.CheckPhotoExist(Session["admin_userInput"].ToString());
                if (exist == 1)
                {
                var photo = svc_client.GetOnePhoto(Session["admin_userInput"].ToString());
                var fileName = photo.Photo_Resource.ToString();
                var path = "~/UserImg/" + fileName;
                profilePfp.ImageUrl = path;
                lbl_profileName.Text = userObj.Name;
                }
            }

            else
            {
                Session["admin_userInput"] = "nothing";
                lbl_searchUserResult.Text = $"Failed to find a user of that phone number";
                lbl_searchUserResult.ForeColor = Color.Red;
                profilePfp.ImageUrl = "~/assets/images/pfp_placeholder.png";
                lbl_profileName.Text = "";
            }

        }
    }
}