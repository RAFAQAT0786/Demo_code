<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Patient_Doctor_Assessment_Report.aspx.cs" Inherits="Patient_Doctor_Assessment_Report" Title="Patient Doctor Assessment Report" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="App_Resources/StyleSheet/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap-responsive.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-metro.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap-daterangepicker/daterangepicker.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN PAGE LEVEL STYLES -->
    <link href="assets/css/pages/tasks.css" rel="stylesheet" type="text/css" media="screen" />
    <!-- END PAGE LEVEL STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN FORM VALIDATION -->
                <div class="portlet box green" runat="server" height="500" width="705">
                    <div class="portlet-title">
                        <div class="caption">Patient Doctor Assessment Report</div>
                    </div>
                    <div class="portlet-body form">
                        <!-- BEGIN FORM-->
                        <div class="form-horizontal">
                            <div class="form-horizontal">
                                <div class="form-horizontal">
                                    <div class="row-fluid">
                                        <div class="span6" style="margin-bottom: -15px;">
                                            <div class="control-group">
                                                <label class="control-label">Patient Name<span class="required">*</span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="PTP_TXT" runat="server" Visible="false" CssClass="span12 m-wrap" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="span6" style="margin-bottom: -15px;">
                                            <div class="control-group">
                                                <label class="control-label">Age Group<span class="required">*</span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="PTP_AGE_TXT" runat="server" Visible="false" CssClass="span12 m-wrap" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6" style="margin-bottom: -15px;">
                                            <div class="control-group">
                                                <label class="control-label">Gender<span class="required">*</span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="PTP_GENDER_TXT" runat="server" Visible="false" CssClass="span12 m-wrap" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="span6" style="margin-bottom: -15px;">
                                            <div class="control-group">
                                                <label class="control-label">Date of Evaluation<span class="required">*</span></label>
                                                <div class="controls">
                                                    <asp:TextBox ID="PTP_DATE_TXT" runat="server" Visible="false" CssClass="span12 m-wrap" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row-fluid">
                                        <div class="span6" style="margin-bottom: -15px;">
                                            <div class="control-group">
                                                <label class="control-label">Disorder<span class="required">*</span></label>
                                                <div class="controls">
                                                    <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" Visible="false" runat="server" AutoPostBack="True">
                                                        <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:CustomValidator ID="existence" ControlToValidate="DDLDIS" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                                    <asp:RequiredFieldValidator ControlToValidate="DDLDIS" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="hiddenModalContent" style="display: none">
            <input type="submit" value="Close" onclick="tb_remove()" />
            <div id="DivIdToPrint" style="font: 10px Arial;">
                <h1 style="font: 22px Arial; text-align: center; font-weight: bolder; text-decoration: underline;">PATIENT<b><span id="EMSSTATUS" runat="server" /></b> REPORT</h1>
                <table border="0" width="650px" style="font: 12px Arial; line-height: 17px">
                    <tr>
                        <td>1.PATIENT NAME: <span id="PATIENTNAME" class="rptfield" runat="server" /></td>
                        <td>2.GENDER: <span id="PATIENTGENDER" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>3.DATE OF BIRTH: <span id="PATIENTDATE" class="rptfield" runat="server" /></td>
                        <td>4.AGE: <span id="PATIENTAGE" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>5.DATE OF EVALUATION: <span id="PATIENTEVALUATION" class="rptfield" runat="server" /></td>
                        <td>6.SCHOOL: <span id="PATIENTSCHOOL" class="rptfield" runat="server" visible="false" /></td>
                    </tr>
                    <tr>
                        <td style="line-height: 50px"></td>
                    </tr>
                    <tr>
                        <td><u><b>REASON FOR REFERRAL:</b></u></td>
                    </tr>
                    <tr>
                        <td>REASON <span id="SPEEDSTATUS" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>EVALUATION METHOD:</b></u></td>
                    </tr>
                    <tr>
                        <td>Clinical Observation <span id="Span1" runat="server" /></td>
                        <td>Parent's Interview <span id="Span2" runat="server" /></td>
                        <td>Development Screening Test <span id="Span3" runat="server" /></td>
                        <td>Vineland Social Maturity Scale <span id="Span4" runat="server" /></td>
                        <td>Childhood Autism Rating Scale-2 <span id="Span5" runat="server" /></td>
                    </tr>

                    <tr>
                        <td>Medical History <span id="Span6" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>No medical complications were reported by the Parents:</b></u></td>
                    </tr>

                    <tr>
                        <td>Development History <span id="Span7" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>No medical complications were reported by the Parents:</b></u></td>
                    </tr>

                    <tr>
                        <td>Family History <span id="Span8" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>patient name:</b></u></td>
                    </tr>

                    <tr>
                        <td>On Observation <span id="Span9" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>patient name:</b></u></td>
                    </tr>

                    <tr>
                        <td>Physical Behaviour <span id="Span10" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>Behaviour:</b></u></td>
                    </tr>

                    <tr>
                        <td>Physical Behaviour <span id="Span11" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>Behaviour:</b></u></td>
                    </tr>

                    <tr>
                        <td>Oral Motor Development/Eating Behaviour <span id="Span12" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>Oral Motor Development:</b></u></td>
                    </tr>

                    <tr>
                        <td>Gross Motor and Fine Motor development <span id="Span13" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>Oral Motor Development:</b></u></td>
                    </tr>

                    <tr>
                        <td>Socail/Emotional development <span id="Span14" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><u><b>Emotional Development:</b></u></td>
                    </tr>
                    <tr>
                        <td style="line-height: 50px"></td>
                    </tr>
                    <tr>
                        <td>Auth. Signatory</td>
                        <td align="right">Auth. Signatory</td>
                    </tr>
                    <tr>
                        <td><span id="CUSTNAME1" class="rptfield" runat="server" /></td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="form-actions">
            <asp:Button ID="Button1" runat="server" Height="30px" Width="100px" Text="Update" CssClass="btn green" OnClick="Updatebtn_Click" ValidationGroup="Save" />
        </div>

        <div id="hiddenModalContentCertificate" style="display: none">
            <input type="submit" value="Close" onclick="tb_remove()" />
            <div id="DivIdToPrintCertificate" style="font: 10px Arial;">
                <h1 style="font: 22px Arial; text-align: center; font-weight: bolder; text-decoration: underline;">PATIENT LIST</h1>

                <table border="0" width="650px" style="font: 12px Arial; line-height: 17px">
                    <tr>
                        <td>Patient Name:</td>
                        <td><span id="PATIENTNAME1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>GENDER :</td>
                        <td><span id="PATIENTGENDER1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>DATE OF BIRTH. :</td>
                        <td><span id="PATIENTDATE1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>AGE :</td>
                        <td><span id="PATIENTAGE1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>DATE OF EVALUATION :</td>
                        <td><span id="PATIENTEVALUATION1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>SCHOOL :</td>
                        <td><span id="PATIENTSCHOOL1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td>REASON FOR REFERRAL :</td>
                        <td><span id="AMCVALIDUPTO1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: justify">REASON<span id="SPEEDSTATUS2" runat="server" /></td>
                    </tr>
                    <tr>
                        <td colspan="2"></td>
                        <td align="right">Authorized Centre</td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><span id="SCNAME1" class="rptfield" runat="server" /></td>
                    </tr>
                    <tr>
                        <td><b>AUTHORIZED SIGNATORY</b></td>
                    </tr>
                    <tr>
                        <td colspan="3">Customers are requested to produce the original documents, reports as required</td>
                    </tr>
                    <tr>
                        <td colspan="3"><b>Undertaking:</b><br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">Signature of Customer<br />
                            <br />
                            (VALID FOR THREE MONTHS FROM DATE OF ISSUE)</td>
                    </tr>
                </table>
            </div>
        </div>

        <asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
        <asp:HiddenField Value="0" ID="TXTVEHID" runat="server" />
        <script type="text/javascript" src="App_Resources/javascript/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="App_Resources/javascript/thickbox-compressed.js"></script>
        <link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" />
        <script type="text/javascript" language="javascript">
    function printdiv(divnametoprint, type) {
        debugger;
        var strBreak = (type == 'PTP_NAME' ? '<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>' : '<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>')
        var divToPrint = document.getElementById(divnametoprint);//alert(divToPrint.innerHTML);
        var newWin = window.open('', '', 'width=100,height=100');  //alert(newWin);
        newWin.document.open();
        newWin.document.write('<html><head><link rel="stylesheet" href="App_Resources/StyleSheet/print.css" type="text/css" media="screen" /><link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" /></head><body onload="AddFirstPage();" class="print">' + divToPrint.innerHTML + strBreak + divToPrint.innerHTML + '</body></html>');
        newWin.document.close();
        setTimeout(function () { newWin.close(); }, 1000);
        newWin.focus();
        newWin.print();
        newWin.close();
        return true;
    }
        </script>
        <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
        <asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <asp:HiddenField ID="hdnID" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
        <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
    </form>
</body>
</html>