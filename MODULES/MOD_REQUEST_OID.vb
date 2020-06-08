Imports System.Collections
'Imports SNMPDll
Imports SnmpSharpNet
Imports System.Management
Imports System.Threading
Imports System.ComponentModel
Imports System.Net.Mail

Module MOD_REQUEST_OID

    Public intcount As Integer
    Public intcount2 As Integer
    Public intcount3 As Integer
    Public intcount4 As Integer

    Public intcountIBP As Integer
    Public intcountCOMM As Integer
    Public intcountPRN As Integer
    Public intcountARD As Integer

    Public PAr1 As String
    Public PAr2 As String
    Public PAr3 As String
    Public PAr4 As String
    Public PAr5 As Integer

    Public cPAr1 As String
    Public cPAr2 As String
    Public cPAr3 As String
    Public cPAr4 As String
    Public cPAr5 As Integer

    Public pPAr1 As String
    Public pPAr2 As String
    Public pPAr3 As String
    Public pPAr4 As String
    Public pPAr5 As Integer

    Public Name_DEV As String
    Public TEMP_DEV As String
    Public IP_DEV_A As String
    Public COMM_DEV_A As String

    Public TIP_DEV_A As String
    Public PROIZV_DEV_A As String

    Public TIME_TOOL_TIPS As Integer

    Public PrPath As String

    Public SMTP_ As String
    Public EMAIL_ As String
    Public FromEMAIL_ As String
    Public TEMP_ As Integer
    Public SendMail_ As Integer
    Public SendMail2_ As Integer
    Public TIMEOPROS_ As Integer

    Public STATUS_BATTERY As String

    Public sTXT As String

    Public result_ As Boolean
    Public sTXT_ As String
    Public sMessage As String

    Public zCounter As Integer
    Public sCOUNT As Integer
    Dim connection As New ConnectionOptions
    Public sOPROS As Boolean = False
    Public int_forSendMail As Integer = 0

    Public UPSMN, UPS_NAME, UPC_Contact, UPS_MODEL, UPS_SN, UPS_BATTERY_TIME, UPS_BATTARY_ENERGY, UPS_BATTARY_SOST, UPS_BATTARY_ZAM, UPS_TIME_WORK, UPS_IP, UPS_MAC, UPS_IN_ACDC, UPS_OUT_ACDC, UPS_MHZ, UPS_LOAD, UPS_STATUS, UPS_TEST, UPS_TEST_DATE, UPS_TEMP, UPS_TEMP2 As Boolean
    Public COMM_MN, COMM_NN, COMM_CONTACT, COMM_MOD, COMM_SN, COMM_INWORK, COMM_IP, COMM_MAC, COMM_THEMP, COMM_FLASH As Boolean


    Public Function REQUEST2(ByVal IP_ As String, ByVal COMMUNITY_ As String, ByVal OID1 As String, ByVal DEVELOPER As String) As String

        On Error GoTo Err_

        Dim host As String = IP_
        Dim community As String = COMMUNITY_
        Dim requestOid() As String
        Dim result As Dictionary(Of Oid, AsnType)
        requestOid = New String() {OID1, OID1}
        Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)

        If Not snmp.Valid Then

            Return "ERR_" + snmp.Valid

            Exit Function

        End If

        Dim uname As String

        uname = ""

        result = snmp.Get(SnmpVersion.Ver1, requestOid)

        If result IsNot Nothing Then
            result_ = True
        Else
            result_ = False
            REQUEST2 = "0"
        End If

        If result IsNot Nothing Then

            Dim kvp As KeyValuePair(Of Oid, AsnType)
            For Each kvp In result

                Select Case DEVELOPER

                    Case "APC"

                                REQUEST2 = kvp.Value.ToString

                                If OID1 = "1.3.6.1.2.1.1.6.0" Then Name_DEV = kvp.Value.ToString

                                If OID1 = "1.3.6.1.2.1.1.5.0" Then Name_DEV = Name_DEV & "/" & kvp.Value.ToString

                                If OID1 = "1.3.6.1.4.1.318.1.1.1.2.2.2.0" Then TEMP_DEV = kvp.Value.ToString



                    Case "EATON"

                        Select Case OID1

                            Case "1.3.6.1.4.1.705.1.5.9.0"

                                Select Case kvp.Value.ToString

                                    Case "1"
                                        uname = "Батарея слабая"
                                    Case "2"
                                        uname = "Батарея нормальная"

                                End Select

                                REQUEST2 = uname

                            Case "1.3.6.1.4.1.705.1.5.1.0"
                                ' 1.3.6.1.4.1.705.1.5.1.0

                                uname = kvp.Value.ToString / 60

                                REQUEST2 = uname & " минут"

                            Case "1.3.6.1.4.1.705.1.5.11.0"

                                Select Case kvp.Value.ToString

                                    Case "2"
                                        uname = "Не требуется замена"
                                    Case "1"
                                        uname = "Требуется замена"

                                End Select

                                REQUEST2 = uname

                            Case "1.3.6.1.4.1.705.1.5.14.0"

                                Select Case kvp.Value.ToString

                                    Case "1"
                                        uname = "да"
                                    Case "2"
                                        uname = "нет"

                                End Select

                                REQUEST2 = uname

                            Case "1.3.6.1.4.1.705.1.10.3.0"

                                Select Case kvp.Value.ToString

                                    Case "1"

                                        uname = "Пройден"

                                    Case "2"

                                        uname = "Не пройден"

                                    Case Else

                                        uname = "-----"

                                End Select

                                REQUEST2 = uname

                            Case "1.3.6.1.4.1.705.1.7.3.0"

                                Select Case kvp.Value.ToString

                                    Case "1"
                                        uname = "От батареи"
                                    Case "2"
                                        uname = "От сети"

                                End Select

                                REQUEST2 = uname
                                STATUS_BATTERY = uname

                                '1.3.6.1.4.1.705.1.7.3.0
                            Case "1.3.6.1.4.1.705.1.7.2.1.3.1"

                                uname = kvp.Value.ToString / 10

                                REQUEST2 = uname '& " Hz"

                            Case Else

                                REQUEST2 = kvp.Value.ToString

                        End Select

                    Case Else

                        REQUEST2 = kvp.Value.ToString

                End Select

            Next

        Else

        End If


        GC.Collect()
        Exit Function
