<%@ Page Title="Payment History" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceiptList.aspx.cs" Inherits="EDP_Clinic.ReceiptList" %>

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
                <asp:ListView ID="receiptListView" runat="server" OnItemCommand="receiptListView_ItemCommand">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-11">
                                        <h5 class="card-title">Receipt ID: 
                                            <asp:Label ID="receiptID" runat="server" Text='<%#Eval("UniqueIdentifier").ToString()%>'></asp:Label></h5>
                                        </h5>
                                        <p class="card-text">Date Payment:
                                            <asp:Label ID="datePayment" runat="server" Text='<%#Convert.ToDateTime(Eval("DateSale")).ToString("dd/MM/yyyy")%>'></asp:Label></p>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:LinkButton ID="moreBtn" runat="server" CssClass="btn btn-primary" CommandName="viewMore" CommandArgument='<%# Eval("UniqueIdentifier") %>'>More</asp:LinkButton>
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
                <asp:DataPager ID="receiptListPager" runat="server" PagedControlID="receiptListView" PageSize="3" OnPreRender="receiptListPager_PreRender">
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
