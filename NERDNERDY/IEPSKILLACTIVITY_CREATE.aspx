<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="IEPSKILLACTIVITY_CREATE.aspx.cs" Inherits="IEPSKILLACTIVITY_CREATE" Title="IEPSKILLACTIVITY Information" %>

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
        <h3 class="page-title">Create New IEPskillactivities</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="IEPSKILLACTIVITY_LIST.aspx">IEPskillactivity List</a> <i class="icon-angle-right"></i></li>
            <li>Create New IEPskillactivities Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="IEPSKILLACTIVITY_LIST.aspx" class="btn purple" style="text-align: right;">IEPskillactivity List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New IEPskillactivities
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">IPE Skill<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="IEP_SKILL_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="IEP_SKILL_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="IEP_SKILL_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Skill Activity Describe<span class="required">*</span></label>
                            <div class="controls">
                                <textarea class="span12 ckeditor m-wrap" id="Textarea3" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor3_error"></textarea>
                                <div id="editor3_error"></div>
                            </div>
                        </div>
                    </div>

                    <div class="form-actions">
                        <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
            <!-- END FORM-->
        </div>
    </div>
    <!-- END FORM VALIDATION -->
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>