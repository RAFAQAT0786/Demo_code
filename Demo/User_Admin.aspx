<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="User_Admin.aspx.cs" Inherits="User_Admin"   Title="Edit User Information" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height:120px;">
        <h3 class="page-title">Edit User Information</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>User List</li>
        </ul>
    </div>

    <div class="row-fluid" style="margin-bottom:8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="User_AdminList.aspx" class="btn purple" style="text-align: right;">User List</a>
            </div>
        </div>
    </div>
<div class="row-fluid">
  <div class="span12">
   <!-- BEGIN FORM VALIDATION -->
    <div class="portlet box green">
       <div class="portlet-title">
     <div class="caption"><i class="icon-reorder"></i>Enter User Information</div>
    </div>
   <div class="portlet-body form">
  <!-- BEGIN FORM-->
<div class="form-horizontal">
 <div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
      <div class="control-group">
       <label class="control-label">User Type<span class="required">*</span></label>
         <div class="controls">
           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
             <ContentTemplate>
                <asp:DropDownList ID="DDL_USER_TYPE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                    <asp:ListItem Value="">-- Select User Type --</asp:ListItem>
                    <%--<asp:ListItem>ORGANIZATION</asp:ListItem>
                    <asp:ListItem>Paediatrician</asp:ListItem>
                    <asp:ListItem>Parent</asp:ListItem>--%>
                    <asp:ListItem>Therapist</asp:ListItem>
                 </asp:DropDownList>
               <asp:RequiredFieldValidator ID="R13" ControlToValidate="DDL_USER_TYPE" SetFocusOnError="true" runat="server" />
             </ContentTemplate>
            </asp:UpdatePanel> 
          </div>
       </div>
    </div>
<div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Name<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_ORGANIZATION" runat="server"/>
               <asp:RequiredFieldValidator ID="R1" ControlToValidate="TXT_ORGANIZATION" SetFocusOnError="true" runat="server" />
               <asp:CustomValidator ID="existence" ControlToValidate="TXT_ORGANIZATION" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existuser_ServerValidate"></asp:CustomValidator>
            </div>
        </div>
    </div>
   </div>
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Address<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_ADDRESS" runat="server"/>
               <asp:RequiredFieldValidator ID="R11" ControlToValidate="TXT_ADDRESS" SetFocusOnError="true" runat="server" />
            </div>
        </div>
    </div>
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group" style="margin-bottom: 4px;">
           <label class="control-label">Mobile Number<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_MOBILE_NO" runat="server"/>
               <asp:RequiredFieldValidator ID="RFV31" runat="server" SetFocusOnError="true" ControlToValidate="TXT_MOBILE_NO"/>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXT_MOBILE_NO" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number"/>
               <asp:CustomValidator ID="CustomValidator1" ControlToValidate="TXT_MOBILE_NO" runat="server" ErrorMessage="Mobile No. Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
            </div>
        </div>
    </div>
