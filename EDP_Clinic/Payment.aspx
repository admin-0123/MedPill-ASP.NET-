<%@ Page Title="Payment" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Payment.aspx.cs" Inherits="EDP_Clinic.Payment" %>
<asp:Content ID="head" ContentPlaceHolderID="head" runat="server">
        <script src="https://js.stripe.com/v3/"></script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="payment" style="height:100vh;">
  <div class="container py-lg-3">
      <button class="btn btn-primary btn-style">Back
      </button>
      <br />
      <br />
          <h1 class="title mb-4">Payment</h1>
      <div class="row">
          <div class="col-md-8">
      <div class="contact-form">
        <form action="/" method="post">
          <label>Name on Card</label>
            <asp:TextBox ID="nameOnCardTB" runat="server" placeholder="Name On Card" CssClass="form-control"></asp:TextBox>
            <asp:Label ID="nameOnCardError" runat="server"></asp:Label>
            <br />
            <br />
            <label>Card Number</label>
          <asp:TextBox ID="cardNumberTB" runat="server" placeholder="Card Number" CssClass="form-control"></asp:TextBox>
             <asp:Label ID="cardNumberError" runat="server"></asp:Label>
            <br />
            <br />
          <div class="row">
              <div class="col-md-6">
                 <label>Card Expiry (MM YY)</label>
                  <!---
                 <input type="month" class="form-control" name="expCard"/>--->
                  <asp:TextBox ID="cardExpiryTB" runat="server" type="month" placeholder="Card Expiry (MM YY)" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="cardExpiryError" runat="server"></asp:Label>
                <br />
                  </div>
                  <div class="col-md-6">
                      <label>CVV Number</label>
                      <asp:TextBox ID="CVVTB" runat="server" placeholder="CVV Number" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="CVVError" runat="server"></asp:Label>
                      <br />
                      <br />
                  </div>
              </div>
        </form>
          <div class="row">
                  <div class="col-md-6"></div>
                  <div class="col-md-4">
              <asp:Button ID="payPalBtn" runat="server" Text="Proceed to Paypal" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White"  Width="200px" /></div>
              <div class="col-md-2">
            <asp:Button ID="submitBtn" runat="server" Text="Submit" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="submitBtn_Click" />
          </div>
      </div>
      </div>
      </div>
      <div class="col-md-4 mt-md-0 mt-5 w3-contact-address">
          <h2 class="title">Receipt</h2>
          <hr />
          <div class="row">
              <div class="col-6"><p>Service</p></div>
              <div class="col-6"><p>Amount ($)</p></div>
          </div>
          <div class="row">
              <div class="col-6"><p>Appointment</p></div>
              <div class="col-6"><p>50</p></div>
          </div>
          <div class="row">
              <div class="col-6"><p>Medication</p></div>
              <div class="col-6"><p>100</p></div>
          </div>
          <hr />
          <div class="row">
              <div class="col-6"><h4>Total ($)</h4></div>
              <div class="col-6"><h4>150</h4></div>
          </div>
        </div>
    </div>
</section>
</asp:Content>
