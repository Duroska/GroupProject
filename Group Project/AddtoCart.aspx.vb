Imports System.Data
Imports System.Data.SqlClient

Public Class AddtoCart
    Inherits System.Web.UI.Page
    Private itemID As String
    Private connect As SqlConnection
    Private sql As String
    Private command As SqlCommand
    Private dr As SqlDataReader
    Private constring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Products.mdf;Integrated Security=True;User Instance=True"
    Private Stock As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        itemID = Request.QueryString("ProductID")
        sql = "select * from Products Where ProductID='" & itemID & "';"
        connect = New SqlConnection(constring)
        command = New SqlCommand(sql)
        command.CommandType = CommandType.Text
        command.Connection = connect
        command.Connection.Open()
        command.ExecuteNonQuery()
        dr = command.ExecuteReader(CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            namediv.InnerHtml = dr("Name")
            setImage(dr("Image"))
            getprice(dr("Price"))
            Stock = CInt(dr("Stock"))
            stockdiv.InnerHtml = Stock
            If Stock = 0 Then
                stockdiv.InnerHtml &= " Currently out of stock"
            End If
        Else
            lblfail.Visible = True
            cmdAdd.Enabled = False
            txtNum.Enabled = False
        End If
        dr.Close()
        command.Connection.Dispose()
        command.Dispose()

    End Sub

    Private Sub getprice(ByRef p As String)
        Dim price As Double = CDbl(p)
        Dim tax As Double = price * 0.14
        pricediv.InnerHtml = "R" & price & " inc VAT"
        taxdiv.InnerHtml = "R" & tax
    End Sub

    Private Sub setImage(ByRef i As String)
        Dim idir As String = ".\Images\" & i
        imagediv.InnerHtml = "<img src='" & idir & "' width=300 hight=300>Immage</img>"
    End Sub

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        Dim requestedstock As Integer = CInt(txtNum.Text)
        If requestedstock <= 0 Then
            lblAmount.Text = "Invalid Stock Amount Specified: incorrect value in text box"
            lblAmount.ForeColor = Drawing.Color.Red
            lblAmount.Visible = True
            Return
        ElseIf requestedstock > Stock Then
            lblAmount.Text = "Invalid Stock Amount Specified: you may not order more items then there is stock"
            lblAmount.ForeColor = Drawing.Color.Red
            lblAmount.Visible = True
            Return
        End If

        'we now know we can continue with transaction
        'for now we asume that the Transactios table is in the same database
        Dim username As String = Session("UserID")
        sql = "Insert Into Transactions Values ('" & username & "', '" & itemID & "', " & requestedstock & ");"
        connect = New SqlConnection(constring)
        command = New SqlCommand(sql)
        command.CommandType = CommandType.Text
        command.Connection = connect
        command.Connection.Open()
        command.ExecuteNonQuery()
        Stock = Stock - requestedstock
        stockdiv.InnerHtml = Stock
        sql = "Update Products Set Stock=" & Stock & " Where ProductID='" & itemID & "';"
        command.CommandText = sql
        command.ExecuteNonQuery()

        lblAmount.Text = "Product Added successfully"
        lblAmount.ForeColor = Drawing.Color.Green
        lblAmount.Visible = True

        command.Connection.Close()
        command.Connection.Dispose()
        command.Dispose()

    End Sub
End Class