using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EDP_DBReference.Service1Client svc_client = new EDP_DBReference.Service1Client();
            User current_user = svc_client.GetOneUser(Convert.ToInt32(Session["UserID"]));
            // For breadcrumb elements


            ListView1.DataSource = GetApptsUser();
            ListView1.DataBind();
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

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e) {
            DataPager dp = (DataPager)ListView1.FindControl("DataPager1");
            dp.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            ListView1.DataSource = GetApptsUser();
            ListView1.DataBind();
        }
    }
}