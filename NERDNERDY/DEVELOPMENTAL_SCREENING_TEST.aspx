<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DOCTOR.master" CodeFile="DEVELOPMENTAL_SCREENING_TEST.aspx.cs" Inherits="DEVELOPMENTAL_SCREENING_TEST" Title="Developmental Screening Test Detail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript"></script>
    <script src="//cdn.ckeditor.com/4.12.1/full/ckeditor.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script> 
     <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>

        <div class="row-fluid" style="height:120px;"> 
            <h3 class="page-title"><span class="username"><asp:Label ID="Label1" runat="server"/></span>Developmental Screening Test</h3>
                <ul class="breadcrumb" >
                    <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
                    <li><i class="icon-table"></i> <a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
                    <li>Developmental Screening Test</li>
                </ul>
            </div>    
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
   
  <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Create New Developmental Screening Test</div>
                </div>

                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                             <div class="span6" style="margin-bottom:-15px;">
                               <div class="control-group">
                                 <label class="control-label">Developmental Age<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="DEVE_AGE_TXT" runat="server" CssClass="span12 m-wrap" /></div>
                                  </div>
                                </div>
                               <div class="span6" style="margin-bottom:-15px;">
                                <div class="control-group">
                                    <label class="control-label">Chronological Age<span class="required">*</span></label>
                                    <div class="controls">
                                      <asp:TextBox ID="CHRO_TXT" runat="server" CssClass="span12 m-wrap" /></div>
                                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="CHRO_TXT"  Display="Dynamic" SetFocusOnError="true" runat="server" />--%>
                                     <%--<asp:CustomValidator ID="CustomValidator2" ControlToValidate="CHRO_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>--%>
                                </div>
                            </div>
                         </div>
                      <div class="row-fluid">
                        <div class="span6" style="margin-bottom:-15px;">
                                <div class="control-group">
                                    <label class="control-label">Developmental Quotient<span class="required">*</span></label>
                                    <div class="controls">
                                      <asp:TextBox ID="DEVE_TXT" runat="server" CssClass="span12 m-wrap" /></div>
                                      <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="DEVE_TXT"  Display="Dynamic" SetFocusOnError="true" runat="server" />
                                     <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DEVE_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>--%>
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
       <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
       <asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <asp:HiddenField ID="hdnID" Value="0" runat="server" />
</asp:Content>

