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
    public partial class Verify : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();

        protected void Page_Load(object sender, EventArgs e)
        {
            var code = Request.QueryString["value"];
            Debug.WriteLine(code);
            var email = client.GetEmailbyCode(code);
            client.VerifyOneUser(email);
            Response.Redirect("Login.aspx");
        }
    }
}