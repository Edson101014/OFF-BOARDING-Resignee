Imports MySql.Data.MySqlClient
Imports System.IO
Public Class ApprovalDB
    Dim dbs As New db
    Function getemployee(ByVal command As MySqlCommand) As DataTable

        command.Connection = dbs.getconn()
        Dim adapter As New MySqlDataAdapter(command)
        Dim table As New DataTable()
        adapter.Fill(table)
        Return table
    End Function


    Public Function insertApproval(ByVal eName As String, ByVal eID As String, ByVal dept As String, ByVal ePos As String, ByVal clPurpose As String, ByVal eStatus As String, ByVal last As Date, ByVal stat As String, ByVal admin As String) As Boolean
        Dim command As New MySqlCommand(admin, dbs.getconn())
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = eName
        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = eID
        command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept
        command.Parameters.Add("@pos", MySqlDbType.VarChar).Value = ePos
        command.Parameters.Add("@purpose", MySqlDbType.VarChar).Value = clPurpose
        command.Parameters.Add("@status", MySqlDbType.VarChar).Value = eStatus
        command.Parameters.Add("@lastday", MySqlDbType.Date).Value = last
        command.Parameters.Add("@stats", MySqlDbType.VarChar).Value = stat

        dbs.opencon()
        If command.ExecuteNonQuery() = 1 Then
            dbs.closecon()
            Return True
        Else
            dbs.closecon()
            Return False
        End If
    End Function
    Public Function insertHistory(ByVal eName As String, ByVal eID As String, ByVal dept As String, ByVal ePos As String, ByVal clPurpose As String, ByVal eStatus As String, ByVal last As Date) As Boolean
        Dim command As New MySqlCommand("INSERT INTO `historyrequest`(`Name`, `empID`, `dept`, `position`, `clearPurpose`, `employeeStatus`, `LastDayEmploy`) VALUES (@name, @id, @dept, @pos, @purpose, @status, @lastday)", dbs.getconn())
        command.Parameters.Add("@name", MySqlDbType.VarChar).Value = eName
        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = eID
        command.Parameters.Add("@dept", MySqlDbType.VarChar).Value = dept
        command.Parameters.Add("@pos", MySqlDbType.VarChar).Value = ePos
        command.Parameters.Add("@purpose", MySqlDbType.VarChar).Value = clPurpose
        command.Parameters.Add("@status", MySqlDbType.VarChar).Value = eStatus
        command.Parameters.Add("@lastday", MySqlDbType.Date).Value = last


        dbs.opencon()
        If command.ExecuteNonQuery() = 1 Then
            dbs.closecon()
            Return True
        Else
            dbs.closecon()
            Return False
        End If
    End Function
    Public Function insertUser(ByVal eID As String, ByVal pass As String) As Boolean
        Dim command As New MySqlCommand("INSERT INTO `userlogin`(`empID`, `pass`) VALUES (@id, @pass)", dbs.getconn())
        command.Parameters.Add("@id", MySqlDbType.VarChar).Value = eID
        command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = pass


        dbs.opencon()
        If command.ExecuteNonQuery() = 1 Then
            dbs.closecon()
            Return True
        Else
            dbs.closecon()
            Return False
        End If
    End Function
End Class
