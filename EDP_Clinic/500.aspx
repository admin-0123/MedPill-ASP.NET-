<%@ Page Title="500 Error" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="500.aspx.cs" Inherits="EDP_Clinic._500" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="500_Error">
        <div class="container py-lg-3">
            <div class="mt-5 text-center">
                <h1 class="title mb-4">500 Error</h1>
                <p class="mb-4">It seems something went wrong somewhere</p>
                <p class="mb-4">Don't worry as you can go back easily to where you are!</p>
                <div style="display: flex; justify-content: center;">
                    <asp:Button ID="goHomeBtn" runat="server" Text="Go back home" CssClass="btn btn-primary btn-style" OnClick="goHomeBtn_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
