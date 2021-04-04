using EDP_Clinic.EDP_DBReference;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Net.Mail;
using System.Web;

namespace EDP_Clinic
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)

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
            CultureInfo culture;
            DateTimeStyles styles;
            DateTime dateResult;
            culture = CultureInfo.CreateSpecificCulture("en-US");
            styles = DateTimeStyles.None;

            int numberResult;

            int update;
            string id = Request.QueryString["id"];
            var name = HttpUtility.HtmlEncode(tb_name.Text.ToString());
            var nric = HttpUtility.HtmlEncode(tb_nric.Text.ToString());
            var dob = HttpUtility.HtmlEncode(tb_dob.Text.ToString());
            var gender = HttpUtility.HtmlEncode(tb_gender.Text.ToString());
            var phone = HttpUtility.HtmlEncode(tb_phone.Text.ToString());
            var email = HttpUtility.HtmlEncode(tb_email.Text.ToString());
            var address = HttpUtility.HtmlEncode(tb_address.Text.ToString());
            var postal = HttpUtility.HtmlEncode(tb_postal.Text.ToString());
            if (name == "" || nric == "" || dob == "" || gender == "" || phone == "" || email == "" || address == "" || postal == "")
            {
                lb_error.Text = "Missing Inputs";
            }
            else if (DateTime.TryParse(dob, culture, styles, out dateResult) == false)
            {
                lb_error.Text = "Invaild Date";
                lb_error.ForeColor = Color.Red;
            }
            else if (gender.ToLower() != "male" && gender.ToLower() != "female")
            {
                Debug.WriteLine(gender.ToLower());
                lb_error.Text = "Gender can only be 'male' or 'female'";
                lb_error.ForeColor = Color.Red;
            }
            else if (phone.Length != 8 && int.TryParse(phone, out numberResult))
            {
                lb_error.Text = "Invaild Phone Number";
                lb_error.ForeColor = Color.Red;
            }
            else if (IsValidEmail(email) == false)
            {
                lb_error.Text = "Invaild Email";
                lb_error.ForeColor = Color.Red;
            }
            else
            {
                EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
                update = client.UpdateDetailsById(id, name, nric, dob, gender, phone, email, address, postal);
                Response.Redirect("Patient_view_details.aspx");
            }


        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }


}
