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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Button1.Text = "Awesome";*/
            
        }

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
    }
}