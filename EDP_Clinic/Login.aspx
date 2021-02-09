<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EDP_Clinic.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css"> 
    </style>
    <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>
    
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="login-card">
    <h1>Log-in</h1><br>
    <form>
      <p>Email</p>
      <asp:TextBox ID="tbemail" runat="server"></asp:TextBox>
&nbsp;</br>
        <p>Password</p>
      <asp:TextBox ID="tbpassword" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;<asp:Label ID="errorMsg" runat="server"></asp:Label>
        </br>
      <asp:Button ID="Button1" runat="server" Text="Submit" class="login login-submit" OnClick="Button1_Click"/>
&nbsp;</form>
  <div class="login-help">
    <a href="Register.aspx">Register</a> • <a href="ForgetPassword.aspx">Forgot Password</a>
  </div>
</div>
   
</asp:Content>