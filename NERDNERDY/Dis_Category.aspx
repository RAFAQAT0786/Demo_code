<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Dis_Category.aspx.cs" Inherits="Dis_Category" Title="Disorder Category Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Disorder Category</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Dis_Category_List.aspx">Disorder Category List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Disorder Category Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Dis_Category_List.aspx" class="btn purple" style="text-align: right;">Disorder Category List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Disorder Category
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Category Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox ID="DCAT_NAME_TXT" runat="server" CssClass="span6 m-wrap" />
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DCAT_NAME_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                            <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DCAT_NAME_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
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

    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>