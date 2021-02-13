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
            if (!IsPostBack)

            {

                string id = Request.QueryString["id"];
                Details eList = new Details();
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                eList = client.GetDetailsById(id);
                tb_name.Text = eList.Name;
                tb_nric.Text = eList.Nric;
                tb_dob.Text = eList.Date_of_birth;
                tb_gender.Text = eList.Gender;
                tb_phone.Text = eList.Phone;
                tb_email.Text = eList.Email;
                tb_address.Text = eList.Address;
                tb_postal.Text = eList.Postal;
            }
        }

        protected void btn_back_click(object sender, EventArgs e)
        {
            Response.Redirect("Patient_view_details.aspx");
        }

        protected void btn_submit_click(object sender, EventArgs e)
        {
            int update;
            string id = Request.QueryString["id"];
            var name = tb_name.Text.ToString();
            var nric = tb_nric.Text.ToString();
            var dob = tb_dob.Text.ToString();
            var gender = tb_gender.Text.ToString();
            var phone = tb_phone.Text.ToString();
            var email = tb_email.Text.ToString();
            var address = tb_address.Text.ToString();
            var postal = tb_postal.Text.ToString();
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            update = client.UpdateDetailsById(id, name, nric, dob, gender, phone, email, address, postal);
            Response.Redirect("Patient_view_details.aspx");
        }
    }

}
