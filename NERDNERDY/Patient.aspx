<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Patient.aspx.cs" Inherits="Patient" Title="Patient List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient List</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Patient List</li>
        </ul>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label2" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>
    <div class="row-fluid" style="margin-bottom:8px;" runat="server" id="HEADER1">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <asp:TextBox ID="PTP_NAME_TXT" ValidationGroup="NONE" runat="server" CssClass="span6 m-wrap" />
                <asp:Button ID="btnSearchPatient" style="text-align: right;" CssClass="btn green" Text="Search" runat="server" OnClick="btnSearchPatient_Click" />
                <a href="Parent_Create.aspx" id="A1" Width="200px" runat="server" class="btn purple" style="text-align: right;">Child's Detail</a>
                <a href="Patient_Create.aspx" id="login_pop" runat="server" class="btn purple" style="text-align: right;">Create New Patient</a>
                <asp:LinkButton class="btn red" Text="Delete Patient" OnClientClick="return F();" OnClick="btnDelete_Click" ID="LinkButton1" runat="server" />
            </div>
        </div>
    </div> 
    <div class="row-fluid" runat="server" id="PTP1">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient List</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <label id="CUSTA_SCTPQUANTITY" runat="server" visible="false">labeltext spantext</label>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                        <asp:GridView Width="100%"
                            DataKeyNames="PTP_ID" AutoGenerateColumns="False" AllowPaging="True" DataSourceID="ObjectDataSource1"
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

                                <asp:BoundField DataField="PTP_NAME" HeaderText="NAME" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_GENDER" HeaderText="GENDER" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_MOBILE" HeaderText="MOBILE NO." HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="AGRP_GROUP" HeaderText="AGE GROUP" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="SCREENING">
                                    <ItemTemplate>
                                        <a id="popupiep" href='Patient_Doctor_Screening.aspx?id=<%#Eval("PTP_ID")%>' class="btn purple icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="DEVELOPMENTAL HISTORY">
                                    <ItemTemplate>
                                        <a href='Patient_Development_Report.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TEST ADMINISTERED">
                                    <ItemTemplate>
                                        <a href='Patient_Doctor_Evaluation.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>                          
                                <asp:TemplateField HeaderText="RECOMMENDATION">
                                    <ItemTemplate>
                                        <a href='Patient_Doctor_Recommendation.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="GENERATE REPORT">
                <ItemTemplate>
                    <a href='Patient_Doctor_Report.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

                                <asp:TemplateField HeaderText="QUANTITY" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="QUANTITY" runat="server" Text="Quantity" Visible="false"></asp:Label>
                                        <asp:Label ID="PRICE" runat="server" Text="Price" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="ASSESSMENT & GENERATE IEP">
                                    <ItemTemplate>
                                        <a href='Patient_Doctor_Assessment.aspx?id=<%#Eval("PTP_ID")%>' class="btn green icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="IEP PLANNING PROGRESS">
                                    <ItemTemplate>
                                        <a href='Patient_IEP.aspx?id=<%#Eval("PTP_ID")%>' class="btn green icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="REGISTRATION">
                                    <ItemTemplate>
                                        <a href='Patient_Create.aspx?id=<%#Eval("PTP_ID")%>' class="btn blue icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                         <asp:ButtonField HeaderStyle-HorizontalAlign="Center" HeaderText="View Parent" 
                            ButtonType="Image" ItemStyle-HorizontalAlign="Center" 
                            ImageUrl="App_Resources/images/visit.png" CommandName="Email">
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                         </asp:ButtonField>
                                <%--<asp:TemplateField HeaderText="View Parent">
                                        <ItemTemplate>
                                            
                                                <asp:ImageButton Text='<%#Eval("PTP_ID")%>' runat="server" OnClientClick="confirmEmail()();return false;" OnClick="btnEmail_Click" ImageUrl="App_Resources/images/gmail-logo.jpg" />
                                            
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                            </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row-fluid" runat="server" id="Div1">
        <div class="span12">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption"><i class="icon-table"></i>Patient List</div>
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

                                <asp:BoundField DataField="PTP_NAME" HeaderText="NAME" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_GENDER" HeaderText="GENDER" HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="PTP_MOBILE" HeaderText="MOBILE NO." HeaderStyle-HorizontalAlign="Left">
                                    <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="SCREENING">
                                    <ItemTemplate>
                                        <a id="popupiep" href='Patient_Doctor_Screening.aspx?id=<%#Eval("PTP_ID")%>' class="btn purple icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="DEVELOPMENTAL HISTORY">
                                    <ItemTemplate>
                                        <a href='Patient_Development_Report.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TEST ADMINISTERED">
                                    <ItemTemplate>
                                        <a href='Patient_Doctor_Evaluation.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RECOMMENDATION">
                                    <ItemTemplate>
                                        <a href='Patient_Doctor_Recommendation.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="REPORT">
                <ItemTemplate>
                    <a href='Patient_Doctor_Report.aspx?id=<%#Eval("PTP_ID")%>' class="btn red icn-only"><i class="icon-edit icon-white"></i></a>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>

                                <asp:TemplateField HeaderText="QUANTITY" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="QUANTITY" runat="server" Text="Quantity" Visible="false"></asp:Label>
                                        <asp:Label ID="PRICE" runat="server" Text="Price" Visible="false"></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="ASSESSMENT & GENERATE IEP">
                                    <ItemTemplate>
                                        <a href='Patient_Doctor_Assessment.aspx?id=<%#Eval("PTP_ID")%>' class="btn green icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

            <asp:TemplateField HeaderText="IEP PLANNING">
                                    <ItemTemplate>
                                        <a href='Patient_IEP.aspx?id=<%#Eval("PTP_ID")%>' class="btn green icn-only"><i class="icon-edit icon-white"></i></a>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>


            <asp:TemplateField HeaderText="REGISTRATION">
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
    <asp:HiddenField ID="HiddenField2" runat="server" />
    <asp:HiddenField ID="HiddenField3" runat="server" />
    <asp:HiddenField ID="HiddenField4" runat="server" />
    <asp:HiddenField ID="HiddenField6" runat="server" />
    <asp:HiddenField ID="HiddenField7" runat="server" />
    <asp:HiddenField ID="HiddenField8" runat="server" />
    <asp:HiddenField ID="HiddenField9" runat="server" />
    <asp:HiddenField ID="HiddenField10" runat="server" />
    <asp:HiddenField ID="HiddenField11" runat="server" />

    <asp:HiddenField ID="MOBILE" runat="server" />
    <asp:HiddenField ID="EMAIL" runat="server" />
    <asp:HiddenField ID="PASSWORD" runat="server" />
 <div class="form-horizontal" style="margin-bottom:1px;" runat="server" id="ID">
  <div class="row-fluid">
    <div class="span6">
        <div class="portlet-body">
        <div class="control-group">
            <label class="control-label"><b>Subscription Remaining</b><span class="required">*</span></label>
            <div class="controls">
                <asp:TextBox ID="TXT_SUB" runat="server" CssClass="span6 m-wrap" />
            </div>
            </div>
          </div>
     </div>
   </div>
 </div>

    <asp:ObjectDataSource
        OnDeleted="ObjectDatasource1_Deleted" SelectMethod="GetParent" TypeName="BLLAge"
        ID="ObjectDataSource1" runat="server" DeleteMethod="GET_PATIENT_DETAIL_ID">
        <DeleteParameters>
            <asp:Parameter Name="PTP_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:SessionParameter Name="pATSession" Type="Object" SessionField="User" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:HiddenField Value="0" ID="HiddenField22" runat="server" />
    <asp:HiddenField ID="TXTVALUE" runat="server" />
    <asp:HiddenField Value="0" ID="PTP_ID" runat="server" />
    <asp:HiddenField Value="0" ID="CUSTA_SCTPID" runat="server" />
    <asp:HiddenField ID="TXTID" runat="server" />
    <asp:HiddenField ID="HiddenField1" runat="server" />
    <asp:HiddenField ID="HiddenField12" runat="server" />
    <asp:HiddenField ID="CUST_ID" runat="server" />
    <asp:HiddenField ID="PTP_TNAME_TXT" runat="server" />
    <asp:HiddenField ID="HiddenField5" runat="server" />
    <script type="text/javascript" language="javascript">
