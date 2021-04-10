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
            <%--            <div class="alert alert-primary" role="alert" runat="server" id="messageNotification">
                <asp:Label ID="messageContent" runat="server"></asp:Label>
            </div>--%>
            <div class="row mt-5">
                <div class="col-md-7">
                    <div class="mb-3">
                        <h4>Caregiver Status:                            
                            <asp:Label ID="lbl_cgstatus" runat="server"></asp:Label>
                        </h4>
                        <asp:Button ID="btn_stopCG" runat="server" Text="Remove Care Receiver" OnClick="btn_stopCG_Click" Visible="false" CssClass="btn btn-primary mt-3" />
                    </div>
                    <div class="form-group mb-3">
                        <asp:Label ID="lbl_instruction" runat="server" Text="Select Patient:"></asp:Label>
                        <div class="input-group">
                            <asp:DropDownList ID="ddl_allPatients" runat="server" CssClass="form-control custom-select" Width="300px"></asp:DropDownList>
                            <div class="input-group-append">
                                <asp:Button ID="btn_becomeCG" runat="server" Text="Become a caregiver" OnClick="btn_becomeCG_Click" CssClass="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="mt-5">
                </div>
                <div class="col-md-5">
                </div>
            </div>
        </div>
    </section>
</asp:Content>
