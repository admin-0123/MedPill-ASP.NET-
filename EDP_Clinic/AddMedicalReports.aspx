<%@ Page Title="Add Medical Report" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMedicalReports.aspx.cs" Inherits="EDP_Clinic.Patient_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5">
        <div class="container">
            <h2 class="mb-5">Add Medical Report</h2>
            <div class="row mb-5">
                <div class="col-md-6">
                    <asp:Label ID="lb_error" runat="server"></asp:Label>
                    <div class="form-group">
                        <asp:Label ID="doctorSelectLbl" runat="server" Text="Doctor in charge" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="dp_doctor" runat="server" CssClass="custom-select">
                            <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                            <asp:ListItem>Dr Ong</asp:ListItem>
                            <asp:ListItem>Dr Wong</asp:ListItem>
                            <asp:ListItem>Dr Song</asp:ListItem>
                            <asp:ListItem>Dr Long</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="clinicSelectLbl" runat="server" Text="Clinic Name" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="dp_clinic" runat="server" CssClass="custom-select">
                            <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                            <asp:ListItem>Medpill</asp:ListItem>
                            <asp:ListItem>Singapore General Hospital</asp:ListItem>
                            <asp:ListItem>Tan Tock Seng Hospital</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="reportDetailLbl" runat="server" Text="Report Details" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_details" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="d-flex justify-content-between">
                        <asp:Button ID="btn_back" runat="server" Text="Back" class="btn btn-primary btn-lg" OnClick="btn_back_click" />
                        <asp:Button ID="btn_submit" runat="server" Text="Submit" class="btn btn-primary btn-lg text-right" OnClick="btn_submit_info" />
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="patientLbl" runat="server" Text="Patient Name" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_patient" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="reportDateLbl" runat="server" Text="Date of Report" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_date" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
