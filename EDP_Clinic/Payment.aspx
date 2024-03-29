﻿<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="EDP_Clinic.Payment" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
    <script src="https://js.stripe.com/v3/"></script>
    <script type="text/javascript" src="https://www.paypal.com/sdk/js?client-id=AT9DJyeJMIR8vwF_hXg51sixRS0sEi3gKj6NZIzrlFq0JdlldbY5NKstWc6AYYNYiNIjZz4xLwnac153">
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="payment">
        <div class="container py-lg-3">
            <div class="mb-3">
                <asp:Button ID="backBtn" runat="server" Text="Back" CssClass="btn btn-primary btn-style" OnClick="backBtn_Click" />
            </div>
            <h1 class="title mb-4">Payment</h1>
            <div class="row mt-5">
                <div class="col-md-8">
                    <div class="contact-form">
                        <div class="mb-3">
                            <h4 class="mb-3">
                                <asp:Label ID="errorMsg" runat="server" CssClass="mb-3" Visible="False"></asp:Label></h4>
                            <h5 class="title mb-3">Choose existing card information</h5>
                            <p class="mb-3">Choosing your stored card information will complete the following transaction.</p>
                            <asp:ListView ID="cardListView" runat="server" OnItemCommand="cardListView_ItemCommand">
                                <ItemTemplate>
                                    <div class="card mb-3">
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-md-10">
                                                    <h5 class="card-title">Card No.:
                                        <asp:Label ID="cardNumber" runat="server" Text='<%# "**** **** **** " + Eval("CardNumber").ToString().Substring(12,4) %>'></asp:Label></h5>
                                                </div>
                                                <div class="col-md-2">
                                                    <asp:LinkButton ID="moreBtn" runat="server" CssClass="btn btn-primary" CommandName="payNow" CommandArgument='<%# Eval("UniqueIdentifier") %>'>Select</asp:LinkButton>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <EmptyDataTemplate>
                                    <div class="mb-5 mt-5 text-center">
                                        <h5 class="title mb-5">There is currently no card information stored.</h5>
                                    </div>
                                </EmptyDataTemplate>
                            </asp:ListView>
                        </div>
                        <hr />
                        <div class="mb-3">
                            <h5 class="title mb-3">Add your own card information</h5>
                            <form id="paymentForm">
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
                                            <asp:TextBox ID="cardExpiryTB" runat="server" type="month" placeholder="Card Expiry (MM YY)" CssClass="form-control" onkeyup="cardExpiryValidation()" ToolTip="Card Expiry (MM YYYY)"></asp:TextBox>
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
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6"></div>
                            <div class="col-md-4">
                                <div id="paypal-button-container"></div>
                                <%--<asp:Button ID="payPalBtn" runat="server" Text="Proceed to Paypal" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="200px" ToolTip="Pay by PayPal" OnClick="payPalBtn_Click" />--%>
                            </div>
                            <div class="col-md-2">
                                <input type="hidden" id="g-recaptcha-response" name="g-recaptcha-response" />
                                <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn btn-primary" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="submitBtn_Click" ToolTip="Submit" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4 mt-md-0 mt-5 w3-contact-address">
                    <h2 class="title">Receipt</h2>
                    <hr />
                    <div class="row">
                        <div class="col-6">
                            <p>Service</p>
                        </div>
                        <div class="col-6">
                            <p>Amount (S$)</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <p>Consultation Fee</p>
                        </div>
                        <div class="col-6">
                            <p>100</p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-6">
                            <p>Medication</p>
                        </div>
                        <div class="col-6">
                            <p>100</p>
                        </div>
                    </div>
                    <hr />
                    <div class="row">
                        <div class="col-6">
                            <h4>Total (S$)</h4>
                        </div>
                        <div class="col-6">
                            <h4>200</h4>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- Start of ChatBot (www.chatbot.com) code -->
    <script type="text/javascript">
        window.__be = window.__be || {};
        window.__be.id = "6027c466643262000724c24d";
        (function () {
            var be = document.createElement('script'); be.type = 'text/javascript'; be.async = true;
            be.src = ('https:' == document.location.protocol ? 'https://' : 'http://') + 'cdn.chatbot.com/widget/plugin.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(be, s);
        })();
    </script>
    <!-- End of ChatBot code -->
    <script>
        // Render the PayPal button into #paypal-button-container
        paypal.Buttons({
            env: 'sandbox',
            style: {
                layout: 'horizontal',
                size: 'responsive'
            },
            // Set up the transaction
            createOrder: function (data, actions) {
                return actions.order.create({
                    purchase_units: [{
                        amount: {
                            value: '200.00',
                            currency: "SGD"
                        }
                    }]
                });
            },

            // Finalize the transaction
            onApprove: function (data, actions) {
                return actions.order.capture().then(function (details) {
                    // Show a success message to the buyer
                    //alert('Transaction completed by ' + details.payer.name.given_name + '!');
                    //Modify the link below
                    console.log(details);
                    window.location.replace('https://localhost:44310/AfterPayment.aspx');
                });
            },
            // Show an error message here, when an error occurs
            onError: function (err) {
                document.getElementById('<%=errorMsg.ClientID%>').innerHTML = "Please ensure that you have the right PayPal Credentials.";
                document.getElementById('<%=errorMsg.ClientID%>').style.color = "Red";
            }
        })
            .render('#paypal-button-container');
    </script>
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
            console.log(nameOnCard.search(/[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/));
            if (nameOnCard.length <= 0) {
                document.getElementById('<%=nameOnCardError.ClientID%>').innerHTML = "Please enter your name on card";
                document.getElementById('<%=nameOnCardError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            //ensures that no special characters are in the cardnameTB
            else if (nameOnCard.search(/[`!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=nameOnCardError.ClientID%>').innerHTML = "Please enter a valid name on card";
                document.getElementById('<%=nameOnCardError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=nameOnCardError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=nameOnCardError.ClientID%>').style.color = "Green";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = false;
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
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.length != 16) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter your 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.search(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter a valid 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.search(/[A-Z]/) != -1) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter a valid 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cardNumber.search(/[a-z]/) != -1) {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Please enter a valid 16-digit card number";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=cardNumberError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=cardNumberError.ClientID%>').style.color = "Green";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = false;
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
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (currentDate.getMonth() > cardExpiry.getMonth()) {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Please ensure that your card is not expired";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (monthDifference < 3) {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Please ensure that your card expiries 3 months from now";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=cardExpiryError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=cardExpiryError.ClientID%>').style.color = "Green";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = false;
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
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.length != 3) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter your 3-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.search(/[ `!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?~]/) != -1) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter a valid 3-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.search(/[A-Z]/) != -1) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter a valid 3-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else if (cvvNumber.search(/[a-z]/) != -1) {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Please enter a valid 3-digit CVV number";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Red";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = true;
            }
            else {
                document.getElementById('<%=CVVError.ClientID%>').innerHTML = "Excellent";
                document.getElementById('<%=CVVError.ClientID%>').style.color = "Green";
                document.getElementById('<%=submitBtn.ClientID%>').disabled = false;
            }
        }
    </script>
</asp:Content>
