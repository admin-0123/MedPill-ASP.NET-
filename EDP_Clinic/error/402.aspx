<%@ Page Title="402 Error" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="402.aspx.cs" Inherits="EDP_Clinic._402" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="402_Error">
        <div class="container py-lg-3">
            <div class="mt-5 text-center">
                <h1 class="title mb-4">402 Error</h1>
                <p class="mb-4">It seems something went wrong somewhere</p>
                <p class="mb-4">Don't worry as you can go back easily to where you are!</p>
                <div style="display: flex; justify-content: center;">
                    <asp:Button ID="goHomeBtn" runat="server" Text="Go back home" CssClass="btn btn-primary btn-style" OnClick="goHomeBtn_Click" />
                </div>
            </div>
        </div>
    </section>
</asp:Content>
