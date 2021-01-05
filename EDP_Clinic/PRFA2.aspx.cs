using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class PRFA2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_cancel_click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "showModal();", true);
        }

        public List<Appointment> GetApptsUser()
        {
            List<Appointment> testList = new List<Appointment>();
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();

            System.Diagnostics.Debug.WriteLine("THE SESSION VALUE IS " + Session["UserID"]);
            testList = svc_client.GetAllApptUser(Convert.ToInt32(Session["UserID"].ToString())).ToList<Appointment>();
            
            if (testList == null)
            {
                testList = new List<Appointment>();
            }
/*            foreach(var i in testList)
            {
                System.Diagnostics.Debug.WriteLine("Foo");
            }*/
            return testList;
        }
    }
}