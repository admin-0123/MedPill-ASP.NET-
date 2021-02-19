<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient_report.aspx.cs" Inherits="EDP_Clinic.Patient_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 222px;
        }
        .auto-style5 {
            width: 292px;
        }

        .auto-style3 {
            width: 229px;
            height: 33px;
        }
        .auto-style5 {
            height: 33px;
        }
        .button {
            background-color: darkblue;
            border: none;
            color: white;
            padding: 20px;
            text-align: center;
            text-decoration: none;
            display: inline-block;
            font-size: 16px;
            margin: 4px 2px;
            cursor: pointer;
        }

        .button1 {border-radius: 2px;}
        .button2 {border-radius: 4px;}
        .button3 {border-radius: 8px;}
        .button4 {border-radius: 12px;}
        .button5 {border-radius: 50%;}
        .auto-style6 {
            height: 33px;
            width: 229px;
        }
        .auto-style7 {
            height: 33px;
            width: 306px;
        }
        .auto-style8 {
            width: 292px;
            height: 33px;
        }
        .auto-style9 {
            height: 33px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7" ></td>
            <td class="auto-style7" style="font-size: x-large; font-weight: bold">Report Details</td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7"></td>
            <td class="auto-style7">
                </td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">Doctor In Charge:</td>
            <td>
                <asp:DropDownList ID="dp_doctor" runat="server" Width="185px">
                    <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                    <asp:ListItem>Dr Ong</asp:ListItem>
                    <asp:ListItem>Dr Wong</asp:ListItem>
                    <asp:ListItem>Dr Song</asp:ListItem>
                    <asp:ListItem>Dr Long</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">Patient:</td>
            <td>
                <asp:TextBox ID="tb_patient" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style8">Clinic:</td>
            <td class="auto-style9">
                <asp:DropDownList ID="dp_clinic" runat="server" Width="185px">
                    <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                    <asp:ListItem>Medpill</asp:ListItem>
                    <asp:ListItem>Singapore General Hospital</asp:ListItem>
                    <asp:ListItem>Tan Tock Seng Hospital</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">Date of report:</td>
            <td>
                <asp:TextBox ID="tb_date" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">Details:</td>
            <td>
                <asp:TextBox ID="tb_details" runat="server" Height="168px" Width="446px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                <asp:Label ID="lb_error" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style5">
                <asp:Button ID="btn_back" runat="server" Text="Back" class="button button3" OnClick="btn_back_click"/>
            </td>
            <td>
                <asp:Button ID="btn_submit" runat="server" Text="Submit" class="button button3" OnClick="btn_submit_info"/>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
