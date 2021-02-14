using System;
using System.Diagnostics;

namespace EDP_Clinic
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                userPageBtn.Visible = false;
                logoutBtn.Visible = false;
                employeePageBtn.Visible = false;
                adminPageBtn.Visible = false;
                receptionistPageBtn.Visible = false;
              
            }
            else
            {
                var role = Session["Role"].ToString();
                if (role == "Patient")
                {
                    receptionistPageBtn.Visible = false;
                    employeePageBtn.Visible = false;
                    loginBtn.Visible = false;
                    adminPageBtn.Visible = false;
                }
                if (role == "Receptionist")
                {
                    employeePageBtn.Visible = false;
                    adminPageBtn.Visible = false;
                    userPageBtn.Visible = false;
                    loginBtn.Visible = false;
                }
                if (role == "Doctor" || role == "Nurse")
                {
                    adminPageBtn.Visible = false;
                    userPageBtn.Visible = false;
                    receptionistPageBtn.Visible = false;
                    loginBtn.Visible = false;
                }
                if ( role == "Admin")
                {
                    employeePageBtn.Visible = false;
                    userPageBtn.Visible = false;
                    receptionistPageBtn.Visible = false;
                    loginBtn.Visible = false;
                }
            }
        }
    }
}