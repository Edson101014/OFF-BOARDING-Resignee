Imports MySql.Data.MySqlClient
Module Module1
    Dim dbs As New db
    Dim reader As MySqlDataReader
    Dim cmd As New MySqlCommand
    Dim x As Integer

    Public Sub LabelHRName()
        Dim sql As String = "SELECT BDGDeptName, SDGSuperName, SDGDeptName, ITOPSDeptName, PMGDeptName, MarketingDeptName, FinanceHeadName, FinanceDeptName, AdminGroupName, AdminHeadName, SysAdminName, SysAdminHeadName, HRHeadName, HRGroupName, ScheduleInterviewerName FROM historyrequest WHERE empID='" & Dashboard.LabelEmpID.Text & "'"

        Dim cmd As New MySqlCommand(sql, dbs.getconn())
        dbs.opencon()
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dashboard.LabelBDGName.Text = If(String.IsNullOrEmpty(reader("BDGDeptName").ToString()), "Pending", reader("BDGDeptName").ToString())
            Dashboard.LabelSDGSuperName.Text = If(String.IsNullOrEmpty(reader("SDGSuperName").ToString()), "Pending", reader("SDGSuperName").ToString())
            Dashboard.LabelSDGName.Text = If(String.IsNullOrEmpty(reader("SDGDeptName").ToString()), "Pending", reader("SDGDeptName").ToString())
            Dashboard.LabelITOPSName.Text = If(String.IsNullOrEmpty(reader("ITOPSDeptName").ToString()), "Pending", reader("ITOPSDeptName").ToString())
            Dashboard.LabelPMGName.Text = If(String.IsNullOrEmpty(reader("PMGDeptName").ToString()), "Pending", reader("PMGDeptName").ToString())
            Dashboard.LabelMarketingName.Text = If(String.IsNullOrEmpty(reader("MarketingDeptName").ToString()), "Pending", reader("MarketingDeptName").ToString())
            Dashboard.LabelFinanceHeadName.Text = If(String.IsNullOrEmpty(reader("FinanceHeadName").ToString()), "Pending", reader("FinanceHeadName").ToString())
            Dashboard.LabelFinanceName.Text = If(String.IsNullOrEmpty(reader("FinanceDeptName").ToString()), "Pending", reader("FinanceDeptName").ToString())
            Dashboard.LabelAdminName.Text = If(String.IsNullOrEmpty(reader("AdminGroupName").ToString()), "Pending", reader("AdminGroupName").ToString())
            Dashboard.LabelAdminHeadName.Text = If(String.IsNullOrEmpty(reader("AdminHeadName").ToString()), "Pending", reader("AdminHeadName").ToString())
            Dashboard.LabelSysAdminName.Text = If(String.IsNullOrEmpty(reader("SysAdminName").ToString()), "Pending", reader("SysAdminName").ToString())
            Dashboard.LabelSysAdminHeadName.Text = If(String.IsNullOrEmpty(reader("SysAdminHeadName").ToString()), "Pending", reader("SysAdminHeadName").ToString())
            Dashboard.LabelHRGroupName.Text = If(String.IsNullOrEmpty(reader("HRGroupName").ToString()), "Pending", reader("HRGroupName").ToString())
            Dashboard.LabelHRHeadName.Text = If(String.IsNullOrEmpty(reader("HRHeadName").ToString()), "Pending", reader("HRHeadName").ToString())
            Dashboard.LabelHRInterviewName.Text = If(String.IsNullOrEmpty(reader("ScheduleInterviewerName").ToString()), "Pending", reader("ScheduleInterviewerName").ToString())

        End While

        reader.Close()
        dbs.closecon()


    End Sub

    Public Sub LabelHRStatus()
        Dim sql As String = "SELECT BDGDeptStatus, SDGSuperStatus, SDGDeptStatus, ITOPSDeptStatus, PMGDeptStatus, MarketingDeptStatus, FinanceHeadStatus, FinanceDeptStatus, AdminGroupStatus, AdminHeadStatus, SysAdminStatus, SysAdminHeadStatus, HRHeadStatus, HRGroupStatus, ScheduleInterviewerStatus FROM historyrequest WHERE empID='" & Dashboard.LabelEmpID.Text & "'"

        Dim cmd As New MySqlCommand(sql, dbs.getconn())
        dbs.opencon()
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dashboard.LabelBDGStatus.Text = If(String.IsNullOrEmpty(reader("BDGDeptStatus").ToString()), "Pending", reader("BDGDeptStatus").ToString())
            Dashboard.LabelSDGSuperStatus.Text = If(String.IsNullOrEmpty(reader("SDGSuperStatus").ToString()), "Pending", reader("SDGSuperStatus").ToString())
            Dashboard.LabelSDGStatus.Text = If(String.IsNullOrEmpty(reader("SDGDeptStatus").ToString()), "Pending", reader("SDGDeptStatus").ToString())
            Dashboard.LabelITOPSStatus.Text = If(String.IsNullOrEmpty(reader("ITOPSDeptStatus").ToString()), "Pending", reader("ITOPSDeptStatus").ToString())
            Dashboard.LabelPMGStatus.Text = If(String.IsNullOrEmpty(reader("PMGDeptStatus").ToString()), "Pending", reader("PMGDeptStatus").ToString())
            Dashboard.LabelMarketingStatus.Text = If(String.IsNullOrEmpty(reader("MarketingDeptStatus").ToString()), "Pending", reader("MarketingDeptStatus").ToString())
            Dashboard.LabelFinanceHeadStatus.Text = If(String.IsNullOrEmpty(reader("FinanceHeadStatus").ToString()), "Pending", reader("FinanceHeadStatus").ToString())
            Dashboard.LabelFinanceStatus.Text = If(String.IsNullOrEmpty(reader("FinanceDeptStatus").ToString()), "Pending", reader("FinanceDeptStatus").ToString())
            Dashboard.LabelAdminStatus.Text = If(String.IsNullOrEmpty(reader("AdminGroupStatus").ToString()), "Pending", reader("AdminGroupStatus").ToString())
            Dashboard.LabelAdminHeadStatus.Text = If(String.IsNullOrEmpty(reader("AdminHeadStatus").ToString()), "Pending", reader("AdminHeadStatus").ToString())
            Dashboard.LabelSysAdminStatus.Text = If(String.IsNullOrEmpty(reader("SysAdminStatus").ToString()), "Pending", reader("SysAdminStatus").ToString())
            Dashboard.LabelSysAdminHeadStatus.Text = If(String.IsNullOrEmpty(reader("SysAdminHeadStatus").ToString()), "Pending", reader("SysAdminHeadStatus").ToString())
            Dashboard.LabelHRGroupStatus.Text = If(String.IsNullOrEmpty(reader("HRGroupStatus").ToString()), "Pending", reader("HRGroupStatus").ToString())
            Dashboard.LabelHRHeadStatus.Text = If(String.IsNullOrEmpty(reader("HRHeadStatus").ToString()), "Pending", reader("HRHeadStatus").ToString())
            Dashboard.LabelHRInterviewStatus.Text = If(String.IsNullOrEmpty(reader("ScheduleInterviewerStatus").ToString()), "Pending", reader("ScheduleInterviewerStatus").ToString())

        End While

        reader.Close()
        dbs.closecon()


    End Sub

    Public Sub LabelHRComment()
        Dim sql As String = "SELECT BDGDeptComment, SDGSuperComment, SDGDeptComment, ITOPSDeptComment, PMGDeptComment, MarketingDeptComment, FinanceHeadComment, FinanceDeptComment, AdminGroupComment, AdminHeadComment, SysAdminComment, SysAdminHeadComment, HRHeadStatus, HRGroupStatus, ScheduleInterviewerStatus FROM historyrequest WHERE empID='" & Dashboard.LabelEmpID.Text & "'"

        Dim cmd As New MySqlCommand(sql, dbs.getconn())
        dbs.opencon()
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dashboard.LabelBDGComment.Text = If(String.IsNullOrEmpty(reader("BDGDeptComment").ToString()), "Pending", reader("BDGDeptComment").ToString())
            Dashboard.LabelSDGSuperComment.Text = If(String.IsNullOrEmpty(reader("SDGSuperComment").ToString()), "Pending", reader("SDGSuperComment").ToString())
            Dashboard.LabelSDGComment.Text = If(String.IsNullOrEmpty(reader("SDGDeptComment").ToString()), "Pending", reader("SDGDeptComment").ToString())
            Dashboard.LabelITOPSComment.Text = If(String.IsNullOrEmpty(reader("ITOPSDeptComment").ToString()), "Pending", reader("ITOPSDeptComment").ToString())
            Dashboard.LabelPMGComment.Text = If(String.IsNullOrEmpty(reader("PMGDeptComment").ToString()), "Pending", reader("PMGDeptComment").ToString())
            Dashboard.LabelMarketingComment.Text = If(String.IsNullOrEmpty(reader("MarketingDeptComment").ToString()), "Pending", reader("MarketingDeptComment").ToString())
            Dashboard.LabelFinanceHeadComment.Text = If(String.IsNullOrEmpty(reader("FinanceHeadComment").ToString()), "Pending", reader("FinanceHeadComment").ToString())
            Dashboard.LabelFinanceComment.Text = If(String.IsNullOrEmpty(reader("FinanceDeptComment").ToString()), "Pending", reader("FinanceDeptComment").ToString())
            Dashboard.LabelAdminComment.Text = If(String.IsNullOrEmpty(reader("AdminGroupComment").ToString()), "Pending", reader("AdminGroupComment").ToString())
            Dashboard.LabelAdminHeadComment.Text = If(String.IsNullOrEmpty(reader("AdminHeadComment").ToString()), "Pending", reader("AdminHeadComment").ToString())
            Dashboard.LabelSysAdminComment.Text = If(String.IsNullOrEmpty(reader("SysAdminComment").ToString()), "Pending", reader("SysAdminComment").ToString())
            Dashboard.LabelSysAdminHeadComment.Text = If(String.IsNullOrEmpty(reader("SysAdminHeadComment").ToString()), "Pending", reader("SysAdminHeadComment").ToString())
            Dashboard.LabelHRGroupComment.Text = If(String.IsNullOrEmpty(reader("HRGroupComment").ToString()), "Pending", reader("HRGroupComment").ToString())
            Dashboard.LabelHRHeadComment.Text = If(String.IsNullOrEmpty(reader("HRHeadComment").ToString()), "Pending", reader("HRHeadComment").ToString())
            Dashboard.LabelHRInterviewComment.Text = If(String.IsNullOrEmpty(reader("ScheduleInterviewerComment").ToString()), "Pending", reader("ScheduleInterviewerComment").ToString())

        End While

        reader.Close()
        dbs.closecon()



    End Sub



    Public Sub LabelHRDate()
        Dim sql As String = "SELECT BDGDeptDate, SDGSuperDate, SDGDeptDate, ITOPSDeptDate, PMGDeptDate, MarketingDeptDate, FinanceHeadDate, FinanceDeptDate, AdminGroupDate, AdminHeadDate, SysAdminDate, SysAdminHeadDate, HRHeadDate, HRGroupDate, ScheduleInterviewerDate FROM historyrequest WHERE empID='" & Dashboard.LabelEmpID.Text & "'"

        Dim cmd As New MySqlCommand(sql, dbs.getconn())
        dbs.opencon()
        Dim reader As MySqlDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dashboard.LabelBDGDate.Text = If(String.IsNullOrEmpty(reader("BDGDeptDate").ToString()), "Pending", DateTime.Parse(reader("BDGDeptDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelSDGSuperDate.Text = If(String.IsNullOrEmpty(reader("SDGSuperDate").ToString()), "Pending", DateTime.Parse(reader("SDGSuperDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelSDGDate.Text = If(String.IsNullOrEmpty(reader("SDGDeptDate").ToString()), "Pending", DateTime.Parse(reader("SDGDeptDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelITOPSDate.Text = If(String.IsNullOrEmpty(reader("ITOPSDeptDate").ToString()), "Pending", DateTime.Parse(reader("ITOPSDeptDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelPMGDate.Text = If(String.IsNullOrEmpty(reader("PMGDeptDate").ToString()), "Pending", DateTime.Parse(reader("PMGDeptDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelMarketingDate.Text = If(String.IsNullOrEmpty(reader("MarketingDeptDate").ToString()), "Pending", DateTime.Parse(reader("MarketingDeptDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelFinanceHeadDate.Text = If(String.IsNullOrEmpty(reader("FinanceHeadDate").ToString()), "Pending", DateTime.Parse(reader("FinanceHeadDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelFinanceDate.Text = If(String.IsNullOrEmpty(reader("FinanceDeptDate").ToString()), "Pending", DateTime.Parse(reader("FinanceDeptDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelAdminDate.Text = If(String.IsNullOrEmpty(reader("AdminGroupDate").ToString()), "Pending", DateTime.Parse(reader("AdminGroupDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelAdminHeadDate.Text = If(String.IsNullOrEmpty(reader("AdminHeadDate").ToString()), "Pending", DateTime.Parse(reader("AdminHeadDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelSysAdminDate.Text = If(String.IsNullOrEmpty(reader("SysAdminDate").ToString()), "Pending", DateTime.Parse(reader("SysAdminDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelSysAdminHeadDate.Text = If(String.IsNullOrEmpty(reader("SysAdminHeadDate").ToString()), "Pending", DateTime.Parse(reader("SysAdminHeadDate").ToString()).ToString("MMM-dd-yyyy"))
            Dashboard.LabelHRGroupDate.Text = If(String.IsNullOrEmpty(reader("HRGroupDate").ToString()), "Pending", reader("HRGroupDate").ToString())
            Dashboard.LabelHRHeadDate.Text = If(String.IsNullOrEmpty(reader("HRHeadDate").ToString()), "Pending", reader("HRHeadDate").ToString())
            Dashboard.LabelHRInterviewDate.Text = If(String.IsNullOrEmpty(reader("ScheduleInterviewerDate").ToString()), "Pending", reader("ScheduleInterviewerDate").ToString())

        End While

        reader.Close()
        dbs.closecon()
    End Sub





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
