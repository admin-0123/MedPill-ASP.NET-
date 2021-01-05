<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PFA.aspx.cs" Inherits="EDP_Clinic.PFA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .myPage {
            background-color:white;
        }

                .profile_1 {
            border-radius:30px;
        }

                .profile_2 {
            border-radius:30px;
        }

        .profile_1:hover {
            color:skyblue;
        }

        .profile_2:hover {
            color:skyblue;
        }

        .rightArrow {
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container myPage">
       <h2> Select Profile For Appointment</h2>
        <div></div>
    <div>
                <p"> &nbsp;</p>
       <p class="text-dark"> My Appointments 
        </p>
        <div class="card-header profile_1">        <span class="profile_1">
            <asp:Image ID="userPfp" runat="server" Height="50px" ImageUrl="~/assets/images/pfp_placeholder.png" Width="50px" style="border-radius:50%;" BorderColor="Black" />
            &nbsp;&nbsp;&nbsp; </span>
        </img>                                                            
            <asp:Label ID="lbl_profileName" runat="server"></asp:Label>
            <asp:ImageButton ID="userArrow" runat="server" Height="50px" ImageAlign="Right" ImageUrl="~/assets/images/rightArrow.png" OnClick="Arrow_Click" Width="50px" />
            </div>
        <p> &nbsp</p>
               <p class="text-dark"> My Care Receivers 
        </p>
                <p> &nbsp</p>
                <div class="card-header profile_2">        <span class="profile_1">&nbsp;<asp:Image ID="crPfp" runat="server" Height="50px" ImageUrl="~/assets/images/pfp_placeholder.png" Width="50px" BorderColor="Black" style="border-radius:50%;"/>
                    &nbsp;&nbsp;&nbsp;&nbsp; </span>
                                                            <asp:Label ID="lbl_crName" runat="server"></asp:Label>
        </img>        
                    <asp:ImageButton ID="crArrow" runat="server" Height="50px" ImageAlign="Right" ImageUrl="~/assets/images/rightArrow.png" OnClick="Arrow_Click" Width="50px" />
                </div>
        </div>
                <p> &nbsp;</p>
                <p> &nbsp</p>
                <p> &nbsp</p>
        </div>
</asp:Content>
