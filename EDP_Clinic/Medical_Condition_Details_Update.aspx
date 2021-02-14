<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medical_Condition_Details_Update.aspx.cs" Inherits="EDP_Clinic.Medical_Condition_Details_Update" %>
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
        .auto-style7 {
            width: 300px;
            height: 62px;
        }
        .auto-style8 {
            height: 62px;
        }
        .auto-style9 {
            width: 945px;
        }
        .auto-style10 {
            height: 32px;
            width: 945px;
        }
        .auto-style11 {
            height: 62px;
            width: 945px;
        }
        .auto-style12 {
            width: 353px;
        }
        .auto-style13 {
            width: 353px;
            height: 32px;
        }
        .auto-style14 {
            width: 353px;
            height: 62px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">Medical Condition Update</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">Name of patient:</td>
            <td class="auto-style9">
                <asp:Label ID="patient" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">Name of medical condition:</td>
            <td class="auto-style9">
                <asp:Label ID="condition" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">Date of diagnosis:</td>
            <td class="auto-style9">
                <asp:Label ID="date" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">Doctor in charge:</td>
            <td class="auto-style9">
                <asp:Label ID="doctor" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style2">Clinic of diagnosis:</td>
            <td class="auto-style10">
                <asp:Label ID="clinic" runat="server"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13">&nbsp;</td>
            <td class="auto-style2">Treatment methods:</td>
            <td class="auto-style10">
                <p style="font-family: Helvetica, Arial, sans-serif; margin: 0px 0px 12px; padding: 0px; line-height: 1.5em; color: rgb(17, 17, 17); font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    <asp:Label ID="treatment" runat="server"></asp:Label>
                </p>
            </td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style13"></td>
            <td class="auto-style2">Medical condition description:</td>
            <td class="auto-style10">
                <p style="font-family: Helvetica, Arial, sans-serif; margin: 0px 0px 12px; padding: 0px; line-height: 1.5em; color: rgb(17, 17, 17); font-size: 16px; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; font-weight: 400; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    <asp:Label ID="description" runat="server"></asp:Label>
                </p>
            </td>
            <td class="auto-style3">
                </td>
        </tr>
        <tr>
            <td class="auto-style14"></td>
            <td class="auto-style7">Patient condition:</td>
            <td class="auto-style11">
                <asp:TextBox ID="tb_patient_condition" runat="server" Height="109px" Width="541px"></asp:TextBox>
            </td>
            <td class="auto-style8"></td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">Doctors Comment:</td>
            <td class="auto-style9">
                <asp:TextBox ID="tb_comments" runat="server" Height="166px" Width="540px"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style12">
                &nbsp;</td>
            <td class="auto-style1">
                <asp:Button ID="btn_back" runat="server" Text="Back" class="button button3" OnClick="btn_back_click" />
            </td>
            <td class="auto-style9">
                <asp:Button ID="btn_update" runat="server" Text="Update" class="button button3" OnClick="btn_update_click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

