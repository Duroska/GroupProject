Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("logged") Is Nothing Then
            NavigationMenu.Items.Item(2).Text = "logout"
            NavigationMenu.Items.Item(2).NavigateUrl = "logout.aspx"
            If Session("admin") Then
                NavigationMenu.Items.Add(New System.Web.UI.WebControls.MenuItem("Add User", Nothing, Nothing, "AddUser.aspx"))
                NavigationMenu.Items.Add(New System.Web.UI.WebControls.MenuItem("Products Modification", Nothing, Nothing, "AddProduct.aspx"))
            End If
        End If
        
    End Sub

End Class