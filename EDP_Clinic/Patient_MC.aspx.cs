using EDP_Clinic.EDP_DBReference;
using System;

namespace EDP_Clinic
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Session["UserRole"].ToString() != "Doctor" && Session["UserRole"].ToString() != "Patient")
                {
                    Response.Redirect("Home.aspx", false);
                }
            }
            string x = "1";
            Patient_MC eList = new Patient_MC();
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            eList = client.GetPatient_MCById(x);
            Reg_no.Text = eList.Reg_no;
            Name.Text = eList.Name;
            Nric.Text = eList.Nric;
            Duration.Text = eList.Duration;
            Type_of_leave.Text = eList.Type_of_leave;
            Clinic.Text = eList.Clinic;
            Signature.Text = eList.Signature;
            Date.Text = eList.Date;

        }

    }
}