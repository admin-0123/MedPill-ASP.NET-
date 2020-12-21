<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PFA_ADMIN.aspx.cs" Inherits="EDP_Clinic.PFA_ADMIN" %>
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
    <!--

                        <nav aria-label="breadcrumb">
  <ol class="breadcrumb">
          <li class="breadcrumb-item" aria-current="page"> <a href=""> Appointments </a>  </li>

  </ol>
</nav>
            -->
            <div class="container myPage">
       <h2> Select Profile For Appointment</h2>
        <div></div>
    <div>
                <p> &nbsp;</p>
        <div class="row">
            <div class="col-6">
                       <span class="text-dark"> Users:
                                           <asp:TextBox ID="TextBox1" runat="server" placeholder="Search User"></asp:TextBox>
        </span>
            </div>
            <div class="col-6"> 

            </div>
        </div>
        <p> &nbsp;</p>
        <div class="card-header profile_1">        <span class="profile_1"><img src="assets/images/profileImage_placeholder.png" class="img-fluid" width="50px" height="50px">&nbsp;&nbsp;&nbsp;&nbsp; Johnny Lim</span>
        </img>                                                            <span class="fa fa-arrow-right" style="height:inherit; margin-left:891px;"></span> <p class="mt-2"> jlim@email.com</p></div>
                <p> &nbsp</p>
                <div class="card-header profile_2">        <span class="profile_1"><img src="assets/images/profileImage_placeholder.png" class="img-fluid" width="50px" height="50px">&nbsp;&nbsp;&nbsp;&nbsp; Jenny Lim</span>
                                                            <span class="fa fa-arrow-right" style="height:inherit; margin-left:900px;"></span> <p class="mt-2"> jenlim@email.com</p
        </img> </div>
        </div>
                <p> &nbsp</p>
                <p> &nbsp</p>
                <p> &nbsp</p>
                            <p> 
                <asp:Button ID="Btn_LoadMore" runat="server" Text="Load More" Width="1110px" CssClass="btn btn-primary" OnClick="Btn_LoadMore_Click" />
            </p>
        </div>

</asp:Content>
