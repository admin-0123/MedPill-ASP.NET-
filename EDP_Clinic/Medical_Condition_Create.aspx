<%@ Page Title="Add Medical Condition" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Medical_Condition_Create.aspx.cs" Inherits="EDP_Clinic.Medical_Condition_Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5">
        <div class="container">
            <h2 class="mb-5">Add Patient Medical Condition</h2>
            <div class="row mb-5">
                <div class="col-md-6">
                    <asp:Label ID="lb_error" runat="server"></asp:Label>
                    <div class="form-group">
                        <asp:Label ID="patientLbl" runat="server" Text="Patient Name" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_patient" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="dateLbl" runat="server" Text="Diagnosis Date" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_date" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="doctorLbl" runat="server" Text="Doctor in charge" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="dp_doctor" runat="server" CssClass="custom-select">
                            <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                            <asp:ListItem>Dr Ong</asp:ListItem>
                            <asp:ListItem>Dr Wong</asp:ListItem>
                            <asp:ListItem>Dr Song</asp:ListItem>
                            <asp:ListItem>Dr Long</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="clinicLbl" runat="server" Text="Clinic of diagnosis" CssClass="form-label"></asp:Label>
                        <asp:DropDownList ID="dp_clinic" runat="server" CssClass="custom-select">
                            <asp:ListItem Selected="True" Value="--Select--">--Select--</asp:ListItem>
                            <asp:ListItem>Medpill</asp:ListItem>
                            <asp:ListItem>Singapore General Hospital</asp:ListItem>
                            <asp:ListItem>Tan Tock Seng Hospital</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:Label ID="medicalConLbl" runat="server" Text="Name of Medical Condition" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_med_condition" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="methodsLbl" runat="server" Text="Treatment Methods" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_treatment" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="medDesLbl" runat="server" Text="Medical Condition Description" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_condition_desc" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="patientConLbl" runat="server" Text="Current Patient Condition" CssClass="form-label"></asp:Label>
                        <asp:TextBox ID="tb_patient_condition" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group mb-5">
                <asp:Label ID="doctorCommentLbl" runat="server" Text="Doctor's Comment" CssClass="form-label"></asp:Label>
                <asp:TextBox ID="tb_comments" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="float-right mb-5">
                <asp:Button ID="btn_back" runat="server" Text="Back" class="btn btn-primary btn-lg" OnClick="btn_back_click" />
                <asp:Button ID="btn_update" runat="server" Text="Submit" class="btn btn-primary btn-lg ml-5" OnClick="btn_submit_click" />
            </div>
        </div>
    </section>
</asp:Content>
