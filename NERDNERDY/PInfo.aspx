<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="PInfo.aspx.cs" Inherits="PInfo" Title="Edit Personal Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Edit Personal Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Edit Personal Information</li>
        </ul>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Edit Personal Information
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Company Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_COMP_NAME" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TXT_COMP_NAME" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Contact Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_CONT_NAME" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TXT_CONT_NAME" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Phone Number<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_PHONE_NO" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TXT_PHONE_NO" SetFocusOnError="true" runat="server" />
                                <cc1:FilteredTextBoxExtender ID="FTextBoxE3" TargetControlID="TXT_PHONE_NO" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Mobile Number<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_MOBILE_NO" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="TXT_MOBILE_NO" SetFocusOnError="true" runat="server" />
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TXT_MOBILE_NO" EnableTheming="false" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number" />
                                <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="TXT_MOBILE_NO" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Fax Number<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_FAX_NO" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="TXT_FAX_NO" SetFocusOnError="true" runat="server" />
                                <cc1:FilteredTextBoxExtender ID="FTextBoxE2" TargetControlID="TXT_FAX_NO" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">E-Mail ID<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox SkinID="etext" ID="TXT_EMAIL" CssClass="span6 m-wrap" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="TXT_EMAIL" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="TXT_EMAIL" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" Display="Dynamic" runat="Server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Address<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_ADDRESS" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="TXT_ADDRESS" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">City<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_CITY" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TXT_CITY" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">State / Province<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_STATE" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="TXT_STATE" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Postal / Zip Code<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox CssClass="span6 m-wrap" ID="TXT_PIN" runat="server" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="TXT_PIN" SetFocusOnError="true" runat="server" />
                                <cc1:FilteredTextBoxExtender ID="FTextBoxE1" TargetControlID="TXT_PIN" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                            </div>
                        </div>
                    </div>
                    <div class="form-actions">
                        <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>