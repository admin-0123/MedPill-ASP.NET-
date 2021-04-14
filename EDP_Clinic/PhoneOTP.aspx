<%@ Page Title="OTP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneOTP.aspx.cs" Inherits="EDP_Clinic.PhoneOTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1 class="mb-5 text-center">Enter OTP</h1>
        <div class="mb-4">
            <asp:Label ID="otpLbl" runat="server" Text="6-digit OTP" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="phoneOTP" runat="server" CssClass=" form-control" required></asp:TextBox>
            <asp:Label ID="errorMsg" runat="server"></asp:Label>
        </div>
        <div class="mb-4">
            <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
            <asp:Button ID="submitBtn" runat="server" Text="Submit" class="btn btn-primary" OnClick="submitBtn_Click" />
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
