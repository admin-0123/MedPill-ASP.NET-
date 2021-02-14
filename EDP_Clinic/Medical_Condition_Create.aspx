<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medical_Condition_Create.aspx.cs" Inherits="EDP_Clinic.Medical_Condition_Create" %>
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
            <td class="auto-style5"></td>
            <td class="auto-style2">Name of patient:</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_patient" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3"></td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Name of medical condition:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_med_condition" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Date of diagnosis:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_date" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Doctor in charge:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_doctor" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style2">Clinic of diagnosis:</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_clinic" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style2">Treatment methods:</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_treatment" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style2">Medical condition description:</td>
            <td class="auto-style7">
                <asp:TextBox ID="tb_condition_desc" runat="server"></asp:TextBox>
            </td>
            <td class="auto-style3">
                </td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Patient condition:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_patient_condition" runat="server"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style1">Doctors Comment:</td>
            <td class="auto-style6">
                <asp:TextBox ID="tb_comments" runat="server"></asp:TextBox>
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
                <asp:Button ID="btn_update" runat="server" Text="Submit" class="button button3" OnClick="btn_submit_click" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

