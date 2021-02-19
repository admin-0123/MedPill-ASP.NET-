<%@ Page Title="Card List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CardList.aspx.cs" Inherits="EDP_Clinic.CardList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="cardList">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <div class="mb-3">
                <h1 class="title mb-4">Payment Methods</h1>
                <p>You can only add up to 3 cards.</p>
            </div>
            <asp:ListView ID="cardListView" runat="server" OnItemCommand="cardListView_ItemCommand">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-10">
                                    <h5 class="card-title">Card No.:
                                        <asp:Label ID="cardNumber" runat="server" Text='<%# "**** **** **** " + Eval("CardNumber").ToString().Substring(12,4) %>'></asp:Label></h5>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="moreBtn" runat="server" CssClass="btn btn-primary btn-style" CommandName="viewMore" CommandArgument='<%# Eval("UniqueIdentifier") %>' Text="View More"></asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="mb-3 mt-5 text-center">
                        <h5>There is currently no card information stored.</h5>
                    </div>
                </EmptyDataTemplate>
            </asp:ListView>
            <div class="mt-5 text-center">
                <asp:Button ID="addCardInfo" runat="server" Text="Add more Card Info" CssClass="btn btn-primary btn-style" OnClick="addCardInfo_Click" />
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
