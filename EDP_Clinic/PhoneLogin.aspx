<%@ Page Title="Phone Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneLogin.aspx.cs" Inherits="EDP_Clinic.PhoneLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1 class="title mb-5">Phone Login</h1>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        <div class="mb-4">
            <asp:Label ID="phoneLbl" runat="server" Text="Phone Number" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbPhoneNo" runat="server"></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Button ID="Button1" runat="server" Text="Submit" class="btn btn-primary" OnClick="Button1_Click" />
        </div>
        <div class="mb-4 text-center">
            <a href="Register.aspx">Register</a> • <a href="Login.aspx">Login</a>
        </div>
    </div>
</asp:Content>
