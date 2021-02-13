using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class PatientOverview : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<displayPatient> patientList = new List<displayPatient>();
            patientList = client.DisplayAllPatients().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        protected void ViewPatients_Click(object sender, EventArgs e)
        {
            List<displayPatient> patientList = new List<displayPatient>();
            List<User> userlist = new List<User>();
            patientList = client.DisplayPatientsOnly().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        protected void ViewCaretaker_Click(object sender, EventArgs e)
        {
            List<displayPatient> patientList = new List<displayPatient>();
            List<User> userlist = new List<User>();
            patientList = client.DisplayCaretakers().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        protected void RefreshBtn_Click(object sender, EventArgs e)
        {
            refreshgrid();
        }
        protected void SearchBtn_Click(object sender, EventArgs e)
        {    
            var search = HttpUtility.HtmlEncode(searchtb.Text);
            List<displayPatient> patientList = new List<displayPatient>();
            patientList = client.DisplayAllSearchedPatients(search).ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
        
        public void refreshgrid()
        {
            List<displayPatient> patientList = new List<displayPatient>();
            List<User> userlist = new List<User>();
            patientList = client.DisplayAllPatients().ToList<displayPatient>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }

        protected void ViewReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create_Report.aspx");
        }
    }
}