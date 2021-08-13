<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="Patient_Screening_List.aspx.cs" Inherits="Patient_Screening_List" Title="Patient Screening List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Screening List</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
            <li>Patient Screening List</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient_Screening.aspx" class="btn purple" style="text-align: right;">Create New Patient Screening</a>
                <asp:LinkButton class="btn red" Text="Delete Patient Screening" OnClientClick="return F();" OnClick="btnDelete_Click" ID="LinkButton1" runat="server" />
            </div>
        </div>
    </div>

    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Screening List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>

                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView Width="100%" DataSourceID="ObjectDataSource1"
                            DataKeyNames="PTS_ID" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1"
                            runat="server" AllowSorting="True" EmptyDataText="No, Record Found..">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" value='<%#Eval("PTS_ID")%>' onclick="SelectUnSelect(this)"
                                            id="chkSelect" />
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="PTS_PTPID" HeaderText="PATIENT NAME" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTS_CUSTID" HeaderText="DOCTER NAME" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTS_SCTPID" HeaderText="DESCRIBE" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTS_INPUT" HeaderText="INPUT" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTS_REMARKS" HeaderText="REMARKS" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Modify">
                                    <ItemTemplate>
                                        <a href='Patient_Screening.aspx?id=<%#Eval("PTS_ID")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a>
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
    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetPatientScreen" TypeName="BLLAge"
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_PT_SCREEN">
        <DeleteParameters>
            <asp:Parameter Name="PTS_ID" Type="String" />
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
{var res = confirm('Do You Want to Delete Patient Screen Detail?');
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