<%@ Page Title="Forget Password" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="EDP_Clinic.ForgetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1 class="mb-5 text-center">Forget Password</h1>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        <div class="mb-4">
            <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbEmail" runat="server" CssClass="form-control" TextMode="Email" required></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" class="btn btn-primary" OnClick="submitBtn_Click" />
        </div>
        <div class="mb-4 text-center">
            <a href="Register.aspx">Register</a> • <a href="Login.aspx">Login</a>
        </div>
    </div>
</asp:Content>
