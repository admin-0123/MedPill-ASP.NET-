<%@ Page Language="C#" Title="Card Update" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="changeCardInfo.aspx.cs" Inherits="EDP_Clinic.changeCardInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="changePaymentInfo">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <h1 class="title mb-4">Change Card Information</h1>
            <div class="row">
                <div class="col-md-8">
                    <hr />
                    <h5 class="title mb-4">Current Card Info</h5>
                </div>
                <div class="col-md-4">
                    <div onclick="showInfo()">
                        <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="currentColor" class="bi bi-eye" viewBox="0 0 16 16" id="eyeVisible">
                            <path d="M16 8s-3-5.5-8-5.5S0 8 0 8s3 5.5 8 5.5S16 8 16 8zM1.173 8a13.133 13.133 0 0 1 1.66-2.043C4.12 4.668 5.88 3.5 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.133 13.133 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755C11.879 11.332 10.119 12.5 8 12.5c-2.12 0-3.879-1.168-5.168-2.457A13.134 13.134 0 0 1 1.172 8z" />
                            <path d="M8 5.5a2.5 2.5 0 1 0 0 5 2.5 2.5 0 0 0 0-5zM4.5 8a3.5 3.5 0 1 1 7 0 3.5 3.5 0 0 1-7 0z" />
                        </svg>
                        <svg xmlns="http://www.w3.org/2000/svg" width="32" height="32" fill="currentColor" class="bi bi-eye-slash" viewBox="0 0 16 16" id="eyeInvisible">
                            <path d="M13.359 11.238C15.06 9.72 16 8 16 8s-3-5.5-8-5.5a7.028 7.028 0 0 0-2.79.588l.77.771A5.944 5.944 0 0 1 8 3.5c2.12 0 3.879 1.168 5.168 2.457A13.134 13.134 0 0 1 14.828 8c-.058.087-.122.183-.195.288-.335.48-.83 1.12-1.465 1.755-.165.165-.337.328-.517.486l.708.709z" />
                            <path d="M11.297 9.176a3.5 3.5 0 0 0-4.474-4.474l.823.823a2.5 2.5 0 0 1 2.829 2.829l.822.822zm-2.943 1.299l.822.822a3.5 3.5 0 0 1-4.474-4.474l.823.823a2.5 2.5 0 0 0 2.829 2.829z" />
                            <path d="M3.35 5.47c-.18.16-.353.322-.518.487A13.134 13.134 0 0 0 1.172 8l.195.288c.335.48.83 1.12 1.465 1.755C4.121 11.332 5.881 12.5 8 12.5c.716 0 1.39-.133 2.02-.36l.77.772A7.029 7.029 0 0 1 8 13.5C3 13.5 0 8 0 8s.939-1.721 2.641-3.238l.708.709zm10.296 8.884l-12-12 .708-.708 12 12-.708.708z" />
                        </svg>
                    </div>
                </div>
            </div>
            <div class="row" id="currentCardDiv">
                <div class="col-md-8">
                    <div class="contact-form">
                        <form id="currentCardInfo">
                            <div class="mb-3">
                                <label>Name on Card</label>
                                <asp:TextBox ID="nameOnCardResult" runat="server" placeholder="Name On Card" CssClass="form-control" ToolTip="Name On Card" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label>Card Number</label>
                                <asp:TextBox ID="cardNumberResult" runat="server" placeholder="Name On Card" CssClass="form-control" ToolTip="Card Number" Enabled="False"></asp:TextBox>
                            </div>
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label>Card Expiry (MM YYYY)</label>
                                        <asp:TextBox ID="cardExpiryResult" runat="server" type="month" placeholder="Card Expiry (MM YYYY)" CssClass="form-control" ToolTip="Card Expiry (MM YY)" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label>CVV Number</label>
                                        <asp:TextBox ID="cvvNumberResult" runat="server" placeholder="CVV Number" CssClass="form-control" ToolTip="CVV Number" Enabled="False"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
            </div>
            <h5 class="title mb-4">New Card Info</h5>
            <div class="row">
                <div class="col-md-8">
                    <div class="contact-form">
                        <form id="changeCardForm">
                            <asp:Label ID="errorMsg" runat="server"></asp:Label>
                            <div class="mb-3">
                                <label>Name on Card</label>
                                <asp:TextBox ID="nameOnCardTB" runat="server" placeholder="Name On Card" CssClass="form-control" onkeyup="nameOnCardValidation()" ToolTip="Name On Card"></asp:TextBox>
                                <asp:Label ID="nameOnCardError" runat="server"></asp:Label>
                            </div>
                            <div class="mb-3">
                                <label>Card Number</label>
                                <asp:TextBox ID="cardNumberTB" runat="server" placeholder="Card Number" CssClass="form-control" onkeyup="cardNumberValidation()" ToolTip="Card Number"></asp:TextBox>
                                <asp:Label ID="cardNumberError" runat="server"></asp:Label>
                            </div>
                            <div class="row mb-3">
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label>Card Expiry (MM YYYY)</label>
                                        <asp:TextBox ID="cardExpiryTB" runat="server" type="month" placeholder="Card Expiry (MM YYYY)" CssClass="form-control" onkeyup="cardExpiryValidation()" ToolTip="Card Expiry (MM YY)"></asp:TextBox>
                                        <asp:Label ID="cardExpiryError" runat="server"></asp:Label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="mb-3">
                                        <label>CVV Number</label>
                                        <asp:TextBox ID="CVVTB" runat="server" placeholder="CVV Number" CssClass="form-control" onkeyup="cvvNumberValidation()" ToolTip="CVV Number"></asp:TextBox>
                                        <asp:Label ID="CVVError" runat="server"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </form>
                        <div class="row">
                            <div class="col-md-10"></div>
                            <div class="col-md-2">
                                <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                                <asp:Button ID="updateBtn" runat="server" Text="Submit" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="updateBtn_Click" ToolTip="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">
                </div>
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
    <!--- nameOnCard Validation --->
    <script type="text/javascript">
        function nameOnCardValidation() {
            var nameOnCard = document.getElementById('<%=nameOnCardTB.ClientID%>').value;
            //console.log(nameOnCard.search(/[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/));
            if (nameOnCard.length <= 0) {
                document.getElementById('<%=nameOnCardError.ClientID%>').innerHTML = "Please enter your name on card";
                document.getElementById('<%=nameOnCardError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            //ensures that no special characters are in the cardnameTB
            else if (nameOnCard.search(/[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=nameOnCardError.ClientID%>').innerHTML = "Please enter a valid name on card";
                document.getElementById('<%=nameOnCardError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=nameOnCardError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=nameOnCardError.ClientID%>').style.color = "Green";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = false;
            }
        }
    </script>
    <!--- cardNumber Validation --->
    <script type="text/javascript">
        function cardNumberValidation() {
            var cardNumber = document.getElementById('<%=cardNumberTB.ClientID%>').value;

            if (cardNumber.length <= 0) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter your card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.length != 16) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter your 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.search(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter a valid 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.search(/[A-Z]/) != -1) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter a valid 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.search(/[a-z]/) != -1) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter a valid 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Green";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = false;
            }
        }
    </script>
    <!--- cardExpiry Validation --->
    <script type="text/javascript">
        function cardExpiryValidation() {
            var cardExpiry = document.getElementById('<%=cardExpiryTB.ClientID%>').value;
            var currentDate = new Date();
            var monthDifference = currentDate.getMonth() - cardExpiry.getMonth();


            if (cardExpiry.length <= 0) {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Please choose your card expiry date";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (currentDate.getMonth() > cardExpiry.getMonth()) {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Please ensure that your card is not expired";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (monthDifference < 3) {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Please ensure that your card expiries 3 months from now";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Green";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = false;
            }

        }
    </script>
    <!--- cvvNumber Validation --->
    <script type="text/javascript">
        function cvvNumberValidation() {
            var cvvNumber = document.getElementById('<%=CVVTB.ClientID%>').value;

            if (cvvNumber.length <= 0) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter your CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.length != 4) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter your 4-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.search(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter a valid 4-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.search(/[A-Z]/) != -1) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter a valid 4-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.search(/[a-z]/) != -1) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter a valid 4-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Green";
                document.getElementById('<%=updateBtn.ClientID%>').disabled = false;
            }
        }
    </script>
    <script type="text/javascript">
        var eyeVisible = document.getElementById("eyeVisible");
        var eyeInvisible = document.getElementById("eyeInvisible");
        var currentInfo = document.getElementById("currentCardDiv");

        eyeInvisible.addEventListener("load", eyeInvisible.style.display = "none")

        function showInfo() {
            if (currentInfo.style.display === "none") {
                currentInfo.style.display = "block";
                eyeInvisible.style.display = "none";
                eyeVisible.style.display = "block";
            } else {
                currentInfo.style.display = "none";
                eyeInvisible.style.display = "block";
                eyeVisible.style.display = "none";
            }
        }
    </script>
</asp:Content>
