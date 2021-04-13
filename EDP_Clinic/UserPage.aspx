<%@ Page Title="User Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="EDP_Clinic.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pfp {
            display: block;
            margin-left: auto;
            margin-right: auto;
            width: auto;
            border-radius: 50%;
            height: 120px;
            margin-top: 10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="icon" type="image/png" href="assets/images/icons/favicon.ico" />
<%--    <link rel="stylesheet" type="text/css" href="assets/css/main.css">--%>
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
    <section class="w3l-contact py-5" id="userPage">
        <div class="container py-lg-3">
            <div class="mb-3">
                <img class="pfp" id="defaultPfp" src="https://icon-library.com/images/default-profile-icon/default-profile-icon-16.jpg" runat="server">
                <asp:Image class="pfp" ID="imgPfp" runat="server" Style="border-style: solid; width: 150px; height: 150px; border-color: #17449e;" />
            </div>
            <asp:Button ID="changeinfoBtn1" runat="server" Text="Change Infomation" CssClass="btn btn-primary" OnClick="changeinfoBtn_Click" />

            <div class="mb-3 text-center mx-auto">
                <asp:Label ID="lblName" runat="server" CssClass="h3">Name</asp:Label>
            </div>
            <div class="mt-5 text-center mx-auto">
                <div class="btn-group btn-group-lg" role="group" aria-label="User Options">
                    <asp:Button ID="appointmentBtn" runat="server" Text="Appointments" CssClass="btn btn-primary" OnClick="appointmentBtn_Click" />
                    <%--                    <asp:Button ID="medicationBtn" runat="server" Text="Medication" CssClass="btn btn-primary" OnClick="medicationBtn_Click" />--%>
                    <asp:Button ID="paymentMethodBtn" runat="server" Text="Payment Methods" CssClass="btn btn-primary" OnClick="paymentMethodBtn_Click" />
                    <asp:Button ID="paymentHistoryBtn" runat="server" Text="Payment History" CssClass="btn btn-primary" OnClick="paymentHistoryBtn_Click" />
                    <asp:Button ID="cgBtn" runat="server" Text="Caregiver Signup" CssClass="btn btn-primary" OnClick="cgBtn_Click" />
                    <asp:Button ID="changeinfoBtn0" runat="server" Text="Change Personal Information" CssClass="btn btn-primary" OnClick="Change_Personal_Info_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
