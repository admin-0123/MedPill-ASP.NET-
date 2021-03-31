<%@ Page Title="Caregiver Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CaregiverSignup.aspx.cs" Inherits="EDP_Clinic.CaregiverSignup" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="caregiverPage">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <h1 class="title mb-4">Caregiver Page</h1>
            <div class="row mt-5">
                <div class="col-md-8">
                    <div class="mb-3">
                        <h4>Caregiver Status:                            
                            <asp:Label ID="lbl_cgstatus" runat="server"></asp:Label>
                        </h4>
                    </div>
                    <div class="mb-3">
                        <label>
                            <asp:Label ID="lbl_instruction" runat="server" Text="Select Patient:"></asp:Label>
                        </label>
                        <asp:DropDownList ID="ddl_allPatients" runat="server" CssClass="form-control" Width="300px"></asp:DropDownList>
                    </div>
                </div>
                <div class="mt-5">
                    <asp:Button ID="btn_becomeCG" runat="server" Text="Become a caregiver" OnClick="btn_becomeCG_Click" CssClass="btn btn-style btn-primary" /><asp:Button ID="btn_stopCG" runat="server" Text="Remove Care Receiver" OnClick="btn_stopCG_Click" Visible="false" CssClass="btn btn-style btn-primary" />
                </div>
            </div>
        </div>
        <div class="col-md-4"></div>
        </div>
    </section>
</asp:Content>
