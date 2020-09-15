<%@ Page Language="C#" MasterPageFile="~/Admin.master" AutoEventWireup="true" CodeFile="User_AdminList.aspx.cs" Inherits="User_AdminList" Title="User List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row-fluid" style="height:120px;">
        <h3 class="page-title">User List</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>User List</li>
        </ul>
    </div>
<div class="row-fluid" style="margin-bottom:8px;" runat="server" id="ID">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <asp:TextBox ID="ORGANIZATION_NAME_TXT" ValidationGroup="NONE" runat="server" CssClass="span6 m-wrap" />
                <asp:Button ID="btnSearchOrganization" style="text-align: right;" CssClass="btn green" Text="Search" runat="server" OnClick="btnSearchOrganization_Click" />
                <a href="User_Admin.aspx" class="btn purple" style="text-align: right;">Create New User</a>
                <asp:LinkButton class="btn red" Text="Delete User" OnClientClick="return F();" OnClick="btnDelete_Click" ID="LinkButton" runat="server" />
            </div>
        </div>
    </div>
<div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>User List</div>
                    <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                 </div>
             </div>
<div class="portlet-body">
    <div class="table table-striped table-bordered table-hover">
        <asp:GridView Width="100%" DataKeyNames="USR_LOGIN" AutoGenerateColumns="False" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1" runat="server" AllowSorting="True" >
            <Columns>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                    <HeaderTemplate><input type="checkbox" onclick="SelectUnSelectAll(this)" ID="chkHeader" /></HeaderTemplate>
                    <ItemTemplate><input type="checkbox" value='<%#Eval("USR_LOGIN")%>' onclick="SelectUnSelect(this)" ID="chkSelect" /></ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="USR_LOGIN" HeaderText="Login Name" HeaderStyle-HorizontalAlign="Left" />
                <asp:BoundField DataField="USR_TYPE" HeaderText="Login Type" HeaderStyle-HorizontalAlign="Left"/> 
                <asp:BoundField DataField="USR_ORGANIZATION_NAME" HeaderText="User's Company" HeaderStyle-HorizontalAlign="Left"/> 
                <%--<asp:BoundField DataField="USR_COMPANY" HeaderText="User's Company" HeaderStyle-HorizontalAlign="Left"/> --%>
                <asp:BoundField DataField="USR_CONT_NAME" HeaderText="User's Name" HeaderStyle-HorizontalAlign="Left"/> 
                <asp:BoundField DataField="USR_EMAIL" HeaderText="User's Email" HeaderStyle-HorizontalAlign="Left"/>
                <asp:TemplateField HeaderText="Modify">
                    <ItemTemplate><a href='User_Admin.aspx?id=<%#Eval("USR_LOGIN")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a></ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
     </div>
   </div>
  </div>
 </div>
</div>
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
            vData=vData+ "'" + Inputs[n].value + "',";  //alert(vData);
    document.getElementById("<%=TXTVALUE.ClientID %>").value=vData;//alert(vData);
    if (vData=="")
    {
        alert("No Record Selected");
        return false;
    }
    }
    function F()
{
    var res = confirm('Do You Want to Delete Organization Detail?');
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