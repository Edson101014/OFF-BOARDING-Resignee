Imports MySql.Data.MySqlClient
Public Class Login
    Private count = 0
    Dim app As New ApprovalDB
    Dim dbs As New db
    Dim classname As New LABELS
    Private Sub Login_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StartUp.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If My.Computer.Network.IsAvailable Then

            Else
                MessageBox.Show("Internet connection is not available.")
            End If
            Dim query As String
            query = "select * from userlogin where empID=@empID and pass=@pass"

            Dim adapter As New MySqlDataAdapter
            Dim table As New DataTable
            Using connection As MySqlConnection = dbs.getConn()
                Using command As New MySqlCommand(query, connection)
                    command.Parameters.AddWithValue("@empID", TextBox1.Text)
                    command.Parameters.AddWithValue("@pass", TextBox2.Text)
                    adapter.SelectCommand = command
                    adapter.Fill(table)
                    connection.Open()

                    If table.Rows.Count > 0 Then
                        connection.Close()
                        Me.Hide()
                        classname.LabelInfoEmp()
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

                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error checking for internet connection: " & ex.Message)
        Finally

            dbs.returnConnection(dbs.getConn())
        End Try
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