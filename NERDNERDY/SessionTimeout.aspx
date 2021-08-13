<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SessionTimeout.aspx.cs" Inherits="RSM_SessionTimeout" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>NerdNerdy Technologies</title>
    <script type="text/javascript">
function showLogin()
{
    this.focus();
    self.opener = this;
    self.close();
}
function Close()
{
    window.setInterval("showLogin()",1000);
}
function closeW()
{
window.opener='X';
window.open('','_parent','');
window.close();
}
    </script>
</head>
<body onload="closeW()">
    <form id="form1" runat="server">
        <div align="center">
            Session Time out. Redirection to Login Page.
        </div>
    </form>
</body>
</html>