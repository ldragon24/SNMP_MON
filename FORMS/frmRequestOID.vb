Imports System.Collections
Imports SnmpSharpNet
Imports System.Net.Mail
Imports System.Net
Imports System.Text
'Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading
Imports ZedGraph
Imports System.Management
Imports System.ComponentModel
Imports System.Security.Principal

Public Class frmRequestOID

    Private m_SortingColumn As ColumnHeader
    Private Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Byte, ByVal dwExtraInfo As Byte)
    Private Const VK_RETURN As Byte = &HD
    Private Const KEYEVENTF_KEYDOWN As Byte = &H0
    Private Const KEYEVENTF_KEYUP As Byte = &H2
    Private END_OPROS As Boolean = False
    Private lstVW As ListView
    Private Const CP_NOCLOSE_BUTTON As Integer = &H200
    Private rCOUNT As Integer
    Private ibpCOUNT As Integer


    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Int32
    Private Declare Function GetWindow Lib "user32" (ByVal hwnd As Int32, ByVal wCmd As Int32) As Int32
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Dim inputTitle As String = "Введите пароль!"
    Dim returnedPW As String
    Const asteriskKeyCode = 42

    Public Const EM_SETPASSWORDCHAR = &HCC
    Public Const GW_CHILD = 5
    Public Const WM_CREATE = &H1
    Dim windowHandle As Int32

    Public ThIBP As System.Threading.Thread
    Public ThPing As System.Threading.Thread
    Public ThrTIMER_ As System.Threading.Thread
    Public ThArd As System.Threading.Thread

    Public ThComm As System.Threading.Thread
    Public ThPrn As System.Threading.Thread
    Public ThANTI As System.Threading.Thread
    Public ThWSUS As System.Threading.Thread

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        MyBase.WndProc(m)

        If m.Result.ToInt32 = WM_CREATE Then

            windowHandle = FindWindow(vbNullString, inputTitle)

        ElseIf windowHandle > 0 Then
            setPassword()
            windowHandle = 0
        End If

    End Sub

    Public Sub setPassword()

        Dim editWindow As Int32
        editWindow = GetWindow(windowHandle, GW_CHILD)
        SendMessage(editWindow, EM_SETPASSWORDCHAR, asteriskKeyCode, 0)

    End Sub

    'Sub ThrPrn()

    '    Do
    '        lstUPS.Invoke(New MethodInvoker(AddressOf OPROS_PRN))

    '        ' ToolStripStatusLabel3.Text = "Опрос каждые " & TIMEOPROS_ & " минут"
    '        Threading.Thread.Sleep((TIMEOPROS_ + 2) * 60 * 1000)

    '    Loop

    'End Sub

    'Sub ThrComm()

    '    Do
    '        lstUPS.Invoke(New MethodInvoker(AddressOf OPROS_COMM))

    '        ToolStripStatusLabel3.Text = "Опрос каждые " & TIMEOPROS_ & " минут"
    '        Threading.Thread.Sleep((TIMEOPROS_ + 1) * 60 * 1000)

    '    Loop

    'End Sub

    Sub ThrIBP()

        Do
            lstUPS.Invoke(New MethodInvoker(AddressOf OPROS))

            ToolStripStatusLabel3.Text = "Опрос каждые " & TIMEOPROS_ & " минут"
            Threading.Thread.Sleep(TIMEOPROS_ * 60 * 1000)

            If Button1.Text = "Ping" Then
                ThPing = New System.Threading.Thread(AddressOf ThrPing)
                ThPing.Start()
            End If
        Loop

    End Sub

    Sub ThrPing()

        Me.Invoke(Sub() Button1.Text = "Стоп")
        Do

            lvPing.BeginInvoke(New MethodInvoker(AddressOf ping_re))

            Threading.Thread.Sleep(60 * 1000)

        Loop

    End Sub

    Sub ThrArd()

        Me.Invoke(Sub() btnStopArduino.Text = "Стоп")
        Do

            lvApparat.BeginInvoke(New MethodInvoker(AddressOf OPROS_ARDUINO))

            Threading.Thread.Sleep(TIMEOPROS_ * 60 * 1000)

        Loop

    End Sub

    Sub ThrTIMER()
        Dim SDA As DateTime

        Do

            SDA = Date.Today.AddDays(-7)


            Select Case TimeOfDay.Hour

                Case wmiHOUR

                    Select Case TimeOfDay.Minute

                        Case wmiMinute

                            Select Case TimeOfDay.Second

                                Case 45

                                    If sOPROS = True Then Threading.Thread.Sleep(180000)
                                    Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_SERV))

                            End Select

                    End Select

                Case 16

                    Select Case TimeOfDay.Minute

                        Case 40

                            Select Case TimeOfDay.Second

                                Case 17

                                    Try
                                        If sOPROS = True Then Threading.Thread.Sleep(180000)

                                        Dim sSQL As String = "select count(*) as t_n FROM TBL_PING_SL Where DT <=" & get_date_format(SDA)
                                        Dim rs As Recordset
                                        rs = New Recordset
                                        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                                        With rs
                                            sCOUNT = .Fields("t_n").Value
                                        End With
                                        rs.Close()
                                        rs = Nothing

                                        If sCOUNT = 0 Then Exit Sub

                                        sSQL = "DELETE FROM TBL_PING_SL Where DT <=" & get_date_format(SDA) ' & "'"
                                        DB7.Execute(sSQL)

                                    Catch ex As Exception

                                    End Try


                                    'Call COMPARE_DB()


                            End Select


                    End Select

            End Select

            Select Case Date.Today.Day

                Case "1"

                    Select Case TimeOfDay.Hour

                        Case wmiHOUR

                            Select Case TimeOfDay.Minute

                                Case wmiMinute

                                    Select Case TimeOfDay.Second

                                        Case 45
                                            ThPing.Abort()
                                            If sOPROS = True Then Threading.Thread.Sleep(180000)

                                            DB7.Execute("DELETE FROM TBL_PING Where DT <=" & get_date_format(SDA))
                                            SDA = Date.Today.AddMonths(-1)
                                            DB7.Execute("DELETE FROM IBP_MON Where DT <=" & get_date_format(SDA))
                                            Call COMPARE_DB()
                                            ThPing.Start()
                                    End Select

                            End Select

                    End Select

                Case Else

            End Select

            Threading.Thread.Sleep(1000)

        Loop

    End Sub

    Function get_date_format(ByVal str_date As String)

        Dim mm As String = Mid(str_date, 4, 2)
        Dim dd As String = Microsoft.VisualBasic.Left(str_date, 2)
        Dim gggg As String = Microsoft.VisualBasic.Right(str_date, 4)
        Return "#" & mm & "/" & dd & "/" & gggg & "#"

    End Function

    Public Sub New()
        InitializeComponent()

        AddHandler zg1.ContextMenuBuilder, AddressOf zg1_ContextMenuBuilder

        AddHandler zg2.ContextMenuBuilder, AddressOf zg1_ContextMenuBuilder

        AddHandler zg3.ContextMenuBuilder, AddressOf zg1_ContextMenuBuilder


        AddHandler zgPrn.ContextMenuBuilder, AddressOf zg1_ContextMenuBuilder

        AddHandler zgApparat.ContextMenuBuilder, AddressOf zg1_ContextMenuBuilder

    End Sub

    Protected Overrides ReadOnly Property CreateParams As System.Windows.Forms.CreateParams

        Get
            Dim myCP As CreateParams = MyBase.CreateParams
            myCP.ClassStyle = myCP.ClassStyle Or CP_NOCLOSE_BUTTON

            Return myCP
        End Get

    End Property

    Private Sub frmRequestoid_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        ThrTIMER_.Abort()
        ThIBP.Abort()
        ThPing.Abort()
        '  ThArd.Abort()

        'ThComm.Abort()
        ' ThPrn.Abort()

        UnLoadDatabase()
        ni.Visible = False

    End Sub

    Private Sub Form_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
  Handles MyBase.SizeChanged

        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
            Me.ni.Visible = True
        End If

    End Sub

    Private Sub frmRequestOID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error GoTo err_

        Call LoadDatabase()

        Graph_n(zg1)
        Graph_n(zg2)
        Graph_n(zg3)
        Graph_n(zgPrn)
        Graph_n(zgApparat)

        lblEnableIbp.Text = "Управление ИБП: Выключено"
        lblEnableIbp.ForeColor = Color.Red

        ComboBox1.Text = "FastLine"

        Me.BeginInvoke(New MethodInvoker(AddressOf PreLoad))
        My.Application.DoEvents()

        Call list_ups_filling()
        Call list_comm_filling()

        lvPrinter.Columns.Clear()

        lvPrinter.Columns.Add("id", 1, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("Имя в сети", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("Модель", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("Отпечатано страниц", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("Уровень тонера", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("Модель картриджа", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("IP адрес", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("MAC адрес", 140, HorizontalAlignment.Left)
        lvPrinter.Columns.Add("Состояние", 140, HorizontalAlignment.Left)

        'lvPing
        lvPing.Columns.Add("id", 1, HorizontalAlignment.Left)
        lvPing.Columns.Add("IP адрес/Псевдоним", 140, HorizontalAlignment.Left)
        lvPing.Columns.Add("Состояние", 140, HorizontalAlignment.Left)
        lvPing.Columns.Add("Плохой пинг", 140, HorizontalAlignment.Left)

        lvHDD.Columns.Add("id", 1, HorizontalAlignment.Left)
        lvHDD.Columns.Add("Дата", 110, HorizontalAlignment.Left)
        lvHDD.Columns.Add("Логический диск", 100, HorizontalAlignment.Left)
        lvHDD.Columns.Add("Объем физического диска", 100, HorizontalAlignment.Left)
        lvHDD.Columns.Add("Свободное пространство", 100, HorizontalAlignment.Left)
        lvHDD.Columns.Add("% Свободного пространства", 100, HorizontalAlignment.Left)

        lvAnti.Columns.Add("id", 30, HorizontalAlignment.Left)
        lvAnti.Columns.Add("Имя в сети", 240, HorizontalAlignment.Left)
        lvAnti.Columns.Add("Антивирус", 240, HorizontalAlignment.Left)
        lvAnti.Columns.Add("Состояние", 140, HorizontalAlignment.Left)
        lvAnti.Columns.Add("Доступность", 140, HorizontalAlignment.Left)
        lvAnti.Columns.Add("Дата и время проверки", 240, HorizontalAlignment.Left)


        lvSystem.Columns.Add("id", 0, HorizontalAlignment.Left)
        lvSystem.Columns.Add("Имя в сети", 240, HorizontalAlignment.Left)
        lvSystem.Columns.Add("Дата установки последнего обновления", 240, HorizontalAlignment.Left)
        lvSystem.Columns.Add("Дата и время проверки", 240, HorizontalAlignment.Left)


        lvApparat.Columns.Add("id", 1, HorizontalAlignment.Left)
        lvApparat.Columns.Add("Дата", 110, HorizontalAlignment.Left)
        lvApparat.Columns.Add("Время", 100, HorizontalAlignment.Left)
        lvApparat.Columns.Add("Температура", 100, HorizontalAlignment.Left)
        lvApparat.Columns.Add("Влажность (%)", 100, HorizontalAlignment.Left)


        Me.Show()

        '  Me.BeginInvoke(New MethodInvoker(AddressOf TIMER_EN))
        ' Me.BeginInvoke(New MethodInvoker(AddressOf TIMER_EN2))

        My.Application.DoEvents()

        'Me.BeginInvoke(New MethodInvoker(AddressOf OPROS))

        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_SERV_HDD))

        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_ARDUINO))


        ThPing = New System.Threading.Thread(AddressOf ThrPing)
        ThPing.Start()

        ThIBP = New System.Threading.Thread(AddressOf ThrIBP)
        ThIBP.Start()

        '  ThArd = New System.Threading.Thread(AddressOf ThrArd)
        '  ThArd.Start()

        'ThPrn = New System.Threading.Thread(AddressOf ThrPrn)
        'ThPrn.Start()

        ThrTIMER_ = New System.Threading.Thread(AddressOf ThrTIMER)
        ThrTIMER_.Start()


        lvPing.BeginInvoke(New MethodInvoker(AddressOf ping_re))

        ' My.Application.DoEvents()
        ' GC.Collect()

        ThANTI = New System.Threading.Thread(AddressOf GET_ANT_START)
        ThANTI.Start()

        ThWSUS = New System.Threading.Thread(AddressOf GET_WSUS_START)
        ThWSUS.Start()

        'GET_WSUS_START


        'ThPrn = New System.Threading.Thread(AddressOf ThrPrn)
        'ThPrn.Start()

        Exit Sub
err_:

        MsgBox(Err.Description, MsgBoxStyle.Critical, "SMNP Monitor")
    End Sub

    Public Sub list_comm_filling()
        On Error Resume Next

        lstComm.Columns.Clear()

        lstComm.Columns.Add("id", 1, HorizontalAlignment.Left)

        Select Case COMM_MN
            Case True
                lstComm.Columns.Add("Место нахождения", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_NN
            Case True
                lstComm.Columns.Add("Имя в сети", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_CONTACT
            Case True
                lstComm.Columns.Add("Контактное лицо", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_MOD
            Case True
                lstComm.Columns.Add("Модель", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_SN
            Case True
                lstComm.Columns.Add("Серийный номер", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_INWORK
            Case True
                lstComm.Columns.Add("В работе", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_IP
            Case True
                lstComm.Columns.Add("IP адрес", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_MAC
            Case True
                lstComm.Columns.Add("MAC адрес", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_THEMP
            Case True
                lstComm.Columns.Add("Температура", 140, HorizontalAlignment.Left)
        End Select

        Select Case COMM_FLASH
            Case True
                lstComm.Columns.Add("Прошивка", 140, HorizontalAlignment.Left)
        End Select


    End Sub

    Public Sub list_ups_filling()
        On Error Resume Next

        lstUPS.Columns.Clear()

        lstUPS.Columns.Add("id", 1, HorizontalAlignment.Left)

        Select Case UPSMN
            Case True
                lstUPS.Columns.Add("Место нахождения", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_NAME
            Case True
                lstUPS.Columns.Add("Имя в сети", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPC_Contact
            Case True
                lstUPS.Columns.Add("Контактное лицо", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_MODEL
            Case True
                lstUPS.Columns.Add("Модель", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_SN
            Case True
                lstUPS.Columns.Add("Серийный номер", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_BATTERY_TIME
            Case True
                lstUPS.Columns.Add("Оставшееся время автономной работы", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_BATTARY_ENERGY
            Case True
                lstUPS.Columns.Add("Заряд батареи", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_BATTARY_SOST
            Case True
                lstUPS.Columns.Add("Состояние батареи", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_BATTARY_ZAM
            Case True
                lstUPS.Columns.Add("Замена батареи", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_TIME_WORK
            Case True
                lstUPS.Columns.Add("В работе", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_IP
            Case True
                lstUPS.Columns.Add("IP адрес", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_MAC
            Case True
                lstUPS.Columns.Add("MAC адрес", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_IN_ACDC
            Case True
                lstUPS.Columns.Add("Входное напряжение", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_OUT_ACDC
            Case True
                lstUPS.Columns.Add("Выходное напряжение", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_MHZ
            Case True
                lstUPS.Columns.Add("Входная частота", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_LOAD
            Case True
                lstUPS.Columns.Add("Мощность нагрузки", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_STATUS
            Case True
                lstUPS.Columns.Add("Статус", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_TEST
            Case True
                lstUPS.Columns.Add("Тест", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_TEST_DATE
            Case True
                lstUPS.Columns.Add("Дата теста", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_TEMP
            Case True
                lstUPS.Columns.Add("Внутренняя температура", 140, HorizontalAlignment.Left)
        End Select

        Select Case UPS_TEMP2
            Case True
                lstUPS.Columns.Add("Внешняя температура", 140, HorizontalAlignment.Left)
        End Select
    End Sub

    'Public Sub TIMER_EN()

    '    ToolStripStatusLabel3.Text = "Опрос каждые " & TIMEOPROS_ & " минут"

    '    Dim t As New System.Windows.Forms.Timer()
    '    t.Interval = TIMEOPROS_ * 60 * 1000
    '    t.Enabled = True
    '    AddHandler t.Tick, AddressOf TimerEventHandler

    'End Sub

    'Public Sub TIMER_EN2()

    '    Dim t As New System.Windows.Forms.Timer()
    '    t.Interval = 1000
    '    t.Enabled = True
    '    AddHandler t.Tick, AddressOf TimerEventHandler2

    'End Sub

    Private Sub ni_DoubleClick(sender As Object, e As System.EventArgs)
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        'Me.ni.Visible = False
    End Sub

    'Public Sub msgboxautoclose(ByVal Message As String, Optional ByVal Style As MsgBoxStyle = Nothing, Optional ByVal title As String = Nothing, Optional ByVal delay As Integer = 5)
    '    Dim t As New Threading.Thread(AddressOf closeMsgbox)
    '    t.Start(delay)
    '    MsgBox(Message, Style, title)
    'End Sub

    'Private Sub closeMsgbox(ByVal delay As Object)
    '    Threading.Thread.Sleep(CInt(delay) * 1000)
    '    AppActivate(Me.Text)
    '    keybd_event(VK_RETURN, 0, KEYEVENTF_KEYDOWN, 0)
    '    keybd_event(VK_RETURN, 0, KEYEVENTF_KEYUP, 0)
    'End Sub

    Private Sub ОпроситьУстройстваToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОпроситьУстройстваToolStripMenuItem.Click
        On Error GoTo err_

        '  Me.BeginInvoke(New MethodInvoker(AddressOf OPROS))
        ThPing.Abort()
        ThIBP.Abort()
        '  ThArd.Abort()
        'ThPrn.Abort()

        ThPing = New System.Threading.Thread(AddressOf ThrPing)
        ThPing.Start()

        ThIBP = New System.Threading.Thread(AddressOf ThrIBP)
        ThIBP.Start()

        '  ThArd = New System.Threading.Thread(AddressOf ThrArd)
        ' ThArd.Start()

        'ThPrn = New System.Threading.Thread(AddressOf ThrPrn)
        'ThPrn.Start()


err_:
    End Sub

    Private Sub ОткрытьВБраузереToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОткрытьВБраузереToolStripMenuItem.Click
        Call OPEN_BROWSER(lstVW)
    End Sub

    Private Sub РазвернутьToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles РазвернутьToolStripMenuItem.Click
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub НастройкиToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles НастройкиToolStripMenuItem1.Click
        frmSetup.ShowDialog(Me)
    End Sub

    Private Sub НастройкиToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles НастройкиToolStripMenuItem.Click
        frmSetup.ShowDialog(Me)
    End Sub

    Private Sub ОпроситьToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОпроситьToolStripMenuItem.Click
        On Error GoTo err_

        Me.BeginInvoke(New MethodInvoker(AddressOf OPROS))
        'Call OPROS()
err_:
    End Sub

    Private Sub ВыходToolStripMenuItem1_Click(sender As System.Object, e As System.EventArgs) Handles ВыходToolStripMenuItem1.Click
        UnLoadDatabase()
        ni.Visible = False
        End
    End Sub

    Private Sub ВыходToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ВыходToolStripMenuItem.Click
        UnLoadDatabase()
        ni.Visible = False
        End
    End Sub

    Private Sub GetNextToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetNextToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub lstUPS_Click(sender As Object, e As System.EventArgs) Handles lstUPS.Click

        CHART_IBP(zg2)

    End Sub

    Private Sub lstUPS_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstUPS.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
          lstUPS.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lstUPS.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lstUPS.Sort()
    End Sub

    Private Sub lstUPS_DoubleClick(sender As Object, e As System.EventArgs) Handles lstUPS.DoubleClick

        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Select Case sIBPR

                        Case False

                            frmIBP.DEVELOP = .Fields("DevelopDev").Value
                            frmIBP.MODEL = .Fields("MODEL").Value
                            frmIBP.IPDEV = .Fields("IPDev").Value
                            frmIBP.COMMDEV = .Fields("CommunityDev").Value

                            frmIBP.ShowDialog(Me)

                        Case True

                            Dim frmIBP As frmIBP = New frmIBP
                            frmIBP.DEVELOP = .Fields("DevelopDev").Value
                            frmIBP.MODEL = .Fields("MODEL").Value
                            frmIBP.IPDEV = .Fields("IPDev").Value
                            frmIBP.COMMDEV = .Fields("CommunityDev").Value

                            frmIBP.Show()

                    End Select

                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select

    End Sub

    Private Sub lstUPS_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstUPS.MouseUp

        If lstUPS.Items.Count = 0 Then Exit Sub

        lstVW = lstUPS

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            cmenuLST.Show(CType(sender, Control), e.Location)

            ОткрытьRDPToolStripMenuItem.Visible = False
            КачествоПингToolStripMenuItem.Visible = False
            ibpRemoteControl.Visible = True
            RealtimeIBP.Visible = True
            ВходноеНапряжениеToolStripMenuItem.Visible = True
            ВыходноеНапряжениеToolStripMenuItem.Visible = True
            НагрузкаToolStripMenuItem.Visible = True
            ЗарядБатареиToolStripMenuItem.Visible = True
            ТемператураToolStripMenuItem.Visible = True
            ВольтажБатареиToolStripMenuItem.Visible = True
        Else

        End If

    End Sub

    Private Sub lstComm_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstComm.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
        lstComm.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lstComm.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lstComm.Sort()
    End Sub

    Private Sub lstComm_DoubleClick(sender As Object, e As System.EventArgs) Handles lstComm.DoubleClick

        Me.Invoke(Sub() Me.BeginInvoke(New MethodInvoker(AddressOf frm_CISCO_PORT_LOAD)))

    End Sub

    Private Sub frm_CISCO_PORT_LOAD()
        On Error Resume Next

        Me.Cursor = Cursors.WaitCursor

        'CISCO_PORT_OPROS

        If lstComm.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        'Dim rCOUNT As Integer

        For z = 0 To lstComm.SelectedItems.Count - 1
            rCOUNT = (lstComm.SelectedItems(z).Text)
            frmCiscoPort.Text = "Описание портов: " & lstComm.SelectedItems(z).SubItems(2).Text
        Next

        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    frmCiscoPort.IPDEV = .Fields("IPDev").Value
                    frmCiscoPort.COMMDEV = .Fields("CommunityDev").Value
                    frmCiscoPort.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub lstComm_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstComm.MouseUp

        If lstComm.Items.Count = 0 Then Exit Sub

        lstVW = lstComm

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            cmenuLST.Show(CType(sender, Control), e.Location)
            ОткрытьRDPToolStripMenuItem.Visible = False
            КачествоПингToolStripMenuItem.Visible = False
            ibpRemoteControl.Visible = False
            RealtimeIBP.Visible = True
            ВходноеНапряжениеToolStripMenuItem.Visible = False
            ВыходноеНапряжениеToolStripMenuItem.Visible = False
            НагрузкаToolStripMenuItem.Visible = False
            ЗарядБатареиToolStripMenuItem.Visible = False
            ТемператураToolStripMenuItem.Visible = False
            ВольтажБатареиToolStripMenuItem.Visible = False

        Else

        End If
    End Sub

    Private Sub lvPrinter_Click(sender As Object, e As System.EventArgs) Handles lvPrinter.Click

        CHART_PRN(zgPrn)

    End Sub

    Private Sub lvPrinter_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPrinter.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
       lvPrinter.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvPrinter.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)
        lvPrinter.Sort()
    End Sub

    Private Sub lvPrinter_DoubleClick(sender As Object, e As System.EventArgs) Handles lvPrinter.DoubleClick

        On Error Resume Next

        If lvPrinter.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2 As String

        uname = ""
        uname2 = ""

        For z = 0 To lvPrinter.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
            uname2 = lstVW.SelectedItems(z).SubItems(2).Text
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            ' uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
        End With

        rs.Close()
        rs = Nothing

        frm_printer.load_sensors(uname, uname2)
        frm_printer.ShowDialog(Me)

    End Sub

    Private Sub lvPrinter_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lvPrinter.MouseUp

        If lvPrinter.Items.Count = 0 Then Exit Sub

        lstVW = lvPrinter

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            cmenuLST.Show(CType(sender, Control), e.Location)
            ОткрытьRDPToolStripMenuItem.Visible = False
            КачествоПингToolStripMenuItem.Visible = False
            ibpRemoteControl.Visible = False
            RealtimeIBP.Visible = True
            ВходноеНапряжениеToolStripMenuItem.Visible = False
            ВыходноеНапряжениеToolStripMenuItem.Visible = False
            НагрузкаToolStripMenuItem.Visible = False
            ЗарядБатареиToolStripMenuItem.Visible = False
            ТемператураToolStripMenuItem.Visible = False
            ВольтажБатареиToolStripMenuItem.Visible = False
        Else

        End If
    End Sub

    Private Sub OPEN_BROWSER(ByVal lstVW As ListView)
        On Error Resume Next

        If lstVW.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2 As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
        End With

        rs.Close()
        rs = Nothing

        If uname2 = "Сервер" Then Exit Sub

        System.Diagnostics.Process.Start("http://" & uname)
    End Sub

    Private Sub ni_DoubleClick1(sender As Object, e As System.EventArgs) Handles ni.DoubleClick
        Me.Visible = True
        Me.WindowState = FormWindowState.Normal
        'Me.ni.Visible = False
    End Sub

    Private Sub OPROS()
        On Error Resume Next

        IBPenable = False
        lblEnableIbp.Text = "Управление ИБП: Выключено"
        lblEnableIbp.ForeColor = Color.Red

        sOPROS = True

        Dim intPing As Integer = 0

        sTXT = ""
        sTXT_ = ""
        ' sTXT_ALERT = ""
        sMessage = ""

        zCounter = 0
        result_ = True

        intcountIBP = 0
        intcountCOMM = 0
        intcountPRN = 0

        lstUPS.Sorting = SortOrder.None
        lstUPS.ListViewItemSorter = Nothing

        lstComm.Sorting = SortOrder.None
        lstComm.ListViewItemSorter = Nothing

        lvPrinter.Sorting = SortOrder.None
        lvPrinter.ListViewItemSorter = Nothing

        lstUPS.Items.Clear()
        lstComm.Items.Clear()
        lvPrinter.Items.Clear()

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sCOUNT = .Fields("t_n").Value

        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

                MsgBox("Нет устройств для опроса" + vbNewLine + "добавить устройства можно в настройках программы", MsgBoxStyle.Information, "SMNP Monitor")

            Case Else

                lstUPS.BeginInvoke(New MethodInvoker(AddressOf OPROS_IBP))
                Application.DoEvents()
                lstComm.BeginInvoke(New MethodInvoker(AddressOf OPROS_COMM))
                Application.DoEvents()
                lvPrinter.BeginInvoke(New MethodInvoker(AddressOf OPROS_PRN))
                Application.DoEvents()
                lvApparat.BeginInvoke(New MethodInvoker(AddressOf OPROS_ARDUINO))
                Application.DoEvents()
                ' lvPing.BeginInvoke(New MethodInvoker(AddressOf ping_re))

        End Select

        ToolStripStatusLabel1.Text = "Время последнего опроса: " & DateTime.Now.ToLongTimeString

        If tmpIntj2 <> 0 And SendMail2_ = 1 Then

            int_forSendMail = tmpIntj2
        Else
            Application.DoEvents()

            sOPROS = False
            Call MESSAGE_("-------------------------")
            int_forSendMail = 0

        End If

        ' GC.Collect()
        ' My.Application.DoEvents()

        Exit Sub
err_:
        sOPROS = False
        MsgBox(Err.Description, MsgBoxStyle.Critical, "SMNP Monitor")
        ToolStripStatusLabel1.Text = "Время последнего опроса: " & DateTime.Now.ToLongTimeString
    End Sub

    Private Sub GetNextOIDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles GetNextOIDToolStripMenuItem.Click
        Form1.Show()
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Select Case Button1.Text

            Case "Стоп"
                Button1.Text = "Ping"
                ThPing.Abort()
            Case Else
                sTXT_ = ""
                sMessage = ""
                ThPing = New System.Threading.Thread(AddressOf ThrPing)
                ThPing.Start()
        End Select

    End Sub

    'Private Sub P_R_N()

    '    lvPing.Sorting = SortOrder.None
    '    lvPing.ListViewItemSorter = Nothing
    '    lvPing.Items.Clear()

    '    BackgroundWorker1.WorkerReportsProgress = True
    '    BackgroundWorker1.RunWorkerAsync()

    'End Sub

    'Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

    '    Dim net As New Net.NetworkInformation.Ping

    '    'Dim p As New System.Net.NetworkInformation.Ping() ' получаем пинг

    '    zCounter = 0
    '    Dim intPing As Integer = 0
    '    Dim intj2 As Integer = 0
    '    Dim sTXT17_ As String

    '    sTXT17_ = ""

    '    Dim sSQL As String
    '    Dim rs As Recordset 

    '    sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev <>'Принтеры' AND NOT_PING <> True"

    '    rs = New Recordset
    '    rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

    '    Dim sCOUNT As Integer

    '    With rs
    '        sCOUNT = .Fields("t_n").Value
    '    End With
    '    rs.Close()
    '    rs = Nothing

    '    If sCOUNT = 0 Then Exit Sub

    '    sSQL = "SELECT * FROM TBL_DEV WHERE TipDev <>'Принтеры' AND NOT_PING <> True ORDER BY ipdev"

    '    rs = New Recordset
    '    rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

    '    With rs
    '        .MoveFirst()
    '        Do While Not .EOF

    '            If net.Send(.Fields("IPDev").Value, 20).status = System.Net.NetworkInformation.IPStatus.Success Then

    '                BackgroundWorker1.ReportProgress(0, .Fields("IPDev").Value)

    '            Else

    '                BackgroundWorker1.ReportProgress(zCounter, .Fields("IPDev").Value)
    '                zCounter = zCounter + 1

    '                Dim sTIM As String
    '                sTIM = TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second

    '                sSQL = "INSERT INTO TBL_PING(TipDev,IPDEV,DT,TM) VALUES('" & .Fields("TipDev").Value & "','" & .Fields("ipdev").Value & "','" & Date.Today & "','" & sTIM & "')"

    '                DB7.Execute(sSQL)

    '            End If

    '            .MoveNext()
    '        Loop
    '    End With

    '    rs.Close()
    '    rs = Nothing

    '    sOPROS = False

    'End Sub

    'Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged

    '    ' lvPing.Items.Add(e.UserState)
    '    Dim sTXT17_ As String

    '    sTXT17_ = ""

    '    Dim sCOUNT As Integer
    '    Dim sSQL As String
    '    Dim rs As Recordset 

    '    sSQL = "SELECT * FROM TBL_DEV WHERE ipdev ='" & e.UserState & "'"


    '    rs = New Recordset
    '    rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

    '    With rs

    '        lvPing.Items.Add(.Fields("id").Value)

    '        If Not IsDBNull(.Fields("Alias").Value) Then

    '            lvPing.Items(CInt(lvPing.Items.Count - 1)).SubItems.Add(.Fields("Alias").Value)

    '        Else

    '            lvPing.Items(CInt(lvPing.Items.Count - 1)).SubItems.Add(.Fields("ipdev").Value)

    '        End If

    '        Dim net As New Net.NetworkInformation.Ping

    '        If net.Send(.Fields("IPDev").Value, 20).status = System.Net.NetworkInformation.IPStatus.Success Then

    '            lvPing.Items(CInt(lvPing.Items.Count - 1)).SubItems.Add("OK")

    '        Else

    '            lvPing.Items(CInt(lvPing.Items.Count - 1)).SubItems.Add("X")
    '            lvPing.Items(CInt(lvPing.Items.Count - 1)).BackColor = Color.Red

    '            Dim sTIM As String
    '            sTIM = TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second

    '            sSQL = "INSERT INTO TBL_PING(TipDev,IPDEV,DT,TM) VALUES('" & .Fields("TipDev").Value & "','" & .Fields("ipdev").Value & "','" & Date.Today & "','" & sTIM & "')"

    '            DB7.Execute(sSQL)

    '            Select Case sTXT17_

    '                Case ""
    '                    sTXT17_ = "Плохой пинг, либо обрыв связи для устройства: " & vbCrLf & .Fields("IPDev").Value
    '                Case Else
    '                    sTXT17_ = sTXT17_ & vbCrLf & .Fields("IPDev").Value

    '            End Select

    '        End If

    '        Dim sPIP As String

    '        If Not IsDBNull(.Fields("Alias").Value) Then

    '            sPIP = .Fields("Alias").Value

    '        Else
    '            sPIP = .Fields("ipdev").Value

    '        End If

    '        sSQL = "SELECT count(*) as t_n FROM TBL_PING WHERE IPDEV='" & sPIP & "'"

    '        Dim rs2 As Recordset 
    '        rs2 = New Recordset
    '        rs2.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

    '        With rs2
    '            sCOUNT = .Fields("t_n").Value
    '        End With
    '        rs2.Close()
    '        rs2 = Nothing

    '        Select Case sCOUNT

    '            Case 0

    '                lvPing.Items(CInt(lvPing.Items.Count - 1)).SubItems.Add("")

    '            Case Else
    '                lvPing.Items(CInt(lvPing.Items.Count - 1)).SubItems.Add("Да" & " " & sCOUNT)

    '        End Select

    '    End With

    '    rs.Close()
    '    rs = Nothing

    '    GC.Collect()

    '    Select Case sTXT17_

    '        Case ""
    '            ' sOPROS = False
    '            ' Call MESSAGE_("-------------------------")

    '        Case Else
    '            sTXT = "Пинг"
    '            Call MESSAGE_(sTXT17_)

    '    End Select

    '    lstPing_X.Items.Clear()

    '    ResList(lvPing)


    'End Sub

    Private Sub ping_re()

        If sOPROS = True Then Exit Sub

        Dim net As New Net.NetworkInformation.Ping

        Me.Invoke(Sub() lvPing.Sorting = SortOrder.None)
        Me.Invoke(Sub() lvPing.ListViewItemSorter = Nothing)

        'Dim p As New System.Net.NetworkInformation.Ping() ' получаем пинг

        zCounter = 0
        Dim intPing As Integer = 0
        Dim intj2 As Integer = 0
        Dim sTXT17_ As String

        sTXT17_ = ""

        lvPing.Items.Clear()
        Dim ssCOUNT As Integer

        Dim sTIM As String
        Dim sSQL As String
        Dim rs As Recordset

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev <>'Принтеры' AND NOT_PING <> True"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim sCOUNT As Integer

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        sSQL = "SELECT * FROM TBL_DEV WHERE TipDev <>'Принтеры' AND NOT_PING <> True ORDER BY ipdev"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF

                Me.Invoke(Sub() lvPing.Items.Add(.Fields("id").Value))
                ' lvPing.Items(CInt(zCounter)).SubItems.Add(.Fields("ipdev").Value)

                If Not IsDBNull(.Fields("Alias").Value) Then

                    Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add(.Fields("Alias").Value)) '& "(" & .Fields("ipdev").Value & ")"

                Else

                    Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add(.Fields("ipdev").Value))

                End If
                intPing = 0


                Dim sw = New Stopwatch()
                sw.Start()
START:

                Select Case net.Send(.Fields("IPDev").Value, 20).status


                    Case System.Net.NetworkInformation.IPStatus.Success

                        sw.Stop()
                        sTIM = TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second
                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add("Ok"))

                    Case System.Net.NetworkInformation.IPStatus.TimedOut

                        intPing = intPing + 1

                        Select Case intPing

                            Case 1
                                GoTo START
                            Case 2
                                GoTo START

                        End Select

                        sw.Stop()

                        sTIM = TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second

                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add("X"))
                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).BackColor = Color.Red)

                        Dim sPIP As String

                        If Not IsDBNull(.Fields("Alias").Value) Then

                            sPIP = .Fields("Alias").Value

                        Else

                            sPIP = .Fields("ipdev").Value

                        End If

                        Select Case sTXT17_

                            Case ""
                                sTXT17_ = "Обрыв связи с устройством: " & vbCrLf & sPIP
                            Case Else
                                sTXT17_ = sTXT17_ & vbCrLf & sPIP

                        End Select

                        sSQL = "INSERT INTO TBL_PING(TipDev,IPDEV,DT,TM) VALUES('" & .Fields("TipDev").Value & "','" & .Fields("ipdev").Value & "','" & Date.Today & "','" & sTIM & "')"
                        DB7.Execute(sSQL)

                    Case Else

                        intPing = intPing + 1

                        Select Case intPing

                            Case 1
                                GoTo START
                            Case 2
                                GoTo START

                        End Select

                        sw.Stop()

                        sTIM = TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second

                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add("X"))
                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).BackColor = Color.Red)

                        Dim sPIP As String

                        If Not IsDBNull(.Fields("Alias").Value) Then

                            sPIP = .Fields("Alias").Value

                        Else

                            sPIP = .Fields("ipdev").Value

                        End If

                        Select Case sTXT17_

                            Case ""
                                sTXT17_ = "Обрыв связи с устройством: " & vbCrLf & sPIP
                            Case Else
                                sTXT17_ = sTXT17_ & vbCrLf & sPIP

                        End Select

                        sSQL = "INSERT INTO TBL_PING(TipDev,IPDEV,DT,TM) VALUES('" & .Fields("TipDev").Value & "','" & .Fields("ipdev").Value & "','" & Date.Today & "','" & sTIM & "')"
                        DB7.Execute(sSQL)

                End Select


                sSQL = "INSERT INTO TBL_PING_SL(IPDEV,PING,DT,TM) VALUES('" & .Fields("ipdev").Value & "'," & sw.ElapsedMilliseconds & ",'" & Date.Today & "','" & sTIM & "')"
                DB7.Execute(sSQL)

                sSQL = "SELECT count(*) as t_n FROM TBL_PING WHERE IPDEV='" & .Fields("ipdev").Value & "'"

                Dim rs2 As Recordset
                rs2 = New Recordset
                rs2.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs2
                    ssCOUNT = .Fields("t_n").Value
                End With
                rs2.Close()
                rs2 = Nothing

                Select Case ssCOUNT

                    Case 0

                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add(""))

                    Case Else
                        Me.Invoke(Sub() lvPing.Items(CInt(zCounter)).SubItems.Add("Да" & " " & ssCOUNT))

                End Select

                zCounter = zCounter + 1

                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing

        sOPROS = False

        GC.Collect()

        Select Case sTXT17_

            Case ""
                sOPROS = False
                Call MESSAGE_("-------------------------")

            Case Else
                sTXT = "Пинг"
                Call MESSAGE_(sTXT17_)

        End Select

        Me.Invoke(Sub() lstPing_X.Items.Clear())

        ResList(lvPing)

    End Sub

    Private Sub lvPing_Click(sender As Object, e As System.EventArgs) Handles lvPing.Click

        Me.BeginInvoke(New MethodInvoker(AddressOf FOR_PING_STAT))

    End Sub

    Private Sub FOR_PING_STAT()
        lstPing_X.Items.Clear()

        If lvPing.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvPing.SelectedItems.Count - 1
            rCOUNT = (lvPing.SelectedItems(z).Text)
        Next

        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        Dim sIPtxt As String

        sIPtxt = ""

        With rs

            sIPtxt = .Fields("ipdev").Value

        End With

        rs.Close()
        rs = Nothing

        sSQL = "Select count(*) as t_n FROM TBL_PING WHERE ipdev='" & sIPtxt & "'"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else
                sSQL = "Select TOP 1440 * FROM TBL_PING WHERE ipdev='" & sIPtxt & "' ORDER BY DT desc, TM desc"

                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        lstPing_X.Items.Add(.Fields("DT").Value & "-" & .Fields("TM").Value)

                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

        End Select

        Call CHART_PING(zg1)

    End Sub

    Private Sub CHART_IBP(ByVal zgc As ZedGraphControl)
        On Error GoTo err_


        '  Graph_n(zg2)

        '######################################################################################
        Dim myPane As GraphPane = zgc.GraphPane

        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True

        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()
        zgc.Refresh()
        '######################################################################################

        On Error GoTo err_

        Dim z As Integer
        'Dim rCOUNT As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next


        If ibpCOUNT = 0 Then Exit Sub


        Dim alist1 = New PointPairList()
        alist1.Clear()
        Dim now As DateTime

        Dim sSQL As String

        Select Case RadioButton1.Checked

            Case True

                Dim uname As String = (60 / TIMEOPROS_) * 24

                If uname >= 130 Then uname = uname \ 1.5


                sSQL = "SELECT TOP " & uname & " * FROM IBP_MON WHERE IBP_ID='" & ibpCOUNT & "' order by dt desc, tm desc"

            Case False

                sSQL = "SELECT * FROM IBP_MON WHERE IBP_ID='" & ibpCOUNT & "'  order by dt desc, tm desc"

        End Select


        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        myPane.CurveList.Clear()

        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case ComboBox2.Text

                    Case "Состояние батарей"

                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("SOST_BATTARY").Value)


                    Case "Замена батарей"

                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("ZAMENA_BATTARY").Value)



                    Case "Входное напряжение"

                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("IN_TOK").Value)


                    Case "Выходное напряжение"

                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("OUT_TOK").Value)

                    Case "Исходящая частота"

                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("OUTPUT_FREQ").Value)


                    Case "Нагрузка"

                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("OUTPUT_LOAD").Value)

                    Case "Температура"
                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("TEMPERATURE").Value)

                    Case "Вольтаж батареи"
                        now = .Fields("DT").Value & " " & .Fields("TM").Value
                        Dim timestamp As Double = CDbl(New XDate(now))
                        alist1.Add(timestamp, .Fields("BATTARY_VOLTAG").Value)

                End Select

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


        '#############################################################################################
        myPane.Title.Text = ComboBox2.Text

        myPane.XAxis.Title.Text = "Время"
        myPane.YAxis.Title.Text = "Данные"
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5
        ' myPane.

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2

        ' Generate a blue curve with circle symbols, and "My Curve 2" in the legend
        Dim myCurve As LineItem = myPane.AddCurve(ComboBox2.Text, alist1, Color.Green, SymbolType.None)
        myCurve.Line.Width = 3.0F
        myCurve.Line.Style = Drawing2D.DashStyle.Solid

        myCurve.Line.Fill = New ZedGraph.Fill(Color.Green, Color.Green, 45.0F)

        myPane.Chart.Fill = New Fill(Color.LightYellow, Color.LightSlateGray)

        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        zgc.AxisChange()
        zgc.Invalidate()
        '######################################################################################

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub CHART_PRN(ByVal zgc As ZedGraphControl)
        On Error GoTo err_

        '  Graph_n(zg2)

        '######################################################################################
        Dim myPane As GraphPane = zgc.GraphPane
        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()

        myPane.Title.Text = Me.Text

        myPane.XAxis.Title.Text = "Время"
        myPane.YAxis.Title.Text = "Данные"
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 14
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5
        ' myPane.

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2
        '    Me.Invoke(Sub() myPane.Title.Text = "Объем свободного пространства на жестком диске объекта " & lstSRV.Text)

        '######################################################################################

        Dim z As Integer
        Dim ipPRN As String

        For z = 0 To lvPrinter.SelectedItems.Count - 1
            ipPRN = (lvPrinter.SelectedItems(z).SubItems(6).Text)
        Next


        If Len(ipPRN) = 0 Then Exit Sub

        Dim alist1 = New PointPairList()
        Dim blist1 = New PointPairList()

        Dim now As DateTime

        Dim sSQL As String


        '(sSQL = "SELECT * FROM TBL_PRN_MON WHERE IPprn='" & ipPRN & "'  order by dt desc, tm desc")


        Dim D1, D2 As String
        Dim dQ() As String

        dQ = Split(Date.Today, ".")
        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        dQ = Split(Date.Today.AddDays(-30), ".")
        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        sSQL = "SELECT (MAX(page)-MIN(page)) AS TN, IPprn, DT FROM TBL_PRN_MON WHERE (DT BETWEEN " & D2 & " AND " & D1 & ") AND IPprn='" & ipPRN & "' GROUP BY IPprn, DT"

        ' sSQL = "SELECT (MAX(page)-MIN(page)) AS TN, IPprn, DT FROM TBL_PRN_MON WHERE IPprn='" & ipPRN & "' GROUP BY IPprn, DT"


        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        myPane.CurveList.Clear()
        alist1.Clear()
        blist1.Clear()

        With rs
            .MoveFirst()
            Do While Not .EOF

                now = .Fields("DT").Value '& " " & .Fields("TM").Value
                Dim timestamp As Double = CDbl(New XDate(now))
                alist1.Add(timestamp, .Fields("TN").Value)

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


        sSQL = "SELECT (MAX(toner)-MIN(toner)) AS TN, IPprn, DT FROM TBL_PRN_MON WHERE (DT BETWEEN " & D2 & " AND " & D1 & ") AND IPprn='" & ipPRN & "' GROUP BY IPprn, DT"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF

                now = .Fields("DT").Value '& " " & .Fields("TM").Value
                Dim timestamp As Double = CDbl(New XDate(now))
                blist1.Add(timestamp, .Fields("TN").Value)

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        myPane.CurveList.Clear()

        '#############################################################################################
        myPane.Title.Text = "Отпечатано страниц на устройстве в день: " & ipPRN

        myPane.XAxis.Title.Text = "Время"
        myPane.YAxis.Title.Text = "Данные"
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5
        ' myPane.

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2

        '' Generate a blue curve with circle symbols, and "My Curve 2" in the legend
        'Dim myCurve As LineItem = myPane.AddCurve("Кол-во страниц", alist1, Color.Green, SymbolType.Square)
        'myCurve.Line.Width = 6.0F
        'myCurve.Line.Style = Drawing2D.DashStyle.Solid
        'myCurve.Line.Fill = New ZedGraph.Fill(Color.Green, Color.Green, 45.0F)
        ''   myPane.Chart.Fill = New Fill(Color.LightYellow, Color.LightSlateGray)


        Dim myBar As BarItem = myPane.AddBar("Кол-во страниц", alist1, Color.Red)

        Dim myBar2 As BarItem = myPane.AddBar("Кол-во тонера", blist1, Color.Blue)

        myPane.BarSettings.MinBarGap = 0.0F
        myPane.BarSettings.MinClusterGap = 2.5F
        BarItem.CreateBarLabels(myPane, True, "0")

        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        zgc.AxisChange()
        zgc.Invalidate()
        zgc.Refresh()
        '######################################################################################

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub ОткрытьВPuttyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОткрытьВPuttyToolStripMenuItem.Click

        Call OPEN_TO_PUTTY(lstVW)

    End Sub

    Private Sub OPEN_TO_PUTTY(ByVal lstVW As ListView)

        If lstVW.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2 As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With

        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            Dim protokol As String = ""
            If Not IsDBNull(.Fields("protokol").Value) Then

                protokol = .Fields("protokol").Value

            Else

                protokol = "telnet"

            End If

            uname2 = .Fields("TipDev").Value
            uname = " -" & protokol & " " & .Fields("IPDev").Value
        End With

        rs.Close()
        rs = Nothing

        If uname2 = "Сервер" Then Exit Sub

        Dim proc As New Process

        With proc
            .StartInfo.UseShellExecute = False
            .StartInfo.FileName = PuttyFilePatch
            .StartInfo.Arguments = uname
        End With
        proc.Start()



    End Sub

    Private Sub КоммутаторыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles КоммутаторыToolStripMenuItem.Click
        ExportListViewToExcel(lstComm, "Коммутаторы")
    End Sub

    Private Sub ИБПToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ИБПToolStripMenuItem.Click
        ExportListViewToExcel(lstUPS, "ИБП")
    End Sub

    Private Sub ПринтерыToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ПринтерыToolStripMenuItem.Click
        ExportListViewToExcel(lvPrinter, "Принтеры")
    End Sub

    Private Sub LOAD_SERV_HDD()
        On Error GoTo err_

        lstSRV.Items.Clear()

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev='Сервер' "

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        ' Exit Sub

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT ipdev, alias FROM TBL_DEV WHERE TipDev='Сервер' AND ping = 0 ORDER BY ipdev,alias", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                ' lstSRV.Items.Add(.Fields("ipdev").Value)

                If Not IsDBNull(.Fields("Alias").Value) Then

                    lstSRV.Items.Add(.Fields("Alias").Value)

                Else

                    lstSRV.Items.Add(.Fields("ipdev").Value)

                End If

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing


err_:
    End Sub

    Private Sub LOAD_ARDUINO()

        On Error Resume Next
        ' On Error GoTo err_

        lbApparat.Items.Clear()

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev='Arduino' "

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        ' Exit Sub

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT ipdev, alias FROM TBL_DEV WHERE TipDev='Arduino' AND ping = 0 ORDER BY ipdev,alias", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
                ' lstSRV.Items.Add(.Fields("ipdev").Value)

                If Not IsDBNull(.Fields("Alias").Value) Then

                    lbApparat.Items.Add(.Fields("Alias").Value)

                Else

                    lbApparat.Items.Add(.Fields("ipdev").Value)

                End If

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

err_:
    End Sub

    Private Sub LOAD_INF_Arduino()

        On Error Resume Next

        lvApparat.Items.Clear()
        intcount4 = 0

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        Dim tmpDat_ As DateTime
        Dim tmpDat As DateTime = Date.Today

        Dim D1, D2 As String
        Dim dQ() As String

        dQ = Split(tmpDat, ".")

        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        dQ = Split(Date.Today.AddDays(-1), ".")
        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        sSQL = "SELECT count(*) as t_n FROM TBL_ARD_SENS WHERE IPDEV='" & lbApparat.Text & "'"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        '##############################################################
        '# Рисуем график
        '##############################################################
        'Me.BeginInvoke(New MethodInvoker(AddressOf sCHART))
        Call sCHART_ARD(zgApparat)
        '##############################################################


        Select Case RadioButton9.Checked

            Case True

                dQ = Split(Date.Today, ".")
                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                dQ = Split(Date.Today.AddDays(-30), ".")
                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        End Select

        Select Case RadioButton7.Checked

            Case True

                dQ = Split(Date.Today, ".")
                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                dQ = Split(Date.Today.AddDays(-1), ".")
                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"
                '(sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc")

        End Select

        Select Case RadioButton10.Checked

            Case True

                dQ = Split(Date.Today, ".")
                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                dQ = Split(Date.Today.AddDays(-7), ".")
                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"
                '(sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc")

        End Select

        sSQL = "SELECT * FROM TBL_ARD_SENS WHERE (dt BETWEEN " & D2 & " AND " & D1 & ") AND IPDEV='" & lbApparat.Text & "' Order by id desc"

        Select Case RadioButton8.Checked

            Case True

                sSQL = "SELECT * FROM TBL_ARD_SENS WHERE IPDEV='" & lbApparat.Text & "' Order by id desc"

        End Select

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        lvApparat.Items.Clear()
        intcount4 = 0
        With rs
            .MoveFirst()
            Do While Not .EOF
                lvApparat.Items.Add(.Fields("id").Value)

                lvApparat.Items(CInt(intcount4)).SubItems.Add(.Fields("DT").Value)
                lvApparat.Items(CInt(intcount4)).SubItems.Add(.Fields("TM").Value)
                lvApparat.Items(CInt(intcount4)).SubItems.Add(.Fields("TEMP").Value & " C")
                lvApparat.Items(CInt(intcount4)).SubItems.Add(.Fields("Humi").Value & " %")

                intcount4 = intcount4 + 1
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing
        ResList(lvApparat)

        Application.DoEvents()

    End Sub

    Private Sub LOAD_INF_HDD()

        On Error Resume Next

        Dim sSID As Integer = 0

        Dim myPane As GraphPane = zg3.GraphPane
        myPane.IsBoundedRanges = True
        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()
        myPane.IsBoundedRanges = True
        myPane.Chart.Fill = New Fill(Color.LightYellow, Color.LightSlateGray)
        zg3.AxisChange()
        zg3.Invalidate()

        lvHDD.Items.Clear()


        intcount4 = 0
                Dim sSQL As String


        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"


        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub


        Dim tmpDat_ As DateTime
        Dim tmpDat As DateTime = Date.Today

        Dim D1, D2 As String
        Dim dQ() As String

        dQ = Split(tmpDat, ".")

        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        dQ = Split(Date.Today.AddDays(-1), ".")
        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE  TipDev='Сервер' AND ipdev='" & lstSRV.Text & "'"


        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sSID = .Fields("id").Value

        End With
        rs.Close()
        rs = Nothing

        If sSID = 0 Then

            sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE TipDev='Сервер' AND alias='" & lstSRV.Text & "'"

            rs = New Recordset
            rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

            With rs

                sSID = .Fields("id").Value

            End With
            rs.Close()
            rs = Nothing

        End If


        sSQL = "SELECT count(*) as t_n FROM TBL_HDD_SER WHERE ID_SERV=" & sSID

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        '##############################################################
        '# Рисуем график
        '##############################################################
        'Me.BeginInvoke(New MethodInvoker(AddressOf sCHART))
        Call sCHART(zg3)
        '##############################################################


        Select Case CheckBox3.Checked

            Case True

                dQ = Split(Date.Today, ".")
                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                dQ = Split(Date.Today.AddDays(-365), ".")
                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        End Select

        Select Case RadioButton6.Checked

            Case True

                dQ = Split(Date.Today, ".")
                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                dQ = Split(Date.Today.AddDays(-30), ".")
                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"
                '(sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc")

        End Select

        Select Case RadioButton5.Checked

            Case True

                dQ = Split(Date.Today, ".")
                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                dQ = Split(Date.Today.AddDays(-7), ".")
                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"
                '(sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc")

        End Select

        sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc, DRIVE asc"

        Select Case CheckBox2.Checked

            Case True

                sSQL = "SELECT * FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " Order by DATE desc, DRIVE asc"

        End Select


        'sSQL = "SELECT * FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " Order by DATE desc,DRIVE "

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        With rs
            .MoveFirst()
            Do While Not .EOF
                lvHDD.Items.Add(.Fields("id").Value)

                lvHDD.Items(CInt(intcount4)).SubItems.Add(.Fields("DATE").Value)
                lvHDD.Items(CInt(intcount4)).SubItems.Add(.Fields("DRIVE").Value)
                lvHDD.Items(CInt(intcount4)).SubItems.Add(.Fields("SIZE").Value & " Гб")
                lvHDD.Items(CInt(intcount4)).SubItems.Add(.Fields("FreeSize").Value & " Мб")
                lvHDD.Items(CInt(intcount4)).SubItems.Add(.Fields("Percent").Value & "%")

                intcount4 = intcount4 + 1
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing
        ResList(lvHDD)

        Application.DoEvents()

    End Sub

    Private Sub sCHART(ByVal zgc As ZedGraphControl)

        ' On Error Resume Next

        Dim uname1, uname2, uname3, uname4, uname5 As Decimal
        Dim sFREE As String

        sFREE = ""

        Dim sSQL As String

        sSQL = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='Сервер' AND ipdev='" & lstSRV.Text & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim sSID As Integer = 0

        With rs

            sSID = .Fields("tn").Value

        End With
        rs.Close()
        rs = Nothing

        Select Case sSID

            Case 0

                sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE TipDev='Сервер' AND alias='" & lstSRV.Text & "'"

                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    sSID = .Fields("id").Value

                End With
                rs.Close()
                rs = Nothing

            Case Else

                sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE TipDev='Сервер' AND ipdev='" & lstSRV.Text & "'"

                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    sSID = .Fields("id").Value

                End With
                rs.Close()
                rs = Nothing

        End Select

        'On Error GoTo err_

        Dim i1 As Integer = 0

        Dim now As Integer

        sSQL = "SELECT DRIVE FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " GROUP by DRIVE"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim uname(10) As String

        With rs
            .MoveFirst()
            Do While Not .EOF
                uname(i1) = .Fields("DRIVE").Value
                i1 = i1 + 1
                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        Dim C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z As New PointPairList()

        Dim sdDate1 As Date
        Dim sdDate2 As Date
        sdDate1 = Date.Today

        sSQL = "SELECT TOP 1 * FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " Order by DATE desc"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sdDate1 = .Fields("DATE").Value
        End With
        rs.Close()
        rs = Nothing

        sdDate2 = sdDate1.AddDays(-7)


        Dim D1, D2 As String
        Dim dQ() As String

        dQ = Split(sdDate1, ".")

        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        dQ = Split(sdDate2, ".")
        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        'Select Case CheckBox2.Checked

        '    Case True
        '        sSQL = "SELECT * FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " Order by DATE desc"
        '    Case False
        '        sSQL = "SELECT * FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " AND ([DATE] BETWEEN " & D2 & " AND " & D1 & ") Order by DATE desc"
        'End Select

        Select Case CheckBox2.Checked

            Case True

                sSQL = "SELECT * FROM TBL_HDD_SER WHERE ID_SERV=" & sSID & " Order by DATE desc, DRIVE asc"


            Case False

                Select Case CheckBox3.Checked

                    Case True

                        dQ = Split(Date.Today, ".")
                        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                        dQ = Split(Date.Today.AddDays(-365), ".")
                        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                        sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc, DRIVE asc"

                    Case False

                        Select Case RadioButton5.Checked

                            Case True

                                dQ = Split(Date.Today, ".")
                                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                dQ = Split(Date.Today.AddDays(-7), ".")
                                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc, DRIVE asc"


                            Case False

                                Select Case RadioButton6.Checked

                                    Case True

                                        dQ = Split(Date.Today, ".")
                                        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                        dQ = Split(Date.Today.AddDays(-30), ".")
                                        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                        sSQL = "SELECT * FROM TBL_HDD_SER WHERE (DATE BETWEEN " & D2 & " AND " & D1 & ") AND ID_SERV=" & sSID & " Order by DATE desc, DRIVE asc"

                                End Select


                        End Select


                End Select

                End Select



        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim z1 As Integer = 0


        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case .Fields("DRIVE").Value

                    Case "C:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        C.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "D:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        D.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "E:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        E.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "F:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        F.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "G:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        G.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "H:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        H.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "I:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        I.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "J:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        G.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "K:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        K.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "L:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        L.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "M:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        M.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "N:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        N.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "O:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        O.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "P:"

                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        P.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "Q:"

                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        Q.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "R:"

                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        R.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "S:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        S.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "T:"

                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        T.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "U:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        U.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "V:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        V.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "W:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        W.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "X:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        X.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "Y:"

                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        Y.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))
                    Case "Z:"
                        Dim now1 As DateTime
                        now1 = .Fields("DATE").Value
                        Dim timestamp As Double = CDbl(New XDate(now1))
                        Z.Add(timestamp, Math.Round((.Fields("FreeSize").Value / 1024), 2))

                End Select

                z1 = z1 + 1

                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing

        sSQL = "SELECT max(FreeSize) as f_s FROM TBL_HDD_SER WHERE ID_SERV=" & sSID '& " and freesize is not null"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sFREE = .Fields("f_s").Value / 1024 'Math.Round((.Fields("f_s") / 1), 0)

        End With
        rs.Close()
        rs = Nothing


        Dim myPane As GraphPane = zgc.GraphPane
        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()

        myPane.Title.Text = Me.Text

        myPane.XAxis.Title.Text = "Время"
        myPane.YAxis.Title.Text = "Данные"
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 14
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5
        ' myPane.

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2
        Me.Invoke(Sub() myPane.Title.Text = "Объем свободного пространства на жестком диске объекта " & lstSRV.Text)

        myPane.CurveList.Clear()

        For now = 0 To i1 - 1

            Select Case ComboBox1.Text

                Case "Гистограмма"

                    Select Case uname(now)

                        Case "C:"

                            Dim myBar As BarItem = myPane.AddBar(uname(now), C, Color.Red)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F

                        Case "D:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), D, Color.Green)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F
                            '

                        Case "E:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), E, Color.Blue)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F

                        Case "F:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), F, Color.GreenYellow)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "G:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), G, Color.Honeydew)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "H:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), H, Color.HotPink)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "I:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), I, Color.IndianRed)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "J:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), J, Color.Indigo)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "K:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), K, Color.Ivory)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "L:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), L, Color.Khaki)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "M:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), M, Color.Lavender)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "N:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), N, Color.LavenderBlush)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "O:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), O, Color.LawnGreen)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "P:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), P, Color.LemonChiffon)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "Q:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), Q, Color.LightBlue)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "R:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), R, Color.LightCoral)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "S:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), S, Color.LightCyan)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "T:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), T, Color.LightGoldenrodYellow)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "U:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), U, Color.AliceBlue)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "V:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), V, Color.AntiqueWhite)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "W:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), W, Color.Aqua)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "X:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), X, Color.Aquamarine)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F


                        Case "Y:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), Y, Color.Azure)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F

                        Case "Z:"
                            Dim myBar As BarItem = myPane.AddBar(uname(now), S, Color.Beige)
                            myPane.BarSettings.MinBarGap = 0.0F
                            myPane.BarSettings.MinClusterGap = 2.5F

                    End Select

                Case "Кривая"

                    Select Case uname(now)

                        Case "C:"

                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), C, Color.Red, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid

                            If i1 < 2 Then
                                myCurve.Line.Fill = New Fill(Color.LightSteelBlue, Color.Red, 45.0F)
                            End If

                        Case "D:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), D, Color.Green, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid

                            myCurve.Line.Fill = New Fill(Color.YellowGreen, Color.Green, 45.0F)

                        Case "E:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), E, Color.Blue, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                            myCurve.Line.Fill = New Fill(Color.LightYellow, Color.Blue, 45.0F)

                        Case "F:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), F, Color.GreenYellow, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid

                        Case "G:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), G, Color.Honeydew, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "H:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), H, Color.HotPink, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "I:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), I, Color.IndianRed, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "J:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), J, Color.Indigo, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "K:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), K, Color.Ivory, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "L:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), L, Color.Khaki, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "M:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), M, Color.Lavender, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "N:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), N, Color.LavenderBlush, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "O:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), O, Color.LawnGreen, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "P:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), P, Color.LemonChiffon, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                            myCurve.Line.Fill = New Fill(Color.LightYellow, Color.LemonChiffon, 45.0F)

                        Case "Q:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), Q, Color.Tomato, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                            myCurve.Line.Fill = New Fill(Color.LightYellow, Color.Tomato, 45.0F)

                        Case "R:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), R, Color.Turquoise, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                            myCurve.Line.Fill = New Fill(Color.LightYellow, Color.Turquoise, 45.0F)

                        Case "S:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), S, Color.Teal, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                            myCurve.Line.Fill = New Fill(Color.WhiteSmoke, Color.Teal, 45.0F)

                        Case "T:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), T, Color.LightGoldenrodYellow, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "U:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), U, Color.AliceBlue, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "V:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), V, Color.AntiqueWhite, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "W:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), W, Color.Aqua, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "X:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), X, Color.Aquamarine, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "Y:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), Y, Color.Azure, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid
                        Case "Z:"
                            Dim myCurve As LineItem = myPane.AddCurve(uname(now), S, Color.Beige, SymbolType.None)
                            myCurve.Line.Width = 3.0F
                            myCurve.Line.Style = Drawing2D.DashStyle.Solid

                    End Select


            End Select

        Next


        BarItem.CreateBarLabels(myPane, True, "0.00")

        myPane.IsBoundedRanges = True

        myPane.Chart.Fill = New Fill(Color.LightYellow, Color.LightSlateGray)
        zgc.AxisChange()
        zg3.Invalidate()


        Exit Sub
