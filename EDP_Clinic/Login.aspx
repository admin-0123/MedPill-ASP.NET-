<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EDP_Clinic.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1 class="title mb-5">Login</h1>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        <div class="mb-4">
            <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbemail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Label ID="passwordLbl" runat="server" Text="Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbpassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" class="btn btn-primary mb-4" OnClick="submitBtn_Click" />
            <asp:Button ID="phoneBtn" runat="server" Text="Login via Phone" class="btn btn-primary" OnClick="phoneBtn_Click" />
        </div>
        <div class="mb-4 text-center">
            <a href="Register.aspx">Register</a> • <a href="ForgetPassword.aspx">Forgot Password</a>
        </div>
    </div>
</asp:Content>
