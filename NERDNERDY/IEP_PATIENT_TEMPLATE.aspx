<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="IEP_PATIENT_TEMPLATE.aspx.cs" Inherits="IEP_PATIENT_TEMPLATE" Title="IEP Patient Template Information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">IEP Planning & Progress Review</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i> <a href="Patient_IEP.aspx">IEP Planning & Progress Review</a> <i class="icon-angle-right"></i></li>
            <li>IEP Planning & Progress Review</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <div class="row-fluid" id="Instructions" runat="server">
        <div class="span12">
            <h1 class="page-title-patient-instruction"><b>Instructions & Directions To Use</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <asp:Button ID="btnPro" CssClass="btn yellow" Text="Progress Review" runat="server" OnClick="btnProgress_Click" />
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
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
    <div class="row-fluid" id="IEPGrid" runat="server">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Skill Based IEP Planning & Progress Review </div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Patient Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PATIENT_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Disorder<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="True">
                                            <asp:ListItem Value="0">-- Select Disorder Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="existence" ControlToValidate="DDLDIS" runat="server" ErrorMessage="Already Exist" Display="Dynamic" OnServerValidate="existence_ServerValidate"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLDIS" SetFocusOnError="true" ID="RV2" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                           <ContentTemplate>
                                              <asp:TextBox ID="PTP_DATE_TXT" runat="server" Placeholder="yyyy/MM/dd" CssClass="span12 m-wrap" autocomplete="off"/>
                                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../App_Resources/images/CalendarImg.png" OnClick="SkillImageButtonCalendar_Click"/>
		                                    <asp:Calendar ID="Calendar1" runat="server" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
			                                    Height="200px" ShowGridLines="True" Visible="false" Width="220px" OnSelectionChanged="SkillBased_Calendar_SelectionChanged"></asp:Calendar>
                                           </ContentTemplate>
                                         </asp:UpdatePanel>
                                        <%--<asp:TextBox ID="PTP_DATE_TXT" Placeholder="yyyy/MM/dd" runat="server" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="PTP_DATE_TXT" Format="yyyy/MM/dd" Enabled="true" runat="server"></cc1:CalendarExtender>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLCAT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCAT_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Category Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator2" ControlToValidate="DDLCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLCAT" SetFocusOnError="true" ID="RequiredFieldValidator3" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Sub Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLSUBCAT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLSUBCAT_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Sub Category Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator3" ControlToValidate="DDLSUBCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator><%-- OnServerValidate="existence_ServerValidate">--%>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLSUBCAT" SetFocusOnError="true" ID="RequiredFieldValidator1" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Suggested Activities<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLIEA" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select IEP Skill Activity --</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Resources<span class="required"></span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="DDLPRODUCT" CssClass="span12 m-wrap" runat="server" AutoPostBack="false">
                                                <asp:ListItem Value="0">-- Select Resources --</asp:ListItem>
                                            </asp:DropDownList>
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

    <%--FOR TESTING THE IEP CURRICULUM START--%>
    <div class="row-fluid" id="Div2" runat="server">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box red">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Curriculum Based IEP Planning & Progress Review</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Patient Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_CUR_PATIENT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Curriculum<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_CUR_DISORDER" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                           <ContentTemplate>
                                              <asp:TextBox ID="TXT_CUR_DATE" runat="server" Placeholder="yyyy/MM/dd" CssClass="span12 m-wrap" autocomplete="off"/>
                                          <asp:ImageButton ID="ImageButtonCalendar" runat="server" ImageUrl="../App_Resources/images/CalendarImg.png" OnClick="Curriculum_ImageButtonCalendar_Click"/>
		                                    <asp:Calendar ID="Calendar" runat="server" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
			                                    Height="200px" ShowGridLines="True" Visible="false" Width="220px" OnSelectionChanged="Curriculum_Calendar_SelectionChanged"></asp:Calendar>
                                           </ContentTemplate>
                                         </asp:UpdatePanel>
                                        <%--<asp:TextBox ID="TXT_CUR_DATE" runat="server" Placeholder="yyyy/MM/dd" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:CalendarExtender ID="CalendarExtender3" TargetControlID="TXT_CUR_DATE" Format="yyyy/MM/dd" Enabled="true" runat="server"></cc1:CalendarExtender>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLCUMCAT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCUMCAT_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Category Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator4" ControlToValidate="DDLCUMCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLCUMCAT" SetFocusOnError="true" ID="RequiredFieldValidator4" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Sub Category<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLCUMSUBCAT" CssClass="span12 m-wrap" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DDLCUMSUBCAT_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Sub Category Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:CustomValidator ID="CustomValidator5" ControlToValidate="DDLCUMSUBCAT" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator><%-- OnServerValidate="existence_ServerValidate">--%>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLCUMSUBCAT" SetFocusOnError="true" ID="RequiredFieldValidator5" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Suggested Activities<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLCUMIEA" CssClass="span12 m-wrap" runat="server">
                                            <asp:ListItem Value="0">-- Select IEP Skill Activity --</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Resources<span class="required"></span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="DDLCUMRES" CssClass="span12 m-wrap" runat="server" AutoPostBack="false">
                                                <asp:ListItem Value="0">-- Select Resources --</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                      </div>
                                    </div>
                                </div>
                        <div class="form-actions">
                            <asp:Button ID="btncursave" CssClass="btn red" runat="server" Text="Save" OnClick="btnCurSave_Click" />
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>

