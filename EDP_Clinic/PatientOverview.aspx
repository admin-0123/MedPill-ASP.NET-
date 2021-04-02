<%@ Page Title="Patient Overview" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PatientOverview.aspx.cs" Inherits="EDP_Clinic.PatientOverview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
    <style>
        .pagination {
            float: right;
            margin: 0 0 5px;
        }

            .pagination li a {
                border: none;
                font-size: 13px;
                min-width: 30px;
                min-height: 30px;
                color: #999;
                margin: 0 2px;
                line-height: 30px;
                border-radius: 2px !important;
                text-align: center;
                padding: 0 6px;
            }

                .pagination li a:hover {
                    color: #666;
                }

            .pagination li.active a, .pagination li.active a.page-link {
                background: #03A9F4;
            }

                .pagination li.active a:hover {
                    background: #0397d6;
                }

            .pagination li.disabled i {
                color: #ccc;
            }

            .pagination li i {
                font-size: 16px;
                padding-top: 6px
            }

    </style>
    <script>
        $(document).ready(function () {
            // Activate tooltip
            $('[data-toggle="tooltip"]').tooltip();

            // Select/Deselect checkboxes
            var checkbox = $('table tbody input[type="checkbox"]');
            $("#selectAll").click(function () {
                if (this.checked) {
                    checkbox.each(function () {
                        this.checked = true;
                    });
                } else {
                    checkbox.each(function () {
                        this.checked = false;
                    });
                }
            });
            checkbox.click(function () {
                if (!this.checked) {
                    $("#selectAll").prop("checked", false);
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5">
        <div class="container">
            <h2 class="mb-5">Patient Overview</h2>
            <div class="mx-auto">
                <div class="row mb-5">
                    <div class="col-sm-6">
                        <div class="btn-group">
                            <asp:Button ID="ViewReport" runat="server" Text="View Reports" OnClick="ViewReport_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="ViewPatientBtn" runat="server" Text="View Patients" OnClick="ViewPatients_Click" CssClass="btn btn-primary" />
                            <asp:Button ID="ViewCaretakerBtn" runat="server" Text="View Caretakers" OnClick="ViewCaretaker_Click" CssClass="btn btn-primary" />
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <asp:LinkButton ID="RefreshBtn" runat="server" OnClick="RefreshBtn_Click" CssClass="btn btn-primary">
                                <span class="text-white">Refresh&nbsp</span>
                                <i class="fas fa-sync-alt"></i>
                                </asp:LinkButton>
                            </div>
                            <asp:TextBox ID="searchtb" runat="server" CssClass="form-control" Placeholder="Search..."></asp:TextBox>
                            <div class="input-group-append">
                                <asp:LinkButton ID="SearchBtn" runat="server" OnClick="SearchBtn_Click" CssClass="btn btn-primary">
                                     <span class="text-white">Search&nbsp</span>
                                     <i class="fas fa-search"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="btn-group mb-5">
                    <asp:Button ID="btn_med_condition" runat="server" OnClick="Med_Condition_Click" Text="Medical Condition" CssClass="btn btn-primary" />
                    <asp:Button ID="btn_send_cert" runat="server" OnClick="btn_send_cert_Click" Text="Send Medical Certificate" CssClass="btn btn-primary" />
                </div>
                <asp:GridView ID="PatientGridView"
                    CssClass="table table-striped table-bordered table-hover"
                    runat="server"
                    EmptyDataText="No data is available">
                    <EmptyDataRowStyle
                        CssClass="mb-3 mt-5 text-center" />
                </asp:GridView>
            </div>
        </div>
    </section>
</asp:Content>
