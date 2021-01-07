<%@ Page Title="Deleted Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentInfoDeleted.aspx.cs" Inherits="EDP_Clinic.PaymentInfoDeleted" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height: 100vh;">
        <div class="container py-lg-3">
            <button class="btn btn-primary btn-style">
                Home
            </button>
            <br />
            <br />
            <h1 class="title mb-4 align-center" style="text-align: center;">Deleted Payment Information</h1>
            <p class="mb-4" style="text-align: center;">You have deleted your payment information.</p>
            <p class="mb-4" style="text-align: center;">Don't worry as you can still add in your payment information whenever you want!</p>
            <br />
            <div style="display: flex; justify-content: center;">
                <button class="btn btn-primary btn-style">
                    Add Payment Info
                </button>
            </div>
            <%--              <button class="btn btn-primary btn-style mr-5">delete
              </button>
              <button class="btn btn-primary btn-style ml-5">update
              </button>--%>
        </div>
    </section>
</asp:Content>
