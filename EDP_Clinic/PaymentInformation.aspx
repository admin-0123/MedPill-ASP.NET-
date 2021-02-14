<%@ Page Title="Payment Information" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PaymentInformation.aspx.cs" Inherits="EDP_Clinic.PaymentInformation" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfo">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <div class="mb-3">
                <h1 class="title mb-4">Payment Information</h1>
                <h4 class="mb-4">Name on Card: 
                    <asp:Label ID="cardNameText" runat="server"></asp:Label></h4>
                <div class="row mb-4">
                    <div class="col-md-4">
                        <h4 class="mt-2">Card Number:
                            <asp:Label ID="cardNumberText" runat="server"></asp:Label></h4>
                    </div>
                    <div class="col-md-8">
                        <div>
                            <asp:Image ID="cardIcon" runat="server" ImageAlign="Left" Width="76px" Height="48px" />
                        </div>
                    </div>
                </div>
                <h4 class="mb-4">Card Expiry: 
                    <asp:Label ID="cardExpiryText" runat="server"></asp:Label></h4>
                <p class="mb-4">
                    <asp:Label ID="cardExpiryStatus" runat="server"></asp:Label></p>
            </div>
            <div class="row">
                <div class="col-md-6"></div>
                <div class="col-md-3">
                    <asp:Button ID="deleteBtn" runat="server" Text="Delete" CssClass="btn btn-primary btn-style" OnClick="deleteBtn_Click" Visible="True" />
                </div>
                <div class="col-md-3">
                </div>
            </div>
        </div>
    </section>
    <!-- Start of ChatBot (www.chatbot.com) code -->
    <script type="text/javascript">
        window.__be = window.__be || {};
        window.__be.id = "6027c466643262000724c24d";
        (function () {
            var be = document.createElement('script'); be.type = 'text/javascript'; be.async = true;
            be.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'cdn.chatbot.com/widget/plugin.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(be, s);
        })();
    </script>
    <!-- End of ChatBot code -->
</asp:Content>
