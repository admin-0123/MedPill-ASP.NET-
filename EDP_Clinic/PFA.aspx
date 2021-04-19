<%@ Page Title="Select Profile" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PFA.aspx.cs" Inherits="EDP_Clinic.PFA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">

        .profile_1 {
            border-radius: 30px;
        }

        .profile_2 {
            border-radius: 30px;
        }

        .profile_1:hover {
            color: skyblue;
        }

        .profile_2:hover {
            color: skyblue;
        }

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container myPage">
        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="hyperlink_breadcrumb lbtn_inactive" NavigateUrl="~/UserPage.aspx">User Page</asp:HyperLink></asp:Label>
                </li>
                <li class="breadcrumb-item active">
                    <asp:HyperLink ID="hl_bc_appt" runat="server" CssClass="hyperlink_breadcrumb">Appointments</asp:HyperLink></asp:Label>
                </li>
            </ol>
        </nav>
        <h2 class="mb-3">Select Profile For Appointment</h2>
        <div>
            <h5 class="mb-3">My Appointments</h5>
            <div class="card-header profile_1 mb-5">
                <span class="profile_1">
                    <asp:Image ID="userPfp" runat="server" Height="50px" ImageUrl="~/assets/images/pfp_placeholder.png" Width="50px" Style="border-radius: 50%;" BorderColor="Black" /></span>
                <asp:Label ID="lbl_profileName" runat="server"></asp:Label>
                <asp:ImageButton ID="userArrow" runat="server" Height="50px" ImageAlign="Right" ImageUrl="~/assets/images/rightArrow.png" OnClick="View_Appt_Patient" Width="50px" />
            </div>
            <h5 class="mb-3">My Care Receivers</h5>
            <div class="card-header profile_2">
                <span class="profile_1">&nbsp;<asp:Image ID="crPfp" runat="server" Height="50px" ImageUrl="~/assets/images/pfp_placeholder.png" Width="50px" BorderColor="Black" Style="border-radius: 50%;" />
                    &nbsp;&nbsp;&nbsp;&nbsp; </span>
                <asp:Label ID="lbl_crName" runat="server"></asp:Label>
                <asp:ImageButton ID="crArrow" runat="server" Height="50px" ImageAlign="Right" ImageUrl="~/assets/images/rightArrow.png" OnClick="View_Appt_CR" Width="50px" />
            </div>
        </div>
    </div>
</asp:Content>
