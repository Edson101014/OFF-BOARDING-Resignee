Imports MySql.Data.MySqlClient
Public Class LABELS
    Dim dbs As New db
    Dim reader As MySqlDataReader
    Dim cmd As New MySqlCommand
    Dim x As Integer

    Public Sub LabelInfoEmp()
        Dim sql As String
        Dim empID As String = Login.TextBox1.Text
        Dim query = "SELECT `empID` FROM `historyrequest` WHERE `empID`='" & empID & "'"
        Using connection As MySqlConnection = dbs.getConn()
            Dim command1 As New MySqlCommand(query, connection)
            connection.Open()

            Dim scalarResult As Object = command1.ExecuteScalar()
            If scalarResult IsNot Nothing Then
                sql = "SELECT Name, empID, dept, position, clearPurpose, employeeStatus, LastDayEmploy FROM historyrequest WHERE empID='" & empID & "'"
            Else
                sql = "SELECT Name, empID, dept, position, clearPurpose, employeeStatus, LastDayEmploy FROM completerequest WHERE empID='" & empID & "'"
            End If

            Using command2 As New MySqlCommand(sql, connection)
                Dim reader As MySqlDataReader = command2.ExecuteReader()

                While reader.Read()
                    Dashboard.LabelEmpName.Text = If(String.IsNullOrEmpty(reader("Name").ToString()), "Pending", reader("Name").ToString())
                    Dashboard.LabelEmpID.Text = If(String.IsNullOrEmpty(reader("empID").ToString()), "Pending", reader("empID").ToString())
                    Dashboard.LabelDept.Text = If(String.IsNullOrEmpty(reader("dept").ToString()), "Pending", reader("dept").ToString())
                    Dashboard.LabelPos.Text = If(String.IsNullOrEmpty(reader("position").ToString()), "Pending", reader("position").ToString())
                    Dashboard.LabelPurpose.Text = If(String.IsNullOrEmpty(reader("clearPurpose").ToString()), "Pending", reader("clearPurpose").ToString())
                    Dashboard.LabelStatus.Text = If(String.IsNullOrEmpty(reader("employeeStatus").ToString()), "Pending", reader("employeeStatus").ToString())
                    Dashboard.LabelLastDay.Text = If(String.IsNullOrEmpty(reader("LastDayEmploy").ToString()), "Pending", DateTime.Parse(reader("LastDayEmploy").ToString()).ToString("MMM-dd-yyyy"))
                End While

                reader.Close()
            End Using
            connection.Close()
            dbs.returnConnection(connection)
        End Using
    End Sub
    Public Sub LabelHRName()
        Dim sql As String
        Dim empID As String = Login.TextBox1.Text
        Dim query = "SELECT `empID` FROM `historyrequest` WHERE `empID`='" & empID & "'"
        Using connection As MySqlConnection = dbs.getConn()
            Dim command1 As New MySqlCommand(query, connection)
            connection.Open()

            Dim scalarResult As Object = command1.ExecuteScalar()
            If scalarResult IsNot Nothing Then

                sql = "SELECT BDGDeptName, SDGSuperName, SDGDeptName, ITOPSDeptName, PMGDeptName, MarketingDeptName, FinanceHeadName, FinanceDeptName, AdminGroupName, AdminHeadName, SysAdminName, SysAdminHeadName, HRHeadName, HRGroupName, ScheduleInterviewerName, ExitInterviewBy FROM historyrequest WHERE empID='" & empID & "'"

            Else
                sql = "SELECT BDGDeptName, SDGSuperName, SDGDeptName, ITOPSDeptName, PMGDeptName, MarketingDeptName, FinanceHeadName, FinanceDeptName, AdminGroupName, AdminHeadName, SysAdminName, SysAdminHeadName, HRHeadName, HRGroupName, ScheduleInterviewerName, ExitInterviewBy FROM completerequest WHERE empID='" & empID & "'"


            End If

            Using command2 As New MySqlCommand(sql, connection)
                Dim reader As MySqlDataReader = command2.ExecuteReader()

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
                    Dashboard.LabelFinalName.Text = If(String.IsNullOrEmpty(reader("ExitInterviewBy").ToString()), "Pending", reader("ExitInterviewBy").ToString())
                End While
                reader.Close()
            End Using
            connection.Close()
            dbs.returnConnection(connection)
        End Using
    End Sub

    Public Sub LabelHRStatus()
        Dim sql As String
        Dim empID As String = Login.TextBox1.Text
        Dim query = "SELECT `empID` FROM `historyrequest` WHERE `empID`='" & empID & "'"
        Using connection As MySqlConnection = dbs.getConn()
            Dim command1 As New MySqlCommand(query, connection)
            connection.Open()

            Dim scalarResult As Object = command1.ExecuteScalar()
            If scalarResult IsNot Nothing Then

                sql = "SELECT BDGDeptStatus, SDGSuperStatus, SDGDeptStatus, ITOPSDeptStatus, PMGDeptStatus, MarketingDeptStatus, FinanceHeadStatus, FinanceDeptStatus, AdminGroupStatus, AdminHeadStatus, SysAdminStatus, SysAdminHeadStatus, HRHeadStatus, HRGroupStatus, ScheduleInterviewStatus, ExitInterviewStatus FROM historyrequest WHERE empID='" & empID & "'"

            Else
                sql = "SELECT BDGDeptStatus, SDGSuperStatus, SDGDeptStatus, ITOPSDeptStatus, PMGDeptStatus, MarketingDeptStatus, FinanceHeadStatus, FinanceDeptStatus, AdminGroupStatus, AdminHeadStatus, SysAdminStatus, SysAdminHeadStatus, HRHeadStatus, HRGroupStatus, ScheduleInterviewStatus, ExitInterviewStatus FROM completerequest WHERE empID='" & empID & "'"


            End If

            Using command2 As New MySqlCommand(sql, connection)
                Dim reader As MySqlDataReader = command2.ExecuteReader()

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
                    Dashboard.LabelHRInterviewStatus.Text = If(String.IsNullOrEmpty(reader("ScheduleInterviewStatus").ToString()), "Pending", reader("ScheduleInterviewStatus").ToString())
                    Dashboard.LabelFinalStatus.Text = If(String.IsNullOrEmpty(reader("ExitInterviewStatus").ToString()), "Pending", reader("ExitInterviewStatus").ToString())

                End While
                reader.Close()
            End Using
            connection.Close()
            dbs.returnConnection(connection)
        End Using


    End Sub

    Public Sub LabelHRComment()
        Dim sql As String
        Dim empID As String = Login.TextBox1.Text
        Dim query = "SELECT `empID` FROM `historyrequest` WHERE `empID`='" & empID & "'"
        Using connection As MySqlConnection = dbs.getConn()
            Dim command1 As New MySqlCommand(query, connection)
            connection.Open()

            Dim scalarResult As Object = command1.ExecuteScalar()
            If scalarResult IsNot Nothing Then

                sql = "SELECT BDGDeptComment, SDGSuperComment, SDGDeptComment, ITOPSDeptComment, PMGDeptComment, MarketingDeptComment, FinanceHeadComment, FinanceDeptComment, AdminGroupComment, AdminHeadComment, SysAdminComment, SysAdminHeadComment, HRHeadComment, HRGroupComment FROM historyrequest WHERE empID='" & empID & "'"

            Else
                sql = "SELECT BDGDeptComment, SDGSuperComment, SDGDeptComment, ITOPSDeptComment, PMGDeptComment, MarketingDeptComment, FinanceHeadComment, FinanceDeptComment, AdminGroupComment, AdminHeadComment, SysAdminComment, SysAdminHeadComment, HRHeadComment, HRGroupComment FROM completerequest WHERE empID='" & empID & "'"


            End If

            Using command2 As New MySqlCommand(sql, connection)
                Dim reader As MySqlDataReader = command2.ExecuteReader()

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



                End While
                reader.Close()
            End Using
            connection.Close()
            dbs.returnConnection(connection)
        End Using




    End Sub

    Public Sub LabelHRDate()
        Dim sql As String
        Dim empID As String = Login.TextBox1.Text
        Dim query = "SELECT `empID` FROM `historyrequest` WHERE `empID`='" & empID & "'"
        Using connection As MySqlConnection = dbs.getConn()
            Dim command1 As New MySqlCommand(query, connection)
            connection.Open()

            Dim scalarResult As Object = command1.ExecuteScalar()
            If scalarResult IsNot Nothing Then

                sql = "SELECT BDGDeptDate, SDGSuperDate, SDGDeptDate, ITOPSDeptDate, PMGDeptDate, MarketingDeptDate, FinanceHeadDate, FinanceDeptDate, AdminGroupDate, AdminHeadDate, SysAdminDate, SysAdminHeadDate, HRHeadDate, HRGroupDate, ScheduleInterviewDate, ExitInterviewDate FROM historyrequest WHERE empID='" & empID & "'"

            Else
                sql = "SELECT BDGDeptDate, SDGSuperDate, SDGDeptDate, ITOPSDeptDate, PMGDeptDate, MarketingDeptDate, FinanceHeadDate, FinanceDeptDate, AdminGroupDate, AdminHeadDate, SysAdminDate, SysAdminHeadDate, HRHeadDate, HRGroupDate, ScheduleInterviewDate, ExitInterviewDate FROM completerequest WHERE empID='" & empID & "'"


            End If


            Using command2 As New MySqlCommand(sql, connection)
                Dim reader As MySqlDataReader = command2.ExecuteReader()

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
                    Dashboard.LabelHRGroupDate.Text = If(String.IsNullOrEmpty(reader("HRGroupDate").ToString()), "Pending", DateTime.Parse(reader("HRGroupDate").ToString()).ToString("MMM-dd-yyyy"))
                    Dashboard.LabelHRHeadDate.Text = If(String.IsNullOrEmpty(reader("HRHeadDate").ToString()), "Pending", DateTime.Parse(reader("HRHeadDate").ToString()).ToString("MMM-dd-yyyy"))
                    Dashboard.LabelHRInterviewDate.Text = If(String.IsNullOrEmpty(reader("ScheduleInterviewDate").ToString()), "Pending", DateTime.Parse(reader("ScheduleInterviewDate").ToString()).ToString("MMM-dd-yyyy"))
                    Dashboard.LabelFinalDate.Text = If(String.IsNullOrEmpty(reader("ExitInterviewDate").ToString()), "Pending", DateTime.Parse(reader("ExitInterviewDate").ToString()).ToString("MMM-dd-yyyy"))


                End While
                reader.Close()
            End Using
            connection.Close()
            dbs.returnConnection(connection)
        End Using
    End Sub

    Public Sub LabelCheckBox()
        Dim sql As String
        Dim empID As String = Login.TextBox1.Text
        Dim query = "SELECT `empID` FROM `historyrequest` WHERE `empID`='" & empID & "'"
        Using connection As MySqlConnection = dbs.getConn()
            Dim command1 As New MySqlCommand(query, connection)
            connection.Open()

            Dim scalarResult As Object = command1.ExecuteScalar()
            If scalarResult IsNot Nothing Then

                sql = "SELECT `CashAdvance`, `FinanceDeptOthers`, `FinanceDeptOtherComment`, `CheckTeleco`, `CheckTools`, `CheckPhone`, `CheckTable`, `CheckOthers`, `CheckOthersComment`, `CheckLaptop`, `CheckEmail`, `CheckCom`, `CheckHMO`, `CheckInsurance`, `CheckCompanyID`, `CheckQuitClaim`, `CheckCOE`, `CheckITR`, `CheckFinalPay`, `ScheduleInterviewStatus`, `ExitInterviewStatus` FROM historyrequest WHERE empID='" & empID & "'"

            Else
                sql = "SELECT `CashAdvance`, `FinanceDeptOthers`, `FinanceDeptOtherComment`, `CheckTeleco`, `CheckTools`, `CheckPhone`, `CheckTable`, `CheckOthers`, `CheckOthersComment`, `CheckLaptop`, `CheckEmail`, `CheckCom`, `CheckHMO`, `CheckInsurance`, `CheckCompanyID`, `CheckQuitClaim`, `CheckCOE`, `CheckITR`, `CheckFinalPay`, `ScheduleInterviewStatus`, `ExitInterviewStatus` FROM completerequest WHERE empID='" & empID & "'"

            End If

            Using command2 As New MySqlCommand(sql, connection)
                Dim reader As MySqlDataReader = command2.ExecuteReader()



                If reader.Read() Then
                    Dim cashAdvanceValue As String = reader("CashAdvance").ToString()
                    If String.Equals(cashAdvanceValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxCashAdv.Checked = True
                    ElseIf String.Equals(cashAdvanceValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxCashAdv.Checked = False
                    End If

                    Dim financeOtherValue As String = reader("FinanceDeptOthers").ToString()
                    If String.Equals(financeOtherValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxFinanceOther.Checked = True
                    ElseIf String.Equals(financeOtherValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxFinanceOther.Checked = False
                    End If

                    Dashboard.TextBoxFinanceOther.Text = reader("FinanceDeptOtherComment").ToString()

                    Dim checkTelecoValue As String = reader("CheckTeleco").ToString()
                    If String.Equals(checkTelecoValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxTelco.Checked = True
                    ElseIf String.Equals(checkTelecoValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxTelco.Checked = False
                    End If

                    Dim checkToolsValue As String = reader("CheckTools").ToString()
                    If String.Equals(checkToolsValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxTools.Checked = True
                    ElseIf String.Equals(checkToolsValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxTools.Checked = False
                    End If

                    Dim checkPhoneValue As String = reader("CheckPhone").ToString()
                    If String.Equals(checkPhoneValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxPhone.Checked = True
                    ElseIf String.Equals(checkPhoneValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxPhone.Checked = False
                    End If

                    Dim checkTableValue As String = reader("CheckTable").ToString()
                    If String.Equals(checkTableValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxTable.Checked = True
                    ElseIf String.Equals(checkTableValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxTable.Checked = False
                    End If

                    Dim checkOthersValue As String = reader("CheckOthers").ToString()
                    If String.Equals(checkOthersValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxOthers.Checked = True
                    ElseIf String.Equals(checkOthersValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxOthers.Checked = False
                    End If

                    Dashboard.txtboxOther.Text = reader("CheckOthersComment").ToString()

                    Dim checkLaptopValue As String = reader("CheckLaptop").ToString
                    If String.Equals(checkLaptopValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxLaptop.Checked = True
                    ElseIf String.Equals(checkLaptopValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxLaptop.Checked = False
                    End If

                    Dim checkEmailValue As String = reader("CheckEmail").ToString()
                    If String.Equals(checkEmailValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxEmail.Checked = True
                    ElseIf String.Equals(checkEmailValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxEmail.Checked = False
                    End If

                    Dim checkComValue As String = reader("CheckCom").ToString()
                    If String.Equals(checkComValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxComputer.Checked = True
                    ElseIf String.Equals(checkComValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxComputer.Checked = False
                    End If



                    Dim checkHMOValue As String = reader("CheckHMO").ToString()
                    If String.Equals(checkHMOValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxHMO.Checked = True
                    ElseIf String.Equals(checkHMOValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxHMO.Checked = False
                    End If

                    Dim checkInsuranceValue As String = reader("CheckInsurance").ToString()
                    If String.Equals(checkInsuranceValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxInsurance.Checked = True
                    ElseIf String.Equals(checkInsuranceValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxInsurance.Checked = False
                    End If

                    Dim checkCompanyIDValue As String = reader("CheckCompanyID").ToString()
                    If String.Equals(checkCompanyIDValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxCompanyID.Checked = True
                    ElseIf String.Equals(checkCompanyIDValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxCompanyID.Checked = False
                    End If

                    Dim checkQuitClaimValue As String = reader("CheckQuitClaim").ToString()
                    If String.Equals(checkQuitClaimValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxQuitClaim.Checked = True
                    ElseIf String.Equals(checkQuitClaimValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxQuitClaim.Checked = False
                    End If

                    Dim checkCOEValue As String = reader("CheckCOE").ToString()
                    If String.Equals(checkCOEValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxCOE.Checked = True
                    ElseIf String.Equals(checkCOEValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxCOE.Checked = False
                    End If

                    Dim checkITRValue As String = reader("CheckITR").ToString()
                    If String.Equals(checkITRValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxITR.Checked = True
                    ElseIf String.Equals(checkITRValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxITR.Checked = False
                    End If

                    Dim checkFinalPayValue As String = reader("CheckFinalPay").ToString()
                    If String.Equals(checkFinalPayValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxFinalPay.Checked = True
                    ElseIf String.Equals(checkFinalPayValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxFinalPay.Checked = False
                    End If


                    Dim checkScheduleValue As String = reader("ScheduleInterviewStatus").ToString()
                    If String.Equals(checkScheduleValue, "Scheduled", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxInterview.Checked = True
                    ElseIf String.Equals(checkScheduleValue, "Pending", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxInterview.Checked = False
                    End If

                    Dim checkFinalValue As String = reader("ExitInterviewStatus").ToString()
                    If String.Equals(checkFinalValue, "Interviewed", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxFinal.Checked = True
                    ElseIf String.Equals(checkFinalValue, "Pending", StringComparison.OrdinalIgnoreCase) Then
                        Dashboard.CheckBoxFinal.Checked = False
                    End If

                End If
                reader.Close()
            End Using
            connection.Close()
            dbs.returnConnection(connection)
        End Using
    End Sub

    Public Sub datelabel()
        Dim checkQuitClaimValue As String = reader("CheckQuitClaim").ToString()
        If String.Equals(checkQuitClaimValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxQuitClaim.Checked = True
        ElseIf String.Equals(checkQuitClaimValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxQuitClaim.Checked = False
        End If

        Dim checkCOEValue As String = reader("CheckCOE").ToString()
        If String.Equals(checkCOEValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxCOE.Checked = True
        ElseIf String.Equals(checkCOEValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxCOE.Checked = False
        End If

        Dim checkITRValue As String = reader("CheckITR").ToString()
        If String.Equals(checkITRValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxITR.Checked = True
        ElseIf String.Equals(checkITRValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxITR.Checked = False
        End If

        Dim checkFinalPayValue As String = reader("CheckFinalPay").ToString()
        If String.Equals(checkFinalPayValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinalPay.Checked = True
        ElseIf String.Equals(checkFinalPayValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinalPay.Checked = False
        End If

        Dim checkScheduleValue As String = reader("ScheduleInterviewStatus").ToString()
        If String.Equals(checkScheduleValue, "Scheduled", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxInterview.Checked = True
        ElseIf String.Equals(checkScheduleValue, "Pending", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxInterview.Checked = False
        End If

        Dim checkFinalValue As String = reader("ExitInterviewStatus").ToString()
        If String.Equals(checkFinalValue, "Interviewed", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinal.Checked = True
        ElseIf String.Equals(checkFinalValue, "Pending", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinal.Checked = False
        End If
    End Sub

    Public Sub datalabel()
        Dim checkQuitClaimValue As String = reader("CheckQuitClaim").ToString()
        If String.Equals(checkQuitClaimValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxQuitClaim.Checked = True
        ElseIf String.Equals(checkQuitClaimValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxQuitClaim.Checked = False
        End If

        Dim checkCOEValue As String = reader("CheckCOE").ToString()
        If String.Equals(checkCOEValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxCOE.Checked = True
        ElseIf String.Equals(checkCOEValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxCOE.Checked = False
        End If

        Dim checkITRValue As String = reader("CheckITR").ToString()
        If String.Equals(checkITRValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxITR.Checked = True
        ElseIf String.Equals(checkITRValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxITR.Checked = False
        End If

        Dim checkFinalPayValue As String = reader("CheckFinalPay").ToString()
        If String.Equals(checkFinalPayValue, "Checked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinalPay.Checked = True
        ElseIf String.Equals(checkFinalPayValue, "Unchecked", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinalPay.Checked = False
        End If

        Dim checkScheduleValue As String = reader("ScheduleInterviewStatus").ToString()
        If String.Equals(checkScheduleValue, "Scheduled", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxInterview.Checked = True
        ElseIf String.Equals(checkScheduleValue, "Pending", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxInterview.Checked = False
        End If

        Dim checkFinalValue As String = reader("ExitInterviewStatus").ToString()
        If String.Equals(checkFinalValue, "Interviewed", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinal.Checked = True
        ElseIf String.Equals(checkFinalValue, "Pending", StringComparison.OrdinalIgnoreCase) Then
            Dashboard.CheckBoxFinal.Checked = False
        End If
    End Sub


End Class
