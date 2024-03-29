﻿using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;

namespace EDP_Clinic
{
    public partial class CA_Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["LoggedIn"] == null || Session["current_appt_profile"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                if (Session["current_appt_profile"].ToString() != "nothing")
                {
                    loadSuccessMsg();
                }
            }
        }

        protected void loadSuccessMsg()
        {
            Service1Client svc_client = new Service1Client();
            Dictionary<String, String> apptDetail = (Dictionary<string, string>)Session["successful_appt_details"];

            DateTime dateTimeinput;
            dateTimeinput = Convert.ToDateTime(apptDetail["dateTime"]);
            var appt = svc_client.GetOneAppt(Convert.ToInt32(Session["current_appt_profile"]), dateTimeinput);

            var patient = svc_client.GetOneUser(appt.patientID.ToString());

            var doctor = svc_client.GetOneUser(appt.doctorID.ToString());

            lbl_apptType.Text = $"Appointment Type: {appt.appointmentType}";
            lbl_datetime.Text = $"Appointment Time: {appt.dateTime}";

            if (doctor == null)
            {
                lbl_doctorname.Text = "Doctor: Not assigned yet";
            }

            else
            {
                lbl_doctorname.Text = $"Doctor: {doctor.Name}";
            }

            lbl_patientname.Text = $"Patient: {patient.Name}";

            // Set the Env variables in windows first
            // Get Env values from https://www.twilio.com/console
            // https://www.twilio.com/blog/2017/01/how-to-set-environment-variables.html

            if (!IsPostBack)
            {
                var accountSid = Environment.GetEnvironmentVariable("TWILIO_ACCOUNT_SID");
                var authToken = Environment.GetEnvironmentVariable("TWILIO_AUTH_TOKEN");

                // Comment these out for testing purposes
                // TwilioClient.Init(accountSid, authToken);

                //if (patient.Id != Session["current_appt_profile"].ToString())
                //{
                //    var message = MessageResource.Create(
                //    body: $"You have successfully made an appointment for {patient.Name.Trim()} with MedPill Clinic, report to the clinic on {appt.dateTime.ToString("G")}",
                //    from: new Twilio.Types.PhoneNumber("+14242066417"),
                //    to: new Twilio.Types.PhoneNumber("+6587558054")
                //    );
                //}
                //else
                //{
                //    var message = MessageResource.Create(
                //    body: $"You have successfully made an appointment with MedPill Clinic, report to the clinic on {appt.dateTime.ToString("G")}",
                //    from: new Twilio.Types.PhoneNumber("+14242066417"),
                //    to: new Twilio.Types.PhoneNumber("+6587558054")
                //    );
                //}
            }
        }

        protected void btn_go_pfa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PFA.aspx");
        }

        protected void btn_go_userpage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UserPage.aspx");
        }
    }
}