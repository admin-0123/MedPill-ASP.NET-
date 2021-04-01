<%@ Page Title="Admin Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AdminPage.aspx.cs" Inherits="EDP_Clinic.AdminPage" %>

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

        .modal button.close {
            position: relative;
        }

        select::-ms-expand {
            display: block;
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
            <h2 class="title mb-5">Employee Dashboard</h2>
            <div class="mb-5">
                <asp:Label ID="editLbl" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="delLbl" runat="server" Visible="False"></asp:Label>
            </div>
            <div class="mx-auto">
                <div class="row mb-5">
                    <div class="col-sm-4">
                    </div>
                    <div class="col-sm-6">
                        <div class="input-group">
                            <div class="input-group-prepend">
                                <asp:LinkButton ID="RefreshBtn" runat="server" CssClass="btn btn-primary" OnClick="RefreshBtn_Click">
                                        <span class="text-white">Refresh&nbsp</span>
                                            <i class="fas fa-sync-alt"></i>
                                </asp:LinkButton>
                            </div>
                            <asp:TextBox ID="searchtb" runat="server" CssClass="form-control" Placeholder="Search..."></asp:TextBox>
                            <div class="input-group-append">
                                <asp:LinkButton ID="SearchBtn" runat="server" CssClass="btn btn-primary" OnClick="SearchBtn_Click">
                                        <span class="text-white">Search&nbsp</span>
                                            <i class="fas fa-search"></i>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-2">
                        <a href="#addEmployeeModal" class="btn btn-success" data-toggle="modal">
                            <span>+ Add Employee</span>
                        </a>
                    </div>
                </div>
                <asp:GridView ID="EmployeeGridView"
                    AutoGenerateColumns="True" class="table"
                    runat="server" OnRowCommand="EmployeeGridView_RowCommand1" AllowCustomPaging="True"
                    CssClass="table table-striped table-bordered table-hover">
                    <Columns>
                        <asp:ButtonField HeaderText="Edit" CommandName="changeinfo" Text="<i class='far fa-edit'></i>"
                            ButtonType="Link" ControlStyle-CssClass="btn btn-primary">
                            <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                        </asp:ButtonField>
                        <asp:ButtonField HeaderText="Delete" CommandName="deleteinfo" Text="<i class='far fa-trash-alt'></i>"
                            ButtonType="Link" ControlStyle-CssClass="btn btn-primary">
                            <ControlStyle CssClass="btn btn-primary"></ControlStyle>
                        </asp:ButtonField>
                    </Columns>
                    <PagerSettings FirstPageText="First" LastPageText="Last" PageButtonCount="5" />
                </asp:GridView>
            </div>
        </div>
    </section>
    <!-- Add Modal HTML -->
    <div id="addEmployeeModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content p-0">
                <div class="modal-header">
                    <h4 class="title">Add Employee</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="form-label">Name</label>
                        <asp:TextBox ID="tbAddName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Email</label>
                        <asp:TextBox ID="tbAddEmail" runat="server" CssClass="form-control" TextMode="Email" placeholder="someone@example.com"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Role</label>
                        <asp:DropDownList ID="AddRole" runat="server" CssClass="custom-select">
                            <asp:ListItem Value="Doctor">Doctor</asp:ListItem>
                            <asp:ListItem Value="Nurse">Nurse</asp:ListItem>
                            <asp:ListItem Value="Receptionist">Receptionist</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>
                        <label class="form-label">Phone</label>
                        <asp:TextBox ID="tbAddMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Label ID="addError" runat="server" Visible="False"></asp:Label>
                </div>
                <div class="modal-footer">
                    <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                    <asp:Button ID="Button1" runat="server" Text="Add" class="btn btn-info" OnClick="Button1_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Edit Modal HTML -->
    <div id="editEmployeeModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content p-0">
                <div class="modal-header">
                    <h4 class="modal-title">Edit Employee</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <div class="form-group">
                        <label class="form-label">Name</label>
                        <asp:TextBox ID="tbEditName" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Email</label>
                        <asp:TextBox ID="tbEditEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Role</label>
                        <asp:DropDownList ID="EditRole" runat="server" CssClass="custom-select">
                            <asp:ListItem Value="Doctor">Doctor</asp:ListItem>
                            <asp:ListItem Value="Nurse">Nurse</asp:ListItem>
                            <asp:ListItem Value="Receptionist">Receptionist</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="form-label">Phone</label>
                        <asp:TextBox ID="tbEditMobile" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Label ID="editError" runat="server"></asp:Label>
                </div>
                <div class="modal-footer">
                    <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                    <asp:Button ID="Button2" class="btn btn-danger" runat="server" Text="Save" OnClick="editBtn_Click" />
                </div>
            </div>
        </div>
    </div>
    <!-- Delete Modal HTML -->
    <div id="deleteEmployeeModal" class="modal fade">
        <div class="modal-dialog">
            <div class="modal-content p-0">
                <div class="modal-header">
                    <h4 class="modal-title">Delete Employee</h4>
                    <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                </div>
                <div class="modal-body">
                    <p>Are you sure you want to delete this record?</p>
                    <p class="text-danger"><small>This action cannot be undone.</small></p>
                </div>
                <div class="modal-footer">
                    <input type="button" class="btn btn-default" data-dismiss="modal" value="Cancel">
                    <asp:Button ID="delBtn" class="btn btn-danger" runat="server" Text="Delete" OnClick="delBtn_Click" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function openEditModal() {
            $("#editEmployeeModal").modal("show");
        }
        function openDeleteModal() {
            $("#deleteEmployeeModal").modal("show");
        }
        function closeEditModal() {
            $("#editEmployeeModal").modal("hide");
        }
        function closeEditModal() {
            $("#editEmployeeModal").modal("hide");
        }
    </script>
</asp:Content>
