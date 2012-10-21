Imports System.Data.SqlClient
'the above import MUST be done to get all the functions needed

Public Class AddUser
    Inherits System.Web.UI.Page
    ' Here we see all the object declared to gain acess to the database

    'This first line is WHERE the database is.  take note of DataDirectory.  that specifies the directory
    'It's curently set to root.  just copy past it
    Private constring As String = "Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|Electronics.mdf;Integrated Security=True;User Instance=True"

    'This string variable will be used to store the SQL command instruction
    Private sql As String

    'this variable will connect to the database itself.  opening a "tunnel" to it
    Private connect As SqlConnection

    'This variable will handle the commands passed to the database
    Private cmd As SqlCommand

    'Datareader is the Object that will read and store ALL information returend from
    'the database after a query was excecuted.  It will be blank if no data returns
    Private dr As SqlDataReader


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub cmdAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdAdd.Click
        'we first contruct the Strign variable with the SQL command, normal SQL laws apply, including order
        sql = "INSERT INTO Users VALUES ('" & txtID.Text & "', '" & dlstTitle.SelectedValue & "'" _
            & ", '" & txtName.Text & "', '" & txtPass.Text & "', '" & txtFname.Text & "'" _
            & ", '" & txtLname.Text & "', " & txtAge.Text & ", '" & txtAdress.Text & "');"

        'Now we connect to the database, post the query to the database and execute it. 
        'Then we close and kill the connection

        connect = New SqlConnection(constring)      'we create the "tunnel"
        cmd = New SqlCommand(sql)                   'we create the query
        cmd.CommandType = CommandType.Text          'this needs to be done because Microsoft is full of s@#$
        cmd.Connection = connect                    'an SQL command can store the conection
        cmd.Connection.Open()                       'we open the connection. the database has now been connected
        cmd.ExecuteNonQuery()                       'we execute the quary.  make sure its "Non" query

        cmd.Connection.Close()                      'close the connection and release the database file
        cmd.Connection.Dispose()                    'clear the resources used.  ONLY do this when you are finished with the database
        cmd.Dispose()                               'clear resources


        'No data is read back, since the connection just simply posts data.
        'The system will crash if there was a problem
        'there is no need to for code against that, we can later just add validation of Data on THIS end 
        'before posting data to the database
    End Sub


    'this will demonstrate reading data from the database
    Private Sub getData()
        'same procedure as last (roughly)
        sql = "Select * From Users Where UserID ='" & txtID.Text & "';"
        connect = New SqlConnection(constring)
        cmd = New SqlCommand(sql)
        cmd.CommandType = CommandType.Text
        cmd.Connection = connect
        cmd.Connection.Open()
        cmd.ExecuteNonQuery()

        'The Execute reader returns a DataReader object. this is but 1 of a few methods of doing it
        'commandBehavior just tells it to kill itself when DataReader is finished
        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        'Now we check to see if something came back
        'true if something came back. false if there is lituratly nothing that came back
        'false will happen when posting data, regardless of success, and if the rows weren't found
        If dr.HasRows Then
            'this must be done. this will kick start the reading process
            'one row at a time will be read from returned data with each .Read()
            dr.Read()

            txtName.Text = dr("UsrLogin")       'we use coloumb names. order does not matter
            txtAdress.Text = dr("Adress")
            txtAge.Text = dr("Age")
            txtFname.Text = dr("Fname")
            txtLname.Text = dr("Lname")
            txtPass.Text = dr("Pass")
            dlstTitle.SelectedValue = dr("Title")

        End If

        dr.Close()      'this will also close the connection, by way of the CommandBehavior we set
        cmd.Connection.Dispose()
        cmd.Dispose()

        'this will never run
        If False Then
            Do While dr.Read()
                'this loop will run as long as there are rows in the DataReader
                'there is no real need to check if there are rows, .Read() has an optional boolean return
                'on each iteration of of the while loop, we move through the rows returned
            Loop
        End If

    End Sub

    Protected Sub cmdGet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdGet.Click
        getData()
    End Sub

    Protected Sub txtAge_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtAge.TextChanged

    End Sub
End Class