<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RA.aspx.cs" Inherits="EDP_Clinic.RA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <style type="text/css">
        
        table#slotTables tr:nth-child(odd) { background-color: #c9d4cc }
        table#slotTables tr:nth-child(even) { background-color: #fff; }
        .auto-style4 {
            width: 74px;
            height: 44px;
        }
        .auto-style5 {
            height: 44px;
        }
        
        #Btn_LoadMore {
            border-radius:15px;
        }

/*        select::-ms-expand {
            display:none;
        }*/

/*        #Btn_LoadMore {
            background-color:deepskyblue;
            color:white;
        }*/
        .auto-style6 {
            max-width: 100%;
            height: 55px;
            width: 66px;
        }

                    .breadcrumb-item + .breadcrumb-item::before {
        content: ">";
    }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
                    <nav aria-label="breadcrumb">
  <ol class="breadcrumb">
    <li class="breadcrumb-item active">Appointments</li>
    <li class="breadcrumb-item active"> Johnny Lim </li>
          <li class="breadcrumb-item active" aria-current="page"> Upcoming Appointments  </li>
          <li class="breadcrumb-item" aria-current="page"> <a href=""> Reschedule Appointment</a></li>
  </ol>
</nav>
            <h2> Reschedule Appointment </h2>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
        <div class="card-header">
            <div class="row">
                <div class="col-3">
                                        <span class="fa fa-arrow-left" style="height:inherit"></span>
                    &nbsp
                    <img src="assets/images/profileImage_placeholder.png" class="auto-style6"></img>
                </div>
                 <div class="col-9">
                     <p style="vertical-align:middle; margin-top:10px; color:black;"> Johnny Lim </p>
                </div>
            </div>
        </div>
            <p> &nbsp;</p>


            <div>
                Current Appointment details
            </div>
            <div class="card-body row mb-0">
                 <div class="col-4"> Date: </div>
                  <div class="col-8"> 02 Dec 2020 (Wed) </div>
            </div>
                        <div class="card-body row mb-0">
                 <div class="col-4"> Time: </div>
                  <div class="col-8"> 02:30 PM </div>
            </div>
                        <div class="card-body row mb-0">
                 <div class="col-4"> Service Type: </div>
                  <div class="col-8"> Consultation </div>
            </div>
            <p> &nbsp;</p>
                <asp:TextBox ID="TextBox1" runat="server" placeholder ="DD/MM/YYYY"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Search" />
                    <p> &nbsp;</p>
            <span> You can only reschedule between Nov 31  and Jan 31 </span>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="426px" OnDayRender="Calendar1_DayRender">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            <p> &nbsp;</p>

            <div>

            <p class="bg-primary text-light" style="text-align:center;"> Choose New Date & Time </p>
            </div>

        &nbsp;<table style="background-color: #FFFFFF; background-repeat: no-repeat;" id="slotTables" class="w-100">
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="Button2" runat="server" Text="Select" />
                        </td>
                        <td class="auto-style5">02 Dec 2020 (Wed), 11:30 AM</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="Button3" runat="server" Text="Select" />
                        </td>
                        <td class="auto-style5">03 Dec 2020 (Thu), 03:00 PM</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="Button4" runat="server" Text="Select" />
                        </td>
                        <td class="auto-style5">04 Dec 2020 (Fri), 03:30 PM</td>
                    </tr>
                </table>
            <p> 
                &nbsp;</p>
            <p> 
                <asp:Button ID="Btn_LoadMore" runat="server" Text="Load More" Width="1110px" CssClass="btn btn-primary" />
            </p>

           <div> 
               <br />
            </div>
            <div class="row">
                <div class="col-lg-1"></div>
                <div class="col-lg-5">                <asp:Button ID="Button5" runat="server" Text="Next" Width="463px" CssClass="btn btn-primary" /></div>
                <div class="col-lg-5">                <asp:Button ID="Button6" runat="server" Text="Cancel" Width="463px" CssClass="btn btn-link btn-outline-primary" /></div>
                <div class="col-lg-1"></div>
            </div>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
            <p> &nbsp;</p>
    </div>
</asp:Content>
