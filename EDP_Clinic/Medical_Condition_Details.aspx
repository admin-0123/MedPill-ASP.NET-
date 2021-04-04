<%@ Page Title="Patient Medical Condition Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medical_Condition_Details.aspx.cs" Inherits="EDP_Clinic.Medical_Condition_Details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 300px;
        }
        .auto-style2 {
            width: 300px;
            height: 32px;
        }
        .auto-style3 {
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
        .auto-style4 {
            width: 358px;
        }
        .auto-style5 {
            width: 358px;
            height: 32px;
        }
        .auto-style6 {
            width: 957px;
        }
        .auto-style7 {
            height: 32px;
            width: 957px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Medical Condition</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Name of patient:</td>
            <td class="auto-style6">
                <asp:Label ID="patient" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Name of medical condition:</td>
            <td class="auto-style6">
                <asp:Label ID="condition" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Date of diagnosis:</td>
            <td class="auto-style6">
                <asp:Label ID="date" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Doctor in charge:</td>
            <td class="auto-style6">
                <asp:Label ID="doctor" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style2">Clinic of diagnosis:</td>
            <td class="auto-style7">
                <asp:Label ID="clinic" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style2">Treatment methods:</td>
            <td class="auto-style7">
                <p style="font-family: Helvetica, Arial, sans-serif; margin: 0px 0px 12px; padding: 0px; line-height: 1.5em; color: rgb(17, 17, 17); font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    <asp:Label ID="treatment" runat="server"></asp:Label>
                </p>
            </td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style2">Medical condition description:</td>
            <td class="auto-style7">
                <p style="font-family: Helvetica, Arial, sans-serif; margin: 0px 0px 12px; padding: 0px; line-height: 1.5em; color: rgb(17, 17, 17); font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    <asp:Label ID="description" runat="server"></asp:Label>
                </p>
            </td>
            <td class="auto-style3">
                </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Patient condition:</td>
            <td class="auto-style6">
                <asp:Label ID="patient_condition" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Doctors Comment:</td>
            <td class="auto-style6">
                <asp:Label ID="comments" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="btn_back" runat="server" Text="Back" class="button button3" OnClick="btn_back_click" />
            </td>
            <td class="auto-style6">
                <asp:Button ID="btn_update" runat="server" Text="Update" class="button button3" OnClick="btn_update_click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
