<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddProduct.aspx.vb" Inherits="Group_Project.AddProduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lbladmin" runat="server" Text="Only Admins may view this site" 
        Visible="False" BorderStyle="Dotted" ForeColor="Red"></asp:Label>
    <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
   
    <div style="margin-left: 40px">
        <asp:Label ID="Label1" runat="server" Text="ProductID"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;<asp:TextBox ID="txtID" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="ProductName"></asp:Label>
&nbsp;<asp:TextBox ID="txtPname" runat="server"></asp:TextBox>
        <br />
        <br />    
        <asp:Label ID="Label3" runat="server" Text="Stock"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtStock" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Price"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="Description"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="66px" 
            Width="249px" ></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Video"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtVideo" runat="server"></asp:TextBox>
    <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Picture"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txtPicture" runat="server"></asp:TextBox>
    
    </div>

    <table border="1">
        <tr>
            <td align="right">
                <asp:Label ID="Label7" runat="server" Text="Add Item to the database"></asp:Label>
            </td>
            <td>
                <asp:Button ID="cmdAdd" runat="server" Text="Add Product" Width="112px" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label8" runat="server" Text="Update an Item with specified ID"></asp:Label>
            </td>
            <td>
                <asp:Button ID="cmdFind" runat="server" Text="Update" Width="112px"/>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label9" runat="server" Text="Delete Item of specified ID"></asp:Label>
            </td>
            <td>
                <asp:Button ID="cmdKill" runat="server" Text="Delete" Width="112px"/>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
