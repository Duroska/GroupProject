<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Register.aspx.vb" Inherits="Group_Project.Register1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div id = "registerpanel" runat = "server">
        <table = cellpadding="3">
        
        <tr>
            <td align=right><b>First name:</b></td>
            <td><asp:DropDownList ID="dlstTitle" runat="server">
            <asp:ListItem>Mr.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem>Msr.</asp:ListItem>
            <asp:ListItem>Dr.</asp:ListItem>
            <asp:ListItem Selected="True">Unknown</asp:ListItem>
            </asp:DropDownList>
                <asp:TextBox ID="txtFname" runat="server" Width="160px"/></td>
            
        </tr>
        
        <tr>
            <td align="right"><b>Last name:</b></td>
            <td><asp:TextBox ID="txtLname" runat="server" Width="160px"/></td>
        </tr>
        
        <tr>
            <td align="right"><b> User Logon name</b> </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" MaxLength="20" 
                    ToolTip="a login name used to log you in"></asp:TextBox>
            </td>
        </tr>
        
         <tr>
            <td align="right"><b>User Password:</b></td>
              
              <asp:Label ID="Label2" runat="server" Text="User Password"></asp:Label>
              <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>

        <tr>
            <td align=right><b>User Age:</b></td>
            <td><b><asp:Label ID="Label8" runat="server" Text="User Age"><b></asp:Label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td align=right><b>Address:</b></td>
            <asp:Label ID="Label5" runat="server" Text="Adress"></asp:Label>
            <td><asp:TextBox ID="txtAdress" runat="server" Width="222px" Height="57px"/><br /></td>
        </tr>
        
        <tr>       
            <td>
                <asp:Button ID="cmdAdd" runat="server" Text="Submit" />
            </td>

            <td>
                <asp:Label ID="lblreg" runat="server" Text="Label" BorderStyle="Dotted" 
                    Visible="False"></asp:Label>
                <asp:Label ID="lbldone" runat="server" Text="Label" Visible="False"><br/></asp:Label>
            </td>
        </tr>

        </table>
    </div>
    </form>
</body>
</html>
