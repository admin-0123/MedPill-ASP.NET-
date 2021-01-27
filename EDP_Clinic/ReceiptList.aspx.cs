﻿using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EDP_Clinic
{
    public partial class Receipt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Login"] = "someone@example.com";

            string guidToken = Guid.NewGuid().ToString();
            Session["AuthToken"] = guidToken;
            HttpCookie AuthToken = new HttpCookie("AuthToken");
            AuthToken.Value = guidToken;
            Response.Cookies.Add(AuthToken);


            //Checks user session
            if (Session["Login"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
            {
                if (!Session["AuthToken"].ToString().Equals(Request.Cookies["AuthToken"].Value))
                {
                    Response.Redirect("Login.aspx", false);
                }
                else
                {
                    Debug.WriteLine("Currently at receiptList page");
                }
            }
            //No credentials at all
            else
            {
                Response.Redirect("Login.aspx", false);
            }
        }

        protected void getReceiptList()
        {
            List<CardInfo> cifList = new List<CardInfo>();
            Service1Client client = new Service1Client();
            cifList = client.GetAllCards().ToList<CardInfo>();

            receiptListView.DataSource = cifList;
            receiptListView.Visible = true;

            if(cifList.Count == 0 || cifList == null)
            {
                receiptListPager.Visible = false;
            }
            else
            {
                receiptListPager.Visible = true;
            }
        }

        //Rename datapager 1 to receiptListPager
        protected void receiptListPager_PreRender(object sender, EventArgs e)
        {
            getReceiptList();
            receiptListView.DataBind();
        }

        protected void backBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("UserPage.aspx", false);
        }
    }
}