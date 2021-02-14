<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceptAssignDoctor.aspx.cs" Inherits="EDP_Clinic.ReceptAssignDoctor" %>
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


                                            .btn_assignDoctor {
            border-radius:15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

                <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
  <ol class="breadcrumb">
      <li class="breadcrumb-item active">
              <asp:HyperLink ID="hl_bc_appt" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/receptionistPage.aspx">User Page</asp:HyperLink></asp:Label>
      </li>
            <li class="breadcrumb-item active">
              <asp:HyperLink ID="HyperLink1" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/ReceptAppts.aspx">Receptionist Appointment Control</asp:HyperLink></asp:Label>
      </li>
    <li class="breadcrumb-item active" aria-current="page"> 
        <asp:HyperLink ID="hl_bc_profileName" runat="server" CssClass="hyperlink_breadcrumb_active"> </asp:HyperLink></asp:Label>
      </li>
    <li class="breadcrumb-item active" aria-current="page"> 
        <asp:HyperLink ID="hl_bc_resch_appt" runat="server" CssClass="hyperlink_breadcrumb_active"></asp:HyperLink>Assign Doctor </asp:Label>
      </li>
  </ol>
</nav>
        <h3 class="h3">
            Assign Doctor
        </h3>
        <div class="row">
            <div class="col-6">
                <p>  Doctor Name: </p>
            </div>
            <div class="col-6">
                                            <asp:DropDownList ID="ddl_chooseDoctors" runat="server"></asp:DropDownList>
            </div>
        </div>

                <div class="row mt-5">
            <div class="col-6">
            </div>
            <div class="col-6">
                <asp:Button ID="btn_assignDoctor" runat="server" Text="Assign" OnClick="btn_assignDoctor_Click" CssClass="btn_assignDoctor btn btn-primary text-white" />
                <asp:Label ID="lbl_updateResult" runat="server"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
