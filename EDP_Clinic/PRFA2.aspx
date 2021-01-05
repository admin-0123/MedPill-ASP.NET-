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


            function testing123() {
                alert("Foo")
                console.log("ABC")
                return false;
            }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <nav aria-label="breadcrumb">
  <ol class="breadcrumb">
      <li class="breadcrumb-item active">
          <asp:Label ID="bc_Appointments" runat="server" Text="Appointments"></asp:Label>
      </li>
    <li class="breadcrumb-item active" aria-current="page"> 
        <asp:Label ID="bc_profileName" runat="server" Text="profileName"></asp:Label>
      </li>
          <li class="breadcrumb-item" aria-current="page"> <!-- <a href=""> Upcoming Appointments </a>  -->
              <asp:Label ID="bc_UAppointments" runat="server" Text="Upcoming Appointments"></asp:Label>
      </li>

  </ol>
</nav>
                    <h2> View Appointments </h2>
        <div class="card-header">

            <div class="row">
                <div class="col-sm-8"> 
                    <!--
                    <span class="fa fa-arrow-left" style="height:inherit"></span>
                    &nbsp
                    <img src="assets/images/profileImage_placeholder.png" width="50px" height="50px"></img>
                                        &nbsp
                    <span> Johnny Lim</span>
                        -->
                    <asp:ImageButton ID="leftArrow_redirect" runat="server" Height="50px" ImageAlign="Left" ImageUrl="~/assets/images/leftArrow.png" Width="50px" />
                    <asp:Image ID="profilePfp" runat="server" ImageUrl="~/assets/images/pfp_placeholder.png" Height="50px" Width="50px" />
                </div>
                <div class="col-sm-4"> 
                    <asp:Button runat="server" Text="Make New Appointment" CssClass="btn_mka btn btn-primary text-white" ID="btn_makeAppt" />
                    <!-- <button class="btn_mka btn btn-primary text-white"> Make New Appointment</button> -->
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-4 upcoming text-primary"> 
                    <asp:Label ID="lbl_Upcoming" runat="server" Text="Upcoming"></asp:Label> </div>
    
                                <div class="col-4 missed">  
                    <asp:Label ID="lbl_Past" runat="server" Text="Past"></asp:Label>  </div>
                <div class="col-4 missed"> &nbsp;<asp:Label ID="lbl_Missed" runat="server" Text="Missed"></asp:Label>  </div>
            </div>
        </div>
        <div>
            &nbsp
            &nbsp
        </div>

        <!-- OLD CARD HEADER, LEAVE FOR POTENTIAL FUTURE RE-USE
        <div class="card-header">
            <div class="row">
                <div class="col-8">                            <h4> Date Time: 02 December 2020 (WED) 02:30PM</h4></h4> </div>
                                <div class="col-4"></div>
            </div>
            <div class="row">
                      <div class="col-8">      <h4> Type: Consultation </h4> </div>
                <div class="col-4"></div>
            </div>

            <div class="row">
                <div class="col-8 col-sm-12">            <h4> Doctor: Johnson Tan </h4> </div>
                </div>
            <div class="row">
                <div class="col-8 col-lg-6"></div>
                <div class="col-2 col-sm-6 mt-2 col-lg-3">
                    <asp:Button ID="btn_Rsch" runat="server" Text="Reschedule" CssClass="btn_Rsch bg-primary text-white" /> </div>
                                <div class="col-2 col-sm-6 mt-2 col-lg-3"> 
                                    <button class="btn_Cancel bg-white text-primary btn-outline-primary"  data-toggle="modal" data-target="#cancelModal" onclick="btn_cancel_click" id="cancelBtn"> Cancel  </button>

                                </div>
                </div>
            </div>
        -->

        <% foreach (var appt in GetApptsUser())
{ %>
            <div class="card-header">
            <h4>Date Time: <%= appt.dateTime %> </h4>
            <h4> Type: <%= appt.appointmentType %> </h4>
            <h4> Doctor: <%= appt.doctorID %> </h4>
            <div class="row">
                                    <asp:Button ID="btn_Rsch2" runat="server" Text="Reschedule" CssClass="btn_Rsch bg-primary text-white col-3 align-content-end ml-2" />
                                    <span class="col-3"></span>
                                    <button class="btn_Cancel bg-white text-primary btn-outline-primary col-3"  data-toggle="modal" data-target="#cancelModal" onclick="btn_cancel_click" id="cancelBtn"> Cancel  </button>
                         <span class="col-3"></span>
            </div>
        </div>
        <%} %>

        <!-- 
        <div class="card-header">
            <h4>Date Time: 02 December 2020 (WED) 02:30PM </h4>
            <h4> Type: Consultation </h4>
            <h4> Doctor: Johnson Tan </h4>
            <div class="row">
                                    <asp:Button ID="btn_Rsch3" runat="server" Text="Reschedule" CssClass="btn_Rsch bg-primary text-white col-3 align-content-end ml-2" />
                                    <span class="col-3"></span>
                                    <button class="btn_Cancel bg-white text-primary btn-outline-primary col-3"  data-toggle="modal" data-target="#cancelModal" onclick="btn_cancel_click" id="cancelBtn"> Cancel  </button>
                         <span class="col-3"></span>
            </div>
        </div>
        -->
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