Err_:
        Return "ERR_" + Err.Description
        ResList(frmRequestOID.lstUPS)
        GC.Collect()
    End Function

    Public Sub ResList(ByVal resizingListView As ListView)

        Dim columnIndex As Integer

        For columnIndex = 1 To resizingListView.Columns.Count - 1
            resizingListView.AutoResizeColumn(columnIndex, ColumnHeaderAutoResizeStyle.HeaderSize)
        Next

       
    End Sub

    Public Sub REQUEST_OID_IBP_DB()
        On Error GoTo err_

        'Пытаемся заполнить лист данными
        Dim A1, A2, A3, A4, A5, A6, A7, A8, A9, A10 As String

        Dim uname As String

        uname = (REQUEST2(PAr1, PAr2, "1.3.6.1.2.1.1.6.0", PAr4))

        Select Case result_

            Case False
                If Len(sTXT_) = 0 Then sTXT_ = "Не возможно получить данные от " & PAr1 & vbNewLine Else sTXT_ = sTXT_ + vbNewLine & "Не возможно получить данные от " & PAr1 & vbNewLine

                Exit Sub
        End Select

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV_OID where Model='" & PAr3 & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            frmRequestOID.lstUPS.Items.Add(PAr5)

            'Место нахождение
            Select Case UPSMN
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("LOCATION_OID").Value, PAr4))
            End Select
            'Имя в сети
            Select Case UPS_NAME
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("NETNAME_OID").Value, PAr4))
            End Select
            'Контактное лицо
            Select Case UPC_Contact
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("CONTACT_OID").Value, PAr4))
            End Select
            'Модель
            Select Case UPS_MODEL
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("Model_OID").Value, PAr4))
            End Select
            'Серийный номер
            Select Case UPS_SN
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("SER_NUM_OID").Value, PAr4))
            End Select
            'Время работы от батареи
            Select Case UPS_BATTERY_TIME
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("TIME_BATTERY_OID").Value, PAr4))
            End Select
            'Заряд батареи
            Select Case UPS_BATTARY_ENERGY
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("ZARIAD_BATTARY_OID").Value, PAr4) & "  %")
            End Select

            'Состояние батареи

            A1 = REQUEST2(PAr1, PAr2, .Fields("SOST_BATTARY_OID").Value, PAr4)

            Select Case UPS_BATTARY_SOST
                Case True

                    Select Case A1

                        Case "1"
                            uname = "Неизвестно"
                        Case "2"
                            uname = "Батарея нормальная"
                        Case "3"
                            uname = "Батарея слабая"
                        Case Else
                            uname = "Неизвестно"

                    End Select


            End Select

            If Len(A1) = 1 Then A1 = uname
            frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(A1)


            'Замена батареи

            A2 = REQUEST2(PAr1, PAr2, .Fields("ZAMENA_BATTARY_OID").Value, PAr4)

            Select Case UPS_BATTARY_ZAM
                Case True

                    Select Case A2

                        Case "1"

                            uname = "Не требуется замена"

                        Case "2"

                            uname = "Требуется замена"

                    End Select


            End Select
            If Len(A2) = 1 Then A2 = uname
            frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(A2)

            'UpTime
            Select Case UPS_TIME_WORK
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("UPTIME_OID").Value, PAr4))
            End Select
            'ip адрес
            Select Case UPS_IP
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(PAr1)
            End Select
            'MAC адрес
            Select Case UPS_MAC
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("MAC_OID").Value, PAr4))
            End Select
            '  If .Fields("Developer") = "EATON" Then
            'Входное напряжение

            A3 = (REQUEST2(PAr1, PAr2, .Fields("IN_TOK_OID").Value, PAr4))

            Select Case A3.Count

                Case 3

                Case 4
                    A3 = A3 / 10

                Case Else

                    A3 = A3 / 10

            End Select

            Select Case UPS_IN_ACDC
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(A3 & " VAC")
            End Select
            '  Else
            'Входное напряжение
            '  frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("IN_TOK_OID"), PAr4) & " VAC")

            '  End If

            '  If .Fields("Developer") = "EATON" Then
            'Выходное напряжение

            A4 = (REQUEST2(PAr1, PAr2, .Fields("OUT_TOK_OID").Value, PAr4))


            Select Case A4.Count

                Case 3

                Case 4
                    A4 = A4 / 10

                Case Else

                    A4 = A4 / 10

            End Select

            Select Case UPS_OUT_ACDC
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(A4 & " VAC")
            End Select
            ' Else

            'frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("OUT_TOK_OID"), PAr4) & " VAC")
            ' End If

            'AdvOutputFrequency

            A5 = REQUEST2(PAr1, PAr2, .Fields("OUTPUT_FREQ_OID").Value, PAr4)

            Select Case UPS_MHZ
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(A5 & " Hz")
            End Select
            'AdvOutputLoad

            A6 = REQUEST2(PAr1, PAr2, .Fields("OUTPUT_LOAD_OID").Value, PAr4)

            Select Case UPS_LOAD
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(A6 & " %")
            End Select
            'OutputStatus

            uname = REQUEST2(PAr1, PAr2, .Fields("OUTPUT_STATUS_OID").Value, PAr4)

            Select Case uname

                Case "1"
                    uname = "Неизветсно"
                Case "2"
                    uname = "От сети"
                Case "3"
                    uname = "От батареи"
                Case "4"
                    uname = "On Smart Boost"
                Case "5"
                    uname = "Timed Sleeping"
                Case "6"
                    uname = "Software Bypass"
                Case "7"
                    uname = "Off"
                Case "8"
                    uname = "Rebooting"
                Case "9"
                    uname = "Switched Bypass"
                Case "10"
                    uname = "Hardware Failure Bypass"
                Case "11"
                    uname = "Sleeping Until Pawer Returns"
                Case "12"
                    uname = "On Smart Trim"

            End Select

            STATUS_BATTERY = uname

            Select Case UPS_STATUS
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(uname)
            End Select
            'Результат SelfTest

            Select Case UPS_TEST
                Case True

                    Select Case REQUEST2(PAr1, PAr2, .Fields("SELFTEST_OID").Value, PAr4)

                        Case "1"

                            uname = "Пройден"

                        Case Else

                            uname = "Не пройден"

                    End Select

                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(uname)
            End Select
            'Дата SelfTest
            Select Case UPS_TEST_DATE
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("SELFTEST_DAY_OID").Value, PAr4))
            End Select
            'Температура

            uname = REQUEST2(PAr1, PAr2, .Fields("TEMPERATURE_OID").Value, PAr4)
            A7 = uname
            uname = uname & " °C"
            Select Case UPS_TEMP
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(uname)

                    Select Case A7
                        Case "0"
                        Case Else
                            If A7 >= TEMP_ Then frmRequestOID.lstUPS.Items(CInt(intcountIBP)).BackColor = Color.Yellow
                    End Select

            End Select

            Select Case UPS_TEMP2
                Case True
                    frmRequestOID.lstUPS.Items(CInt(intcountIBP)).SubItems.Add(REQUEST2(PAr1, PAr2, .Fields("TEMPERATURE2_OID").Value, PAr4) & " °C")
            End Select

            'Сохраняем данные в таблицу

            Select Case PAr4
                Case "APC"
                    Select Case A1
                        Case "Батарея нормальная"
                            A1 = "2"
                        Case "Батарея слабая"
                            A1 = "3"
                        Case Else
                            A1 = "1"
                    End Select
                Case "EATON"
                    Select Case A1

                        Case "Батарея нормальная"
                            A1 = "2"
                        Case "Батарея слабая"
                            A1 = "3"
                        Case Else
                            A1 = "1"
                    End Select
            End Select

            Select Case PAr4
                Case "APC"
                    Select Case A2
                        Case "Не требуется замена"
                            A2 = "1"
                        Case Else
                            A2 = "2"
                    End Select
                Case "EATON"
                    Select Case A2
                        Case "Не требуется замена"
                            A2 = "1"
                        Case Else
                            A2 = "2"
                    End Select
            End Select

            If A7 = "---" Then A7 = "0"

            If Not IsDBNull(.Fields("BATTARY_VOLTAG_OID").Value) Then

                ' A8 = REQUEST2(PAr1, PAr2, .Fields("BATTARY_VOLTAG_OID").Value, PAr4) / 10


                A8 = REQUEST2(PAr1, PAr2, .Fields("BATTARY_VOLTAG_OID").Value, PAr4)

                Select Case A8.Count

                    Case 3
                        A8 = A8 / 10
                    Case 4
                        A8 = A8 / 10
                    Case Else

                End Select


            Else

                A8 = "0"

            End If

            Dim sSQL1 As String
            sSQL1 = "INSERT INTO IBP_MON(IBP_ID,SOST_BATTARY,ZAMENA_BATTARY,IN_TOK,OUT_TOK,OUTPUT_FREQ,OUTPUT_LOAD,TEMPERATURE,BATTARY_VOLTAG,DT,TM) " &
            "VALUES('" & PAr5 & "','" & A1 & "','" & A2 & "','" & A3 & "','" & A4 & "','" & A5 & "','" & A6 & "','" & A7 & "','" & A8 & "','" & Date.Today & "','" & TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second & "')"

            DB7.Execute(sSQL1)

        End With
        rs.Close()
        rs = Nothing

        ResList(frmRequestOID.lstUPS)

        Select Case STATUS_BATTERY

            Case "От сети"

            Case Else
                sTXT = "Информация"
                Call MESSAGE_("Статус ИБП -" & Name_DEV & " изменен на " & STATUS_BATTERY)

        End Select

        If TEMP_DEV >= TEMP_ Then

            sTXT = "Информация"
            Call MESSAGE_("Температура ИБП -" & Name_DEV & " достигла установленного максимума = " & TEMP_DEV & " °C")

        End If


        intcountIBP = intcountIBP + 1

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Public Sub REQUEST_OID_COMM_DB()
        ' On Error Resume Next
        'On Error GoTo err_

        Dim tmpTHEMP As Boolean = False

        'Заполняем лист данными

        Dim uname As String

        uname = (REQUEST2(cPAr1, cPAr2, "1.3.6.1.2.1.1.6.0", cPAr4))

        Select Case result_

            Case False
                If Len(sTXT_) = 0 Then sTXT_ = "Не возможно получить данные от " & cPAr1 & vbNewLine Else sTXT_ = sTXT_ + vbNewLine & "Не возможно получить данные от " & cPAr1 & vbNewLine

                Exit Sub

        End Select

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV_OID where Model='" & cPAr3 & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            frmRequestOID.lstComm.Items.Add(cPAr5)

            'Место нахождение

            Select Case COMM_MN
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("LOCATION_OID").Value, cPAr4)))
            End Select

            'Имя в сети
            Select Case COMM_NN
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("NETNAME_OID").Value, cPAr4)))
            End Select

            Name_DEV = REQUEST2(cPAr1, cPAr2, .Fields("NETNAME_OID").Value, cPAr4)

            'Контактное лицо
            Select Case COMM_CONTACT
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("CONTACT_OID").Value, cPAr4)))
            End Select


            'Модель
            Select Case COMM_MOD
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("Model_OID").Value, cPAr4)))
            End Select

            'Серийный номер
            Select Case COMM_SN
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("SER_NUM_OID").Value, cPAr4)))
            End Select


            'UpTime
            Select Case COMM_INWORK
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("UPTIME_OID").Value, cPAr4)))
            End Select

            'ip адрес
            Select Case COMM_IP
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(cPAr1)))
            End Select

            'MAC адрес
            Select Case COMM_MAC
                Case True
                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("MAC_OID").Value, cPAr4)))
            End Select

            Select Case .Fields("Model").Value

                Case "WS-C2960-24TT-L"

                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    Select Case uname
                        Case 1
                            uname = "Температура в норме"
                            tmpTHEMP = False
                            TEMP_DEV = TEMP_ - 5
                        Case 2
                            uname = "Высокая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 5
                        Case 3
                            uname = "Критическая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 10
                    End Select



                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname))


                Case "WS-C3560-24TS-S"

                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    Select Case uname
                        Case 1
                            uname = "Температура в норме"
                            tmpTHEMP = False
                            TEMP_DEV = TEMP_ - 5
                        Case 2
                            uname = "Высокая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 5
                        Case 3
                            uname = "Критическая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 10
                    End Select

                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname))

                Case "WS-C2940-8TF-S"

                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    Select Case uname
                        Case 0
                            uname = "Температура в норме"
                            tmpTHEMP = False
                            TEMP_DEV = TEMP_ - 5
                        Case 1
                            uname = "Высокая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 5
                        Case 2
                            uname = "Критическая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 10
                    End Select


                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname))

                Case "WS-CE500G-12TC"

                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    Select Case uname
                        Case 0
                            uname = "Температура в норме"
                            tmpTHEMP = False
                            TEMP_DEV = TEMP_ - 5
                        Case 1
                            uname = "Высокая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 5
                        Case 2
                            uname = "Критическая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 10
                    End Select


                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname))

                Case "WS-C3750G-12S-E"

                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    Select Case uname
                        Case 1
                            uname = "Температура в норме"
                            tmpTHEMP = False
                            TEMP_DEV = TEMP_ - 5
                        Case 2
                            uname = "Высокая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 5
                        Case 3
                            uname = "Критическая температура"
                            tmpTHEMP = True
                            TEMP_DEV = TEMP_ + 10
                    End Select


                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname))


                Case "WS-C2960-24TT-L"
                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname & " °C"))

                    If uname > TEMP_ Then tmpTHEMP = True

                    TEMP_DEV = uname

                Case Else

                    uname = REQUEST2(cPAr1, cPAr2, .Fields("TEMPERATURE_OID").Value, cPAr4)

                    frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(uname & " °C"))

                    If uname > TEMP_ Then tmpTHEMP = True

                    TEMP_DEV = uname
            End Select

            'FLASH
            Select Case COMM_FLASH
                Case True

                    If Not IsDBNull(.Fields("FLASH_OID")) Then

                        frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(REQUEST2(cPAr1, cPAr2, .Fields("FLASH_OID").Value, cPAr4)))

                    Else

                        frmRequestOID.Invoke(Sub() frmRequestOID.lstComm.Items(CInt(intcountCOMM)).SubItems.Add(""))
                    End If

            End Select

            intcountCOMM = intcountCOMM + 1

        End With
        rs.Close()
        rs = Nothing

        frmRequestOID.Invoke(Sub() ResList(frmRequestOID.lstComm))

        If TEMP_DEV >= TEMP_ Or tmpTHEMP = True Then

            ' If Len(sTXT_) = 0 Then sTXT_ = vbNewLine & "Температура Коммутатора -" & Name_DEV & " близка к критической = " & TEMP_DEV & " °C" & vbNewLine Else sTXT_ = sTXT_ & vbNewLine & "Температура Коммутатора -" & Name_DEV & " близка к критической = " & TEMP_DEV & " °C" & vbNewLine
            sTXT = "Информация"
            Call MESSAGE_("Температура Коммутатора -" & Name_DEV & " достигла установленного максимума = " & TEMP_DEV & " °C")

        End If

