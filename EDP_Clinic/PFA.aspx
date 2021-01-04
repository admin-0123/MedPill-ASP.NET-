<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PFA.aspx.cs" Inherits="EDP_Clinic.PFA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .profile_1 {
            border-radius:30px;
        }

                .profile_2 {
            border-radius:30px;
        }

        .myPage {
            background-color:white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container myPage">
       <h2> Select Profile For Appointment</h2>
        <div></div>
    <div>
                <p> &nbsp;</p>
       <p class="text-dark"> My Appointments 
        </p>
        <div class="card-header profile_1">        <span class="profile_1">
            <asp:Image ID="userPfp" runat="server" Height="50px" ImageUrl="~/assets/images/pfp_placeholder.png" Width="50px" />
            &nbsp;&nbsp;&nbsp; </span>
        </img>                                                            
            <asp:Label ID="lbl_profileName" runat="server"></asp:Label>
            <span class="profile_1">
            <asp:Image ID="Image2" runat="server" Height="50px" ImageAlign="Right" ImageUrl="~/assets/images/rightArrow.png" Width="50px" />
            </span>
            </div>
        <p> &nbsp</p>
               <p class="text-dark"> My Care Receivers 
        </p>
                <p> &nbsp</p>
                <div class="card-header profile_2">        <span class="profile_1">&nbsp;<asp:Image ID="crPfp" runat="server" Height="50px" ImageUrl="~/assets/images/pfp_placeholder.png" Width="50px" />
                    &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                                            <asp:Label ID="lbl_crName" runat="server"></asp:Label>
        </img>        <span class="profile_1">
                    <asp:Image ID="Image1" runat="server" Height="50px" ImageAlign="Right" ImageUrl="~/assets/images/rightArrow.png" Width="50px" />
                    </span>
                </div>
        </div>
                <p> &nbsp</p>
                <p> &nbsp</p>
                <p> &nbsp</p>
        </div>
</asp:Content>
