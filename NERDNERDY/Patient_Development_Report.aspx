<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Development_Report.aspx.cs" Inherits="Patient_Development_Report" Title="Patient Doctor Report Information" %>
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
        <h3 class="page-title"><span class="username"><asp:Label ID="Label1" runat="server"/></span>Patient Report</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i> <a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
            <li>Patient Report</li>
        </ul>
    </div>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions To Use</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label2" runat="server">

                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom:8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
            </div>
        </div>
    </div>
     <div class="row-fluid">
       <div class="span12">
           <!-- BEGIN FORM VALIDATION -->
           <div class="portlet box green">
               <div class="portlet-title">
                   <div class="caption">
                   <i class="icon-reorder"></i>Developmental Profile</div>
               </div>
                   <div class="portlet-body form">
                       <!-- BEGIN FORM-->
             <div class="form-horizontal">
                <div class="row-fluid">
                    <div class="span6" style="margin-bottom:-15px;">
                       <div class="control-group">
                          <label class="control-label">Patient Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox ID="PTP_NAME_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                           </div>
                        </div>
                     </div>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Age Group<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_AGE_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                        </div>
                    </div>
                 </div>
               </div>
              <div class="row-fluid">
                <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Gender<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_GENDER_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                            </div>
                         </div>
                     </div>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Grade<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="GRADE_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                        </div>
                    </div>
                 </div>
             </div>
            <div class="row-fluid">
                <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Name Of The Organization<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="ORG_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                            </div>
                         </div>
                     </div>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Address<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="ADDRESS_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                        </div>
                    </div>
                 </div>
             </div>
            <div class="row-fluid">
                <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Email<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="EMAIL_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                            </div>
                         </div>
                     </div>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Phone Number<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PHONE_TXT" runat="server" Visible="true" CssClass="span12 m-wrap" />
                        </div>
                    </div>
                 </div>
             </div>
              <div class="row-fluid">
                  <div class="span12" style="margin-bottom:-15px;">
                    <div class="control-group">
                       <label class="control-label">Reason For Referral<span class="required">*</span></label>
                         <div class="controls">
                            <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor1_error"></textarea>
                            <div id="editor1_error"></div>
                        </div>
                      </div>                   
                  </div>
               </div>
              <div class="row-fluid">
                  <div class="span12" style="margin-bottom:-15px;">
                    <div class="control-group">
                       <label class="control-label">Medical History<span class="required">*</span></label>
                         <div class="controls">
                            <textarea class="span12 ckeditor m-wrap" id="Textarea2" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                            <div id="editor2_error"></div>
                        </div>
                      </div>                   
                  </div>
               </div>
             <div class="form-horizontal"> 
               <div class="control-group" style="margin-bottom: 10px;">
                  <label class="control-label">Development History<span class="required">*</span></label>
                    <div class="controls">
                        <textarea class="span12 ckeditor m-wrap" id="Textarea3" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor3_error"></textarea>
                        <div id="editor3_error"></div>
                     </div>
                 </div>
              </div>
              <div class="row-fluid">
                  <div class="span12" style="margin-bottom:-15px;">
                    <div class="control-group">
                       <label class="control-label">Family History<span class="required">*</span></label>
                         <div class="controls">
                            <textarea class="span12 ckeditor m-wrap" id="Textarea4" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor4_error"></textarea>
                            <div id="editor4_error"></div>
                        </div>
                      </div>                   
                  </div>
               </div>
             <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Symptoms Narrated By Parents/Caregiver<span class="required">*</span></label>
                        <div class="controls">
                        <textarea class="span12 ckeditor m-wrap" id="Textarea6" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor5_error"></textarea>
                        <div id="editor6_error"></div>
                        </div>
                    </div>
                </div>
             <div class="form-horizontal">
                <div class="control-group">
                   <label class="control-label">Clinical Observation<span class="required">*</span></label>
                     <div class="controls">
                        <textarea class="span12 ckeditor m-wrap" id="Textarea5" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor5_error"></textarea>
                        <div id="editor5_error"></div>
                        </div>
                    </div>
                    </div>
             <div class="form-horizontal">
                <div class="control-group">
                    <label class="control-label">Clinical Diagnostic<span class="required">*</span></label>
                       <div class="controls">
                          <textarea class="span12 ckeditor m-wrap" id="Textarea11" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor11_error"></textarea>
                           <div id="editor11_error"></div>
                      </div>
                  </div>
               </div>
                 <div class="row-fluid">
                    <div class="span6" style="margin-bottom:-15px;">
                       <div class="control-group">
                          <label class="control-label">Doctor's Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox ID="TXT_DOC_NAME" runat="server" Visible="true" CssClass="span12 m-wrap" />
                           </div>
                        </div>
                     </div>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Doctor's Designation<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="TXT_DOC_DESIG" runat="server" Visible="true" CssClass="span12 m-wrap" />
                        </div>
                    </div>
                 </div>
               </div>
                 <div class="row-fluid">
                    <div class="span6" style="margin-bottom:-15px;">
                       <div class="control-group">
                          <label class="control-label">Doctor's Registration ID / MCI No. / RCI No.<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox ID="TXT_DOC_REG" runat="server" Visible="true" CssClass="span12 m-wrap" />
                           </div>
                        </div>
                     </div>
                  </div>
                 <div class="row-fluid">
                  <div class="span12" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Disclaimer<span class="required">*</span></label>
                        <div class="controls">
                            <asp:label ID="TXT_DISCLAIMER" Text="Please confirm first" runat="server" Visible="true" CssClass="span12 m-wrap" />
                            <p>The report templates is to be used by the registered and authorized Medical/Rehabilitation professional. The professional using NerdNerdy Report template takes the sole responsibility that their degree/registration is recognized by the authorized Institution approved by the Government of that particular country of which the professional belongs to.

