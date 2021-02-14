﻿using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Patient_Update_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

            {

                string id = Request.QueryString["id"];
                Report eList = new Report();
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                eList = client.GetReportById(id);
                tb_doctor.Text = eList.Dname;
                tb_patient.Text = eList.Pname;
                tb_clinic.Text = eList.Clinic;
                tb_date.Text = eList.Date_of_report;
                tb_details.Text = eList.Details;

            }
            

        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("Create_Report.aspx");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            styles = DateTimeStyles.None;

            int update;
            string id = Request.QueryString["id"];
            var dname = HttpUtility.HtmlEncode(tb_doctor.Text.ToString());
            var pname = HttpUtility.HtmlEncode(tb_patient.Text.ToString());
            var clinic = HttpUtility.HtmlEncode(tb_clinic.Text.ToString());
            var date = HttpUtility.HtmlEncode(tb_date.Text.ToString());
            var details = HttpUtility.HtmlEncode(tb_details.Text.ToString());
            if (dname == "" || pname == "" || clinic == "" || date == "" || details == "")
            {
                lb_error.Text = "Missing Inputs";
            }
            else if (DateTime.TryParse(date, culture, styles, out dateResult) == false)
            {
                lb_error.Text = "Invaild Date";
                lb_error.ForeColor = Color.Red;
            }
            else
            {
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                update = client.UpdateReportById(id, dname, pname, clinic, date, details);
                Response.Redirect("Create Report.aspx?id=" + dname);
            }
            
        }
    }
}