err_:
        MsgBox(Err.Description)


    End Sub

    Private Sub sCHART_ARD(ByVal zgc As ZedGraphControl)
        ' On Error GoTo err_
        'On Error Resume Next

        Dim sSQL As String

        sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE TipDev='Arduino' AND ipdev='" & lbApparat.Text & "'"

        Dim rs As Recordset
        rs = New Recordset

        Dim i1 As Integer = 0

        Dim sdDate1 As Date
        Dim sdDate2 As Date
        sdDate1 = Date.Today

        Dim Temp1, Hum1 As New PointPairList()


        sSQL = "SELECT TOP 1 * FROM TBL_ARD_SENS WHERE IPDEV='" & lbApparat.Text & "' Order by id desc"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sdDate1 = .Fields("DT").Value
        End With
        rs.Close()
        rs = Nothing

        sdDate2 = sdDate1.AddDays(-1)


        Dim D1, D2 As String
        Dim dQ() As String

        dQ = Split(sdDate1, ".")

        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        dQ = Split(sdDate2, ".")
        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

        Select Case RadioButton8.Checked

            Case True

                sSQL = "SELECT * FROM TBL_ARD_SENS WHERE IPDEV='" & lbApparat.Text & "' Order by id desc"

            Case False

                Select Case RadioButton9.Checked

                    Case True

                        dQ = Split(Date.Today, ".")
                        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                        dQ = Split(Date.Today.AddDays(-30), ".")
                        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                    Case False

                        Select Case RadioButton7.Checked

                            Case True

                                dQ = Split(Date.Today, ".")
                                D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                dQ = Split(Date.Today.AddDays(-1), ".")
                                D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                            Case False

                                Select Case RadioButton10.Checked

                                    Case True

                                        dQ = Split(Date.Today, ".")
                                        D1 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                        dQ = Split(Date.Today.AddDays(-7), ".")
                                        D2 = "#" & dQ(1) & "/" & dQ(0) & "/" & dQ(2) & "#"

                                End Select


                        End Select


                End Select

                sSQL = "SELECT * FROM TBL_ARD_SENS WHERE (DT BETWEEN " & D2 & " AND " & D1 & ") AND IPDEV='" & lbApparat.Text & "' Order by id desc"

        End Select

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim now As DateTime

        With rs
            .MoveFirst()
            Do While Not .EOF

                now = .Fields("DT").Value & " " & .Fields("TM").Value
                '  now = STR
                Dim timestamp As Double = CDbl(New XDate(now))
                Temp1.Add(timestamp, .Fields("TEMP").Value)
                Hum1.Add(timestamp, .Fields("Humi").Value)
               
                .MoveNext()
            Loop
        End With

        rs.Close()
        rs = Nothing


        'sSQL = "SELECT (MAX(page)-MIN(page)) AS TN, IPprn, DT FROM TBL_PRN_MON WHERE (DT BETWEEN " & D2 & " AND " & D1 & ") AND IPprn='" & ipPRN & "' GROUP BY IPprn, DT"
        sSQL = "SELECT (SUM(TEMP)/COUNT(*)) AS TN, min(temp) as minTN, max(temp) as MaxTN,(SUM(Humi)/COUNT(*)) AS hN, min(Humi) as minhN, max(Humi) as MaxhN  FROM TBL_ARD_SENS WHERE (DT BETWEEN " & D2 & " AND " & D1 & ") AND IPDEV='" & lbApparat.Text & "'"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim Stn As Double
        Dim mintn As Double
        Dim maxtn As Double

        Dim htn As Double
        Dim minhn As Double
        Dim maxhn As Double

        With rs
            Stn = .Fields("TN").Value
            mintn = .Fields("mintn").Value
            maxtn = .Fields("maxtn").Value

            htn = .Fields("hN").Value
            minhn = .Fields("minhn").Value
            maxhn = .Fields("maxhn").Value
        End With
        rs.Close()
        rs = Nothing




        Dim myPane As GraphPane = zgc.GraphPane
        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()

        myPane.Title.Text = Me.Text

        myPane.XAxis.Title.Text = "Время"
        myPane.YAxis.Title.Text = "Данные"
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 14
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5
        ' myPane.

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2
        Me.Invoke(Sub() myPane.Title.Text = "Температура и влажность считанные устройством - " & lbApparat.Text & ", средняя температура/влажность за период, " & Math.Round(Stn, 2) & "/" & Math.Round(htn, 2) & vbNewLine & "минимальная " & Math.Round(mintn, 2) & "/" & Math.Round(minhn, 2) & ", максимальная " & Math.Round(maxtn, 2) & "/" & Math.Round(maxhn, 2))

        myPane.CurveList.Clear()

        Dim myCurve As LineItem = myPane.AddCurve("Температура", Temp1, Color.Red, SymbolType.None)
        myCurve.Line.Width = 3.0F
        myCurve.Line.Style = Drawing2D.DashStyle.Solid

        Dim myCurve1 As LineItem = myPane.AddCurve("Влажность", Hum1, Color.Blue, SymbolType.None)
        myCurve1.Line.Width = 3.0F
        myCurve1.Line.Style = Drawing2D.DashStyle.Solid

        '   myPane.Chart.Fill = New Fill(Color.LightYellow, Color.LightSlateGray)

        zgc.AxisChange()
        zgc.Invalidate()


        Exit Sub
