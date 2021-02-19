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
                <p>You can view your payment history here. You can view your PayPal Receipts at your <a href="https://www.paypal.com/sg/signin" target="_blank">PayPal Account</a> .</p>
            </div>
            <div class="mb-3">
                <asp:ListView ID="receiptListView" runat="server" OnItemCommand="receiptListView_ItemCommand">
                    <ItemTemplate>
                        <div class="card mb-3">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-8">
                                        <h5 class="card-title">Receipt ID: 
                                            <asp:Label ID="receiptID" runat="server" Text='<%#Eval("UniqueIdentifier").ToString()%>'></asp:Label></h5>
                                        </h5>
                                        <p class="card-text">
                                            Date Payment:
                                            <asp:Label ID="datePayment" runat="server" Text='<%#Convert.ToDateTime(Eval("DateSale")).ToString("dd/MM/yyyy")%>'></asp:Label>
                                        </p>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:LinkButton ID="downloadBtn" runat="server" CssClass="btn btn-primary" CommandName="downloadReceipt" CommandArgument='<%# Eval("UniqueIdentifier") %>' Text="Download" Visible="False"></asp:LinkButton>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:LinkButton ID="printBtn" runat="server" CssClass="btn btn-primary" CommandName="printReceipt" CommandArgument='<%# Eval("UniqueIdentifier") %>' Text="Print" Visible="False"></asp:LinkButton>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:LinkButton ID="moreBtn" runat="server" CssClass="btn btn-primary" CommandName="viewMore" CommandArgument='<%# Eval("UniqueIdentifier") %>' Text="View More"></asp:LinkButton>
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
