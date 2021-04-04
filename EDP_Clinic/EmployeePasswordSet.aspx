<%@ Page Title="Set Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePasswordSet.aspx.cs" Inherits="EDP_Clinic.EmployeePasswordSet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1 class="mb-5 text-center">Set Password</h1>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        <div class="mb-4">
            <asp:Label ID="passwordLbl" runat="server" Text="New Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbpassword" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Label ID="passwordLbl2" runat="server" Text="Re-enter Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbpassword2" runat="server" TextMode="Password" CssClass="form-control" required></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="Button1_Click" />
        </div>
        <asp:Label ID="codeLbl" runat="server" Visible="False"></asp:Label>
        <div class="mb-4 text-center">
            <a href="#">Register</a> • <a href="#">Forgot Password</a>
        </div>
    </div>
</asp:Content>
