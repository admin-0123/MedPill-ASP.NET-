<%@ Page Title="Medical Reports" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MedicalReports.aspx.cs" Inherits="EDP_Clinic.Create_Report" %>

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

        .hint-text {
            float: left;
            margin-top: 10px;
            font-size: 13px;
        }
        /* Custom checkbox */
        .custom-checkbox {
            position: relative;
        }

            .custom-checkbox input[type="checkbox"] {
                opacity: 0;
                position: absolute;
                margin: 5px 0 0 3px;
                z-index: 9;
            }

            .custom-checkbox label:before {
                width: 18px;
                height: 18px;
            }

            .custom-checkbox label:before {
                content: '';
                margin-right: 10px;
                display: inline-block;
                vertical-align: text-top;
                background: white;
                border: 1px solid #bbb;
                border-radius: 2px;
                box-sizing: border-box;
                z-index: 2;
            }

            .custom-checkbox input[type="checkbox"]:checked + label:after {
                content: '';
                position: absolute;
                left: 6px;
                top: 3px;
                width: 6px;
                height: 11px;
                border: solid #000;
                border-width: 0 3px 3px 0;
                transform: inherit;
                z-index: 3;
                transform: rotateZ(45deg);
            }

            .custom-checkbox input[type="checkbox"]:checked + label:before {
                border-color: #03A9F4;
                background: #03A9F4;
            }

            .custom-checkbox input[type="checkbox"]:checked + label:after {
                border-color: #fff;
            }

            .custom-checkbox input[type="checkbox"]:disabled + label:before {
                color: #b8b8b8;
                cursor: auto;
                box-shadow: none;
                background: #ddd;
            }
        /* Modal styles */
        .modal .modal-dialog {
            max-width: 400px;
        }

        .modal .modal-header, .modal .modal-body, .modal .modal-footer {
            padding: 20px 30px;
        }

        .modal .modal-content {
            border-radius: 3px;
            font-size: 14px;
        }

        .modal .modal-footer {
            background: #ecf0f1;
            border-radius: 0 0 3px 3px;
        }

        .modal .modal-title {
            display: inline-block;
        }

        .modal .form-control {
            border-radius: 2px;
            box-shadow: none;
            border-color: #dddddd;
        }

        .modal textarea.form-control {
            resize: vertical;
        }

        .modal .btn {
            border-radius: 2px;
            min-width: 100px;
        }

        .modal form label {
            font-weight: normal;
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
            <h2 class="mb-5">Medical Reports</h2>
            <div class="mx-auto">
                <div class="row mb-5">
                    <div class="col-sm-6">
                    </div>
                    <div class="col-sm-6">
                    </div>
                </div>
                <div class="mb-5">
                    <asp:Button ID="addReportBtn" runat="server" Text="+ Add New Report" CssClass="btn btn-success" OnClick="btn_submit_add" />
                </div>
                <asp:GridView ID="gv_report" runat="server"
                    CssClass="table table-striped table-bordered table-hover"
                    AutoGenerateColumns="False" OnRowCommand="gv_report_RowCommand1"
                    OnPreRender="gv_report_PreRender" OnPageIndexChanging="gv_report_PageIndexChanging"
                    AllowPaging="True" PageSize="5" EmptyDataText="No data is available">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" />
                        <asp:BoundField DataField="Dname" HeaderText="Doctor in charge" ReadOnly="True" />
                        <asp:BoundField DataField="Pname" HeaderText="Patient" ReadOnly="True" />
                        <asp:BoundField DataField="Clinic" HeaderText="Clinic" ReadOnly="True" />
                        <asp:BoundField DataField="Date_of_report" HeaderText="Date of report" ReadOnly="True" />
                        <asp:BoundField DataField="Details" HeaderText="Details" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Update">
                            <ItemTemplate>
                                <asp:Button ID="btn_update" runat="server" Text="Update" CommandArgument='<%# Eval("Id") %>' CommandName="editing" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="4" />
                    <EmptyDataRowStyle
                        CssClass="mb-3 mt-5 text-center" />
                </asp:GridView>
            </div>
            <div class="clearfix">
            </div>
        </div>
    </section>
</asp:Content>
