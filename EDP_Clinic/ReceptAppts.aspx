<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceptAppts.aspx.cs" Inherits="EDP_Clinic.WebForm4" %>
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

            .hyperlink_breadcrumb {
                color:black;
    text-decoration:none;
            }

            .lbtn_inactive {
                                color:black;
    text-decoration:none;
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
        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
  <ol class="breadcrumb">
      <li class="breadcrumb-item active">
              <asp:HyperLink ID="hl_bc_appt" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/PFA.aspx">User Page</asp:HyperLink></asp:Label>
      </li>
    <li class="breadcrumb-item active" aria-current="page"> 
        <asp:HyperLink ID="hl_bc_profileName" runat="server" CssClass="hyperlink_breadcrumb_active"> Receptionist Appointment Control</asp:HyperLink></asp:Label>
      </li>
  </ol>
</nav>
                    <h2> View Appointments </h2>
        <div class="card-header">

            <div class="row">
                <div class="col-sm-8"> 
                    <asp:ImageButton ID="leftArrow_redirect" runat="server" Height="50px" ImageAlign="Left" ImageUrl="~/assets/images/leftArrow.png" Width="50px" OnClick="leftArrow_redirect_Click" />
                    <asp:Image ID="profilePfp" runat="server" ImageUrl="~/assets/images/pfp_placeholder.png" Height="50px" Width="50px" />
                                        <asp:Label ID="lbl_profileName" runat="server" Text=""></asp:Label>
                </div>
                <div class="col-sm-4"> 
                    <asp:Button runat="server" Text="Make New Appointment For User" CssClass="btn_mka btn btn-primary text-white" ID="btn_makeAppt" OnClick="btn_makeAppt_Click" hidden/>
                </div>
            </div>
            <div class="row mt-2">
                <div class="col-4 upcoming text-primary">
                     <asp:LinkButton ID="lbtn_upcoming" runat="server" OnClick="lbtn_upcoming_Click" CssClass="test">Upcoming</asp:LinkButton>
                     </div>
    
                                <div class="col-4 missed">  
                                         <asp:LinkButton ID="lbtn_past" runat="server" CssClass="lbtn_inactive test" OnClick="lbtn_past_Click">Past</asp:LinkButton>  </div>
                <div class="col-4 missed"> <asp:LinkButton ID="lbtn_missed" runat="server" OnClick="lbtn_missed_Click" CssClass="lbtn_inactive test">Missed</asp:LinkButton>  </div>
            </div>
        </div>
        <div>
            &nbsp
            &nbsp

        </div>



                <asp:ListView ID="listview_appts" runat="server" OnPagePropertiesChanging="listview_appts_PagePropertiesChanging">
                        <ItemTemplate>
                            <div class="card-header">
                                <p> Patient: <asp:Label ID="lbl_c_patient" runat="server" Text='<%# Convert_ID_To_Name ( Eval("patientID") ) %>'></asp:Label> </p>
                                <p hidden> Patient ID: <asp:Label ID="lbl_c_patient_id" runat="server" Text='<%# ( Eval("patientID")) %>'></asp:Label> </p>
                                <p> Date Time: <asp:Label ID="lbl_c_dt" runat="server" Text='<%# Eval("dateTime") %>'></asp:Label> </p>
                               <p> Type: <asp:Label ID="lbl_c_at" runat="server" Text='<%# Eval("appointmentType") %>'></asp:Label></p>
                                <p> Doctor: <asp:Label ID="lbl_c_dn" runat="server" Text='<%# Convert_ID_To_Name( Eval("doctorID") ) %>'></asp:Label> </p>


                    <% if (Session["appt_viewstate_admin"].ToString() == "upcoming")
                        { %>
            <div class="row">
                                         <asp:Button ID="btn_AssignDoctor" runat="server" Text="Assign Doctor" CssClass="btn_Rsch bg-primary text-white col-3 align-content-end ml-2" OnClick="btn_AdOnClick" />
                                         <span class="col-1"></span>
                                    <asp:Button ID="btn_Rsch" runat="server" Text="Reschedule" CssClass="btn_Rsch bg-primary text-white col-3 align-content-end ml-2" OnClick="btn_RschOnClick" />
                                    <span class="col-1"></span>
                                    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" CssClass="btn_Cancel bg-white text-primary btn-outline-primary col-3" OnClick="btn_CancelOnClick" />


            </div>
                                <% } %>

        </div>
            </ItemTemplate>
                    <EmptyDataTemplate> No Record Found </EmptyDataTemplate>
        </asp:ListView>
        <asp:DataPager ID="dp_listview_appt" runat="server" PagedControlID="listview_appts" PageSize="2">
            <Fields>
                <asp:NumericPagerField ButtonType="Link" />
            </Fields>
        </asp:DataPager>






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
