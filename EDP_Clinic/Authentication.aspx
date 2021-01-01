<%@ Page Title="Authentication" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authentication.aspx.cs" Inherits="EDP_Clinic.Authentication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="changePaymentInfo" style="height:100vh;">
       <div class="container py-lg-3">
           <h1 class="title mb-4">Verify your Identity</h1>
           <p class="mb-4">Click <a href="/">here</a> to resend your SMS.</p>
            <div class="contact-form">
               <form id="authenticationForm">
                   <div class="mb-3">
                       <label>6-digit OTP</label>
                       <asp:TextBox ID="OTPTB" runat="server" placeholder="6-digit OTP" CssClass="form-control" Width="200px" onkeyup="validateToken()"></asp:TextBox>
                       <asp:Label ID="OTPError" runat="server"></asp:Label>
                   </div>
                   <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response"/>
                   <asp:Button ID="verifyBtn" runat="server" Text="Verify" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="verifyBtn_Click" />
               </form>
            </div>
       </div>
    </section>
    <!--- Recaptcha --->
    <script>
        grecaptcha.ready(function () {
            grecaptcha.execute('6LejmBwaAAAAAIDSwI7BQzo5s3UO3qDlAztog9Uh', { action: 'Submit' }).then(function (token) {
                document.getElementById("g-recaptcha-response").value = token;
            });
        });
    </script>
    <script type="text/javascript">
        function validateToken() {
            var OTP = document.getElementById('<%=OTPTB.ClientID%>').value;

            if (OTP.length <= 0) {
                document.getElementById('<%=OTPError.ClientID%>').innerHTML = "Please enter your OTP";
                document.getElementById('<%=OTPError.ClientID%>').style.color = "Red";
                document.getElementById('<%=verifyBtn.ClientID%>').disabled = true;
            }
            else if (OTP.length != 4) {
                document.getElementById('<%=OTPError.ClientID%>').innerHTML = "Please enter a 4-digit OTP number";
                document.getElementById('<%=OTPError.ClientID%>').style.color = "Red";
                document.getElementById('<%=verifyBtn.ClientID%>').disabled = true;
            }
            else if (OTP.search(/[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=OTPError.ClientID%>').innerHTML = "Please enter a valid OTP number";
                document.getElementById('<%=OTPError.ClientID%>').style.color = "Red";
                document.getElementById('<%=verifyBtn.ClientID%>').disabled = true;
            }
            else if (OTP.search(/[A-Z]/) != -1) {
                document.getElementById('<%=OTPError.ClientID%>').innerHTML = "Please enter a valid OTP number";
                document.getElementById('<%=OTPError.ClientID%>').style.color = "Red";
                document.getElementById('<%=verifyBtn.ClientID%>').disabled = true;
            }
            else if (OTP.search(/[a-z]/) != -1) {
                document.getElementById('<%=OTPError.ClientID%>').innerHTML = "Please enter a valid OTP number";
                document.getElementById('<%=OTPError.ClientID%>').style.color = "Red";
                document.getElementById('<%=verifyBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=OTPError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=OTPError.ClientID%>').style.color = "Green";
                document.getElementById('<%=verifyBtn.ClientID%>').disabled = false;
            }
        }
    </script>
</asp:Content>
