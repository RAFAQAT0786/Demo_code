<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Customer_Organization_Create.aspx.cs" Inherits="Customer_Organization_Create"   Title="Edit User Information" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" ></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height:120px;">
        <h3 class="page-title">Customer Organization Information</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Customer Organization Information</li>
        </ul>
    </div>
<div class="row-fluid">
  <div class="span12">
            <h1 class="page-title"><b>Instructions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label2" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
<div class="row-fluid">
  <div class="span12">
   <!-- BEGIN FORM VALIDATION -->
    <div class="portlet box green">
       <div class="portlet-title">
     <div class="caption"><i class="icon-reorder"></i>Customer Organization Information</div>
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
                    <asp:ListItem>ORGANIZATION</asp:ListItem>
                 </asp:DropDownList>
               <asp:RequiredFieldValidator ID="R13" ControlToValidate="DDL_USER_TYPE" SetFocusOnError="true" runat="server" />
             </ContentTemplate>
            </asp:UpdatePanel> 
          </div>
       </div>
    </div>
<div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Organization Name<span class="required">*</span></label>
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
           <label class="control-label">Contact Name<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_CONT_NAME" runat="server" />
           </div>
       </div>
   </div>
<div class="span6" style="margin-bottom:-15px;">
        <div class="control-group" style="margin-bottom: 4px;">
           <label class="control-label">Mobile Number<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_MOBILE_NO" runat="server"/>
               <asp:RequiredFieldValidator ID="RFV31" runat="server" SetFocusOnError="true"  ErrorMessage="* Mobile Number" ControlToValidate="TXT_MOBILE_NO"/>
               <cc1:FilteredTextBoxExtender ID="FTextBoxE1"  TargetControlID="TXT_MOBILE_NO" FilterType="Numbers"  runat="server"  Enabled="True" FilterMode="ValidChars"/>
               <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TXT_MOBILE_NO" EnableTheming="false"  ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number"/>
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
            </div>
        </div>
    </div>
<div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Address<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_ADDRESS" runat="server"/>
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
            </div>
        </div>
    </div>
 </div> 
 <div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
            <label class="control-label">Subscription Starts<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_START" runat="server" CssClass="span12 m-wrap" />
                    <cc1:calendarextender ID="CalendarExtender3" runat="server" TargetControlID="TXT_START" Format="dd/MMM/yyyy"></cc1:calendarextender>
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_START" runat="server"/>
            </div>
        </div>
    </div>
 <div class="span6" style="margin-bottom:-15px;">
    <div class="control-group" style="margin-bottom: 2px;">
        <label class="control-label">Subscription End<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_END" runat="server" CssClass="span12 m-wrap" />
                    <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="TXT_END" Format="dd/MMM/yyyy"></cc1:calendarextender>
                    <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_END" runat="server"/>
            </div>
        </div>
    </div>
 </div>
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
            <label class="control-label">Therapist Subscription<span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_Sub" runat="server" Text="1" CssClass="span12 m-wrap" />
            </div>
        </div>
    </div>
     <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Patient license Purchase<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_PATIENT" runat="server"/>
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
     <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Login<span class="required">*</span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_LOGIN" runat="server"/>
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
</asp:Content>

