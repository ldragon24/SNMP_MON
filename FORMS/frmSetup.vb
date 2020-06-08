Imports System
Imports System.IO

Public Class frmSetup
    Private m_SortingColumn As ColumnHeader

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

    Private rCOUNT As Integer

    Public Sub setPassword()

        Dim editWindow As Int32
        editWindow = GetWindow(windowHandle, GW_CHILD)
        SendMessage(editWindow, EM_SETPASSWORDCHAR, asteriskKeyCode, 0)

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        MyBase.WndProc(m)

        If m.Result.ToInt32 = WM_CREATE Then

            windowHandle = FindWindow(vbNullString, inputTitle)

        ElseIf windowHandle > 0 Then
            setPassword()
            windowHandle = 0
        End If

    End Sub

    Private Sub btnAdddev_Click(sender As System.Object, e As System.EventArgs) Handles btnAdddev.Click

        If Len(cmbtipdev.Text) = 0 Then
            MsgBox("Не выбрано устройство", MsgBoxStyle.Information, "SNMP Monitor")
            Exit Sub
        End If

        If Len(cmbDevelop.Text) = 0 Then
            MsgBox("Не выбран производитель", MsgBoxStyle.Information, "SNMP Monitor")
            Exit Sub
        End If

        If Len(ComboBox1.Text) = 0 Then
            MsgBox("Не выбрана модель", MsgBoxStyle.Information, "SNMP Monitor")
            Exit Sub
        End If

        If Len(txtcomdev.Text) = 0 Then
            MsgBox("Не указана Community", MsgBoxStyle.Information, "SNMP Monitor")
            Exit Sub
        End If

        If Len(txtipdev.Text) = 0 Then
            MsgBox("Не указан IP", MsgBoxStyle.Information, "SNMP Monitor")
            Exit Sub
        End If

        Dim sSQL As String

        Dim protokol As String = ""

        Select Case rbtelnet.Checked

            Case True

                protokol = "telnet"

            Case Else

                protokol = "ssh"

        End Select



        Select Case btnAdddev.Text

            Case "Добавить"

                sSQL = "select count(*) as t_n from TBL_DEV where ipdev='" & txtipdev.Text & "'"

                Dim rs As Recordset
                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                Dim sCOUNT As Integer

                With rs
                    sCOUNT = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing


                If sCOUNT = 0 Then

                    sSQL = "INSERT INTO TBL_DEV(TipDev,MODEL,IPDev,CommunityDev,NOT_PING,DevelopDev,protokol) VALUES('" & cmbtipdev.Text & "','" & ComboBox1.Text & "','" & txtipdev.Text & "','" & txtcomdev.Text & "'," & chkCloseSNMP.Checked & ",'" & cmbDevelop.Text & "','" & protokol & "')"

                    DB7.Execute(sSQL)

                    cmbtipdev.Text = ""
                    cmbDevelop.Text = ""
                    txtipdev.Text = ""
                    txtcomdev.Text = ""
                    ComboBox1.Text = ""

                    Call LOAD_DEV_LST()

                Else

                    MsgBox("Устройство с таким адресом уже есть в базе", MsgBoxStyle.Critical, "SNMP APC Monitor")

                    cmbtipdev.Text = ""
                    cmbDevelop.Text = ""
                    txtipdev.Text = ""
                    txtcomdev.Text = ""
                    ComboBox1.Text = ""
                    chkCloseSNMP.Checked = False

                End If

            Case "Сохранить"

                sSQL = "UPDATE TBL_DEV SET TipDev='" & cmbtipdev.Text & "',MODEL='" & ComboBox1.Text & "',IPDev='" & txtipdev.Text & "',CommunityDev='" & txtcomdev.Text & "',NOT_PING=" & chkCloseSNMP.Checked & ",DevelopDev='" & cmbDevelop.Text & "', protokol='" & protokol & "' WHERE id=" & rCOUNT

                DB7.Execute(sSQL)

                cmbtipdev.Text = ""
                txtipdev.Text = ""
                txtcomdev.Text = ""
                ComboBox1.Text = ""
                chkCloseSNMP.Checked = False

                Call LOAD_DEV_LST()

        End Select

        btnAdddev.Text = "Добавить"

    End Sub

    Private Sub frmSetup_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        WaterMark.Edit_SetCueBannerTextFocused(txtipdev, False, "IP-(XXX.XXX.XXX.XXX)")
        WaterMark.Edit_SetCueBannerTextFocused(txtcomdev, False, "Введите Community")

        WaterMark.Edit_SetCueBannerTextFocused(txtAlias, False, "Псевдоним устройства")
        WaterMark.Edit_SetCueBannerTextFocused(txtUserName, False, "Имя пользователя устройства")
        WaterMark.Edit_SetCueBannerTextFocused(txtPassword, False, "Пароль пользователя")
        WaterMark.Edit_SetCueBannerTextFocused(txtDomen, False, "Домен пользователя")

        WaterMark.Edit_SetCueBannerTextFocused(txtUserDom, False, "Имя пользователя")
        WaterMark.Edit_SetCueBannerTextFocused(txtPassDom, False, "Пароль пользователя")
        WaterMark.Edit_SetCueBannerTextFocused(txtDom, False, "Домен пользователя")

        WaterMark.ComboBox_SetCueBannerText(cmbtipdev, "Выбор устройства")
        WaterMark.ComboBox_SetCueBannerText(cmbDevelop, "Производитель")
        WaterMark.ComboBox_SetCueBannerText(ComboBox1, "Модель устройства")
        WaterMark.ComboBox_SetCueBannerText(txtIP, "IP-(XXX.XXX.XXX.XXX)")

        WaterMark.Edit_SetCueBannerTextFocused(txtEmail, False, "Ваша почта - user@domain.local")
        WaterMark.Edit_SetCueBannerTextFocused(txtSMTP, False, "SMTP сервер - domain.local или 192.168.0.1")
        WaterMark.Edit_SetCueBannerTextFocused(TextBox2, False, "Пароль пользователя SMTP")
        WaterMark.Edit_SetCueBannerTextFocused(txtFromMail, False, "От кого почта - user@domain.local")



        btnAdddev.Text = "Добавить"

        cmbtipdev.Text = ""
        txtipdev.Text = ""
        txtcomdev.Text = ""
        ComboBox1.Text = ""

        lstDevice.Columns.Clear()

        lstDevice.Columns.Add("id", 1, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Тип устройства", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Производитель устройства", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Модель", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("IP адрес", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Community", 140, HorizontalAlignment.Left)
        lstDevice.Columns.Add("Опрос", 140, HorizontalAlignment.Left)

        lvT.Columns.Clear()
        lvT.Columns.Add("id", 1, HorizontalAlignment.Left)
        lvT.Columns.Add("Тип устройства", 140, HorizontalAlignment.Left)
        lvT.Columns.Add("Имя пользователя", 140, HorizontalAlignment.Left)
        ' lvT.Columns.Add("Пароль", 140, HorizontalAlignment.Left)
        lvT.Columns.Add("IP адрес", 140, HorizontalAlignment.Left)
        lvT.Columns.Add("Псевдоним", 140, HorizontalAlignment.Left)
        lvT.Columns.Add("Домен\Рабочая группа", 140, HorizontalAlignment.Left)
        lvT.Columns.Add("Опрос", 140, HorizontalAlignment.Left)


        Dim uname As String
        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        txtEmail.Text = objIniFile.GetString("General", "email", "")

        txtSMTP.Text = objIniFile.GetString("General", "SMTP", "")

        txtFromMail.Text = objIniFile.GetString("General", "FromMail", "")

        '###############################################################################
        Dim decr As String = DecryptBytes(objIniFile.GetString("General", "Password", "MsrlJmYom1y7VXvyYN9ifw=="))
        TextBox2.Text = decr
        SMTP_PORT.Value = objIniFile.GetString("General", "Port", "0")
        CheckBox22.Checked = objIniFile.GetString("General", "USETLS", "False")
        '###############################################################################

        nudTIME.Text = objIniFile.GetString("General", "TIME", "20")

        nudTEMP.Text = objIniFile.GetString("General", "TEMP", "35")

        timeOpros.Text = objIniFile.GetString("General", "TIMEOPROS", "5")

        TextBox1.Text = objIniFile.GetString("General", "Putty", "")

        uname = objIniFile.GetString("General", "SendMail", "0")

        Select Case uname

            Case "1"

                chkMail.Checked = True

            Case "0"

                chkMail.Checked = False

        End Select

        uname = objIniFile.GetString("General", "SendMail2", "1")

        Select Case uname

            Case "1"

                chkCrit.Checked = True

            Case "0"

                chkCrit.Checked = False

        End Select

        nudHour.Text = objIniFile.GetString("WMI", "Hour", "7")
        nudMinute.Text = objIniFile.GetString("WMI", "Minute", "45")

        uname = objIniFile.GetString("General", "IBPR", "0")

        Select Case uname

            Case "1"

                RadioButton1.Checked = True
                RadioButton2.Checked = False

            Case "0"

                RadioButton1.Checked = False
                RadioButton2.Checked = True

        End Select

        CheckBox1.Checked = UPSMN
        CheckBox2.Checked = UPS_NAME
        CheckBox3.Checked = UPC_Contact
        CheckBox4.Checked = UPS_MODEL
        CheckBox5.Checked = UPS_SN
        CheckBox6.Checked = UPS_BATTERY_TIME
        CheckBox7.Checked = UPS_BATTARY_ENERGY
        CheckBox8.Checked = UPS_BATTARY_SOST
        CheckBox9.Checked = UPS_BATTARY_ZAM
        CheckBox10.Checked = UPS_TIME_WORK
        CheckBox11.Checked = UPS_IP
        CheckBox12.Checked = UPS_MAC
        CheckBox13.Checked = UPS_IN_ACDC
        CheckBox14.Checked = UPS_OUT_ACDC
        CheckBox15.Checked = UPS_MHZ
        CheckBox16.Checked = UPS_LOAD
        CheckBox17.Checked = UPS_STATUS
        CheckBox18.Checked = UPS_TEST
        CheckBox19.Checked = UPS_TEST_DATE
        CheckBox20.Checked = UPS_TEMP
        CheckBox21.Checked = UPS_TEMP2

        CheckBox23.Checked = COMM_MN
        CheckBox25.Checked = COMM_NN
        CheckBox27.Checked = COMM_CONTACT
        CheckBox29.Checked = COMM_MOD
        CheckBox31.Checked = COMM_SN
        CheckBox41.Checked = COMM_INWORK
        CheckBox43.Checked = COMM_IP
        CheckBox42.Checked = COMM_MAC
        CheckBox26.Checked = COMM_THEMP
        CheckBox24.Checked = COMM_FLASH

        Call LOAD_DEV_LST()
        Call LOAD_DEV_LST2()

    End Sub

    Private Sub LOAD_DEV_LST()


        lstDevice.Items.Clear()
        lstDevice.ListViewItemSorter = Nothing

        lstDevice.Items.Clear()

        Dim intj As Integer = 0
        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev<>'Сервер' and TipDev <>'АРМ'"

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
                rs.Open("SELECT * FROM TBL_DEV WHERE TipDev<>'Сервер' and TipDev <>'АРМ'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF

                        lstDevice.Items.Add(.Fields("id").Value) 'col no. 1
                        lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("TipDev").Value)
                        lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("DevelopDev").Value)
                        lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("MODEL").Value)
                        lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value)
                        lstDevice.Items(CInt(intj)).SubItems.Add(.Fields("CommunityDev").Value)

                        If Not IsDBNull(.Fields("NOT_PING").Value) Then

                            If .Fields("NOT_PING").Value = 0 Then

                                lstDevice.Items(CInt(intj)).SubItems.Add("Да")
                            Else

                                lstDevice.Items(CInt(intj)).SubItems.Add("Нет")
                            End If

                        Else

                            lstDevice.Items(CInt(intj)).SubItems.Add("")

                        End If

                        intj = intj + 1

                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

        End Select

        ResList(lstDevice)

    End Sub

    Private Sub LOAD_DEV_LST2()

        lvT.Items.Clear()
        lvT.ListViewItemSorter = Nothing

        lvT.Items.Clear()

        Dim intj As Integer = 0
        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev='Сервер' or TipDev ='АРМ'"

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
                rs.Open("SELECT * FROM TBL_DEV WHERE TipDev='Сервер' or TipDev ='АРМ'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF
                        lvT.Items.Add(.Fields("id").Value) 'col no. 1
                        lvT.Items(CInt(intj)).SubItems.Add(.Fields("TipDev").Value)

                        If Not IsDBNull(.Fields("DevelopDev").Value) Then

                            lvT.Items(CInt(intj)).SubItems.Add(.Fields("DevelopDev").Value)

                        Else

                            lvT.Items(CInt(intj)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("IPDev").Value) Then

                            lvT.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value)

                        Else

                            lvT.Items(CInt(intj)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("Alias").Value) Then

                            lvT.Items(CInt(intj)).SubItems.Add(.Fields("Alias").Value)

                        Else

                            lvT.Items(CInt(intj)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("CommunityDev").Value) Then

                            lvT.Items(CInt(intj)).SubItems.Add(.Fields("CommunityDev").Value)

                        Else

                            lvT.Items(CInt(intj)).SubItems.Add("")

                        End If

                        If Not IsDBNull(.Fields("NOT_PING").Value) Then

                            If .Fields("NOT_PING").Value = 0 Then

                                lvT.Items(CInt(intj)).SubItems.Add("Да")
                            Else

                                lvT.Items(CInt(intj)).SubItems.Add("Нет")
                            End If

                        Else

                            lvT.Items(CInt(intj)).SubItems.Add("")

                        End If

                        intj = intj + 1
                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing
        End Select



        'sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE TipDev='АРМ'"


        'rs = New Recordset
        'rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        'With rs
        '    sCOUNT = .Fields("t_n").Value
        'End With
        'rs.Close()
        'rs = Nothing

        'Select Case sCOUNT

        '    Case 0

        '    Case Else

        '        rs = New Recordset
        '        rs.Open("SELECT * FROM TBL_DEV WHERE TipDev='АРМ'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        '        With rs
        '            .MoveFirst()
        '            Do While Not .EOF
        '                lvT.Items.Add(.Fields("id").Value) 'col no. 1
        '                lvT.Items(CInt(intj)).SubItems.Add(.Fields("TipDev").Value)

        '                If Not IsDBNull(.Fields("DevelopDev").Value) Then

        '                    lvT.Items(CInt(intj)).SubItems.Add(.Fields("DevelopDev").Value)

        '                Else

        '                    lvT.Items(CInt(intj)).SubItems.Add("")

        '                End If

        '                If Not IsDBNull(.Fields("IPDev").Value) Then

        '                    lvT.Items(CInt(intj)).SubItems.Add(.Fields("IPDev").Value)

        '                Else

        '                    lvT.Items(CInt(intj)).SubItems.Add("")

        '                End If

        '                If Not IsDBNull(.Fields("Alias").Value) Then

        '                    lvT.Items(CInt(intj)).SubItems.Add(.Fields("Alias").Value)

        '                Else

        '                    lvT.Items(CInt(intj)).SubItems.Add("")

        '                End If

        '                If Not IsDBNull(.Fields("CommunityDev").Value) Then

        '                    lvT.Items(CInt(intj)).SubItems.Add(.Fields("CommunityDev").Value)

        '                Else

        '                    lvT.Items(CInt(intj)).SubItems.Add("")

        '                End If

        '                If Not IsDBNull(.Fields("NOT_PING").Value) Then

        '                    If .Fields("NOT_PING").Value = 0 Then

        '                        lvT.Items(CInt(intj)).SubItems.Add("Да")
        '                    Else

        '                        lvT.Items(CInt(intj)).SubItems.Add("Нет")
        '                    End If

        '                Else

        '                    lvT.Items(CInt(intj)).SubItems.Add("")

        '                End If

        '                intj = intj + 1
        '                .MoveNext()
        '            Loop
        '        End With
        '        rs.Close()
        '        rs = Nothing
        'End Select









        ResList(lvT)

    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        objIniFile.WriteString("General", "email", txtEmail.Text)
        objIniFile.WriteString("General", "FromMail", txtFromMail.Text)
        objIniFile.WriteString("General", "SMTP", txtSMTP.Text)
        objIniFile.WriteString("General", "TIME", nudTIME.Text)
        objIniFile.WriteString("General", "TIMEOPROS", timeOpros.Text)
        '###############################################################################
        objIniFile.WriteString("General", "USETLS", CheckBox22.Checked)
        objIniFile.WriteString("General", "Port", SMTP_PORT.Value)
        Dim Code As String = EncryptString(TextBox2.Text)
        objIniFile.WriteString("General", "Password", Code)
        '###############################################################################

        objIniFile.WriteString("General", "TEMP", nudTEMP.Text)


        Select Case chkMail.Checked

            Case False

                objIniFile.WriteString("General", "SendMail", "0")
                SendMail_ = 0

            Case True

                objIniFile.WriteString("General", "SendMail", "1")
                SendMail_ = 1

        End Select

        Select Case chkCrit.Checked

            Case False

                objIniFile.WriteString("General", "SendMail2", "0")
                SendMail2_ = 0

            Case True

                objIniFile.WriteString("General", "SendMail2", "1")
                SendMail2_ = 1

        End Select

        If RadioButton1.Checked = True Then

            objIniFile.WriteString("General", "IBPR", "1")
            sIBPR = True
        Else

            objIniFile.WriteString("General", "IBPR", "0")
            sIBPR = False
        End If

        SMTP_ = txtSMTP.Text
        EMAIL_ = txtEmail.Text
        FromEMAIL_ = txtFromMail.Text
        TEMP_ = nudTEMP.Text()
        TIMEOPROS_ = timeOpros.Text

        'Call frmRequestOID.TIMER_EN()

    End Sub

    Private Sub lstDevice_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lstDevice.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
       lstDevice.Columns(e.Column)
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

        lstDevice.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lstDevice.Sort()
    End Sub

    Private Sub lstDevice_DoubleClick(sender As Object, e As System.EventArgs) Handles lstDevice.DoubleClick
        If lstDevice.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        'Dim rCOUNT As Integer

        For z = 0 To lstDevice.SelectedItems.Count - 1
            rCOUNT = (lstDevice.SelectedItems(z).Text)
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
                    cmbtipdev.Text = .Fields("TipDev").Value
                    ComboBox1.Text = .Fields("MODEL").Value
                    txtipdev.Text = .Fields("IPDev").Value
                    txtcomdev.Text = .Fields("CommunityDev").Value
                    chkCloseSNMP.Checked = .Fields("NOT_PING").Value
                    cmbDevelop.Text = .Fields("DevelopDev").Value

                    Dim protokol As String = ""
                    If Not IsDBNull(.Fields("protokol").Value) Then

                        protokol = .Fields("protokol").Value

                    Else

                        protokol = "telnet"

                    End If

                    Select Case protokol

                        Case "telnet"

                            rbtelnet.Checked = True

                        Case "ssh"

                            rbssh.Checked = True

                    End Select



                End With
                rs.Close()
                rs = Nothing

        End Select

        btnAdddev.Text = "Сохранить"

    End Sub

    Private Sub lstDevice_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstDevice.MouseUp

        If lstDevice.Items.Count = 0 Then Exit Sub

        If e.Button = Windows.Forms.MouseButtons.Right Then
            cmnu.Show(CType(sender, Control), e.Location)

        Else

        End If

    End Sub

    Private Sub УдалитьToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles УдалитьToolStripMenuItem.Click
        If lstDevice.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lstDevice.SelectedItems.Count - 1
            rCOUNT = (lstDevice.SelectedItems(z).Text)
        Next

        If MsgBox("Будет удалена запись" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            DB7.Execute("Delete FROM TBL_DEV WHERE id=" & rCOUNT)

        Else

        End If

        Call LOAD_DEV_LST()

    End Sub

    Private Sub txtipdev_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtipdev.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Asc(e.KeyChar) <> 8 And Asc(e.KeyChar) <> 46 Then e.Handled = True

    End Sub

    Private Sub cmbtipdev_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbtipdev.SelectedIndexChanged

        cmbDevelop.Items.Clear()
        cmbDevelop.Text = ""

        Select Case cmbtipdev.Text

            Case "Источник бесперебойного питания"
                cmbDevelop.Items.Add("APC")
                cmbDevelop.Items.Add("EATON")

            Case "Коммутаторы"

                cmbDevelop.Items.Add("CISCO")

            Case "Принтеры"

                cmbDevelop.Items.Add("HP")
                cmbDevelop.Items.Add("Aficio")

            Case "Arduino"

                cmbDevelop.Items.Add("Self")

        End Select


        On Error GoTo err_

        ComboBox1.Items.Clear()

        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV_OID WHERE Device='" & cmbtipdev.Text & "'"

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
                rs.Open("SELECT * FROM TBL_DEV_OID WHERE Device='" & cmbtipdev.Text & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF
                        ComboBox1.Items.Add(.Fields("Model").Value)
                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

        End Select

        Exit Sub
err_:

        MsgBox(Err.Description)




    End Sub

    Private Sub ToolStripButton1_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

        frmDev.ComboBox1.Text = cmbtipdev.Text
        frmDev.ShowDialog(Me)

    End Sub

    Private Sub cmbDevelop_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        On Error GoTo err_

        ComboBox1.Items.Clear()

        Dim sCOUNT As Integer

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV_OID"

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
                rs.Open("SELECT * FROM TBL_DEV_OID WHERE Device='" & cmbtipdev.Text & "'", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                With rs
                    .MoveFirst()
                    Do While Not .EOF
                        ComboBox1.Items.Add(.Fields("Model").Value)
                        .MoveNext()
                    Loop
                End With
                rs.Close()
                rs = Nothing

        End Select

        Exit Sub
err_:

        MsgBox(Err.Description)
    End Sub

    Private Sub ToolStripButton2_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripButton2.Click

        frmEdit_Dev_spr.ShowDialog(Me)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        cmbtipdev.Text = ""
        txtipdev.Text = ""
        txtcomdev.Text = ""
        ComboBox1.Text = ""

        btnAdddev.Text = "Добавить"

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim ePatch As String
        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        ePatch = objIniFile.GetString("General", "Putty", PrPath)

        Dim fdlg As OpenFileDialog = New OpenFileDialog()

        fdlg.Title = "Путь к гипертерминалу Putty"
        fdlg.InitialDirectory = ePatch
        fdlg.Filter = "binaries files (*.exe)|*.exe"
        fdlg.FilterIndex = 2

        fdlg.RestoreDirectory = True

        If fdlg.ShowDialog() = DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor

            PuttyFilePatch = fdlg.FileName

        End If

        TextBox1.Text = PuttyFilePatch

        objIniFile.WriteString("General", "Putty", PuttyFilePatch)

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)

        System.Diagnostics.Process.Start(PuttyFilePatch)

    End Sub

    Private Sub btnAddServ_Click(sender As System.Object, e As System.EventArgs) Handles btnAddServ.Click

        Dim sSQL As String

        If Len(txtAlias.Text) = 0 Then txtAlias.Text = txtIP.Text

        Dim sTMP As String

        Select Case chkNARM.Checked

            Case True

                sTMP = "Сервер"

            Case False

                sTMP = "АРМ"
                chkClose.Checked = True
        End Select



        Select Case btnAddServ.Text

            Case "Добавить"

                sSQL = "select count(*) as t_n from TBL_DEV where ipdev='" & txtIP.Text & "'"

                Dim rs As Recordset
                rs = New Recordset
                rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

                Dim sCOUNT As Integer

                With rs
                    sCOUNT = .Fields("t_n").Value
                End With
                rs.Close()
                rs = Nothing

                If sCOUNT = 0 Then
                    Dim Code As String = EncryptString(txtPassword.Text)

                    'chkAnt

                    sSQL = "INSERT INTO TBL_DEV(TipDev,DevelopDev,MODEL,IPDev,Alias,CommunityDev,ping,NOT_PING,Anti) VALUES('" & sTMP & "','" & txtUserName.Text & "','" & Code & "','" & txtIP.Text & "','" & txtAlias.Text & "','" & txtDomen.Text & "'," & chkPing.Checked & "," & chkClose.Checked & "," & chkAnt.Checked & ")"

                    DB7.Execute(sSQL)

                    txtUserName.Text = ""
                    txtPassword.Text = ""
                    txtIP.Text = ""
                    txtAlias.Text = ""
                    txtDomen.Text = ""
                    chkPing.Checked = False
                    chkClose.Checked = False
                    chkAnt.Checked = False

                    'chkNARM


                    Call LOAD_DEV_LST2()

                Else

                    MsgBox("Устройство с таким адресом уже есть в базе", MsgBoxStyle.Critical, "SNMP APC Monitor")

                    txtUserName.Text = ""
                    txtPassword.Text = ""
                    txtIP.Text = ""
                    txtAlias.Text = ""
                    txtDomen.Text = ""
                    chkPing.Checked = False
                    chkClose.Checked = False
                    chkAnt.Checked = False

                End If

            Case Else

                Dim Code As String = EncryptString(txtPassword.Text)
                sSQL = "UPDATE TBL_DEV SET TipDev='" & sTMP & "', DevelopDev='" & txtUserName.Text & "',MODEL='" & Code & "',IPDev='" & txtIP.Text & "',Alias='" & txtAlias.Text & "',CommunityDev='" & txtDomen.Text & "',ping=" & chkPing.Checked & ",NOT_PING=" & chkClose.Checked & ",Anti=" & chkAnt.Checked & " WHERE id=" & rCOUNT

                DB7.Execute(sSQL)

                txtUserName.Text = ""
                txtPassword.Text = ""
                txtIP.Text = ""
                txtAlias.Text = ""
                txtDomen.Text = ""
                chkPing.Checked = False
                chkClose.Checked = False

                Call LOAD_DEV_LST2()

        End Select

        txtUserName.Text = ""
        txtPassword.Text = ""
        txtIP.Text = ""
        txtAlias.Text = ""
        txtDomen.Text = ""
        chkPing.Checked = False
        chkClose.Checked = False
        chkAnt.Checked = False

        btnAddServ.Text = "Добавить"
    End Sub

    Private Sub lvT_ColumnClick(sender As Object, e As System.Windows.Forms.ColumnClickEventArgs) Handles lvT.ColumnClick
        Dim new_sorting_column As ColumnHeader = _
      lvT.Columns(e.Column)
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

        lvT.ListViewItemSorter = New ListViewComparer(e.Column, sort_order)

        lvT.Sort()
    End Sub

    Private Sub lvT_DoubleClick(sender As Object, e As System.EventArgs) Handles lvT.DoubleClick

        On Error Resume Next

        If lvT.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        'Dim rCOUNT As Integer

        For z = 0 To lvT.SelectedItems.Count - 1
            rCOUNT = (lvT.SelectedItems(z).Text)
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

                    txtUserName.Text = .Fields("DevelopDev").Value

                    Dim decr As String = DecryptBytes(.Fields("MODEL").Value)

                    txtPassword.Text = decr

                    txtIP.Text = .Fields("IPDev").Value

                    txtAlias.Text = .Fields("Alias").Value

                    txtDomen.Text = .Fields("CommunityDev").Value

                    chkPing.Checked = .Fields("Ping").Value

                    chkClose.Checked = .Fields("NOT_PING").Value

                    chkAnt.Checked = .Fields("Anti").Value

                    Select Case .Fields("TipDev").Value

                        Case "Сервер"

                            chkNARM.Checked = True

                        Case "АРМ"

                            chkNARM.Checked = False

                    End Select

                    ' TipDev.c

                End With
                rs.Close()
                rs = Nothing

        End Select

        btnAddServ.Text = "Сохранить"
        txtPassword.PasswordChar = "*"

    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        returnedPW = InputBox("Введите мастер пароль для просмотра информации!", inputTitle, "password", 0)

        If Not returnedPW = Nothing AndAlso returnedPW = Chr(76) + Chr(102) + Chr(112) + Chr(108) + Chr(104) + Chr(102) + Chr(49) + Chr(118) + Chr(102) + Chr(33) Then

            txtPassword.PasswordChar = ""

        Else

            MessageBox.Show("Не верный пароль!" & vbCrLf & "ПОДСКАЗКА - Мир, Труд, Май!", " Попробуйте еще раз")

        End If

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

        If lvT.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        Dim rCOUNT As Integer

        For z = 0 To lvT.SelectedItems.Count - 1
            rCOUNT = (lvT.SelectedItems(z).Text)
        Next

        If MsgBox("Будет удалена запись" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            DB7.Execute("Delete FROM TBL_DEV WHERE id=" & rCOUNT)

            Call LOAD_DEV_LST2()

        Else

        End If

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        chkPing.Checked = False
        txtIP.Text = ""
        txtAlias.Text = ""
        txtUserName.Text = ""
        txtPassword.Text = ""
        txtDomen.Text = ""
        btnAddServ.Text = "Добавить"

    End Sub

    Private Sub chkCrit_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkCrit.CheckedChanged

        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        Select Case chkCrit.Checked

            Case False

                objIniFile.WriteString("General", "SendMail2", "0")
                SendMail2_ = 0

            Case True

                objIniFile.WriteString("General", "SendMail2", "1")
                SendMail2_ = 1

        End Select
    End Sub

    Private Sub chkMail_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMail.CheckedChanged

        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        Select Case chkMail.Checked

            Case False

                objIniFile.WriteString("General", "SendMail", "0")
                SendMail_ = 0

            Case True

                objIniFile.WriteString("General", "SendMail", "1")
                SendMail_ = 1

        End Select

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox1.CheckedChanged

        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPSMN", CheckBox1.Checked)
        UPSMN = CheckBox1.Checked
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox2.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_NAME", CheckBox2.Checked)
        UPS_NAME = CheckBox2.Checked
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox3.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPC_Contact", CheckBox3.Checked)
        UPC_Contact = CheckBox3.Checked
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox4.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_MODEL", CheckBox4.Checked)
        UPS_MODEL = CheckBox4.Checked
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox5.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_SN", CheckBox5.Checked)
        UPS_SN = CheckBox5.Checked
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox6.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_BATTERY_TIME", CheckBox6.Checked)
        UPS_BATTERY_TIME = CheckBox6.Checked
    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox7.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_BATTARY_ENERGY", CheckBox7.Checked)
        UPS_BATTARY_ENERGY = CheckBox7.Checked
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox8.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_BATTARY_SOST", CheckBox8.Checked)
        UPS_BATTARY_SOST = CheckBox8.Checked
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox9.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_BATTARY_ZAM", CheckBox9.Checked)
        UPS_BATTARY_ZAM = CheckBox9.Checked
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox10.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_TIME_WORK", CheckBox10.Checked)
        UPS_TIME_WORK = CheckBox10.Checked
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox11.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_IP", CheckBox11.Checked)
        UPS_IP = CheckBox11.Checked
    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox12.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_MAC", CheckBox12.Checked)
        UPS_MAC = CheckBox12.Checked
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox13.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_IN_ACDC", CheckBox13.Checked)
        UPS_IN_ACDC = CheckBox13.Checked
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox14.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_OUT_ACDC", CheckBox14.Checked)
        UPS_OUT_ACDC = CheckBox14.Checked
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox15.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_MHZ", CheckBox15.Checked)
        UPS_MHZ = CheckBox15.Checked
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox16.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_LOAD", CheckBox16.Checked)
        UPS_LOAD = CheckBox16.Checked
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox17.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_STATUS", CheckBox17.Checked)
        UPS_STATUS = CheckBox17.Checked
    End Sub

    Private Sub CheckBox18_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox18.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_TEST", CheckBox18.Checked)
        UPS_TEST = CheckBox18.Checked
    End Sub

    Private Sub CheckBox19_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox19.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_TEST_DATE", CheckBox19.Checked)
        UPS_TEST_DATE = CheckBox19.Checked
    End Sub

    Private Sub CheckBox20_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox20.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_TEMP", CheckBox20.Checked)
        UPS_TEMP = CheckBox20.Checked
    End Sub

    Private Sub CheckBox21_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox21.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("UPS", "UPS_TEMP2", CheckBox21.Checked)
        UPS_TEMP2 = CheckBox21.Checked
    End Sub

    Private Sub CheckBox23_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox23.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_MN", CheckBox23.Checked)
        COMM_MN = CheckBox23.Checked
    End Sub

    Private Sub CheckBox25_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox25.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_NN", CheckBox25.Checked)
        COMM_NN = CheckBox25.Checked
    End Sub

    Private Sub CheckBox27_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox27.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_CONTACT", CheckBox27.Checked)
        COMM_CONTACT = CheckBox27.Checked
    End Sub

    Private Sub CheckBox29_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox29.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_MOD", CheckBox29.Checked)
        COMM_MOD = CheckBox29.Checked
    End Sub

    Private Sub CheckBox31_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox31.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_SN", CheckBox31.Checked)
        COMM_SN = CheckBox31.Checked
    End Sub

    Private Sub CheckBox41_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox41.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_INWORK", CheckBox41.Checked)
        COMM_INWORK = CheckBox41.Checked
    End Sub

    Private Sub CheckBox43_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox43.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_IP", CheckBox43.Checked)
        COMM_IP = CheckBox43.Checked
    End Sub

    Private Sub CheckBox42_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox42.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_MAC", CheckBox42.Checked)
        COMM_MAC = CheckBox42.Checked
    End Sub

    Private Sub CheckBox26_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox26.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_THEMP", CheckBox26.Checked)
        COMM_THEMP = CheckBox26.Checked
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton1.CheckedChanged

        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        If RadioButton1.Checked = True Then

            objIniFile.WriteString("General", "IBPR", "1")
            sIBPR = True
        Else

            objIniFile.WriteString("General", "IBPR", "0")
            sIBPR = False
        End If

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles RadioButton2.CheckedChanged

        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        If RadioButton1.Checked = True Then

            objIniFile.WriteString("General", "IBPR", "1")
            sIBPR = True
        Else

            objIniFile.WriteString("General", "IBPR", "0")
            sIBPR = False
        End If

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click

        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        objIniFile.WriteString("WMI", "Hour", nudHour.Text)
        objIniFile.WriteString("WMI", "Minute", nudMinute.Text)

        wmiHOUR = nudHour.Text
        wmiMinute = nudMinute.Text

    End Sub

    Private Sub CheckBox24_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBox24.CheckedChanged
        Dim objIniFile As New IniFile(PrPath & "settings.ini")
        objIniFile.WriteString("COMM", "COMM_FLASH", CheckBox24.Checked)
        COMM_FLASH = CheckBox24.Checked
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        On Error GoTo err_
        If MsgBox("Будут удалены записи о обрывах связи и данные ИБП" & vbCrLf & "Хотите продолжить?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then


            Dim SDA As DateTime
            SDA = Date.Today.AddDays(-4)
            DB7.Execute("DELETE FROM TBL_PING_SL Where DT <=" & get_date_format(SDA))
            DB7.Execute("DELETE FROM TBL_PING Where DT <=" & get_date_format(SDA))
            SDA = Date.Today.AddMonths(-1)
            DB7.Execute("DELETE FROM IBP_MON Where DT <=" & get_date_format(SDA))


        Else

        End If

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Exclamation, Application.ProductName)
        Call COMPARE_DB()
    End Sub

    Function get_date_format(ByVal str_date As String)

        Dim mm As String = Mid(str_date, 4, 2)
        Dim dd As String = Microsoft.VisualBasic.Left(str_date, 2)
        Dim gggg As String = Microsoft.VisualBasic.Right(str_date, 4)
        Return "#" & mm & "/" & dd & "/" & gggg & "#"

    End Function

    Private Sub lstDevice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstDevice.SelectedIndexChanged

    End Sub

    Private Sub КопироватьToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles КопироватьToolStripMenuItem.Click
        If lstDevice.Items.Count = 0 Then Exit Sub

        Dim z As Integer
        'Dim rCOUNT As Integer

        For z = 0 To lstDevice.SelectedItems.Count - 1
            rCOUNT = (lstDevice.SelectedItems(z).Text)
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
                    cmbtipdev.Text = .Fields("TipDev").Value
                    ComboBox1.Text = .Fields("MODEL").Value
                    ' txtipdev.Text = .Fields("IPDev").Value
                    txtcomdev.Text = .Fields("CommunityDev").Value
                    chkCloseSNMP.Checked = .Fields("NOT_PING").Value
                End With
                rs.Close()
                rs = Nothing

        End Select

        txtipdev.Text = ""

        btnAdddev.Text = "Добавить"
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        On Error GoTo err_

        Call COMPARE_DB()

err_:
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged, cmbDevelop.SelectedIndexChanged

    End Sub

    Private Sub lvT_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lvT.SelectedIndexChanged

    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        On Error GoTo err_

        Dim sSQL As String

        sSQL = "SELECT count(*) as t_n FROM TBL_DEV WHERE CommunityDev='" & txtDom.Text & "'"

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

                Exit Sub

            Case Else

                Dim Code As String = EncryptString(txtPassDom.Text)

                sSQL = "UPDATE TBL_DEV SET MODEL='" & Code & "', DevelopDev='" & txtUserDom.Text & "' WHERE CommunityDev='" & txtDom.Text & "'"

                DB7.Execute(sSQL)

        End Select


        MsgBox("Пароль для пользователя: " & txtUserDom.Text & " успешно изменен", vbInformation, "SNMP")

        txtUserDom.Text = ""
        txtDom.Text = ""
        txtPassDom.Text = ""


        Exit Sub
err_:
        MsgBox(Err.Description, vbCritical, "SNMP")

    End Sub

    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click

        txtPassDom.Text = ""
        txtUserDom.Text = ""
        txtDom.Text = ""

    End Sub

    Private Sub chkNARM_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNARM.CheckedChanged

    End Sub

    Private Sub TableLayoutPanel7_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles TableLayoutPanel7.Paint

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles rbtelnet.CheckedChanged

    End Sub
End Class