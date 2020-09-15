<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DIS_OBSERVATION_CREATE.aspx.cs" Inherits="DIS_OBSERVATION_CREATE" Title="Observation Information" %>

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
    <cc1:ToolkitScriptManager ID="aa" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Disorder Observation</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="DIS_OBSERVATION.aspx">Disorder Observation List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Disorder Observation Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="DIS_OBSERVATION.aspx" class="btn purple" style="text-align: right;">Disorder Observation List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Disorder Observation
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Description<span class="required">*</span></label>
                            <div class="controls">
                                <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                <asp:CustomValidator ID="CustomValidator1" ControlToValidate="Textarea1" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                <div id="editor2_error"></div>
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