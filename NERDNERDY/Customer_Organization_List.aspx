<%@ Page Language="C#" MasterPageFile="~/Organization.master" AutoEventWireup="true" CodeFile="Customer_Organization_List.aspx.cs" Inherits="Customer_Organization_List" Title="Customer Organization List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Organization List</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="doctor_welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i>Patient Organization List<i class="icon-angle-right"></i></li>
        </ul>
    </div>
    <div runat="server" id="cust1" visible="false">
        <div class="row-fluid" style="margin-bottom: 8px;">
            <div class="span12">
                <div class="portlet-body" style="text-align: right;">
                    <asp:TextBox ID="PTP_NAME_TXT" ValidationGroup="NONE" runat="server" CssClass="span6 m-wrap" />
                    <asp:Button ID="btnSearchPatient" Style="text-align: right;" CssClass="btn green" Text="Search" runat="server" OnClick="btnSearchPatient_Click" />
                    <a href="Patient_Create.aspx" id="login_pop" runat="server" class="btn purple" style="text-align: right;">Create New Patient</a>
                    <a href="Customer_Organization.aspx" class="btn purple" style="text-align: right;">Organization List</a>
                    <asp:LinkButton class="btn red" Text="Delete Patient" OnClientClick="return F();" OnClick="btnDelete_Click" ID="LinkButton1" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid" runat="server" id="PTP1">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Organization Detail List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <label id="CUSTA_SCTPQUANTITY" runat="server" visible="false">labeltext spantext</label>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView Width="100%"
                            DataKeyNames="PTP_ID" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1"
                            runat="server" AllowSorting="True" EmptyDataText="No, Record Found.." OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="PTP_ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="PTP_ID" runat="server" Text='<%#Eval("PTP_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" value='<%#Eval("PTP_ID")%>' onclick="SelectUnSelect(this)"
                                            id="chkSelect" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Patient Name" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Eval("PTP_NAME")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PTP_GENDER" HeaderText="Gender" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_REFERRED" HeaderText="Referred" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_MOBILE" HeaderText="Mobile No." HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_EMAIL" HeaderText="Email" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_THERAPIST_NAME" HeaderText="Therapist Name" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="MODIFY">
                                    <ItemTemplate>
                                        <a href='Patient_Create.aspx?id=<%#Eval("PTP_ID")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid" runat="server" id="Div1">
        <div class="span12">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Organization Detail List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <label id="Label1" runat="server" visible="false">labeltext spantext</label>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView Width="100%"
                            DataKeyNames="PTP_ID" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="GridView2_PageIndexChanging" PageSize="20" ID="GridView2"
                            runat="server" AllowSorting="True" EmptyDataText="No, Record Found.." OnRowCommand="GridView2_RowCommand">
                            <Columns>

                                <asp:TemplateField HeaderText="PTP_ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="PTP_ID" runat="server" Text='<%#Eval("PTP_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" value='<%#Eval("PTP_ID")%>' onclick="SelectUnSelect(this)"
                                            id="chkSelect" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Patient Name" HeaderStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <%# Eval("PTP_NAME")%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PTP_GENDER" HeaderText="Gender" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_REFERRED" HeaderText="Referred" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_MOBILE" HeaderText="Mobile No." HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_EMAIL" HeaderText="Email" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_THERAPIST_NAME" HeaderText="Therapist Name" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="MODIFY">
                                    <ItemTemplate>
                                        <a href='Patient_Create.aspx?id=<%#Eval("PTP_ID")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField Value="0" ID="HiddenField22" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField Value="0" ID="PTP_ID" runat="server" />
    <asp:HiddenField Value="0" ID="CUSTA_SCTPID" runat="server" />
    <asp:HiddenField ID="TXTID" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="CUST_ID" runat="server" />
    <asp:HiddenField ID="PTP_TNAME_TXT" runat="server" />
    <asp:HiddenField ID="TXTVALUE" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <script type="text/javascript" language="javascript">
        var Totalchk;
        var Counter;
        window.onload = function()
        {
           Totalchk = parseInt('<%= this.GridView1.Rows.Count %>');   //Get total no. of CheckBoxes in side the GridView.
           Counter = 0;
        }
        function SelectUnSelectAll(CheckBox)
        {
           var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
           var checkbox = "chkSelect";

           var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

           for(var n = 0; n < Inputs.length; ++n)
            if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0)
                 Inputs[n].checked = CheckBox.checked;

           Counter = CheckBox.checked ? Totalchk : 0;
        }

        function SelectUnSelect(CheckBox)
        {
           var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
           var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
           if(CheckBox.checked && Counter < Totalchk)   //Modifiy Counter;
              Counter++;
           else if(Counter > 0)
              Counter--;
           if(Counter < Totalchk)   //Change state of the header CheckBox.
              Inputs[0].checked = false;
           else if(Counter == Totalchk)
              Inputs[0].checked = true;
        }
        function F()
        {var res = confirm('Do You Want to Delete Customer Organization Detail?');
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
            document.getElementById("<%=TXTVALUE.ClientID %>").value=vData;//alert(vData);
            if (vData=="")
            {
                alert("No Record Selected");
                return false;
            }
        }
        }
    </script>
</asp:Content>