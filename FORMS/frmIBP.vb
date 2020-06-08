Imports System.Threading

Public Class frmIBP
    Dim Th As System.Threading.Thread
    Dim ThRn As System.Threading.Thread

    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Friend strGroupUser As String
    Public IPDEV, COMMDEV, MODEL, DEVELOP As String

    Private Delegate Sub WriteText(ByVal text As String)

    Dim ZARIAD_BATTARY_OID As String
    Dim OUTPUT_LOAD_OID As String
    Dim SOST_BATTARY_OID As String
    Dim ZAMENA_BATTARY_OID As String
    Dim SELFTEST_OID As String
    Dim SELFTEST_DAY_OID As String
    Dim IN_TOK_OID As String
    Dim OUT_TOK_OID As String
    Dim UPTIME_OID As String
    Dim TIME_BATTERY_OID As String
    Dim OUTPUT_FREQ_OID As String
    Dim OUTPUT_STATUS_OID As String
    Dim BATTARY_VOLTAG_OID As String
    Dim TEMPERATURE_OID As String
    Dim TEMPERATURE2_OID As String

    Private Sub REALOID()

        If sOPROS = True Then Exit Sub

        Dim uname2 As String
        Dim uname As Integer

        uname2 = (REQUEST2(IPDEV, COMMDEV, "1.3.6.1.2.1.1.6.0", DEVELOP))

        Select Case result_

            Case False
                Exit Sub
        End Select

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV_OID where MODEL='" & MODEL & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            ZARIAD_BATTARY_OID = .Fields("ZARIAD_BATTARY_OID").Value
            OUTPUT_LOAD_OID = .Fields("OUTPUT_LOAD_OID").Value
            SOST_BATTARY_OID = .Fields("SOST_BATTARY_OID").Value
            ZAMENA_BATTARY_OID = .Fields("ZAMENA_BATTARY_OID").Value
            SELFTEST_OID = .Fields("SELFTEST_OID").Value
            SELFTEST_DAY_OID = .Fields("SELFTEST_DAY_OID").Value
            IN_TOK_OID = .Fields("IN_TOK_OID").Value
            OUT_TOK_OID = .Fields("OUT_TOK_OID").Value
            UPTIME_OID = .Fields("UPTIME_OID").Value
            TIME_BATTERY_OID = .Fields("TIME_BATTERY_OID").Value
            OUTPUT_FREQ_OID = .Fields("OUTPUT_FREQ_OID").Value
            OUTPUT_STATUS_OID = .Fields("OUTPUT_STATUS_OID").Value


            If Not IsDBNull(.Fields("BATTARY_VOLTAG_OID").Value) Then

                BATTARY_VOLTAG_OID = .Fields("BATTARY_VOLTAG_OID").Value

            Else

                BATTARY_VOLTAG_OID = "0"

            End If

            TEMPERATURE_OID = .Fields("TEMPERATURE_OID").Value
            TEMPERATURE2_OID = .Fields("TEMPERATURE2_OID").Value

        End With
        rs.Close()
        rs = Nothing

    End Sub

    Sub Thr()

        Do
            If sOPROS = True Then Threading.Thread.Sleep(2000)

            Dim uname2 As String
            Dim uname As Integer

            uname2 = (REQUEST2(IPDEV, COMMDEV, "1.3.6.1.2.1.1.6.0", DEVELOP))

            Select Case result_

                Case False
                    Exit Sub
            End Select

            uname = REQUEST2(IPDEV, COMMDEV, ZARIAD_BATTARY_OID, DEVELOP)

            ' IBP_BATTARY.Value = uname

            Me.Invoke(Sub() IBP_BATTARY.Value = uname)

            Select Case uname

                Case Is >= 70

                    Me.Invoke(Sub() SendMessage(Me.IBP_BATTARY.Handle, &H400 + 16, &H1, 0))

                    ' SendMessage(Me.IBP_BATTARY.Handle, &H400 + 16, &H1, 0)

                Case Is <= 69 And uname > 31
                    Me.Invoke(Sub() SendMessage(Me.IBP_BATTARY.Handle, &H400 + 16, &H3, 0))
                    'SendMessage(Me.IBP_BATTARY.Handle, &H400 + 16, &H3, 0)

                Case Is <= 30
                    Me.Invoke(Sub() SendMessage(Me.IBP_BATTARY.Handle, &H400 + 16, &H2, 0))
                    ' SendMessage(Me.IBP_BATTARY.Handle, &H400 + 16, &H2, 0)

            End Select

            uname = REQUEST2(IPDEV, COMMDEV, OUTPUT_LOAD_OID, DEVELOP)

            Me.Invoke(Sub() Me.IBP_LOAD.Value = uname)
            'Me.IBP_LOAD.Value = uname

            Select Case uname

                Case Is <= 30
                    Me.Invoke(Sub() SendMessage(Me.IBP_LOAD.Handle, &H400 + 16, &H1, 0))
                    ' SendMessage(Me.IBP_LOAD.Handle, &H400 + 16, &H1, 0)

                Case Is < 50 And uname > 31
                    Me.Invoke(Sub() SendMessage(Me.IBP_LOAD.Handle, &H400 + 16, &H3, 0))
                    ' SendMessage(Me.IBP_LOAD.Handle, &H400 + 16, &H3, 0)

                Case Is >= 50
                    Me.Invoke(Sub() SendMessage(Me.IBP_LOAD.Handle, &H400 + 16, &H2, 0))
                    ' SendMessage(Me.IBP_LOAD.Handle, &H400 + 16, &H2, 0)

            End Select

            '#################################################################################################
            ''Замена батареи'Состояние батареи
            '#################################################################################################
            Dim A1 As String
            Dim unames As String

            A1 = REQUEST2(IPDEV, COMMDEV, SOST_BATTARY_OID, DEVELOP)

            Select Case A1

                Case "1"
                    unames = "Неизвестно"

                Case "2"
                    unames = "Батарея нормальная"
                Case "3"
                    unames = "Батарея слабая"

            End Select

            If Len(A1) = 1 Then A1 = unames

            Dim A2 As String

            A2 = REQUEST2(IPDEV, COMMDEV, ZAMENA_BATTARY_OID, DEVELOP)

            Select Case A2

                Case "1"

                    unames = "Не требуется замена"

                Case "2"

                    unames = "Требуется замена"

            End Select

            If Len(A2) = 1 Then A2 = unames

            Me.Invoke(Sub() Me.Label8.Text = A1 & "/" & A2)
            Application.DoEvents()

            '#################################################################################################
            A2 = REQUEST2(IPDEV, COMMDEV, SELFTEST_OID, DEVELOP)

            Select Case A2

                Case "1"

                    unames = "Пройден"

                Case "2"

                    unames = "Не пройден"

            End Select
            A2 = unames



            Me.Invoke(Sub() Me.Label21.Text = REQUEST2(IPDEV, COMMDEV, SELFTEST_DAY_OID, DEVELOP) & "/" & A2)
            Application.DoEvents()
            '#################################################################################################

            A2 = REQUEST2(IPDEV, COMMDEV, IN_TOK_OID, DEVELOP)

            Select Case A2.Count

                Case 3

                Case 4
                    A2 = A2 / 10

                Case Else

                    A2 = A2 / 10

            End Select

            Me.Invoke(Sub() Me.Label10.Text = A2 & " VAC")
            Application.DoEvents()
          
            Me.Invoke(Sub() Me.Label11.Text = REQUEST2(IPDEV, COMMDEV, OUT_TOK_OID, DEVELOP) / 10 & " VAC")
           
            Me.Invoke(Sub() Me.Label12.Text = REQUEST2(IPDEV, COMMDEV, UPTIME_OID, DEVELOP))

            Me.Invoke(Sub() Me.Label13.Text = REQUEST2(IPDEV, COMMDEV, TIME_BATTERY_OID, DEVELOP))
            
            Me.Invoke(Sub() Me.Label23.Text = REQUEST2(IPDEV, COMMDEV, OUTPUT_FREQ_OID, DEVELOP) & " Hz")

            uname2 = REQUEST2(IPDEV, COMMDEV, OUTPUT_STATUS_OID, DEVELOP)

            Select Case uname2

                Case "1"
                    uname2 = "Неизветсно"
                Case "2"
                    uname2 = "От сети"
                Case "3"
                    uname2 = "От батареи"
                Case "4"
                    uname2 = "On Smart Boost"
                Case "5"
                    uname2 = "Timed Sleeping"
                Case "6"
                    uname2 = "Software Bypass"
                Case "7"
                    uname2 = "Off"
                Case "8"
                    uname2 = "Rebooting"
                Case "9"
                    uname2 = "Switched Bypass"
                Case "10"
                    uname2 = "Hardware Failure Bypass"
                Case "11"
                    uname2 = "Sleeping Until Pawer Returns"
                Case "12"
                    uname2 = "On Smart Trim"

            End Select

            Select Case uname2

                Case "От сети"
                    Me.Invoke(Sub() Me.Label24.ForeColor = Color.Green)

                Case Else
                    Me.Invoke(Sub() Me.Label24.ForeColor = Color.Red)

            End Select

            Me.Invoke(Sub() Me.Label24.Text = uname2)

            If BATTARY_VOLTAG_OID <> "0" Then

                uname2 = REQUEST2(IPDEV, COMMDEV, BATTARY_VOLTAG_OID, DEVELOP) '/ 10 & " VDC"  '1.3.6.1.2.1.33.1.2.5.0

            Else

                uname2 = "0"

            End If

            Select Case uname2

                Case "0"
                    Me.Invoke(Sub() Me.Label30.Text = uname2)
                    'Me.Label30.Text = uname2
                Case Else

                    Select Case uname2.Count

                        Case 3
                            uname2 = uname2 / 10
                        Case 4
                            uname2 = uname2 / 10
                        Case Else

                    End Select

                    Me.Invoke(Sub() Me.Label30.Text = uname2 & " VDC")
                    'Me.Label30.Text = uname2 / 10 & " VDC"
            End Select

            'Температура

            uname2 = REQUEST2(IPDEV, COMMDEV, TEMPERATURE_OID, DEVELOP)

            Select Case uname2

                Case Is <= 30
                    Me.Invoke(Sub() Me.Label27.ForeColor = Color.Green)
                    'Me.Label27.ForeColor = Color.Green

                Case Is >= 31
                    Me.Invoke(Sub() Me.Label27.ForeColor = Color.LightPink)
                    ' Me.Label27.ForeColor = Color.LightPink

                Case Is >= 50
                    Me.Invoke(Sub() Me.Label27.ForeColor = Color.Red)
                    ' Me.Label27.ForeColor = Color.Red

            End Select

            ' Me.Label27.Text = uname2 & " °C"
            Me.Invoke(Sub() Me.Label27.Text = uname2 & " °C")

            uname2 = REQUEST2(IPDEV, COMMDEV, TEMPERATURE2_OID, DEVELOP)

            Select Case uname2

                Case Is <= 25
                    Me.Invoke(Sub() Me.Label28.ForeColor = Color.Green)
                    'Me.Label28.ForeColor = Color.Green

                Case Is >= 25
                    Me.Invoke(Sub() Me.Label28.ForeColor = Color.LightPink)
                    ' Me.Label28.ForeColor = Color.LightPink

                Case Is >= 35
                    Me.Invoke(Sub() Me.Label28.ForeColor = Color.Red)
                    ' Me.Label28.ForeColor = Color.Red

            End Select

            Me.Invoke(Sub() Me.Label28.Text = uname2 & " °C")

            '  Me.Label28.Text = uname2 & " °C"
            'Label28.Text = REQUEST2(IPDEV, COMMDEV, TEMPERATURE2_OID"), DEVELOP) & " °C"

            Threading.Thread.Sleep(900)

        Loop

    End Sub

    Private Sub REQUEST_OID_IBP_DB_no_Refresh()

        Dim uname As String

        uname = (REQUEST2(IPDEV, COMMDEV, "1.3.6.1.2.1.1.6.0", DEVELOP))

        Select Case result_

            Case False
                If Len(sTXT_) = 0 Then sTXT_ = "Не возможно получить данные от " & IPDEV & vbNewLine Else sTXT_ = sTXT_ + vbNewLine & "Не возможно получить данные от " & IPDEV & vbNewLine

                Exit Sub

        End Select

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV_OID where MODEL='" & MODEL & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            Me.Invoke(Sub() Me.Text = REQUEST2(IPDEV, COMMDEV, .Fields("MODEL_OID").Value, DEVELOP))
            Me.Invoke(Sub() Me.Label6.Text = REQUEST2(IPDEV, COMMDEV, .Fields("MODEL_OID").Value, DEVELOP))

            ''Место нахождение
            Me.Invoke(Sub() Me.Label18.Text = REQUEST2(IPDEV, COMMDEV, .Fields("LOCATION_OID").Value, DEVELOP))

            ''Контактное лицо
            Me.Invoke(Sub() Me.Label19.Text = REQUEST2(IPDEV, COMMDEV, .Fields("CONTACT_OID").Value, DEVELOP))

            ''Модель
            'frmRequestOID.lstUPS.Items(CInt(intcount)).SubItems.Add(REQUEST2(IPDEV, COMMDEV, .Fields("MODEL_OID"), Develop))

            ''Серийный номер
            Me.Invoke(Sub() Me.Label20.Text = REQUEST2(IPDEV, COMMDEV, .Fields("SER_NUM_OID").Value, DEVELOP))

        End With

        rs.Close()
        rs = Nothing


    End Sub

    Private Sub WriteTextSub(ByVal text As String)

        If Not (Me.InvokeRequired) Then

            Me.Text = text

        Else

            Me.Invoke(New WriteText(AddressOf WriteTextSub), text)

        End If

    End Sub

    Private Sub frmIBP_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        Try
            Th.Abort()
            
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmIBP_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        '  Me.BeginInvoke(New MethodInvoker(AddressOf Me.TIMER_EN))
        'Application.DoEvents()
        'Me.BeginInvoke(New MethodInvoker(AddressOf Me.REQUEST_OID_IBP_DB)))

        Call REALOID()
        'Me.BeginInvoke(New MethodInvoker(AddressOf Me.REQUEST_OID_IBP_DB_no_Refresh))

        ThRn = New System.Threading.Thread(AddressOf REQUEST_OID_IBP_DB_no_Refresh)
        ThRn.Start()

        Th = New System.Threading.Thread(AddressOf Thr)
        Th.Start()

        ' Application.DoEvents()
        'Application.DoEvents()

    End Sub


End Class
