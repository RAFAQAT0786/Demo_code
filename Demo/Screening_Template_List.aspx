<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Screening_Template_List.aspx.cs" Inherits="Screening_Template_List" Title="Screening Template List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Screening Template List</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><a href="Screening_Template.aspx">Screening Template List</a></li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Screening_Template.aspx" class="btn purple" style="text-align: right;">Create New Screen</a>
                <asp:LinkButton class="btn red" Text="Delete Screen" OnClientClick="return F();" OnClick="btnDelete_Click" ID="LinkButton1" runat="server" />
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Screening Template List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView Width="100%" DataSourceID="ObjectDataSource1"
                            DataKeyNames="SCTP_ID" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1"
                            runat="server" AllowSorting="True" EmptyDataText="No, Record Found..">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" value='<%#Eval("SCTP_ID")%>' onclick="SelectUnSelect(this)"
                                            id="chkSelect" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PTP_NAME" HeaderText="PATIENT NAME" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="COND_NAME" HeaderText="CONDITION NAME" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTM_DESC" HeaderText="DESCRIBE" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Modify">
                                    <ItemTemplate>
                                        <a href='Patient_Condition.aspx?id=<%#Eval("SCTP_ID")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a>
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
    <asp:ObjectDataSource OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetScreen" TypeName="BLLAge"
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_SCREEN_TEMPLATE">
        <DeleteParameters>
            <asp:Parameter Name="SCTP_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="pATSession" Type="Object" SessionField="User" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="TXTVALUE" runat="server" />
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
{var res = confirm('Do You Want to Delete Screen Detail?');
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
    document.getElementById("<%=TXTVALUE.ClientID %>").value=vData;//alert(vData);
    if (vData=="")
    {
        alert("No Record Selected");
        return false;
    }
}}
    </script>
</asp:Content>