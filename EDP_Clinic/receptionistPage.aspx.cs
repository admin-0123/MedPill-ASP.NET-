using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class employeePage : System.Web.UI.Page
    {
        Service1Client client = new Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {
            imgPfp.Visible = false;
            var email = Session["LoggedIn"].ToString();
            var user = client.GetOneUserByEmail(email);
            lblName.Text = user.Name.ToString();
            var id = user.Id.ToString();
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

        protected void receptionistBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReceptAppts.aspx", false);
        }

        protected void changeinfoBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeInfo.aspx", false);

        }
    }
}