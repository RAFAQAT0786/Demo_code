<%@ Page Language="C#" MasterPageFile="~/Admin.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="Age_disorder.aspx.cs" Inherits="Age_disorder" Title="Age Disorder Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Age Group Wise Disorder Configuration</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Age_disorder_List.aspx">Age Group Wise Disorder List</a> <i class="icon-angle-right"></i></li>
            <li>Age Group Wise Disorder Configuration</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Age_disorder_List.aspx" class="btn purple" style="text-align: right;">Age Group Wise Disorder List</a>
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
                        <i class="icon-reorder"></i>Age Group Wise Disorder Configuration
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Analysis Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="DDLANALYSIS" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ANALYSIS_DDL" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Select Analysis Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="ANALYSIS_DDL" SetFocusOnError="true" ID="RequiredFieldValidator10" runat="server" />
                                    </div>
                                </div>
                            </div>
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
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Disorder<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="DISORDER" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:CustomValidator ID="existence" ControlToValidate="DDLDIS" runat="server" ErrorMessage="Already Exist" Display="Dynamic"><%--OnServerValidate="existence_ServerValidate">--%>
                                        </asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" SetFocusOnError="true" ID="RV2" runat="server" />
                                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="DISORDER" runat="server">
                                            <ProgressTemplate>
                                                <img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                            </div>
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
                        </div>
                        <div class="row-fluid">
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
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Observation<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="OBSERVATION" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLOBSER" CssClass="span12 m-wrap" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="0">-- Select Observation Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:CustomValidator ID="CustomValidator4" ControlToValidate="DDLOBSER" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLOBSER" InitialValue="0" SetFocusOnError="true" ID="RequiredFieldValidator2" runat="server" />
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
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Category Wise Disorder Observation</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="AGE_GRP" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="120" EmptyDataText="No, Record Added" OnPageIndexChanging="AGE_GRP_PageIndexChanging"
                                OnRowDeleting="AGE_GRP_RowDeleting" OnRowCommand="AGE_GRP_RowCommand">
                                <Columns>
                                    <asp:TemplateField HeaderText="AGE ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_AGDMID" runat="server" Text='<%#Eval("AGDD_AGDMID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_DOBSID" runat="server" Text='<%#Eval("AGDD_DOBSID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_DSCATID" runat="server" Text='<%#Eval("AGDD_DSCATID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_ID" runat="server" Text='<%#Eval("AGDD_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_NAME" runat="server" Text='<%#Eval("DCAT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_DESC" runat="server" Text='<%#Eval("DSCAT_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DOBS_DESC" runat="server" Text='<%#Eval("DOBS_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
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