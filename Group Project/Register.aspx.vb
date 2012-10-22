Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class Register1
    Inherits System.Web.UI.Page
    Private constring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Electronics.mdf;Integrated Security=True;User Instance=True"
    Private sql As String
    Private connect As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("logged") Then
            Session.Clear()
        End If
    End Sub


    Private Function checkifthere(ByVal user As String) As Boolean
        sql = "Select * From Users Where UsrLogin = '" & user & "';"
        Dim command As SqlCommand = New SqlCommand(sql)
        command.CommandType = CommandType.Text
        command.Connection = New SqlConnection(constring)
        command.Connection.Open()
        command.ExecuteNonQuery()
        Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)

        If reader.HasRows Then
            reader.Close()
            command.Connection.Dispose()
            command.Dispose()
            Return False
        Else
            reader.Close()
            command.Connection.Dispose()
            command.Dispose()
            Return True
        End If

    End Function

    Private Function GenerateHash(ByVal SourceText As String) As String
        Dim UniEnc As New UnicodeEncoding()
        Dim ByteSourceText() As Byte = UniEnc.GetBytes(SourceText)
        Dim Md5 As New MD5CryptoServiceProvider()
        Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
        Return Convert.ToBase64String(ByteHash)
    End Function

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        If checkifthere(txtName.Text) Then

            sql = "INSERT INTO Users VALUES ('" & makeID() & "', '" & dlstTitle.SelectedValue & "'" _
                & ", '" & txtName.Text & "', '" & GenerateHash(txtPass.Text) & "', '" & txtFname.Text & "'" _
                & ", '" & txtLname.Text & "', " & txtAge.Text & ", '" & txtAdress.Text & "', 0);"


            connect = New SqlConnection(constring)
            cmd = New SqlCommand(sql)
            cmd.CommandType = CommandType.Text
            cmd.Connection = connect
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()

            cmd.Connection.Close()
            cmd.Connection.Dispose()
            cmd.Dispose()

            lblreg.Text = "You have been Added to the database!"
            lblreg.ForeColor = Drawing.Color.Green
            lblreg.Visible = True
            cmdAdd.Enabled = False
            lbldone.Text = "<a href='Login.aspx'>Click here to Continue</a>"
            lbldone.Visible = True

        Else
            lblreg.Text = "User login Name Already in database"
            lblreg.ForeColor = Drawing.Color.Red
            lblreg.Visible = True
        End If
    End Sub

    Private Function makeID() As String
        sql = "Select Count(UserID) AS count From Users;"
        Dim command As SqlCommand = New SqlCommand(sql)
        command.CommandType = CommandType.Text
        command.Connection = New SqlConnection(constring)
        command.Connection.Open()
        command.ExecuteNonQuery()
        Dim reader As SqlDataReader = command.ExecuteReader(CommandBehavior.CloseConnection)
        reader.Read()
        Dim back As String = "UR-" & reader("count")
        reader.Close()
        command.Connection.Dispose()
        command.Dispose()
        Return back
    End Function
End Class