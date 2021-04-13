using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;

namespace EDP_Clinic
{
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Service1Client client = new Service1Client();

            var code = Request.QueryString["value"];
            Debug.WriteLine(code);
            var email = client.GetEmailbyCode(code);
            client.VerifyOneUser(email);

            Response.Redirect("~/Login.aspx");
        }
    }
}