err_:
    End Sub

    Public Sub MESSAGE_(ByVal stext As String)

        Select Case stext

            Case "-------------------------"

                'stext = ""

                If Len(sMessage) = 0 Then Exit Sub

            Case Else

                ' If Len(sMessage) = 0 Then Exit Sub

        End Select


        If Len(sMessage) <> 0 Then

            sMessage = sMessage & vbCrLf & vbCrLf & stext

        Else

            sMessage = stext

        End If

        Select Case sOPROS

            Case True

            Case False

                If Len(sMessage) <> 0 And sMessage <> "-------------------------" Then frmRequestOID.ni.ShowBalloonTip(TIME_TOOL_TIPS * 1000, "SMNP Monitor", sMessage, ToolTipIcon.Warning)

                Select Case sTXT

                    Case "Информация"
                        If SendMail_ = "0" Then

                            sMessage = ""
                            stext = ""
                            Exit Sub
                        End If

                        frmRequestOID.BeginInvoke(New MethodInvoker(AddressOf frmRequestOID.SEND_MAIL))


                    Case Else
                        If SendMail2_ = "0" Then

                            sMessage = ""
                            stext = ""
                            Exit Sub
                        End If

                        frmRequestOID.BeginInvoke(New MethodInvoker(AddressOf frmRequestOID.SEND_MAIL))

                End Select
                'Отправляем по почте
                Application.DoEvents()

        End Select
        ' sMessage = ""
        ' stext = ""
       
    End Sub

    Public Sub REQUEST_OID_PRINT_DB()

        'On Error Resume Next
        'Пытаемся заполнить лист данными

        Dim uname As String

        uname = (REQUEST2(pPAr1, pPAr2, "1.3.6.1.2.1.25.3.2.1.3.1", pPAr4))

        Select Case result_

            Case False
                Exit Sub
        End Select

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV_OID where Model='" & pPAr3 & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)


        Dim pageCount, Toner As String



        With rs

            frmRequestOID.lvPrinter.Items.Add(pPAr5)

            'Имя в сети
            uname = REQUEST2(pPAr1, pPAr2, .Fields("NETNAME_OID").Value, pPAr4)

            Select Case uname
                Case "0"
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname))
            End Select

            uname = REQUEST2(pPAr1, pPAr2, .Fields("Model_OID").Value, pPAr4)

            Select Case uname
                Case "0"
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname))
            End Select

            uname = REQUEST2(pPAr1, pPAr2, .Fields("TEMPERATURE_OID").Value, pPAr4)

            Select Case uname
                Case "0"

                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname))

            End Select

            pageCount = uname

            uname = REQUEST2(pPAr1, pPAr2, .Fields("UPTIME_OID").Value, pPAr4)

            Select Case uname
                Case "0"
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    Select Case .Fields("Model").Value

                        Case "HP1320"

                            uname = uname / 10

                        Case Else

                    End Select

                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname & "%"))
            End Select

            Toner = uname

            uname = REQUEST2(pPAr1, pPAr2, .Fields("LOCATION_OID").Value, pPAr4)

            Select Case uname
                Case "0"
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname))
            End Select

            frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(pPAr1))

            uname = REQUEST2(pPAr1, pPAr2, .Fields("MAC_OID").Value, pPAr4)

            Select Case uname
                Case "0"
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname))
            End Select

            uname = REQUEST2(pPAr1, pPAr2, .Fields("OUTPUT_STATUS_OID").Value, pPAr4)

            Select Case uname
                Case "0"
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add("---"))
                Case Else
                    frmRequestOID.Invoke(Sub() frmRequestOID.lvPrinter.Items(CInt(intcountPRN)).SubItems.Add(uname))
            End Select

        End With
        rs.Close()
        rs = Nothing


        Dim sSQL1 As String
        sSQL1 = "INSERT INTO TBL_PRN_MON(IPprn,page,toner,DT,TM) " &
        "VALUES('" & pPAr1 & "','" & pageCount & "','" & Toner & "','" & Date.Today & "','" & TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second & "')"

        DB7.Execute(sSQL1)

        intcountPRN = intcountPRN + 1

