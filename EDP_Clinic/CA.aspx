<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CA.aspx.cs" Inherits="EDP_Clinic.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- had to add this jquery cdn script here to make the jquery code able to run on webpage start,
        did not work on masterpage -->
    <script
        src="https://code.jquery.com/jquery-3.5.1.min.js"
        integrity="sha256-9/aliU8dGd2tb6OSsuzixeV4y/faTqgFtohetphbbj0="
        crossorigin="anonymous"></script>
    <script type="text/javascript">

        $(document).ready(function () {
            $("#test123").hide();
            function show(min, max) {
                var $table = $('#slotTables'), // the table we are using
                    $rows = $table.find('tbody tr'); // the rows we want to select
                min = min ? min - 1 : 0;
                max = max ? max : $rows.length;
                $rows.hide().slice(min, max).show(); // hide all rows, then show only the range we want
                return false;
            }
            show(1, 100)

        });

    </script>
    <style type="text/css">
        table#slotTables tr:nth-child(odd) {
            background-color: #c9d4cc
        }

        table#slotTables tr:nth-child(even) {
            background-color: #fff;
        }

        .auto-style4 {
            width: 74px;
            height: 44px;
        }

        .auto-style5 {
            height: 44px;
        }

        #Btn_LoadMore {
            border-radius: 15px;
        }

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
    </style>
    </asp:Content>
    <asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="container">
            <nav aria-label="breadcrumb">
                <ol class="breadcrumb">
                    <li class="breadcrumb-item active">Appointments</li>
                    <li class="breadcrumb-item active">Johnny Lim </li>
                    <li class="breadcrumb-item" aria-current="page"><a href="">New Appointment </a></li>
                </ol>
            </nav>
            <h2 id="test123">Book an Appointment </h2>
            <p>&nbsp;</p>
            <p>&nbsp;</p>
            <div class="card-header">
                <div class="row">
                    <div class="col-3">
                        <span class="fa fa-arrow-left" style="height: inherit"></span>
                        &nbsp
                    <img src="assets/images/profileImage_placeholder.png" class="auto-style6"></img>
                    </div>
                    <div class="col-9">
                        <p style="vertical-align: middle; margin-top: 10px; color: black;">Johnny Lim </p>
                    </div>
                </div>
            </div>
            <p>&nbsp;</p>
            <p>
                <asp:Label ID="Label1" runat="server" Text="Appointment Type:"></asp:Label>
                &nbsp;<asp:DropDownList ID="DropDownList1" runat="server">
                    <asp:ListItem>Consultation</asp:ListItem>
                    <asp:ListItem>Diagnosis</asp:ListItem>
                    <asp:ListItem>Treatment</asp:ListItem>
                </asp:DropDownList>
            </p>
            <p>&nbsp;</p>
            <asp:TextBox ID="tb_startdate" runat="server" placeholder="DD/MM/YYYY"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="tb_startdate_CalendarExtender" runat="server" BehaviorID="TextBox2_CalendarExtender" TargetControlID="tb_startdate" Format="dd/MM/yyyy" />
            <asp:Button ID="btn_searchSlot" runat="server" Text="Search" OnClick="btn_searchSlot_Click"/>
            <br />
            <asp:Label ID="lbl_validDates" runat="server"></asp:Label>



            <div>

                <p class="bg-primary text-light" style="text-align: center;">Available Slots </p>
            </div>

            <table style="background-color: #FFFFFF; background-repeat: no-repeat;" id="slotTables" class="w-100">
                <% foreach (var timeslot in mySlots) { %>
                <tr>
                    <td class="auto-style4">
                        <div class="custom-control custom-radio ml-4">
                            <input type="radio" class="custom-control-input" id="<%= timeslot %>" name="example1" value="<%= timeslot %>">
                            <label class="custom-control-label" for="<%= timeslot %>"></label>
                        </div>
                    </td>
                    <td class="auto-style5"><%= timeslot %></td>
                </tr>
                <% } %>
                <!--
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="Button3" runat="server" Text="Select" />
                        </td>
                        <td class="auto-style5">03 Dec 2020 (Thu), 03:00 PM</td>
                    </tr>
                    <tr>
                        <td class="auto-style4">
                            <asp:Button ID="Button4" runat="server" Text="Select" />
                        </td>
                        <td class="auto-style5">04 Dec 2020 (Fri), 03:30 PM</td>
                    </tr>
            -->
    </table>
        <p>
            &nbsp;
        </p>
    <p>
        <a href="#" class="load_more">Load more</a>
        <asp:Button ID="Btn_LoadMore" runat="server" Text="Load More" Width="1110px" CssClass="btn btn-primary" />
    </p>

    <div>
        <br />
    </div>
    <div class="row">
        <div class="col-lg-1"></div>
        <div class="col-lg-5">
            <asp:Button ID="Button5" runat="server" Text="Next" Width="463px" CssClass="btn btn-primary" />
        </div>
        <div class="col-lg-5">
            <asp:Button ID="Button6" runat="server" Text="Cancel" Width="463px" CssClass="btn btn-link btn-outline-primary" />
        </div>
        <div class="col-lg-1"></div>
    </div>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    <p>&nbsp;</p>
    </div>


</asp:Content>


