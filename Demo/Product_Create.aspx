<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Product_Create.aspx.cs" Inherits="Product_Create" Title="Edit Product Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="aa" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Product</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><a href="Product.aspx">Product List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Product Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green" CausesValidation="false" PostBackUrl="~/Product.aspx">Product List</asp:LinkButton>
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-reorder"></i>Create New Product</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Select Category<span class="required">*</span></label>
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
                                        <asp:RequiredFieldValidator ControlToValidate="DDLSUBCAT" SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Product Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PROD_NAME_TXT" ValidationGroup="NONE" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="PROD_NAME_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <%--<div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Product MRP<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PROD_MRP_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="PROD_MRP_TXT" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">
                                        Product Retail Price<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PROD_RTP_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="PROD_RTP_TXT" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Product Stock Price<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PROD_STK_TXT" ValidationGroup="NONE" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="PROD_STK_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Synopsis<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PROD_SYN_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="PROD_SYN_TXT" runat="server" />
                                    </div>
                                </div>
                            </div>--%>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Product Link<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_LINK" runat="server" CssClass="span12 m-wrap" />
                                        <%--<asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_LINK" runat="server" />--%>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
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
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField2" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField4" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>