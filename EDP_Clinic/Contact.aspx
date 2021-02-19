<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EDP_Clinic.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- //Domain modal -->
    <section class="w3l-about-breadcrumb">
        <div class="breadcrumb-bg breadcrumb-bg-contact py-5">
            <div class="container py-lg-5 py-md-3">
                <h2>Contact Us</h2>
                <p>Get Intouch with us</p>
            </div>
        </div>
    </section>
    <!-- Contact section -->
    <section class="w3l-contact py-5" id="contact">
        <div class="container py-lg-3">
            <h3 class="title mb-4">Drop Us a Message</h3>
            <div class="row">
                <div class="col-md-8 contact-form">
                    <form action="https://sendmail.w3layouts.com/submitForm" method="post">
                        <input type="text" class="form-control" name="w3lName" placeholder="Name" /><br />
                        <input type="email" class="form-control" name="w3lSender" placeholder="E-mail" /><br />
                        <input type="text" class="form-control" name="w3lSubject" placeholder="Subject" /><br />
                        <textarea class="form-control" name="w3lMessage" placeholder="Your Message"
                            style="height: 150px;"></textarea><br />
                        <div class="">
                            <button class="btn btn-primary btn-style" type="submit">Submit now</button>
                        </div>
                    </form>
                </div>
                <div class="col-md-4 mt-md-0 mt-5 w3-contact-address">
                    <b>Address:</b>
                    <p>#135 block,</p>
                    <p>Barnard St. Brooklyn,</p>
                    <p>55001 Nevada, 445586,</p>
                    <p>NY 10036, USA.</p>
                    <br />
                    <b>Phone:</b>
                    <p><a href="tel: +1-2345-345-678-11">+1-2345-345-678-11</a></p>
                    <p><a href="tel:+ +1-2345-345-678-12">+1-2345-345-678-12</a></p>
                    <br />
                    <b>Email:</b>
                    <p><a href="mailto:medpillhospital@mail.com">medpillhospital@mail.com</a></p>
                    <p><a href="mailto:medpill@supportmail.com">medpill@supportmail.com</a></p>
                </div>
            </div>
        </div>
    </section>
    <!-- //Contact section -->

    <!-- map -->
    <div class="map">
        <iframe
            src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d158857.7281066703!2d-0.24168144921176335!3d51.5287718408761!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x47d8a00baf21de75%3A0x52963a5addd52a99!2sLondon%2C%20UK!5e0!3m2!1sen!2sin!4v1569921526194!5m2!1sen!2sin"
            frameborder="0" style="border: 0;" allowfullscreen=""></iframe>
    </div>
    <!-- //map -->
</asp:Content>
