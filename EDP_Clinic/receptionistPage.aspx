<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="receptionistPage.aspx.cs" Inherits="EDP_Clinic.employeePage" %>
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

        .theName {
            font-size: 25px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="icon" type="image/png" href="assets/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/animate/animate.css">--%>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/select2/select2.min.css">--%>
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/perfect-scrollbar/perfect-scrollbar.css">--%>
    <!--===============================================================================================-->
    <%--    <div class="nav" style="display: block;">
        <ul>
            <li><a href="#">Appointments</a></li>
            <li><a href="#">Medication</a></li>
            <li><a href="CardList.aspx">Payment Methods</a></li>
            <li><a href="ReceiptList.aspx">Payment History</a></li>
        </ul>
    </div>--%>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/css/util.css">
    <link rel="stylesheet" type="text/css" href="assets/css/main.css">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
    <section class="w3l-contact py-5" id="400_Error">
        <div class="container py-lg-3">
            <img class="pfp mb-3" id="defaultPfp" src="https://icon-library.com/images/default-profile-icon/default-profile-icon-16.jpg" runat="server">
            <asp:Image class="pfp mb-3" ID="imgPfp" runat="server" style="border-style: solid; width:150px; height:150px; border-color:#17449e;"  /> 
            <asp:Button ID="changeinfoBtn" runat="server" Text="Change Infomation" CssClass="btn btn-primary" OnClick="changeinfoBtn_Click" />
            
            &nbsp;<div class="mb-3" style="margin-left: auto; margin-right: auto; text-align: center;">
                <asp:Label ID="lblName" runat="server" CssClass="theName">Name</asp:Label>
            </div>
    <%--    <div class="nav" style="display: block;">
        <ul>
            <li><a href="#">Appointments</a></li>
            <li><a href="#">Medication</a></li>
            <li><a href="CardList.aspx">Payment Methods</a></li>
            <li><a href="ReceiptList.aspx">Payment History</a></li>
        </ul>
    </div>--%>
            <div class="mt-5 text-center mx-auto">
                <div class="btn-group btn-group-lg" role="group" aria-label="User Options">
                    <asp:Button ID="receptionistBtn" runat="server" Text="Appointments" CssClass="btn btn-primary" OnClick="receptionistBtn_Click" />
                </div>
            </div>
           
        </div>
    </section>
</asp:Content>
