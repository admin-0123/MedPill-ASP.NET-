using System;

namespace EDP_Clinic
{
    public partial class _403 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx", false);
        }
    }
}