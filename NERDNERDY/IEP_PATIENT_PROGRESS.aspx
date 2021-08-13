<%@ Page Language="C#" AutoEventWireup="true" CodeFile="IEP_PATIENT_PROGRESS.aspx.cs" Inherits="IEP_PATIENT_PROGRESS" Title="Enter IEP Patient Detail" %>

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
<body class="bg-change">
    <form id="form1" runat="server">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN FORM VALIDATION -->
                <div class="portlet box-green" runat="server">
                <%--<div class="portlet box green" runat="server" height="500" width="705">--%>
                    <div class="portlet-title">
                        <div class="caption">IEP Patient Detail</div>
                    </div>
                    <div class="portlet-body form">
                        <!-- BEGIN FORM-->
                        <div class="form-horizontal">
                            <div class="form-horizontal">
                                <div class="row-fluid">
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">Category<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="DDLCAT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCAT_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">-- Select Category Name --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="CustomValidator2" ControlToValidate="DDLCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                                <asp:RequiredFieldValidator ControlToValidate="DDLCAT" SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">Sub Category<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="DDLSUBCAT" CssClass="span12 m-wrap" runat="server">
                                                    <asp:ListItem Value="0">-- Select Sub Category Name --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLSUBCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator><%-- OnServerValidate="existence_ServerValidate">--%>
                                                <asp:RequiredFieldValidator ControlToValidate="DDLSUBCAT" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row-fluid">
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">IEP Skill Activity<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:DropDownList ID="DDLIEA" CssClass="span12 m-wrap" runat="server">
                                                    <asp:ListItem Value="0">-- Select IEP Skill Activity --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DDLIEA" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                                <asp:RequiredFieldValidator ControlToValidate="DDLIEA" SetFocusOnError="true" ID="RequiredFieldValidator5" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="span6" style="margin-bottom: -15px;">
                                        <div class="control-group">
                                            <label class="control-label">IEP Patient Date<span class="required">*</span></label>
                                            <div class="controls">
                                                <asp:TextBox ID="PTP_DATE_TXT" runat="server" CssClass="span12 m-wrap" />
                                                <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="PTP_DATE_TXT" Format="dd/MM/yyyy" Enabled="true" runat="server"></cc1:CalendarExtender>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="control-group" style="margin-bottom: 10px;">
                                    <label class="control-label">Emerging<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:CheckBox runat="server" value='<%#Eval("IEPAT_ID")%>' onclick="SelectUnSelect(this)" ID="chkSelect" />
                                    </div>
                                </div>

                                <div class="control-group" style="margin-bottom: 10px;">
                                    <label class="control-label">Accomplished<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:CheckBox runat="server" value='<%#Eval("IEPAT_ID")%>' onclick="SelectUnSelect(this)" ID="chkSelect1" />
                                    </div>
                                </div>
                                <div class="control-group" style="margin-bottom: 10px;">
                                    <label class="control-label">No Improvement<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:CheckBox runat="server" value='<%#Eval("IEPAT_ID")%>' onclick="SelectUnSelect(this)" ID="chkSelect2" />
                                    </div>
                                </div>
                                <div class="control-group" style="margin-bottom: 10px;">
                                    <label class="control-label">Remarks</label>
                                    <div class="controls">
                                        <asp:TextBox ID="IEPAT_REMARK" CssClass="span12 m-wrap" runat="server" />
                                    </div>
                                </div>
                                <div class="form-actions">
                                    <asp:Button ID="btnupdate" runat="server" Height="30px" Width="100px" Text="Update" CssClass="btn green" OnClick="Updatebtn_Click" ValidationGroup="Save" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script type="text/javascript" language="javascript">
        function SelectUnSelect(sender)
            {
            (function () {
                document.getElementById("chkSelect").onclick = function () {

                    checkClickedCheckBoxTrue("chkSelect", "chkSelect1", "chkSelect2")

                };
            })();
            (function () {
                document.getElementById("chkSelect1").onclick = function () {

                    checkClickedCheckBoxTrue("chkSelect1", "chkSelect", "chkSelect2")

                };
            })();
            (function () {
                document.getElementById("chkSelect2").onclick = function () {
                    checkClickedCheckBoxTrue("chkSelect2", "chkSelect1", "chkSelect")

                };
            })();
        };

        function checkClickedCheckBoxTrue(chkSelect,chkSelect1,chkSelect2)
        {
            var check = document.getElementById(chkSelect)
            if (check.checked)
            {
                check.checked = true
            }
            else
            {
                check.checked = false
            }
            document.getElementById(chkSelect1).checked = false
            document.getElementById(chkSelect2).checked = false
            return false;
        }
        </script>
        <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
        <asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <asp:HiddenField ID="hdnID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
    </form>
</body>
</html>