</div>
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
                <div class="control-group">
                    <label class="control-label">Country<span class="required">*</span></label>
                    <div class="controls">
                        <asp:UpdatePanel ID="UP_COUNTRY" UpdateMode="Conditional" runat="server">
                        <ContentTemplate>
                            <asp:DropDownList ID="CUST_COUNTRY_DDL" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="CUST_COUNTRY_DDL_SelectedIndexChanged">
                                <asp:ListItem Value="0">-- Select Country --</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="CUST_COUNTRY_DDL" SetFocusOnError="true" runat="server" />
                            <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UP_COUNTRY" runat="server">
                                <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                            </asp:UpdateProgress>
                        </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    </div>
                </div>
                <div class="span6" style="margin-bottom:-15px;">
                <div class="control-group" style="margin-bottom:-15px;">
                    <label class="control-label">State<span class="required">*</span></label>
                    <div class="controls">
                        <asp:UpdatePanel ID="UP_RegioanlHQ" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="RegioanlHQ_DDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RegioanlHQ_DDL_SelectedIndexChanged" CssClass="span12 m-wrap">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UP4" AssociatedUpdatePanelID="UP_RegioanlHQ" runat="server">
                            <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
                </div>
            </div>
        <div class="row-fluid">
            <div class="span6" style="margin-bottom:-15px;">
                <div class="control-group">
                    <label class="control-label">City<span class="required">*</span></label>
                    <div class="controls">
                        <asp:UpdatePanel ID="UP_AreaHQ" UpdateMode="Conditional" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="AreaHQ_DDL" runat="server" AutoPostBack="True" CssClass="span12 m-wrap">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdateProgress ID="UpdateP1" AssociatedUpdatePanelID="UP_AreaHQ" runat="server">
                            <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                        </asp:UpdateProgress>
                    </div>
                </div>
            </div>
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Postal / Zip Code<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_PIN" runat="server"/>
               <asp:RequiredFieldValidator ID="R8" ControlToValidate="TXT_PIN" SetFocusOnError="true" runat="server" />
               <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender3"  TargetControlID="TXT_PIN" FilterType="Numbers"  runat="server"  Enabled="True" FilterMode="ValidChars"/>
            </div>
        </div>
    </div>
 </div> 
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Email ID<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox SkinID="etext" ID="TXT_EMAIL" CssClass="span12 m-wrap" runat="server"/>
               <asp:RequiredFieldValidator ID="R16" ControlToValidate="TXT_EMAIL" Display="Dynamic" SetFocusOnError="true" runat="server" />
               <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="TXT_EMAIL" ErrorMessage="* Invalid E-Mail Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" />
               <asp:CustomValidator ID="CustomValidator2" ControlToValidate="TXT_EMAIL" runat="server" ErrorMessage="Email Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
            </div>
        </div>
    </div>
<div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
            <label class="control-label">Start Date<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_START" runat="server" CssClass="span12 m-wrap" />
                    <cc1:calendarextender ID="CalendarExtender3" runat="server" TargetControlID="TXT_START" Format="dd/MMM/yyyy"></cc1:calendarextender>
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_START" runat="server"/>
            </div>
        </div>
    </div>
 </div>
 <div class="row-fluid">
 <div class="span6" style="margin-bottom:-15px;">
    <div class="control-group" style="margin-bottom: 2px;">
        <label class="control-label">End Date<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_END" runat="server" CssClass="span12 m-wrap" />
                    <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="TXT_END" Format="dd/MMM/yyyy"></cc1:calendarextender>
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_END" runat="server"/>
            </div>
        </div>
    </div>
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group" style="margin-bottom: 2px;">
            <label class="control-label">Therapist Subscription<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_Sub" runat="server" Text="1" CssClass="span12 m-wrap" />
                <asp:CompareValidator ID="CompareValidator1" runat="server"
                  ControlToValidate="TXT_Sub" ErrorMessage="Must be greater than 0"
                  Operator="GreaterThan" Type="Integer"
                  ValueToCompare="0" />
            </div>
        </div>
    </div>
 </div>
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group" style="margin-bottom: 2px;">
            <label class="control-label">Patient license Purchase<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_PATIENT" runat="server" Text="1" CssClass="span12 m-wrap" />
                <asp:CompareValidator ID="CompareValidator2" runat="server"
                  ControlToValidate="TXT_PATIENT" ErrorMessage="Must be greater than 0"
                  Operator="GreaterThan" Type="Integer"
                  ValueToCompare="0" />
            </div>
        </div>
    </div>
     <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Login<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_LOGIN" runat="server"/>
            </div>
        </div>
    </div>
  </div>
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Password<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_PASSWORD" runat="server"/>
            </div>
        </div>
    </div>
</div>
<div class="form-actions">
  <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
       </div>
         <!-- END FORM-->
        </div>
    </div>
  <!-- END FORM VALIDATION -->
 </div>
</div> 
<asp:HiddenField Value="0" ID="TXTID" runat="server"/>
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server"/>
</asp:Content>

