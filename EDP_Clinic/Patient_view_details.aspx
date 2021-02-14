<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient_view_details.aspx.cs" Inherits="EDP_Clinic.Patient_view_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .auto-style1 {
            width: 306px;
        }
        .auto-style2 {
            width: 229px;
        }
        .auto-style3 {
            width: 229px;
            height: 33px;
        }
        .auto-style4 {
            width: 306px;
            height: 33px;
        }
        .auto-style5 {
            height: 33px;
        }
        .auto-style6 {
            width: 229px;
            height: 32px;
        }
        .auto-style7 {
            width: 306px;
            height: 32px;
        }
        .auto-style8 {
            height: 32px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1" style="font-size: x-large; font-weight: bold">Personal Particulars</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">Name:</td>
            <td class="auto-style8">
                <asp:Label ID="Name" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">NRIC:</td>
            <td>
                <asp:Label ID="Nric" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">Date of birth:</td>
            <td>
                <asp:Label ID="dob" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">Gender:</td>
            <td>
                <asp:Label ID="Gender" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">Handphone Number:</td>
            <td>
                <asp:Label ID="Phone" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">Email Address:</td>
            <td>
                <asp:Label ID="Email" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">Address:</td>
            <td class="auto-style8">
                <asp:Label ID="Address" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">Postal Code:</td>
            <td>
                <asp:Label ID="Postal" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style4"></td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="btn_back" runat="server" Text="Back" OnClick="btn_back_click" class="button button3" />
            </td>
            <td>
                <asp:Button ID="btn_update" runat="server" Text="Update" OnClick="btn_update_click" class="button button3" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

