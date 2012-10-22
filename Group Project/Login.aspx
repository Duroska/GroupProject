<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Group_Project.Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id = "loginpanel" runat = "server">
        <asp:Button ID="Button1" runat="server" Text="Login" /><br/>
        Login<br />
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox><br/>
        Password<br />
        <asp:TextBox ID="Password" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" BorderStyle="Dotted" ForeColor="#FF3300" 
            Text="Login Failed" Visible="False"></asp:Label><br/>
            If you're not registered, why not regester <a href="Register.aspx">here?</a>
    </div>
    </form>
</body>
</html>
