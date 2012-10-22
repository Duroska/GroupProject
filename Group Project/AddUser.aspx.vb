Imports System.Data.SqlClient
Imports System.Security.Cryptography

Public Class AddUser
    Inherits System.Web.UI.Page
    Private constring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Electronics.mdf;Integrated Security=True;User Instance=True"
    Private sql As String
    Private connect As SqlConnection
    Private cmd As SqlCommand
    Private dr As SqlDataReader


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        lblGet.Visible = False
        If checkifthere(txtName.Text) Then

            sql = "INSERT INTO Users VALUES ('" & txtID.Text & "', '" & dlstTitle.SelectedValue & "'" _
                & ", '" & txtName.Text & "', '" & GenerateHash(txtPass.Text) & "', '" & txtFname.Text & "'" _
                & ", '" & txtLname.Text & "', " & txtAge.Text & ", '" & txtAdress.Text & "', " & chkadmin.Checked & ");"


            connect = New SqlConnection(constring)
            cmd = New SqlCommand(sql)
            cmd.CommandType = CommandType.Text
            cmd.Connection = connect
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()

            cmd.Connection.Close()
            cmd.Connection.Dispose()
            cmd.Dispose()

            lblreg.Text = "User Added to the database"
            lblreg.ForeColor = Drawing.Color.Green
            lblreg.Visible = True

        ElseIf checkifIDthere(txtID.Text) Then
            lblreg.Text = "User ID Already in database"
            lblreg.ForeColor = Drawing.Color.Red
            lblreg.Visible = True

        Else
            lblreg.Text = "User login Name Already in database"
            lblreg.ForeColor = Drawing.Color.Red
            lblreg.Visible = True
        End If


    End Sub


    Private Sub getData()
        lblreg.Visible = False
        sql = "Select * From Users Where UserID ='" & txtID.Text & "';"
        connect = New SqlConnection(constring)
        cmd = New SqlCommand(sql)
        cmd.CommandType = CommandType.Text
        cmd.Connection = connect
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()


        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
        If dr.HasRows Then
            dr.Read()

            txtName.Text = dr("UsrLogin")
            txtAdress.Text = dr("Adress")
            txtAge.Text = dr("Age")
            txtFname.Text = dr("Fname")
            txtLname.Text = dr("Lname")
            txtPass.Text = dr("Pass")
            dlstTitle.SelectedValue = dr("Title")
        Else
            lblGet.Text = "I can't find a user with that ID"
        End If

        dr.Close()
        cmd.Connection.Dispose()
        cmd.Dispose()


    End Sub

    Protected Sub cmdGet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGet.Click
        getData()
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

    Private Function checkifIDthere(ByVal user As String) As Boolean
        sql = "Select * From Users Where UserID = '" & user & "';"
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

End Class