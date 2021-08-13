<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient_Doctor_Evaluation.aspx.cs" Inherits="Patient_Doctor_Evaluation" Title="Patient Evaluation List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="row-fluid" style="height:120px;">
        <h3 class="page-title">Test Administered</h3>
        <ul class="breadcrumb" >
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Test Administered</li>
        </ul>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label1" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom:8px;" runat="server" id="HEADER1">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="EVALUATION_RECOMMENDED_TEST.aspx" class="btn purple" style="text-align: right;">Recommended Evaluation</a>
                <a href="Patient.aspx" class="btn green" style="text-align: right;">Patient List</a>
            </div>
        </div>
    </div>
    <div class="row-fluid" runat="server" id="PTP1">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Test Administered</div>
                     <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                      </div>
                   </div>
              </div>
       <label id="CUSTA_SCTPQUANTITY" runat="server" visible="false"></label>
         <div class="portlet-body">
           <div class="table table-striped table-bordered table-hover">
               <asp:GridView Width="100%" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" ID="GridView1" 
        runat="server" AllowSorting="True" EmptyDataText="No, Record Found.." onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Tests and Disorders" HeaderStyle-Width="900px">
                <ItemTemplate>
                    <asp:Label ID="EVA_NAME" runat="server" Text='<%#Eval("EVA_NAME")%>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="left"/>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Test Templates">
            <ItemTemplate>
                <asp:Button Text="View" runat="server" CommandName="View" BackColor="Green" CommandArgument='<%# Eval("EVA_ID") %>'  />
            </ItemTemplate>
          </asp:TemplateField>
          </Columns>
        </asp:GridView>
      </div>
    </div>
  </div>
 </div>
</div>

<asp:HiddenField ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="PTP_ID" runat="server" />
 <asp:HiddenField Value="0" ID="CUSTA_SCTPID" runat="server" />
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
</script>
</asp:Content>