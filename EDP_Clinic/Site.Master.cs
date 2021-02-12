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
            }
            else
            {
                loginBtn.Visible = false;
            }
        }
    }
}