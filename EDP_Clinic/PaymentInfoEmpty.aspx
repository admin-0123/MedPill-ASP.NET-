<%@ Page Title="Payment Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentInfoEmpty.aspx.cs" Inherits="EDP_Clinic.PaymentInfoEmpty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height: 100vh;">
        <div class="container py-lg-3">
            <button class="btn btn-primary btn-style">
                Back
            </button>
            <br />
            <br />
            <h1 class="title mb-4 align-center" style="text-align: center;">No Payment Information</h1>
            <p style="text-align: center;">Add payment information to make your payment quick!</p>
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
