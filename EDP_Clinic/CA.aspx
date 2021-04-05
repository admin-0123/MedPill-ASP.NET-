<%@ Page Title="Appointment Booking" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CA.aspx.cs" Inherits="EDP_Clinic.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- had to add this jquery cdn script here to make the jquery code able to run on webpage start,
        did not work on masterpage -->
    <script
        src="https://code.jquery.com/jquery-3.5.1.min.js"
        integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0="
        crossorigin="anonymous"></script>
    <style type="text/css">
        table#slotTables tr:nth-child(odd) {
            background-color: #c9d4cc
        }

        table#slotTables tr:nth-child(even) {
            background-color: #fff;
        }

        /*        #Btn_LoadMore {
            border-radius: 15px;
        }*/

        /*        select::-ms-expand {
            display:none;
        }*/

        /*        #Btn_LoadMore {
            background-color:deepskyblue;
            color:white;
        }*/
        .auto-style6 {
            max-width: 100%;
            height: 55px;
            width: 66px;
        }


        .breadcrumb-item + .breadcrumb-item::before {
            content: ">";
        }

        .gv_pager td {
            padding-left: 4px;
            padding-right: 4px;
            padding-top: 3px;
            padding-bottom: 3px;
        }

        .btn_cancelAppt:hover {
            background-color: lightgray;
        }


        .hyperlink_breadcrumb {
            color: black;
            text-decoration: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <!-- Breadcrumb -->
        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item active">
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/UserPage.aspx">User Page</asp:HyperLink></asp:Label>
                </li>
                <li class="breadcrumb-item active">
                    <asp:HyperLink ID="hl_bc_appt" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/PFA.aspx">Appointments</asp:HyperLink></asp:Label>
                </li>
                <li class="breadcrumb-item active" aria-current="page">
                    <asp:HyperLink ID="hl_bc_profileName" runat="server" CssClass="hyperlink_breadcrumb" NavigateUrl="~/PRFA2.aspx"></asp:HyperLink></asp:Label>
                </li>
                <li class="breadcrumb-item active" aria-current="page">
                    <asp:HyperLink ID="hl_bc_makeappt" runat="server" CssClass="hyperlink_breadcrumb_active"></asp:HyperLink>Make Appointment</asp:Label>
                </li>
            </ol>
        </nav>
        <h2 class="mb-3">Book an Appointment </h2>
        <div class="card-header mb-5">
            <div class="row">
                <div class="col-sm-12">
                    <!--
                    <span class="fa fa-arrow-left" style="height:inherit"></span>
                    &nbsp
                    <img src="assets/images/profileImage_placeholder.png" width="50px" height="50px"></img>
                                        &nbsp
                    <span> Johnny Lim</span>
                        -->
                    <asp:ImageButton ID="leftArrow_redirect" runat="server" Height="50px" ImageAlign="Left" ImageUrl="~/assets/images/leftArrow.png" Width="50px" OnClick="leftArrow_redirect_Click" />
                    <asp:Image ID="profilePfp" runat="server" ImageUrl="~/assets/images/pfp_placeholder.png" Height="50px" Width="50px" />
                    <asp:Label ID="lbl_profileName" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <div class="mb-3">
            <asp:Label ID="lbl_error_make_appt" runat="server"></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-4">
                <div class="form-group" style="width: 250px;">
                    <asp:Label ID="Label1" runat="server" Text="Appointment Type:"></asp:Label>
                    <asp:DropDownList ID="ddl_apptType" runat="server" CssClass="custom-select">
                        <asp:ListItem>Consultation</asp:ListItem>
                        <asp:ListItem>Diagnosis</asp:ListItem>
                        <asp:ListItem>Treatment</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-md-4">
                <div class="form-group">
                    <asp:Label ID="appointmentDateLbl" runat="server" Text="Search Appointment Date:"></asp:Label>
                    <div class="input-group mb-3" style="width: 250px;">
                        <asp:TextBox ID="tb_startdate" runat="server" placeholder="DD/MM/YYYY" CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="tb_startdate_CalendarExtender" runat="server" BehaviorID="TextBox2_CalendarExtender" TargetControlID="tb_startdate" Format="dd/MM/yyyy" />
                        <div class="input-group-append">
                            <asp:Button ID="btn_searchSlot" runat="server" Text="Search" OnClick="btn_searchSlot_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <asp:Label ID="lbl_validDates" runat="server"></asp:Label>
                </div>
            </div>
            <div class="col-md-4">
            </div>
        </div>
        <div class="mb-5">
            <div>
                <p class="bg-primary text-light mt-3 text-center">Available Slots </p>
            </div>
            <asp:GridView ID="gv_timeslots" runat="server"
                AutoGenerateColumns="False" ClientIDMode="Static"
                AllowPaging="True" BackColor="#99CCFF" CellPadding="2"
                OnPageIndexChanging="gv_timeslots_PageIndexChanging"
                OnSelectedIndexChanged="gv_timeslots_SelectedIndexChanged"
                PageSize="10" Width="100%" CssClass="table">
                <Columns>
                    <asp:TemplateField HeaderText="Select" ItemStyle-Width="75px" ItemStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                            <div class="custom-control custom-radio">
                                <input type="radio" class="custom-control-input" id="<%# Container.DataItem %>" name="rb_apptslot" value="<%# Container.DataItem %>">
                                <label class="custom-control-label" for="<%# Container.DataItem %>"></label>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="75px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Appointment Slot">
                        <ItemTemplate>
                            <asp:Label ID="lbl_apptSlot" runat="server" Text="<%# Container.DataItem %>"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle ForeColor="Black" BorderStyle="None" />
                <PagerSettings Mode="NumericFirstLast" />
                <PagerStyle CssClass="gv_pager" />
            </asp:GridView>
        </div>
        <div class="d-flex justify-content-center mt-3">
            <div class="btn-group">
                <asp:Button ID="btn_createAppt" runat="server" Text="Next" Width="463px" CssClass="btn btn-primary btn-block mt-3" OnClick="btn_createAppt_Click" />
                <asp:Button ID="btn_cancelAppt" runat="server" Text="Cancel" Width="463px" CssClass="btn btn-link btn-outline-primary btn-block mt-3 btn_cancelAppt" OnClick="btn_cancelAppt_Click" />
            </div>
        </div>
    </div>
</asp:Content>
