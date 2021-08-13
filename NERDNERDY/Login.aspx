<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
                   <b style="color:darkmagenta;">Sp.Edtech for Rehab Professionals</b>
              </h3>
                <%--<h3 class="form-title">
                   <b style="color:darkmagenta;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NerdNerdy IEP Creator</b>
              </h3>--%>
           <h3 class="form-title-login">
                   <b>Log In</b>
              </h3>
        <%--<h3 class="form-title">
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Log In</b>
              </h3>--%>
                <%--<b>Parents can Register to receive the Login Details on your email.</b>--%>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="alert alert-error hide">
                    <button class="close" data-dismiss="alert">
                    </button>
                    <span>Enter any username and password.</span>
                </div>
                <asp:Panel DefaultButton="BTN_LOGIN" ID="panel" runat="server">
                    <div class="control-group">
                        <label class="control-label visible-ie8 visible-ie9">
                            Mobile No.</label>
                        <div class="controls">
                            <div class="input-icon left">
                                <i class="icon-user"></i>
                                <asp:TextBox runat="server" ID="TXTUSER" CssClass="m-wrap placeholder-no-fix" Width="360px" placeholder="Mobile No." />
                                <asp:RequiredFieldValidator CausesValidation="true" ValidationGroup="vg" ErrorMessage="Enter Valid Mobile No."
                                    ControlToValidate="TXTUSER" ID="R1" runat="server" ForeColor="Red"/>
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
                                    ControlToValidate="TXTPWD" ID="RequiredFieldValidator1" runat="server" ForeColor="Red"/>
                                <asp:Label runat="server" ID="lblMsg" ForeColor="Red"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <%--<asp:Button CausesValidation="true" ValidationGroup="vg2" runat="server" ID="BTN_THERAPIST_REGISTRATION"
                            Text="Therapist Registration" CssClass="btn yellow pull-left" Width="170px" OnClick="BTN_TerapistRegistration_Click" />--%>
                    <br />
                    <div class="form-actions">
                        

                        <asp:Button CausesValidation="true" ValidationGroup="vg" runat="server" ID="BTN_LOGIN"
                            Text="Login" CssClass="btn blue pull-right" Width="100px" OnClick="BTN_LOGIN_Click" />

                         
                        <%--<a id="popupiep" href="Registration.aspx">--%>
                                                <%--<asp:Button CausesValidation="true" ValidationGroup="vg1" runat="server" ID="BTN_REGISTRATION"
                            Text="Parent Registration" CssClass="btn green pull-left" Width="170px" OnClick="BTN_REGISTRATION_Click"/>--%>
                                           <%-- </a>--%>
                        
                        </div>
                        
            <h4 style="color:black;">For support contact at:-8130277666</h4>
                </asp:Panel>
        <div class="forget-password">
            <h4 style="color:black;">
                Forgot your password .click <a href="javascript:;" id="forget-password"><b>here</b></a> </h4>
                    <%--<p>
                        
                    </p>--%>
        </div>
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
        <div class="form-vertical forget-form" >
        <h3>
            Forget Password ?</h3>
                <%--<p>
            Enter your e-mail address below to reset your password.</p>--%>
            <p>
            You will receive your user-id and password in your email</p>
                <div class="control-group">
                    <div class="controls">
                        <div class="input-icon left">
                            <i class="icon-mobile-phone"></i>
                            <asp:TextBox CssClass="span6 m-wrap" ID="TXT_MOBILE_NO" Width="90%" runat="server" placeholder="MobileNo." />
                             <asp:RequiredFieldValidator ID="RFV31" runat="server" SetFocusOnError="true" ControlToValidate="TXT_MOBILE_NO" ErrorMessage="Please enter your mobile no."/>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXT_MOBILE_NO" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number"/>
                            <%--<input class="m-wrap placeholder-no-fix" type="text" id="mobile" placeholder="Mobile Number" autocomplete="off"
                                style="width: 360px;" name="email" />--%>
                        </div>
                    </div>
                </div>
            <div class="control-group">
                    <div class="controls">
                        <div class="input-icon left">
                            <i class="icon-envelope"></i>
                            <asp:TextBox ID="TXT_EMAIL" CssClass="span6 m-wrap" Width="90%" runat="server" ErrorMessage="Please enter your email" placeholder="Email-id" />
                            <asp:RequiredFieldValidator ID="R16" ControlToValidate="TXT_EMAIL" Display="Dynamic" SetFocusOnError="true" runat="server" />
                            <%--<input class="m-wrap placeholder-no-fix" id="email" type="text" placeholder="Email" autocomplete="off"
                                style="width: 360px;" name="email" />--%>
                        </div>
                    </div>
                </div>
                <div class="form-actions">
                    <button type="button" id="back-btn" class="btn green">
                        <i class="m-icon-swapleft"></i>Back
                    </button>
                    <asp:Button ID="btnsave" runat="server" Height="35px" Width="100px" Text="Submit" CssClass="btn blue pull-right" OnClick="BTN_SUBMIT_Click"/>
                    <%--<asp:Button type="button" Text="Submit" class="btn blue pull-right" onclick="BTN_SUBMIT_Click"">
                         <i class="m-icon-swapright m-icon-white"></i>
                    </asp:Button>--%>
                </div>
       </div>
        

            <!-- END FORGOT PASSWORD FORM -->
        </div>

        <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />

        <!-- END LOGIN -->
        <!-- BEGIN COPYRIGHT -->
        <div class="copyright" style="width: 400px;">
            2020 &copy; Powered By NerdNerdy Technologies Private Limited
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