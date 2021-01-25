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

        .theName {
            font-size: 25px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <link rel="icon" type="image/png" href="assets/images/icons/favicon.ico" />
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/bootstrap/css/bootstrap.min.css">--%>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/fonts/font-awesome-4.7.0/css/font-awesome.min.css">
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/animate/animate.css">--%>
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/select2/select2.min.css">--%>
    <!--===============================================================================================-->
    <%--    <link rel="stylesheet" type="text/css" href="assets/vendor/perfect-scrollbar/perfect-scrollbar.css">--%>
    <!--===============================================================================================-->
    <link rel="stylesheet" type="text/css" href="assets/css/util.css">
    <link rel="stylesheet" type="text/css" href="assets/css/main.css">
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
    <section class="w3l-contact py-5" id="400_Error">
        <div class="container py-lg-3">
            <img class="pfp mb-3" src="https://icon-library.com/images/default-profile-icon/default-profile-icon-16.jpg">
            <div class="mb-3" style="margin-left: auto; margin-right: auto; text-align: center;">
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
                    <asp:Button ID="appointmentBtn" runat="server" Text="Appointments" CssClass="btn btn-primary" OnClick="appointmentBtn_Click" />
                    <asp:Button ID="medicationBtn" runat="server" Text="Medication" CssClass="btn btn-primary" OnClick="medicationBtn_Click" />
                    <asp:Button ID="paymentMethodBtn" runat="server" Text="Payment Methods" CssClass="btn btn-primary" OnClick="paymentMethodBtn_Click" />
                    <asp:Button ID="paymentHistoryBtn" runat="server" Text="Payment History" CssClass="btn btn-primary" OnClick="paymentHistoryBtn_Click" />
                </div>
            </div>
            <div class="mt-5" id ="appointmentTable">
                <div class="limiter">
                    <div class="container-table100">
                        <div class="wrap-table100">
                            <div class="table100">
                                <table>
                                    <thead>
                                        <tr class="table100-head">
                                            <th class="column1">Date</th>
                                            <th class="column2">Appointment ID</th>
                                            <th class="column3">Doctor</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr>
                                            <td class="column1">2017-09-29 01:22</td>
                                            <td class="column2">200398</td>
                                            <td class="column3">Johnny Lim</td>
                                        </tr>
                                        <tr>
                                            <td class="column1">2017-08-29 05:57</td>
                                            <td class="column2">200397</td>
                                            <td class="column3">Johnny Lim</td>
                                        </tr>
                                        <tr>
                                            <td class="column1">2017-07-29 05:57</td>
                                            <td class="column2">200396</td>
                                            <td class="column3">Johnny Lim</td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
