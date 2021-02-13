<%@ Page Title="Thank You" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AfterPayment.aspx.cs" Inherits="EDP_Clinic.AfterPayment" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height: 100vh;">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="goHomeBtn" runat="server" Text="Home" CssClass="btn btn-primary btn-style" OnClick="goHomeBtn_Click" />>
            </div>
            <div class="mt-5 text-center">
                <h1 class="title mb-4">Thank You</h1>
                <p class="mb-4">You have now completed your transaction. You can continue by checking out your latest receipts.</p>
            </div>
            <div style="display: flex; justify-content: center;">
                <asp:Button ID="goToReceipt" runat="server" Text="Check Receipts" CssClass="btn btn-primary btn-style" OnClick="goToReceipt_Click" />
            </div>
        </div>
    </section>
</asp:Content>
