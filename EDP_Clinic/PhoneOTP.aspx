<%@ Page Title="OTP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneOTP.aspx.cs" Inherits="EDP_Clinic.PhoneOTP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1 class="mb-5 text-center">Enter OTP</h1>
        <asp:Label ID="errorMsg" runat="server"></asp:Label>
        <div class="mb-4">
            <asp:Label ID="otpLbl" runat="server" Text="6-digit OTP" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="phoneOTP" runat="server" CssClass=" form-control" required></asp:TextBox>
        </div>
        <div class="mb-4">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" class="btn btn-primary" OnClick="submitBtn_Click" />
        </div>
    </div>
</asp:Content>
