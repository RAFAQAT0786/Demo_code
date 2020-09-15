<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="IEP_MAPPING.aspx.cs" Inherits="IEP_MAPPING" Title="IEP MAPPING Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script src="//cdn.ckeditor.com/4.12.1/full/ckeditor.js" type="text/javascript"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New IEP MAPPING</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="IEP_MAPPING_List.aspx">IEP MAPPING Master</a> <i class="icon-angle-right"></i></li>
            <li>Create New IEP MAPPING</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="IEP_MAPPING_List.aspx" class="btn purple" style="text-align: right;">IEP MAPPING Master List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New IEP MAPPING
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLCAT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCAT_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Category Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="existence" ControlToValidate="DDLCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLCAT" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Sub Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLSUBCAT" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Sub Category Name --</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Skill Activity<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="SKILL_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="SKILL_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator2" ControlToValidate="SKILL_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span12" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Skill Describe<span class="required">*</span></label>
                                    <div class="controls">
                                        <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="Textarea1" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
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
                    <div class="caption"><i class="icon-table"></i>IEP Disorder Mapping</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="Gridview1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="2" EmptyDataText="No, Record Added" AllowSorting="True" OnRowCommand="Gridview1_RowCommand" OnRowDeleting="Gridview1_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_NAME" runat="server" Text='<%#Eval("DCAT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub-Category" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_DESC" runat="server" Text='<%#Eval("DSCAT_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="IEPMD_NAME" HeaderText="Skill Activity" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IEPMD_DESC" HeaderText="Observation" HtmlEncode="false" HeaderStyle-HorizontalAlign="Left">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:CommandField EditText="EDIT" ShowEditButton="true" UpdateText="UPDATE" CancelText="CANCEL" ShowCancelButton="true" />
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                    <asp:TemplateField HeaderText="DCAT_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_ID" runat="server" Text='<%#Eval("DCAT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DSCAT_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_ID" runat="server" Text='<%#Eval("DSCAT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IEPMD_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPMD_ID" runat="server" Text='<%#Eval("IEPMD_ID")%>'></asp:Label>
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
                    <div class="caption"><i class="icon-table"></i>IEP Disorder Mapping</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel2" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="Gridview2" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="2" EmptyDataText="No, Record Added" AllowSorting="True" OnRowUpdating="Gridview2_RowUpdating"
                                OnRowCancelingEdit="Gridview2_RowCancelingEdit" OnRowEditing="Gridview2_RowEditing" OnRowDeleting="Gridview2_RowDeleting">
                                <Columns>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_NAME" runat="server" Text='<%#Eval("DCAT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub-Category" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_DESC" runat="server" Text='<%#Eval("DSCAT_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Skill">
                                        <ItemTemplate>
                                            <asp:TextBox ID="IEPMD_NAME" runat="server" Text='<%#Eval("IEPMD_NAME")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="IEPMD_DESC" runat="server" Text='<%#Eval("IEPMD_DESC")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:CommandField EditText="EDIT" ShowEditButton="true" UpdateText="UPDATE" CancelText="CANCEL" ShowCancelButton="true" />
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                    <asp:TemplateField HeaderText="DCAT_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_ID" runat="server" Text='<%#Eval("DCAT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DSCAT_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_ID" runat="server" Text='<%#Eval("DSCAT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IEPMD_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPMD_ID" runat="server" Text='<%#Eval("IEPMD_ID")%>'></asp:Label>
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
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
</asp:Content>