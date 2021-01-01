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
        <p> &nbsp;</p>
        <div class="card-header profile_1">        <span class="profile_1"><img src="assets/images/profileImage_placeholder.png" class="img-fluid" width="50px" height="50px">&nbsp;&nbsp;&nbsp;&nbsp; Johnny Lim </span>
        </img>                                                            <span class="fa fa-arrow-right" style="height:inherit; margin-left:891px;"></span> </div>
        <p> &nbsp</p>
               <p class="text-dark"> My Care Receivers 
        </p>
                <p> &nbsp</p>
                <div class="card-header profile_2">        <span class="profile_1"><img src="assets/images/profileImage_placeholder.png" class="img-fluid" width="50px" height="50px">&nbsp;&nbsp;&nbsp;&nbsp; Jenny Lim </span>
                                                            <span class="fa fa-arrow-right" style="height:inherit; margin-left:900px;"></span>
        </img> </div>
        </div>
                <p> &nbsp</p>
                <p> &nbsp</p>
                <p> &nbsp</p>
        </div>
</asp:Content>
