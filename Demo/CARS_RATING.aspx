<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DOCTOR.master" CodeFile="CARS_RATING.aspx.cs" Inherits="CARS_RATING" Title="CAR Rating Detail" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript"></script>
    <script src="//cdn.ckeditor.com/4.12.1/full/ckeditor.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="../js/clock.js" type="text/javascript"></script>
    <script src="../js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>
    <script src="../js/js.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/ckeditor/ckeditor.js"></script>
    <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/wysihtml5-0.3.0.js"></script> 
     <script type="text/javascript" src="assets/plugins/bootstrap-wysihtml5/bootstrap-wysihtml5.js"></script>

        <div class="row-fluid" style="height:120px;"> 
            <h3 class="page-title"><span class="username"><asp:Label ID="Label1" runat="server"/></span>Childhood Autism Rating Scale(CARS-2)</h3>
                <ul class="breadcrumb" >
                    <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
                    <li><i class="icon-table"></i> <a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
                    <li>Childhood Autism Rating Scale(CARS-2)</li>
                </ul>
            </div>    
         <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
   <div class="row-fluid" id="car" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Childhood Autism Rating Scale(CARS-2)</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>                      
       <div class="portlet-body">
        <div class="table table-striped table-bordered table-hover">
         
            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%" Height="100%"
                PageSize="25" EmptyDataText="No, Record Added">
                <Columns>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-Width="900px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="CAR_ID" runat="server" Text='<%#Eval("CAR_ID")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="900px">
                        <ItemTemplate>
                            <asp:Label ID="CAR_NAME" runat="server" Text='<%#Eval("CAR_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Score" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_VALUE" runat="server" Width="85px" onkeypress="return validate(event)"></asp:TextBox>
                            <asp:RegularExpressionValidator Display="Dynamic" runat="server" ControlToValidate="PTC_VALUE" ValidationExpression="^([0-5]*)$" ErrorMessage="Not Greater than 5 or Less than 1" />
                              <cc1:FilteredTextBoxExtender ID="FTB1" FilterType="Numbers" TargetControlID="PTC_VALUE" runat="server" />
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Score" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_RAWSCORE" runat="server" Width="85px" onkeypress="return validate(event)"></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
               
                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_REMARK" runat="server" Width="300px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="TextBox Is Must Be Fill" ClientValidationFunction="validateMyTextBoxes"></asp:CustomValidator>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                 </Columns>
               </asp:GridView>
            <div class="form-actions">
                    <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
             </div>
            </div>
          </div>
        </div>
      </div>
  <div class="row-fluid" id="Submitcar" runat="server"> 
    <div class="span12">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Childhood Autism Rating Scale(CARS-2)</div>
                <div class="tools">
                    <div class="btn-group pull-right" data-toggle="buttons-radio">
                    </div>
                </div>
            </div>   
            <div class="portlet-body">
        <div class="table table-striped table-bordered table-hover">
        <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" Width="100%" Height="100%"
                PageSize="25" EmptyDataText="No, Record Added">
                <Columns>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-Width="900px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="PTC_ID" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="900px">
                        <ItemTemplate>
                            <asp:Label ID="PTC_PTRID" runat="server" Text='<%#Eval("CAR_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <%--<asp:TemplateField HeaderText="Score" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_VALUE" runat="server" Width="85px" Text='<%#Eval("PTC_VALUE")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>--%>

                    <asp:TemplateField HeaderText="Score" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_RAWSCORE" runat="server" Width="85px" Text='<%#Eval("PTC_RAWSCORE")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
               
                    <asp:TemplateField HeaderText="Remarks" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_REMARK" runat="server" Width="300px" Text='<%#Eval("PTC_REMARKS")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                 </Columns>
               </asp:GridView>
             </div>
            </div>
          </div>
        </div>
      </div>
   <asp:ObjectDataSource SelectMethod="GET_PT_CARS" TypeName="BLLAGE" ID="ObjectDataSource1" runat="server" DeleteMethod="DelCARSRATING">
        <DeleteParameters>
            <asp:Parameter Name="PTC_ID" Type="String" />
        </DeleteParameters>
        <SelectParameters>
            <asp:QueryStringParameter Name="PTP_ID" QueryStringField="Id" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

    <script type="text/javascript">
        //Function to allow only numbers to textbox
            function validate(key)
            {
            //getting key code of pressed key
            var keycode = (key.which) ? key.which : key.keyCode;
            var phn = document.getElementById('txtPhn');
            //comparing pressed keycodes
            if (!(keycode==8 || keycode==46)&&(keycode < 48 || keycode > 57))
            {
            return false;
            }
            else
            {
            //Condition to check textbox contains ten numbers or not
            if (phn.value.length <10)
            {
            return true;
            }
            else
            {
            return false;
            }
           }
        }

        function validateMyTextBoxes(oSrc, args)
        {
        var isValid = false;
        $("#<%= GridView1.ClientID %> input[type=text]").each(function () {
            if ($(this).val() != "") {
                isValid = true;
            }
        })
        args.IsValid = isValid;
    }

    </script>

            <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
   <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField ID="hdnID" Value="0" runat="server" />
 </asp:Content>

