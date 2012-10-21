<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddtoCart.aspx.vb" Inherits="Group_Project.AddtoCart" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:Label ID="lblfail" runat="server" Text="Invalid product ID" 
        ForeColor="Red" BorderStyle="Dotted" Visible="False"></asp:Label>
    <div id="cart" runat="server">
    <table border="1">
        <tr>
        <td align="center" class="style1"><div id="namediv" runat="server">Product Name Here </div></td>
        <td class="style1"><div id="imagediv" runat="server">Product Image goes here</div></td>
        <td class="style1"><div id="pricediv" runat="server">Product Price Goes here</div></td>
        <td class="style1"><div id="taxdiv" runat="server">Product Tax Goes here</div></td>
        <td class="style1"><div id="stockdiv" runat="server">Availeble Stock Goes Here</div></td>
        </tr>
        
        <tr>
        <td width="250">
            <asp:Label ID="lblAdd" runat="server" Text="Stock/Success" 
                Visible="False" BorderStyle="Dotted"></asp:Label></td>
        <td></td>
        <td width="150">
            <asp:Label ID="lblAmount" runat="server" Text="Specify The amount you wish to buy"></asp:Label>
            </td>
        <td>
            <asp:TextBox ID="txtNum" runat="server"></asp:TextBox>
            </td>
        <td>
            <asp:Button ID="cmdAdd" runat="server" Text="Add to Cart" />
        </td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>
