﻿using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace EDP_Clinic
{
    public partial class CA_admin_Success : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null || Session["admin_userInput"] == null)
            {
                Response.Redirect("~/Home.aspx");
            }
            else
            {
                if (Session["admin_userInput"].ToString() != "nothing")
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
            var appt = svc_client.GetOneAppt(Convert.ToInt32(Session["admin_userInput"]), dateTimeinput);

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

                TwilioClient.Init(accountSid, authToken);

                if (patient.Id == Session["admin_userInput"].ToString())
                {
                    var message = MessageResource.Create(
                    body: $"Our receptionist has booked an appointment for you. Report to the clinic on {appt.dateTime:G}",
                    from: new Twilio.Types.PhoneNumber("+14242066417"),
                    to: new Twilio.Types.PhoneNumber("+6587558054")
                    );
                }
            }
        }

        protected void btn_go_pfa_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReceptAppts.aspx");
        }

        protected void btn_go_userpage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/receptionistPage.aspx");
        }
    }
}