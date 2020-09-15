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
            <li>
				<asp:LinkButton id="LinkButton2" class="btn blue" runat="server" style="text-align:left" Text="Intervention Tools" onClientClick="window.open('https://nerdnerdy.com/');"></asp:LinkButton>
                <asp:LinkButton id="LinkButton3" class="btn green" runat="server" style="text-align:left" Text="Buy license" onClientClick="window.open('https://nerdnerdy.com/');"></asp:LinkButton>
			</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="scrtoolkit" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom:8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Go To Patient Detail</a>
                <%--<asp:LinkButton class="btn red" Text="Play video" OnClick="btnVideo_Click" ID="LinkButton1" runat="server" />--%>
                <%--<asp:Literal ID="ltPlayer" runat="server" ></asp:Literal>--%>
                <asp:LinkButton ID="btnShow" class="btn red" runat="server" Text="Assessment Video" OnClientClick="return ShowModalPopup()" />  
                    <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>  
                    <cc1:ModalPopupExtender ID="ModalPopupExtender1" BehaviorID="mpe" runat="server"  
                        PopupControlID="pnlPopup" TargetControlID="lnkDummy" BackgroundCssClass="modalBackground" CancelControlID = "btnClose">  
                    </cc1:ModalPopupExtender>  
                    <asp:Panel ID="pnlPopup" runat="server" CssClass="modalPopup" Style="display: none">  
                        <%--<div class="header">  
                            Youtube Video  
                        </div>--%>  
                        <div class="body">  
                            <iframe id = "video" width="420" height="315" frameborder="0" allowfullscreen></iframe>  
                            <br />  
                            <br />  
                            <asp:Button ID="btnClose" runat="server" Text="Close" />  
                        </div>  
                    </asp:Panel>  
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
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
                                <%--<asp:DropDownList ID="DDLPATIENT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLPATIENT_SelectedIndexChanged">
                                    <asp:ListItem Value="0">-- Select Patient Name --</asp:ListItem>
                                </asp:DropDownList>
                              <asp:RequiredFieldValidator ControlToValidate="DDLPATIENT" SetFocusOnError="true" ID="RV2" runat="server" />--%>
                           </div>
                        </div>
                     </div>
                      <%--<div class="span6" style="margin-bottom:-15px;">
                        <div class="control-group">
                            <label class="control-label">Name<span class="required">*</span></label>
                            <div class="controls">
                                <asp:TextBox ID="PTP_CUST_TXT" runat="server" CssClass="span12 m-wrap" />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="PTP_CUST_TXT" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                     </div>
                 </div>
                <div class="row-fluid">--%>
                  <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Age Group<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_AGE" runat="server" CssClass="span12 m-wrap" />
                            <%--<asp:DropDownList ID="DDLAGE" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLAGE_SelectedIndexChanged">
                                    <asp:ListItem Value="0">-- Select Age Group --</asp:ListItem>
                                </asp:DropDownList>
                              <asp:RequiredFieldValidator ControlToValidate="DDLAGE" SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server" />--%>
                              <%--<asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLPATIENT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>--%>

                            <%--<asp:TextBox ID="PTP_AGE_TXT" runat="server" CssClass="span12 m-wrap" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="PTP_AGE_TXT" SetFocusOnError="true" runat="server" />--%>
                        </div>
                    </div>
                 </div>
               </div>
              <div class="row-fluid">
                <div class="span6" style="margin-bottom:-15px;">
                    <div class="control-group">
                      <label class="control-label">Gender<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="PTP_GENDER_TXT" runat="server" CssClass="span12 m-wrap" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="PTP_GENDER_TXT" SetFocusOnError="true" runat="server" />
                            </div>
                        </div>
                        </div>
                   <%-- </div>
                 <div class="row-fluid">--%>
                   <div class="span6" style="margin-bottom:-15px;">
                      <div class="control-group">
                        <label class="control-label">Mobile Number<span class="required">*</span></label>
                         <div class="controls">
                            <asp:TextBox ID="PTP_MOB_TXT" runat="server" CssClass="span12 m-wrap" />
                            <cc1:FilteredTextBoxExtender ID="FVE11" TargetControlID="PTP_MOB_TXT" FilterType="Numbers" runat="server" Enabled="True" FilterMode="ValidChars" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="PTP_MOB_TXT" SetFocusOnError="true" runat="server" />
                            <%--<asp:CustomValidator ID="CustomValidator3" ControlToValidate="PTP_MOB_TXT" runat="server" ErrorMessage="Already Exist" Display="Dynamic" onservervalidate="existence_ServerValidate"></asp:CustomValidator>--%>
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
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
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
               <%--<asp:TemplateField HeaderText="Value" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_VALUE" runat="server" Width="70px"></asp:TextBox>--%>
                        <%--<asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="PTAD_VALUE" ValidationExpression="^[1-5]\\d*(\\.\\d+)?$" ErrorMessage="Not Greater than 5 or Less than 1" />--%>
                        <%--<cc1:FilteredTextBoxExtender ID="FTB1" FilterType="Numbers" TargetControlID="PTAD_VALUE" runat="server" />--%>
                    <%--</ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>--%>
               
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

               <%--<asp:TemplateField HeaderText="Scale" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_SCALE" runat="server" Width="100px"></asp:TextBox>
                        <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="PTAD_SCALE" ValidationExpression="^([0-5]*)$" ErrorMessage="Not Greater than 5 or Less than 1" />
                        <cc1:FilteredTextBoxExtender ID="FTB1" FilterType="Numbers" TargetControlID="PTAD_SCALE" runat="server" />
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>--%>

               <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_REMARK" runat="server" Width="300px"></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="Please Enter Remark" ControlToValidate="PTAD_REMARK" ClientValidationFunction="RequirePersonalDetails" ValidateEmptyText="true"></asp:CustomValidator>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PTAD_REMARK" ForeColor="Red" ErrorMessage="Textbox Field can't be blanked"></asp:RequiredFieldValidator>--%>
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
                        <%--<asp:CheckBox ID="chkSelect" runat="server" 
                            Checked='<%# Eval("PTAD_VALUE").ToString()=="1" ? true : false %>' Enabled='<%#(String.IsNullOrEmpty(Eval("PTAD_VALUE").ToString()) ? false: true) %>'/>--%> <%--onclick="javascript:UnCheckOtherCheckBox(this, 'chkSelect');"/>--%>
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

               <%--<asp:TemplateField HeaderText="Scale" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_SCALE" runat="server" Width="300px" Text='<%#Eval("PTAD_SCALE")%>'></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="Please Enter Scale" ControlToValidate="PTAD_SCALE" ClientValidationFunction="RequirePersonalDetails" ValidateEmptyText="true"></asp:CustomValidator>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                </asp:TemplateField>--%>

               <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                    <ItemTemplate>
                        <asp:TextBox ID="PTAD_REMARK" runat="server" Width="300px" Text='<%#Eval("PTAD_REMARK")%>'></asp:TextBox>
                        <asp:CustomValidator runat="server" ErrorMessage="Please Enter Remark" ControlToValidate="PTAD_REMARK" ClientValidationFunction="RequirePersonalDetails" ValidateEmptyText="true"></asp:CustomValidator>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="PTAD_REMARK" ForeColor="Red" ErrorMessage="Textbox Field can't be blanked"></asp:RequiredFieldValidator>--%>
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

        <div class="form-horizontal">
              <div class="form-actions">
                   <asp:Button ID="btnSave" CssClass="btn blue" runat="server" Text="Save" OnClick="btnSave_Click" OnClientClick="javascript:return ValidateCheckBox();"/> <%--OnClientClick="return Validate_Checkbox()"/>--%>  <%--OnClientClick="return F();"--%>
                  <%--<input alt="#TB_inline?height=500&width=700&inlineId=hiddenModalContent&modal=true" class="thickbox" type="button" value="Patient PDF Report" />--%>
                  <%--<asp:Button ID="btnPdf" Text="Print Patient PDF" onclientclick="return printdiv('DivIdToPrint', 'patient')" OnClick="btnPdf_Click" runat="server" skinid="n" Visible="false"/>--%>  
                  <asp:Button class="btn green" Text="PDF Report" OnClick="btnPdf_Click" ID="popupiep1" runat="server"/>
                  </div>
            </div>
    <asp:HiddenField Value="0" ID="HiddenField4" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE11" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE1" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="ID" runat="server" />
    <asp:HiddenField Value="0" ID="Videolink" runat="server" />
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
                <%--<asp:TemplateField HeaderText="Scored Rank" HeaderStyle-Width="250px" >
                    <ItemTemplate>
                        <asp:Label ID="Total_Percentage" runat="server" Text='<%#Eval("Total_Percentage")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>--%>
                <%--<asp:TemplateField HeaderText="Scale(1-5)" HeaderStyle-Width="250px" >
                    <ItemTemplate>
                        <asp:Label ID="Total_scal" runat="server" Text='<%#Eval("Total_scal")%>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="left" />
                </asp:TemplateField>--%>

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
     <div id="hiddenModalContent" style="display: none"> 
        <%--<input type="submit" value="Close" onclick="tb_remove()" /> --%>
         <%--<asp:Button ID="btnPdfReport" Text="Print Patient PDF Report" OnClick="btnPdfReport_Click" CssClass="pull-right" runat="server" Visible="true"/>--%>
                    <div id="DivIdToPrint" style="font: 10px Arial;">
                        <h1 style="font: 22px Arial; text-align:center; font-weight:bolder; text-decoration:underline;">PATIENT <b><span id="NAME" runat="server" /></b> REPORT</h1>
                        <table border="0" width="650px" style="font: 12px Arial;line-height:17px">
                            <%--<tr>
                                <td width="60%"><B>Card No: <span id="JOBCARDNO" class="rptfield" runat="server" /></B></td>
                                <td width="50%" align="right"><B>Date: <span id="CHECKDATE" class="rptfield" runat="server" /></B></td>
                            </tr>--%>
                            <tr>
                                <td runat="server" visible="false"><U><B>1.PATIENT NAME:</B></U> <span id="PATIENTNAME" class="rptfield" runat="server"/></td>
                                <td><U><B>1.DATE OF BIRTH:</B></U><span id="PATIENTDATE" class="rptfield" runat="server" /></td>
                                <td colspan="2"><U><B>2.GENDER:</B></U> <span id="PATIENTGENDER" class="rptfield" runat="server" /></td>
                                
                            </tr>
                            <tr>
                                <%--<td><U><B>3.DATE OF BIRTH:</B></U> <span id="PATIENTDATE" class="rptfield" runat="server" /></td>--%>
                                <%--<td colspan="2"><U><B>4.AGE:</B></U> <span id="PATIENTAGE" class="rptfield" runat="server" /></td>--%>
                            </tr>
                            <tr>
                               <%-- <td><U><B>5.DATE OF EVALUATION:</B></U> <span id="PATIENTEVALUATION" class="rptfield" runat="server" /></td>
                                <td colspan="2"><U><B>6.SCHOOL:</B></U> <span id="PATIENTSCHOOL" class="rptfield" runat="server" visible="false"/></td>--%>
                            </tr>
                            <%--<tr><td style="line-height:50px"></td></tr>--%>
                            <tr>
                                <td><U><B>REASON FOR REFERRAL:</B></U></td>
                            </tr>
                            <tr>
                                <td><b><span id="REASON" class="rptfield" runat="server"/></b> is a 3 year 1 months old young boy who was brought for evaluation by his parents, who provided all relevant information. 
                                    Parents were concerned about his Speech Delay and Vihaan not responding to his name or instructions.</td>
                            </tr>
                            <tr>
                                <td><U><B>EVALUATION METHOD:</B></U></td>
                            </tr>
                            <tr>
                                <td>1.Clinical Observation <span id="Span1" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">2.Parent's Interview <span id="Span2" class="rptfield" runat="server" /></td>
                            </tr>
                                <tr>
                                    <td>3.Development Screening Test <span id="Span3" runat="server" /></td>
                               </tr>
                            <tr>
                                <td  colspan="2">4.Vineland Social Maturity Scale <span id="Span4" runat="server" /></td>
                             </tr>
                            <tr>
                                <td>5.Childhood Autism Rating Scale-2 <span id="Span5" runat="server" /></td>
                            </tr>

                            <tr>
                                <td><U><B>Medical History:</B></U></td>
                            </tr>
                            <tr>
                                <td>No medical complications were reported by the Parents.<span id="Span6" runat="server" /></td> 
                            </tr>

                            <tr>
                                <td><U><B>Development History:</B></U></td> 
                            </tr>
                            <tr>
                                <td>Mother reported that <b><span id="Span7" runat="server" /></b> Physical and motor milestones were age appropriate. 
                                    He started speaking 4-5 words (mama, papa etc) around one and a half years of age but around 2 years he stopped saying the words that he used to say. 
                                    Now rarely he may say one or two words but not always.
                                    According to parents Vihaan has extraordinary Balancing skills and eye hand coordination. He does not fall even if he walks on the edge of the furniture.
                                    He can walk with eyes closed and would not bang self into the object.
                                    <b><span id="Span11" runat="server" /></b> likes to spin objects and self. He would not get dizzy even after spinning self for long but would start looking from the corner of his eyes after spinning.  
                                    According to parents <b><span id="Span15" runat="server" /></b> likes to have his own diet, which generally consist of semi solid food only. He does not try new food. 
                                    If he tries solid food, he would cough it out as if his throat is choking. 
                                    <b><span id="Span16" runat="server" /></b> hearing test and Neurological assessment have been done. 
                                    He has no issues with hearing or any other neurological impairment. </td>
                            </tr>

                             <tr>
                                <td><U><B>Family History</B></U></td>
                            </tr>
                            <tr>
                                <td><b><span id="Span8" runat="server" /></b> is the only child living in nuclear family.No history of similar complaints in the family.</td>
                            </tr>

                            <tr>
                                <td><U><B>On Observation:</B></U> </td>
                            </tr>
                            <tr>
                                <td><b><span id="Span9" runat="server" /></b> does not have age appropriate Eye Contact. <b><span id="Span14" runat="server" /></b> kept constantly moving in the room and was in his own world. 
                                    He didn’t respond to his name or simple commands. Pretend play or imaginative play is not developed.
                                    He was happy and got excited when he saw bubble tubes with lights. <b><span id="Span19" runat="server" /></b> does not have speech at this stage but has lot of vocalization. 
                                    He indicates his needs by holding hands. Has repetitive behaviour, he peels off the stickers from the objects. If interrupted then gets aggressive. 
                                    Fine motor skills are age appropriate. Inappropriate body use like flapping of hands or wiggling of fingers were not noticed. 
                                    He enjoys fast movements on swings and enjoyed jumping on trampoline and ball. He looked from the corner of his eyes after he got off the swing. 
                                    <b><span id="Span17" runat="server" /></b> showed tactile issues as he was not able to touch fibres, sensory balls, and sensory sand. He showed interest in playing with different toys. 
                                    He showed discomfort when touched by other therapist. No discomfort was noticed in <b><span id="Span20" runat="server" /></b> while moving from one room to the other. 
                                    His abstract skills like cause and effect are not age appropriate.</td>
                            </tr>

                            <tr>
                                <td><U><B>Physical Behaviour:</B></U></td>
                            </tr>
                            <tr>
                                <td><b><span id="Span18" runat="server" /></b> enjoys movement. He can’t seem to sit still, craves fast spinning movement. Gross motor and fine motor skills are age appropriate.<b><span id="Span10" runat="server" /></b></td>
                            </tr>
                           
                            <tr>
                                <td><U><B>Oral Motor Development/Eating Behaviour:</B></U></td>
                            </tr>
                            <tr>
                                <td>He is hypersensitive to oral input and only eats semi solid food. When <b><span id="Span12" runat="server" /></b> is introduced solid food item, he would cough it out as his throat is choked. 
                                    He never shows any curiosity to try new food item. According to his parents he has preference for limited food items. 
                                    He can suck but can’t blow.</td>
                            </tr>

                            <tr>
                                <td><U><B>Gross Motor and Fine Motor development:</B></U></td>
                            </tr>
                            <tr>
                                <td><b><span id="Span13" runat="server" /></b> can walk, run and jumps well, he can walk upstairs and downstairs, pincer grasp is age appropriate.</td>
                            </tr>

                            <tr>
                                <td><U><B>Socail/Emotional development:</B></U></td>
                            </tr>
                            <tr>
                                <td>He does not socially interact with people, he does not demonstrate trouble when separated from his mother, he used to scream loudly when aggressive or excited. 
                                    Imaginative/ pretend play not developed.</td>
                            </tr>

                            <tr>
                                <td><U><B>Activities of Daily Living(ADL):</B></U></td>
                            </tr>
                             <tr>
                                <td><U><B>Self-care:</B></U></td>
                            </tr>
                            <tr>
                                <td>1.Eating: <b><span id="Span21" class="rptfield" runat="server" /></b> can feed himself with spoon, he is able to drink water from glass on his own.</td>
                           </tr>
                            <tr>
                                <td>2.Dressing: He can dress and undress himself with assistance.</td>
                           </tr>
                           <tr>
                                <td>3.Bladder/Bowel: He indicates bladder/ bowel movements by maintaining a peculiar posture.</td>
                            </tr>

                            <tr>
                                <td><U><B>The Childhood Autism Rating Scale</B></U></td>
                            </tr>
                            <tr>
                                <td>The childhood Autism Rating Scale, Second Edition (CARS 2) includes three forms. 
                                    The three forms are the two rating booklets – Childhood Autism Rating Scale, Second Edition –Standard Version (CARS2- ST; formerly titled CARS) and the Childhood Autism Rating Scale, Second Edition-  High Functioning Version (CARS2-HF)- and the questionnaire for parents or caregivers (CARS2- QPC). 
                                    The CARS2- ST and CARS2-HF are not intended as screeners for use in general population. Their primarily values lies in their providing brief, quantitatively specific and reliable yet comprehensively based summary information that can be used to help develop diagnostic hypotheses among referred individuals of all ages and functional levels.
                                    CARS2-ST and CARS2-HF ratings are based not only on the frequency of behaviours, but also on their intensity, peculiarity and duration. This allows for great flexibility in integrating comprehensive information about a case, and at the same time yields consistent quantitative results. Professionals can also use CARS2 results to help in giving diagnostic feedback to parents, characterizing functional profiles and guiding intervention planning. 
                                    The CARS-ST and CARS-HF each include 15 items that ask respondents to rate an individual on a scale from 1to 4 in key areas related to autism diagnosis. The ratings were done by the examiner based on Vihaan’s parent’s interview and her observations. 
                                    <b><span id="Span22" class="rptfield" runat="server" /></b> obtained a rating of 33 on CARS2-ST, which places him in Mild to Moderate Symptoms of Autism Spectrum Disorder at this time.
                                </td>
                           </tr>

                            <tr>
                              <td><U><B>Category Rating:</B></U></td>
                            </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:table width="100%" border="1" cellpadding="0" runat="server" id="tbl" cellspacing="0" class="printtable">
                                        <%--<tr><th>Observation:<span id="Q11OBSERVATION" class="tblfield1" runat="server"/></th><th>Remarks:<span id="Q11REMARKS" class="tblfield1" runat="server"/></th><th>Percentage:<span id="Q11PERCENTAGE" class="tblfield1" runat="server"/></th><th>Scale:<span id="Q11SCALE" class="tblfield1" runat="server"/></th></tr>--%>
                                        <%--<tr><td><span id="Q11OBSERVATION" class="tblfield1" runat="server"/></td><td><span id="Q11REMARKS" class="tblfield1" runat="server"/></td><td><span id="Q11PERCENTAGE" class="tblfield1" runat="server"/></td><td><span id="Q11SCALE" class="tblfield1" runat="server"/></td></tr>--%>
                                        <%--<tr><td>2</td><td><span id="Q21OBSERVATION" class="tblfield2" runat="server"/></td><td><span id="Q21REMARKS" class="tblfield2" runat="server"/></td><td><span id="Q21PERCENTAGE" class="tblfield2" runat="server"/></td><td><span id="Q21SCALE" class="tblfield2" runat="server"/></td></tr>
                                        <tr><td>3</td><td><span id="Q31OBSERVATION" class="tblfield3" runat="server"/></td><td><span id="Q31REMARKS" class="tblfield3" runat="server"/></td><td><span id="Q31PERCENTAGE" class="tblfield3" runat="server"/></td><td><span id="Q31SCALE" class="tblfield3" runat="server"/></td></tr>
                                        <tr><td>4</td><td><span id="Q41OBSERVATION" class="tblfield4" runat="server"/></td><td><span id="Q41REMARKS" class="tblfield4" runat="server"/></td><td><span id="Q41PERCENTAGE" class="tblfield4" runat="server"/></td><td><span id="Q41SCALE" class="tblfield4" runat="server"/></td></tr>
                                        <tr><td>5</td><td><span id="Q51OBSERVATION" class="tblfield5" runat="server"/></td><td><span id="Q51REMARKS" class="tblfield5" runat="server"/></td><td><span id="Q51PERCENTAGE" class="tblfield5" runat="server"/></td><td><span id="Q51SCALE" class="tblfield5" runat="server"/></td></tr>
                                        <tr><td>6</td><td><span id="Q61OBSERVATION" class="tblfield6" runat="server"/></td><td><span id="Q61REMARKS" class="tblfield6" runat="server"/></td><td><span id="Q61PERCENTAGE" class="tblfield6" runat="server"/></td><td><span id="Q61SCALE" class="tblfield6" runat="server"/></td></tr>
                                        <tr><td>7</td><td><span id="Q71OBSERVATION" class="tblfield7" runat="server"/></td><td><span id="Q71REMARKS" class="tblfield7" runat="server"/></td><td><span id="Q71PERCENTAGE" class="tblfield7" runat="server"/></td><td><span id="Q71SCALE" class="tblfield7" runat="server"/></td></tr>--%>
                                        </asp:table>
                                    </td>
                                </tr>

                             <tr>
                                <td><U><B>Developmental Screening Test:</B></U></td>
                            </tr>
                            <tr>
                                <td>The Developmental Screening Test is designed for the purpose of measuring mental development of children from birth to 15 years of age.
                                    The test starts from the ‘Basal Age’ where all characteristics at a particular age are passed and gradually moving through upper age levels. 
                                    It assesses behavioural characteristics of respective age levels. 
                                    At each age level, items are drawn from behavioural areas like motor development, speech, language and personal social development.
                                </td>
                           </tr>

                            <tr>
                                <td><U><B>Developmental Age: 18 Months</B></U></td>
                            </tr>

                             <tr>
                                <td><U><B>Developmental Quotient: 50</B></U></td>
                            </tr>
                            <tr>
                                <td>As per developmental screening test <b><span id="Span23" class="rptfield" runat="server" /></b> General Development score is 50 and falls in Delayed range.</td>
                           </tr>

                             <tr>
                                <td><U><B>Vineland Social Maturity Scale:</B></U></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0" class="printtable">
                                    <tr><th>S.No.</th><th>Social Areas </th><th>Month</th><th><span id="SOT" runat="server"/>SQ</th></tr>
                                    <tr><td>1</td><td>Self-Help General</td><td>32months</td><td>86.4</td></tr>
                                    <tr><td>2</td><td>Self-Help Eating</td><td>32months</td><td>86.4</td></tr>
                                    <tr><td>3</td><td>Self-Help Dressing</td><td>32months</td><td>86.4</td></tr>
                                    <tr><td>4</td><td>Occupation</td><td>32months</td><td>86.4</td></tr>
                                    <tr><td>5</td><td>Communication</td><td>14.4 months</td><td>38.9</td></tr>
                                    <tr><td>6</td><td>Socialization</td><td>21.6months</td><td>58.37</td></tr>
                                    </table>
                                    </td>
                                </tr>
                             <tr>
                                <td>
                                Vineland Maturity Scale is a useful instrument in measuring social maturity of children and young adults. 
                                This test not only measures the Social Age and Social Quotient.It also indicate the social deficits and social assets in a growing child.
                                The above results highlight that <b><span id="Span24" class="rptfield" runat="server" /></b> has significant delays in Communication and Social development. 
                            </td>
                           </tr>

                             <tr>
                               <td align="center"><b>Sensory Evaluation</b></td>
                             </tr>
                             <tr>
                                <td><U><B>Tactile: </B></U></td>
                            </tr>
                            <tr>
                                <td>• Can tolerate hair cut well. <span id="Span25" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">• Avoids touching certain textures of materials. <span id="Span28" class="rptfield" runat="server" /></td>
                            </tr>
                                <tr>
                                    <td>• Avoids messy play with sand, mud, glue etc. <span id="Span31" runat="server" /></td>
                               </tr>
                            <tr>
                                <td  colspan="2">• Becomes aggressive with light or unexpected touch. <span id="Span34" runat="server" /></td>
                             </tr>
                            

                            <tr>
                                <td><U><B>Auditory: </B></U></td>
                            </tr>
                            <tr>
                                <td>• He is not bothered by sounds made by toilet flushing, backward noises, vacuum or blow dryer etc.
                                    Earlier he used to cover his ears with noise of running machines. But now he is fine with it. <span id="Span37" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">• Does not enjoy very loud noise or continuous talking by siblings. <span id="Span38" class="rptfield" runat="server" /></td>
                            </tr>
                                <tr>
                                    <td>• Enjoys listening to music. <span id="Span39" runat="server" /></td>
                               </tr>
                            <tr>
                                <td  colspan="2">• Distracted by sounds not normally noticed by others. <span id="Span40" runat="server" /></td>
                             </tr>
                            
                             <tr>
                                <td><U><B>Oral input: </B></U></td>
                            </tr>
                            <tr>
                                <td>• He chews semi solid food. He does not eat solid food items. <span id="Span41" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">• Has difficulty in blowing. <span id="Span42" class="rptfield" runat="server" /></td>
                            </tr>

                             <tr>
                                <td><U><B>Vestibular: </B></U></td>
                            </tr>
                            <tr>
                                <td>• Enjoys swings, slides, merry-go-round. <span id="Span43" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">• Does not get dizzy easily. <span id="Span44" class="rptfield" runat="server" /></td>
                            </tr>
                                <tr>
                                    <td>• Enjoys being tipped upside down Enjoys moving/running around in the house. <span id="Span45" runat="server" /></td>
                               </tr>

                            <tr>
                                <td><U><B>Overall it seems <b><span id="Span46" class="rptfield" runat="server" /></B> has Sensory Integration issues. He is Hypersensitive to Touch and Oral Input and is Hyposensitive to Movement. </B></U></td>
                            </tr>
                            
                            <tr>
                                <td><U><B>CLINICAL FINDINGS AND DIAGNOSTIC IMPRESSION </B></U></td>
                            </tr>
                            <tr>
                                <td>• Features of Autism Spectrum Disorder with developmental delays especially are prominent at this time. <span id="Span47" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">• Sensory Integration issues. <span id="Span48" class="rptfield" runat="server" /></td>
                            </tr>

                             <tr>
                                <td><U><B>RECOMMENDATIONS</B></U></td>
                            </tr>
                            <tr>
                                <td>1. TEACCH/ABA therapy is highly recommended. <span id="Span49" class="rptfield" runat="server" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">2. Speech therapy with Oral Motor is recommended. <span id="Span50" class="rptfield" runat="server" /></td>
                            </tr>
                                <tr>
                                    <td>3. Regular Occupational therapy with emphasis on Sensory Processing is highly recommended. <span id="Span51" runat="server" /></td>
                               </tr>
                            <tr>
                                <td  colspan="2">4.	Play school with intervention therapies is recommended. <span id="Span52" runat="server" /></td>
                             </tr>
                            <tr>
                                <td>5. Use of digital resources like various communication apps, cognitive apps, rhymes etc can be used under adult guidance. <span id="Span53" runat="server" /></td>
                            </tr>

                        <tr><td style="line-height:50px"></td></tr>
                            <tr>
                               <td colspan="2"><U><B>Dr. Mukta Vasal, Ph.D</B></U><span id="Span54" runat="server" /></td>
                            </tr>
                            <tr>
                               <td>Senior Consultant Child& Adolescent Psychologist <span id="Span55" runat="server" /></td>
                             </tr>
                            <tr>
                               <td colspan="2">Educator for Gifted Learner (USA) <span id="Span56" runat="server" /></td>
                            </tr>
                            <tr>
                               <td>TEACCH Autism Certified (USA) <span id="Span57" runat="server" /></td>
                            </tr>
                            <tr>
                               <td colspan="2">SIPT Certified (USA) <span id="Span58" runat="server" /></td>
                            </tr>
                            <%--<tr>
                            <td align="right">Auth. Signatory</td>
                        </tr>--%>
                        <tr><td><span id="CUSTNAME1" class="rptfield" runat="server"/></td></tr>
                    </table>
                  </div> 
                </div>
                <%--<div class="form-actions">
                  <asp:Button ID="Button1" runat="server" Height="30px" Width="100px" Text="Update" CssClass="btn green" OnClick="Updatebtn_Click" ValidationGroup="Save" /> 
             </div>
          </div> --%>
      <div id="hiddenModalContentCertificate" style="display: none"> 
        <input type="submit" value="Close" onclick="tb_remove()" /> 
        <div id="DivIdToPrintCertificate" style="font: 10px Arial;">
            <h1 style="font: 22px Arial; text-align:center; font-weight:bolder; text-decoration:underline;">PATIENT LIST</h1>

            <table border="0" width="650px" style="font: 12px Arial;line-height:17px">
                <%--<tr>
                    <td width="25%"><B>Certificate No: </td><td width="25%"><span id="CNGCNO" class="rptfield" runat="server" /></B></td>
                    <td width="50%" align="right" rowspan="8">
                        <asp:Image Width="150" Height="150" BorderWidth="1" ID="ImgPreview1A" runat="server" />
                        <asp:Image Width="150" Height="150" BorderWidth="1" ID="ImgPreview1B" runat="server" />
                        (Speed Limit checking centre authorized to grant certificate in compliance with permit conditions of stage and contract carriage relating to undergo quarterly Speed Limit Check.)
                    </td>
                </tr>--%>
                <tr><td>Patient Name:</td><td><span id="PATIENTNAME1" class="rptfield" runat="server" /></td></tr>
                <tr><td>GENDER :</td><td><span id="PATIENTGENDER1" class="rptfield" runat="server" /></td></tr>
                <tr><td>DATE OF BIRTH. :</td><td><span id="PATIENTDATE1" class="rptfield" runat="server" /></td></tr>
                <tr><td>AGE :</td><td><span id="PATIENTAGE1" class="rptfield" runat="server" /></td></tr>
                <tr><td>DATE OF EVALUATION :</td><td><span id="PATIENTEVALUATION1" class="rptfield" runat="server" /></td></tr>
                <tr><td>SCHOOL :</td><td><span id="PATIENTSCHOOL1" class="rptfield" runat="server" /></td></tr>
                <tr><td>REASON FOR REFERRAL :</td><td><span id="AMCVALIDUPTO1" class="rptfield" runat="server" /></td></tr>
                <tr><td colspan="3" style="text-align:justify">REASON<span id="SPEEDSTATUS2" runat="server" /></td></tr>
                <tr><td colspan="2"></td><td align="right">Authorized Centre</td></tr>
                <tr><td></td><td><span id="SCNAME1" class="rptfield" runat="server" /></td></tr>
                <tr><td><b>AUTHORIZED SIGNATORY</b></td></tr>
                <%--<tr><td colspan="3">Customers are requested to produce the original documents, reports as required</td></tr>--%>
                <%--<tr><td colspan="3"><b>Undertaking:</b><BR />I am satisfied with the Speed Limit check. I have checked each and every part of Speed Limiting device regarding speed limit. I undertake that I will not tamper with Speed Limit Device and I will check my vehicle for preventive maintenance as per procedure & time schedule given in the manual provided by OEM.<br /><br /></td></tr>--%>
                <%--<tr><td colspan="3">Signature of Customer<br /><br />(VALID FOR THREE MONTHS FROM DATE OF ISSUE)</td></tr>--%>
        </table>
        </div> 
    </div>

     
<asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
<asp:HiddenField Value="0" ID="TXTVEHID" runat="server" />
<script type="text/javascript" src="App_Resources/javascript/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="App_Resources/javascript/thickbox-compressed.js"></script>
<link rel="stylesheet" href="App_Resources/StyleSheet/thickbox.css" type="text/css" media="screen" />

    <%--<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">  
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">  
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>  
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>  
    <link rel="stylesheet" href="https://cdn.datatables.net/1.10.16/css/dataTables.bootstrap4.min.css" />  
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js" type="text/javascript"></script>  
    <script src="https://cdn.datatables.net/1.10.16/js/dataTables.bootstrap4.min.js" type="text/javascript"></script> --%> 


<script type="text/javascript" language="javascript">
    function allow() {
            alert("Copy paste and cut not allow");
            return false;
        }
    function printdiv(divnametoprint, type) {
        debugger;
        //window.print();alert(1);
        var strBreak = (type == 'patient' ? '<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>' : '<br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br><br>')
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

    function ShowModalPopup() {
        var url = $get("<%=HiddenField1.ClientID %>").value;
        //alert(url);
        url = url.split('v=')[1];
        $get("video").src = "http://www.youtube.com/embed/" + url
        $find("mpe").show();
        return false;
    }
    function HideModalPopup() {
        $get("video").src = "";
        $find("mpe").hide();
        return false;
    }  

</script>
        <asp:HiddenField ID="AGDD_DOBSID" runat="server" />
    <asp:HiddenField ID="PTP_ID" runat="server" />
</asp:Content>

