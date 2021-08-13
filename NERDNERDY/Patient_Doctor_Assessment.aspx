<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Doctor_Assessment.aspx.cs" Inherits="Patient_Doctor_Assessment" Title="Patient Doctor Assessment Information" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript"></script>
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script> 
     <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>

    <div class="row-fluid" style="height:120px;">
        <h3 class="page-title">Assessment & Generate Individualized Education Plan(IEP)</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Assessment & Generate Individualized Education Plan(IEP)</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="scrtoolkit" runat="server" />
    <div class="row-fluid" id="Instructions" runat="server">
        <div class="span12">
            <h1 class="page-title-patient-instruction"><b>Instructions & Directions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom:8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient Detail</a>
                <button id="pressed_btn" class="btn red" style="width:150px;height:35px;">Tutorial Video</button>
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
            <div class="portlet box purple">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Assessment & Generate Individualized Education Plan(IEP)</div>
                </div>
              <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                <div class="form-horizontal">
                  <div class="row-fluid">
                    <div class="span6" style="margin-bottom:-15px;">
                       <div class="control-group">
                          <label class="control-label">Patient Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox ID="PTP_NAME" runat="server" CssClass="span12 m-wrap" />
                           </div>
                        </div>
                     </div>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Age Group<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_AGE" runat="server" CssClass="span12 m-wrap" />
                        </div>
                    </div>
                 </div>
               </div>
              <div class="row-fluid" runat="server" id="GENDER">
                <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Gender<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_GENDER_TXT" runat="server" CssClass="span12 m-wrap" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PTP_GENDER_TXT" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                     </div>
                   <div class="span6" style="margin-bottom:-15px;">
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

              <div class="row-fluid">
                <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                        <label class="control-label">Disorder<span class="required">*</span></label>
                        <div class="controls">
                            <asp:UpdatePanel ID="DISORDER" UpdateMode="Conditional" runat="server">
                                <ContentTemplate>
                            <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                            </asp:DropDownList>
                                    </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                     </div>
                  </div>
               </div>

           <div class="form-actions">
              <asp:Button ID="btnAssessment" CssClass="btn green" runat="server" Text="Patient Assessment" OnClick="btnAssessment_Click" />
          </div>
        </div>
      <!-- END FORM-->
    </div>
  </div>
  <!-- END FORM VALIDATION -->
