<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PRFA2.aspx.cs" Inherits="EDP_Clinic.PRFA2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btn_mka {
            border-radius:15px;
        }

        .btn_Cancel {
            border-radius:15px;
        }

        .btn_Rsch {
                        border-radius:15px;
        }


            .breadcrumb-item + .breadcrumb-item::before {
        content: ">";
    }
    </style>

    <script>
     function showModal() {
            $('#cancelModal').modal('show');
        }

        $(function () {
            $("#cancelBtn").click(function () {
                showModal();
            });
        

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <nav aria-label="breadcrumb">
  <ol class="breadcrumb">
    <li class="breadcrumb-item active">Appointments</li>
    <li class="breadcrumb-item active" aria-current="page"> Johnny Lim </li>
          <li class="breadcrumb-item" aria-current="page"> <a href=""> Upcoming Appointments </a>  </li>

  </ol>
</nav>
                    <h2> View Appointments </h2>
        <div class="card-header">

            <div class="row">
                <div class="col-8"> 
                    <span class="fa fa-arrow-left" style="height:inherit"></span>
                    &nbsp
                    <img src="assets/images/profileImage_placeholder.png" width="50px" height="50px"></img>
                                        &nbsp
                    <span> Johnny Lim</span>
                </div>
                <div class="col-4"> 
                    <button class="btn_mka btn btn-primary text-white"> Make New Appointment </button>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-4 upcoming text-primary"> 
                    Upcoming  </div>
                                <div class="col-4 missed"> Past  </div>
                <div class="col-4 missed"> Missed  </div>
            </div>
        </div>
        <div>
            &nbsp
            &nbsp
        </div>
        <div class="card-header">
            <div class="row">
                <div class="col-8">                            <h4> Date Time: 02 December 2020 (WED) 02:30PM</h4> </div>
                                <div class="col-4"></div>
            </div>
            <div class="row">
                      <div class="col-8">      <h4> Type: Consultation </h4> </div>
                <div class="col-4"></div>
            </div>

            <div class="row">
                <div class="col-8 col-sm-12">            <h4> Doctor: Johnson Tan </h4> </div>
                <div class="col-2 col-sm-6 mt-2"> <button class="btn_Rsch bg-primary text-white"> Reschedule </button> </div>
                                <div class="col-2 col-sm-6 mt-2"> <button class="btn_Cancel bg-white text-primary btn-outline-primary"  data-toggle="modal" data-target="#cancelModal" onclick="btn_cancel_click" id="cancelBtn"> Cancel  </button> </div>
            </div>
        </div>
        <!-- Modal -->
<div class="modal fade" id="cancelModal" tabindex="-1" role="dialog" aria-labelledby="cancelModalLabel" aria-hidden="true">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Cancel Appointment?</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Cancel</button>
      </div>
    </div>
  </div>
</div>
    </div>
</asp:Content>
