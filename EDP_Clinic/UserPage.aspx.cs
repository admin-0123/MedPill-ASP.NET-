using EDP_Clinic.EDP_DBReference;
using System;

namespace EDP_Clinic
{
    public partial class UserPage : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("~/Login.aspx", false);
            }
            else
            {
                imgPfp.Visible = false;
                string email = Session["LoggedIn"].ToString();
                var user = client.GetOneUserByEmail(email);
                lblName.Text = user.Name.ToString();
                string id = user.Id.ToString();
                var exist = client.CheckPhotoExist(id);
                if (exist == 1)
                {
                    defaultPfp.Visible = false;
                    imgPfp.Visible = true;
                    var photo = client.GetOnePhoto(id);
                    var fileName = photo.Photo_Resource.ToString();
                    var path = "~/UserImg/" + fileName;
                    imgPfp.ImageUrl = path;
                }
            }
        }

        protected void appointmentBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/PFA.aspx", false);
        }

        protected void medicationBtn_Click(object sender, EventArgs e)
        {

        }


        //Hasan's Stuff
        protected void paymentMethodBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CardList.aspx", false);
        }

        protected void paymentHistoryBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReceiptList.aspx", false);
        }

        protected void changeinfoBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ChangeInfo.aspx", false);

        }

        protected void Change_Personal_Info_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Patient_view_details.aspx");
        }

        protected void cgBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/CaregiverSignup.aspx");
        }
    }
}