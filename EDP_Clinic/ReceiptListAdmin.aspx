<%@ Page Title="Payment History Admin" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceiptListAdmin.aspx.cs" Inherits="EDP_Clinic.ReceiptListAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height: 100vh;">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" />
            </div>
            <div class="mb-3">
                <h1 class="title mb-4">Receipt History</h1>
                <p>You can view your payment history here.</p>
            </div>
            <div class="card mb-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-11">
                            <h5 class="card-title">Receipt No: 1</h5>
                            <p class="card-text">Appointment No: 1</p>
                        </div>
                        <div class="col-md-1">
                            <a href="#" class="btn btn-primary">More</a>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
