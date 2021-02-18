<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaregiverSignup.aspx.cs" Inherits="EDP_Clinic.CaregiverSignup" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
                .btn_signup {
            border-radius:15px;
        }

                                .btn_remove {
            border-radius:15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
                <div class="row">
            <div class="col-6">Caregiver Status: </div>
            <div class="col-6"><asp:Label ID="lbl_cgstatus" runat="server" Text=""></asp:Label></div>
                    
        </div>
        <div class="row">
            
            <div class="col-6"><asp:Label ID="lbl_instruction" runat="server" Text="Select Patient:"></asp:Label></div>
            <div class="col-6">        <asp:DropDownList ID="ddl_allPatients" runat="server"></asp:DropDownList></div>
        </div>
                <div class="row mt-5">
            <div class="col-6"></div>
            <div class="col-6"><asp:Button ID="btn_becomeCG" runat="server" Text="Become a caregiver" OnClick="btn_becomeCG_Click" CssClass="btn_signup btn btn-primary text-white" /><asp:Button ID="btn_stopCG" runat="server" Text="Remove Care Receiver" OnClick="btn_stopCG_Click" Visible="false" CssClass="btn_remove btn btn-primary text-white"/></div>
        </div>

    </div>
</asp:Content>
