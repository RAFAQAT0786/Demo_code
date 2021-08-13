<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Doctor_Screening.aspx.cs" Inherits="Patient_Doctor_Screening" Title="Patient Doctor Screening Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript"></script>
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Screening Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Patient Screening Information</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="scrtoolkit" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions To Use</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
                <button id="pressed_btn" class="btn red" style="width:150px;height:35px;">Tutorial Video</button>
                <%--<asp:LinkButton ID="btnShow" class="btn red" runat="server" Text="Screening Video" OnClientClick="return ShowModalPopup()" />  
                    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>  
                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"  
                        PopupControlID="pnlPopup" TargetControlID="lnkDummy" BackgroundCssClass="modalBackground" CancelControlID = "btnClose">  
                    </cc1:ModalPopupExtender>  
                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">  
                        <div class="body">  
                            <iframe id = "video" width="420" height="315" frameborder="0" allowfullscreen></iframe>  
                            <br />  
                            <br />  
                            <asp:Button ID="btnClose" runat="server" Text="Close" CssClass="btn purple"/>  
                        </div>  
                    </asp:Panel>  --%>
            </div>
        </div>
    </div>

    <!-- ########### Video Play for popup on left side ############-->
        <div id="play_flo" class="video_player">
            <div class="row">
            <button id="close" style="float:right;">Close</button></div>
            <iframe id = "video2" width="250" height="210" frameborder="0" allowfullscreen></iframe>
        </div>
    <!-- ########### end of Video play ###### -->

    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Patient Screening Information</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Patient Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_NAME" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Age Group<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_AGE_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="PTP_AGE_TXT" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Gender<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_GENDER_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PTP_GENDER_TXT" SetFocusOnError="true" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Mobile Number<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_MOB_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <cc1:FilteredTextBoxExtender ID="FVE11" TargetControlID="PTP_MOB_TXT" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="PTP_MOB_TXT" SetFocusOnError="true" runat="server" />
                                        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="PTP_MOB_TXT" ValidationExpression="^([7-9]{1})([0-9]{9})$" ErrorMessage="Invalid Mobile Number" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
              <asp:Button ID="btnScreen" CssClass="btn green" runat="server" Text="Start Screening" OnClick="btnScreen_Click" />
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>

    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Screening</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                                DataKeyNames="AGDD_DOBSID" PageSize="25" EmptyDataText="No, Record Added">
                                <Columns>
                                    <asp:TemplateField HeaderText="AGDD_DOBSID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="AGDD_DOBSID" runat="server" Text='<%#Eval("AGDD_DOBSID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DOBS_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DOBS_ID" runat="server" Text='<%#Eval("DOBS_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="900px">
                                        <ItemTemplate>
                        <asp:Label ID="DOBS_DESC" runat="server" Text='<%#Eval("DOBS_DESC")%>'
                        oncopy="return allow()"
                        onpaste="return allow()"
                        oncut="return allow()"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Yes" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
               <asp:RadioButton ID="rdbtn2" runat="server" AutoPostBack="false" TextAlign="Left" 
             GroupName="View" Checked='<%# Eval("PTSD_SOMETHING").ToString()=="1" ? true : false %>' 
                    Enabled='<%#(String.IsNullOrEmpty(Eval("PTSD_SOMETHING").ToString()) ? false: true) %>' OnCheckedChanged="rdbtn2_CheckedChanged" CssClass="icon-hand-right" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="No" HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                        <asp:RadioButton ID="rdbtn1" runat="server" AutoPostBack="false" TextAlign="Right" 
                GroupName="View" Checked='<%# Eval("PTSD_VIEW").ToString()=="1" ? true : false %>' 
                 Enabled='<%#(String.IsNullOrEmpty(Eval("PTSD_VIEW").ToString()) ? false: true) %>' OnCheckedChanged="rdbtn1_CheckedChanged" CssClass="icon-hand-right" />  
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID1" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTD_AGDDID" Visible="false" runat="server" Text='<%#Eval("SCTD_AGDDID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID8" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="PTSD_SOMETHING" Visible="false" runat="server" Text='<%#Eval("PTSD_SOMETHING")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID2" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTD_ID" Visible="false" runat="server" Text='<%#Eval("SCTD_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID3" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTP_ID" Visible="false" runat="server" Text='<%#Eval("SCTP_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="portlet-body form">
        <div class="form-horizontal">
            <div class="row-fluid">
                <div class="span6" style="margin-bottom: -15px;">
                    <div class="control-group">
                        <label class="control-label">Remarks<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_REMARK_TXT" runat="server" Height="200px" TextMode="MultiLine" Width="280px"></asp:TextBox>
                            <%--<asp:TextBox ID="PTP_REMARK_TXT" runat="server" Width="888px" Height="100px"/>--%> <%--CssClass="span12 m-wrap" />--%>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-horizontal">
        <div class="form-actions">
            <asp:LinkButton class="btn green" Text="Show Result" OnClientClick="return F();" OnClick="btnShow_Click" ID="LinkButton" runat="server" Visible="false" />
                    <asp:Button ID="btnSave" CssClass="btn blue" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="return Validate_Checkbox()"/>  <%--OnClientClick="return F();"--%>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Disclaimer</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label2" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    &nbsp;&nbsp; 
    <asp:HiddenField Value="0" ID="ID" runat="server" />
    <div class="row-fluid" id="doctor_id" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Screening Result</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel2" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" Width="100%"
                                DataKeyNames="SCTD_DISID" PageSize="25" EmptyDataText="No, Record Added">
                                <Columns>
                                    <asp:TemplateField HeaderText="Disorder Name" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="Disname" runat="server" Text='<%#Eval("Disname")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Scored Rank" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="Total_Percentage" runat="server" Text='<%#Eval("Total_Percentage","{0:N2}")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="TXTVALUE" Value="0" runat="server" />
    <asp:HiddenField ID="AGRP_ID" runat="server" />
    <asp:HiddenField ID="SCTP_ID" runat="server" />
    <asp:HiddenField ID="AGDD_DOBSID" runat="server" />
    <asp:HiddenField ID="PTS_ID" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField4" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField5" runat="server" />

    <style>
            .shower {
                display: block !important;
            }
        </style>

    <script type="text/javascript" language="javascript">

        window.onload = function () {
            var video_url = document.getElementById("<%= HiddenField4.ClientID %>").value;
            if (video_url == null || video_url == 0) {
                document.getElementById('pressed_btn').style.display = 'none';
            }
        }

       function allow() {
            alert("Copy paste and cut not allow");
            return false;
        }