err_:
        MsgBox(Err.Description)

    End Sub

    Private Sub lstSRV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstSRV.Click

        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_INF_HDD))

    End Sub

    Private Sub LOAD_SERV()
        On Error GoTo err_
        Dim net As New Net.NetworkInformation.Ping

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev='Сервер' AND Ping=0 AND NOT_PING = 0"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim uname As String

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0
                Exit Sub

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV WHERE TipDev='Сервер' AND Ping=0 AND NOT_PING = 0 ORDER BY ipdev", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        Select Case net.Send(.Fields("IPDev").Value, 20).status

                            Case System.Net.NetworkInformation.IPStatus.Success
                                If Not IsDBNull(.Fields("MODEL")) Then

                                    uname = .Fields("MODEL").Value

                                Else
                                    uname = ""

                                End If

                                Dim decr As String = DecryptBytes(uname)

                                Call LOAD_WMI_3(.Fields("IPDev").Value, .Fields("CommunityDev").Value, .Fields("DevelopDev").Value, decr, .Fields("Id").Value)

                            Case Else

                        End Select

                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

                sTXT = "Cвободное пространство HDD"

                sMessage = sMessage & vbNewLine & vbNewLine & "Количество серверов для опроса: " & sCOUNT
                Call SEND_MAIL()

        End Select

