<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="ChangeAdmPass.aspx.cs" Inherits="ChangeAdmPass" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row-fluid" style="height:120px;">
        <h3 class="page-title">Edit Personal Password</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Edit Personal Password</li>
        </ul>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Edit Personal Password</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                          <div class="span6" style="margin-bottom:-15px;">
                            <div class="control-group">
                            <label class="control-label">Old Password<span class="required">*</span></label>
                            <div class="controls">
                                        <asp:TextBox  ID="TXT_OLD_PASS" CssClass="span12 m-wrap" TextMode="Password" runat="server"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="TXT_OLD_PASS" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                        <div class="span6" style="margin-bottom:-15px;">
                           <div class="control-group">
                             <label class="control-label">New Password<span class="required">*</span></label>
                            <div class="controls">
                                        <asp:TextBox  ID="TXT_NEW_PASS" CssClass="span12 m-wrap" TextMode="Password" runat="server"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TXT_NEW_PASS" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                       </div> 
                        <div class="row-fluid">
                          <div class="span6" style="margin-bottom:-15px;">
                            <div class="control-group">
                            <label class="control-label">Confirm Your Password<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox  ID="TXT_CONF_PASS" CssClass="span12 m-wrap" TextMode="Password" runat="server"/>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TXT_CONF_PASS" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                <asp:CompareValidator ID="CV" ControlToValidate="TXT_CONF_PASS" skinid="pwd"   ControlToCompare="TXT_NEW_PASS" Operator="Equal" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                    </div>
                    </div>
                    <div class="form-actions">
                            <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                    </div>
                </div>
            </div>
        </div>
     </div>
<asp:HiddenField Value="0" ID="TXTID" runat="server" /></div>
</asp:Content>