<%--FOR TESTING THE IEP CURRICULUM END--%>

    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Customized IEP Planning & Skill Progress</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="IEPDT_ID" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="15" AllowPaging="true" AllowSorting="true" EmptyDataText="No, Record Added" OnPageIndexChanging="IEPDT_ID_PageIndexChanging"
                                  onrowdeleting="IEPDT_ID_RowDeleting" onrowcommand="IEPDT_ID_RowCommand" ondatabound="IEPDT_ID_DataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="ID7" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPAT_ID" runat="server" Text='<%#Eval("IEPAT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDTD_DSCATID" runat="server" Text='<%#Eval("IEPDTD_DSCATID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Category ID1" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_DCATID" runat="server" Text='<%#Eval("DSCAT_DCATID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEPA_ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPA_ID" runat="server" Text='<%#Eval("IEPA_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="NAME" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="DIS_NAME" runat="server" Text='<%#Eval("DIS_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEPA" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDTD_IEPAID" runat="server" Text='<%#Eval("IEPDTD_IEPAID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Category">
                                        <ItemTemplate>
                                            <asp:Label ID="DCAT_NAME" runat="server" Text='<%#Eval("DCAT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sub Category" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="DSCAT_DESC" runat="server" Text='<%#Eval("DSCAT_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Suggested Activities" HeaderStyle-Width="2000px" >
                                        <ItemTemplate>
                                            <asp:Label ID="IEPA_DESC" runat="server" Text='<%#Eval("IEPA_DESC")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                     <asp:TemplateField HeaderText="Resources Link" HeaderStyle-Width="300px" >
                                        <ItemTemplate>
                                            <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("PRODM_IMAGE_LINK")%>' onerror="this.src = '/assets/img/sped pic.jpeg'" height="120px" Width="150px" />
                                            <br />
                                            <asp:HyperLink ID="PRODM_LINK" runat="server" NavigateUrl='<%#Eval("PRODM_LINK")%>' Text='<%#Eval("PRODM_LINK")%>'></asp:HyperLink>
                                            <br />
                                            <asp:Label ID="PRODM_NAME" runat="server" Text='<%#Eval("PRODM_NAME")%>'></asp:Label>
                                            <br />
                                            <%--<asp:Label ID="Label2" runat="server" Text="Video Link:-"></asp:Label>--%>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("PRODM_VIDEO_LINK")%>' Text='<%#Eval("PRODM_VIDEO_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Clinical Video Lessons" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("VIDEO_LINK")%>' Text='<%#Eval("VIDEO_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEP Date" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPAT_DATE" runat="server" Text='<%#Eval("IEPAT_DATE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEP Remark" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:TextBox ID="IEPAT_REMARK" runat="server" Text='<%#Eval("IEPAT_REMARK")%>'></asp:TextBox>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEPDT_PRICE" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDT_PRICE" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEPDTD_PRODMID" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDTD_PRODMID" runat="server" Text='<%#Eval("IEPDTD_PRODMID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                   <asp:TemplateField HeaderText="ID14" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDTD_ID" runat="server" Text='<%#Eval("IEPDTD_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Progress">
                                        <ItemTemplate>
                                            <a id="popupiep" href='IEP_PATIENT_PROGRESS.aspx?id=<%#Eval("IEPAT_ID")%> + <%#Eval("DCAT_NAME")%>'>
                                                <asp:ImageButton runat="server" OnClientClick="basicPopup();return false;" ImageUrl="App_Resources/images/visit.png" />
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid" runat="server">
               <asp:Button ID="btnCreate" CssClass="btn yellow" runat="server" Text="Click To Create Your Own Activities & IEP" OnClick="btnActivities_Click" />
           </div>
    <br />

    <%--BEGIN Trail--%>

    <div class="row-fluid" id="Div1" runat="server">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box yellow">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Your Own Created Activities</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                           <ContentTemplate>
                                              <asp:TextBox ID="PTP_DATE_TXT1" runat="server" Placeholder="yyyy/MM/dd" CssClass="span12 m-wrap" autocomplete="off"/>
                                          <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../App_Resources/images/CalendarImg.png" OnClick="OwnActivity_ImageButtonCalendar_Click"/>
		                                    <asp:Calendar ID="Calendar2" runat="server" BorderWidth="1px" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" 
			                                    Height="200px" ShowGridLines="True" Visible="false" Width="220px" OnSelectionChanged="OwnActivity_Calendar_SelectionChanged"></asp:Calendar>
                                           </ContentTemplate>
                                         </asp:UpdatePanel>
                                        <%--<asp:TextBox ID="PTP_DATE_TXT1" Placeholder="yyyy/MM/dd" runat="server" CssClass="span12 m-wrap" autocomplete="off"/>
                                        <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="PTP_DATE_TXT1" Format="yyyy/MM/dd" Enabled="true" runat="server"></cc1:CalendarExtender>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Home Activity<span class="required"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_HOME_ACTIVITY" runat="server" CssClass="span12 m-wrap"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Remark<span class="required"></span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="TXT_REMARK" runat="server" CssClass="span12 m-wrap"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                          </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Suggested Activities<span class="required"></span></label>
                                    <div class="text-box">
                                        <asp:TextBox ID="TXT_SUGGESTED" runat="server" style="height:200px;width:280px;margin-left: 17px;"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <%--Trail for emerging ,accomplished Start--%>
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Emerging<span class="required">*</span></label>
                            <div class="controls">
                                <asp:CheckBox runat="server" OnCheckedChanged="chkSelect_CheckedChanged" AutoPostBack="true" ID="chkSelect" />
                            </div>
                        </div>

                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">Accomplished<span class="required">*</span></label>
                            <div class="controls">
                                <asp:CheckBox runat="server" OnCheckedChanged="chkSelect1_CheckedChanged" AutoPostBack="true" ID="chkSelect1" />
                            </div>
                        </div>
                        <div class="control-group" style="margin-bottom: 10px;">
                            <label class="control-label">No Improvement<span class="required">*</span></label>
                            <div class="controls">
                                <asp:CheckBox runat="server" OnCheckedChanged="chkSelect2_CheckedChanged" AutoPostBack="true" ID="chkSelect2" />
                            </div>
                        </div>
                      <%--Trail for emerging ,accomplished End--%>


                        <div class="form-actions">
                            <asp:Button ID="btnactivitiessave" CssClass="btn yellow" runat="server" Text="Save" OnClick="btnSaveActivities_Click" />
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
                </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>
           

    <div class="row-fluid" id="Creator" runat="server">
        <div class="span12">
            <div class="portlet box yellow">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i> Therapist's IEP </div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel2" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="15" AllowPaging="true" AllowSorting="true" EmptyDataText="No, Record Added" OnPageIndexChanging="GridView1_PageIndexChanging" onrowcommand="GridView1_RowCommand"
                                OnRowDataBound="GridView1_OnRowDataBound">
                                <Columns>
                                    
                                    <asp:TemplateField HeaderText="IEP Date" HeaderStyle-Width="100px">
                                        <ItemTemplate>
                                            <asp:Label ID="Label12" runat="server" Text='<%#Eval("DATE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEP Activities" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="TextBox1" runat="server" Text='<%#Eval("IEPAT_ACTIVITIES")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="TextBox2" runat="server" Text='<%#Eval("IEPAT_REMARK")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEP Home Activities" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="TextBox3" runat="server" Text='<%#Eval("IEPAT_HOME_ACTIVITIY")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="IEPDT_PRICE" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Label13" runat="server"></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID7" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPAT_ID" runat="server" Text='<%#Eval("IEPAT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Accomplished" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# Eval("IEPAT_PRESENT").ToString()=="1" ? true : false %>'
                                        Enabled='<%#(String.IsNullOrEmpty(Eval("IEPAT_PRESENT").ToString()) ? false: true) %>'/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Emerging" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# Eval("IEPAT_ABSENT").ToString()=="1" ? true : false %>'
                                        Enabled='<%#(String.IsNullOrEmpty(Eval("IEPAT_ABSENT").ToString()) ? false: true) %>'/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="No Improvement" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# Eval("IEPAT_REG").ToString()=="1" ? true : false %>'
                                        Enabled='<%#(String.IsNullOrEmpty(Eval("IEPAT_REG").ToString()) ? false: true) %>'/>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:ButtonField ButtonType="Image" CommandName="delete" ImageUrl="~/App_Resources/images/btn_remove-selected_bg.gif" />
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- END TRAIL -->


    
    <asp:HiddenField Value="0" ID="HiddenField2" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE12" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="PTP_ID" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField3" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField4" runat="server" />

    <asp:HiddenField Value="0" ID="CURRICULUM" runat="server" />
    <asp:HiddenField Value="0" ID="DIS_ID" runat="server" />
    <asp:HiddenField Value="0" ID="IEPDTD_ID" runat="server" />

    <asp:HiddenField ID="hdnID" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField5" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField6" Value="0" runat="server" />

    <style>
            .shower {
                display: block !important;
            }
        </style>
    <script type="text/javascript">

        window.onload = function () {
            var video_url = document.getElementById("<%= HiddenField4.ClientID %>").value;
            if (video_url == null || video_url == 0) {
                document.getElementById('pressed_btn').style.display = 'none';
            }
        }

        function basicPopup() {
            console.log("entered inside basicPOP");
          //  $(document).ready(function () {
                console.log("entered inside doc ready");
                $('a#popupiep').live('click', function (e) {

                    var page = $(this).attr("href")
                    <%--var selectect_Cat = document.getElementById("<%#Eval("DCAT_NAME")%>").value;
                    console.log("Cta",selectect_Cat);
                    console.log("huiiii");--%>
                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: "100%",
                            bgcolor: "#ffffff",
                            title: "IEP Patient Detail",
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
            //});
        }

        function basicPopupList() {
            $(document).ready(function () {

                $('a#popupiep1').live('click', function (e) {

                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
                            title: "IEP Patient Progress List",
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
        /*@media screen and (min-width: 768px) {*/
  @media screen (min-width: 100px) and (max-width: 700px) {
      #ModalPopupExtender1 {
          top : 66px;
          left: auto;
          bottom: auto;
        overflow: visible;
      }

      .text-box
      {
          height: 200px;
          width:  50%;
      }
  }

  .text-box
      {
          height: 200px;
          width:  704px;
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