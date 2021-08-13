<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EVALUATION_DISORDER.aspx.cs" Inherits="EVALUATION_DISORDER" Title="Evaluation Disorder Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Evaluation Disorder</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="EVALUATION_DISORDER_LIST.aspx">Evaluation Disorder List</a> <i class="icon-angle-right"></i></li>
            <li>Evaluation Disorder Configuration</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="EVALUATION_DISORDER_LIST.aspx" class="btn purple" style="text-align: right;">Evaluation Disorder List</a>
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Evaluation Disorder Configuration
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
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="existence" ControlToValidate="DDLDIS" runat="server" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Evaluation<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLEVA" CssClass="span12 m-wrap" runat="server">
                                            <%-- AutoPostBack="True">--%>
                                            <asp:ListItem Value="0">-- Select Evaluation Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator4" ControlToValidate="DDLEVA" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLEVA" SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnAdd" CssClass="btn blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>
    <asp:HiddenField Value="0" ID="HiddenField2" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE1" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE12" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Evaluation Disorder List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="EVA_ID1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="50" EmptyDataText="No, Record Added" OnPageIndexChanging="EVA_ID1_PageIndexChanging" OnRowDeleting="EVA_ID1_RowDeleting"
                                OnRowCommand="EVA_ID1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Disorder Name" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="DIS_NAME" runat="server" Text='<%#Eval("DIS_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Evaluation" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="EVA_NAME" runat="server" Text='<%#Eval("EVA_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />

                                    <asp:TemplateField HeaderText="ID" Visible="true">
                                        <ItemTemplate>
                                            <asp:Label ID="EVA_ID" runat="server" Text='<%#Eval("EVA_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
</asp:Content>