<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Customer_Create.aspx.cs"
    Inherits="Customer_Create" Title="Customer Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript" src="App_Resources/javascript/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="App_Resources/javascript/jquery-ui.js"></script>
    <script language="javascript" type="text/javascript">
    function checkmobile(x,y)
    {
        if(y.Value.length>=11)
            y.IsValid=false;
        else
            y.IsValid=true;
    }
    </script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Customer Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i>
                <asp:LinkButton runat="server" Text="Home" CausesValidation="false" ID="btn_home" OnClick="btn_home_Click"></asp:LinkButton></li>
            <li><i class="icon-table"></i><a href="Customer.aspx">Customer List</a> <i class="icon-angle-right"></i></li>
            <li>Customer Creation Screen</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Customer.aspx" class="btn purple" style="text-align: right;">Customer List</a>
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
                        <i class="icon-reorder"></i>Customer Information
                    </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Customer Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="CUST_NAME_TXT" CssClass="span12 m-wrap" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CUST_NAME_TXT" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Prefix<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel1" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="CUST_PREFIX_NAME" CssClass="span12 m-wrap" runat="server">
                                                    <asp:ListItem Value="0">Select Prefix</asp:ListItem>
                                                    <asp:ListItem>Mr.</asp:ListItem>
                                                    <asp:ListItem>Mrs.</asp:ListItem>
                                                    <asp:ListItem>M/S.</asp:ListItem>
                                                    <asp:ListItem>Ms.</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ControlToValidate="CUST_PREFIX_NAME" InitialValue="0" SetFocusOnError="true" ID="RequiredFieldValidator10" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Designation<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_DESIGNATION" CssClass="span12 m-wrap" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="TXT_DESIGNATION" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Phone Number<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="CUST_PH_TXT" CssClass="span12 m-wrap" runat="server" />
                                        <cc1:FilteredTextBoxExtender ID="FVE1" TargetControlID="CUST_PH_TXT" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 4px;">
                                    <label class="control-label">Mobile Number<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_MOBILE_TXT" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator4" ControlToValidate="CUST_MOBILE_TXT" runat="server" ErrorMessage="Mobile No Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ErrorMessage="No. Required" ControlToValidate="CUST_MOBILE_TXT" SetFocusOnError="true" runat="server" />
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="CUST_MOBILE_TXT" EnableTheming="false" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number" />
                                        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" TargetControlID="CUST_MOBILE_TXT" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 4px;">
                                    <label class="control-label">Email ID <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_EMAIL_TXT" runat="server" />
                            <asp:RequiredFieldValidator ID="R16" ControlToValidate="CUST_EMAIL_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                           <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="CUST_EMAIL_TXT" ErrorMessage="* Invalid E-Mail Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" />
                           <asp:CustomValidator ID="CustomValidator2" ControlToValidate="CUST_EMAIL_TXT" runat="server" ErrorMessage="Email Already Exist" Display="Dynamic" onservervalidate="existuser_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Road/Street/House <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_ADD_TXT" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="CUST_ADD_TXT" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Village/Town/City <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="txt_vil" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="txt_vil" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Post Office<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="txt_post" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="txt_post" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Country<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UP_COUNTRY" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="CUST_COUNTRY_DDL" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CUST_COUNTRY_DDL_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">-- Select Country --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" InitialValue="0" ControlToValidate="CUST_COUNTRY_DDL" SetFocusOnError="true" runat="server" />
                                                <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UP_COUNTRY" runat="server">
                                    <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">State <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="up_state" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="ddl_state" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">-- Select State --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" InitialValue="0" ControlToValidate="ddl_state" SetFocusOnError="true" runat="server" />
                                                <asp:UpdateProgress ID="UpdateProgress5" AssociatedUpdatePanelID="up_state" runat="server">
                                     <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">City<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UP_STATION" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="CUST_STATION_DDL" CssClass="span12 m-wrap" runat="server">
                                                    <asp:ListItem Value="0">-- Select City Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="CUST_STATION_DDL" InitialValue="0" SetFocusOnError="true" ID="RV2" runat="server" />
                                        <asp:UpdateProgress ID="UpdateProgress1" AssociatedUpdatePanelID="UP_STATION" runat="server">
                                <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">Pin Code <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_PIN_TXT" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="CUST_PIN_TXT" ErrorMessage="PIN No. Required" SetFocusOnError="true" runat="server" />
                                        <cc1:FilteredTextBoxExtender ID="FV1" TargetControlID="CUST_PIN_TXT" FilterType="Numbers" runat="server" Enabled="True" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Start Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_START" runat="server" Placeholder="yyyy/MM/dd" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="TXT_START" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_START" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">End Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_END" runat="server" Placeholder="yyyy/MM/dd" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="TXT_END" Format="dd/MMM/yyyy"></cc1:CalendarExtender>
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_END" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Company Name <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_COMP_NAME_TXT" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="CUST_COMP_NAME_TXT" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Customer Category <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel2" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="CUST_CATRGORY_DDL" CssClass="span12 m-wrap" runat="server">
                                                    <asp:ListItem Value="0">-- Select Category --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator11" InitialValue="0" ControlToValidate="CUST_CATRGORY_DDL" SetFocusOnError="true" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Prospective Category <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ddlProspective" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">Select Prospective</asp:ListItem>
                                            <asp:ListItem Value="1">Existing</asp:ListItem>
                                            <asp:ListItem Value="2">Prospective</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">Consultant/Decision Maker <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_CONSL_TXT" Enabled="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">Phone/ Mobile Number <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_CONSL_MOB_TXT" Enabled="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">Customer Profile <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="CUST_TYPE_DDL" runat="server" CssClass="span12 m-wrap" AutoPostBack="True" OnSelectedIndexChanged="CUST_TYPE_DDL_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">-- Select Customer Type --</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ControlToValidate="CUST_TYPE_DDL" InitialValue="0" SetFocusOnError="true" ID="RV1" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Description <span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="TXT_DISC" Enabled="false" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="TXT_DESIGNATION" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Value of Customer<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="TXT_VALUE" runat="server" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="TXT_DESIGNATION" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">Choose Organization<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="ORGANIZATION_DDL" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Organization --</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="Addbtn" CssClass="btn green" runat="server" Text="Add Profile" OnClick="Addbtn_Click" />
                            <asp:Button ID="btnSave" CssClass="btn yellow" runat="server" Text="Save" OnClick="btnSave_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Customer List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView ID="CUST_PROFILE" Width="100%" AutoGenerateColumns="false" runat="server"
                            PageSize="25" EmptyDataText="No, Profile Added" OnRowCommand="CUST_PROFILE_RowCommand"
                            OnRowDeleting="CUST_PROFILE_RowDeleting">
                            <Columns>
                                <asp:TemplateField HeaderText="Customer ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="CUSTP_TYPE_ID" runat="server" Text='<%#Eval("CUSTP_TYPE_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Profile Name">
                                    <ItemTemplate>
                                        <asp:Label ID="CUST_TYP_NAME" runat="server" Text='<%#Eval("CUST_TYP_NAME")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Value">
                                    <ItemTemplate>
                                        <asp:Label ID="CUSTP_VALUE" runat="server" Text='<%#Eval("CUSTP_VALUE")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description" HeaderStyle-Width="400px">
                                    <ItemTemplate>
                                        <asp:Label ID="CUSTP_DESC" runat="server" Text='<%#Eval("CUSTP_DESC")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />

    <script type="text/javascript" language="javascript">
function CUST_TYPE_DDL(x,y)
{
var ddl1 = document.getElementById('<%= this.CUST_TYPE_DDL.ClientID %>');
 if(ddl1.value!="")
 y.IsValid=true;
 else
 y.IsValid=false;
}
function SelectUnSelect(CheckBox)
{
   var grid = document.getElementById('<%= this.CUST_TYPE_DDL.ClientID %>');//Get target base & child control.
   var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
   if(CheckBox.checked && Counter < Totalchk)   //Modifiy Counter;
      Counter++;
   else if(Counter > 0)
      Counter--;
   if(Counter < Totalchk)   //Change state of the header CheckBox.
      Inputs[0].checked = false;
   else if(Counter == Totalchk)
      Inputs[0].checked = true;
}
function SelectUnSelectAll(CheckBox)
{
   var grid = document.getElementById('<%= this.CUST_TYPE_DDL.ClientID %>');//Get target base & child control.
   var checkbox = "chkSelect";

   var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

   for(var n = 0; n < Inputs.length; ++n)
    if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0)
         Inputs[n].checked = CheckBox.checked;

   Counter = CheckBox.checked ? Totalchk : 0;
}
    </script>
</asp:Content>