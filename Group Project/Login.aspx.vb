Imports System.Security.Cryptography
Imports System.Data.SqlClient

Public Class Login1
    Inherits System.Web.UI.Page
    Private connect As SqlConnection
    Private sql As String
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Private constring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Products.mdf;Integrated Security=True;User Instance=True"

    Private Function GenerateHash(ByVal SourceText As String) As String
        Dim UniEnc As New UnicodeEncoding()
        Dim ByteSourceText() As Byte = UniEnc.GetBytes(SourceText)
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        Return Convert.ToBase64String(ByteHash)
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Button1.Click
        sql = "Select * From Users Where UserID ='" & UserName.Text & "';"
        connect = New SqlConnection(constring)
        cmd = New SqlCommand(sql)
        cmd.CommandType = CommandType.Text
        cmd.Connection = connect
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()

        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        If dr.HasRows Then
            dr.Read()
            Dim BoxPassword = GenerateHash(Password.Text)
            If BoxPassword.Equals(dr("Password")) Then
                Session("Logged") = True
                Session("UserID") = UserName
            Else
                Label1.Visible = True
            End If
        Else
            Label1.Visible = True
        End If

    End Sub
End Class