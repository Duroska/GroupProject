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
        <asp:Label ID="Label7" runat="server" Text="User Title"></asp:Label>
        <asp:DropDownList ID="dlstTitle" runat="server">
            <asp:ListItem>Mr.</asp:ListItem>
            <asp:ListItem Value="Ms.">Ms.</asp:ListItem>
            <asp:ListItem>Msr.</asp:ListItem>
            <asp:ListItem>Dr.</asp:ListItem>
            <asp:ListItem Selected="True">Unknown</asp:ListItem>
        </asp:DropDownList>
        <br/>
        <asp:Label ID="Label1" runat="server" Text="User logon Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="User Password"></asp:Label>
        <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label3" runat="server" Text="First Names"></asp:Label>
        <asp:TextBox ID="txtFname" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label4" runat="server" Text="Last Name"></asp:Label>
        <asp:TextBox ID="txtLname" runat="server"></asp:TextBox>
        <br/>
        <asp:Label ID="Label8" runat="server" Text="User Age"></asp:Label>
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        
        <br/>
        <asp:Label ID="Label5" runat="server" Text="Adress"></asp:Label>
        <asp:TextBox ID="txtAdress" runat="server" Height="55px" TextMode="MultiLine" 
            Width="204px"></asp:TextBox>
        <br/>
        <asp:Button ID="cmdAdd" runat="server" Text="Submit" />
        <br/>
        <asp:Button ID="cmdGet" runat="server" Text="get" />
    
    </div>
    </form>
</body>
</html>
