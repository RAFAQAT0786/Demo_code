<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="SEVERITY_GROUP_CREATE.aspx.cs" Inherits="SEVERITY_GROUP_CREATE" Title="Severity Group Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Severity Group</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="SEVERITY_GROUP.aspx">Severity Group List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Severity Group Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="SEVERITY_GROUP.aspx" class="btn purple" style="text-align: right;">Severity Group List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Severity Group
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Disorder<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server"></asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" InitialValue="0" SetFocusOnError="true" ID="RequiredFieldValidator10" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Description<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="DESCRIPTION_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DESCRIPTION_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DESCRIPTION_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">From Value<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="FROM_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="FROM_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">To Value<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TO_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TO_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
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