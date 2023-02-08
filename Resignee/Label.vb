Imports MySql.Data.MySqlClient
Module Module1
    Dim dbs As New db
    Dim reader As MySqlDataReader
    Dim cmd As New MySqlCommand
    Dim x As Integer
    Public Sub DataLabel(ByRef lbl As Label, ByVal sql As String)
        Try
            cmd.Connection = dbs.getconn
            dbs.opencon()
            cmd.CommandText = sql
            reader = cmd.ExecuteReader

            While reader.Read
                For x = 0 To reader.FieldCount - 1
                    If reader.IsDBNull(x) Then
                        lbl.Text = "Pending"
                    Else
                        lbl.Text = reader.GetValue(x).ToString
                    End If
                Next x
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try

        dbs.closecon()
    End Sub
    Public Sub DateLabel(ByRef lbl As Label, ByVal sql As String)
        Try
            cmd.Connection = dbs.getconn
            dbs.opencon()
            cmd.CommandText = sql
            reader = cmd.ExecuteReader

            While reader.Read
                For x = 0 To reader.FieldCount - 1
                    If reader.IsDBNull(x) Then
                        lbl.Text = "Waiting"
                    Else
                        lbl.Text = DateTime.Parse(reader.GetValue(x).ToString()).ToString("MMM-dd-yyyy")
                    End If
                Next x
            End While
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "error")
        End Try

        dbs.closecon()
    End Sub
End Module