Please note that some of the assessment tests used in NerdNerdy application are non- standardized in nature. NerdNerdy takes no responsibility on misinterpretation of data by the medical professional/rehabilitation therapist. It is the sole responsibility of the therapist to clinically corelate.

Please note that there is no copyright infringement in some of the standardized tests included in the application. NerdNerdy has not included in whole or part any such assessment scales in the application. It has just provided the tables to include the scores received after administering the actual tests.

Since the application is used by the authorized Medical/rehabilitation professional, thus it is the sole responsibility of such professionals to assume the responsibility for accuracy and privacy/confidentiality of patients. NerdNerdy Technologies Pvt Ltd, nor affiliated partnerships or bodies corporate, nor directors, shareholders, managers, partners, employees or agents of any of them are held responsible of the accuracy, privacy and confidentiality breach of information shared by the therapist to his/her patients. </p>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                        </div>
                    </div>
                 </div>
               </div>
                    <div class="form-actions">
                            <asp:Button ID="SAVEBTN" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                      </div>
                 </div> 
             </div>
         </div>
      </div>
    </div>
    <asp:ObjectDataSource SelectMethod="GetParent" TypeName="BLLAge" 
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_PATIENT_DETAIL">
    <DeleteParameters>
        <asp:Parameter Name="PTP_ID" Type="String" />
    </DeleteParameters>
<SelectParameters>
    <asp:Parameter Name="PTP_ID" Type="String" />
    <asp:SessionParameter Name="pATSession" Type="Object" SessionField="User" /> 
</SelectParameters>
</asp:ObjectDataSource>
<asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
<asp:HiddenField Value="0" ID="HiddenField4" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID2" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField5" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField6" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField7" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField8" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField9" runat="server" />
<asp:HiddenField Value="0" ID="TXTVEHID" runat="server" />
<script type="text/javascript" src="App_Resources/javascript/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="App_Resources/javascript/thickbox-compressed.js"></script>
<link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" />
    <script type="text/javascript">
        function basicPopup() {
            $(document).ready(function () {
            
                var id = $("#" + '<%= HiddenField1.ClientID %>').val();
           
                $('a#popupiep').live('click', function (e) {
                    var link = "CARS_RATING.aspx?id=" + id
              
                    $('a#popupiep').prop("href", link)
                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
                            title: "CAR RATING",
                            buttons: {
                                "Close": function () { $dialog.dialog('close'); }
                            },
                            close: function (event, ui) {
                                window.location.href = window.location.href;
                            }
                        });
                    $dialog.dialog('open');
                    e.preventDefault();
                });
                });
            
        }

        function basicPopup1() {
            $(document).ready(function () {

                var id = $("#" + '<%= HiddenField2.ClientID %>').val();

                $('a#popupiep1').live('click', function (e) {
                    var link = "VSMS_RATING.aspx?id=" + id

                    $('a#popupiep1').prop("href", link)
                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
                            title: "VSMS RATING",
                            buttons: {
                                "Close": function () { $dialog.dialog('close'); }
                            },
                            close: function (event, ui) {
                                window.location.href = window.location.href;
                            }
                        });
                    $dialog.dialog('open');
                    e.preventDefault();
                });
            });

        }

        function basicPopup2() {
            $(document).ready(function () {

                var id = $("#" + '<%= HiddenField3.ClientID %>').val();

                $('a#popupiep2').live('click', function (e) {
                    var link = "CEREBAL_PALSY_RATING.aspx?id=" + id

                    $('a#popupiep2').prop("href", link)
                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
                            title: "CEREBAL PALSY RATING",
                            buttons: {
                                "Close": function () { $dialog.dialog('close'); }
                            },
                            close: function (event, ui) {
                                window.location.href = window.location.href;
                            }
                        });
                    $dialog.dialog('open');
                    e.preventDefault();
                });
            });

        }

        function basicPopup3() {
            $(document).ready(function () {

                var id = $("#" + '<%= HiddenField4.ClientID %>').val();

                $('a#popupiep3').live('click', function (e) {
                    var link = "DOWN_SYNDROME_RATING.aspx?id=" + id

                    $('a#popupiep3').prop("href", link)
                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
                            title: "DOWN SYNDROME RATING",
                            buttons: {
                                "Close": function () { $dialog.dialog('close'); }
                            },
                            close: function (event, ui) {
                                window.location.href = window.location.href;
                            }
                        });
                    $dialog.dialog('open');
                    e.preventDefault();
                });
            });

        }

         function basicPopup4() {
            $(document).ready(function () {

                var id = $("#" + '<%= HiddenField5.ClientID %>').val();

                $('a#popupiep4').live('click', function (e) {
                    var link = "ADHD_RATING.aspx?id=" + id

                    $('a#popupiep4').prop("href", link)
                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
                            title: "ADHD RATING",
                            buttons: {
                                "Close": function () { $dialog.dialog('close'); }
                            },
                            close: function (event, ui) {
                                window.location.href = window.location.href;
                            }
                        });
                    $dialog.dialog('open');
                    e.preventDefault();
                });
            });

        }

</script>
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
      <asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <asp:HiddenField ID="hdnID" Value="0" runat="server" />
     <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
  <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField10" Value="0" runat="server" />
</asp:Content>
