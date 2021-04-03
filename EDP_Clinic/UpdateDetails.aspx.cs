using EDP_Clinic.EDP_DBReference;
using System;

namespace EDP_Clinic
{
    public partial class Patient_view_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Session["UserRole"].ToString() != "Patient")
                {
                    Response.Redirect("Home.aspx", false);
                }
            }
            string id = "1";
            Details eList = new Details();
            Service1Client client = new Service1Client();
            eList = client.GetDetailsById(id);
            Name.Text = eList.Name;
            Nric.Text = eList.Nric;
            dob.Text = eList.Date_of_birth;
            Gender.Text = eList.Gender;
            Phone.Text = eList.Phone;
            Email.Text = eList.Email;
            Address.Text = eList.Address;
            Postal.Text = eList.Postal;

        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx", false);
        }

        protected void btn_update_click(object sender, EventArgs e)
        {
            string id = "1";
            string url = "Patient_update_details.aspx?id=" + id;
            Response.Redirect(url);
        }
    }
}