</div>
</div>
<asp:HiddenField Value="0" ID="TXTID" runat="server" />
        <div class="row-fluid" id="AGDD" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Patient Assessment & Customised</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>                      
   <div class="portlet-body">
   <div class="table table-striped table-bordered table-hover">
    <asp:Panel ID="Panel1"  ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
      <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%" 
          DataKeyNames="AGDD_DOBSID" PageSize="25" EmptyDataText="No, Record Added">
           <Columns>
               <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="900px" >
                    <ItemTemplate>
                        <asp:Label ID="DOBS_DESC" runat="server" Text='<%#Eval("DOBS_DESC")%>' oncopy="return allow()"
                        onpaste="return allow()"
                        oncut="return allow()"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left"/>
                </asp:TemplateField>
               
               <asp:TemplateField HeaderText="Yes" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn3" runat="server" Width="50px" AutoPostBack="false" TextAlign="Left" 
                           GroupName="View" OnCheckedChanged="rdbtn3_CheckedChanged" CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn2" runat="server" Width="50px" AutoPostBack="false" TextAlign="Left" 
                           GroupName="View" OnCheckedChanged="rdbtn2_CheckedChanged" CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Sometimes" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn1" runat="server" AutoPostBack="false" TextAlign="Left" 
                  GroupName="View" Checked='<%# Eval("PTAD_SOMETHING").ToString()=="1" ? true : false %>' 
                            Enabled='<%#(String.IsNullOrEmpty(Eval("PTAD_SOMETHING").ToString()) ? false: true) %>' OnCheckedChanged="rdbtn1_CheckedChanged" CssClass="icon-hand-right"/>  
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_REMARK" runat="server" Width="300px"></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="Please Enter Remark" ControlToValidate="PTAD_REMARK" ClientValidationFunction="RequirePersonalDetails" ValidateEmptyText="true"></asp:CustomValidator>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID1" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="ASED_AGDDID" Visible="false" runat="server" Text='<%#Eval("ASED_AGDDID")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID2" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="ASED_ID" Visible="false" runat="server" Text='<%#Eval("ASED_ID")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>
               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID3" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="ASE_ID" Visible="false" runat="server" Text='<%#Eval("ASE_ID")%>'></asp:Label>
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

     <div class="row-fluid" id="ASE_ID1" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Patient Doctor Assessment & Customised</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>                      
   <div class="portlet-body">
   <div class="table table-striped table-bordered table-hover">
    <asp:Panel ID="Panel3"  ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
      <asp:GridView ID="GridView3" AutoGenerateColumns="false" runat="server" Width="100%" 
          DataKeyNames="AGDD_DOBSID" PageSize="25" EmptyDataText="No, Record Added">
           <Columns>
               <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="900px" >
                    <ItemTemplate>
                        <asp:Label ID="DOBS_DESC" runat="server" Text='<%#Eval("DOBS_DESC")%>' oncopy="return allow()"
                        onpaste="return allow()"
                        oncut="return allow()"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left"/>
                </asp:TemplateField>
               
               <asp:TemplateField HeaderText="Yes" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                    <ItemTemplate>
                          <asp:RadioButton ID="rdbtn3" Width="50px" runat="server" AutoPostBack="false" TextAlign="Left" 
                           GroupName="View" CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn2" runat="server" Width="50px" AutoPostBack="false" TextAlign="Left" 
                           GroupName="View" Checked='<%# Eval("PTAD_VALUE").ToString()=="1" ? true : false %>' Enabled='<%#(String.IsNullOrEmpty(Eval("PTAD_VALUE").ToString()) ? false: true) %>' CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Sometimes" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn1" runat="server" AutoPostBack="false" TextAlign="Left" 
                  GroupName="View" Checked='<%# Eval("PTAD_SOMETHING").ToString()=="1" ? true : false %>' 
                            Enabled='<%#(String.IsNullOrEmpty(Eval("PTAD_SOMETHING").ToString()) ? false: true) %>' CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_REMARK" runat="server" Width="300px" Text='<%#Eval("PTAD_REMARK")%>'></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="Please Enter Remark" ControlToValidate="PTAD_REMARK" ClientValidationFunction="RequirePersonalDetails" ValidateEmptyText="true"></asp:CustomValidator>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID1" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="ASED_AGDDID" Visible="false" runat="server" Text='<%#Eval("ASED_AGDDID")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID2" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="ASED_ID" Visible="false" runat="server" Text='<%#Eval("ASED_ID")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>
               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID3" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="ASE_ID" Visible="false" runat="server" Text='<%#Eval("ASE_ID")%>'></asp:Label>
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

    <%--Testing for the age group start --%> 

  <div class="row-fluid" id="Div1" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Patient Assessment & Customised</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>                      
   <div class="portlet-body">
   <div class="table table-striped table-bordered table-hover">
    <asp:Panel ID="Panel4"  ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
      <asp:GridView ID="GridView4" AutoGenerateColumns="false" runat="server" Width="100%" 
          PageSize="25" EmptyDataText="No, Record Added">
           <Columns>
               <asp:TemplateField HeaderText="Observation" HeaderStyle-Width="900px" >
                    <ItemTemplate>
                        <asp:Label ID="CURRICULUM_DESC" runat="server" Text='<%#Eval("CURRICULUM_DESC")%>' oncopy="return allow()"
                        onpaste="return allow()"
                        oncut="return allow()"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left"/>
                </asp:TemplateField>
               
               <asp:TemplateField HeaderText="Yes" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn3" runat="server" Width="50px" AutoPostBack="false" TextAlign="Left" 
                           GroupName="View" OnCheckedChanged="rdbtn3_CheckedChanged" CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="No" HeaderStyle-HorizontalAlign="Left" HeaderStyle-Width="100px">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn2" runat="server" Width="50px" AutoPostBack="false" TextAlign="Left" 
                           GroupName="View" OnCheckedChanged="rdbtn2_CheckedChanged" CssClass="icon-hand-right"/>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Sometimes" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:RadioButton ID="rdbtn1" runat="server" AutoPostBack="false" TextAlign="Left" 
                  GroupName="View" Checked='<%# Eval("PTACD_SOMETHING").ToString()=="1" ? true : false %>' 
                            Enabled='<%#(String.IsNullOrEmpty(Eval("PTACD_SOMETHING").ToString()) ? false: true) %>' OnCheckedChanged="rdbtn1_CheckedChanged" CssClass="icon-hand-right"/>  
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_REMARK" runat="server" Width="300px"></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="Please Enter Remark" ControlToValidate="PTAD_REMARK" ClientValidationFunction="RequirePersonalDetails" ValidateEmptyText="true"></asp:CustomValidator>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>
               <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="CURRICULUM ID" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="CURRICULUM_ID" Visible="false" runat="server" Text='<%#Eval("CURRICULUM_ID")%>'></asp:Label>
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


    <div class="row-fluid" id="Div2" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Customised IEP For Curriculum Observation</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>                      
   <div class="portlet-body">
   <div class="table table-striped table-bordered table-hover">
    <asp:Panel ID="Panel5"  ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
      <asp:GridView ID="GridView5" AutoGenerateColumns="false" runat="server" Width="100%" 
           PageSize="25" EmptyDataText="No, Record Added" onrowcommand="GridView5_RowCommand">
           <Columns>
                <asp:TemplateField HeaderText="Disorder Name" HeaderStyle-Width="250px" >
                    <ItemTemplate>
                        <asp:Label ID="DIS_NAME" runat="server" Text='<%#Eval("DIS_NAME")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>
               <asp:TemplateField HeaderText="PTAC_ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="PTAC_ID" runat="server" Text='<%#Eval("PTAC_ID")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

               <asp:ButtonField  HeaderStyle-HorizontalAlign="Center" HeaderText="View IEP" 
                ButtonType="Image" ItemStyle-HorizontalAlign="Center" 
                ImageUrl="App_Resources/images/visit_station.gif" CommandName="PATIENT" >
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:ButtonField>
           </Columns>
         </asp:GridView>
        </asp:Panel>
        </div>
       </div>
      </div>
    </div>
  </div>

