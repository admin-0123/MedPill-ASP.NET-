<%@ Page Title="OTP" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PhoneOTP.aspx.cs" Inherits="EDP_Clinic.PhoneOTP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
 
    </style>
    <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>

    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="login-card">
        <h1>Enter OTP</h1>
        <br>
            <form>
                <p>Code</p>
                <asp:TextBox ID="phoneOTP" runat="server"></asp:TextBox>
            &nbsp;</br>

        &nbsp;<asp:Label ID="errorMsg" runat="server"></asp:Label>
        </br>
      <asp:Button ID="Button1" runat="server" Text="Submit" class="login login-submit" OnClick="Button1_Click" />
        &nbsp;</form>
  <div class="login-help">
  </div>
    </div>
</asp:Content>
