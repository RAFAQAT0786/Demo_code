<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_IEP.aspx.cs" Inherits="Patient_IEP" Title="Patient IEP Information" %>

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
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">IEP Planning & Progress Review</h3> 
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>IEP Planning & Progress Review</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="scrtoolkit" runat="server" />
    <%--<div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions To Use</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>--%>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body-button" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>IEP Planning & Progress Review</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Patient Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PATIENT_TXT" runat="server" data-required="1" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PATIENT_TXT" ErrorMessage="*" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                       <label class="control-label">Disorder<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="IEP_DIS_TXT" runat="server" data-required="1" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="IEP_DIS_TXT" ErrorMessage="*" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <div class="row-fluid" id="PTP_IEP" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>IEP Planning & Progress Review</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView Width="100%" DataKeyNames="IEPDT_ID" AutoGenerateColumns="False" AllowPaging="True"
                                OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1"
                                runat="server" AllowSorting="True" EmptyDataText="No, Record Found.." OnRowCommand="GridView1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="IEPDT_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDT_ID" runat="server" Text='<%#Eval("IEPDT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DISORDER NAME">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDT_DISID" runat="server" Text='<%#Eval("DIS_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

              <asp:ButtonField  HeaderStyle-HorizontalAlign="Center" HeaderText="IEP Planning" 
                                        ButtonType="Image" ItemStyle-HorizontalAlign="Center"
                ImageUrl="App_Resources/images/visit.png" CommandName="PATIENT" >
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:ButtonField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="PTP_ID" runat="server" />
    <asp:HiddenField Value="0" ID="IEPDT_ID" runat="server" />
</asp:Content>