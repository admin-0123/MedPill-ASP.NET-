<%@ Page Title="Authentication" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="EDP_Clinic.Authentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="changePaymentInfo" style="height:100vh;">
       <div class="container py-lg-3">
           <h1 class="title mb-4">Verify your Identity</h1>
           <p class="mb-4">Click <a href="/">here</a> to resend your SMS.</p>
            <div class="contact-form">
               <form action="/" method="post">
                   <input type="text" class="form-control" name="OTP" placeholder="6-digit OTP" style="width:200px;"/>
                   <br />
                   <button type="submit" class="btn btn-primary btn-style">Verify</button>
               </form>
            </div>
       </div>
    </section>
</asp:Content>
