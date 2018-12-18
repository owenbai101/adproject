<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Team4_Ad.login" %>

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml" class="perfect-scrollbar-on" lang="en">
    <head>
  <meta charset="utf-8"/>
  <link href="~/assets/img/apple-icon.png" rel="apple-touch-icon" sizes="76x76"/>
  <link href="~/assets/img/favicon.png" rel="icon" type="image/png"/>
  <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1"/>
  <title>
    Let's start form here
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
  <!-- Navbar -->
  <nav class="navbar navbar-expand-lg navbar-transparent navbar-absolute fixed-top ">
    <div class="container-fluid">
      <div class="navbar-wrapper">
        <a class="navbar-brand" href="#pablo"><img src="../images/logo.jpg" width="135" runat="server"/></a>
      </div>
      <button class="navbar-toggler" aria-expanded="false" aria-controls="navigation-index" aria-label="Toggle navigation" type="button" data-toggle="collapse">
        <span class="sr-only">Toggle navigation</span>
        <span class="navbar-toggler-icon icon-bar"></span>
        <span class="navbar-toggler-icon icon-bar"></span>
        <span class="navbar-toggler-icon icon-bar"></span>
      </button>
      <div class="collapse navbar-collapse justify-content-end">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link" href="~/7OtherPages/FAQ.aspx">
              FAQ
            </a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="~/7OtherPages/ContactUs.aspx">
              Contact Us
            </a>
          </li>
        </ul>
      </div>
    </div>
  </nav>
  <!-- End Navbar -->
  <div class="page-header clear-filter">
    <div class="page-header-image" style="background-image: url('../assets/img/cover.jpg'); left: 0px; top: 3px;" runat="server"></div>
    <div class="content-center">
      <div class="auto-style1" align="center">
       <div class="card col-md-5" align="center">
           <div class="card">
            <div class="card-body">
                <form id="form1" runat="server">
                <div>
                <asp:Login ID="Login1" runat="server" OnLoggedIn="Login1_LoggedIn"></asp:Login>
                </div>
                </form>
            </div>
            </div>
        </div>
      </div>
    </div>
  </div>
  <footer class="footer">
    <div class="container-fluid">
      <nav class="float-left">
        <ul>
          <li>
            <a href="~/7OtherPages/StartPage.aspx">
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
  </footer>
  <!--   Core JS Files   -->
  <script src="../assets/js/core/jquery.min.js" type="text/javascript"></script>
  <script src="../startbootstrap-sb-admin-gh-pages/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
  <script src="../assets/js/core/popper.min.js" type="text/javascript"></script>
  <script src="../assets/js/core/bootstrap-material-design.min.js" type="text/javascript"></script>
  <script src="../assets/js/plugins/perfect-scrollbar.jquery.min.js"></script>
  <!--  Google Maps Plugin    -->
  <script src="https://maps.googleapis.com/maps/api/js?key=YOUR_KEY_HERE"></script>
  <!-- Chartist JS -->
  <script src="../assets/js/plugins/chartist.min.js"></script>
  <script src="../startbootstrap-sb-admin-gh-pages/vendor/jquery-easing/jquery/jquery.easing.min.js"></script>
  <!--  Notifications Plugin    -->
  <script src="../assets/js/plugins/bootstrap-notify.js"></script>
  <!-- Control Center for Material Dashboard: parallax effects, scripts for the example pages etc -->
  <script src="../assets/js/material-dashboard.min.js?v=2.1.0" type="text/javascript"></script>


</body>

</html>

