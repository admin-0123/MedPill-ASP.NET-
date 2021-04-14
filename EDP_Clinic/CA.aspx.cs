using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] != null || Session["current_appt_profile"] != null)
            {
                Service1Client svc_client = new Service1Client();
                User current_user = svc_client.GetOneUser(Session["current_appt_profile"].ToString());
                // For breadcrumb elements
                hl_bc_profileName.Text = current_user.Name;

                Photo current_user_photo_obj = svc_client.GetOnePhoto(current_user.Id);

                //profilePfp.ImageUrl = $"~/assets/images/{current_user_photo_obj.Photo_Resource.Trim()}.jpg";
                var exist = svc_client.CheckPhotoExist(current_user.Id);
                if (exist == 1)
                {
                    var photo = svc_client.GetOnePhoto(current_user.Id);
                    string fileName = photo.Photo_Resource.ToString();
                    var path = "~/UserImg/" + fileName;
                    profilePfp.ImageUrl = path;
                }
                lbl_profileName.Text = current_user.Name;

                tb_startdate_CalendarExtender.StartDate = DateTime.Now.AddDays(1);
                tb_startdate_CalendarExtender.EndDate = DateTime.Now.AddMonths(2);
                if (Session["gv_timeSlot"] == null)
                {
                    Session["startDate"] = DateTime.Now.AddDays(1);
                    DateTime startDate = Convert.ToDateTime(Session["startDate"]);
                    DateTime endDate = DateTime.Now.AddMonths(2);
                    lbl_validDates.Text = $"You may only pick a date between {startDate.Day} {startDate:MMMM} to {endDate.Day} {endDate:MMMM}";
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

                // mySlots = openSlots;

                //gv_timeslots.DataSource = mySlots;
                //gv_timeslots.DataBind();
                /* Code to check the list items, more efficient than for loop, takes less memory, similar to an iterator/generator 
                var enumerator = openSlots.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    System.Diagnostics.Debug.WriteLine("THE LIST OF DATES ARE " + enumerator.Current);
                }
                */
            }

            else
            {
                Response.Redirect("~/Home.aspx", false);
            }
        }

        protected void btn_searchSlot_Click(object sender, EventArgs e)
        {
            var checkdate_bool = DateTime.TryParse(tb_startdate.Text, out _);

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
                        lbl_validDates.Text = $"You may only pick a date between {DateTime.Now.AddDays(1).Day} {DateTime.Now.AddDays(1):MMMM} to {endDate.Day} {endDate:MMMM}";
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
            Service1Client svc_client = new Service1Client();
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
            Service1Client svc_client = new Service1Client();
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
            Response.Redirect("~/PRFA2.aspx");
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
            return result;
        }

        protected void btn_createAppt_Click(object sender, EventArgs e)
        {
            bool validInput = ValidateInput();

            if (validInput)
            {
                // Get the data needed

                int current_profile = Convert.ToInt32(Session["current_appt_profile"]);
                string appointmentType = ddl_apptType.SelectedValue;
                DateTime rb_userinput = Convert.ToDateTime(Request["rb_apptslot"]);
                string status = "upcoming";

                Service1Client svc_client = new Service1Client();
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
                    Response.Redirect("~/CA_Success.aspx");
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
            Response.Redirect("~/PRFA2.aspx");
        }
        /*
        public List<Appointment> GetAppts()
        {
        List<Appointment> testList = new List<Appointment>();
        EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

        testList = svc_client.GetAllApptAdmin().ToList<Appointment>();
        return testList;
        }
        private void RefreshGridView()
        {
        List<Employee> eList = new List<Employee>();
        MyDBServiceReference.Service1Client client = new MyDBServiceReference.Service1Client();
        eList = client.GetAllEmployee().ToList<Employee>();

        // using gridview to bind to the list of employee objects
        gvEmployee.Visible = true;
        gvEmployee.DataSource = eList;
        gvEmployee.DataBind();


        List<Appointment> aList = new List<Appointment>();

        aList = client.GetAllAppt().ToList<Appointment>();

        GridView1.Visible = true;
        GridView1.DataSource = aList;
        GridView1.DataBind();
        }
        */

        /* Code using the default asp calendar control, commented out in case switch back from ajax calendar to this
        // https://forums.asp.net/t/1285637.aspx?CALENDAR+Disable+past+dates

        // Method that decide how to render each cell of the calender
        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            
            // Get the Date of the current cell
            DateTime calenderCellDate = e.Day.Date;

            //System.Diagnostics.Debug.WriteLine(pastday);
            
            // Get current date and time
            DateTime date = DateTime.Now;

            // Set the last selectable date (+2 months from current date)
            DateTime endDate = date.AddMonths(2);

            int year = date.Year;
            int month = date.Month;
            int day = date.Day;

            // Create Date Time variable in a new format
            DateTime today = new DateTime(year, month, day);


            // Restrict selection of past dates
            if (calenderCellDate.CompareTo(today) < 0)
            {
                e.Cell.BackColor = System.Drawing.Color.Gray;
                e.Day.IsSelectable = false;
            }
           
            // Restrict selection of dates that go beyond range of 2months after current date
            if (calenderCellDate.CompareTo(endDate) > 0)
            {
                e.Cell.BackColor = System.Drawing.Color.Red;
                e.Day.IsSelectable = false;
            }

            // Restrict selection of the current date
            if (calenderCellDate == today)
            {
                e.Cell.BackColor = System.Drawing.Color.Blue;
                e.Day.IsSelectable = false;
            }

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            // Automatically fill the textbox value when user picks a date
            TextBox1.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
        }

        */
    }
}