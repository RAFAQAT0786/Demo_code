<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="VSMS_RATING.aspx.cs" Inherits="VSMS_RATING" Title="Vineland Social Maturity Scale" %>
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
            <h3 class="page-title"><span class="username"><asp:Label ID="Label1" runat="server"/></span>Vineland Social Maturity Scale Rating</h3>
                <ul class="breadcrumb" >
                    <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
                    <li><i class="icon-table"></i> <a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
                    <li>Vineland Social Maturity Scale Rating</li>
                </ul>
            </div>    
        
        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
 <div class="row-fluid" id="car" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Vineland Social Maturity Scale Rating</div>
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
                            <asp:Label ID="VSMS_ID" runat="server" Text='<%#Eval("VSMS_ID")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Social Areas" HeaderStyle-Width="900px">
                        <ItemTemplate>
                            <asp:Label ID="VSMS_NAME" runat="server" Text='<%#Eval("VSMS_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SA(Social Age)" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTV_VALUE" runat="server" Width="100px"></asp:TextBox>
                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="At Least One TextBox Is Required" ClientValidationFunction="validateMyTextBoxes"></asp:CustomValidator>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SQ(Social Quotient)" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="AGE_MONTH" runat="server" Width="100px"></asp:TextBox>
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
  <div class="row-fluid" id="Submitcar" runat="server"> 
    <div class="span12">
        <div class="portlet box green">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Vineland Social Maturity Scale Rating</div>
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
                            <asp:Label ID="PTV_ID" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="900px">
                        <ItemTemplate>
                            <asp:Label ID="VSMS_NAME" runat="server" Text='<%#Eval("VSMS_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="SA(Social Age)" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_VALUE" runat="server" Width="100px" Text='<%#Eval("PTV_VALUE")%>'></asp:TextBox>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="SQ(Social Quotient)" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:TextBox ID="PTC_VALUE2" runat="server" Width="100px" Text='<%#Eval("PTV_AGE_MONTH")%>'>

                            </asp:TextBox>
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

    <div class="form-actions">
        <asp:Button ID="btnSave" CssClass="btn green" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>

    <script type="text/javascript" language="javascript">
            
            function validateMyTextBoxes(oSrc, args) {
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

