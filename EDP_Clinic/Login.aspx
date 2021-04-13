<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EDP_Clinic.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card" style="width: 300px;">
        <h1 class="mb-5 text-center">Login</h1>
        <div class="mb-3">
            <asp:Label ID="errorMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group mb-4">
            <asp:Label ID="emailLbl" runat="server" Text="Email" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbemail" runat="server" CssClass="form-control" TextMode="Email" required></asp:TextBox>
            <asp:Label ID="emailErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="form-group mb-4">
            <asp:Label ID="passwordLbl" runat="server" Text="Password" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="tbpassword" runat="server" CssClass="form-control" TextMode="Password" required></asp:TextBox>
            <asp:Label ID="passwordErrorMsg" runat="server"></asp:Label>
        </div>
        <div class="mb-4">
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
            <asp:Button ID="submitBtn" runat="server" Text="Submit" class="btn btn-primary mb-4" OnClick="submitBtn_Click" />
            <asp:Button ID="phoneBtn" runat="server" Text="Login via Phone" class="btn btn-primary" OnClick="phoneBtn_Click" />
        </div>
        <div class="mb-4 text-center">
            <a href="Register.aspx">Register</a> • <a href="ForgetPassword.aspx">Forgot Password</a>
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
