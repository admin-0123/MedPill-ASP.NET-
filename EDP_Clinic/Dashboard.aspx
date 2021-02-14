<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="EDP_Clinic.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btn_report" runat="server" OnClick="btn_report_Click" Text="Patient_Report" />
    <br />
    <asp:Button ID="btn_condition" runat="server" OnClick="btn_condition_Click" Text="Patient_Condition" />
    <br />
    <asp:Button ID="btn_particulars" runat="server" OnClick="btn_particulars_Click" Text="Patient_Particulars" />
    <br />
    <asp:Button ID="btn_late" runat="server" OnClick="btn_late_Click" Text="Patient_Late_Payments" />
    <br />
    <asp:Button ID="btn_mc" runat="server" OnClick="btn_mc_Click" Text="Patient_MC" />
</asp:Content>
