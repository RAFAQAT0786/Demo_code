<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" Title="Enter Registration Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="App_Resources/StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-metro.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="assets/css/pages/tasks.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN FORM VALIDATION -->
                <div class="portlet box green" runat="server" height="500" width="705">
                    <div class="portlet-title">
                        <div class="caption">Registration Detail</div>
                    </div>
                    <div class="portlet-body form">
                        <!-- BEGIN FORM-->
                        <div class="form-horizontal">
                            <div class="form-horizontal">
                                <div class="row-fluid">
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">Name<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox CssClass="span12 m-wrap" ID="TXT_ORGANIZATION" runat="server"/>
                                               <asp:RequiredFieldValidator ID="R1" ControlToValidate="TXT_ORGANIZATION" SetFocusOnError="true" runat="server" />
                                               <%--<asp:CustomValidator ID="existence" ControlToValidate="TXT_ORGANIZATION" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existuser_ServerValidate"></asp:CustomValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span6" style="margin-bottom:-15px;">
                                      <div class="control-group">
                                       <label class="control-label">User Type<span class="required">*</span></label>
                                         <div class="controls">
                                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                             <ContentTemplate>
                                                <asp:DropDownList ID="DDL_USER_TYPE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="">-- Select User Type --</asp:ListItem>
                                                    <asp:ListItem>Therapist</asp:ListItem>
                                                    <asp:ListItem>Parent</asp:ListItem>
                                                 </asp:DropDownList>
                                               <asp:RequiredFieldValidator ID="R13" ControlToValidate="DDL_USER_TYPE" SetFocusOnError="true" runat="server" />
                                             </ContentTemplate>
                                            </asp:UpdatePanel> 
                                          </div>
                                       </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">Mobile No.<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox CssClass="span12 m-wrap" ID="TXT_MOBILE_NO" runat="server"/>
                                               <asp:RequiredFieldValidator ID="RFV31" runat="server" SetFocusOnError="true" ControlToValidate="TXT_MOBILE_NO"/>
                                               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXT_MOBILE_NO" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number"/>
                                               <%--<asp:CustomValidator ID="CustomValidator1" ControlToValidate="TXT_MOBILE_NO" runat="server" ErrorMessage="Mobile No. Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">Email-Id<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox SkinID="etext" ID="TXT_EMAIL" CssClass="span12 m-wrap" runat="server"/>
                                               <asp:RequiredFieldValidator ID="R16" ControlToValidate="TXT_EMAIL" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                               <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TXT_EMAIL" ErrorMessage="* Invalid E-Mail Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" />
                                               <%--<asp:CustomValidator ID="CustomValidator2" ControlToValidate="TXT_EMAIL" runat="server" ErrorMessage="Email Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>--%>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnsave" runat="server" Height="30px" Width="100px" Text="Save" CssClass="btn green" OnClick="Savebtn_Click" ValidationGroup="Save" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        
        </script>
        <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
        <asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <asp:HiddenField ID="hdnID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
    </form>
</body>
</html>