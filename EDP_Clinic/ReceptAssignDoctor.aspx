<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReceptAssignDoctor.aspx.cs" Inherits="EDP_Clinic.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
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
                <asp:Button ID="btn_assignDoctor" runat="server" Text="Assign" OnClick="btn_assignDoctor_Click" />
                <asp:Label ID="lbl_updateResult" runat="server"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
