<%@ Page Title="Payment History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceiptList.aspx.cs" Inherits="EDP_Clinic.Receipt" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="receiptList">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <div class="mb-3">
                <h1 class="title mb-4">Payment History</h1>
                <p>You can view your payment history here.</p>
            </div>
            <div class="mb-3">
                <asp:ListView ID="receiptListView" runat="server">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-11">
                                        <h5 class="card-title">Receipt No: <%# Eval("CardNumber")%></h5>
                                        <p class="card-text">Appointment No: 1</p>
                                    </div>
                                    <div class="col-md-1">
                                        <a href="#" class="btn btn-primary">More</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                    <EmptyDataTemplate>
                        <div class="mb-3 mt-5 text-center">
                            <h5>There is currently no payment history stored.</h5>
                        </div>
                    </EmptyDataTemplate>
                </asp:ListView>
            </div>
            <div class="mt-5 text-center">
                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="receiptListView" PageSize="1" OnPreRender="DataPager1_PreRender">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-primary" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
        </div>
    </section>
</asp:Content>