err_:
    End Sub

    Public Sub LOAD_WMI_3(ByVal strComputer As String, ByVal Authority As String, ByVal wmiUser As String, ByVal wmiPasword As String, ByVal ssID As Integer)
        Dim net As New Net.NetworkInformation.Ping

        On Error Resume Next

        Dim sTEXT13 As String
        Dim intCount As Decimal = 0
        Dim A1, A2, A3, A4, A5 As String
        Dim sSQL As String

        sTEXT13 = ""

        ' Dim cmdInsert As New OleDbCommand
        'Dim iSqlStatus As Integer

        connection.Username = wmiUser
        connection.Password = wmiPasword
        connection.Authority = "ntlmdomain:" & Authority

        Dim scope As New ManagementScope("\\" & strComputer & "\root\CIMV2", connection)
        scope.Connect()

        Dim query As New ObjectQuery("SELECT * FROM Win32_LOGICALDISK where drivetype=3")

        Dim searcher As New ManagementObjectSearcher(scope, query)

        Dim intFreespace, intTotalSpace, pctFreespace As Decimal

        For Each queryObj As ManagementObject In searcher.Get()

            A1 = (queryObj("name"))
            A2 = Math.Round((((queryObj("size") / 1024) / 1024) / 1024), 2)
            ' A2 = ((queryObj("size") / 1024) / 1024) / 1024
            A3 = (queryObj("FreeSpace") / 1024) / 1024

            intFreespace = queryObj("freespace")
            intTotalSpace = queryObj("size")
            pctFreespace = intFreespace / intTotalSpace

            A4 = Math.Round((pctFreespace * 100), 2)

            ' If A4 <= 9 Then

            If Len(sMessage) = 0 Then

                sMessage = "На устройстве: " & strComputer & " Объем свободного пространства на логическом диске " & A1 & " составляет: " & A4 & "%" & vbCrLf

            Else

                sMessage = sMessage & vbCrLf & "На устройстве: " & strComputer & " Объем свободного пространства на логическом диске " & A1 & " составляет: " & A4 & "%" & vbCrLf

            End If

            ' End If

            sSQL = "INSERT INTO TBL_HDD_SER(ID_SERV,[DATE],[DRIVE],[SIZE],[FreeSize],[Percent]) VALUES(" & ssID & ",'" & Date.Today & "','" & A1 & "','" & A2 & "','" & A3 & "','" & A4 & "')"
            DB7.Execute(sSQL)


            intCount = intCount + 1
        Next

        If Len(sTEXT13) = 0 Then Exit Sub

