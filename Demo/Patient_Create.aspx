<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Create.aspx.cs" Inherits="Patient_Create" Title="Patient's personal Details Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Create New Patient</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><a href="Patient.aspx">Go To Patient Detail</a> <i class="icon-angle-right"></i></li>
            <li>Create New Patient Information</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn green" CausesValidation="false" PostBackUrl="~/Patient.aspx">Go To Patient Detail</asp:LinkButton>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN VALIDATION STATES-->
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-reorder"></i>Create New Patient</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Name of the Patient<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_NAME_TXT" ValidationGroup="NONE" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PTP_NAME_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Therapist Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_THERAPIST_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="PTP_THERAPIST_TXT" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Parent's Qualification</label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_QUA_TXT" ValidationGroup="NONE" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="PTP_QUA_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="DDLAGEGROUP" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="DDLAGE" CssClass="span12 m-wrap" runat="server" AutoPostBack="true">
                                                    <asp:ListItem Value="0">-- Select Age Group Name --</asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLAGE" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">
                                        Gender<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel4" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="PTP_GENDER" runat="server" CssClass="span12 m-wrap">
                                                    <asp:ListItem Text="Male"></asp:ListItem>
                                                    <asp:ListItem Text="Female"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Referred By<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="REFERRED_TXT" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select Referred By --</asp:ListItem>
                                            <asp:ListItem Value="1">Self</asp:ListItem>
                                            <asp:ListItem Value="2">Therapist</asp:ListItem>
                                            <asp:ListItem Value="3">Paediatricain</asp:ListItem>
                                            <asp:ListItem Value="4">School</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator Display="Dynamic" ErrorMessage="*" ControlToValidate="REFERRED_TXT" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Mobile Number<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_MOB_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <cc1:FilteredTextBoxExtender ID="FVE11" TargetControlID="PTP_MOB_TXT" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="PTP_MOB_TXT" SetFocusOnError="true" runat="server" />
                                        <%--<asp:CustomValidator ID="CustomValidator3" ControlToValidate="PTP_MOB_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>--%>
                                        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="PTP_MOB_TXT" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number" />
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
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="CUST_COUNTRY_DDL" SetFocusOnError="true" runat="server" />
                                                <asp:UpdateProgress ID="UpdateProgress2" AssociatedUpdatePanelID="UP_COUNTRY" runat="server">
                                                    <ProgressTemplate>
                                                        <img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                                </asp:UpdateProgress>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                         <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group" style="margin-bottom: -15px;">
                                    <label class="control-label">State<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UP_RegioanlHQ" UpdateMode="Conditional" runat="server">
                                            <ContentTemplate>
                                                <asp:DropDownList ID="RegioanlHQ_DDL" runat="server" AutoPostBack="True" OnSelectedIndexChanged="RegioanlHQ_DDL_SelectedIndexChanged" CssClass="span12 m-wrap">
                                                </asp:DropDownList>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdateProgress ID="UP4" AssociatedUpdatePanelID="UP_RegioanlHQ" runat="server">
                                            <ProgressTemplate>
                                                <img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
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
                                            <ProgressTemplate>
                                                <img alt="" src="App_Resources/images/loadinfo.gif" />Please Wait..</ProgressTemplate>
                                        </asp:UpdateProgress>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Email<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_EMAIL_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" SetFocusOnError="true" ControlToValidate="PTP_EMAIL_TXT" runat="server" />
                                        <asp:RegularExpressionValidator Display="Dynamic" ControlToValidate="PTP_EMAIL_TXT" ErrorMessage="* Invalid E-Mail Id"
                                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ID="RegularExpressionValidator4"
                                            runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Primary Language<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PRIMARY_TXT" ValidationGroup="NONE" Enabled="false" Text="Demo" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="PRIMARY_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Parents Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PARENT_TXT" ValidationGroup="NONE" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="PARENT_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Fathers Occupation<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="FATHER_TXT" ValidationGroup="NONE" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="FATHER_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Mothers Occupation<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="MOTHER_TXT" ValidationGroup="NONE" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="MOTHER_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                         </div>
                        

                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Parent Concern</label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_REMARK_TXT" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:CustomValidator ID="CustomValidator4" ControlToValidate="PTP_REMARK_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Prior Diagnosis<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PRIOR_TXT" ValidationGroup="NONE" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="PRIOR_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Prior Therapy<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="THERAPY_TXT" ValidationGroup="NONE" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="THERAPY_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Patient Address<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_ADD_TXT" ValidationGroup="NONE" Text="Demo" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="PTP_ADD_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Pincode<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PINCODE_TXT" ValidationGroup="NONE" Text="1234" Enabled="false" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="PINCODE_TXT" Display="Dynamic" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                       
                        <div class="form-actions">
                            <asp:Button ID="SAVEBTN" CssClass="btn blue" runat="server" Text="SAVE" OnClick="btnSave_Click" />
                        </div>
                        <!-- END FORM-->
                    </div>
                </div>
                <!-- END VALIDATION STATES-->
            </div>
        </div>
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <%--<script type="text/javascript" language="javascript">
     function CheckForPastDate(e) {
        var today = new Date();
        var dateofbirth = e.get_selectedDate();
        var months = (today.getMonth() - dateofbirth.getMonth() + (12 * (today.getFullYear() - dateofbirth.getFullYear())));
         document.getElementById('<%=TextBox1.ClientID %>').value = Math.floor(months / 12);
        }
    </script>--%>
</asp:Content>