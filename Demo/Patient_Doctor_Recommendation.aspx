<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Doctor_Recommendation.aspx.cs" Inherits="Patient_Doctor_Recommendation" Title="Patient Doctor Recommendation" %>

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
    <cc1:ToolkitScriptManager ID="aa" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Recommendation</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Recommendation</li>
        </ul>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions To Use</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Go To Patient Detail</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create Recommendation</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Recommendation Categories<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLRECOMMENDATION" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLRECOMMENDATION_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Recommendation Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="DDLRECOMMENDATION" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLRECOMMENDATION" SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Select Description<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLDESC" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Description Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLDESC" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDESC" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnAdd" CssClass="btn blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                        </div>

                        <!-- END FORM-->
                    </div>
                </div>
                <!-- END FORM VALIDATION -->
            </div>
        </div>
    </div>

    <div class="row-fluid" runat="server" id="Templatenew">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Recommendation</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="Gridview1" AutoGenerateColumns="false" runat="server" Width="100%"
                                DataKeyNames="RECOM_ID" PageSize="25" EmptyDataText="No, Record Added" OnRowDeleting="Gridview1_RowDeleting" OnRowCommand="Gridview1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Recommendation" HeaderStyle-Width="900px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_TEXT" runat="server" Text='<%#Eval("RECOM_TEXT")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="900px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMD_DESC" runat="server" Text='<%#Eval("RECOMD_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                    <asp:TemplateField HeaderText="RECOM_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_ID" runat="server" Text='<%#Eval("RECOM_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECOMD_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMD_ID" runat="server" Text='<%#Eval("RECOMD_ID")%>'></asp:Label>
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

    <div class="row-fluid" runat="server" id="Div1">
        <div class="span12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Recommendation Master</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel2" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="Gridview2" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="150" EmptyDataText="No, Record Added" AllowSorting="True" OnRowCommand="Gridview2_RowCommand" OnRowDeleting="Gridview2_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Recommendation" HeaderStyle-Width="900px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_TEXT" runat="server" Text='<%#Eval("RECOM_TEXT")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description" HeaderStyle-Width="900px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMD_DESC" runat="server" Text='<%#Eval("RECOMD_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                    <asp:TemplateField HeaderText="RECOM_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_ID" runat="server" Text='<%#Eval("RECOM_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECOMD_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMD_ID" runat="server" Text='<%#Eval("RECOMD_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECOMM_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMM_ID" runat="server" Text='<%#Eval("RECOMM_ID")%>'></asp:Label>
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

    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
</asp:Content>