err_:
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error GoTo err_

        If sOPROS = True Then

        Else
            Call LOAD_INF_HDD()
        End If

        Exit Sub
err_:

    End Sub

    Private Sub CheckBox2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox2.CheckedChanged

        'Chart1.BeginInvoke(New MethodInvoker(AddressOf sCHART))
        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_INF_HDD))
        ' Call sCHART(zg3)

    End Sub

    Public Sub SEND_MAIL()

        If sMessage = "-------------------------" Then Exit Sub
        If Len(sTXT) = 0 Then Exit Sub

        Dim Subject As String
        Dim Body As String
        Dim bAns As Boolean = True
        Dim sParams As String

        Dim sTEXT As System.Windows.Forms.TextBox
        sTEXT = New System.Windows.Forms.TextBox
        sTEXT.Multiline = True

        sTEXT.Text = "Здравствуйте " & ", " + vbCrLf + sMessage + vbCrLf + ToolStripStatusLabel1.Text


        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$
        '$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$$

        ' Exit Sub

        Subject = "SMNP Monitor:: " & sTXT

        On Error GoTo err_

        Dim objIniFile As New IniFile(PrPath & "settings.ini")


        'Dim client As New SmtpClient(SMTP_)
        Dim fromAdr As MailAddress = New MailAddress(FromEMAIL_, "SMNP Monitor", System.Text.Encoding.UTF8)
        Dim toAdr As MailAddress = New MailAddress(EMAIL_)
        Dim message As MailMessage = New MailMessage(FromEMAIL_, EMAIL_)

        '##############################
        '##############################
        '##############################

        Dim decr As String = DecryptBytes(objIniFile.GetString("General", "Password", "MsrlJmYom1y7VXvyYN9ifw=="))

        Dim client As New SmtpClient(SMTP_)

        Dim uname As String = objIniFile.GetString("General", "Port", "0")

        If uname = "0" Then

        Else
            client.Port = uname
        End If

        client.Host = objIniFile.GetString("General", "SMTP", "")

        client.EnableSsl = objIniFile.GetString("General", "USETLS", "False")

        client.Credentials = New NetworkCredential(objIniFile.GetString("SMTP", "User", ""), decr)

        If Len(client.Host) = 0 Then Exit Sub

        message.Subject = Subject
        message.SubjectEncoding = Encoding.UTF8
        message.Body = sTEXT.Text
        message.BodyEncoding = Encoding.UTF8

        client.Send(message)
        message.Dispose()
        sTEXT = Nothing

        sTEXT = Nothing

        '  sTXT_ALERT = ""
        sTXT = ""
        sTXT_ = ""
        sMessage = ""

        Exit Sub
