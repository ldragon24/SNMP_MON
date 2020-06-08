Imports System.Collections
'Imports SNMPDll
Imports SnmpSharpNet
Imports System.Management
Imports System.Threading
Imports System.ComponentModel

Public Class frmSRV

    Public Sub LOAD_WMI_7(ByVal strCmputer As String, ByVal Authority As String, ByVal wmiUser As String, ByVal wmiPasword As String, ByVal ssID As Integer, ByVal Journal As String)

        Call Lvev_Head_1()

        Dim connection As New ConnectionOptions

        lvev.Items.Clear()
        lvev.SmallImageList = il70


        Dim stm As String
        Dim mntch As String = DateTimePicker1.Value.Month
        Dim dntch As String = DateTimePicker1.Value.Day

        If Len(mntch) = 1 Then
            mntch = "0" & mntch
        End If

        If Len(dntch) = 1 Then
            dntch = "0" & dntch
        End If


        Me.Text = "Журнал событий за период с: " & dntch & "." & mntch & "." & DateTimePicker1.Value.Year & " по " & Date.Today

        stm = DateTimePicker1.Value.Year & mntch & dntch & "000000.000000-000"

        connection.Username = wmiUser
        connection.Password = DecryptBytes(wmiPasword)
        connection.Authority = "ntlmdomain:" & Authority

        Dim scope As New ManagementScope("\\" & strCmputer & "\root\CIMV2", connection)
        scope.Connect()

        Dim sSQL As String

        Select Case chkErr.Checked

            Case True

                Select Case Journal

                    Case "Система"

                        sSQL = "SELECT * FROM Win32_NTLogEvent where LogFile='System' AND (Type='Error' or Type='Warning' or Type='Critical' or Type='Ошибка') AND TimeWritten>='" & stm & "'"

                    ' AND EventType<3

                    Case "Приложение"

                        sSQL = "SELECT * FROM Win32_NTLogEvent where LogFile='Application' AND (Type='Error' or Type='Warning' or Type='Critical' or Type='Ошибка')  AND TimeWritten>='" & stm & "'"

                    Case "Безопасность"

                        sSQL = "SELECT * FROM Win32_NTLogEvent where LogFile='Security' AND (Type='Audit Failure' or Type='Аудит отказа'or Type='Ошибка')  AND TimeWritten>='" & stm & "'"

                End Select


            Case Else

                Select Case Journal

                    Case "Система"

                        sSQL = "SELECT * FROM Win32_NTLogEvent where LogFile='System' AND TimeWritten>='" & stm & "'"

                ' AND EventType<3

                    Case "Приложение"

                        sSQL = "SELECT * FROM Win32_NTLogEvent where LogFile='Application' AND TimeWritten>='" & stm & "'"

                    Case "Безопасность"

                        sSQL = "SELECT * FROM Win32_NTLogEvent where LogFile='Security' AND TimeWritten>='" & stm & "'"


                End Select


        End Select



        Dim query As New ObjectQuery(sSQL)
        '"SELECT * FROM Win32_NTLogEvent where logfile='System' AND TimeWritten>='" & stm & "' AND type='Error' OR type ='Warning' OR type='Ошибка' OR type='Предупреждение'"
        '"SELECT * FROM Win32_NTLogEvent where TimeWritten>='" & stm & "' and type='Error' OR type ='Warning' OR type='Ошибка' OR type='Предупреждение'"
        ' logfile='System' AND 

        Dim searcher As New ManagementObjectSearcher(scope, query)

        Dim intj As Integer = 0
        'Dim dt As DataTable = globals.getEventLogStructure

        lvev.Items.Clear()

        Try

            For Each queryObj As ManagementObject In searcher.Get()
                'globals.addEventLog(dt, Convert.ToString(queryObj("Category")), queryObj("ComputerName"), Convert.ToString(queryObj("EventCode")), queryObj("Message"), Convert.ToString(queryObj("TimeWritten")), Convert.ToString(queryObj("Type"))


                lvev.Cursor = Cursors.WaitCursor

                Dim uname As Integer

                Select Case queryObj("Type")

                    Case "Warning"
                        uname = 0

                    Case "Error"
                        uname = 1

                    Case "Critical"
                        uname = 1

                    Case "Предупреждение"
                        uname = 0

                    Case "Ошибка"
                        uname = 1

                    Case "Аудит успеха"
                        uname = 2

                    Case "Аудит отказа"
                        uname = 1

                    Case "Audit Success"
                        uname = 2

                    Case "Audit Failure"
                        uname = 1

                    Case "Аудит - успех"
                        uname = 2

                    Case "Аудит - отказ"
                        uname = 1

                    Case Else
                        uname = 2
                End Select

                Dim item As ListViewItem

                CNAME = queryObj("ComputerName")

                item = lvev.Items.Add(queryObj("ComputerName"))
                item.ImageIndex = uname

                If Len(queryObj("EventCode")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("EventCode"))
                If Len(queryObj("Message")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("Message"))
                If Len(queryObj("SourceName")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("SourceName"))
                If Len(queryObj("TimeGenerated")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(WMIDateStr(queryObj("TimeGenerated")))
                If Len(queryObj("Type")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("Type"))
                If Len(queryObj("LogFile")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("LogFile"))

                intj = intj + 1

                Application.DoEvents()

            Next

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


        lvev.Cursor = Cursors.Default
        Exit Sub
err_:

        MsgBox(Err.Description)

    End Sub

    Private Sub frmSRV_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Application.DoEvents()
        Me.Show()
        Application.DoEvents()

    End Sub

    Private Sub Lvev_Head_1()

        lvev.Columns.Clear()

        lvev.Columns.Add("Имя компьютера", 170, HorizontalAlignment.Left)
        lvev.Columns.Add("Event Code", 70, HorizontalAlignment.Left)
        lvev.Columns.Add("Сообщение", 140, HorizontalAlignment.Left)
        lvev.Columns.Add("Источник", 170, HorizontalAlignment.Left)
        lvev.Columns.Add("Время", 170, HorizontalAlignment.Left)
        lvev.Columns.Add("Тип", 100, HorizontalAlignment.Left)
        lvev.Columns.Add("Журнал", 100, HorizontalAlignment.Left)
    End Sub

    Private Sub Lvev_Head_2()

        lvev.Columns.Clear()
        lvev.Columns.Add("Имя компьютера", 170, HorizontalAlignment.Left)
        lvev.Columns.Add("Имя процесса", 170, HorizontalAlignment.Left)
        lvev.Columns.Add("Идентификатор процесса", 70, HorizontalAlignment.Left)
        lvev.Columns.Add("Описание", 70, HorizontalAlignment.Left)
        lvev.Columns.Add("Путь", 70, HorizontalAlignment.Left)

    End Sub

    Private Sub lvev_ItemMouseHover(sender As Object, e As System.Windows.Forms.ListViewItemMouseHoverEventArgs) Handles lvev.ItemMouseHover

        Try

            Dim stext As String
            stext = e.Item.SubItems(4).Text & vbCrLf & e.Item.SubItems(3).Text & vbCrLf & vbCrLf & e.Item.SubItems(2).Text & vbCrLf & "Event Code " & e.Item.SubItems(1).Text

            ToolTip1.ToolTipTitle = Application.ProductName

            If e.Item.SubItems(1).Text Is Nothing Then


            Else

                ToolTip1.SetToolTip(lvev, WordWrap(stext))


                Debug.Print(WordWrap(stext))

            End If

        Catch ex As Exception

            Debug.Print(ex.Message)

        End Try

    End Sub

    Friend Function WordWrap(ByVal MessageText As String) As String
        Dim Words() As String = Split(MessageText, " ")

        Dim LineLen As Integer
        WordWrap = ""

        For i As Integer = 0 To Words.Length - 1
            WordWrap &= Words(i) & " "
            LineLen += (Words(i).Length + 1)

            ' Add a wrap if adding next word overflows
            If i < Words.Length - 1 Then

                If LineLen + Words(i + 1).Length >= 40 Then
                    WordWrap &= vbCrLf
                    LineLen = 0
                End If
            End If
        Next
        Return WordWrap
    End Function

    Private Sub lvev_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If lvev.GetItemAt(e.X, e.Y) Is Nothing Then
            ToolTip1.RemoveAll()
        End If
    End Sub

    Private Sub lvev_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub rbSystem_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSystem.CheckedChanged

        If rbSystem.Checked = True Then

            lvev.Columns.Clear()
            Lvev_Head_1()

            Call LOAD_WMI_7(strComputer1, Authority1, wmiUser1, wmiPasword1, ssID1, "Система")
        Else
        End If

    End Sub

    Private Sub rbApplication_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbApplication.CheckedChanged

        If rbApplication.Checked = True Then

            lvev.Columns.Clear()
            Lvev_Head_1()

            Call LOAD_WMI_7(strComputer1, Authority1, wmiUser1, wmiPasword1, ssID1, "Приложение")
        Else
        End If

    End Sub

    Private Sub rbSecurity_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbSecurity.CheckedChanged

        If rbSecurity.Checked = True Then

            lvev.Columns.Clear()
            Lvev_Head_1()

            Call LOAD_WMI_7(strComputer1, Authority1, wmiUser1, wmiPasword1, ssID1, "Безопастность")
        Else
        End If

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        ExportListViewToExcel(lvev, Me.Text & " сервера " & CNAME)


    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged

        Call Lvev_Head_2()
        lvev.Items.Clear()

        Dim connection As New ConnectionOptions

        connection.Username = wmiUser1
        connection.Password = DecryptBytes(wmiPasword1)
        connection.Authority = "ntlmdomain:" & Authority1

        Dim scope As New ManagementScope("\\" & strComputer1 & "\root\CIMV2", connection)
        scope.Connect()

        Dim sSQL As String

        sSQL = "SELECT * FROM Win32_Process"


        Dim query As New ObjectQuery(sSQL)
        '"SELECT * FROM Win32_NTLogEvent where logfile='System' AND TimeWritten>='" & stm & "' AND type='Error' OR type ='Warning' OR type='Ошибка' OR type='Предупреждение'"
        '"SELECT * FROM Win32_NTLogEvent where TimeWritten>='" & stm & "' and type='Error' OR type ='Warning' OR type='Ошибка' OR type='Предупреждение'"
        ' logfile='System' AND 

        Dim searcher As New ManagementObjectSearcher(scope, query)

        Dim intj As Integer = 0
        'Dim dt As DataTable = globals.getEventLogStructure

        Try

            For Each queryObj As ManagementObject In searcher.Get()
                'globals.addEventLog(dt, Convert.ToString(queryObj("Category")), queryObj("ComputerName"), Convert.ToString(queryObj("EventCode")), queryObj("Message"), Convert.ToString(queryObj("TimeWritten")), Convert.ToString(queryObj("Type"))

                lvev.Cursor = Cursors.WaitCursor

                lvev.Items.Add(CNAME)

                If Len(queryObj("Name")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("Name"))
                If Len(queryObj("ProcessId")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("ProcessId"))
                If Len(queryObj("Description")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("Description"))
                If Len(queryObj("ExecutablePath")) <> 0 Then lvev.Items(CInt(intj)).SubItems.Add(queryObj("ExecutablePath"))
                'ExecutablePath:

                intj = intj + 1

                Application.DoEvents()
            Next

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try


        lvev.Cursor = Cursors.Default
        Exit Sub
err_:

        MsgBox(Err.Description)


    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        If rbApplication.Checked = True Then
            Call LOAD_WMI_7(strComputer1, Authority1, wmiUser1, wmiPasword1, ssID1, "Приложение")
        Else
        End If

        If rbSecurity.Checked = True Then
            Call LOAD_WMI_7(strComputer1, Authority1, wmiUser1, wmiPasword1, ssID1, "Безопасность")
        Else
        End If

        If rbSystem.Checked = True Then
            Call LOAD_WMI_7(strComputer1, Authority1, wmiUser1, wmiPasword1, ssID1, "Система")
        Else
        End If

    End Sub


    Function WMIDateStr(WMIDate)
        WMIDateStr = CDate(Mid(WMIDate, 7, 2) & "." & Mid(WMIDate, 5, 2) & "." & Microsoft.VisualBasic.Left(WMIDate, 4) & " " & Mid(WMIDate, 9, 2) & ":" & Mid(WMIDate, 11, 2) & ":" & Mid(WMIDate, 13, 2))
    End Function

    Private Sub chkErr_CheckedChanged(sender As Object, e As EventArgs) Handles chkErr.CheckedChanged

    End Sub
End Class