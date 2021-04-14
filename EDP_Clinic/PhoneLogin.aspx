<%@ Page Title="Phone Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneLogin.aspx.cs" Inherits="EDP_Clinic.PhoneLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card" style="width: 300px;">
        <h1 class="mb-5 text-center">Phone Login</h1>
        <div class="mb-4">
            <asp:Label ID="phoneLbl" runat="server" Text="Phone Number" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbPhoneNo" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="phoneErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="mb-4">
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
            <asp:Button ID="SubmitBtn" runat="server" Text="Submit" class="btn btn-primary" OnClick="SubmitBtn_Click" />
        </div>
        <div class="mb-4 text-center">
            <a href="Register.aspx">Register</a> • <a href="Login.aspx">Login</a>
        </div>
    </div>
</asp:Content>
