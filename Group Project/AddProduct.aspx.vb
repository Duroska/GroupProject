
Public Class AddProduct
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("admin") Then
            cmdAdd.Enabled = False
            cmdFind.Enabled = False
            cmdKill.Enabled = False
            lbladmin.Visible = True
        End If
    End Sub

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        Dim sql As String = "INSERT INTO Products (ProductID, Product_Name, Stock, Price, Description, Video, Picture)  VALUES ('" & txtID.Text & "','" & txtPname.Text & "', " & CInt(txtStock.Text) & ", " & CDbl(txtPrice.Text) & ", '" & txtDesc.Text & "', '" & txtVideo.Text & "','" & txtPicture.Text & "')"
        Dim con = New ConnectionDB
        con.openconnection()
        con.writedata(sql)
        con.closeconnection()

        MsgBox("A new product has been added to the database")

        txtID.Text = ""
        txtPname.Text = ""
        txtStock.Text = ""
        txtPrice.Text = ""
        txtVideo.Text = ""
        txtPicture.Text = ""
        txtDesc.Text = ""
        Dim R As New Register
        'R.Show()
        'Me.Hide()

    End Sub

    Protected Sub cmdFind_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdFind.Click
        Dim sql As String = "UPDATE Products SET Name = '" & txtPname.Text & "',Stock=" & CInt(txtStock.Text) & ",Price=" & CDbl(txtPrice.Text) & ",IDNumber='" & txtID.Text & "',Video='" & txtVideo.Text & "', Description='" & txtDesc.Text & "', Picture='" & txtPicture.Text & "'  Where ProductID ='" & txtID.Text & "'"
        Dim con = New ConnectionDB
        con.openconnection()
        con.writedata(sql)
        con.closeconnection()

        MsgBox("information updated and save to the database")

    End Sub

    Protected Sub cmdKill_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdKill.Click
        If txtID.Text = "" Then
            MsgBox("no record deleted, please input the correct details")
            Exit Sub
        End If

        If MsgBox("Are you sure you want to delete ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim sql As String = " DELETE FROM Customers WHERE (ProductID='" & txtID.Text & "')"
            Dim con = New ConnectionDB
            con.openconnection()
            con.writedata(sql)
            con.closeconnection()
            MsgBox("Product:'" & txtID.Text & "' Is deleted permanently", MsgBoxStyle.OkCancel)

        Else
            MsgBox("Record not deleted")

        End If

    End Sub
End Class