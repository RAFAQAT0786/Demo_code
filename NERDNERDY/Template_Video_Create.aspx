<%@ Page Language="C#" MasterPageFile="~/Parent.master" AutoEventWireup="true" CodeFile="Template_Video_Create.aspx.cs" Inherits="Template_Video_Create" Title="Template Video Detail" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Template Video Detail</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><a href="Template_Video_List.aspx">Template Video List</a> <i class="icon-angle-right"></i></li>
            <li>Template Video Detail</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green" CausesValidation="false" PostBackUrl="~/Template_Video_List.aspx">Template Video List</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-reorder"></i>Template Video Detail</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Choose Analysis<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="DDLANALYSIS" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLANAL" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Select Analysis Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLANAL" SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="DDLANAL" runat="server" ErrorMessage="Analysis Name Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="DDLAGEGROUP" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLAGE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Select Age Group Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLAGE" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DDLAGE" runat="server" ErrorMessage="Age Group Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                           </div>
                            
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Disorder Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLORDER" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                            <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLORDER" SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLAGE" runat="server" ErrorMessage="Disorder Name Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Video Link<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="VIDEO_LINK" runat="server" CssClass="span12 m-wrap" />
                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="VIDEO_LINK" runat="server" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="SAVEBTN" CssClass="btn blue" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                        </div>
                        <!-- END FORM-->
                    </div>
                </div>
                <!-- END VALIDATION STATES-->
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
</asp:Content>