var Totalchk;
var Counter;
    window.onload = function () {
   Totalchk = parseInt('<%= this.GridView1.Rows.Count %>');   //Get total no. of CheckBoxes in side the GridView.
   Counter = 0;
}

    function basicPopup()
{
        var confirm_value = document.createElement("INPUT");
        confirm_value.type = "hidden";
        confirm_value.name = "confirm_value";
        confirm("Are You Sure You Want To Use This Screen.");
        <%--var id = ('<%#Eval("CUSTP_SCTPID")%>');--%>
        var id = document.getElementById('<%= this.GridView1.ClientID%>').innerText;
       <%-- var id = document.getElementById('<%=CUSTA_SCTPQUANTITY.ClientID%>').innerText();--%>
        alert(id);
        alert("no no mom")
        document.forms[0].appendChild(confirm_value);
     }

    function SelectUnSelectAll(CheckBox) {
   var grid = document.getElementById('<%= this.GridView1.ClientID %>');//Get target base & child control.
   var checkbox = "chkSelect";

   var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.

   for(var n = 0; n < Inputs.length; ++n)
    if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0)
         Inputs[n].checked = CheckBox.checked;

   Counter = CheckBox.checked ? Totalchk : 0;
}

    function SelectUnSelect(CheckBox) {
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
    function F() {
        var res = confirm('Do You Want to Delete Patient Detail?');
//alert(res);
        if (res == false) {
            return false;
}
        else {

    var grid=document.getElementById("<%=GridView1.ClientID%>");
    if (!grid) {
        alert("No Record Selected");
        return false;
    }
    var vData='';
    var checkbox = "chkSelect";
    var Inputs = grid.getElementsByTagName("input");//Get all control of type INPUT in the base control.
    for(var n = 1; n < Inputs.length; ++n)
        if(Inputs[n].type == 'checkbox' && Inputs[n].id.indexOf(checkbox,0) >= 0 && Inputs[n].checked)
            vData=vData+ Inputs[n].value + ',';  //alert(vData);
    document.getElementById("<%=TXTVALUE.ClientID %>").value=vData;//alert(vData);
    if (vData == "") {
        alert("No Record Selected");
        return false;
    }
        }
        }

        //Email
        function confirmEmail() {
            if (confirm("Are you sure you want to send the email to patient?") == true)
                return true;
            else
                return false;
        }
        //End Email confirmation
    </script>
</asp:Content>