<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Assessment_Word.aspx.cs" Inherits="Assessment_Word" Title="Assessment Word" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Patient Individualized Educational Plan(IEP)</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Patient Individualized Educational Plan(IEP)</li>
            <li>
				<asp:LinkButton id="LinkButton2" class="btn blue" runat="server" style="text-align:left" Text="Intervention Tools" onClientClick="window.open('https://nerdnerdy.com/');"></asp:LinkButton>
                <asp:LinkButton id="LinkButton3" class="btn green" runat="server" style="text-align:left" Text="Buy license" onClientClick="window.open('https://nerdnerdy.com/');"></asp:LinkButton>
			</li>
        </ul>
    </div>
    <div class="row-fluid" style="margin-bottom: 8px;">
        <div class="span12">
            <div class="portlet-body" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Go To Patient Detail</a>
            </div>
        </div>
    </div>
    <div class="row-fluid" id="Div1" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Patient Individualized Educational Plan(IEP)</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel4" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView1" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added">
                                <Columns>
                                    <asp:TemplateField HeaderText="IEP" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="Word" runat="server" Text='<%#Eval("ASER_KEYWORD")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:Label ID="remark" runat="server" Text='<%#Eval("PTAD_REMARK")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Resources Name" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("PRODM_NAME")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Resources Link" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="PRODM_LINK" runat="server" NavigateUrl='<%#Eval("PRODM_LINK")%>' Text='<%#Eval("PRODM_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Resources Video Link" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("PRODM_VIDEO_LINK")%>' Text='<%#Eval("PRODM_VIDEO_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </asp:Panel>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="TXTVALUE" runat="server" />
</asp:Content>