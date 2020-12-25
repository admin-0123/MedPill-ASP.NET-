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
                   <label>6-digit OTP</label>
                   <asp:TextBox ID="OTPTB" runat="server" placeholder="6-digit OTP" CssClass="form-control" Width="200px"></asp:TextBox>
                    <asp:Label ID="OTPError" runat="server"></asp:Label>
                   <br />
                   <br />
                    <asp:Button ID="verifyBtn" runat="server" Text="Verify" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="verifyBtn_Click" />
               </form>
            </div>
       </div>
    </section>
</asp:Content>
