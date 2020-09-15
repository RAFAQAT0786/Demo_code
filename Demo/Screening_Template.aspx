<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Screening_Template.aspx.cs" Inherits="Screening_Template" Title="Screen Template Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <cc1:ToolkitScriptManager ID="aa" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Screen Template Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Screening_Template_List.aspx">Screen Template Information</a> <i class="icon-angle-right"></i></li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Screening_Template_List.aspx" class="btn purple" style="text-align: right;">Screen Template List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Enter Screen Template Information
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Select Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="Update_Category" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLDAGECAT" runat="server" CssClass="span12 m-wrap" AutoPostBack="True">
                                                    <asp:ListItem Value="0">--Select Age Group Disorder--</asp:ListItem>
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
                                    <label class="control-label">Screen Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="SCREEN_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="SCREEN_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
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