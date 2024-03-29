﻿<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EDP_Clinic.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card" style="width: 400px;">
        <h1 class="title mb-5 text-center">Register</h1>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        <div class="form-group mb-4">
            <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbemail" runat="server" TextMode="Email" CssClass="form-control" required></asp:TextBox>
            <asp:Label ID="emailErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group mb-4">
            <asp:Label ID="nameLbl" runat="server" Text="Name" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbName" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="nameErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group mb-4">
            <asp:Label ID="phoneLbl" runat="server" Text="Phone Number" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbMobile" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="phoneErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group mb-4">
            <asp:Label ID="passwordLbl" runat="server" Text="Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbpassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="passwordErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group mb-5">
            <asp:Label ID="confirmPasswordLbl" runat="server" Text="Re-enter Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbConfirm" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="passwordConfirmErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="mb-4">
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
            <asp:Button ID="RegisterBtn" runat="server" Text="Sign Up" class="btn btn-primary" OnClick="RegisterBtn_Click" />
        </div>
        <div class="mb-4 text-center">
            <p><a href="Login.aspx">Already have an account?</a></p>
        </div>
    </div>
    <!--- Recaptcha --->
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LejmBwaAAAAAIDSwI7BQzo5s3UO3qDlAztog9Uh', { action: 'Submit' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
    </script>
</asp:Content>
