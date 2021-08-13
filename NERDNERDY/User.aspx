<%@ Page Language="C#" MasterPageFile="~/Organization.master" AutoEventWireup="true" CodeFile="User.aspx.cs" Inherits="User" Title="User Organization Information" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
<script type="text/javascript" src="App_Resources/javascript/jquery-1.9.1.js"></script>
 <script type="text/javascript" src="App_Resources/javascript/jquery-ui.js" ></script>
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
        <h3 class="page-title">User Organization Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><asp:LinkButton runat="server" Text="Home" CausesValidation="false" ID="btn_home" onclick="btn_home_Click"></asp:LinkButton><i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i> <a href="UserList.aspx">User List</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i>User Organization Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="UserList.aspx" class="btn purple" style="text-align: right;">User List</a>
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
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                   <label class="control-label">Organization Name<span class="required">*</span></label>
                                    <div class="controls">
                                       <asp:TextBox CssClass="span12 m-wrap" ID="ORGANIZATION_DDL" runat="server"/>
                                       <asp:RequiredFieldValidator ID="R1" ControlToValidate="ORGANIZATION_DDL" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom:-15px;">
                                <div class="control-group">
                                    <label class="control-label">User Type<span class="required">*</span></label>
                                        <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>
                                            <asp:DropDownList ID="DDL_USER_TYPE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                <asp:ListItem Value="">-- Select User Type --</asp:ListItem>
                                                <asp:ListItem>Therapist</asp:ListItem>
                                                <asp:ListItem>Health care professional</asp:ListItem>
                                                <%--<asp:ListItem>Paediatrician</asp:ListItem>--%>
                                                </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="R13" ControlToValidate="DDL_USER_TYPE" SetFocusOnError="true" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel> 
                                        </div>
                                    </div>
                                </div>
                            
                        </div>
                        
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                   <label class="control-label">Name of Therapist Assigned<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox CssClass="span12 m-wrap" ID="CUST_NAME_TXT" runat="server" /><%--TextMode="Password"/>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                               <div class="control-group">
                                 <label class="control-label">Designation Of Therapist<span class="required">*</span></label>
                                    <div class="controls">
                                       <asp:TextBox CssClass="span12 m-wrap" ID="TXT_DESIGNATION" runat="server" />
                                       <asp:RequiredFieldValidator ID="R2" ControlToValidate="TXT_DESIGNATION" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                   <label class="control-label">No. of Patients Assigned<span class="required">*</span></label>
                                    <div class="controls">
                                       <asp:TextBox CssClass="span12 m-wrap" ID="TXT_VALUE" runat="server" />
                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TXT_VALUE" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: 4px;">
                                    <label class="control-label">Mobile Number<span class="required">*</span></label>
                                    <div class="controls">
                                       <asp:TextBox CssClass="span12 m-wrap" ID="CUST_MOBILE_TXT" runat="server" />
                                       <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="CUST_MOBILE_TXT" SetFocusOnError="true" ID="R5" runat="server" />
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="CUST_MOBILE_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
                                       <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="CUST_MOBILE_TXT" EnableTheming="false"  ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                           <div class="span6" style="margin-bottom: -15px;">
                            <div class="control-group">
                               <label class="control-label">Email ID<span class="required">*</span></label>
                                    <div class="controls">
                                       <asp:TextBox SkinID="etext" ID="CUST_EMAIL_TXT" CssClass="span12 m-wrap" runat="server"/>
                                       <asp:RequiredFieldValidator ID="R16" ControlToValidate="CUST_EMAIL_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                       <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="CUST_EMAIL_TXT" ErrorMessage="* Invalid E-Mail Id" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator1" runat="server" />
                                       <asp:CustomValidator ID="CustomValidator1" ControlToValidate="CUST_EMAIL_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                               <div class="control-group">
                                 <label class="control-label">Subscription Starts<span class="required">*</span></label>
                                    <div class="controls">
                                      <asp:TextBox ID="TXT_START" runat="server" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:calendarextender ID="CalendarExtender3" runat="server" TargetControlID="TXT_START" Format="dd/MMM/yyyy"></cc1:calendarextender>
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_START" runat="server"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                          <div class="span6" style="margin-bottom: -15px;">
                            <div class="control-group" style="margin-bottom: 2px;">
                                <label class="control-label">Subscription Ends<span class="required">*</span></label>
                                    <div class="controls">
                                    <asp:TextBox ID="TXT_END" runat="server" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:calendarextender ID="CalendarExtender1" runat="server" TargetControlID="TXT_END" Format="dd/MMM/yyyy"></cc1:calendarextender>
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="TXT_END" runat="server"/>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                              <div class="control-group">
                                <label class="control-label">Prospective Category <span class="required">*</span></label>
                                <div class="controls">
                                        <asp:DropDownList ID="ddlProspective" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Prospective --</asp:ListItem>
                                            <asp:ListItem Value="1">Existing</asp:ListItem>
                                            <asp:ListItem Value="2">Prospective</asp:ListItem>
                                        </asp:DropDownList>
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
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator16" InitialValue="0" ControlToValidate="CUST_COUNTRY_DDL" SetFocusOnError="true" runat="server" />
                                                <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UP_COUNTRY" runat="server">
                                    <ProgressTemplate><img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                          <div class="span6" style="margin-bottom: -15px;">
                                 <div class="control-group" style="margin-bottom: 2px;">
                                    <label class="control-label">State<span class="required">*</span></label>
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
                </div>
                  <div class="row-fluid">
                    <div class="span6" style="margin-bottom:-15px;">
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
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
           <label class="control-label">Login<span class="required"></span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_LOGIN" runat="server"/>
            </div>
        </div>
    </div>
 </div>
<div class="row-fluid">
    <div class="span6" style="margin-bottom:-15px;">
        <div class="control-group">
           <label class="control-label">Password<span class="required"></span></label>
           <div class="controls">
               <asp:TextBox CssClass="span12 m-wrap" ID="TXT_PASSWORD" runat="server"/>
            </div>
        </div>
    </div>
 </div>  
<div class="form-actions">
  <asp:Button ID="btnSave" CssClass="btn yellow" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
       </div>
         <!-- END FORM-->
        </div>
    </div>
  <!-- END FORM VALIDATION -->
 </div>
</div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    <asp:HiddenField ID="HiddenField7" runat="server" />
    <asp:HiddenField ID="HiddenField8" runat="server" />
    <asp:HiddenField ID="HiddenField9" runat="server" />
    <asp:HiddenField ID="HiddenField10" runat="server" />
    <asp:HiddenField ID="HiddenField11" runat="server" />
    <asp:HiddenField ID="ORGANIZATION_NAME" runat="server" />
</asp:Content>