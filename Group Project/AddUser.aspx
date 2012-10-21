<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddUser.aspx.vb" Inherits="Group_Project.AddUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="Label6" runat="server" Text="User ID"></asp:Label>
        <asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br/>
        <table = cellpadding=3>
        
        <tr>
            <td align=right><b>First name:</b></td>
            <td><asp:DropDownList ID="dlstTitle" runat="server">
            <asp:ListItem>Mr.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem>Msr.</asp:ListItem>
            <asp:ListItem>Dr.</asp:ListItem>
            <asp:ListItem Selected="True">Unknown</asp:ListItem>
            </asp:DropDownList>
                <asp:TextBox ID="TextBox1" runat="server" Width="160px"/>
            <td><br /></td>
        </tr>
        
        <tr>
            <td align=right><b>Last name:</b></td>
            <td><asp:TextBox ID="access0" runat="server" Width="160px"/><asp:Label ID="Label1" runat="server" Text="User logon Name"></asp:Label></td>
        </tr>
        
         <tr>
            <td align=right><b>User Password:</b></td>
              <br/>
              <asp:Label ID="Label2" runat="server" Text="User Password"></asp:Label>
              <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
              <br/>
            </td>
        </tr>

        <tr>
            <td align=right><b>User Age:</b></td>
            <td><b><asp:Label ID="Label8" runat="server" Text="User Age"><b></asp:Label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td align=right><b>Change Access Rights:</b></td>
            <td><asp:TextBox ID="access" runat="server" Width="160px"/><br /></td>
        </tr>

        <tr>
            <td align=right><b>Address:</b></td>
            <asp:Label ID="Label5" runat="server" Text="Adress"></asp:Label>
            <td><asp:TextBox ID="txtAdress" runat="server" Width="222px" Height="57px"/><br /></td>
        </tr>
        
        <tr>       
            <td>
                <br/> <asp:Button ID="cmdAdd" runat="server" Text="Submit" /> <br/>
            </td>
        </tr>

        <tr>
            <td>
                
                <asp:Button ID="cmdGet" runat="server" Text="GET" />
                
            </td>
        </tr>
        
    </div>
    </form>
</body>
</html>
