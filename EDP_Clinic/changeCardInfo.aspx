<%@ Page Language="C#" Title="Card Update" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="changeCardInfo.aspx.cs" Inherits="EDP_Clinic.PaymentInfo" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="w3l-contact py-5" id="changePaymentInfo" style="height:100vh;">
  <div class="container py-lg-3">
      <button class="btn btn-primary btn-style">Back
      </button>
      <br />
      <br />
          <h1 class="title mb-4">Change Card Information</h1>
      <div class="row">
          <div class="col-md-8">
              <div class="contact-form">
        <form action="/" method="post">
            <asp:TextBox ID="nameOnCardTB" runat="server" placeholder="Name On Card" CssClass="form-control"></asp:TextBox>
            <br />
            <br />
          <input type="text" class="form-control-range" name="cardNumber" placeholder="Card Number" />
            <br />
          <div class="row">
              <div class="col-md-6">
                 <label>Card Expiry (MM YY)</label>
                 <input type="month" class="form-control" name="expCard"/>
            <br />
              </div>
              <div class="col-md-6">
                  <label>CVV Number</label>
                  <input type="text" class="form-control" name="CVVNum" placeholder="CVV Number" />
            <br />
              </div>
          </div>
        </form>
                  <div class="row">
                      <div class="col-md-10"></div>
                      <div class="col-md-2">
                          <asp:Button ID="updateBtn" runat="server" Text="Submit" CssClass="btn btn-primary btn-style" BackColor="#17449E" ForeColor="White" Width="100px" OnClick="updateBtn_Click" />
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
