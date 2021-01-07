<%@ Page Title="Deleted Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentInfoDeleted.aspx.cs" Inherits="EDP_Clinic.PaymentInfoDeleted" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height: 100vh;">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="goHomeBtn" runat="server" Text="Home" CssClass="btn btn-primary btn-style" OnClick="goHomeBtn_Click" />
            </div>
            <div class="mt-5 text-center">
                <h1 class="title mb-4">Deleted Payment Information</h1>
                <p class="mb-4">You have deleted your payment information.</p>
                <p class="mb-4">Don't worry as you can still add in your payment information whenever you want!</p>
            </div>
            <div style="display: flex; justify-content: center;">
                <asp:Button ID="paymentListBtn" runat="server" Text="Payment Methods" CssClass="btn btn-primary btn-style" OnClick="paymentListBtn_Click" />
            </div>
        </div>
    </section>
</asp:Content>
