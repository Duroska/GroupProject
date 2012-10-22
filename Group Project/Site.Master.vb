Public Class Site
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("logged") Is Nothing Then
            NavigationMenu.Items.Item(1).Text = "logout"
            NavigationMenu.Items.Item(1).NavigateUrl = "logout.aspx"
        End If
        
    End Sub

End Class