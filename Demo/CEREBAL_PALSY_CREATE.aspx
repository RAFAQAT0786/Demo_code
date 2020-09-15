<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="CEREBAL_PALSY_CREATE.aspx.cs" Inherits="CEREBAL_PALSY_CREATE" Title="Cerebal Palsy Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Cerebal Palsy</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="CEREBAL_PALSY_LIST.aspx">Cerebal Palsy List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Cerebal Palsy</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="CEREBAL_PALSY_LIST.aspx" class="btn purple" style="text-align: right;">Cerebal Palsy List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Cerebal Palsy
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Traits<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TRAIT_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Cerebal Palsy Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="CEREBAL_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CEREBAL_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="CEREBAL_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--</div>--%>
                    <div class="form-actions">
                        <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
                <!-- END FORM-->
            </div>
        </div>
        <!-- END FORM VALIDATION -->
    </div>

    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>