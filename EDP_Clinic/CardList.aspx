<%@ Page Title="Card List" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CardList.aspx.cs" Inherits="EDP_Clinic.CardList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="cardList">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" />
            </div>
            <div class="mb-3">
                <h1 class="title mb-4">Payment Methods</h1>
                <p>You can only add up to 3 cards.</p>
            </div>
            <!---
            <div class="card mb-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-9">
                            <h5 class="card-title">Card No: 1</h5>
                        </div>
                        <div class="col-md-3">
                            <a href="#" class="btn btn-primary">Choose this card</a>
                            <a href="#" class="btn btn-primary">More</a>
                        </div>
                    </div>
                </div>
            </div>
            <div class="card mb-3">
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-9">
                            <h5 class="card-title">Card No: 2</h5>
                        </div>
                        <div class="col-md-3">
                            <a href="#" class="btn btn-primary">Choose this card</a>
                            <a href="#" class="btn btn-primary">More</a>
                        </div>
                    </div>
                </div>
            </div> --->
            <asp:ListView ID="cardListView" runat="server" OnItemCommand="cardListView_ItemCommand">
                <ItemTemplate>
                    <div class="card mb-3">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-md-10">
                                    <h5 class="card-title">Card No.:
                                        <asp:Label ID="cardNumber" runat="server" Text='<%# Eval("CardNumber") %>'></asp:Label></h5>
                                </div>
                                <div class="col-md-2">
                                    <asp:LinkButton ID="moreBtn" runat="server" CssClass="btn btn-primary btn-style" CommandName="viewMore" CommandArgument='<%# Eval("CardNumber") %>'>More</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:ListView>
            <div class="text-center">
                <asp:Button ID="addCardInfo" runat="server" Text="Add more Card Info" CssClass="btn btn-primary btn-style" OnClick="addCardInfo_Click" />
            </div>
            <%--              <button class="btn btn-primary btn-style mr-5">delete
              </button>
              <button class="btn btn-primary btn-style ml-5">update
              </button>--%>
        </div>
    </section>
</asp:Content>
