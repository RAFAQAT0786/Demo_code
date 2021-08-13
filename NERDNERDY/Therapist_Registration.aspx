<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Therapist_Registration.aspx.cs" Inherits="Therapist_Registration" %>
<%--<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ></cc1:ToolkitScriptManager>--%>
<!DOCTYPE html>
<html lang="en">
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>NerdNerdy | Registration Options - Registration Form</title>
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
     <script src="https://js.stripe.com/v3/"></script> 
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
        <div class="content" style="width: 500px;">
            <!-- BEGIN LOGIN FORM -->
            <div id="Form1" class="form-vertical login-form" defaultfocus="TXTUSER">
                <h3 class="form-title">
                   <%--<b style="color:darkmagenta;">NerdNerdy IEP Creator</b>--%>
                    <%--<b style="color:darkmagenta;">NerdNerdy Assistive Technology For Special Needs</b>--%>
                    <b style="color:darkmagenta;">Sp.Edtech for Rehab Professionals</b>
              </h3>
                <%--<h3 class="form-title">
                   <b style="color:darkmagenta;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;NerdNerdy IEP Creator</b>
              </h3>--%>
          <h3 class="form-title-registration">
                   <b>Registration In</b>
              </h3>

        <%--<h3 class="form-title">
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <b>Registration In</b>
              </h3>--%>
                <%--<b>Parents can Register to receive the Login Details on your email.</b>--%>
                <br />&nbsp;&nbsp;&nbsp;&nbsp;
                <div class="alert alert-error hide">
                    <button class="close" data-dismiss="alert">
                    </button>
                    <span>Enter any username and password.</span>
                </div>
                <%--<asp:Panel DefaultButton="BTN_LOGIN" ID="panel" runat="server">--%>
                    
                        <div class="form-horizontal">
                                <div class="row-fluid">
                                    <div class="span12" style="margin-bottom: 2px;">
                                        <div class="control-group">
                                            <label class="control-label"><b>Name</b><span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox CssClass="span12 m-wrap" ID="TXT_ORGANIZATION" runat="server" placeholder="Username" />
                                               <asp:RequiredFieldValidator ID="R1" ControlToValidate="TXT_ORGANIZATION" SetFocusOnError="true" runat="server" />
                                               <%--<asp:CustomValidator ID="existence" ControlToValidate="TXT_ORGANIZATION" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existuser_ServerValidate"></asp:CustomValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                  </div>
                                <div class="row-fluid">
                                    <div class="span12" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label"><b>Mobile No.</b><span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox CssClass="span12 m-wrap" ID="TXT_MOBILE_NO" runat="server" placeholder="MobileNo." />
                                               <asp:RequiredFieldValidator ID="RFV31" runat="server" SetFocusOnError="true" ControlToValidate="TXT_MOBILE_NO"/>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXT_MOBILE_NO" ValidationExpression="[0-9]{10}" ErrorMessage="Invalid Mobile Number"/>
                                               <asp:CustomValidator ID="CustomValidator1" ControlToValidate="TXT_MOBILE_NO" runat="server" ErrorMessage="Mobile No. Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                    <div class="row-fluid">
                                    <div class="span12" style="margin-bottom: 2px;">
                                        <div class="control-group">
                                            <label class="control-label"><b>Email-Id</b><span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox SkinID="etext" ID="TXT_EMAIL" CssClass="span12 m-wrap" runat="server" placeholder="Email-id" />
                                               <asp:RequiredFieldValidator ID="R16" ControlToValidate="TXT_EMAIL" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                               <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TXT_EMAIL" ErrorMessage="* Invalid E-Mail Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" />
                                               <%--<asp:CustomValidator ID="CustomValidator2" ControlToValidate="TXT_EMAIL" runat="server" ErrorMessage="Email Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            <div class="row-fluid">
                                    <div class="span12" style="margin-bottom: 2px;">
                                        <div class="control-group">
                                            <label class="control-label"><b>Subscription</b><span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="TXT_SUBSCRIPTION" CssClass="span12 m-wrap" runat="server" placeholder="No. Of Subscription" />
                                               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TXT_SUBSCRIPTION" ErrorMessage="Fill Subscription" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                               <%--<asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TXT_SUBSCRIPTION" ForeColor="Red" ErrorMessage="Fill Subscription" ID="RegularExpressionValidator2" runat="server" />--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnsave" runat="server" Text="Buy Now" OnClientClick="pay();" CssClass="btn blue pull-right" OnClick="Savebtn_Click"/>
                                    &nbsp;&nbsp;
                                    <a class="btn green pull-right" style="margin-right: 5px" href="http://demo.nerdnerdy.in">Start 2 Day Free Trail</a>
                                </div>
                            <div class="text-center">Already have an account? <a href="Login.aspx">Login here</a></div>
                            </div>
                        </div>
                        
            <h4 class="text-center" style="color:black;">For support contact at:-8130277666</h4>
                
        </div>
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

         <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
        <asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <asp:HiddenField ID="hdnID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />

        <!-- START POPUP FOR PAY-->
        <style>
            .shower {
                display: block !important;
            }
        </style>

        <script>
            window.onload = function () {
                var url = window.location.href;
                var url_split = url.split("?");
                var req_url = url_split[1];

                if (url) {
                    var ele = document.getElementById("btnPay");
                    ele.classList.add("shower");
                }
            }

            jQuery(document).ready(function () {
                App.init();
                Login.init();
            });

            
            function pay() {
                var url = window.location.href;
                console.log(url);
                
                var url_split = url.split("?");
                var req_url = url_split[1];
                var req_subscription = document.getElementById("TXT_SUBSCRIPTION").value;
                var subscription_umber = parseFloat(req_subscription);
                console.log("Total Subscription", req_subscription, typeof req_subscription, typeof subscription_umber);
                var stripe = Stripe('pk_test_51HQ60SBa0trLGZxvi3mvxR2AHJ27KgbgaPx88jnEF3zNhAjkPdJBIIWuAkZlPKxOtlDNBo4bUWKVVWFFVBbJGMTH00fZdblZ8t');
                    stripe.redirectToCheckout({
                        lineItems: [{
                            //price: 'price_1HU5M8Ba0trLGZxvuPHKJN7F', // Replace with the ID of your price
                            price: 'price_1HThOhBa0trLGZxvE7j1zzVj', // Replace with the ID of your price
                            quantity: subscription_umber,
                        }],
                        mode: 'payment',
                        // successUrl: 'https://example.com/cancel?' + req_url,
                        successUrl: 'http://nerdnerdy.in/Therapist_Registration.aspx?' + req_url + '?SendEmail',
                        cancelUrl: 'https://nerdnerdy.in/',
                    }).then(function (result) {
                        // If `redirectToCheckout` fails due to a browser or network
                        // error, display the localized error message to your customer
                        // using `result.error.message`.
                    });
            }


        </script>
        <!-- END POPUP FOR PAY-->

       
    </body>
</form>
<!-- END BODY -->
</html>


