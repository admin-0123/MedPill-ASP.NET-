<%@ Page Title="Assign Doctor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceptAssignDoctor.aspx.cs" Inherits="EDP_Clinic.ReceptAssignDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .breadcrumb-item + .breadcrumb-item::before {
            content: ">";
        }

        .hyperlink_breadcrumb {
            color: black;
            text-decoration: none;
        }

        .lbtn_inactive {
            color: black;
            text-decoration: none;
        }


        .btn_assignDoctor {
            border-radius: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item active">
                    <asp:HyperLink ID="hl_bc_appt" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/receptionistPage.aspx">User Page</asp:HyperLink>
                </li>
                <li class="breadcrumb-item active">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/ReceptAppts.aspx">Receptionist Appointment Control</asp:HyperLink>
                </li>
                <li class="breadcrumb-item active" aria-current="page">
                    <asp:HyperLink ID="hl_bc_profileName" runat="server" CssClass="hyperlink_breadcrumb_active"> </asp:HyperLink>
                </li>
                <li class="breadcrumb-item active" aria-current="page">
                    <asp:HyperLink ID="hl_bc_resch_appt" runat="server" CssClass="hyperlink_breadcrumb_active"></asp:HyperLink>Assign Doctor
                </li>
            </ol>
        </nav>
        <h2 class="mb-3">Assign Doctor</h2>
        <asp:Label ID="lbl_updateResult" runat="server" CssClass="mb-3"></asp:Label>
        <div class="form-group mb-3">
            <asp:Label ID="doctorSelect" runat="server" Text="Doctor"></asp:Label>
            <div class="input-group" style="width: 350px;">
                <asp:DropDownList ID="ddl_chooseDoctors" runat="server" CssClass="custom-select form-control"></asp:DropDownList>
                <div class="input-group-append">
                    <asp:Button ID="btn_assignDoctor" runat="server" Text="Assign" OnClick="btn_assignDoctor_Click" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