var Totalchk;
var Counter;
<%--window.onload = function()
{
   Totalchk = parseInt('<%= this.GridView1.Rows.Count %>');   //Get total no. of CheckBoxes in side the GridView.
   Counter = 0;
}--%>
function F()
{
    var res = confirm('Do You Want to Show Screening  Result Detail?');
//alert(res);
if(res==false)
{return false;
}
else
{

    var grid=document.getElementById("<%=GridView1.ClientID%>");
    if (!grid)
    {   alert("No Record Selected");
        return false;
    }
    var vData='';
    var checkbox = "chkSelect";
    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
    for(var n = 1; n < Inputs.length; ++n)
        if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0 && Inputs[n].checked)
            vData=vData+ Inputs[n].value + ',';  //alert(vData);
    document.getElementById("<%=AGDD_DOBSID.ClientID %>").value=vData;//alert(vData);
    if (vData=="")
    {
        alert("No Record Selected");
        return false;
    }
            }
        }

        function ShowModalPopup() {
            var digiclock = document.getElementById("<%= HiddenField4.ClientID %>").value;
            //$get("video").src = "https://www.youtube.com/embed/ODBb_vlfJl0";
            $get("video").src = digiclock;
            $find("mpe").show();
            return false;
        }
        function HideModalPopup() {
            $get("video").src = "";
            $find("mpe").hide();
            return false;
        }  

        function getsourceforiframe() {
            var digiclock = document.getElementById("<%= HiddenField4.ClientID %>").value;
            console.log(digiclock);
            //$get("video").src = "https://www.youtube.com/embed/d4kPMZuqtuA";
            $get("video").src = digiclock;
            return false;
        }
        document.querySelector('#pressed_btn').addEventListener('click', function (event) {

            event.preventDefault();
            var digiclock = document.getElementById("<%= HiddenField4.ClientID %>").value;
        console.log(digiclock);
        $get("video2").src = digiclock;
        document.getElementById('play_flo').style.display = 'block';
    })
        document.querySelector('#close').addEventListener('click', function (event) {
            event.preventDefault();
            $get("video2").src = '';
            $("#play_flo").hide();
        })
    </script>
    <style>
        @media screen and (min-width: 768px) {
      #ModalPopupExtender1 {
          top : 66px;
          left: auto;
          bottom: auto;
        overflow: visible;
      }
  }
        .video_player{
            z-index: 50;
            position:fixed;
            /*margin-left :-100px;
            margin-top: 10px;*/
            display:none;
            top :206px;
            left: 10px;
        }
        .shower{
            display:block;
        }
        .remover{
            display:none;
        }
    </style>
</asp:Content>