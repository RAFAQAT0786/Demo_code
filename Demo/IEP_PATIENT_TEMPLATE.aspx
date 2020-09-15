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
                <%--<asp:TextBox ID="PTP_TNAME_TXT" ValidationGroup="NONE" runat="server" CssClass="span4 m-wrap" />
                <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="PTP_TNAME_TXT" Format="yyyy/MM/dd" Enabled="true" runat="server"></cc1:CalendarExtender>
                <asp:Button ID="btnSearch" CssClass="btn blue" Text="Search By Date" runat="server" OnClick="btnSearch_Click" />--%>
                <asp:Button ID="btnPro" CssClass="btn yellow" Text="Progress Review" runat="server" OnClick="btnProgress_Click" />
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
                        <i class="icon-reorder"></i>IEP Planning & Progress Review</div>
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
                                        <asp:TextBox ID="PTP_DATE_TXT" runat="server" CssClass="span12 m-wrap" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="PTP_DATE_TXT" Format="yyyy/MM/dd" Enabled="true" runat="server"></cc1:CalendarExtender>
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
                                        <asp:CustomValidator ID="CustomValidator1" ControlToValidate="DDLIEA" runat="server" ErrorMessage="Already Exist" Display="Dynamic"></asp:CustomValidator>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLIEA" SetFocusOnError="true" ID="RequiredFieldValidator5" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Resources<span class="required">*</span></label>
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

    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Customized IEP & Skill Progress</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="IEPDT_ID" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added" OnPageIndexChanging="IEPDT_ID_PageIndexChanging"
          onrowdeleting="IEPDT_ID_RowDeleting" 
          onrowcommand="IEPDT_ID_RowCommand" onrowupdating="IEPDT_ID_RowUpdating" 
          onrowediting="IEPDT_ID_RowEditing">
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

               <asp:TemplateField HeaderText="Resources" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:Label ID="PRODM_NAME" runat="server" Text='<%#Eval("PRODM_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>


               <asp:TemplateField HeaderText="Resources Link" HeaderStyle-Width="300px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="PRODM_LINK" runat="server" NavigateUrl='<%#Eval("PRODM_LINK")%>' Text='<%#Eval("PRODM_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Resources Video Link" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("PRODM_VIDEO_LINK")%>' Text='<%#Eval("PRODM_VIDEO_LINK")%>'></asp:HyperLink>
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
                                            <a id="popupiep" href='IEP_PATIENT_PROGRESS.aspx?id=<%#Eval("IEPAT_ID")%>'>
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
    <asp:HiddenField Value="0" ID="HiddenField2" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE12" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="PTP_ID" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField1" runat="server" />
    <asp:HiddenField Value="0" ID="HiddenField3" runat="server" />

    <script type="text/javascript">
        function basicPopup() {
            $(document).ready(function () {

                $('a#popupiep').live('click', function (e) {

                    var page = $(this).attr("href")

                    var $dialog = $('<div></div>')
                        .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                        .dialog({
                            autoOpen: false,
                            modal: true,
                            height: 400,
                            width: 705,
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
            });
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
    </script>
</asp:Content>