err_:

    End Sub

    Private Sub ОткрытьRDPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОткрытьRDPToolStripMenuItem.Click

        If lvPing.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname As String
        Dim uname2 As String

        uname = ""
        uname2 = ""

        For z = 0 To lvPing.SelectedItems.Count - 1
            rCOUNT = (lvPing.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With

        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            uname2 = .Fields("TipDev").Value
            uname = " /v:" & .Fields("IPDev").Value

        End With

        rs.Close()
        rs = Nothing

        ' System.Diagnostics.Process.Start("mstsc.exe")

        If uname2 <> "Сервер" Then Exit Sub

        Dim proc As New Process

        With proc
            .StartInfo.UseShellExecute = False
            .StartInfo.FileName = "mstsc.exe"
            .StartInfo.Arguments = uname
        End With
        proc.Start()

    End Sub

    Private Sub lvPing_ColumnClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvPing.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
       lvPing.Columns(e.Column)
        Dim sort_order As System.Windows.Forms.SortOrder
        If m_SortingColumn Is Nothing Then
            sort_order = SortOrder.Ascending
        Else
            If new_sorting_column.Equals(m_SortingColumn) Then
                If m_SortingColumn.Text.StartsWith("> ") Then
                    sort_order = SortOrder.Descending
                Else
                    sort_order = SortOrder.Ascending
                End If
            Else
                sort_order = SortOrder.Ascending
            End If

            m_SortingColumn.Text = m_SortingColumn.Text.Substring(2)
        End If

        m_SortingColumn = new_sorting_column
        If sort_order = SortOrder.Ascending Then
            m_SortingColumn.Text = "> " & m_SortingColumn.Text
        Else
            m_SortingColumn.Text = "< " & m_SortingColumn.Text
        End If

        lvPing.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvPing.Sort()
    End Sub

    Private Sub lvPing_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvPing.MouseUp

        If lvPing.Items.Count = 0 Then Exit Sub
        lstVW = lvPing

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            cmenuLST.Show(CType(sender, Control), e.Location)
            ОткрытьRDPToolStripMenuItem.Visible = True
            КачествоПингToolStripMenuItem.Visible = True
            ibpRemoteControl.Visible = False
            RealtimeIBP.Visible = True
            ВходноеНапряжениеToolStripMenuItem.Visible = False
            ВыходноеНапряжениеToolStripMenuItem.Visible = False
            НагрузкаToolStripMenuItem.Visible = False
            ЗарядБатареиToolStripMenuItem.Visible = False
            ТемператураToolStripMenuItem.Visible = False
            ВольтажБатареиToolStripMenuItem.Visible = False
        Else

        End If
    End Sub

    Private Sub ОПрограммеToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ОПрограммеToolStripMenuItem.Click
        AboutBox1.ShowDialog(Me)
    End Sub

    Private Sub CHART_PING(ByVal zgc As ZedGraphControl)
        On Error GoTo err_

        Dim z As Integer
        Dim ipd As String

        For z = 0 To lvPing.SelectedItems.Count - 1
            ibpCOUNT = (lvPing.SelectedItems(z).Text)
        Next

        If ibpCOUNT = 0 Then Exit Sub

        '  Graph_n(zg1)

        Dim myPane As GraphPane = zgc.GraphPane
        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True

        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()
        zgc.Refresh()

        myPane.XAxis.Title.Text = "Время опроса"
        myPane.YAxis.Title.Text = "Время в мс."
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2


        Dim alist1 = New PointPairList()
        alist1.Clear()
        Dim now As DateTime


        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV WHERE id=" & ibpCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        With rs

            ipd = .Fields("IPDev").Value

        End With
        rs.Close()
        rs = Nothing

        myPane.Title.Text = "Прохождение команды ПИНГ для - " & ipd & " в мс."

        Select Case RadioButton3.Checked

            Case True

                sSQL = "SELECT TOP 1440 * FROM TBL_PING_SL WHERE IPDEV='" & ipd & "' order by dt desc, tm desc"

            Case False

                sSQL = "SELECT * FROM TBL_PING_SL WHERE IPDEV='" & ipd & "' order by dt desc, tm desc"

        End Select

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim STR As String

        With rs
            .MoveFirst()
            Do While Not .EOF

                STR = .Fields("DT").Value & " " & .Fields("TM").Value
                now = STR
                Dim timestamp As Double = CDbl(New XDate(now))
                alist1.Add(timestamp, .Fields("PING").Value)

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        myPane.CurveList.Clear()

        Dim myCurve As LineItem = myPane.AddCurve("Пинг", alist1, Color.Red, SymbolType.None)
        myCurve.Line.Width = 3.0F
        myCurve.Line.Style = Drawing2D.DashStyle.Solid
        'myCurve.Line.Fill = New ZedGraph.Fill(Color.White, Color.Red, 45.0F)

        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        zgc.AxisChange()
        zg1.Invalidate()

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub Graph_n(ByVal zgc As ZedGraphControl)

        Dim myPane As GraphPane = zgc.GraphPane

        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()

        Me.Invoke(Sub() myPane.Title.Text = "")

        myPane.XAxis.Title.Text = "Время"
        myPane.YAxis.Title.Text = "Данные"
        myPane.XAxis.Type = ZedGraph.AxisType.Date

        myPane.Title.FontSpec.Size = 10
        myPane.XAxis.Title.FontSpec.Size = 10
        myPane.YAxis.Title.FontSpec.Size = 10

        myPane.XAxis.MajorGrid.IsVisible = True
        myPane.XAxis.MajorGrid.DashOn = 10
        myPane.XAxis.MajorGrid.DashOff = 5

        myPane.YAxis.MajorGrid.IsVisible = True
        myPane.YAxis.MajorGrid.DashOn = 10
        myPane.YAxis.MajorGrid.DashOff = 5
        ' myPane.

        myPane.XAxis.MinorGrid.IsVisible = True
        myPane.XAxis.MinorGrid.DashOn = 1
        myPane.XAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.IsVisible = True
        myPane.YAxis.MinorGrid.DashOn = 1
        myPane.YAxis.MinorGrid.DashOff = 2

        myPane.YAxis.MinorGrid.Color = Color.Gray
        myPane.XAxis.MinorGrid.Color = Color.Gray
        myPane.Chart.Fill = New Fill(Color.LightYellow, Color.Gray)

        myPane.IsFontsScaled = False
        myPane.YAxis.Scale.MinAuto = True
        myPane.XAxis.Scale.MinAuto = True
        myPane.YAxis.Scale.MaxAuto = True
        myPane.XAxis.Scale.MaxAuto = True
        myPane.IsBoundedRanges = True

        zgc.AxisChange()
        zgc.Invalidate()

    End Sub

    Private Sub zg1_ContextMenuBuilder(sender As ZedGraphControl, menuStrip As ContextMenuStrip, mousePt As Drawing.Point, objState As ZedGraphControl.ContextMenuObjectState)
        ' !!!
        ' Переименуем (переведем на русский язык) некоторые пункты контекстного меню
        menuStrip.Items(0).Text = "Копировать"
        menuStrip.Items(1).Text = "Сохранить как картинку…"
        menuStrip.Items(2).Text = "Параметры страницы…"
        menuStrip.Items(3).Text = "Печать…"
        menuStrip.Items(4).Text = "Показывать значения в точках…"
        ' menuStrip.Items(4).Checked = True
        menuStrip.Items(5).Text = "Убрать увеличение"
        menuStrip.Items(6).Text = "Убрать все увеличение"
        menuStrip.Items(7).Text = "Установить масштаб по умолчанию…"

        ' Некоторые пункты удалим
        ' menuStrip.Items.RemoveAt(5)
        ' menuStrip.Items.RemoveAt(5)

        ' Добавим свой пункт меню
        ' Dim newMenuItem As ToolStripItem = New ToolStripMenuItem("Этот пункт меню ничего не делает")
        '  menuStrip.Items.Add(newMenuItem)
    End Sub

    'Private Sub zg3_ContextMenuBuilder(sender As ZedGraphControl, menuStrip As ContextMenuStrip, mousePt As Drawing.Point, objState As ZedGraphControl.ContextMenuObjectState)
    '    ' !!!
    '    ' Переименуем (переведем на русский язык) некоторые пункты контекстного меню
    '    menuStrip.Items(0).Text = "Копировать"
    '    menuStrip.Items(1).Text = "Сохранить как картинку…"
    '    menuStrip.Items(2).Text = "Параметры страницы…"
    '    menuStrip.Items(3).Text = "Печать…"
    '    menuStrip.Items(4).Text = "Показывать значения в точках…"
    '    ' menuStrip.Items(4).Checked = True
    '    menuStrip.Items(5).Text = "Убрать увеличение"
    '    menuStrip.Items(6).Text = "Убрать все увеличение"
    '    menuStrip.Items(7).Text = "Установить масштаб по умолчанию…"

    '    ' Некоторые пункты удалим
    '    ' menuStrip.Items.RemoveAt(5)
    '    ' menuStrip.Items.RemoveAt(5)

    '    ' Добавим свой пункт меню
    '    ' Dim newMenuItem As ToolStripItem = New ToolStripMenuItem("Этот пункт меню ничего не делает")
    '    '  menuStrip.Items.Add(newMenuItem)
    'End Sub

    'Private Sub zg2_ContextMenuBuilder(sender As ZedGraphControl, menuStrip As ContextMenuStrip, mousePt As Drawing.Point, objState As ZedGraphControl.ContextMenuObjectState)
    '    ' !!!
    '    ' Переименуем (переведем на русский язык) некоторые пункты контекстного меню
    '    menuStrip.Items(0).Text = "Копировать"
    '    menuStrip.Items(1).Text = "Сохранить как картинку…"
    '    menuStrip.Items(2).Text = "Параметры страницы…"
    '    menuStrip.Items(3).Text = "Печать…"
    '    menuStrip.Items(4).Text = "Показывать значения в точках…"
    '    ' menuStrip.Items(4).Checked = True
    '    menuStrip.Items(5).Text = "Убрать увеличение"
    '    menuStrip.Items(6).Text = "Убрать все увеличение"
    '    menuStrip.Items(7).Text = "Установить масштаб по умолчанию…"

    '    ' Некоторые пункты удалим
    '    ' menuStrip.Items.RemoveAt(5)
    '    ' menuStrip.Items.RemoveAt(5)

    '    ' Добавим свой пункт меню
    '    ' Dim newMenuItem As ToolStripItem = New ToolStripMenuItem("Этот пункт меню ничего не делает")
    '    '  menuStrip.Items.Add(newMenuItem)
    'End Sub

    Private Sub ОпроситьHDDToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОпроситьHDDToolStripMenuItem.Click

        Me.BeginInvoke(New MethodInvoker(AddressOf LOAD_SERV))

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        On Error GoTo err_

        CHART_IBP(zg2)

        Exit Sub
err_:

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged
        On Error GoTo err_

        CHART_IBP(zg2)

        Exit Sub
err_:
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged
        On Error GoTo err_
        CHART_IBP(zg2)
        Exit Sub
err_:
    End Sub

    Private Sub КачествоПингToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КачествоПингToolStripMenuItem.Click

        If lvPing.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname As String

        uname = ""

        For z = 0 To lvPing.SelectedItems.Count - 1
            rCOUNT = (lvPing.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sHOST = .Fields("IPDev").Value

        End With

        rs.Close()
        rs = Nothing

        '  Dim frmPing As frmPing = New frmPing
        frmPing.TextBox1.Text = sHOST
        frmPing.ListView1.Items.Clear()
        frmPing.ShowDialog(Me)

    End Sub

    Private Sub ibpOff_Click(sender As System.Object, e As System.EventArgs) Handles ibpOff.Click
        On Error GoTo err_

        If IBPenable = False Then
            MsgBox("Управление ИБП отключено" & vbNewLine & "включите управление, затем повторите попытку", MsgBoxStyle.Exclamation, ProductName)
            Exit Sub
        End If

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2, smodel As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
            smodel = .Fields("MODEL").Value
        End With

        rs.Close()
        rs = Nothing

        If uname2 <> "Источник бесперебойного питания" Then Exit Sub

        If MsgBox("Будет произведено отключение ИБП" & vbNewLine & "а также отключение всего подключенного к нему оборудования." & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            Dim rs1 As Recordset
            rs1 = New Recordset
            rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & smodel & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
            Dim devOIDs As String
            With rs1

                devOIDs = .Fields("UPS_OTKL_OID").Value

            End With

            rs1.Close()
            rs1 = Nothing

            Dim host As String = uname
            Dim community As String = "private"


            Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)
            Dim result As Dictionary(Of Oid, AsnType)
            Dim sysContactOid As Oid = New Oid(devOIDs)
            ' Dim sysContactNewValue As OctetString = New OctetString("3")

            Dim sysContactNewValue As SnmpSharpNet.Integer32 = New Integer32(3)

            If Not snmp.Valid Then
                MsgBox("invalid hostname\community")
                Exit Sub
            End If

            Dim vbCollection() As Vb
            Dim vb As Vb = New Vb(sysContactOid, sysContactNewValue)

            vbCollection = New Vb() {vb}

            result = snmp.Set(SnmpVersion.Ver1, vbCollection)

            If result IsNot Nothing Then
                'Dim kvp As KeyValuePair(Of Oid, AsnType)
                'For Each kvp In result
                '    Debug.Print("{0}: ({1}) {2}", kvp.Key.ToString(), SnmpConstants.GetTypeName(kvp.Value.Type), kvp.Value.ToString())
                'Next

                MsgBox("Комманда выполнена успешно", MsgBoxStyle.Information, ProductName)

            Else

                MsgBox("Комманда не выполнена", MsgBoxStyle.Critical, ProductName)

            End If

        Else

            MsgBox("Комманда отменена", MsgBoxStyle.Critical, ProductName)

        End If

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub ibpOn_Click(sender As System.Object, e As System.EventArgs) Handles ibpOn.Click
        On Error GoTo err_

        If IBPenable = False Then
            MsgBox("Управление ИБП отключено" & vbNewLine & "включите управление, затем повторите попытку", MsgBoxStyle.Exclamation, ProductName)
            Exit Sub
        End If

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2, smodel As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
            smodel = .Fields("MODEL").Value
        End With

        rs.Close()
        rs = Nothing

        If uname2 <> "Источник бесперебойного питания" Then Exit Sub

        If MsgBox("Будет произведено включение ИБП" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            Dim rs1 As Recordset
            rs1 = New Recordset
            rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & smodel & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
            Dim devOIDs As String
            With rs1

                devOIDs = .Fields("UPS_VKL_OID").Value

            End With

            rs1.Close()
            rs1 = Nothing


            Dim host As String = uname
            Dim community As String = "private"

            '1.3.6.1.4.1.318.1.1.1.6.2.2.0 Integer32 1

            Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)
            Dim result As Dictionary(Of Oid, AsnType)
            Dim sysContactOid As Oid = New Oid(devOIDs)
            ' Dim sysContactNewValue As OctetString = New OctetString("3")

            Dim sysContactNewValue As SnmpSharpNet.Integer32 = New Integer32(2)

            If Not snmp.Valid Then
                MsgBox("invalid hostname\community")
                Exit Sub
            End If

            Dim vbCollection() As Vb
            Dim vb As Vb = New Vb(sysContactOid, sysContactNewValue)

            vbCollection = New Vb() {vb}

            result = snmp.Set(SnmpVersion.Ver1, vbCollection)

            If result IsNot Nothing Then
                'Dim kvp As KeyValuePair(Of Oid, AsnType)
                'For Each kvp In result
                '    Debug.Print("{0}: ({1}) {2}", kvp.Key.ToString(), SnmpConstants.GetTypeName(kvp.Value.Type), kvp.Value.ToString())
                'Next

                MsgBox("Комманда выполнена успешно", MsgBoxStyle.Information, ProductName)

            Else

                MsgBox("Комманда не выполнена", MsgBoxStyle.Critical, ProductName)

            End If

        Else

            MsgBox("Комманда отменена", MsgBoxStyle.Critical, ProductName)

        End If

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub ibpTest_Click(sender As System.Object, e As System.EventArgs) Handles ibpTest.Click
        On Error GoTo err_

        If IBPenable = False Then
            MsgBox("Управление ИБП отключено" & vbNewLine & "включите управление, затем повторите попытку", MsgBoxStyle.Exclamation, ProductName)
            Exit Sub
        End If

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2, smodel As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
            smodel = .Fields("MODEL").Value
        End With

        rs.Close()
        rs = Nothing

        If uname2 <> "Источник бесперебойного питания" Then Exit Sub

        If MsgBox("Будет произведено тестирование ИБП" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            Dim rs1 As Recordset
            rs1 = New Recordset
            rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & smodel & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
            Dim devOIDs As String
            With rs1

                devOIDs = .Fields("UPS_TEST_OID").Value

            End With

            rs1.Close()
            rs1 = Nothing


            Dim host As String = uname
            Dim community As String = "private"

            '1.3.6.1.4.1.318.1.1.1.6.2.2.0 Integer32 1

            Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)
            Dim result As Dictionary(Of Oid, AsnType)
            Dim sysContactOid As Oid = New Oid(devOIDs)
            ' Dim sysContactNewValue As OctetString = New OctetString("3")

            Dim sysContactNewValue As SnmpSharpNet.Integer32 = New Integer32(2)

            If Not snmp.Valid Then
                MsgBox("invalid hostname\community")
                Exit Sub
            End If

            Dim vbCollection() As Vb
            Dim vb As Vb = New Vb(sysContactOid, sysContactNewValue)

            vbCollection = New Vb() {vb}

            result = snmp.Set(SnmpVersion.Ver1, vbCollection)

            If result IsNot Nothing Then
                'Dim kvp As KeyValuePair(Of Oid, AsnType)
                'For Each kvp In result
                '    Debug.Print("{0}: ({1}) {2}", kvp.Key.ToString(), SnmpConstants.GetTypeName(kvp.Value.Type), kvp.Value.ToString())
                'Next

                MsgBox("Комманда выполнена успешно", MsgBoxStyle.Information, ProductName)

            Else

                MsgBox("Комманда не выполнена", MsgBoxStyle.Critical, ProductName)

            End If

        Else

            MsgBox("Комманда отменена", MsgBoxStyle.Critical, ProductName)

        End If

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub calibrationIBP_Click(sender As System.Object, e As System.EventArgs) Handles calibrationIBP.Click
        On Error GoTo err_

        If IBPenable = False Then
            MsgBox("Управление ИБП отключено" & vbNewLine & "включите управление, затем повторите попытку", MsgBoxStyle.Exclamation, ProductName)
            Exit Sub
        End If

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2, smodel As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
            smodel = .Fields("MODEL").Value
        End With

        rs.Close()
        rs = Nothing

        If uname2 <> "Источник бесперебойного питания" Then Exit Sub

        If MsgBox("Будет произведена калибровка ИБП" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            Dim rs1 As Recordset
            rs1 = New Recordset
            rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & smodel & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
            Dim devOIDs As String
            With rs1

                devOIDs = .Fields("UPS_KALIBR_OID").Value

            End With

            rs1.Close()
            rs1 = Nothing

            Dim host As String = uname
            Dim community As String = "private"

            '1.3.6.1.4.1.318.1.1.1.6.2.2.0 Integer32 1

            Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)
            Dim result As Dictionary(Of Oid, AsnType)
            Dim sysContactOid As Oid = New Oid(devOIDs)
            ' Dim sysContactNewValue As OctetString = New OctetString("3")

            Dim sysContactNewValue As SnmpSharpNet.Integer32 = New Integer32(2)

            If Not snmp.Valid Then
                MsgBox("invalid hostname\community")
                Exit Sub
            End If

            Dim vbCollection() As Vb
            Dim vb As Vb = New Vb(sysContactOid, sysContactNewValue)

            vbCollection = New Vb() {vb}

            result = snmp.Set(SnmpVersion.Ver1, vbCollection)

            If result IsNot Nothing Then
                'Dim kvp As KeyValuePair(Of Oid, AsnType)
                'For Each kvp In result
                '    Debug.Print("{0}: ({1}) {2}", kvp.Key.ToString(), SnmpConstants.GetTypeName(kvp.Value.Type), kvp.Value.ToString())
                'Next

                MsgBox("Комманда выполнена успешно", MsgBoxStyle.Information, ProductName)

            Else

                MsgBox("Комманда не выполнена", MsgBoxStyle.Critical, ProductName)

            End If

        Else

            MsgBox("Комманда отменена", MsgBoxStyle.Critical, ProductName)

        End If

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub enableIBP_Click(sender As System.Object, e As System.EventArgs) Handles enableIBP.Click

        If IBPenable = True Then

            IBPenable = False
            lblEnableIbp.Text = "Управление ИБП: Выключено"
            lblEnableIbp.ForeColor = Color.Red
            Exit Sub

        End If

        If MsgBox("Будет включена возможность управления ИБП" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            returnedPW = InputBox("Введите мастер пароль для включения управления ИБП!", inputTitle, "password", 0)

            If Not returnedPW = Nothing AndAlso returnedPW = Chr(76) + Chr(102) + Chr(112) + Chr(108) + Chr(104) + Chr(102) + Chr(49) + Chr(118) + Chr(102) + Chr(33) Then

                IBPenable = True
                lblEnableIbp.Text = "Управление ИБП: Включено"
                lblEnableIbp.ForeColor = Color.Green

            Else

                MessageBox.Show("Не верный пароль!" & vbCrLf & "ПОДСКАЗКА - Мир, Труд, Май!", " Попробуйте еще раз")

            End If

        End If
    End Sub

    Private Sub ВходноеНапряжениеToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ВходноеНапряжениеToolStripMenuItem.Click

        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("IN_TOK_OID")

                    Dim rs1 As Recordset
                    rs1 = New Recordset
                    rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & frmRTGraph.MODEL & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmRTGraph.Text = "Входное напряжение ИБП: " & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("MODEL_OID").Value, frmRTGraph.DEVELOP) & "\" & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("LOCATION_OID").Value, frmRTGraph.DEVELOP)

                    End With

                    rs1.Close()
                    rs1 = Nothing

                    ' frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select
    End Sub

    Private Sub ВыходноеНапряжениеToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ВыходноеНапряжениеToolStripMenuItem.Click
        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("OUT_TOK_OID")


                    Dim rs1 As Recordset
                    rs1 = New Recordset
                    rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & frmRTGraph.MODEL & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmRTGraph.Text = "Выходное напряжение ИБП: " & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("MODEL_OID").Value, frmRTGraph.DEVELOP) & "\" & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("LOCATION_OID").Value, frmRTGraph.DEVELOP)

                    End With

                    rs1.Close()
                    rs1 = Nothing

                    'frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select
    End Sub

    Private Sub ТемператураToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ТемператураToolStripMenuItem.Click
        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("TEMPERATURE_OID")

                    Dim rs1 As Recordset
                    rs1 = New Recordset
                    rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & frmRTGraph.MODEL & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmRTGraph.Text = "Температура батарей ИБП: " & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("MODEL_OID").Value, frmRTGraph.DEVELOP) & "\" & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("LOCATION_OID").Value, frmRTGraph.DEVELOP)

                    End With

                    rs1.Close()
                    rs1 = Nothing

                    'frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select
    End Sub

    Private Sub НагрузкаToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles НагрузкаToolStripMenuItem.Click

        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("OUTPUT_LOAD_OID")

                    Dim rs1 As Recordset
                    rs1 = New Recordset
                    rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & frmRTGraph.MODEL & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmRTGraph.Text = "Нагрузка ИБП: " & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("MODEL_OID").Value, frmRTGraph.DEVELOP) & "\" & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("LOCATION_OID").Value, frmRTGraph.DEVELOP)

                    End With

                    rs1.Close()
                    rs1 = Nothing

                    'frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select
    End Sub

    Private Sub ЗарядБатареиToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ЗарядБатареиToolStripMenuItem.Click
        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("ZARIAD_BATTARY_OID")

                    Dim rs1 As Recordset
                    rs1 = New Recordset
                    rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & frmRTGraph.MODEL & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmRTGraph.Text = "Заряд батареи ИБП: " & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("MODEL_OID").Value, frmRTGraph.DEVELOP) & "\" & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("LOCATION_OID").Value, frmRTGraph.DEVELOP)

                    End With

                    rs1.Close()
                    rs1 = Nothing

                    'frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing
        End Select
    End Sub

    Private Sub ВольтажБатареиToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ВольтажБатареиToolStripMenuItem.Click
        If lstUPS.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstUPS.SelectedItems.Count - 1
            ibpCOUNT = (lstUPS.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("BATTARY_VOLTAG_OID")

                    Dim rs1 As Recordset
                    rs1 = New Recordset
                    rs1.Open("SELECT * FROM TBL_DEV_OID where MODEL='" & frmRTGraph.MODEL & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs1

                        frmRTGraph.Text = "Вольтаж батареи ИБП: " & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("MODEL_OID").Value, frmRTGraph.DEVELOP) & "\" & REQUEST2(frmRTGraph.IPDEV, frmRTGraph.COMMDEV, .Fields("LOCATION_OID").Value, frmRTGraph.DEVELOP)

                    End With

                    rs1.Close()
                    rs1 = Nothing

                    ' frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing
        End Select
    End Sub

    Private Sub ПингToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ПингToolStripMenuItem.Click

        If lstVW.Items.Count = 0 Then Exit Sub

        Dim z As Integer

        For z = 0 To lstVW.SelectedItems.Count - 1
            ibpCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Dim frmRTGraph As frmRTGraph = New frmRTGraph

                    frmRTGraph.DEVELOP = .Fields("DevelopDev").Value
                    frmRTGraph.MODEL = .Fields("MODEL").Value
                    frmRTGraph.IPDEV = .Fields("IPDev").Value
                    frmRTGraph.COMMDEV = .Fields("CommunityDev").Value

                    Call frmRTGraph.ZaprosOID("PING")

                    frmRTGraph.Text = "Пинг: " & frmRTGraph.IPDEV


                    ' frmRTGraph.Text = "Графики реального времени"
                    frmRTGraph.Show()
                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing


        End Select

    End Sub

    'Private Sub TracerouteToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TracerouteToolStripMenuItem.Click
    '    If lstVW.Items.Count = 0 Then Exit Sub

    '    Dim z As Integer

    '    For z = 0 To lstVW.SelectedItems.Count - 1
    '        ibpCOUNT = (lstVW.SelectedItems(z).Text)
    '    Next

    '    Dim sSQL As String

    '    sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

    '    Dim rs As Recordset
    '    rs = New Recordset
    '    rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

    '    With rs
    '        sCOUNT = .Fields("t_n").Value
    '    End With
    '    rs.Close()
    '    rs = Nothing

    '    Select Case sCOUNT

    '        Case 0

    '        Case Else

    '            rs = New Recordset
    '            rs.Open("SELECT * FROM TBL_DEV where id =" & ibpCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

    '            With rs

    '                Dim frmRTGraph As frmRTGraph = New frmRTGraph


    '                frmRTGraph.IPDEV = .Fields("IPDev").Value


    '            End With
    '            rs.Close()
    '            rs = Nothing


    '            Dim traceObj As New TraceClass.MLtekTraceClass

    '            Dim Results As ArrayList = traceObj.GetTrace("www.google.co.uk")


    '            For Each result As String In Results
    '                MessageBox.Show(result)
    '            Next



    '    End Select
    'End Sub

    Private Sub lvPing_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvPing.SelectedIndexChanged
        Me.BeginInvoke(New MethodInvoker(AddressOf FOR_PING_STAT))
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton3.CheckedChanged
        CHART_PING(zg3)
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton4.CheckedChanged
        CHART_PING(zg3)
    End Sub

    Private Sub СжатьБазуToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles СжатьБазуToolStripMenuItem.Click
        On Error GoTo err_

        Call COMPARE_DB()

err_:
    End Sub

    Private Sub lstSRV_EnabledChanged(sender As Object, e As System.EventArgs) Handles lstSRV.EnabledChanged

    End Sub

    Private Sub lstSRV_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles lstSRV.MouseUp

        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            MnuWMI.Show(CType(sender, Control), e.Location)
        Else

        End If

    End Sub

    Private Sub ОпроситьСерверToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОпроситьСерверToolStripMenuItem.Click
        On Error Resume Next
        Dim sSID As Integer = 0
        Dim net As New Net.NetworkInformation.Ping

        'lvHDD.Items.Clear()
        intcount4 = 0

        Dim sSQL As String

        sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE TipDev='Сервер' AND ipdev='" & lstSRV.Text & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sSID = .Fields("id").Value

        End With
        rs.Close()
        rs = Nothing

        If sSID = 0 Then

            sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE TipDev='Сервер' AND alias='" & lstSRV.Text & "'"

            rs = New Recordset
            rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

            With rs

                sSID = .Fields("id").Value

            End With
            rs.Close()
            rs = Nothing

        End If

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & sSID, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim uname As String
        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case net.Send(.Fields("IPDev").Value, 20).status

                    Case System.Net.NetworkInformation.IPStatus.Success
                        If Not IsDBNull(.Fields("MODEL")) Then

                            uname = .Fields("MODEL").Value

                        Else
                            uname = ""

                        End If

                        Dim decr As String = DecryptBytes(uname)

                        Call LOAD_WMI_3(.Fields("IPDev").Value, .Fields("CommunityDev").Value, .Fields("DevelopDev").Value, decr, .Fields("Id").Value)

                    Case Else

                End Select

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

    End Sub

    Private Sub EventLogToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EventLogToolStripMenuItem.Click

        Call LoadEName_and_Password("Event", lstSRV.Text)


    End Sub

    Private Sub LoadEName_and_Password(ByVal sOpt As String, ByVal ip As String)

        On Error GoTo err_
        Dim sSID As Integer = 0
        Dim net As New Net.NetworkInformation.Ping

        'lvHDD.Items.Clear()
        intcount4 = 0

        Dim sSQL As String


        sSQL = "SELECT count(*) as tn FROM TBL_DEV WHERE IPDev='" & ip & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sSID = .Fields("tn").Value

        End With
        rs.Close()
        rs = Nothing


        Select Case sSID

            Case 0

                sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE alias='" & ip & "'"

            Case Else

                sSQL = "SELECT ipdev,id FROM TBL_DEV WHERE IPDev='" & ip & "'"

        End Select

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sSID = .Fields("id").Value

        End With
        rs.Close()
        rs = Nothing





        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & sSID, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim uname As String
        With rs
            .MoveFirst()
            Do While Not .EOF

                Select Case net.Send(.Fields("IPDev").Value, 20).status

                    Case System.Net.NetworkInformation.IPStatus.Success
                        If Not IsDBNull(.Fields("MODEL")) Then

                            uname = .Fields("MODEL").Value

                        Else
                            uname = ""

                        End If

                        '   Dim decr As String = DecryptBytes(uname)

                        strComputer1 = .Fields("IPDev").Value
                        Authority1 = .Fields("CommunityDev").Value
                        wmiUser1 = .Fields("DevelopDev").Value
                        wmiPasword1 = uname
                        ssID1 = .Fields("Id").Value
                        Journal1 = "Система"

                        Select Case sOpt

                            Case "Event"

                                frmSRV.DateTimePicker1.Value = Date.Today.AddDays(-2)

                                frmSRV.Show()

                            Case "Anti"


                        End Select





                    Case Else

                End Select

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub GET_ANT_START()

        Do

            Me.Invoke(Sub() lvAnti.Items.Clear())
            Me.Invoke(Sub() lvAnti.SmallImageList = il70)

            Dim net As New Net.NetworkInformation.Ping

            Dim sSql As String

            sSql = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='АРМ' AND Anti=True"

            Dim sCOUNT As Integer

            Dim rs As Recordset
            rs = New Recordset
            rs.Open(sSql, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

            With rs

                sCOUNT = .Fields("tn").Value

            End With
            rs.Close()
            rs = Nothing


            Dim a As IPHostEntry
            Dim intj As Integer = 0
            Dim uname As Integer
            Dim item As ListViewItem

            Select Case sCOUNT

                Case 0


                Case Else

                    sSql = "SELECT * FROM TBL_DEV WHERE TipDev='АРМ' AND Anti=True"

                    rs = New Recordset
                    rs.Open(sSql, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs
                        .MoveFirst()
                        Do While Not .EOF

                            Select Case net.Send(.Fields("IPDev").Value, 100).status

                                Case System.Net.NetworkInformation.IPStatus.Success

                                    a = Dns.GetHostEntry(.Fields("IPDev").Value)

                                    ' Dim zzz As String = Dns.GetHostEntry(My.Computer.Name).AddressList(1).ToString

                                    '  get_WSUS(.Fields("IPDev").Value)


                                    If Dns.GetHostEntry(My.Computer.Name).HostName.ToString = a.HostName.ToString Then

                                        get_Anti_(.Fields("IPDev").Value)

                                    Else
                                        get_Anti(.Fields("IPDev").Value)

                                    End If



                                    'If .Fields("IPDev").Value = Dns.GetHostEntry(My.Computer.Name).AddressList(1).ToString Then

                                    '    get_Anti_(.Fields("IPDev").Value)

                                    'Else

                                    '    get_Anti(.Fields("IPDev").Value)

                                    'End If

                                    '  get_Anti(.Fields("IPDev").Value)


                                    Select Case ANTI_S

                                        Case "Обновлен и включен" '"Up to date Enabled"

                                            uname = 2

                                        Case Else

                                            uname = 1

                                    End Select


                                    Me.Invoke(Sub() item = lvAnti.Items.Add(.Fields("id").Value))
                                    Me.Invoke(Sub() item.ImageIndex = uname)


                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(a.HostName.ToString))

                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(ANTIV))


                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(ANTI_S))

                                    Select Case uname

                                        Case 1

                                            Me.Invoke(Sub() lvAnti.Items(CInt(intj)).BackColor = Color.Red)
                                            Me.Invoke(Sub() lvAnti.Items(CInt(intj)).ForeColor = Color.White)
                                        Case 2

                                            Me.Invoke(Sub() lvAnti.Items(CInt(intj)).BackColor = Color.LightGreen)

                                    End Select

                                    ' Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(ANTI_S))

                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add("Доступен " & DateAndTime.TimeOfDay))

                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(DateTime.Today & " " & DateAndTime.TimeOfDay))

                                    'Дата обновления
                                    '  Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(tmpWSUS))

                                    intj = intj + 1


                                Case Else

                                    Me.Invoke(Sub() item = lvAnti.Items.Add(.Fields("id").Value))
                                    Me.Invoke(Sub() item.ImageIndex = 1)


                                    ' a = Dns.GetHostEntry(.Fields("IPDev").Value)
                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value))

                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(""))
                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(""))
                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add("Не доступен " & DateAndTime.TimeOfDay))
                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(DateTime.Today & " " & DateAndTime.TimeOfDay))
                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).BackColor = Color.LightGray)
                                    'Дата обновления
                                    ' Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add("Не доступен " & DateAndTime.TimeOfDay))

                                    intj = intj + 1

                            End Select




                            .MoveNext()
                        Loop
                    End With
                    rs.Close()
                    rs = Nothing

            End Select

            '###############################################
            'SERVERS
            'TipDev='АРМ' AND Ping=False AND Anti=True
            sSql = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev='Сервер' AND Ping=False AND NOT_PING =False AND Anti=True"

            rs = New Recordset
            rs.Open(sSql, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


            With rs
                sCOUNT = .Fields("t_n").Value
            End With
            rs.Close()
            rs = Nothing
            Dim suname As String

            Select Case sCOUNT

                Case 0

                    Exit Sub

                Case Else

                    rs = New Recordset
                    rs.Open("SELECT * FROM TBL_DEV WHERE TipDev='Сервер' AND Ping=False AND NOT_PING =False AND Anti=True ORDER BY ipdev", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs
                        .MoveFirst()
                        Do While Not .EOF

                            Select Case net.Send(.Fields("IPDev").Value, 20).status

                                Case System.Net.NetworkInformation.IPStatus.Success

                                    If Not IsDBNull(.Fields("MODEL")) Then

                                        suname = .Fields("MODEL").Value

                                    Else
                                        suname = ""

                                    End If

                                    Dim decr As String = DecryptBytes(suname)


                                    '    Call LOAD_WMI_3(.Fields("IPDev").Value, .Fields("CommunityDev").Value, .Fields("DevelopDev").Value, decr, .Fields("Id").Value)

                                    Dim aTt As Boolean = False

                                    Try

                                        a = Dns.GetHostEntry(.Fields("IPDev").Value)

                                    Catch ex As Exception

                                        aTt = True

                                    End Try

                                    get_Anti2(.Fields("IPDev").Value)


                                    Select Case ANTI_S

                                        Case "Обновлен и включен"

                                            uname = 2

                                        Case "Сервис запущен"

                                            uname = 2

                                        Case Else

                                            uname = 1

                                    End Select


                                    Me.Invoke(Sub() item = lvAnti.Items.Add(.Fields("id").Value))
                                    Me.Invoke(Sub() item.ImageIndex = uname)

                                    Select Case aTt

                                        Case False
                                            Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(a.HostName.ToString))

                                        Case Else
                                            Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value))

                                    End Select



                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(ANTIV))
                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(ANTI_S))

                                    Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add("Доступен " & DateAndTime.TimeOfDay))

                                    'Дата обновления
                                    '  Me.Invoke(Sub() lvAnti.Items(CInt(intj)).SubItems.Add(tmpWSUS))

                                    intj = intj + 1


                                Case Else



                            End Select

                            .MoveNext()
                        Loop
                    End With
                    rs.Close()

            End Select

            Threading.Thread.Sleep(3600000)

        Loop

    End Sub

    Dim ANTIV As String
    Dim ANTI_S As String
    Dim tmpWSUS As DateTime = Date.Today.AddMonths(-6)

    Private Sub get_WSUS(ByVal ip As String)
        Call LoadEName_and_Password("Anti", ip)
        tmpWSUS = Date.Today.AddMonths(-6)

        ' On Error GoTo err_
        ' sSql = "SELECT * FROM AntiVirusProduct"

        Try

            Dim connection As New ConnectionOptions
            connection.Username = wmiUser1
            connection.Password = DecryptBytes(wmiPasword1)
            connection.Authority = "ntlmdomain:" & Authority1

            Dim scope As New ManagementScope("\\" & ip & "\root\CIMV2", connection)
            scope.Connect()

            Dim query As New ObjectQuery("SELECT InstalledOn FROM Win32_QuickFixEngineering")
            Dim searcher As New ManagementObjectSearcher(scope, query)
            Dim arr As New ArrayList()

            For Each queryObj As ManagementObject In searcher.Get()

                Dim d() As String
                d = Split(queryObj("InstalledOn"), "/")

                If Len(d(1)) = 1 Then d(1) = "0" & d(1)
                If Len(d(0)) = 1 Then d(0) = "0" & d(0)

                arr.Add(d(1) & "." & d(0) & "." & d(2))
            Next

            arr.Sort()


            Dim MinDate As DateTime = Date.Today.AddDays(-60)
            Dim MaxDate As DateTime = DateTime.Now

            For Each CurrentDate As DateTime In arr

                If MinDate < CurrentDate Then
                    MinDate = CurrentDate
                End If
                If MaxDate > CurrentDate Then
                    MaxDate = CurrentDate
                End If
            Next

            tmpWSUS = MinDate

        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Dim intj As Integer = 0

    Private Sub GET_WSUS_(ByVal ip As String)
        ' On Error GoTo err_

        Try
            tmpWSUS = Date.Today.AddMonths(-6)

            '#####################################################################################
            Dim searcher As New ManagementObjectSearcher("root\CIMV2", "SELECT InstalledOn FROM Win32_QuickFixEngineering")

            intj = 0

            Dim arr As New ArrayList()

            For Each queryObj As ManagementObject In searcher.Get()

                Dim d() As String
                d = Split(queryObj("InstalledOn"), "/")

                If Len(d(1)) = 1 Then d(1) = "0" & d(1)
                If Len(d(0)) = 1 Then d(0) = "0" & d(0)

                arr.Add(d(1) & "." & d(0) & "." & d(2))

            Next

            Dim MinDate As DateTime = Date.Today.AddDays(-60)
            Dim MaxDate As DateTime = DateTime.Now

            For Each CurrentDate As DateTime In arr

                If MinDate < CurrentDate Then
                    MinDate = CurrentDate
                End If
                If MaxDate > CurrentDate Then
                    MaxDate = CurrentDate
                End If
            Next

            tmpWSUS = MinDate
        Catch ex As Exception

        End Try

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub GET_WSUS_START()

        Do
            ' Threading.Thread.Sleep(50000)

            Me.Invoke(Sub() lvSystem.Items.Clear())
            Me.Invoke(Sub() lvSystem.SmallImageList = il70)

            Dim net As New Net.NetworkInformation.Ping

            Dim sSql As String

            sSql = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='АРМ' AND Anti=True"

            Dim sCOUNT As Integer

            Dim rs As Recordset
            rs = New Recordset
            rs.Open(sSql, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

            With rs

                sCOUNT = .Fields("tn").Value

            End With
            rs.Close()
            rs = Nothing

            Dim a As IPHostEntry
            Dim intj As Integer = 0
            Dim uname As Integer
            Dim item As ListViewItem

            Select Case sCOUNT

                Case 0

                Case Else

                    sSql = "SELECT * FROM TBL_DEV WHERE TipDev='АРМ' AND Anti=True"

                    rs = New Recordset
                    rs.Open(sSql, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                    With rs
                        .MoveFirst()
                        Do While Not .EOF

                            Me.Invoke(Sub() Label1.Text = "..............")

                            Select Case net.Send(.Fields("IPDev").Value, 20).status

                                Case System.Net.NetworkInformation.IPStatus.Success

                                    a = Dns.GetHostEntry(.Fields("IPDev").Value)

                                    '   Dim zzz As String = Dns.GetHostEntry(My.Computer.Name).AddressList(0).ToString
                                    '   Dim zzz1 As String = Dns.GetHostEntry(My.Computer.Name).AddressList(1).ToString
                                    '   Dim zzz2 As String = Dns.GetHostEntry(My.Computer.Name).AddressList(2).ToString


                                    Select Case Dns.GetHostEntry(My.Computer.Name).HostName.ToString
                                        Case a.HostName.ToString

                                            Me.Invoke(Sub() Label1.Text = "Опрашивается: " & a.HostName.ToString)
                                            GET_WSUS_(.Fields("IPDev").Value)

                                        Case Else

                                            Me.Invoke(Sub() Label1.Text = "Опрашивается: " & a.HostName.ToString)
                                            get_WSUS(.Fields("IPDev").Value)


                                    End Select

                                    'If .Fields("IPDev").Value = Dns.GetHostEntry(My.Computer.Name).AddressList(2).ToString Then

                                    '    Me.Invoke(Sub() Label1.Text = "Опрашивается: " & a.HostName.ToString)
                                    '    GET_WSUS_(.Fields("IPDev").Value)

                                    'Else
                                    '    Me.Invoke(Sub() Label1.Text = "Опрашивается: " & a.HostName.ToString)
                                    '    get_WSUS(.Fields("IPDev").Value)

                                    'End If


                                    Me.Invoke(Sub() item = lvSystem.Items.Add(.Fields("id").Value))

                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(a.HostName.ToString))

                                    Dim sTM As String
                                    If tmpWSUS = Date.Today.AddDays(-60) Then
                                        sTM = "Не удалось получить доступ к системе"
                                    Else
                                        sTM = tmpWSUS
                                    End If

                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(sTM))
                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(DateTime.Today & " " & DateAndTime.TimeOfDay))

                                    Dim age As Integer
                                    age = DateDiff(DateInterval.Day, Date.Today, tmpWSUS)

                                    If age < -30 Then

                                        Me.Invoke(Sub() lvSystem.Items(CInt(intj)).BackColor = Color.Red)
                                        Me.Invoke(Sub() lvSystem.Items(CInt(intj)).ForeColor = Color.White)

                                    Else

                                        Me.Invoke(Sub() lvSystem.Items(CInt(intj)).BackColor = Color.LightGreen)


                                    End If


                                    ' Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add("Доступен " & DateAndTime.TimeOfDay))
                                    ' Дата(обновления)
                                    ' Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(tmpWSUS))

                                    intj = intj + 1

                                Case Else

                                    Me.Invoke(Sub() item = lvSystem.Items.Add(.Fields("id").Value))
                                    'Me.Invoke(Sub() item.ImageIndex = 1)

                                    ' Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value))

                                    ' a = Dns.GetHostEntry(.Fields("IPDev").Value)
                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value))
                                    'Alias

                                    ' Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(""))
                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add("Не доступен " & DateAndTime.TimeOfDay))
                                    'Дата обновления
                                    ' Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add("Не доступен " & DateAndTime.TimeOfDay))

                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).SubItems.Add(DateTime.Today & " " & DateAndTime.TimeOfDay))

                                    Me.Invoke(Sub() lvSystem.Items(CInt(intj)).BackColor = Color.LightGray)

                                    intj = intj + 1

                            End Select

                            .MoveNext()
                        Loop
                    End With
                    rs.Close()
                    rs = Nothing

            End Select


            Me.Invoke(Sub() Label1.Text = "Следующий опрос в: " & DateAndTime.TimeOfDay.AddHours(+4))
            Threading.Thread.Sleep(14400000)

        Loop
        Exit Sub
