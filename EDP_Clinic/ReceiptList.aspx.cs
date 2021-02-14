using EDP_Clinic.EDP_DBReference;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrintNodeNet;
using System.Net.Http;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Http.Headers;

namespace EDP_Clinic
{
    public partial class ReceiptList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Checks user session
            if (Session["LoggedIn"] != null && Session["AuthToken"] != null && Request.Cookies["AuthToken"] != null)
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
            string userID = Session["LoggedIn"].ToString().Trim();

            List<Receipt> repList = new List<Receipt>();
            Service1Client client = new Service1Client();
            repList = client.SelectAllReceipts(userID).ToList();

            receiptListView.DataSource = repList;
            receiptListView.Visible = true;

            if (repList.Count == 0 || repList == null)
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

        protected void receiptListView_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            //Checks if button clicked is view more button
            if (String.Equals(e.CommandName, "viewMore"))
            {
                string userID = Session["LoggedIn"].ToString().Trim();
                string uniqueIdentifier = e.CommandArgument.ToString().Trim();
                Service1Client client = new Service1Client();
                Receipt rep = client.SelectByReceiptID(userID, uniqueIdentifier);
                string receiptLink = rep.ReceiptLink.ToString().Trim();
                Response.Redirect(receiptLink, false);
            }
            else if (String.Equals(e.CommandName, "printReceipt"))
            {
                //var testing = PrintNodeAuthenticationType.BasicAuth;
                //PrintNodeConfiguration.ApiKey = "DGjrFiPUgRwFrGqlSEJjGntiRj-DHjoqOxXeRX7RV-o";
                //Debug.WriteLine(testing);
                ////var testing2 = PrintNodeComputer;
                //var printingType = PrintNodeContentType.raw_uri;
                ////var testing3 = PrintNodePrinter.Id;

                //PrintNodeComputer computer = new PrintNodeComputer();

                
                ////PrintNodePrintJobAuthentication.
                ////PrintNodeRequestOptions;
                //var type = PrintNodeNet.PrintNodeConfiguration.ApiKey;
                //PrintNodeCredentials cre = new PrintNodeCredentials();
                //Debug.WriteLine(cre.Pass);
                //Debug.WriteLine(cre.User);
                //Debug.WriteLine(type);
                //using (var httpClient = new HttpClient())
                //{
                //    using (var request = new HttpRequestMessage(new HttpMethod("GET"), "https://api.printnode.com/whoami"))
                //    {
                //        var base64authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("DGjrFiPUgRwFrGqlSEJjGntiRj-DHjoqOxXeRX7RV-o"));
                //        request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64authorization}");

                //        var response = httpClient.GetAsync(request);
                //        var testing2 = response.ToString();
                //        Debug.WriteLine(response.ToString());
                //    }
                //}
                // Create a request for the URL.
                //WebRequest request = WebRequest.Create(
                //  "https://api.printnode.com/whoami");
                //// If required by the server, set the credentials.
                //request.Credentials = CredentialCache.DefaultCredentials;
                //request.Method = "GET";
                ////Base 64
                ////REdqckZpUFVnUndGckdxbFNFSmpHbnRpUmotREhqb3FPeFhlUlg3UlYtbw==
                //request.Headers.Add("Authorization", "Basic " + "REdqckZpUFVnUndGckdxbFNFSmpHbnRpUmotREhqb3FPeFhlUlg3UlYtbw");
                ////request.Headers["Authorization"] = "DGjrFiPUgRwFrGqlSEJjGntiRj-DHjoqOxXeRX7RV-o";
                //request.ContentType = "application/json";

                //// Get the response.

                //WebResponse response = request.GetResponse();

            }
            else if (String.Equals(e.CommandName, "downloadReceipt"))
            {
                //using (var client = new WebClient())
                //{
                //    client.DownloadFile("https://pay.stripe.com/receipts/", "acct_1HveuKAVRV4JC5fk/ch_1IIbzrAVRV4JC5fkguWPM0CF/rcpt_IuQrRNFAPkLyCK19cQlB497Z4i67HB3");
                //}
                //Debug.WriteLine("Downloading Receipt");
            }
        }
    }
}