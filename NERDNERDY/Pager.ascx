<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Pager.ascx.cs" Inherits="Pager" %>
<div style="font-size: 8pt; font-family: Verdana;">
    <table cellpadding="0" cellspacing="0" style="width: 100%;">
        <tr>
            <td style="width: 100px;">
                <span>Show Page</span></td>
            <td style="width: 100px;">
                <asp:DropDownList ID="ddlPageNumber" Style="width: 100px;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageNumber_SelectedIndexChanged"></asp:DropDownList>
            </td>
            <td style="width: 200px;">
                <span>of</span>
                <asp:Label ID="lblShowRecords" runat="server"></asp:Label>
                <span>Pages</span></td>
            <td style="width: 438px;">&nbsp;</td>
            <td style="width: 60px;">
                <span>Display&nbsp;</span></td>
            <td style="width: 60px;">
                <asp:DropDownList ID="ddlPageSize" Style="width: 50px;" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                    <asp:ListItem Text="15" Value="15" Selected="true"></asp:ListItem>
                    <asp:ListItem Text="20" Value="20"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="width: 150px;">&nbsp;<span>&nbsp;Records per Page</span>
            </td>
            <td style="width: 20px"></td>
        </tr>
    </table>
</div>