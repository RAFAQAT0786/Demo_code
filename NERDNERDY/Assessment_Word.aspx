<%@ Page Language="C#" MasterPageFile="~/DOCTOR.master" AutoEventWireup="true" CodeFile="Assessment_Word.aspx.cs" Inherits="Assessment_Word" Title="Assessment Word" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="row-fluid" style="height: 120px;">
        <h3 class="page-title">Individualized Educational Plan(IEP)</h3>
        <ul class="breadcrumb">
            <li><i class="icon-home"></i><a href="Admin_Welcome.aspx">Home</a> <i class="icon-angle-right"></i></li>
            <li>Individualized Educational Plan(IEP)</li>
        </ul>
    </div>
    <div class="row-fluid">
        <div class="span12">
            <div class="portlet-body-button" style="text-align: right;">
                <a href="Patient.aspx" class="btn purple" style="text-align: right;">Patient Detail</a>
            </div>
        </div>
    </div>
    <div class="row-fluid" id="Div1" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Individualized Educational Plan(IEP))</div>
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
                                     <asp:TemplateField HeaderText="Intervention Tools" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                               <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("PRODM_IMAGE_LINK")%>' onerror="this.src = '/assets/img/sped pic.jpeg'" height="120px" Width="150px" />
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("PRODM_NAME")%>'></asp:Label>
                                            <br />
                                            <asp:HyperLink ID="PRODM_LINK" runat="server" NavigateUrl='<%#Eval("PRODM_LINK")%>' Text='<%#Eval("PRODM_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Intervention Tool Video" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%#Eval("PRODM_VIDEO_LINK")%>' Text='<%#Eval("PRODM_VIDEO_LINK")%>'></asp:HyperLink>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>

                                    <%--For adding the clinical video link--%> 
                                    <asp:TemplateField HeaderText="Clinical Video Lessons" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("VIDEO_LINK")%>' Text='<%#Eval("VIDEO_LINK")%>'></asp:HyperLink>
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

    <%--for curriculum paient obsertaion Start--%>

    <div class="row-fluid" id="Div2" runat="server">
        <div class="span12">
            <div class="portlet box blue">
                <div class="portlet-title">
                <div class="caption"><i class="icon-table"></i>Individualized Educational Plan(IEP))</div>
                    <div class="tools">
                        <div class="btn-group pull-right" data-toggle="buttons-radio">
                        </div>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="table table-striped table-bordered table-hover">
                        <asp:Panel ID="Panel1" ScrollBars="Vertical" runat="server" Height="100%" Width="100%">
                            <asp:GridView ID="GridView2" AutoGenerateColumns="false" runat="server" Width="100%"
                                PageSize="25" EmptyDataText="No, Record Added">
                                <Columns>
                                    <asp:TemplateField HeaderText="IEP" HeaderStyle-Width="400px">
                                        <ItemTemplate>
                                            <asp:Label ID="Word" runat="server" Text='<%#Eval("CURRICULUM_KEYWORD")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Remark" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                            <asp:Label ID="remark" runat="server" Text='<%#Eval("PTACD_REMARK")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="left" />
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Resources Link" HeaderStyle-Width="400px" >
                                        <ItemTemplate>
                                               <asp:Image ID="Image1" runat="server" ImageUrl='<%#Eval("PRODM_IMAGE_LINK")%>' onerror="this.src = '/assets/img/sped pic.jpeg'" height="120px" Width="150px" />
                                            <br />
                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("PRODM_NAME")%>'></asp:Label>
                                            <br />
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

                                    <%--For adding the clinical video link--%> 
                                    <asp:TemplateField HeaderText="Clinical Video Lessons" HeaderStyle-Width="200px" >
                                        <ItemTemplate>
                                            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("VIDEO_LINK")%>' Text='<%#Eval("VIDEO_LINK")%>'></asp:HyperLink>
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

  <%--for curriculum paient obsertaion End--%>

    <asp:HiddenField ID="TXTVALUE" runat="server" />
</asp:Content>