SENDMAIL_ALERT:


        Exit Sub
err_:

        MsgBox(Err.Description)
    End Sub


    Public Sub REQUEST_OID_ARDUINO_DB()

        ' On Error Resume Next
        'Пытаемся заполнить лист данными

        Dim uname As String

        uname = (REQUEST2(pPAr1, pPAr2, "1.3.6.1.2.1.1.5.0", pPAr4))

        Select Case result_

            Case False
                Exit Sub
        End Select

        Dim sSQL As String
        Dim rs As Recordset

        sSQL = "SELECT count(*) as tn FROM TBL_DEV_OID where Model='" & pPAr3 & "' AND Developer='" & pPAr4 & "'"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            uname = .Fields("tn").Value

        End With

        Select Case uname
            Case 0

                Exit Sub

        End Select
        uname = ""


        sSQL = "SELECT * FROM TBL_DEV_OID where Model='" & pPAr3 & "' AND Developer='" & pPAr4 & "'"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        Dim Tem1, Hum1 As String

        With rs

            frmRequestOID.lvApparat.Items.Add(pPAr5)

T1:

            Try
                uname = REQUEST2(pPAr1, pPAr2, .Fields("TEMPERATURE_OID").Value, pPAr4)

                If uname = 0 Then GoTo T1
                If uname = "0" Then GoTo T1


                Tem1 = uname

                Select Case uname
                    Case "0"

                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add("---"))
                    Case Else
                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add(uname))

                End Select

            Catch ex As Exception

            End Try


