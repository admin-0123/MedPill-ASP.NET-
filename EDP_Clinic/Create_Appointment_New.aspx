<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create_Appointment_New.aspx.cs" Inherits="EDP_Clinic.Create_Appointment_New" %>
<%@ Register assembly="DayPilot" namespace="DayPilot.Web.Ui" tagprefix="DayPilot" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 74px;
        }
        .auto-style2 {
            width: 74px;
            height: 28px;
        }
        .auto-style3 {
            height: 28px;
        }

        #slotTable:nth-child(odd) { background-color: #c9d4cc }
        #slotTable:nth-child(even) { background-color: #fff; }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
            <p> &nbsp;</p>
            <h1> Appointments</h1>
            <p> &nbsp;</p>
            <p> 
                <asp:TextBox ID="TextBox1" runat="server" placeholder ="DD/MM/YYYY"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Search" />
            </p>
            <p> &nbsp;</p>
            <asp:Calendar ID="Calendar1" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px">
                <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                <OtherMonthDayStyle ForeColor="#999999" />
                <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                <TodayDayStyle BackColor="#CCCCCC" />
            </asp:Calendar>
            <p> &nbsp;</p>
            <p> 
                <asp:Label ID="Label1" runat="server" Text="Available Slots"></asp:Label>
            </p>
            <p> </p>
            <p> 
                <table style="width: 100%; background-color: #FFFFFF; background-repeat: no-repeat;" id="slotTables">
                    <tr>
                        <td class="auto-style2">
                            <asp:RadioButton ID="RadioButton1" runat="server" Text="FSOD" />
                        </td>
                        <td class="auto-style3">02 Dec 2020 (Wed), 11:50 AM</td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:RadioButton ID="RadioButton2" runat="server" />
                        </td>
                        <td class="auto-style3">03 Dec 2020 (Thu), 03:05 PM</td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:RadioButton ID="RadioButton3" runat="server" />
                        </td>
                        <td>04 Dec 2020 (Fri), 03:20 PM</td>
                    </tr>
                </table>
            </p>
            <p> &nbsp;</p>
            <p> 
                <asp:RadioButton ID="RadioButton4" runat="server" />
            </p>
            <p> &nbsp;</p>
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