err_:

    End Sub

    Private Sub get_Anti(ByVal ip As String)
        Call LoadEName_and_Password("Anti", ip)

        ' On Error GoTo err_
        ' sSql = "SELECT * FROM AntiVirusProduct"

        Try
            Dim connection As New ConnectionOptions
            connection.Username = wmiUser1
            connection.Password = DecryptBytes(wmiPasword1)
            connection.Authority = "ntlmdomain:" & Authority1

            Dim scope As New ManagementScope("\\" & ip & "\root\SecurityCenter2", connection)
            scope.Connect()
            Dim query As New ObjectQuery("SELECT * FROM AntiVirusProduct")

            Dim searcher As New ManagementObjectSearcher(scope, query)

            For Each queryObj As ManagementObject In searcher.Get()

                ANTIV = queryObj("displayName")
                ANTI_S = queryObj("productState")

                Select Case ANTI_S
                    Case "262144"
                        ANTI_S = "Обновлен и отключен"
                    Case "262160"
                        ANTI_S = "Не обновлен и отключен"
                    Case "266240"
                        ANTI_S = "Обновлен и включен"
                    Case "266256"
                        ANTI_S = "Не обновлен и включен"
                    Case "393216"
                        ANTI_S = "Обновлен и отключен"
                    Case "393232"
                        ANTI_S = "Не обновлен и отключен"
                    Case "393488"
                        ANTI_S = "Не обновлен и отключен"
                    Case "397312"
                        ANTI_S = "Обновлен и включен"
                    Case "397328"
                        ANTI_S = "Не обновлен и включен"
                    Case "397584"
                        ANTI_S = "Не обновлен и включен"
                    Case "462848"
                        ANTI_S = "Обновлен и включен"
                    Case "462864"
                        ANTI_S = "Не обновлен и включен"
                    Case Else
                        ANTI_S = "Состояние не определено"
                End Select

            Next
        Catch ex As Exception
            ANTI_S = "UNCNOwN"
            ANTIV = "UNCNOwN"
        End Try

        Exit Sub
