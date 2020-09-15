<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Patient_Template.aspx.cs" Inherits="Patient_Template" Title="Patient Template Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Template Detail</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Patient Template Detail</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
            </div>
        </div>
    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN FORM VALIDATION -->
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <i class="icon-reorder"></i>Patient Template Detail
                    </div>
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
                                    <label class="control-label">Patient Age<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:TextBox ID="AGE_TXT" runat="server" CssClass="span12 m-wrap" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row-fluid" runat="server" id="temp3">
                            <div class="span6" style="margin-bottom: -15px;">
                                <div class="control-group">
                                    <label class="control-label">Template<span class="required">*</span></label>
                                    <div class="controls">
                                        <asp:DropDownList ID="DDLTEMP" CssClass="span12 m-wrap" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDLTEMP_SelectedIndexChanged">
                                            <asp:ListItem Value="0">-- Select Template Name --</asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ControlToValidate="DDLTEMP" SetFocusOnError="true" ID="RequiredFieldValidator10" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="span6" style="margin-bottom: -15px;" runat="server" visible="false">
                            <div class="control-group">
                                <label class="control-label">Customer Name<span class="required">*</span></label>
                                <div class="controls">
                                    <asp:TextBox ID="PTP_CUST" runat="server" CssClass="span12 m-wrap" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- END FORM-->
                </div>
            </div>
            <!-- END FORM VALIDATION -->
        </div>
    </div>

    <div class="row-fluid" id="Link" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Screen Template</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added" OnPageIndexChanging="GridView1_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTP_ID" runat="server" Text='<%#Eval("SCTP_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Template Name">
                                        <ItemTemplate>
                                            <asp:Label ID="TEMPLATE_NAME" runat="server" Text='<%#Eval("SCTP_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="PRICE_NAME" runat="server" Text='<%#Eval("SCTP_PRICE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Stock">
                                        <ItemTemplate>
                                            <asp:Label ID="Quantity" runat="server" Text='<%#Eval("CTP_QUANTITY")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:TextBox ID="Quantity1" runat="server" Width="50PX"></asp:TextBox>
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
    <asp:CustomValidator ID="CustomValidator1" runat="server" Display="None" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
    <div class="row-fluid" id="Div1" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Assessment Template</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel2" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added" OnPageIndexChanging="GridView2_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="ASE_ID" runat="server" Text='<%#Eval("ASE_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Template Name">
                                        <ItemTemplate>
                                            <asp:Label ID="TEMPLATE_NAME" runat="server" Text='<%#Eval("ASE_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="PRICE_NAME" runat="server" Text='<%#Eval("ASE_PRICE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="Quantity" runat="server" Text='<%#Eval("CTP_QUANTITY")%>'></asp:Label>
                                            <%--<asp:TextBox ID="Quantity" runat="server" Width="50PX" Text='<%#Eval("CTP_QUANTITY")%>'></asp:TextBox>--%>
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
                    <div class="caption"><i class="icon-table"></i>Patient IEP Report Template</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel3" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView3" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added" OnPageIndexChanging="GridView3_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDT_ID" runat="server" Text='<%#Eval("IEPDT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Template Name">
                                        <ItemTemplate>
                                            <asp:Label ID="TEMPLATE_NAME" runat="server" Text='<%#Eval("IEPDT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="PRICE_NAME" runat="server" Text='<%#Eval("IEPDT_PRICE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="Quantity" runat="server" Text='<%#Eval("CTP_QUANTITY")%>'></asp:Label>
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

    <div class="row-fluid" id="Div3" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Report Template</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel4" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView4" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added" OnPageIndexChanging="GridView4_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckChanged" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RPT_ID" runat="server" Text='<%#Eval("RPT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Template Name">
                                        <ItemTemplate>
                                            <asp:Label ID="TEMPLATE_NAME" runat="server" Text='<%#Eval("RPT_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Price" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="PRICE_NAME" runat="server" Text='<%#Eval("RPT_PRICE")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Quantity">
                                        <ItemTemplate>
                                            <asp:Label ID="Quantity" runat="server" Text='<%#Eval("CTP_QUANTITY")%>'></asp:Label>
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

    <div class="row-fluid" id="Div4" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Template For Patient</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel5" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView5" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added" OnPageIndexChanging="GridView5_PageIndexChanging">
                                <Columns>
                                    <asp:BoundField DataField="TEMPLATE_NAME" HeaderText="Template Name" />
                                    <asp:BoundField DataField="PRICE_NAME" HeaderText="Price" />
                                    <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" />
                                    <asp:TemplateField HeaderText="id" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="SCTP_ID" runat="server" Text='<%#Eval("SCTP_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id1" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="ASE_ID" runat="server" Text='<%#Eval("ASE_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id2" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="RPT_ID" runat="server" Text='<%#Eval("RPT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="id3" HeaderStyle-Width="400px" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="IEPDT_ID" runat="server" Text='<%#Eval("IEPDT_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TEMPLATE">
                                        <ItemTemplate>
                                            <asp:Button ID="btnView" CssClass="btn blue" OnClick="btnView_Click" runat="server" Text="View" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="form-horizontal" id="Link1" runat="server">
        <div class="form-actions">
            <asp:Button ID="btnSave" CssClass="btn blue" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>
    </div>
    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted"
        runat="server">
        <DeleteParameters>
            <asp:Parameter Name="PTP_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="CUST_ID" QueryStringField="Id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField Value="0" ID="CUST_ID" runat="server" />
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
    <script type="text/javascript" language="javascript">
        var Totalchk;
        var Counter;
        window.onload = function () {
            Totalchk = parseInt('<%= this.GridView1.Rows.Count %>');   //Get total no. of CheckBoxes in side the GridView.
            Counter = 0;
        }

        $(function ()
        {
            $('#chkSelect').click(function ()
            {
                alert("abvfd");
                var txt = $('#Quantity1');
                if (txt.val() != null && txt.val() != '')
                {
                    alert('you entered text ' + txt.val())
                }
                else
                {
                    alert('Please enter text')
                }
            })
        });

        function SelectUnSelectAll(CheckBox)
        {
            var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
            var checkbox = "chkSelect";

            var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

            for (var n = 0; n < Inputs.length; ++n)
                if (Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox, 0) >= 0)
                    Inputs[n].checked = CheckBox.checked;

            Counter = CheckBox.checked ? Totalchk : 0;
        }

        function SelectUnSelect(CheckBox) {
            var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
            var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
            if (CheckBox.checked && Counter < Totalchk)   //Modifiy Counter;
                Counter++;
            else if (Counter > 0)
                Counter--;
            if (Counter < Totalchk)   //Change state of the header CheckBox.
                Inputs[0].checked = false;
            else if (Counter == Totalchk)
                Inputs[0].checked = true;
        }
        function basicPopup()
        {
            var res = confirm('Do You Want to Buy Template?');
            //alert(res);
            if (res == false)
            {
                return false;
            }
            else
            {
                $(document).ready(function ()
                {
                    $('a#popupiep').live('click', function (e)
                    {
                        var page = $(this).attr("href")
                        var $dialog = $('<div></div>')
                            .html('<iframe style="border: 0px; " src="' + page + '" width="100%" height="100%"></iframe>')
                            .dialog({
                                autoOpen: false,
                                modal: true,
                                height: 400,
                                width: 705,
                                title: "Buy Template",
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
        }
    </script>
</asp:Content>