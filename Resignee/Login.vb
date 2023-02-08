Imports MySql.Data.MySqlClient
Public Class Login
    Private count = 0
    Dim app As New ApprovalDB
    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StartUp.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim query As String
        query = "select *from userlogin where empID='" & TextBox1.Text & "' and pass='" & TextBox2.Text & "'"
        Dim dbs As New db
        Dim adapter As New MySqlDataAdapter
        Dim table As New DataTable
        Dim command As New MySqlCommand(query, dbs.getconn)
        adapter.SelectCommand = command
        adapter.Fill(table)

        If table.Rows.Count > 0 Then
            Me.Hide()
            Dashboard.Show()
            TextBox1.Clear()
            TextBox2.Clear()
        Else
            count = count + 1
            If count < 3 Then
                MsgBox("USERNAME OR PASSWORD INCORRECT", MsgBoxStyle.Critical, "Login Error")
            End If
            If count = 3 Then
                MsgBox("You exceed try again, app is now close", MsgBoxStyle.Critical)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then 'Chr(13) is the Enter Key
            'Runs the Button1_Click Event
            Button1_Click(Me, EventArgs.Empty)
        End If
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class