Imports MySql.Data.MySqlClient
Public Class Dashboard
    Dim dbs As New db

    Dim sql As String
    Dim app As New ApprovalDB
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        LabelHRName()
        LabelHRStatus()
        LabelHRComment()
        LabelHRDate()
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LabelHRName()
        LabelHRStatus()
        LabelHRComment()
        LabelHRDate()
    End Sub



    Private Sub Dashboard_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Login.Show()
    End Sub

    Private Sub LabelBDGStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelBDGStatus.Text = "Pending" Then
            LabelBDGStatus.BackColor = Color.PowderBlue
        ElseIf LabelBDGStatus.Text = "Approve" Then
            LabelBDGStatus.BackColor = Color.Lime
        Else
            LabelBDGStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelSDGStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelSDGSuperStatus.Text = "Pending" Then
            LabelSDGSuperStatus.BackColor = Color.PowderBlue
        ElseIf LabelSDGSuperStatus.Text = "Approve" Then
            LabelSDGSuperStatus.BackColor = Color.Lime
        Else
            LabelSDGSuperStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelITOPSStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelITOPSStatus.Text = "Pending" Then
            LabelITOPSStatus.BackColor = Color.PowderBlue
        ElseIf LabelITOPSStatus.Text = "Approve" Then
            LabelITOPSStatus.BackColor = Color.Lime
        Else
            LabelITOPSStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelPMGStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelPMGStatus.Text = "Pending" Then
            LabelPMGStatus.BackColor = Color.PowderBlue
        ElseIf LabelPMGStatus.Text = "Approve" Then
            LabelPMGStatus.BackColor = Color.Lime
        Else
            LabelPMGStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelMarketingStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelMarketingStatus.Text = "Pending" Then
            LabelMarketingStatus.BackColor = Color.PowderBlue
        ElseIf LabelMarketingStatus.Text = "Approve" Then
            LabelMarketingStatus.BackColor = Color.Lime
        Else
            LabelMarketingStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelFinanceStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelFinanceStatus.Text = "Pending" Then
            LabelFinanceStatus.BackColor = Color.PowderBlue
        ElseIf LabelFinanceStatus.Text = "Approve" Then
            LabelFinanceStatus.BackColor = Color.Lime
        Else
            LabelFinanceStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs)

    End Sub

    Private Sub LabelSDGStatus_TextChanged_1(sender As Object, e As EventArgs)
        If LabelSDGStatus.Text = "Pending" Then
            LabelSDGStatus.BackColor = Color.PowderBlue
        ElseIf LabelSDGStatus.Text = "Approve" Then
            LabelSDGStatus.BackColor = Color.Lime
        Else
            LabelSDGStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelFinanceHeadStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelFinanceHeadStatus.Text = "Pending" Then
            LabelFinanceHeadStatus.BackColor = Color.PowderBlue
        ElseIf LabelFinanceHeadStatus.Text = "Approve" Then
            LabelFinanceHeadStatus.BackColor = Color.Lime
        Else
            LabelFinanceHeadStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelAdminStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelAdminStatus.Text = "Pending" Then
            LabelAdminStatus.BackColor = Color.PowderBlue
        ElseIf LabelAdminStatus.Text = "Approve" Then
            LabelAdminStatus.BackColor = Color.Lime
        Else
            LabelAdminStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelAdminHeadStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelAdminHeadStatus.Text = "Pending" Then
            LabelAdminHeadStatus.BackColor = Color.PowderBlue
        ElseIf LabelAdminHeadStatus.Text = "Approve" Then
            LabelAdminHeadStatus.BackColor = Color.Lime
        Else
            LabelAdminHeadStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelSysAdminStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelSysAdminStatus.Text = "Pending" Then
            LabelSysAdminStatus.BackColor = Color.PowderBlue
        ElseIf LabelSysAdminStatus.Text = "Approve" Then
            LabelSysAdminStatus.BackColor = Color.Lime
        Else
            LabelSysAdminStatus.BackColor = Color.Firebrick

        End If
    End Sub


    Private Sub LabelSysAdminHeadStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelSysAdminHeadStatus.Text = "Pending" Then
            LabelSysAdminHeadStatus.BackColor = Color.PowderBlue
        ElseIf LabelSysAdminHeadStatus.Text = "Approve" Then
            LabelSysAdminHeadStatus.BackColor = Color.Lime
        Else
            LabelSysAdminHeadStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelHRGroupTextChanged(sender As Object, e As EventArgs)
        If LabelHRGroupStatus.Text = "Pending" Then
            LabelHRGroupStatus.BackColor = Color.PowderBlue
        ElseIf LabelHRGroupStatus.Text = "Approve" Then
            LabelHRGroupStatus.BackColor = Color.Lime
        Else
            LabelHRGroupStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelHRHeadStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelHRHeadStatus.Text = "Pending" Then
            LabelHRHeadStatus.BackColor = Color.PowderBlue
        ElseIf LabelHRHeadStatus.Text = "Approve" Then
            LabelHRHeadStatus.BackColor = Color.Lime
        Else
            LabelHRHeadStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelHRInterviewStatus_TextChanged(sender As Object, e As EventArgs)
        If LabelHRInterviewStatus.Text = "Pending" Then
            LabelHRInterviewStatus.BackColor = Color.PowderBlue
        ElseIf LabelHRInterviewStatus.Text = "Approve" Then
            LabelHRInterviewStatus.BackColor = Color.Lime
        Else
            LabelHRInterviewStatus.BackColor = Color.Firebrick

        End If
    End Sub

    Private Sub LabelHRGroupStatus_TextChanged(sender As Object, e As EventArgs)

    End Sub
End Class