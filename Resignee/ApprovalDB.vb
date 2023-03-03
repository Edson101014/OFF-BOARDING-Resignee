Imports MySql.Data.MySqlClient
Imports System.IO
Public Class ApprovalDB
    Dim dbs As New db
    Function getemployee(ByVal command As MySqlCommand) As DataTable


        Dim resultTable As New DataTable()

        Using conn As MySqlConnection = dbs.getConn()
            command.Connection = conn
            Dim adapter As New MySqlDataAdapter(command)
            adapter.Fill(resultTable)
            dbs.returnConnection(conn)
        End Using

        Return resultTable
    End Function


    Public Function insertApproval(ByVal eName As String, ByVal eID As String, ByVal dept As String, ByVal ePos As String, ByVal clPurpose As String, ByVal eStatus As String, ByVal last As Date, ByVal stat As String, ByVal sql As String) As Boolean
        Dim result As Boolean = False
        Using conn As MySqlConnection = dbs.getConn()
            Dim cmd As New MySqlCommand(sql, conn)
            cmd.Parameters.Add("@name", MySqlDbType.VarChar).Value = eName
            cmd.Parameters.Add("@id", MySqlDbType.VarChar).Value = eID
            cmd.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept
            cmd.Parameters.Add("@pos", MySqlDbType.VarChar).Value = ePos
            cmd.Parameters.Add("@purpose", MySqlDbType.VarChar).Value = clPurpose
            cmd.Parameters.Add("@status", MySqlDbType.VarChar).Value = eStatus
            cmd.Parameters.Add("@lastday", MySqlDbType.Date).Value = last
            cmd.Parameters.Add("@stats", MySqlDbType.VarChar).Value = stat

            conn.Open()
            Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
            If rowsAffected = 1 Then
                result = True
            End If
            conn.Close()
            dbs.returnConnection(conn)
        End Using

        Return result
    End Function
    Public Function insertHistory(ByVal eName As String, ByVal eID As String, ByVal dept As String, ByVal ePos As String, ByVal clPurpose As String, ByVal eStatus As String, ByVal last As Date) As Boolean
        Dim result As Boolean = False
        Using conn As MySqlConnection = dbs.getConn()

            Dim command As New MySqlCommand("INSERT INTO `historyrequest`(`Name`, `empID`, `dept`, `position`, `clearPurpose`, `employeeStatus`, `LastDayEmploy`) VALUES (@name, @id, @dept, @pos, @purpose, @status, @lastday)", conn)


            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = eName
        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = eID
        command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept
        command.Parameters.Add("@pos", MySqlDbType.VarChar).Value = ePos
        command.Parameters.Add("@purpose", MySqlDbType.VarChar).Value = clPurpose
        command.Parameters.Add("@status", MySqlDbType.VarChar).Value = eStatus
        command.Parameters.Add("@lastday", MySqlDbType.Date).Value = last


            conn.Open()
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected = 1 Then
                result = True
            End If
            conn.Close()
            dbs.returnConnection(conn)
        End Using

        Return result
    End Function
    Public Function insertUser(ByVal eID As String, ByVal pass As String) As Boolean
        Dim result As Boolean = False
        Using conn As MySqlConnection = dbs.getConn()
            Dim command As New MySqlCommand("INSERT INTO `userlogin`(`empID`, `pass`) VALUES (@id, @pass)", conn)
            command.Parameters.Add("@id", MySqlDbType.VarChar).Value = eID
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass


            conn.Open()
            Dim rowsAffected As Integer = command.ExecuteNonQuery()
            If rowsAffected = 1 Then
                result = True
            End If
            conn.Close()
            dbs.returnConnection(conn)
        End Using

        Return result
    End Function
End Class
