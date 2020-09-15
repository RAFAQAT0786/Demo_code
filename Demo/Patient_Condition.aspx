<%@ Page Language="C#" MasterPageFile="~/Admin.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="Patient_Condition.aspx.cs" Inherits="Patient_Condition" Title="Patient Mental Information" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <script type="text/javascript"></script>

    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title"><span class="username">
            <asp:Label ID="PTP_TXT" runat="server" /></span> Mental Information</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li><i class="icon-table"></i><a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
            <li>Patient Mental Information</li>
        </ul>
    </div>
    <cc1:ToolkitScriptManager ID="scrtoolkit" runat="server" />
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient List</a>
            </div>
        </div>
    </div>
    <div id="hidden1" runat="server">
        <div class="row-fluid">
            <div class="span12">
                <!-- BEGIN FORM VALIDATION -->
                <div class="portlet box green">
                    <div class="portlet-title">
                        <div class="caption">
                            <i class="icon-reorder"></i>Patient Mental Information
                        </div>
                    </div>
                    <div class="portlet-body form">
                        <!-- BEGIN FORM-->
                        <div class="form-horizontal">
                            <div class="row-fluid">
                                <div class="span6" style="margin-bottom: -15px;">
                                    <div class="control-group">
                                        <label class="control-label">Condition<span class="required">*</span></label>
                                        <div class="controls">
                                            <asp:DropDownList ID="COND_ID" runat="server" CssClass="span12 m-wrap"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row-fluid">
                                <div class="span12" style="margin-bottom: -15px;">
                                    <div class="control-group">
                                        <label class="control-label">Description<span class="required">*</span></label>
                                        <div class="controls">
                                            <textarea class="span12 ckeditor m-wrap" id="Textarea1" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                                            <div id="editor2_error"></div>
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
    </div>
    <asp:HiddenField Value="0" ID="TXTID" runat="server" />

    <div class="row-fluid">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient Condition List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:GridView Width="100%" DataSourceID="ObjectDataSource1"
                            DataKeyNames="PTM_ID" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="20" ID="GridView1"
                            runat="server" AllowSorting="True" EmptyDataText="No, Record Found.." OnRowCommand="GridView1_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                                    <HeaderTemplate>
                                        <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <input type="checkbox" value='<%#Eval("PTM_ID")%>' onclick="SelectUnSelect(this)"
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
                                <asp:TemplateField HeaderStyle-CssClass="colhide" HeaderText="ID2" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="PTM_ID" Visible="false" runat="server" Text='<%#Eval("PTM_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="left" />
                                </asp:TemplateField>
                                <asp:ButtonField ItemStyle-HorizontalAlign="Center" HeaderText="Modify"
                                    ButtonType="Image" ImageUrl="App_Resources/images/edit.gif"
                                    CommandName="modify">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetParentMentalNEW" TypeName="BLLAge"
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_PT_MENTAL">
        <DeleteParameters>
            <asp:Parameter Name="PTM_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>

            <asp:QueryStringParameter Name="PTP_ID" QueryStringField="Id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField ID="PTP_ID" runat="server" />
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
{var res = confirm('Do You Want to Delete Patient Detail?');
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