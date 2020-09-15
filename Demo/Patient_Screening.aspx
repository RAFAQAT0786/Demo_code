<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Screening.aspx.cs" Inherits="Patient_Screening" Title="Patient Screening Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript"></script>
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Screening Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Patient_Screening_List.aspx">Patient Screening List</a> <i class="icon-angle-right"></i></li>
            <li>Patient Screening Information</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="scrtoolkit" runat="server" />
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient_Screening_List.aspx" class="btn purple" style="text-align: right;">Patient Screening List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Patient Screening Information
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Docter Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLDOCTER" CssClass="span12 m-wrap" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="0">-- Select Docter Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDOCTER" InitialValue="0" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Screen Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLSCREEN" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Screen Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLSCREEN" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Input<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="INPUT_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="INPUT_TXT" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Remarks<span class="required">*</span></label>
                                    <div class="controls">
                                        <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                        <div id="editor2_error"></div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>