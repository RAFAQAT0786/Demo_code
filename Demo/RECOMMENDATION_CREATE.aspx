<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="RECOMMENDATION_CREATE.aspx.cs" Inherits="RECOMMENDATION_CREATE" Title="Recommendation Create" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript"></script>
    <script src="//cdn.ckeditor.com/4.12.1/full/ckeditor.js" type="text/javascript"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Recommendation Master</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="RECOMMENDATION_LIST.aspx">Recommendation List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Recommendation Master</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="RECOMMENDATION_LIST.aspx" class="btn purple" style="text-align: right;">Recommendation List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Recommendation Master
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Recommendation<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="RECO_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="RECO_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="RECO_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Observation<span class="required">*</span></label>
                                    <div class="controls">
                                        <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="Textarea1" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                        <div id="editor2_error"></div>
                                    </div>
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
    </div>
    <!-- END FORM VALIDATION -->
    <div class="row-fluid" runat="server" id="Templatenew">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Recommendation Master</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="Gridview1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="150" EmptyDataText="No, Record Added" AllowSorting="True" OnRowDeleting="Gridview1_RowDeleting" OnRowCommand="Gridview1_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="Recommention" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_TEXT" runat="server" Text='<%#Eval("RECOM_TEXT")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMD_DESC" runat="server" Text='<%#Eval("RECOMD_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECOM_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_ID" runat="server" Text='<%#Eval("RECOM_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
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
                                PageSize="150" EmptyDataText="No, Record Added" AllowSorting="True" OnRowCommand="Gridview2_RowCommand" OnRowUpdating="Gridview2_RowUpdating"
                                OnRowCancelingEdit="Gridview2_RowCancelingEdit" OnRowDeleting="Gridview2_RowDeleting" OnRowEditing="Gridview2_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderText="Recommention" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_TEXT" runat="server" Text='<%#Eval("RECOM_TEXT")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOMD_DESC" runat="server" Text='<%#Eval("RECOMD_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RECOM_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RECOM_ID" runat="server" Text='<%#Eval("RECOM_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:CommandField EditText="EDIT" ShowEditButton="true" UpdateText="UPDATE" CancelText="CANCEL" ShowCancelButton="true" />
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
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

    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
</asp:Content>