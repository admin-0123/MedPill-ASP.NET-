﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class _400 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void goHomeBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx", false);
        }
    }
}