T2:
            Try

                uname = REQUEST2(pPAr1, pPAr2, .Fields("TEMPERATURE2_OID").Value, pPAr4)

                If uname = 0 Then GoTo T2
                If uname = "0" Then GoTo T2

                Hum1 = uname

                Select Case uname
                    Case "0"

                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add("---"))
                    Case Else
                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add(uname))

                End Select

            Catch ex As Exception

            End Try



            Try
                uname = REQUEST2(pPAr1, pPAr2, .Fields("UPTIME_OID").Value, pPAr4)

                Select Case uname
                    Case "0"

                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add("---"))
                    Case Else
                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add(uname))

                End Select
            Catch ex As Exception

            End Try


            Try
                uname = REQUEST2(pPAr1, pPAr2, .Fields("LOCATION_OID").Value, pPAr4)

                Select Case uname
                    Case "0"

                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add("---"))
                    Case Else
                        frmRequestOID.Invoke(Sub() frmRequestOID.lvApparat.Items(CInt(intcountARD)).SubItems.Add(uname))

                End Select

            Catch ex As Exception

            End Try


        End With
        rs.Close()
        rs = Nothing

        '  DateAndTime.Now

        Dim sSQL1 As String
        sSQL1 = "INSERT INTO TBL_ARD_SENS(IPDEV,TEMP,Humi,DT,TM) " &
        "VALUES('" & pPAr1 & "','" & Tem1 & "','" & Hum1 & "','" & Date.Today & "','" & TimeOfDay.Hour & ":" & TimeOfDay.Minute & ":" & TimeOfDay.Second & "')"

        DB7.Execute(sSQL1)

        intcountARD = intcountARD + 1

err_:

    End Sub

End Module
