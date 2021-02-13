<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangeInfo.aspx.cs" Inherits="EDP_Clinic.ChangeInfo" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="changePaymentInfo">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click"  />
            </div>
            <h1 class="title mb-4">Change Information</h1>
            <p>Enter only fields you wish to change</p>
            <div class="row">
                <div class="col-md-8">
                    <div class="contact-form">
                        <form id="changeForm">
                            <asp:Label ID="errorMsg" runat="server"></asp:Label>
                            <div class="mb-3">
                                <label>Name</label>
                                <asp:TextBox ID="nameTB" runat="server"  CssClass="form-control" ></asp:TextBox>
                                <asp:Label ID="nameError" runat="server"></asp:Label>
                            </div>
                            <div class="mb-3">
                                <label>Email</label>
                                <asp:TextBox ID="emailTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="emailError" runat="server"></asp:Label>
                            </div>
                            <div class="mb-3">
                                <label>Phone Number</label>
                                <asp:TextBox ID="phoneTB" runat="server" CssClass="form-control"></asp:TextBox>
                                <asp:Label ID="phoneError" runat="server"></asp:Label>
                            </div>
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label>Password</label>
                                        <asp:TextBox ID="passwordTB" runat="server" CssClass="form-control" ></asp:TextBox>
                                        <asp:Label ID="passError" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label>New Password (Enter to change password)</label>
                                        <asp:TextBox ID="password2TB" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:Label ID="pass2Error" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </form>
                        <div class="row">
                            <div class="col-md-10">
                                <asp:FileUpload ID="imgUpload" runat="server" Width="300px" />
                            </div>
                            <div class="col-md-2">
                                <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                                <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="submitBtn_Click"   />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
        </div>
    </section>
</asp:Content>
