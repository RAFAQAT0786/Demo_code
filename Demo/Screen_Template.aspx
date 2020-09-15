<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Screen_Template.aspx.cs" Inherits="Screen_Template" Title="Screen Template Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="tool" runat="server" />
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Screen Template</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Screen_Template_List.aspx">Screen Template List</a> <i class="icon-angle-right"></i></li>
            <li>Screen Template Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Screen_Template_List.aspx" class="btn purple" style="text-align: right;">Screen Template List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Patient Screen Template
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Screen Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="SCREEN_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="SCREEN_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="SCREEN_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLAGE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLAGE_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Age Group Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLAGE" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
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
                                                <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLDIS_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="DDLDIS" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" InitialValue="0" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="btnSearch" CssClass="btn green" Text="Search" runat="server" OnClick="btnSearch_Click" />
                            <asp:Button ID="btnSave" CssClass="btn blue" Text="Save" runat="server" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
                <!-- END FORM-->
            </div>
        </div>
        <!-- END FORM VALIDATION -->
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="TextID" runat="server" />
    <div class="row-fluid" runat="server" id="Templatenew">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Screen</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GV_NEWTEMPLATE" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="50" EmptyDataText="No, Record Added" OnRowUpdating="GV_NEWTEMPLATE_RowUpdating"
                                OnRowCancelingEdit="GV_NEWTEMPLATE_RowCancelingEdit" OnRowEditing="GV_NEWTEMPLATE_RowEditing">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTR_ID" Visible="false" Text='<%#Eval("SCTR_ID")%>' runat="server"></asp:Label>
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
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_ID" runat="server" Text='<%#Eval("AGDD_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Percentage" HeaderStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="SCTR_PERCENTAGE" runat="server" Width="50PX"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="SCTR_PERCENTAGE" ErrorMessage="*Not more than 100%"
                                                ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ID="RegularExpressionValidator4"
                                                runat="server" />
                                            <cc1:FilteredTextBoxExtender ID="FTB2" FilterType="Numbers" TargetControlID="SCTR_PERCENTAGE" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scale" HeaderStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="SCTR_SCALE" runat="server" Width="50PX"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="SCTR_SCALE" ValidationExpression="^([0-5]*)$" ErrorMessage="Not Greater than 5 or Less than 1" />
                                            <cc1:FilteredTextBoxExtender ID="FTB1" FilterType="Numbers" TargetControlID="SCTR_SCALE" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID2" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTD_ID" Visible="false" Text='<%#Eval("SCTD_ID")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID4" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DOBS_ID" Visible="false" Text='<%#Eval("DOBS_ID")%>' runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:CommandField EditText="EDIT" ShowEditButton="true" UpdateText="UPDATE" CancelText="CANCEL" ShowCancelButton="true" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField Value="0" ID="ID" runat="server" />
    <asp:HiddenField Value="0" ID="SCTR_ID" runat="server" />
    <asp:HiddenField Value="0" ID="AGDM_ID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />

    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetScreen" TypeName="BLLAGE"
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_SCT_MASTER">
        <DeleteParameters>
            <asp:Parameter Name="SCTP_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="SCTP_ID" QueryStringField="Id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <script type="text/javascript" language="javascript">
    function DDLAGE(x, y) {
        var ddl1 = document.getElementById('<%= this.DDLAGE.ClientID %>');
        if (ddl1.value != "")
            y.IsValid = true;
        else
            y.IsValid = false;
    }
    function SelectUnSelect(CheckBox) {
        var grid = document.getElementById('<%= this.DDLAGE.ClientID %>');//Get target base & child control.
        var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
        if (CheckBox.checked && Counter < Totalchk)   //Modifiy Counter;
            Counter++;
        else if (Counter > 0)
            Counter--;
        if (Counter < Totalchk)   //Change state of the header CheckBox.
            Inputs[0].checked = false;
        else if (Counter == Totalchk)
            Inputs[0].checked = true;
    }
    function SelectUnSelectAll(CheckBox) {
        var grid = document.getElementById('<%= this.DDLAGE.ClientID %>');//Get target base & child control.
        var checkbox = "chkSelect";

        var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

        for (var n = 0; n < Inputs.length; ++n)
            if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox, 0) >= 0)
                Inputs[n].checked = CheckBox.checked;

        Counter = CheckBox.checked ? Totalchk : 0;
    }
    </script>
</asp:Content>