<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Report_Template.aspx.cs" Inherits="Report_Template" Title="Report Template" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript"></script>
    <script src="//cdn.ckeditor.com/4.12.1/full/ckeditor.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title"><span class="username">
            <asp:Label ID="Label1" runat="server" /></span>Report Template</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Report_Template_List.aspx">Report List</a> <i class="icon-angle-right"></i></li>
            <li>Report Template</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Report_Template_List.aspx" class="btn purple" style="text-align: right;">Report List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Report Template
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Report Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="REPORT_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="REPORT_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="REPORT_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="AGEGROUP" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLAGE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Select Age Group Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLAGE" SetFocusOnError="true" ID="RequiredFieldValidator5" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Reason For Referral<span class="required">*</span></label>
                                    <div class="controls">
                                        <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor1_error"></textarea>
                                        <div id="editor1_error"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: 5px;">
                                <label class="control-label">Evaluation Method<span class="required">*</span></label>
                                <div class="controls">
                                    <div class="control-group" style="height: 160px; overflow: auto; border: 2px solid #dddddd; margin: 0px; padding: 0px; width: 1023px;">
                                        <asp:CheckBoxList ID="EVALUATION_DDL" RepeatLayout="Table" CssClass="checkboxlist" RepeatColumns="1" runat="server" Enabled="False"
                                            RepeatDirection="Horizontal" onclick="SelectUnSelect(this)">
                                        </asp:CheckBoxList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Medical History<span class="required">*</span></label>
                                    <div class="controls">
                                        <textarea class="span12 ckeditor m-wrap" id="Textarea2" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                        <div id="editor2_error"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <div class="control-group" style="margin-bottom: 10px;">
                                <label class="control-label">Development History<span class="required">*</span></label>
                                <div class="controls">
                                    <textarea class="span12 ckeditor m-wrap" id="Textarea3" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor3_error"></textarea>
                                    <div id="editor3_error"></div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Family History<span class="required">*</span></label>
                                    <div class="controls">
                                        <textarea class="span12 ckeditor m-wrap" id="Textarea4" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor4_error"></textarea>
                                        <div id="editor4_error"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label">Clinical Observation<span class="required">*</span></label>
                                <div class="controls">
                                    <textarea class="span12 ckeditor m-wrap" id="Textarea5" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor5_error"></textarea>
                                    <div id="editor5_error"></div>
                                </div>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label">Clinical Diagnostic<span class="required">*</span></label>
                                <div class="controls">
                                    <textarea class="span12 ckeditor m-wrap" id="Textarea11" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor11_error"></textarea>
                                    <div id="editor11_error"></div>
                                </div>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <div class="control-group">
                                <label class="control-label">Recommendations<span class="required">*</span></label>
                                <div class="controls">
                                    <textarea class="span12 ckeditor m-wrap" id="Textarea17" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor17_error"></textarea>
                                    <div id="editor17_error"></div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="SAVEBTN" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVEHID" runat="server" />
    <script type="text/javascript" src="App_Resources/javascript/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="App_Resources/javascript/thickbox-compressed.js"></script>
    <link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" />
    <script type="text/javascript" language="javascript">
    function printdiv(divnametoprint, type) {
        debugger;
        var strBreak = (type == 'PTP_NAME' ? '<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>' : '<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>')
        var divToPrint = document.getElementById(divnametoprint);//alert(divToPrint.innerHTML);
        var newWin = window.open('', '', 'width=100,height=100');  //alert(newWin);
        newWin.document.open();
        newWin.document.write('<html><head><link rel="stylesheet" href="App_Resources/StyleSheet/print.css" type="text/css" media="screen" /><link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" /></head><body onload="AddFirstPage();" class="print">' + divToPrint.innerHTML + strBreak + divToPrint.innerHTML + '</body></html>');
        newWin.document.close();
        setTimeout(function () { newWin.close(); }, 1000);
        newWin.focus();
        newWin.print();
        newWin.close();
        return true;
    }
    </script>
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField ID="hdnID" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
</asp:Content>