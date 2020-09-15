<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Dis_Sub_Category.aspx.cs" Inherits="Dis_Sub_Category" Title="Disorder Category Sub Information" %>

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
    <cc1:ToolkitScriptManager ID="aa" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Disorder Sub Category</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Dis_Sub_Category_List.aspx">Disorder Sub Category List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Disorder Sub Category Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Dis_Sub_Category_List.aspx" class="btn purple" style="text-align: right;">Disorder Sub Category List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Disorder Sub Category
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Select Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="Update_Category" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLDCAT" runat="server" CssClass="span12 m-wrap" AutoPostBack="True" OnSelectedIndexChanged="DDLDCAT_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">--Select Category--</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:UpdateProgress ID="UpdateProgress7" AssociatedUpdatePanelID="Update_Category" runat="server">
                                                    <ProgressTemplate>
                                                        <img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait...
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>

                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Sub Category Describe<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="DSCAT_DESC_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DSCAT_DESC_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DSCAT_DESC_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>

                        <!-- END FORM-->
                    </div>
                </div>
                <!-- END FORM VALIDATION -->
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>