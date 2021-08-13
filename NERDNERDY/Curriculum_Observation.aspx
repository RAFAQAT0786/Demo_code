<%@ Page Language="C#" MasterPageFile="~/Admin.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Curriculum_Observation.aspx.cs" Inherits="Curriculum_Observation" Title="Curriculum Observation Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <script src="//cdn.ckeditor.com/4.12.1/full/ckeditor.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Curriculum Observation Configuration</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Curriculum_Observation_List.aspx">Curriculum Observation List</a> <i class="icon-angle-right"></i></li>
            <li>Curriculum Observation Configuration</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Curriculum_Observation_List.aspx" class="btn purple" style="text-align: right;">Curriculum Observation List</a>
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
                        <i class="icon-reorder"></i>Curriculum Observation Configuration
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
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="DDLCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLCAT" SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server" />
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
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLSUBCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator><%-- OnServerValidate="existence_ServerValidate">--%>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLSUBCAT" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                             <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="AGE_GROUP" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLAGE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Select Age Group Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLAGE" SetFocusOnError="true" ID="RequiredFieldValidator5" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Keyword<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="KEYWORD_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Description<span class="required">*</span></label>
                            <div class="controls">
                                <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                <asp:CustomValidator ID="CustomValidator1" ControlToValidate="Textarea1" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                <div id="editor2_error"></div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                            <asp:Button ID="btnAdd" CssClass="btn blue" runat="server" Text="Add" OnClick="btnAdd_Click" />
                            <asp:Button ID="btnUpdate" CssClass="btn purple" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Curriculum Observation</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="CURRICULUM" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="120" EmptyDataText="No, Record Added" OnPageIndexChanging="CURRICULUM_PageIndexChanging"
                                OnRowDeleting="CURRICULUM_RowDeleting" OnRowCommand="CURRICULUM_RowCommand" OnRowUpdating="CURRICULUM_RowUpdating"
                                OnRowCancelingEdit="CURRICULUM_RowCancelingEdit" OnRowEditing="CURRICULUM_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderText="CURRICULUM ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="CURRICULUM_ID" runat="server" Text='<%#Eval("CURRICULUM_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="CURRICULUM_DSCATID" runat="server" Text='<%#Eval("CURRICULUM_DSCATID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="CURRICULUM_DCATID" runat="server" Text='<%#Eval("CURRICULUM_DCATID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_NAME" runat="server" Text='<%#Eval("DCAT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category" HeaderStyle-Width="350px">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_DESC" runat="server" Text='<%#Eval("DSCAT_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Keyword">
                                        <ItemTemplate>
                                            <asp:Label ID="CURRICULUM_KEYWORD" runat="server" Text='<%#Eval("CURRICULUM_KEYWORD")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="500px">
                                        <ItemTemplate>
                                            <asp:Label ID="CURRICULUM_DESC" runat="server" TextMode="MultiLine" Text='<%#Eval("CURRICULUM_DESC")%>' Height="100px" Width="600px"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:ButtonField ItemStyle-HorizontalAlign="Center" HeaderText="Modify"
                                    ButtonType="Image" ImageUrl="App_Resources/images/edit.gif"
                                    CommandName="modify">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
                                    <%--<asp:CommandField EditText="EDIT" ShowEditButton="true" UpdateText="UPDATE" CancelText="CANCEL" ShowCancelButton="true" />--%>
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                    
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="DelAGEDISORDER" TypeName="BLLAge"
        ID="ObjectDataSource1" runat="server" DeleteMethod="DEL_AGDIS_DETAIL">
        <DeleteParameters>
            <asp:Parameter Name="AGDM_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="pATSession" Type="Object" SessionField="User" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
</asp:Content>