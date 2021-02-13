<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Patient_MC.aspx.cs" Inherits="EDP_Clinic.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
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

        .button1 {
            border-radius: 2px;
        }

        .button2 {
            border-radius: 4px;
        }

        .button3 {
            border-radius: 8px;
        }

        .button4 {
            border-radius: 12px;
        }

        .button5 {
            border-radius: 50%;
        }

        .auto-style2 {
            width: 154px;
        }

        .auto-style3 {
            width: 154px;
            height: 32px;
        }
        .auto-style4 {
            width: 637px;
            height: 32px;
        }
        .auto-style5 {
            height: 32px;
        }
        .auto-style6 {
            width: 399px;
        }
        .auto-style7 {
            width: 637px;
        }
        .auto-style8 {
            width: 399px;
            height: 32px;
        }

        </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table class="w-100">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7" >Medical Certificate</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style7">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style8" style="text-align:right">Reg No: </td>
            <td class="auto-style4">
                <asp:Label ID="Reg_no" runat="server"></asp:Label>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style8" style="text-align:right">Name:</td>
            <td class="auto-style4">
                <asp:Label ID="Name" runat="server"></asp:Label>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6" style="text-align:right">NRIC:</td>
            <td class="auto-style7">
                <asp:Label ID="Nric" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style8" style="text-align:right">Duration of mc:</td>
            <td class="auto-style4">
                <asp:Label ID="Duration" runat="server"></asp:Label>
            </td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6" style="text-align:right">Type of leave granted:</td>
            <td class="auto-style7">
                <asp:Label ID="Type_of_leave" runat="server"></asp:Label>
            </td>
            <td></td>
        </tr>
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style6" style="text-align:right">Clinic Name:</td>
            <td class="auto-style7">
                <asp:Label ID="Clinic" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6" style="text-align:right">Signature:</td>
            <td class="auto-style7">
                <asp:Label ID="Signature" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style6" style="text-align:right">Date:</td>
            <td class="auto-style7">
                <asp:Label ID="Date" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
   
</asp:Content>
