<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html>
<html lang="en">
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>NerdNerdy | Login Options - Login Form</title>
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="assets/css/style-metro.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2_metro.css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="assets/css/pages/login-soft.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
     
</head>
<!-- END HEAD -->
<!-- BEGIN BODY -->
    

<form runat="server" id="frm">
    
    <body class="login">
        <!-- BEGIN LOGO -->
        <div class="logo">
        <img id="ctl00_imglogo" src="Logos/logo.png" style="height:50px;width:300px;">

        &nbsp;</div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content" style="width: 400px;">
            <!-- BEGIN LOGIN FORM -->
            <div id="Form1" class="form-vertical login-form" defaultfocus="TXTUSER">

    
        <h3 class="form-title">
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Log In
              </h3>
                <div class="alert alert-error hide">
                    <button class="close" data-dismiss="alert">
                    </button>
                    <span>Enter any username and password.</span>
                </div>
                <asp:Panel DefaultButton="BTN_LOGIN" ID="panel" runat="server">
                    <div class="control-group">
                        <label class="control-label visible-ie8 visible-ie9">
                            Username</label>
                        <div class="controls">
                            <div class="input-icon left">
                                <i class="icon-user"></i>
                                <asp:TextBox runat="server" ID="TXTUSER" CssClass="m-wrap placeholder-no-fix" Width="360px" placeholder="Username" />
                                <asp:RequiredFieldValidator CausesValidation="true" ValidationGroup="vg" ErrorMessage="Enter Valid Username."
                                    ControlToValidate="TXTUSER" ID="R1" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="control-group">
                        <label class="control-label visible-ie8 visible-ie9">
                            Password</label>
                        <div class="controls">
                            <div class="input-icon left">
                                <i class="icon-lock"></i>
                                <asp:TextBox runat="server" TextMode="Password" ID="TXTPWD" CssClass="m-wrap placeholder-no-fix"
                                    Width="360px" placeholder="Password" />
                                <asp:RequiredFieldValidator CausesValidation="true" ValidationGroup="vg" ErrorMessage="Enter Valid Password."
                                    ControlToValidate="TXTPWD" ID="RequiredFieldValidator1" runat="server" />
                                <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-actions">
                        <asp:Button CausesValidation="true" ValidationGroup="vg" runat="server" ID="BTN_LOGIN"
                            Text="Login" CssClass="btn blue pull-right" Width="100px" OnClick="BTN_LOGIN_Click" />

                        
                        <a id="popupiep" href="Registration.aspx">
                                                <asp:Button CausesValidation="true" runat="server" ID="BTN_REGISTRATION"
                            Text="Registration" CssClass="btn green pull-right" Width="100px" OnClientClick="basicPopup();return false;"/>
                                            </a>

                        </div>
                        
            <h4>For support contact at:-8130277666</h4>
                </asp:Panel>
        <%--<div class="forget-password">
            <h4>
                Forgot your password ?</h4>
                    <p>
                        no worries, click <a href="javascript:;" id="forget-password">here</a> to reset
                your password.
                    </p>
        </div>--%>
        <%--<div class="CREATE">
            <p>
                Do you want to track your kit ?&nbsp; click <a href="TrackKit.aspx" id="A1">here</a>
                to track your kit
            </p>
                </div>
        <div class="grveinces">
            <p>
                Do you want to report grievance ?&nbsp; click<a href="javascript:;" id="grveinces">here</a>
                to report grievance
            </p>
        </div>--%>
            </div>
            <!-- END LOGIN FORM -->
            <!-- BEGIN FORGOT PASSWORD FORM -->
        <%--<div class="form-vertical forget-form" >
        <h3>
            Forget Password ?</h3>
                <p>
            Enter your e-mail address below to reset your password.</p>
                <div class="control-group">
                    <div class="controls">
                        <div class="input-icon left">
                            <i class="icon-envelope"></i>
                            <input class="m-wrap placeholder-no-fix" type="text" placeholder="Email" autocomplete="off"
                                style="width: 360px;" name="email" />
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <button type="button" id="back-btn" class="btn">
                        <i class="m-icon-swapleft"></i>Back
                    </button>
                    <button type="button" class="btn blue pull-right">
                        Submit <i class="m-icon-swapright m-icon-white"></i>
                    </button>
                </div>
       </div>--%>
        

            <!-- END FORGOT PASSWORD FORM -->
        </div>
        <!-- END LOGIN -->
        <!-- BEGIN COPYRIGHT -->
        <div class="copyright" style="width: 400px;">
            2020 &copy; Powered By NerdNerdy Technology Private Limited
        </div>
        <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>

        <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>

        <script src="assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>

        <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>

        <script src="assets/plugins/bootstrap-hover-dropdown/twitter-bootstrap-hover-dropdown.min.js"
            type="text/javascript"></script>
        <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>

        <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>

        <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>

        <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>

        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->

        <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>

        <script src="assets/plugins/backstretch/jquery.backstretch.min.js" type="text/javascript"></script>

        <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>

        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->

        <script src="assets/scripts/app.js" type="text/javascript"></script>

        <script src="assets/scripts/login-soft.js" type="text/javascript"></script>

        <!-- END PAGE LEVEL SCRIPTS -->

        <script>
	    jQuery(document).ready(function() {
	        App.init();
	        Login.init();
        });

            function basicPopup() {
                $(document).ready(function () {

                    $('a#popupiep').live('click', function (e) {

                        var page = $(this).attr("href")
                        //alert(page);
                        var $dialog = $('<div></div>')
                            .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                            .dialog({
                                autoOpen: false,
                                modal: true,
                                height: 400,
                                width: 705,
                                title: "Registration Detail",
                                buttons: {
                                    "Close": function () { $dialog.dialog('close'); }
                                },
                                close: function (event, ui) {
                                    window.location.href = window.location.href;
                                }
                            });
                        $dialog.dialog('open');
                        e.preventDefault();
                    });
                });
            }

        </script>

        <!-- END JAVASCRIPTS -->
    </body>
</form>
<!-- END BODY -->
</html>