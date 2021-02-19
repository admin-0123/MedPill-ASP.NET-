using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Patient_Medical_Condition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoggedIn"] == null)
            {
                Response.Redirect("Login.aspx", false);
            }
            else
            {
                if (Session["UserRole"].ToString() != "Doctor" && Session["UserRole"].ToString() != "Nurse")
                {
                    Response.Redirect("Home.aspx", false);
                }
            }
        }
        protected void gv_medical_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RefreshGridView(0);
                gv_medical.DataBind();
            }

            
        }
        private void RefreshGridView(int pageNumber)
        {
            List<Medical_Condition> eList = new List<Medical_Condition>();
            EDP_DBReference.Service1Client client = new EDP_DBReference.Service1Client();
            eList = client.GetAllMedicalCondition().ToList<Medical_Condition>();

            // using gridview to bind to the list of employee objects
            gv_medical.PageIndex = pageNumber;
            gv_medical.Visible = true;
            gv_medical.DataSource = eList;
            

        }
        protected void gv_medical_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gv_medical.PageIndex = e.NewPageIndex;
            Debug.WriteLine("Yes " + gv_medical.PageIndex);
            RefreshGridView(gv_medical.PageIndex);
            gv_medical.DataBind();
        }

       

        protected void gv_medical_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "editing")
            {
                // Convert the row index stored in the CommandArgument
                // property to an Integer.
                int index = Convert.ToInt32(e.CommandArgument);

                GridViewRow selectedRow = gv_medical.Rows[index - 1];
                string id = selectedRow.Cells[0].Text;

                string url = "Medical_Condition_Details.aspx?id=" + id;
                Response.Redirect(url);

            }
        }

        protected void btn_submit_add(object sender, EventArgs e)
        {
            Response.Redirect("Medical_Condition_Create.aspx");
        }
    }
}