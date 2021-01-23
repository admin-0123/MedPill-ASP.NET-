using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class PatientOverview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();
            List<displayUser> patientList = new List<displayUser>();
            List<User> userlist = new List<User>();
            patientList = client.ShowAllPatients().ToList<displayUser>();
            PatientGridView.Visible = true;
            PatientGridView.DataSource = patientList;
            PatientGridView.DataBind();
        }
    }
}