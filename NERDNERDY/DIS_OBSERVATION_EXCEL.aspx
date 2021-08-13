<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="DIS_OBSERVATION_EXCEL.aspx.cs" Inherits="DIS_OBSERVATION_EXCEL" Title="Upload Product Bilk Barcode" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="aa" runat="server"></cc1:ToolkitScriptManager>
    <script type="text/javascript" src="App_Resources/javascript/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="App_Resources/javascript/jquery-ui.js"></script>

    <script src="assets/plugins/jquery-1.10.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.1.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.1.custom.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cookie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script type="text/javascript" src="assets/plugins/jquery-validation/dist/jquery.validate.min.js"></script>
    <script type="text/javascript" src="assets/plugins/jquery-validation/dist/additional-methods.min.js"></script>
    <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
    <script type="text/javascript" src="assets/plugins/chosen-bootstrap/chosen/chosen.jquery.min.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Disorder Observation Bulk Upload</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="DIS_OBSERVATION.aspx">Disorder Observation List</a> <i class="icon-angle-right"></i></li>
            <li>Disorder Observation Upload Screen</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="DIS_OBSERVATION.aspx" class="btn purple" style="text-align: right;">Disorder Observation List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Disorder Observation Bulk Upload
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">

                                    <div class="controls">
                                        <asp:FileUpload ID="FlUploadcsv" runat="server" ToolTip="Select Only Excel File" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">

                                    <div class="controls">
                                        <asp:Button ID="Button1" CssClass="btn green" runat="server" Text="Upload" OnClick="btnIpload_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Button ID="Button3" CssClass="btn bg-purple" runat="server" Text="Dowload Excel Format For Bulk Upload" OnClick="btnExcelload_Click" />
                        <asp:Label ID="lblMessage" runat="server" Text="label"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Visible="false" Text="label"></asp:Label>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Observation List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView Width="100%" DataKeyNames="DOBS_DESC"
                            AutoGenerateColumns="False" AllowPaging="True"
                            PageSize="20" ID="GridView1" runat="server" AllowSorting="True"
                            EmptyDataText="No, Record Found..">
                            <Columns>
                                <asp:TemplateField HeaderText="Observation">
                                    <ItemTemplate>
                                        <asp:Label ID="DOBS_DESC" runat="server" Text='<%#Eval("DOBS_DESC")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-actions">
        <asp:Button ID="Button2" CssClass="btn green" runat="server" Text="Save" OnClick="SAVE_Click" />
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>