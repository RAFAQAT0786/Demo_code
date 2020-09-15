<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Disorder_Report_Master.aspx.cs" Inherits="Disorder_Report_Master" Title="Disorder Report Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Disorder Master</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Disorder_Report_Master_List.aspx">Disorder Report Master List</a> <i class="icon-angle-right"></i></li>
            <li>Create New Disorder Master</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Disorder_Report_Master_List.aspx" class="btn purple" style="text-align: right;">Disorder Report Master List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Disorder Master
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
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="existence" ControlToValidate="DDLDIS" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Pysical Trade<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PHY_TRADE_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PHY_TRADE_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    <asp:CustomValidator ID="CustomValidator1" ControlToValidate="PHY_TRADE_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span6" style="margin-bottom: -15px;">
                                    <div class="control-group">
                                        <label class="control-label">Observation<span class="required">*</span></label>
                                        <div class="controls">
                                            <asp:TextBox ID="OBSERVATION_TXT" runat="server" CssClass="span12 m-wrap" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="OBSERVATION_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="OBSERVATION_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
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
                    <div class="caption"><i class="icon-table"></i>Disorder Master</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="Gridview1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="150" EmptyDataText="No, Record Added" AllowSorting="True" OnRowCommand="Gridview1_RowCommand" OnRowUpdating="Gridview1_RowUpdating"
                                OnRowCancelingEdit="Gridview1_RowCancelingEdit" OnRowDeleting="Gridview1_RowDeleting" OnRowEditing="Gridview1_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderText="Disorder">
                                        <ItemTemplate>
                                            <asp:Label ID="DIS_NAME" runat="server" Text='<%#Eval("DIS_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Physical Trade" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DISO_RETT_PHY" runat="server" Text='<%#Eval("DISO_RETT_PHY")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DISO_RETT_OBSER" runat="server" Text='<%#Eval("DISO_RETT_OBSER")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DISO_RET_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DISO_RET_ID" runat="server" Text='<%#Eval("DISO_RET_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:CommandField EditText="EDIT" ShowEditButton="true" UpdateText="UPDATE" CancelText="CANCEL" ShowCancelButton="true" />
                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                    <asp:TemplateField HeaderText="DISO_RETT_ID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DISO_RETT_ID" runat="server" Text='<%#Eval("DISO_RETT_ID")%>'></asp:Label>
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