<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/DOCTOR.master" CodeFile="FRAGILE_RATING.aspx.cs" Inherits="FRAGILE_RATING" Title="Fragile Rating Detail" %>
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
            <h3 class="page-title"><span class="username"><asp:Label ID="Label1" runat="server"/></span>Fragile-X Syndrome</h3>
                <ul class="breadcrumb" >
                    <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
                    <li><i class="icon-table"></i> <a href="Patient.aspx">Patient List</a> <i class="icon-angle-right"></i></li>
                    <li>Fragile-X Syndrome</li>
                </ul>
            </div>    
    
    <div class="row-fluid">
        <div class="span12">
            <h1 class="page-title"><b>Instructions & Directions</b></h1>
            <div class="portlet-body">
                <asp:Label ID="Label2" runat="server">
                </asp:Label>
            </div>
        </div>
    </div>

        <asp:Label ID="lblmsg" runat="server"></asp:Label>
        <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" />
   <div class="row-fluid" id="car" runat="server"> 
    <div class="span12">
        <div class="portlet box blue">
            <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Fragile-X Syndrome</div>
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
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            <asp:CheckBox ID="CheckBox1" AutoPostBack="true" OnCheckedChanged="chckchanged" runat="server" /> </HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" value='<%#Eval("FRA_ID")%>' onclick="SelectUnSelect(this)" id="CheckBox2" />
                            </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-Width="900px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="FRA_ID" runat="server" Text='<%#Eval("FRA_ID")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="900px">
                        <ItemTemplate>
                            <asp:Label ID="FRA_NAME" runat="server" Text='<%#Eval("FRA_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Physical Trait" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="FRA_TRAIT" runat="server" Text='<%#Eval("FRA_TRAIT")%>'></asp:Label>
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
                <div class="caption"><i class="icon-table"></i>Fragile-X Syndrome</div>
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
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Left">
                        <HeaderTemplate>
                            <input type="checkbox" onclick="SelectUnSelectAll(this)" id="chkHeader" /></HeaderTemplate>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" id="CheckBox1" AutoPostBack="True" Checked='<%# Eval("PTFRA_STATUS").ToString()=="1" ? true : false %>' Enabled='<%#(String.IsNullOrEmpty(Eval("PTFRA_STATUS").ToString()) ? false: true) %>' />
                            </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Left"></HeaderStyle>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ID" HeaderStyle-Width="900px" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="FRA_ID" runat="server"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="900px">
                        <ItemTemplate>
                            <asp:Label ID="FRA_NAME" runat="server" Text='<%#Eval("FRA_NAME")%>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="left"/>
                    </asp:TemplateField>
                                   
                    <asp:TemplateField HeaderText="Physical Trait" HeaderStyle-HorizontalAlign="Left">
                        <ItemTemplate>
                            <asp:Label ID="FRA_TRAIT" runat="server" Text='<%#Eval("FRA_TRAIT")%>'></asp:Label>
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
   <div class="row-fluid">
      <div class="span12" style="margin-bottom:-15px;">
        <div class="control-group">
            <label class="control-label"><b>Observation</b><span class="required">*</span></label>
                <div class="controls">
                <textarea class="span12 ckeditor m-wrap" id="Textarea2" cols="30" runat="server" name="editor2" rows="6" data-error-container="#editor2_error"></textarea>
                <div id="editor2_error"></div>
            </div>
          </div>                   
        </div>
     </div>

        <div class="form-actions">
            <asp:Button ID="btnSave" CssClass="btn green" OnClientClick="javascript:validateCheckBoxes()" runat="server" Text="Save" OnClick="btnSave_Click" />
        </div>

    <script type="text/javascript" language="javascript">
            
            function validateCheckBoxes()    /*Unchecked Checkbox selected */
             {
                  var isValid = false;
                   var gridView = document.getElementById('<%= GridView1.ClientID %>');
                    for (var i = 1; i < gridView.rows.length; i++) {
                     var inputs = gridView.rows[i].getElementsByTagName('input');
                      if (inputs != null) {
                       if (inputs[0].type == "checkbox") {
                        if (inputs[0].checked) {
                        isValid = true;
                        return true;
                      }
                    }
                   }
                 }
                 alert("Please select checkbox");
                return false;
             }
        </script>

        <asp:HiddenField Value="0" ID="TXTVALUE" runat="server" />
   <asp:HiddenField Value="0" ID="TXTID" runat="server" />
    <asp:HiddenField ID="hdnID" Value="0" runat="server" />
</asp:Content>

