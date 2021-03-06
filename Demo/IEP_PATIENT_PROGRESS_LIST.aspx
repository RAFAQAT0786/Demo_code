﻿<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="IEP_PATIENT_PROGRESS_LIST.aspx.cs" Inherits="IEP_PATIENT_PROGRESS_LIST" Title="Enter IEP Patient Progress List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
    <script src="FusionCharts/FusionCharts.js" type="text/javascript"></script>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="App_Resources/javascript/jquery-1.9.1.js"></script>
    <script type="text/javascript" src="App_Resources/javascript/jquery-ui.js" ></script>
    

    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Progress Review</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
            <li>Progress Review</li>
        </ul>
    </div>
    <%--<div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions To Use</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>--%>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
            </div>
        </div>
    </div>
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                   <div class="caption">Progress Review</div>
                </div>
                <div class="portlet-body form">
                    <!-- BEGIN FORM-->
                    <div class="form-horizontal">
                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Patient's Name<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Disorder<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLDIS" CssClass="span12 m-wrap" runat="server" AutoPostBack="false">
                                            <asp:ListItem Value="0">-- Select Dis Order Name --</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid">
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
                        </div>

                        <div class="row-fluid">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">From Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_FROM_TXT" ValidationGroup="NONE" runat="server" CssClass="span12 m-wrap" />
                                        <cc1:CalendarExtender ID="CalendarExtender2" TargetControlID="PTP_FROM_TXT" Format="yyyy-MM-dd" Enabled="true" runat="server"></cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">To Date<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="PTP_TO_TXT" ValidationGroup="NONE" runat="server" CssClass="span12 m-wrap" />
                                        <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="PTP_TO_TXT" Format="yyyy-MM-dd" Enabled="true" runat="server"></cc1:CalendarExtender>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="form-actions">
                            <asp:Button ID="Button1" CssClass="btn yellow" Text="Search By Date" runat="server" OnClick="btnDate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                        <div class="caption"><i class="icon-table"></i>Patient Progress Review</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="IEPAT_ID" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" AllowPaging="true" AllowSorting="True" EmptyDataText="No, Record Added"
                                OnPageIndexChanging="IEPAT_ID_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="800px">
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

                                    <asp:TemplateField HeaderText="IEP Date" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPAT_DATE" runat="server" Text='<%#Eval("IEPAT_DATE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Accomplished" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# Eval("IEPAT_PRESENT").ToString()=="1" ? true : false %>'
                                        Enabled='<%#(String.IsNullOrEmpty(Eval("IEPAT_PRESENT").ToString()) ? false: true) %>' onclick="SelectUnSelect(this)" id="chkSelect" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Emerging" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# Eval("IEPAT_ABSENT").ToString()=="1" ? true : false %>'
                                        Enabled='<%#(String.IsNullOrEmpty(Eval("IEPAT_ABSENT").ToString()) ? false: true) %>' onclick="SelectUnSelect(this)" id="chkSelect1" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="No Improvement" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" Checked='<%# Eval("IEPAT_REG").ToString()=="1" ? true : false %>'
                                        Enabled='<%#(String.IsNullOrEmpty(Eval("IEPAT_REG").ToString()) ? false: true) %>' onclick="SelectUnSelect(this)" id="chkSelect2" />
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

                                    <asp:BoundField DataField="IEPDTD_ID" HeaderText="ID34" HeaderStyle-HorizontalAlign="Left" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:BoundField>

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

                                    <asp:TemplateField HeaderText="IEPA" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDTD_IEPAID" runat="server" Text='<%#Eval("IEPDTD_IEPAID")%>'></asp:Label>
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

    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField ID="hdnID" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField2" Value="0" runat="server" />
    <asp:HiddenField ID="HiddenField3" Value="0" runat="server" />
</asp:Content>