<%@ Page Title="Receipt" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceiptList.aspx.cs" Inherits="EDP_Clinic.Receipt" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height:100vh;">
          <div class="container py-lg-3" >
              <button class="btn btn-primary btn-style">Home</button>
              <br />
              <br />
              <h1 class="title mb-4">Receipts</h1>
              <div class="card">
              <div class="card-header">
                Receipt No: 1
              </div>
              <div class="card-body">
                <h5 class="card-title">Appointment No: 1</h5>
                <p class="card-text">Payment Status: Paid</p>
                <a href="#" class="btn btn-primary">Go somewhere</a>
              </div>
            </div>
          </div>
        </section>
</asp:Content>
