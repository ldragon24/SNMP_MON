Imports System.Threading

Module MOD_NEW_OPROS

    Public Sub OPROS_IBP()
        Dim net As New Net.NetworkInformation.Ping

        Call frmRequestOID.list_ups_filling()

        Dim intPing As Integer = 0

        Dim rs As Recordset
        Dim sSQL As String

        sSQL = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='Источник бесперебойного питания' AND NOT_PING=0"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim sCount As Integer

        With rs
            sCount = .Fields("tn").Value
        End With
        rs.Close()
        rs = Nothing

        If sCount = 0 Then Exit Sub

        sSQL = "SELECT * FROM TBL_DEV WHERE TipDev='Источник бесперебойного питания' AND NOT_PING=0 ORDER BY ipdev"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
START:

                Select Case net.Send(.Fields("IPDev").Value, 20).status

                    '  Select Case My.Computer.Network.Ping(.Fields("IPDev").Value)

                    Case System.Net.NetworkInformation.IPStatus.Success

                        PAr1 = .Fields("IPDev").Value
                        PAr2 = .Fields("CommunityDev").Value
                        PAr3 = .Fields("MODEL").Value
                        PAr4 = .Fields("DevelopDev").Value
                        PAr5 = .Fields("Id").Value

                        frmRequestOID.lstUPS.BeginInvoke(New MethodInvoker(AddressOf REQUEST_OID_IBP_DB))

                        My.Application.DoEvents()

                        zCounter = zCounter + 1

                    Case False

                        'Формируем сообщение о недоступности устройства в сети
                        '5 раз пингуем, дабы убедиться в недоступности. 5 раз на всякий случай...

                        intPing = intPing + 1
                        If intPing < 5 Then GoTo START

                        sTXT = "Информация"

                        Call MESSAGE_(.Fields("TipDev").Value & " " & .Fields("IPDev").Value & " не доступен")

                        tmpIntj2 = tmpIntj2 + 1

                End Select

                intPing = 0

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        ResList(frmRequestOID.lstUPS)

    End Sub

    Public Sub OPROS_COMM()
        Dim net As New Net.NetworkInformation.Ping

        frmRequestOID.lstComm.Items.Clear()

        Call frmRequestOID.list_comm_filling()

        Dim intPing As Integer = 0

        Dim rs As Recordset
        Dim sSQL As String

        sSQL = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='Коммутаторы' AND NOT_PING=0"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim sCount As Integer
        With rs
            sCount = .Fields("tn").Value
        End With
        rs.Close()
        rs = Nothing

        If sCount = 0 Then Exit Sub

        sSQL = "SELECT * FROM TBL_DEV WHERE TipDev='Коммутаторы' AND NOT_PING=0 ORDER BY ipdev"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
START:

                Select Case Net.Send(.Fields("IPDev").Value, 20).status
                    'Select Case My.Computer.Network.Ping(.Fields("IPDev").Value)

                    Case System.Net.NetworkInformation.IPStatus.Success

                        cPAr1 = .Fields("IPDev").Value
                        cPAr2 = .Fields("CommunityDev").Value
                        cPAr3 = .Fields("MODEL").Value
                        cPAr4 = .Fields("DevelopDev").Value
                        cPAr5 = .Fields("Id").Value

                        frmRequestOID.lstComm.BeginInvoke(New MethodInvoker(AddressOf REQUEST_OID_COMM_DB))

                        My.Application.DoEvents()

                        zCounter = zCounter + 1

                    Case False

                        'Формируем сообщение о недоступности устройства в сети

                        '5 раз пингуем, дабы убедиться в недоступности. 5 раз на всякий случай...
                        intPing = intPing + 1
                        If intPing < 5 Then GoTo START

                        sTXT = "Информация"

                        Call MESSAGE_(.Fields("TipDev").Value & " " & .Fields("IPDev").Value & " не доступен")

                        tmpIntj2 = tmpIntj2 + 1

                End Select

                intPing = 0

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        ResList(frmRequestOID.lstComm)
    End Sub

    Public Sub OPROS_PRN()
        Dim net As New Net.NetworkInformation.Ping
        frmRequestOID.lvPrinter.Items.Clear()

        Dim intPing As Integer = 0

        Dim rs As Recordset
        Dim sSQL As String

        sSQL = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='Принтеры' AND NOT_PING=0"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim sCount As Integer

        With rs
            sCount = .Fields("tn").Value
        End With
        rs.Close()
        rs = Nothing

        If sCount = 0 Then Exit Sub

        sSQL = "SELECT * FROM TBL_DEV WHERE TipDev='Принтеры' AND NOT_PING=0 ORDER BY ipdev"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
START:
                Select Case Net.Send(.Fields("IPDev").Value, 20).status
                    'Select Case My.Computer.Network.Ping(.Fields("IPDev").Value)

                    Case System.Net.NetworkInformation.IPStatus.Success

                        pPAr1 = .Fields("IPDev").Value
                        pPAr2 = .Fields("CommunityDev").Value
                        pPAr3 = .Fields("MODEL").Value
                        pPAr4 = .Fields("DevelopDev").Value
                        pPAr5 = .Fields("Id").Value

                        frmRequestOID.lvPrinter.BeginInvoke(New MethodInvoker(AddressOf REQUEST_OID_PRINT_DB))
                        My.Application.DoEvents()

                        zCounter = zCounter + 1

                    Case False

                        intPing = intPing + 1
                        'If intPing < 5 Then GoTo START

                        tmpIntj2 = tmpIntj2 + 1

                End Select


                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        ResList(frmRequestOID.lvPrinter)

    End Sub

    Public Sub OPROS_ARDUINO()

        Dim net As New Net.NetworkInformation.Ping

        frmRequestOID.lvApparat.Items.Clear()

        '   Dim intard As Integer = 0

        Dim rs As Recordset
        Dim sSQL As String

        sSQL = "SELECT count(*) as tn FROM TBL_DEV WHERE TipDev='Arduino' AND NOT_PING=0"

        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)
        Dim sCount As Integer

        With rs
            sCount = .Fields("tn").Value
        End With
        rs.Close()
        rs = Nothing

        If sCount = 0 Then Exit Sub

        sSQL = "SELECT * FROM TBL_DEV WHERE TipDev='Arduino' AND NOT_PING=0 ORDER BY ipdev"
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            .MoveFirst()
            Do While Not .EOF
START:
                Select Case net.Send(.Fields("IPDev").Value, 20).status
                    'Select Case My.Computer.Network.Ping(.Fields("IPDev").Value)

                    Case System.Net.NetworkInformation.IPStatus.Success

                        pPAr1 = .Fields("IPDev").Value
                        pPAr2 = .Fields("CommunityDev").Value
                        pPAr3 = .Fields("MODEL").Value
                        pPAr4 = .Fields("DevelopDev").Value
                        pPAr5 = .Fields("Id").Value

                        frmRequestOID.lvApparat.BeginInvoke(New MethodInvoker(AddressOf REQUEST_OID_ARDUINO_DB))
                        My.Application.DoEvents()

                        zCounter = zCounter + 1

                    Case False

                        '  intard = intard + 1
                        'If intPing < 5 Then GoTo START

                End Select

                .MoveNext()
            Loop
        End With
        rs.Close()
        rs = Nothing

        '   ResList(frmRequestOID.lvApparat)

    End Sub



End Module


