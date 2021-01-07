<%@ Page Title="Payment Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentInformation.aspx.cs" Inherits="EDP_Clinic.PaymentInformation" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfo" style="height: 100vh;">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <div class="mb-3">
                <h1 class="title mb-4">Payment Information</h1>
                <h4 class="mb-4">Name on Card: Hasan</h4>
                <h4 class="mb-4">Card Number:
                    <asp:Label ID="cardNumberText" runat="server"></asp:Label></h4>
                <h4 class="mb-4">Card Expiry: 12/2020</h4>
                <h4 class="mb-4">CVV Number: 0123</h4>
            </div>
            <div class="row">
                <div class="col-md-8"></div>
                <div class="col-md-2">
                    <asp:Button ID="deleteBtn" runat="server" Text="Delete" CssClass="btn btn-primary btn-style" OnClick="deleteBtn_Click" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="updateBtn" runat="server" Text="Update" CssClass="btn btn-primary btn-style" OnClick="updateBtn_Click" />
                </div>
            </div>
            <%--              <button class="btn btn-primary btn-style mr-5">delete
              </button>
              <button class="btn btn-primary btn-style ml-5">update
              </button>--%>
        </div>
    </section>
</asp:Content>
