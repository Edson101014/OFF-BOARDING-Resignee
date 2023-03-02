Imports System.Net.Mail
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Reflection
Imports MySql.Data.MySqlClient

Public Class Request
    Dim dbs As New db
    Dim reader As MySqlDataReader
    Dim cmd As New MySqlCommand
    Dim x As Integer
    Private Sub Request_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim today As Date = Date.Today.Date
        LabelLastDay.Text = Date.Today.AddDays(30)
        ComboBox1.SelectedItem = "N/A"
        ComboBox2.SelectedItem = "BDG"
    End Sub
    Private Sub Request_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        StartUp.Show()
    End Sub

    Private Sub CheckedListBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListBoxPurpose.MouseClick
        Dim idx, sidx As Integer
        CheckedListBoxPurpose.BackColor = Color.White
        sidx = CheckedListBoxPurpose.SelectedIndex
        For idx = 0 To CheckedListBoxPurpose.Items.Count - 1
            If idx <> sidx Then
                CheckedListBoxPurpose.SetItemChecked(idx, False)
            Else
                CheckedListBoxPurpose.SetItemChecked(sidx, True)
            End If
        Next
    End Sub

    Private Sub CheckedListBox2_MouseClick(sender As Object, e As MouseEventArgs) Handles CheckedListBoxStatus.MouseClick
        Dim idx, sidx As Integer
        CheckedListBoxStatus.BackColor = Color.White
        sidx = CheckedListBoxStatus.SelectedIndex
        For idx = 0 To CheckedListBoxStatus.Items.Count - 1
            If idx <> sidx Then
                CheckedListBoxStatus.SetItemChecked(idx, False)
            Else
                CheckedListBoxStatus.SetItemChecked(sidx, True)
            End If
        Next
    End Sub
    Function verf() As Boolean
        Dim checkpurpose As Integer = 0
        Dim checkstatus As Integer = 0
        Dim checker As Integer = 0

        For i As Integer = 0 To CheckedListBoxPurpose.Items.Count - 1
            If CheckedListBoxPurpose.CheckedItems.Count = 0 Then
                CheckedListBoxPurpose.BackColor = Color.Red
                checkpurpose += 1

            End If
        Next
        For j As Integer = 0 To CheckedListBoxStatus.Items.Count - 1
            If CheckedListBoxStatus.CheckedItems.Count = 0 Then
                CheckedListBoxStatus.BackColor = Color.Red
                checkstatus += 1

            End If
        Next

        If TextBoxName.Text.Trim = "" Then
            TextBoxName.BackColor = Color.Red
            checker += 1
        End If

        If TextBoxName.Text.Trim = "" Then
            TextBoxName.BackColor = Color.Red
            checker += 1
        End If

        If TextBoxPos.Text.Trim = "" Then
            TextBoxPos.BackColor = Color.Red
            checker += 1
        End If

        If TextBoxEmpID.Text.Trim = "" Then
            TextBoxEmpID.BackColor = Color.Red
            checker += 1
        End If

        If TextBoxPassword.Text.Trim = "" Then
            TextBoxPassword.BackColor = Color.Red
            checker += 1
        End If

        If checker > 0 Or checkstatus > 0 Or checkpurpose > 0 Then
            Return False
        Else
            Return True
        End If
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim dbs As New db
        Dim apdb As New ApprovalDB
        Dim empName As String = TextBoxName.Text
        Dim empID As String = TextBoxEmpID.Text
        Dim empPos As String = TextBoxPos.Text
        Dim Dept As String = ComboBox2.SelectedItem
        Dim clear As String = CheckedListBoxPurpose.SelectedItem
        Dim empStatus As String = CheckedListBoxStatus.SelectedItem
        Dim lastDay As String = LabelLastDay.Text
        Dim pass As String = TextBoxPassword.Text
        Dim status As String = "Pending"
        Dim insert As String



        If verf() = True Then
            insert = "INSERT INTO `hrinterview`(`Name`, `empID`, `dept`, `position`, `clearPurpose`, `employeeStatus`, `LastDayEmploy`, `hrStatus`) VALUES (@name, @id, @dept, @pos, @purpose, @status, @lastday, @stats)"

            sentmail()
            apdb.insertApproval(empName, empID, Dept, empPos, clear, empStatus, lastDay, status, insert)
            apdb.insertHistory(empName, empID, Dept, empPos, clear, empStatus, lastDay)
            apdb.insertUser(empID, pass)
            Loading.Hide()
            MsgBox("Request has sent!, You can now login to monitor your request", MsgBoxStyle.Information, "Request")
            Me.Close()
            TextBoxName.Clear()
            TextBoxEmpID.Clear()
            TextBoxPos.Clear()
            ComboBox1.SelectedIndex = -1

            TextBoxEmpID.Clear()
            TextBoxPassword.Clear()


        Else
            MsgBox("Please fill out all the items", MsgBoxStyle.Exclamation, "REQUEST")
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        TextBoxPassword.UseSystemPasswordChar = Not CheckBox1.Checked
    End Sub
    Public Async Sub sentmail()

        Try
            Loading.Show()

            Dim Smtp_Server As New SmtpClient
            Dim e_mail As New MailMessage()
            Dim folderName As String = "Resources"
            Dim fileName As String = "index.html"
            Dim filePath As String = Path.Combine(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), folderName), fileName)

            If File.Exists(filePath) Then
                Dim path As New FileStream(filePath, FileMode.Open)
                Dim str As New StreamReader(path)
                Dim Mailtext As String = str.ReadToEnd
                str.Close()

                Smtp_Server.UseDefaultCredentials = False
                Smtp_Server.Credentials = New Net.NetworkCredential("ojt.systemadmin@findme.com.ph", "kucgpmvpetlhbjzo")
                Smtp_Server.Port = 587
                Smtp_Server.EnableSsl = True
                Smtp_Server.Host = "smtp.gmail.com"

                Dim query As String = "SELECT email FROM login WHERE department = 'HR' AND (title = 'Interview' OR title IS NULL) ORDER BY department ASC"

                cmd.Connection = dbs.getconn
                dbs.opencon()
                cmd.CommandText = query
                reader = cmd.ExecuteReader
                While reader.Read()
                    Dim email As String = reader.GetString("email")

                    Mailtext = Mailtext.Replace("@empname", TextBoxName.Text)
                    Mailtext = Mailtext.Replace("@empID", TextBoxEmpID.Text)
                    Mailtext = Mailtext.Replace("@empPos", TextBoxPos.Text)
                    Mailtext = Mailtext.Replace("@empStatus", CheckedListBoxStatus.SelectedItem)
                    Mailtext = Mailtext.Replace("@clearPurpose", CheckedListBoxPurpose.SelectedItem)
                    Mailtext = Mailtext.Replace("@lastday", LabelLastDay.Text)
                    Mailtext = Mailtext.Replace("@dept", ComboBox2.SelectedItem)

                    e_mail = New MailMessage
                    e_mail.From = New MailAddress("no-reply@gmail.com")
                    e_mail.To.Add(email)

                    e_mail.Subject = "Request Approval Notification"
                    e_mail.IsBodyHtml = True
                    e_mail.Body = Mailtext

                    Await Smtp_Server.SendMailAsync(e_mail)

                End While


            End If

        Catch error_t As Exception
            MsgBox(error_t.ToString)


        End Try

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.SelectedItem = "N/A" Then
            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
        ElseIf ComboBox1.SelectedItem = "BDG" Then

            ComboBox2.Items.Clear()


            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "BDG"
        ElseIf ComboBox1.SelectedItem = "SDG" Then

            ComboBox2.Items.Clear()


            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "SDG"
        ElseIf ComboBox1.SelectedItem = "ITOPS" Then

            ComboBox2.Items.Clear()


            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "ITOPS"

        ElseIf ComboBox1.SelectedItem = "PMG" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "PMG"
        ElseIf ComboBox1.SelectedItem = "Marketing" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "Marketing"
        ElseIf ComboBox1.SelectedItem = "Finance" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "Finance"
        ElseIf ComboBox1.SelectedItem = "Admin" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "Admin"
        ElseIf ComboBox1.SelectedItem = "System Admin" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "System Admin"
        ElseIf ComboBox1.SelectedItem = "HR" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "HR"
        ElseIf ComboBox1.SelectedItem = "COO" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "COO"
        ElseIf ComboBox1.SelectedItem = "CEO" Then

            ComboBox2.Items.Clear()

            ComboBox2.Items.Add("BDG")
            ComboBox2.Items.Add("SDG")
            ComboBox2.Items.Add("ITOPS")
            ComboBox2.Items.Add("PMG")
            ComboBox2.Items.Add("Marketing")
            ComboBox2.Items.Add("Finance")
            ComboBox2.Items.Add("Admin")
            ComboBox2.Items.Add("System Admin")
            ComboBox2.Items.Add("HR")
            ComboBox2.Items.Add("COO")
            ComboBox2.Items.Add("CEO")
            ComboBox2.SelectedItem = "CEO"
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBoxName.Clear()
        TextBoxEmpID.Clear()
        TextBoxPos.Clear()
        ComboBox1.SelectedIndex = -1

        TextBoxEmpID.Clear()
        TextBoxPassword.Clear()
        Me.Close()

    End Sub

    Private Sub TextBoxName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxName.TextChanged
        TextBoxName.BackColor = Color.White
    End Sub

    Private Sub TextBoxPos_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPos.TextChanged
        TextBoxPos.BackColor = Color.White
    End Sub

    Private Sub TextBoxEmpID_TextChanged(sender As Object, e As EventArgs) Handles TextBoxEmpID.TextChanged
        TextBoxEmpID.BackColor = Color.White
    End Sub

    Private Sub TextBoxPassword_TextChanged(sender As Object, e As EventArgs) Handles TextBoxPassword.TextChanged
        TextBoxPassword.BackColor = Color.White
    End Sub

    Private Sub TextBoxName_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBoxName.KeyDown
        Select Case e.KeyValue
            Case Keys.Space
            Case Keys.A To Keys.Z
            Case Keys.Left, Keys.Right, Keys.Back

            Case Else : e.SuppressKeyPress = True


        End Select
    End Sub
End Class
