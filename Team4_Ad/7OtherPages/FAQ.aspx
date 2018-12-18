<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FAQ.aspx.cs" Inherits="Team4_Ad._7OtherPages.FAQ" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" class="perfect-scrollbar-on" lang="en">
    <head>
  <meta charset="utf-8"/>
  <link href="../assets/img/apple-icon.png" rel="apple-touch-icon" sizes="76x76"/>
  <link href="../assets/img/favicon.png" rel="icon" type="image/png"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
  <title>
    FAQ
  </title>
  <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0, shrink-to-fit=no"/>
  <!--     Fonts and icons     -->
  <link href="https://fonts.googleapis.com/css?family=Roboto:300,400,500,700|Roboto+Slab:400,700|Material+Icons" rel="stylesheet" type="text/css"/>
  <link href="https://maxcdn.bootstrapcdn.com/font-awesome/latest/css/font-awesome.min.css" rel="stylesheet"/>
  <!-- CSS Files -->
  <link href="../assets/css/material-dashboard.css?v=2.1.0" rel="stylesheet"/>
  <script src="https://maps.googleapis.com/maps-api-v3/api/js/33/8/intl/en_au/common.js" type="text/javascript" charset="UTF-8"></script>
  <script src="https://maps.googleapis.com/maps-api-v3/api/js/33/8/intl/en_au/util.js" type="text/javascript" charset="UTF-8"></script>
  <script src="https://maps.googleapis.com/maps-api-v3/api/js/33/8/intl/en_au/stats.js" type="text/javascript" charset="UTF-8"></script>
        <style type="text/css">
            .auto-style1 {
                left: 0px;
                top: 0px;
            }
        </style>
    </head>

<body class="offline-doc">
  
<div class="container">
    <br />
    <br />
    <br />

    <div class="alert alert-warning alert-dismissible" role="alert" >
        <button type="button" class="close" data-dismiss="alert"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
        This section contains a wealth of information, related to <strong>Stationery Store Inventory System</strong>. If you cannot find an answer to your question, 
        make sure to <a href="../7OtherPages/ContactUs.aspx" class="alert-link">contact us.
    </div>

    <br />

    <div class="" id="accordion">
        <div class="faqHeader">General questions</div>

        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Is account registration required?</a>
                </h4>
            </div>
            <div id="collapseOne" class="panel-collapse collapse in">
                <h6 class="card-block">
                    The system is developed by <strong>Logic University Team 4</strong> and only can be used for internal users. For now, new users can be added via the database, and no need to registrate.
                </h6>
            </div>
        </div>

        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTen">Do we need a user traning class before using system?</a>
                </h4>
            </div>
            <div id="collapseTen" class="panel-collapse collapse">
                <div class="card-block">
                  We are very pleased to provide user tranning service. If you need, plase <a href="../7OtherPages/ContactUs.aspx" class="alert-link">contact us.
                </div>
            </div>
        </div>

       <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseThree">What do I do if I forgot my password?</a>
                </h4>
            </div>
            <div id="collapseThree" class="panel-collapse collapse">
                <div class="card-block">
                  Please <a href="../7OtherPages/ContactUs.aspx" class="alert-link">contact us to obtain a new and working set of username and password to log into the system.
                </div>
            </div>
        </div>

        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseFive">How do I log out of the mobile application?</a>
                </h4>
            </div>
            <div id="collapseFive" class="panel-collapse collapse">
                <div class="card-block">
                 There is no log out function temporarily. The function is currently being developed and may be available in the next update.
                </div>
            </div>
        </div>

        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseEleven">How to uspade pro vision? </a>
                </h4>
            </div>
            <div id="collapseEleven" class="panel-collapse collapse">
                <div class="card-block">
                  We offer a paid upgrate service to provide a customized solution just for you.  
                </div>
            </div>
        </div>

        <div class="faqHeader">Department Staff</div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo"> What do I do if I miss my collection date and time?</a>
                </h4>
            </div>
            <div id="collapseTwo" class="panel-collapse collapse">
                <div class="card-block">
                   The system facilitates the automation of requisition and disbursement of stationery. For collection enquiries, please contact the store directly to make additional arrange
                </div>
            </div>
        </div>
       
        

        <div class="faqHeader">Store Staff</div>
        <div class="card ">
            <div class="card-header">
                <h4 class="card-header">
                    <a class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" href="#collapseFour">I want to buy a theme - what are the steps?</a>
                </h4>
            </div>
            <div id="collapseFour" class="panel-collapse collapse">
                <div class="card-block">
                    Buying a theme on <strong>PrepBootstrap</strong> is really simple. Each theme has a live preview. 
                    Once you have selected a theme or template, which is to your liking, you can quickly and securely pay via Paypal.
                    <br />
                    Once the transaction is complete, you gain full access to the purchased product. 
                </div>
            </div>
        </div>
        
    </div>
</div>

<style>
    .faqHeader {
        font-size: 27px;
        margin: 20px;
    }

    .panel-heading [data-toggle="collapse"]:after {
        font-family: 'Glyphicons Halflings';
        content: "e072"; /* "play" icon */
        float: right;
        color: #F58723;
        font-size: 18px;
        line-height: 22px;
        /* rotate "play" icon from > (right arrow) to down arrow */
        -webkit-transform: rotate(-90deg);
        -moz-transform: rotate(-90deg);
        -ms-transform: rotate(-90deg);
        -o-transform: rotate(-90deg);
        transform: rotate(-90deg);
    }

    .panel-heading [data-toggle="collapse"].collapsed:after {
        /* rotate "play" icon from > (right arrow) to ^ (up arrow) */
        -webkit-transform: rotate(90deg);
        -moz-transform: rotate(90deg);
        -ms-transform: rotate(90deg);
        -o-transform: rotate(90deg);
        transform: rotate(90deg);
        color: #454444;
    }
</style>




<%--  <footer class="footer">
    <div class="container-fluid">
      <nav class="float-left">
        <ul>
          <li>
            <a href="~/7OtherPages/Team 4.aspx">
              Team 4
            </a>
          </li>
          <li>
            <a href="~/7OtherPages/ContactUs.aspx">
              About Us
            </a>
          </li>
        </ul>
      </nav>
      <div class="copyright float-right">
        ©
        <script>
            document.write(new Date().getFullYear())
        </script>made with <i class="material-icons">favorite</i> by
        <a href="https://www.creative-tim.com" target="_blank">Team 4</a> for a better web.
      </div>
    </div>
  </footer>--%>
    

  <!--   Core JS Files   -->
  <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
  <script src="../assets/js/core/popper.min.js" type="text/javascript"></script>
  <script src="../assets/js/core/bootstrap-material-design.min.js" type="text/javascript"></script>
  <script src="../assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
  <!--  Google Maps Plugin    -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!-- Chartist JS -->
  <script src="../assets/js/plugins/chartist.min.js"></script>
  <!--  Notifications Plugin    -->
  <script src="../assets/js/plugins/bootstrap-notify.js"></script>
  <!-- Control Center for Material Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="../assets/js/material-dashboard.min.js?v=2.1.0" type="text/javascript"></script>


</body>

</html>

