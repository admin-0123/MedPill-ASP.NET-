<%@ Page Title="Receiptionist Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="receptionistPage.aspx.cs" Inherits="EDP_Clinic.employeePage" %>
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
    <link rel="stylesheet" href="assets/css/style.css" media="screen" type="text/css" />
    <section class="w3l-contact py-5" id="400_Error">
        <div class="container py-lg-3">
            <img class="pfp mb-3" id="defaultPfp" src="https://icon-library.com/images/default-profile-icon/default-profile-icon-16.jpg" runat="server">
            <asp:Image class="pfp mb-3" ID="imgPfp" runat="server" style="border-style: solid; width:150px; height:150px; border-color:#17449e;"  /> 
            <asp:Button ID="changeinfoBtn" runat="server" Text="Change Infomation" CssClass="btn btn-primary" OnClick="changeinfoBtn_Click" />
            
            &nbsp;<div class="mx-auto mb-3 text-center">
                <asp:Label ID="lblName" runat="server" CssClass="theName">Name</asp:Label>
            </div>
            <div class="mt-5 text-center mx-auto">
                <div class="btn-group btn-group-lg" role="group" aria-label="User Options">
                    <asp:Button ID="receptionistBtn" runat="server" Text="Receptionist Appointment Control" CssClass="btn btn-primary" OnClick="receptionistBtn_Click" />
                </div>
            </div>        
        </div>
    </section>
</asp:Content>
