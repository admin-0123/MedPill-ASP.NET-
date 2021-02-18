<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RA_Success_admin.aspx.cs" Inherits="EDP_Clinic.RA_Success_admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-12 h2">
                  <asp:Label ID="lbl_success_msg" runat="server" Text="Booking success"></asp:Label>
            </div>
            <div class="col-lg-12">
                  <asp:Label ID="lbl_apptdetails" runat="server" Text="Appointment details:" CssClass="h5"></asp:Label>
            </div>
                        <div class="col-lg-12">
                  <asp:Label ID="lbl_apptType" runat="server" Text="Type: " CssClass="h5"></asp:Label>
            </div>
                       <div class="col-lg-12">
                  <asp:Label ID="lbl_doctorname" runat="server" Text="Doctor: " CssClass="h5"></asp:Label>
            </div>
            <div class="col-lg-12">
                  <asp:Label ID="lbl_patientname" runat="server" Text="Patient: " CssClass="h5"></asp:Label>
            </div>
            <div class="col-lg-12">
                  <asp:Label ID="lbl_datetime" runat="server" Text="Date Time: " CssClass="h5"></asp:Label>
            </div>
        </div>
        <div class="row">
             <div class="col-lg-3 col-md-4">
                            <asp:Button ID="btn_go_dashboard" runat="server" Text="Dashboard" BorderStyle="None" CssClass="bg-primary text-white mt-4 btn_block btn-sm" OnClick="btn_go_receptpage_Click" />
            </div>
            <div class="col-lg-3 col-md-4">
                           <asp:Button ID="btn_go_pfa" runat="server" Text="Appointment" BorderStyle="None" CssClass="bg-primary text-white mt-4 btn_block btn-sm" OnClick="btn_go_pfa_Click" />
            </div>
        </div>


    </div>
</asp:Content>