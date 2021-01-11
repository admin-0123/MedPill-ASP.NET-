using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        public List<DateTime> mySlots;
        public DateTime startDate = DateTime.Now;
        public DateTime endDate = DateTime.Now.AddMonths(2);
        protected void Page_Load(object sender, EventArgs e)
        {

            // Set the start and end range of selectable dates
            tb_startdate_CalendarExtender.StartDate = startDate;
            tb_startdate_CalendarExtender.EndDate = endDate;

            // Tells the user the available selectable dates to search for slots

            lbl_validDates.Text = $"You may only pick a date between {startDate.Day} {startDate.ToString("MMMM")} to {endDate.Day} {endDate.ToString("MMMM")}";

            // Code block below to generate a list of available appointment timeslots 

            var openSlots = new List<DateTime>();

            for (var dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                dt = new DateTime(dt.Year, dt.Month, dt.Day, 9, 00, 00);

                while (dt.Hour != 17) 
                {
                    // Query from appointment table and check if timeslot alr exist (to be added)
                    openSlots.Add(dt);
                    dt = dt.AddMinutes(30);
                }


            }

            mySlots = openSlots;

           
            /* Code to check the list items, more efficient than for loop, takes less memory, similar to an iterator/generator 
            var enumerator = openSlots.GetEnumerator();
            while (enumerator.MoveNext())
            {
                System.Diagnostics.Debug.WriteLine("THE LIST OF DATES ARE " + enumerator.Current);
            }
            */

           
        }



        protected void btn_searchSlot_Click(object sender, EventArgs e)
        {
            startDate = Convert.ToDateTime(tb_startdate.Text.ToString());

        }





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