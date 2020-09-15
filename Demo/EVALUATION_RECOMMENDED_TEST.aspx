<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="EVALUATION_RECOMMENDED_TEST.aspx.cs" Inherits="EVALUATION_RECOMMENDED_TEST" Title="Evaluation Recommended Test Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Evaluation Recommended Test</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Evaluation Recommended Test</li>
        </ul>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
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
                        <i class="icon-reorder"></i>Evaluation Recommended Test Information
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
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDIS_Click">
                                            <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="existence" ControlToValidate="DDLDIS" runat="server" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- END FORM-->
                    </div>
                </div>
                <!-- END FORM VALIDATION -->
            </div>
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
                    <div class="caption"><i class="icon-table"></i>Evaluation Recommended Test List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="EVA_ID1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="50" EmptyDataText="No, Record Added" OnPageIndexChanging="EVA_ID1_PageIndexChanging">
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