<%--Testing for the age group End --%> 

        <div class="form-horizontal">
              <div class="form-actions">
                   <asp:Button ID="btnSave" CssClass="btn blue" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="javascript:return ValidateCheckBox();"/> <%--OnClientClick="return Validate_Checkbox()"/>--%>  <%--OnClientClick="return F();"--%>
                <%--Testing for the age group Save Start --%> 
                  <asp:Button ID="btnSaveCurriculum" CssClass="btn green" runat="server" Text="Save" OnClick="btnSaveCurriculum_Click" OnClientClick="javascript:return ValidateCheckBox();"/>
                <%--Testing for the age group Save End --%> 
                  
                  </div>
            </div>
    <asp:HiddenField Value="0" ID="HiddenField4" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE11" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE1" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="ID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField2" runat="server" />
<div class="row-fluid" id="doctor_id" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Customised IEP</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>                      
   <div class="portlet-body">
   <div class="table table-striped table-bordered table-hover">
    <asp:Panel ID="Panel2"  ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
      <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" Width="100%" 
           PageSize="25" EmptyDataText="No, Record Added" onrowcommand="GridView2_RowCommand">
           <Columns>
                <asp:TemplateField HeaderText="Disorder Name" HeaderStyle-Width="250px" >
                    <ItemTemplate>
                        <asp:Label ID="Disname" runat="server" Text='<%#Eval("Disname")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>
                
               <asp:TemplateField HeaderText="PTA_ID" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="PTA_ID" runat="server" Text='<%#Eval("PTA_ID")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>

               <asp:ButtonField  HeaderStyle-HorizontalAlign="Center" HeaderText="View IEP" 
                ButtonType="Image" ItemStyle-HorizontalAlign="Center" 
                ImageUrl="App_Resources/images/visit_station.gif" CommandName="PATIENT" >
                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                <ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:ButtonField>
           </Columns>
         </asp:GridView>
        </asp:Panel>
        </div>
       </div>
      </div>
    </div>
  </div>
   
<asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField5" runat="server" />
<asp:HiddenField Value="0" ID="TXTVEHID" runat="server" />
<script type="text/javascript" src="App_Resources/javascript/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="App_Resources/javascript/thickbox-compressed.js"></script>
<link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" />

    <style>
            .shower {
                display: block !important;
            }
        </style>
<script type="text/javascript" language="javascript">

    window.onload = function () {
        var video_url = document.getElementById("<%= HiddenField2.ClientID %>").value;
        var user_type = document.getElementById("<%= HiddenField5.ClientID %>").value;
        if (video_url == null || video_url == 0) {
            document.getElementById('pressed_btn').style.display = 'none';
        }
        //this.console.log(HiddenField5.Value);
        
        else if (user_type == "Patient")
        {
            document.getElementById('pressed_btn').style.display = 'none';
        }
    }
    
    function allow() {
            alert("Copy paste and cut not allow");
            return false;
        }
   
    function ShowModalPopup() {
        var digiclock = document.getElementById("<%= HiddenField2.ClientID %>").value;
        ///console.log();
        //$get("video").src = "https://www.youtube.com/embed/d4kPMZuqtuA";
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
           var digiclock = document.getElementById("<%= HiddenField2.ClientID %>").value;
           console.log(digiclock);
           //$get("video").src = "https://www.youtube.com/embed/d4kPMZuqtuA";
           $get("video").src = digiclock;
           return false;
    }
    document.querySelector('#pressed_btn').addEventListener('click', function (event) {
        
        event.preventDefault();
        var digiclock = document.getElementById("<%= HiddenField2.ClientID %>").value;
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
        <asp:HiddenField ID="AGDD_DOBSID" runat="server" />
    <asp:HiddenField ID="PTP_ID" runat="server" />
</asp:Content>

