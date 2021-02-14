<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaregiverSignup.aspx.cs" Inherits="EDP_Clinic.CaregiverSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
                <div class="row">
            <div class="col-6">Caregiver Status: </div>
            <div class="col-6"><asp:Label ID="lbl_cgstatus" runat="server" Text=""></asp:Label></div>
                    
        </div>
        <div class="row">
            <div class="col-6">Select Patient: </div>
            <div class="col-6">        <asp:DropDownList ID="ddl_allPatients" runat="server"></asp:DropDownList></div>
        </div>
                <div class="row mt-5">
            <div class="col-6"></div>
            <div class="col-6"><asp:Button ID="btn_becomeCG" runat="server" Text="Become a caregiver" OnClick="btn_becomeCG_Click" /></div>
        </div>

    </div>
</asp:Content>
