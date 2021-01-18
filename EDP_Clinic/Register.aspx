<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="EDP_Clinic.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style> 
        .login-card{
            width:450px;
            margin: 50px auto 50px;
        }
        .auto-style1 {
            left: -1px;
            top: 0px;
        }
    </style>
    <link rel='stylesheet' href='http://codepen.io/assets/libs/fullpage/jquery-ui.css'>
    
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="login-card">
    <h1>Register</h1><br>
    
      <p>Email</p>
      <asp:TextBox ID="tbemail" runat="server"></asp:TextBox>
&nbsp;</br>
        <p>Name</p>
      <asp:TextBox ID="tbName" runat="server"></asp:TextBox>
&nbsp;</br>
        <p>Mobile Number</p>
      <asp:TextBox ID="tbMobile" runat="server"></asp:TextBox>
&nbsp;</br>
        <p>Password</p>
      <asp:TextBox ID="tbpassword" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;</br>
        <p>Confirm Password</p>
        <asp:TextBox ID="tbConfirm" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;</br>
      <asp:Button ID="Button1" runat="server" Text="Sign Up" class="login login-submit" OnClick="Button1_Click" CssClass="auto-style1"/>
&nbsp;<asp:Label ID="errorMsg" runat="server"></asp:Label>
&nbsp;<div class="login-help">
    <a href="#">Already have an account ?</a>
  </div>
</div>
   
</asp:Content>