err_:

    End Sub

    Private Sub get_Anti2(ByVal ip As String)

        Call LoadEName_and_Password("Anti", ip)

        On Error GoTo err_
        ' sSql = "SELECT * FROM AntiVirusProduct"
        Dim connection As New ConnectionOptions
        connection.Username = wmiUser1
        connection.Password = DecryptBytes(wmiPasword1)
        connection.Authority = "ntlmdomain:" & Authority1

        Dim scope As New ManagementScope("\\" & ip & "\root\CIMV2", connection)
        scope.Connect()
        Dim query As New ObjectQuery("SELECT * FROM Win32_Process where Caption ='smc.exe' or  Caption ='ccSvcHst.exe' or Caption='avp.exe'")

        Dim searcher As New ManagementObjectSearcher(scope, query)

        For Each queryObj As ManagementObject In searcher.Get()

            ANTIV = queryObj("Caption")
            ANTI_S = "Сервис запущен"

        Next

        'Тут надо расписать про все известные антивирусы, какие процессы у них работают

        Select Case ANTI_S

            Case "Сервис запущен"

                'query = New ObjectQuery("SELECT * FROM Win32_Process where Caption='ccSvcHst.exe'")

                'searcher = New ManagementObjectSearcher(scope, query)

                'For Each queryObj As ManagementObject In searcher.Get()

                ANTIV = ANTIV '& "/" & queryObj("Caption")
                ANTI_S = "Сервис запущен"
                'Next

            Case Else

                ANTI_S = "UNCNOwN"


        End Select





        Exit Sub
