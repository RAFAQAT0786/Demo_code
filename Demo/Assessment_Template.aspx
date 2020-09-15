<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Assessment_Template.aspx.cs" Inherits="Assessment_Template" Title="Assessment Template Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="tool" runat="server" />
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Assessment Template</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Assessment_Template_List.aspx">Assessment Template List</a> <i class="icon-angle-right"></i></li>
            <li>Assessment Template Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Assessment_Template_List.aspx" class="btn purple" style="text-align: right;">Assessment Template List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Patient Assessment Template
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Assessment Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="ASSESSMENT_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="ASSESSMENT_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="ASSESSMENT_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
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
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                        </asp:DropDownList>
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
    <asp:HiddenField Value="0" ID="ASED_ID" runat="server" />
    <div class="row-fluid" runat="server" id="Templatenew">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Assessment</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GV_NEWTEMPLATE1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="150" EmptyDataText="No, Record Added" AllowSorting="True" OnRowUpdating="GV_NEWTEMPLATE1_RowUpdating"
                                OnRowCancelingEdit="GV_NEWTEMPLATE1_RowCancelingEdit" OnRowEditing="GV_NEWTEMPLATE1_RowEditing">
                                <Columns>
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

                                    <asp:TemplateField HeaderText="Percentage" HeaderStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ASER_PERCENTAGE" runat="server" Width="50PX"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="ASER_PERCENTAGE" ErrorMessage="*Not more than 100%"
                                                ValidationExpression="^[1-9]?[0-9]{1}$|^100$" ID="RegularExpressionValidator4"
                                                runat="server" />
                                            <cc1:FilteredTextBoxExtender ID="FTB2" FilterType="Numbers" TargetControlID="ASER_PERCENTAGE" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scale" HeaderStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ASER_SCALE" runat="server" Width="50PX"></asp:TextBox>
                                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="ASER_SCALE" ValidationExpression="^([0-5]*)$" ErrorMessage="Not Greater than 5 or Less than 1" />
                                            <cc1:FilteredTextBoxExtender ID="FTB1" FilterType="Numbers" TargetControlID="ASER_SCALE" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Key Word" HeaderStyle-Width="5px">
                                        <ItemTemplate>
                                            <asp:TextBox ID="ASER_KEYWORD" runat="server" Width="200PX"></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_ID" runat="server" Text='<%#Eval("AGDD_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ASER_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="ASER_ID" Visible="false" runat="server" Text='<%#Eval("ASER_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID2" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="ASED_ID" Visible="false" Text='<%#Eval("ASED_ID")%>' runat="server"></asp:Label>
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
    <asp:HiddenField Value="0" ID="ASER_ID" runat="server" />
    <asp:HiddenField Value="0" ID="AGDM_ID" runat="server" />

    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetScreen" TypeName="BLLAGE"
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_SCT_MASTER">
        <DeleteParameters>
            <asp:Parameter Name="ASE_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="ASE_ID" QueryStringField="Id" Type="String" />
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