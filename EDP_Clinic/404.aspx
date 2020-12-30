<%@ Page Title="404" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="404.aspx.cs" Inherits="EDP_Clinic._404" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="paymentInfoEmpty" style="height:100vh;">
        <div class="container py-lg-3" >
            <br />
            <br />
            <h1 class="title mb-4 align-center"style="text-align:center;">404 Error</h1>
             <p class="mb-4" style="text-align:center;">It seems something went wrong somewhere</p>
             <p class="mb-4" style="text-align:center;">Don't worry as you can go back easily to where you are!</p>
             <div style="display: flex; justify-content: center;">
                 <button class="btn btn-primary btn-style">Go back home
                 </button>
             </div>
        </div>
    </section>
</asp:Content>