err_:
        ANTI_S = "UNCNOwN"
        ANTIV = "UNCNOwN"
    End Sub

    Private Sub get_Anti_(ByVal ip As String)

        Dim searcher As New ManagementObjectSearcher("root\SecurityCenter2", "SELECT * FROM AntiVirusProduct")

        For Each queryObj As ManagementObject In searcher.Get()

            ANTIV = queryObj("displayName")
            ANTI_S = queryObj("productState")

            Select Case ANTI_S


                Case "262144"
                    ANTI_S = "Обновлен и отключен"
                Case "262160"
                    ANTI_S = "Не обновлен и отключен"
                Case "266240"
                    ANTI_S = "Обновлен и включен"
                Case "266256"
                    ANTI_S = "Не обновлен и включен"
                Case "393216"
                    ANTI_S = "Обновлен и отключен"
                Case "393232"
                    ANTI_S = "Не обновлен и отключен"
                Case "393488"
                    ANTI_S = "Не обновлен и отключен"
                Case "397312"
                    ANTI_S = "Обновлен и включен"
                Case "397328"
                    ANTI_S = "Не обновлен и включен"
                Case "397584"
                    ANTI_S = "Не обновлен и включен"

                Case "462848"

                    ANTI_S = "Обновлен и включен"

                Case "462864"

                    ANTI_S = "Не обновлен и включен"

                Case Else

                    ANTI_S = "Состояние не определено"

            End Select


        Next

        Exit Sub
err_:
        ANTI_S = "UNCNOwN"
        ANTIV = "UNCNOwN"
    End Sub

    Private Sub TrapsToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TrapsToolStripMenuItem.Click
        frmTraps.Show()
    End Sub

    Private Sub ОпроситьАнтивирусToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОпроситьАнтивирусToolStripMenuItem.Click
        ThANTI.Abort()

        ThANTI = New System.Threading.Thread(AddressOf GET_ANT_START)
        ThANTI.Start()

        '   ThWSUS = New System.Threading.Thread(AddressOf GET_WSUS_START)
        '   ThWSUS.Start()
    End Sub

    Private Sub ОпроситьОбновленияToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ОпроситьОбновленияToolStripMenuItem.Click
        ThWSUS.Abort()

        ThWSUS = New System.Threading.Thread(AddressOf GET_WSUS_START)
        ThWSUS.Start()
    End Sub

    Private Sub lvSystem_DoubleClick(sender As Object, e As System.EventArgs) Handles lvSystem.DoubleClick
        'Что то напридумываю
        Dim tmpIP As String

        Dim z As Integer

        For z = 0 To lvSystem.SelectedItems.Count - 1
            tmpIP = (lvSystem.SelectedItems(z).SubItems(1).Text)
        Next

        GET_WSUS_(tmpIP)

    End Sub

    Private Sub СканерПортовToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles СканерПортовToolStripMenuItem.Click

        On Error Resume Next

        If lstVW.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer
        Dim uname, uname2 As String

        uname = ""
        uname2 = ""

        For z = 0 To lstVW.SelectedItems.Count - 1
            rCOUNT = (lstVW.SelectedItems(z).Text)
        Next

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV where id=" & rCOUNT

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        If sCOUNT = 0 Then Exit Sub

        rs = New Recordset
        rs.Open("SELECT * FROM TBL_DEV where id=" & rCOUNT, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            uname2 = .Fields("TipDev").Value
            uname = .Fields("IPDev").Value
        End With

        rs.Close()
        rs = Nothing

        'If uname2 = "Сервер" Then Exit Sub

        'System.Diagnostics.Process.Start("http://" & uname)

        port_scan.TextBox1.Text = uname
        port_scan.ShowDialog(Me)



    End Sub

    Private Sub СъемныеДискиToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles СъемныеДискиToolStripMenuItem.Click

        frm_removable_device.ShowDialog(Me)

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged

        If sOPROS = True Then

        Else
            Call LOAD_INF_HDD()
        End If

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton5.CheckedChanged

        If sOPROS = True Then

        Else
            Call LOAD_INF_HDD()
        End If


    End Sub

    Private Sub RadioButton6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton6.CheckedChanged
        If sOPROS = True Then

        Else
            Call LOAD_INF_HDD()
        End If
    End Sub

    Private Sub lbApparat_Click(sender As Object, e As System.EventArgs) Handles lbApparat.Click

        If lbApparat.Text = "" Then Exit Sub

        If sOPROS = True Then

        Else
            Call LOAD_INF_Arduino()
        End If

    End Sub

    Private Sub RadioButton8_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton8.CheckedChanged

        If lbApparat.Text = "" Then Exit Sub
        If sOPROS = True Then

        Else
            Call LOAD_INF_Arduino()
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton9.CheckedChanged

        If lbApparat.Text = "" Then Exit Sub
        If sOPROS = True Then

        Else
            Call LOAD_INF_Arduino()
        End If
    End Sub

    Private Sub RadioButton10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton10.CheckedChanged
        If lbApparat.Text = "" Then Exit Sub

        If sOPROS = True Then

        Else
            Call LOAD_INF_Arduino()
        End If
    End Sub

    Private Sub RadioButton7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton7.CheckedChanged

        If lbApparat.Text = "" Then Exit Sub

        If sOPROS = True Then

        Else
            Call LOAD_INF_Arduino()
        End If
    End Sub

    Private Sub lbApparat_DoubleClick(sender As Object, e As System.EventArgs) Handles lbApparat.DoubleClick

        If lbApparat.Text = "" Then Exit Sub

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields("t_n").Value
        End With
        rs.Close()
        rs = Nothing

        Select Case sCOUNT

            Case 0

            Case Else

                rs = New Recordset
                rs.Open("SELECT * FROM TBL_DEV where IPDev ='" & lbApparat.Text & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs

                    Select Case sIBPR

                        Case False

                            frmArd.DEVELOP = .Fields("DevelopDev").Value
                            frmArd.MODEL = .Fields("MODEL").Value
                            frmArd.IPDEV = .Fields("IPDev").Value
                            frmArd.COMMDEV = .Fields("CommunityDev").Value

                            frmArd.ShowDialog(Me)

                        Case True

                            Dim frmArd As frmArd = New frmArd
                            frmArd.DEVELOP = .Fields("DevelopDev").Value
                            frmArd.MODEL = .Fields("MODEL").Value
                            frmArd.IPDEV = .Fields("IPDev").Value
                            frmArd.COMMDEV = .Fields("CommunityDev").Value

                            frmArd.Show()

                    End Select

                    ' frmIBP.ShowDialog(Me)

                End With
                rs.Close()
                rs = Nothing

        End Select
    End Sub

End Class