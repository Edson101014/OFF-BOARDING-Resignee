Imports MySql.Data.MySqlClient
Public Class Dashboard
    Dim dbs As New db
    Dim sql As String
    Dim app As New ApprovalDB
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        getInfo()
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        getInfo()
    End Sub

    Sub getInfo()
        sql = "select name from historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelEmpName, sql)
        sql = "select dept from historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelDept, sql)
        sql = "select clearPurpose from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelPurpose, sql)
        sql = "select empID from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelEmpID, sql)
        sql = "select LastDayEmploy from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel((Me.LabelLastDay), sql)
        sql = "select position from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelPos, sql)
        sql = "select employeestatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelStatus, sql)

        sql = "select BDGDeptStatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelBDGStatus, sql)
        sql = "select SDGDeptStatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelSDGStatus, sql)
        sql = "select ITOPSDeptStatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelITOPSStatus, sql)
        sql = "select PMGDeptStatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelPMGStatus, sql)
        sql = "select MarketingDeptStatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelMarketingStatus, sql)
        sql = "select FinanceDeptStatus from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DataLabel(Me.LabelFinanceStatus, sql)

        sql = "select BDGDeptDate from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel(Me.LabelBDGDate, sql)
        sql = "select SDGDeptDate from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel(Me.LabelSDGDate, sql)
        sql = "select ITOPSDeptDate from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel(Me.LabelITOPSDate, sql)
        sql = "select PMGDeptDate from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel(Me.LabelPMGDate, sql)
        sql = "select MarketingDeptDate from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel(Me.LabelMarketingDate, sql)
        sql = "select FinanceDeptDate from  historyrequest where empID='" & Login.TextBox1.Text & "'"
        DateLabel(Me.LabelFinanceDate, sql)

        Me.Refresh()
    End Sub

    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Show()
    End Sub

    Private Sub LabelBDGStatus_TextChanged(sender As Object, e As EventArgs) Handles LabelBDGStatus.TextChanged
        If LabelBDGStatus.Text = "Pending" Then
            LabelBDGStatus.BackColor = Color.PowderBlue
        ElseIf LabelBDGStatus.Text = "Approve" Then
            LabelBDGStatus.BackColor = Color.Lime
        Else
            LabelBDGStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelSDGStatus_TextChanged(sender As Object, e As EventArgs) Handles LabelSDGStatus.TextChanged
        If LabelSDGStatus.Text = "Pending" Then
            LabelSDGStatus.BackColor = Color.PowderBlue
        ElseIf LabelSDGStatus.Text = "Approve" Then
            LabelSDGStatus.BackColor = Color.Lime
        Else
            LabelSDGStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelITOPSStatus_TextChanged(sender As Object, e As EventArgs) Handles LabelITOPSStatus.TextChanged
        If LabelITOPSStatus.Text = "Pending" Then
            LabelITOPSStatus.BackColor = Color.PowderBlue
        ElseIf LabelITOPSStatus.Text = "Approve" Then
            LabelITOPSStatus.BackColor = Color.Lime
        Else
            LabelITOPSStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelPMGStatus_TextChanged(sender As Object, e As EventArgs) Handles LabelPMGStatus.TextChanged
        If LabelPMGStatus.Text = "Pending" Then
            LabelPMGStatus.BackColor = Color.PowderBlue
        ElseIf LabelPMGStatus.Text = "Approve" Then
            LabelPMGStatus.BackColor = Color.Lime
        Else
            LabelPMGStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelMarketingStatus_TextChanged(sender As Object, e As EventArgs) Handles LabelMarketingStatus.TextChanged
        If LabelMarketingStatus.Text = "Pending" Then
            LabelMarketingStatus.BackColor = Color.PowderBlue
        ElseIf LabelMarketingStatus.Text = "Approve" Then
            LabelMarketingStatus.BackColor = Color.Lime
        Else
            LabelMarketingStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelFinanceStatus_TextChanged(sender As Object, e As EventArgs) Handles LabelFinanceStatus.TextChanged
        If LabelFinanceStatus.Text = "Pending" Then
            LabelFinanceStatus.BackColor = Color.PowderBlue
        ElseIf LabelFinanceStatus.Text = "Approve" Then
            LabelFinanceStatus.BackColor = Color.Lime
        Else
            LabelFinanceStatus.BackColor = Color.Firebrick

        End If
    End Sub
End Class