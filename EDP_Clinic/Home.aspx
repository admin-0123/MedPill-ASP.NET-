<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EDP_Clinic.WebForm1" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- Domain Modal -->
    <div class="modal right fade" id="DomainModal" tabindex="-1" role="dialog" aria-labelledby="DomainModalLabel2">
        <div class="modal-dialog" role="document">
            <div class="modal-content">

                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                    <span
                        aria-hidden="true">&times;</span></button>

                <div class="modal-body">
                    <div class="modal__content">
                        <h2 class="logo">
                            <img src="assets/images/award.png" class="img-fluid">
                            Medpill</h2>
                        <!-- if logo is image enable this   
          <h2 class="logo">
            <img src="image-path" alt="Your logo" title="Your logo" style="height:35px;" />
          </h2> -->
                        <p class="mt-md-3 mt-2">Lorem ipsum dolor sit amet, elit. Eos expedita ipsam at fugiat ab.</p>
                        <div class="widget-menu-items mt-sm-5 mt-4">
                            <h5 class="widget-title">Menu Items</h5>
                            <nav class="navbar p-0">
                                <ul class="navbar-nav">
                                    <li class="nav-item active">
                                        <a class="nav-link" href="index.html">Home</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="about.html">About</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="services.html">Services</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" href="contact.html">Contact</a>
                                    </li>
                                </ul>
                            </nav>
                        </div>
                        <div class="widget-social-icons mt-sm-5 mt-4">
                            <h5 class="widget-title">Contact Us</h5>
                            <ul class="icon-rounded address">
                                <li>
                                    <p>#135 block, Barnard St. Brooklyn,
                                        <br>
                                        NY 10036, USA</p>
                                </li>
                                <li class="mt-3">
                                    <p><span class="fa fa-phone"></span><a href="tel:+404-11-22-89">+1-2345-345-678-11</a></p>
                                </li>
                                <li class="mt-2">
                                    <p>
                                        <span class="fa fa-envelope"></span><a
                                            href="mailto:medpillhospital@mail.com">medpillhospital@mail.com</a>
                                    </p>
                                </li>
                                <li class="top_li1 mt-2">
                                    <p>
                                        <span class="fa fa-clock-o"></span><a href="mailto:medpillhospital@mail.com">Mon - Sun 09:00 - 21:00
                                        </a>
                                    </p>
                                </li>
                            </ul>
                        </div>
                        <div class="widget-social-icons mt-sm-5 mt-4">
                            <h5 class="widget-title">Follow Us</h5>
                            <ul class="icon-rounded">
                                <li><a class="social-link twitter" href="#url" target="_blank"><i class="fa fa-twitter"></i></a></li>
                                <li><a class="social-link linkedin" href="#url" target="_blank"><i class="fa fa-linkedin"></i></a></li>
                                <li><a class="social-link tumblr" href="#url" target="_blank"><i class="fa fa-tumblr"></i></a></li>
                            </ul>
                        </div>


                    </div>
                </div>
            </div>
            <!-- //modal-content -->
        </div>
        <!-- //modal-dialog -->
    </div>
    <!-- //Domain modal -->
    <section class="w3l-main-slider" id="home">
        <!-- main-slider -->
        <div class="companies20-content">

            <div class="owl-one owl-carousel owl-theme">
                <div class="item">
                    <li>
                        <div class="slider-info banner-view bg bg2">
                            <div class="banner-info">
                                <div class="container">
                                    <div class="banner-info-bg">
                                        <h5>We Provide total Health care solution</h5>
                                        <p>
                                            Donec maximus erat quis magna tincidunt, et ullamcorper ex condimentum. Pellentesque 
                    volutpat lectus felis, sit amet dapibus tortor convallis sit amet. Quisque egestas sem quis 
                    augue porta, et iaculis massa consequat.
                                        </p>
                                        <a class="btn btn-style btn-style-outline mt-sm-5 mt-4" href="services.html">Our Services</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </div>
                <div class="item">
                    <li>
                        <div class="slider-info  banner-view banner-top1 bg bg2">
                            <div class="banner-info">
                                <div class="container">
                                    <div class="banner-info-bg">
                                        <h5>Helping you to stay Happy one</h5>
                                        <p>
                                            Donec maximus erat quis magna tincidunt, et ullamcorper ex condimentum. Pellentesque 
                    volutpat lectus felis, sit amet dapibus tortor convallis sit amet. Quisque egestas sem quis 
                    augue porta, et iaculis massa consequat.
                                        </p>
                                        <a class="btn btn-style btn-style-outline mt-sm-5 mt-4" href="services.html">Our Services</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </div>
                <div class="item">
                    <li>
                        <div class="slider-info banner-view banner-top2 bg bg2">
                            <div class="banner-info">
                                <div class="container">
                                    <div class="banner-info-bg">
                                        <h5>1 Lakh+ Patients trusted in our Hospital.</h5>
                                        <p>
                                            Donec maximus erat quis magna tincidunt, et ullamcorper ex condimentum. Pellentesque 
                    volutpat lectus felis, sit amet dapibus tortor convallis sit amet. Quisque egestas sem quis 
                    augue porta, et iaculis massa consequat.
                                        </p>
                                        <a class="btn btn-style btn-style-outline mt-sm-5 mt-4" href="services.html">Our Services</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </div>
                <div class="item">
                    <li>
                        <div class="slider-info banner-view banner-top3 bg bg2">
                            <div class="banner-info">
                                <div class="container">
                                    <div class="banner-info-bg">
                                        <h5>The Largest and most respected Agencies</h5>
                                        <p>
                                            Donec maximus erat quis magna tincidunt, et ullamcorper ex condimentum. Pellentesque 
                    volutpat lectus felis, sit amet dapibus tortor convallis sit amet. Quisque egestas sem quis 
                    augue porta, et iaculis massa consequat.
                                        </p>
                                        <a class="btn btn-style btn-style-outline mt-sm-5 mt-4" href="services.html">Our Services</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </li>
                </div>
            </div>
        </div>
        <!-- /main-slider -->
    </section>
    <!-- w3l-features-photo-7 -->
    <section class="w3l-features-photo-7 py-5">
        <div class="w3l-features-photo-7_sur py-lg-5 py-sm-3">
            <div class="container">
                <div class="row">
                    <div class="col-lg-8 w3l-features-photo-7_top-left">
                        <h2>Dr.Thomas Saint</h2>
                        <p class="mb-lg-5 mb-4">Doctor of Transplant Surgery (PHD)</p>
                        <h4>I Offer a full range of Professional mental Health services to children, Adults,
                          Couples, and Families.</h4>
                        <p>
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. orci urna. In et augue ornare,
                          tempor massa in, luctus sapien. Proin a diam et dui fermentum dolor molestie vel id
                          neque. Donec sed tempus enim, a congue risus. Pellen tesqu
                        </p>
                        <div class="feat_top">
                            <div class="w3l-features-photo-7-box">
                                <div class="icon">
                                    <img src="assets/images/heart.png" class="img-fluid" />
                                </div>
                                <div class="info-feature">
                                    <h5 class="w3l-features-photo-7-box-txt"><a href="#url">Heart Attack</a></h5>
                                    <p>Proin a diam et dui elit, orci urna vel id neque. Donec sed enim</p>
                                </div>
                            </div>
                            <div class="w3l-features-photo-7-box">
                                <div class="icon">
                                    <img src="assets/images/icon1.png" class="img-fluid" />
                                </div>
                                <div class="info-feature">
                                    <h5 class="w3l-features-photo-7-box-txt"><a href="#url">Transplant Surgery</a></h5>
                                    <p>Proin a diam et dui elit, orci urna vel id neque. Donec sed enim</p>
                                </div>
                            </div>
                            <div class="w3l-features-photo-7-box">
                                <div class="icon">
                                    <img src="assets/images/sthethoscope.png" class="img-fluid" />
                                </div>
                                <div class="info-feature">
                                    <h5 class="w3l-features-photo-7-box-txt"><a href="#url">Surgery specialist</a></h5>
                                    <p>Proin a diam et dui elit, orci urna vel id neque. Donec sed enim</p>
                                </div>
                            </div>
                            <div class="w3l-features-photo-7-box">
                                <div class="icon">
                                    <img src="assets/images/ambulance.png" class="img-fluid" />
                                </div>
                                <div class="info-feature">
                                    <h5 class="w3l-features-photo-7-box-txt"><a href="#url">Physiotheraphy</a></h5>
                                    <p>Proin a diam et dui elit, orci urna vel id neque. Donec sed enim</p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-4 w3l-features-photo-7_top-right mt-lg-0 mt-4">
                        <img src="assets/images/doctor1.jpg" class="img-fluid" alt="" />
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- //w3l-features-photo-7 -->
    <section class="w3l-video-sec">
        <div class="video-inner py-5">
            <div class="overlay1 py-lg-5 py-sm-3">
                <div class="container">
                    <div class="video-content">
                        <img src="assets/images/heart-big.png" class="img-fluid" alt="" />
                        <h4><a href="#url">We Provide High Quality Services.</a></h4>
                        <p>
                            Lorem ipsum dolor sit amet consectetur adipisicing elit. Sed obcaecati natus illum, placeat nam
						consequatur! Proin a diam et dui fermentum dolor.
                        </p>
                        <a href="#notify" class="play-button btn"><span class="fa fa-play pl-1" aria-hidden="true"></span></a>

                        <!-- notify-popup-->
                        <div id="notify" class="notify-pop-overlay">
                            <div class="notify-popup">
                                <h5>Excellent Health Care Systems</h5>
                                <iframe src="https://player.vimeo.com/video/180825357" frameborder="0"
                                    allow="autoplay; fullscreen" allowfullscreen></iframe>
                                <a class="close" href="#close">&times;</a>
                            </div>
                        </div>
                        <!-- //notify-popup -->
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- services page block 1 -->
    <section class="w3l-features py-5">
        <div class="container py-lg-5 py-3">
            <div class="row main-cont-wthree-2">
                <div class="col-lg-6 feature-grid-right">
                    <img src="assets/images/healthcare.jpg" class="img-fluid" alt="healthcare">
                </div>
                <div class="col-lg-6 feature-grid-left mt-lg-0 mt-sm-5 mt-4">
                    <h4 class="title-left">We are Providing Excellent Health Care</h4>
                    <p class="text-para">
                        Curabitur id gravida risus. Fusce eget ex fermentum, ultricies nisi ac sed, lacinia est.
                    Quisque ut lectus consequat, venenatis eros et, commodo risus. Nullam sit amet laoreet elit.
                    </p>
                    <div class="stats_main text-center">
                        <div class="w3l-stats">
                            <div class="">
                                <img src="assets/images/patients.png" class="img-fluid">
                            </div>
                            <div class="info-feature mt-3">
                                <h5 class="w3l-stats-txt"><a href="#url">1,754</a></h5>
                                <p class="stats-text">Patients</p>
                            </div>
                        </div>
                        <div class="w3l-stats">
                            <div class="">
                                <img src="assets/images/services.png" class="img-fluid">
                            </div>
                            <div class="info-feature mt-3">
                                <h5 class="w3l-stats-txt"><a href="#url">457</a></h5>
                                <p class="stats-text">Services</p>
                            </div>
                        </div>
                        <div class="w3l-stats">
                            <div class="">
                                <img src="assets/images/award.png" class="img-fluid">
                            </div>
                            <div class="info-feature mt-3">
                                <h5 class="w3l-stats-txt"><a href="#url">1,395</a></h5>
                                <p class="stats-text">Awards</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- services page block 1 -->
    <section class="w3l-apply-6" id="appointment">
        <!-- /apply-6-->
        <div class="apply-info py-5">
            <div class="container py-lg-5 py-sm-3">
                <div class="apply-grids-info row">
                    <div class="apply-gd-left col-lg-5">
                        <h4>Make an appointment</h4>
                        <p class="para-apply">
                            We will send you a confirmation within 24 hours.
						<br>
                            <strong>Emergency?</strong> Call 1-2554-2356-33
                        </p>
                        <div class="mt-lg-5 mt-4">
                            <div class="sub-apply mt-5">
                                <div class="apply-sec-info">
                                    <div class="icon">
                                        <img src="assets/images/icon1.png" class="img-fluid">
                                    </div>
                                    <div class="appyl-sub-icon-info">
                                        <h5><a href="blog-single.html">Immune system</a></h5>
                                        <p>
                                            Lorem ipsum dolor sit amet,Ea a diam et dui elit, orci urna vel id neque. Donec
										sed enim.
                                        </p>
                                        <a href="#url" class="learn">Learn More <i class="fa fa-long-arrow-right ml-2"></i></a>
                                    </div>
                                </div>
                            </div>
                            <div class="sub-apply mt-5">
                                <div class="apply-sec-info">
                                    <div class="icon">
                                        <img src="assets/images/sthethoscope.png" class="img-fluid">
                                    </div>
                                    <div class="appyl-sub-icon-info">
                                        <h5><a href="blog-single.html">Nutrition</a></h5>
                                        <p>
                                            Lorem ipsum dolor sit amet,Ea a diam et dui elit, orci urna vel id neque. Donec
										sed enim.
                                        </p>
                                        <a href="#url" class="learn">Learn More <i class="fa fa-long-arrow-right ml-2"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="apply-gd-right offset-lg-1 col-lg-6 mt-lg-0 mt-5">
                        <div class="apply-form p-sm-5 p-4">
                            <h5>Fill the form for appointment</h5>
                            <form action="#" method="post">
                                <div class="admission-form">
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="Full Name*" required="">
                                    </div>
                                    <div class="form-group">
                                        <input type="text" class="form-control" placeholder="Phone Number*" required="">
                                    </div>
                                    <div class="form-group">
                                        <input type="email" class="form-control" placeholder="Email*" required="">
                                    </div>
                                    <select class="form-control">
                                        <option>Select Disease</option>
                                        <option>Lung disease</option>
                                        <option>Others</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <textarea name="Comment" class="form-control" placeholder="Message*" required=""></textarea>
                                </div>
                                <button type="submit" class="btn btn-primary submit">Submit Now</button>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
    <!-- //apply-6-->
    <!---<section class="w3l-call-to-action_9 py-5">
    <div class="call-w3">
        <div class="container">
            <div class=" main-cont-wthree-2">
                <div class="left-contect-calls text-center">
                    <h3 class="title mb-sm-5 mb-4">Certificates & Standards</h3>
                  <div class="call-grids-w3 ">
                        <a href="#url" class="">
                            <img src="assets/images/logo1.png" class="img-fluid" alt="">
                        </a>

                        <a href="#url" class="">
                            <img src="assets/images/logo2.png" class="img-fluid" alt="">
                        </a>
                        <a href="#url" class="">
                            <img src="assets/images/logo3.png" class="img-fluid" alt="">
                        </a>
                        <a href="#url" class="">
                            <img src="assets/images/logo4.png" class="img-fluid" alt="">
                        </a>
                        <a href="#url" class="">
                            <img src="assets/images/logo5.png" class="img-fluid" alt="">
                        </a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section> --->
</asp:Content>
