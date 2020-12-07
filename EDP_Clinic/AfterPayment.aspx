<%@ Page Title="Thank You" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AfterPayment.aspx.cs" Inherits="EDP_Clinic.AfterPayment" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height:100vh;">
          <div class="container py-lg-3" >
              <button class="btn btn-primary btn-style">Home
              </button>
              <br />
              <br />
              <h1 class="title mb-4 align-center"style="text-align:center;">Thank You</h1>
              <p class="mb-4" style="text-align:center;">You have now completed your transaction. You can continue by checking out your latest receipts.</p>
              <br />
              <div style="display: flex; justify-content: center;">
              <button class="btn btn-primary btn-style">Check Latest Receipts
              </button></div>
             </div>
    </section>
</asp:Content>
