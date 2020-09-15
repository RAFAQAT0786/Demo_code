<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="CUSTOMER.aspx.cs" Inherits="customer" Title="Customer List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Customer List</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="doctor_welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i>Customer List<i class="icon-angle-right"></i></li>
        </ul>
    </div>
    <div runat="server" id="cust1" visible="false">
        <div class="row-fluid" style="margin-bottom: 8px;">
            <div class="span12">
                <div class="portlet-body" style="text-align: right;">
                    <asp:LinkButton class="btn purple" Text="Create New Customer" OnClick="CreateNewCustbtn_Click" ID="CreateNewCustbtn" runat="server" CausesValidation="false" />
                    <asp:LinkButton class="btn red" Text="Delete Customer" OnClientClick="return F();" OnClick="btnDelete_Click" ID="a" runat="server" CausesValidation="false" />
                </div>
            </div>
        </div>
    </div>
    <div class="portlet box blue">
        <div class="portlet-title">
            <div class="caption"><i class="icon-reorder"></i>Customer Visit Detail List</div>
        </div>
        <div class="portlet-body">
            <div class="table table-striped table-bordered table-hover">
                <asp:GridView Width="100%" DataSourceID="ObjectDataSource1"
                    DataKeyNames="CUST_ID" AutoGenerateColumns="False" AllowPaging="True"
                    OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1"
                    runat="server" AllowSorting="True" EmptyDataText="No, Record Found..">
                    <Columns>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                            <HeaderTemplate>
                                <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" />
                            </HeaderTemplate>
                            <ItemTemplate>
                                <input type="checkbox" value='<%#Eval("CUST_ID")%>' onclick="SelectUnSelect(this)"
                                    id="chkSelect" />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Customer Name" HeaderStyle-HorizontalAlign="Left">
                            <ItemTemplate>

                                <%# Eval("CUST_PREFIX") %>&nbsp;<%# Eval("CUST_NAME")%>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="CUST_COMP_NAME" HeaderText="Company" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CUST_MOBILE" HeaderText="Mobile No." HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="CUST_PROSPECTIVE" HeaderText="Prospective" HeaderStyle-HorizontalAlign="Left">
                            <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Patient">
                            <ItemTemplate>
                                <a href='Patient.aspx?id=<%#Eval("CUST_ID")%>' class="btn green icn-only"><i class="icon-edit icon-white"></i></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Modify">
                            <ItemTemplate>
                                <a href='Customer_Create.aspx?id=<%#Eval("CUST_ID")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <div class="form-horizontal" style="margin-bottom: 1px;" runat="server" id="ID">
        <div class="row-fluid">
            <div class="span6">
                <div class="portlet-body">
                    <div class="control-group">
                        <label class="control-label">Subscription Remaining<span class="required">*</span></label>
                        <div class="controls">
                            <asp:TextBox ID="TXT_SUB" runat="server" CssClass="span6 m-wrap" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetCustomer" TypeName="BLLCustomer"
        ID="ObjectDataSource1" runat="server" DeleteMethod="DelCustomer">
        <DeleteParameters>
            <asp:Parameter Name="CUST_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="pATSession" Type="Object" SessionField="User" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="TXTVALUE" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField2" runat="server" />
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
        {var res = confirm('Do You Want to Delete Customer Detail?');
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