Imports System
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module MOD_DATABASE
    Public unamDB As String
    Public DBserv As String
    Public DBtabl As String
    Public DBuser As String
    Public DBpass As String
    Public DBport As String
    Public DBsec As String
    Public DATAB As Boolean
    Public BasePath As String
    Public Base_Name As String
    Public DB_N As String

    Public strPassword As String, Temp As String
    Public SUBD As String
    Public DB7 As Connection
    Public ConNect As String

    Public PuttyFilePatch As String
    Public sIBPR As Boolean
    Public tmpIntj As Integer
    Public tmpIntj2 As Integer
    Public wmiHOUR As Integer
    Public wmiMinute As Integer
    Public sHOST As String

    Private b As Byte() = Convert.FromBase64String("0JTQkNC30LTQoNCwMdCc0LAh0JTQsNC30JTRgNCwMtC80LAh0JzQuNGA0YM=")

    Public strComputer1 As String
    Public Authority1 As String
    Public wmiUser1 As String
    Public wmiPasword1 As String
    Public ssID1 As Integer
    Public Journal1 As String
    Public CNAME As String

    Public IBPenable As Boolean = False

    '###############################################################################################
    '###############################################################################################
    '###############################################################################################

    Public Function EncryptString(ByVal sTEXTBLOC As String) As String

        Try

            'Dim DESkey As New DESCryptoServiceProvider()
            'DESkey.IV = UnicodeEncoding.Unicode.GetBytes(Mid(sCRTKey, 1, 8)) 'вектор
            'DESkey.Key = UnicodeEncoding.Unicode.GetBytes(Mid(sCRTKey, 9, 16)) 'Ключ
            'Dim DinBlock() As Byte = UnicodeEncoding.Unicode.GetBytes(sTEXTBLOC)
            'Dim DEStransForm As ICryptoTransform = DESkey.CreateEncryptor()
            'Dim DutBlock() As Byte = DEStransForm.TransformFinalBlock(DinBlock, 0, DinBlock.Length)

            'Return Convert.ToBase64String(DutBlock)

            Dim AESkey As New AesCryptoServiceProvider()
            AESkey.IV = UnicodeEncoding.Unicode.GetBytes(Mid(System.Text.Encoding.UTF8.GetString(b), 1, 8)) 'вектор
            AESkey.Key = UnicodeEncoding.Unicode.GetBytes(Mid(System.Text.Encoding.UTF8.GetString(b), 9, 16)) 'Ключ
            Dim inBlock() As Byte = UnicodeEncoding.Unicode.GetBytes(sTEXTBLOC)
            Dim AEStransForm As ICryptoTransform = AESkey.CreateEncryptor()
            Dim outBlock() As Byte = AEStransForm.TransformFinalBlock(inBlock, 0, inBlock.Length)

            Return Convert.ToBase64String(outBlock)

        Catch ex As Exception

            Return "ERR_" + ex.Message
        End Try

    End Function

    Public Function DecryptBytes(sTEXTBLOC As String) As String

        Try
            'Dim DESkey As New DESCryptoServiceProvider()
            'DESkey.IV = UnicodeEncoding.Unicode.GetBytes(Mid(sCRTKey, 1, 8)) 'вектор
            'DESkey.Key = UnicodeEncoding.Unicode.GetBytes(Mid(sCRTKey, 9, 16)) 'Ключ
            'Dim DinBytes() As Byte = Convert.FromBase64String(sTEXTBLOC)
            'Dim DEStransForm As ICryptoTransform = DESkey.CreateDecryptor()
            'Dim DutBlock() As Byte = DEStransForm.TransformFinalBlock(DinBytes, 0, DinBytes.Length)
            'Return UnicodeEncoding.Unicode.GetString(DutBlock)

            Dim AESkey As New AesCryptoServiceProvider()
            AESkey.IV = UnicodeEncoding.Unicode.GetBytes(Mid(System.Text.Encoding.UTF8.GetString(b), 1, 8)) 'вектор
            AESkey.Key = UnicodeEncoding.Unicode.GetBytes(Mid(System.Text.Encoding.UTF8.GetString(b), 9, 16)) 'Ключ
            Dim inBytes() As Byte = Convert.FromBase64String(sTEXTBLOC)
            Dim AEStransForm As ICryptoTransform = AESkey.CreateDecryptor()
            Dim outBlock() As Byte = AEStransForm.TransformFinalBlock(inBytes, 0, inBytes.Length)

            Return UnicodeEncoding.Unicode.GetString(outBlock)

        Catch ex As Exception

            Return "ERR_" + ex.Message
        End Try

    End Function

    'Public Function GENID() As Long

    '    Randomize()
    '    GENID = Int(Rnd() * 1000000000)

    '    'Dim numbers As Integer() = Enumerable.Range(1, 1000000000).ToArray()
    'End Function

    Public Sub PreLoad()

        ' Dim uname As String

        PrPath = Directory.GetParent(Application.ExecutablePath).ToString & "\"

        Dim objIniFile As New IniFile(PrPath & "settings.ini")

        EMAIL_ = objIniFile.GetString("General", "email", "")
        SMTP_ = objIniFile.GetString("General", "SMTP", "10.252.185.6")
        TIME_TOOL_TIPS = objIniFile.GetString("General", "TIME", "20")
        FromEMAIL_ = objIniFile.GetString("General", "FromMail", "apc-srv@info.ru")
        TEMP_ = objIniFile.GetString("General", "TEMP", "35")
        SendMail_ = objIniFile.GetString("General", "SendMail", "0")
        SendMail2_ = objIniFile.GetString("General", "SendMail2", "1")
        TIMEOPROS_ = objIniFile.GetString("General", "TIMEOPROS", "5")
        PuttyFilePatch = objIniFile.GetString("General", "Putty", "")

        UPSMN = objIniFile.GetString("UPS", "UPSMN", "true")
        UPS_NAME = objIniFile.GetString("UPS", "UPS_NAME", "true")
        UPC_Contact = objIniFile.GetString("UPS", "UPC_Contact", "true")
        UPS_MODEL = objIniFile.GetString("UPS", "UPS_MODEL", "true")
        UPS_SN = objIniFile.GetString("UPS", "UPS_SN", "true")
        UPS_BATTERY_TIME = objIniFile.GetString("UPS", "UPS_BATTERY_TIME", "true")
        UPS_BATTARY_ENERGY = objIniFile.GetString("UPS", "UPS_BATTARY_ENERGY", "true")
        UPS_BATTARY_SOST = objIniFile.GetString("UPS", "UPS_BATTARY_SOST", "true")
        UPS_BATTARY_ZAM = objIniFile.GetString("UPS", "UPS_BATTARY_ZAM", "true")
        UPS_TIME_WORK = objIniFile.GetString("UPS", "UPS_TIME_WORK", "true")
        UPS_IP = objIniFile.GetString("UPS", "UPS_IP", "true")
        UPS_MAC = objIniFile.GetString("UPS", "UPS_MAC", "true")
        UPS_IN_ACDC = objIniFile.GetString("UPS", "UPS_IN_ACDC", "true")
        UPS_OUT_ACDC = objIniFile.GetString("UPS", "UPS_OUT_ACDC", "true")
        UPS_MHZ = objIniFile.GetString("UPS", "UPS_MHZ", "true")
        UPS_LOAD = objIniFile.GetString("UPS", "UPS_LOAD", "true")
        UPS_STATUS = objIniFile.GetString("UPS", "UPS_STATUS", "true")
        UPS_TEST = objIniFile.GetString("UPS", "UPS_TEST", "true")
        UPS_TEST_DATE = objIniFile.GetString("UPS", "UPS_TEST_DATE", "true")
        UPS_TEMP = objIniFile.GetString("UPS", "UPS_TEMP", "true")
        UPS_TEMP2 = objIniFile.GetString("UPS", "UPS_TEMP2", "true")

        COMM_MN = objIniFile.GetString("COMM", "COMM_MN", "true")
        COMM_NN = objIniFile.GetString("COMM", "COMM_NN", "true")
        COMM_CONTACT = objIniFile.GetString("COMM", "COMM_CONTACT", "true")
        COMM_MOD = objIniFile.GetString("COMM", "COMM_MOD", "true")
        COMM_SN = objIniFile.GetString("COMM", "COMM_SN", "true")
        COMM_INWORK = objIniFile.GetString("COMM", "COMM_INWORK", "true")
        COMM_IP = objIniFile.GetString("COMM", "COMM_IP", "true")
        COMM_MAC = objIniFile.GetString("COMM", "COMM_MAC", "true")
        COMM_THEMP = objIniFile.GetString("COMM", "COMM_THEMP", "true")
        COMM_FLASH = objIniFile.GetString("COMM", "COMM_FLASH", "true")

        wmiHOUR = objIniFile.GetString("WMI", "Hour", "7")
        wmiMinute = objIniFile.GetString("WMI", "Minute", "45")

        Dim uname As String
        uname = objIniFile.GetString("General", "IBPR", "0")

        Select Case uname

            Case "1"

                sIBPR = True

            Case "0"

                sIBPR = False

        End Select


        Call ALTER_DB()


        Exit Sub
err_:

    End Sub

    Public Sub ALTER_DB()

        Dim tVER As String

        tVER = My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Build & "." & My.Application.Info.Version.Revision

        Dim sTMPtext As String

        Dim rs As Recordset
        rs = New Recordset
        rs.Open("SELECT VERSIA FROM CONFIG", DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            sTMPtext = .Fields("VERSIA").Value

        End With
        rs.Close()
        rs = Nothing
        'Dim sSQL As String

        Select Case sTMPtext

            Case "1.0.0.1"

                Call DB_1001()

            Case "1.3.1.1"

                Call DB_1311()

            Case "1.3.1.3"

                Call DB_1314()

            Case "1.3.1.5"

                Call DB_1316()

            Case Else

        End Select

    End Sub

    Private Sub DB_1001()
        On Error GoTo err_
        Dim sSQL As String
        sSQL = "CREATE TABLE TBL_PING_SL (id counter NOT NULL, IPDEV TEXT(50), PING int, DT Date, TM Date)"
        DB7.Execute(sSQL)

        Call DB_1311()

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub DB_1311()
        On Error GoTo err_
        Dim sSQL As String
        sSQL = "ALTER TABLE TBL_DEV_OID ADD UPS_OTKL_OID TEXT,UPS_VKL_OID TEXT,UPS_TEST_OID TEXT,UPS_KALIBR_OID TEXT"
        DB7.Execute(sSQL)

        Call DB_1314()

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub DB_1314()
        On Error GoTo err_
        Dim sSQL As String
        sSQL = "ALTER TABLE TBL_DEV ADD protokol TEXT"
        DB7.Execute(sSQL)

        Call DB_1316()

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub DB_1316()
        On Error GoTo err_
        Dim sSQL As String
        sSQL = "CREATE TABLE TBL_ARD_SENS (id counter NOT NULL, IPDEV TEXT(50), TEMP FLOAT, Humi FLOAT, DT Date, TM Date)"
        DB7.Execute(sSQL)


        sSQL = "UPDATE CONFIG SET VERSIA='1.3.1.6'"
        DB7.Execute(sSQL)

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Public Sub COMPARE_DB()
      
        On Error GoTo err_
        Select Case DB_N

            Case "MS Access"

                UnLoadDatabase()
                Dim sBname As String
                sBname = "temp_" & Base_Name

                Kill(BasePath & "\" & sBname)

                Dim JRO As JRO.JetEngine
                JRO = New JRO.JetEngine
                JRO.CompactDatabase("Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & BasePath & "\" & Base_Name, "Provider=Microsoft.Jet.OLEDB.4.0;" & "Data Source=" & BasePath & "\" & sBname & ";Jet OLEDB:Engine Type=5")
                Kill(BasePath & "\" & Base_Name)
                Rename(BasePath & "\" & sBname, BasePath & "\" & Base_Name)
                LoadDatabase()

            Case Else

        End Select

        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Information, Application.ProductName)
        LoadDatabase()

    End Sub

    Public Sub LoadDatabase(Optional ByRef sFile As String = "")
        On Error GoTo ERR1
        Dim uname As String

        If Len(unamDB) = 0 Then
            unamDB = "MS Access"
        Else
        End If
        Base_Name = "snmpapcmon.mdb"
        sFile = Base_Name
        BasePath = Directory.GetParent(Application.ExecutablePath).ToString '& "\database\"


        If Len(unamDB) = 0 Or unamDB = Nothing Then Exit Sub
        If unamDB = "MS Access" And Len(sFile) = 0 Then Exit Sub

        Dim MyShadowPassword As String
        Dim TempStr As String

        DATAB = True

        MyShadowPassword = ""

        DB7 = New Connection

        DB_N = unamDB

        Select Case unamDB

            'Case "MS SQL 2008-file"


            '    DB7.Open("Driver={SQL Server Native Client 10.0};Server=./SQLEXPRESS;AttachDBFileName=" & BasePath & "\" & "mSQL.bak;Database=mSQL;Uid=sa;Pwd=lfplhf1vf!;Trusted_connection=Yes;")


            Case "MS SQL 2008"

                DB7.Open(
                    "Driver={SQL Server Native Client 10.0};Server=" & DBserv & ";Database=" & DBtabl & ";Uid=" & DBuser & ";Pwd=" & DBpass & ";")

                Base_Name = DBserv & "\" & DBtabl
            Case "MS SQL"

                '2000
                DB7.Open(
                    "Driver={SQL Server};Server=" & DBserv & ";Database=" & DBtabl & ";Uid=" & DBuser & ";Pwd=" & DBpass &
                    ";")

                Base_Name = DBserv & "\" & DBtabl

            Case "MS Access"

                DB7.Open("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & BasePath & "\" & sFile & ";Jet OLEDB:Database Password=" & MyShadowPassword & ";")

            Case "MS Access 2007"

                DB7.Open("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & BasePath & "\" & sFile & ";Persist Security Info=False" & ";")

            Case "MySQL"

                DB7.Open(
                    "Driver={MySQL ODBC 3.51 Driver};Server=" & DBserv & ";Port=" & DBport & ";Database=" & DBtabl &
                    ";User=" & DBuser & "; Password=" & DBpass & ";OPTION=2059; -С;")

                'Driver={MySQL ODBC 3.51 Driver};Server=myServerAddress;charset=UTF8;Database=myDataBase;User=myUsername; Password=myPassword;Option=3;
                'DB7.Open("Driver={MySQL ODBC 5.1 Driver};Server=" & DBserv & ";Port=" & DBport & ";Database=" & DBtabl & ";User=" & DBuser & "; Password=" & DBpass & ";OPTION=2059;")
                'DB7.Open("DSN=BKO2;Server=" & DBserv & ";Port=" & DBport & ";Database=" & DBtabl & ";Uid=" & DBuser & ";Pwd=" & DBpass & ";")

                Base_Name = DBserv & "\" & DBtabl

            Case "MySQL (MyODBC 5.1)"

                DB7.Open(
                    "Driver={MySQL ODBC 5.1 Driver};Server=" & DBserv & ";Database=" & DBtabl & ";Port=" & DBport &
                    ";User=" & DBuser & "; Password=" & DBpass & ";Option=2059;-С;")

                Base_Name = DBserv & "\" & DBtabl

            Case "PostgreSQL"

                DB7.Open(
                    "DSN=PGS;Server=" & DBserv & ";Port=" & DBport & ";Database=" & DBtabl & ";Uid=" & DBuser & ";Pwd=" &
                    DBpass & ";")

                'DB7.Open("Driver={PostgreSQL};Server=" & DBserv & ";Port=" & DBport & ";Database=" & DBtabl & ";Uid=" & DBuser & ";Pwd=" & DBpass & ";")

                'DB7.Open("DSN=PGS" & ";UID=" & DBuser & ";PWD=" & DBpass & ";" & "Database=" & DBtabl & ";")

                Base_Name = DBserv & "\" & DBtabl

            Case "SQLLite"

                DB7.Open(
                    "DRIVER=SQLite3 ODBC Driver;Database=" & BasePath & "\" & sFile &
                    ";LongNames=0;Timeout=1000;NoTXN=0;SyncPragma=NORMAL;StepAPI=0;")

            Case "DSN"

                DB7.Open("DSN=" & DBserv & ";UID=" & DBuser & ";PWD=" & DBpass & ";")

        End Select


        Exit Sub
ERR1:

        DATAB = False
        MsgBox(Err.Description)

        If unamDB = "MS Access" Then

            BasePath = Directory.GetParent(Application.ExecutablePath).ToString & "\database\"

            Dim objIniFile As New IniFile(PrPath & "base.ini")
            objIniFile.WriteString("general", "BasePath", BasePath)

            'LoadDatabase()

        Else

            MsgBox(Err.Description)

        End If
    End Sub

    Public Sub UnLoadDatabase(Optional ByRef sFile As String = "")

        On Error Resume Next

        frmRequestOID.ThIBP.Abort()
        frmRequestOID.ThPing.Abort()
        frmRequestOID.ThArd.Abort()
        frmRequestOID.ThComm.Abort()
        frmRequestOID.ThPrn.Abort()
        frmRequestOID.ThANTI.Abort()
        frmRequestOID.ThWSUS.Abort()

        On Error GoTo Err_

        If Len(unamDB) = 0 Or unamDB = Nothing Then Exit Sub
        'If unamDB = "MS Access" And Len(sFile) = 0 Then Exit Sub
        If DATAB = False Then Exit Sub

        DB7.Close()
        DB7 = Nothing

        DATAB = False
        Exit Sub
Err_:
    End Sub

    Public Function ExportListViewToExcel(ByVal MyListView As ListView, ByVal sTXT As String)

        'Dim ExcelReport As Excel.ApplicationClass

        ' Const MAX_COLOURS As Int16 = 40

        Const MAX_COLUMS As Int16 = 254

        Dim i As Integer

        Dim New_Item As Windows.Forms.ListViewItem

        Dim TempColum As Int16

        Dim ColumLetter As String

        Dim TempRow As Int16

        Dim TempColum2 As Int16

        Dim AddedColours As Int16 = 1

        Dim MyColours As Hashtable = New Hashtable

        Dim AddNewBackColour As Boolean = True

        Dim AddNewFrontColour As Boolean = True

        'Dim BackColour As String

        'Dim FrontColour As String

        '##########################

        Dim chartRange As Excel.Range

        '##########################

        Dim ExcelReport As Excel.Application

        'ExcelReport = New Excel.ApplicationClass

        ExcelReport = New Excel.Application

        ExcelReport.Visible = True

        ExcelReport.Workbooks.Add()

        ColumLetter = ""

        'ExcelReport.Worksheets("Sheet1").Select()

        'ExcelReport.Sheets("Sheet1").Name = sTXT

        i = 0

        Do Until i = MyListView.Columns.Count

            If i > MAX_COLUMS Then

                MsgBox("Too many Colums added")

                Exit Do

            End If

            TempColum = i

            TempColum2 = 0

            Do While TempColum > 25

                TempColum -= 26

                TempColum2 += 1

            Loop

            ColumLetter = Chr(97 + TempColum)

            If TempColum2 > 0 Then ColumLetter = Chr(96 + TempColum2) & ColumLetter

            ExcelReport.Range(ColumLetter & 3).Value = MyListView.Columns(i).Text

            'ExcelReport.Range(ColumLetter & 3).Font.Name = MyListView.Font.Name

            ' ExcelReport.Range(ColumLetter & 3).Font.Size = MyListView.Font.Size + 2

            ExcelReport.Range(ColumLetter & 3).Font.Bold = True

            chartRange = ExcelReport.Range(ColumLetter & 3)

            chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

            i += 1

        Loop

        '###############################################

        'Вставляем заголовок

        '###############################################

        'Устанавливаем диапазон ячеек

        chartRange = ExcelReport.Range("A1", ColumLetter & 2)

        'Объединяем ячейки

        chartRange.Merge()

        'Вставляем текст

        chartRange.FormulaR1C1 = sTXT

        'Выравниваем по центру

        chartRange.HorizontalAlignment = 3

        chartRange.VerticalAlignment = 2

        'Устанавливаем шрифт

        ExcelReport.Range("A1").Font.Name = MyListView.Font.Name

        'Увеличиваем шрифт

        ExcelReport.Range("A1").Font.Size = MyListView.Font.Size + 4

        'Делаем шрифт жирным

        ExcelReport.Range("A1").Font.Bold = True

        '###############################################
        '###############################################

        TempRow = 4

        For Each New_Item In MyListView.Items

            i = 0

            Do Until i = New_Item.SubItems.Count

                If i > MAX_COLUMS Then

                    MsgBox("Too many Colums added")

                    Exit Do

                End If

                TempColum = i

                TempColum2 = 0

                Do While TempColum > 25

                    TempColum -= 26

                    TempColum2 += 1

                Loop

                ColumLetter = Chr(97 + TempColum)

                If TempColum2 > 0 Then ColumLetter = Chr(96 + TempColum2) & ColumLetter

                ExcelReport.Range(ColumLetter & TempRow).Value = New_Item.SubItems(i).Text

                chartRange = ExcelReport.Range(ColumLetter & TempRow)

                chartRange.BorderAround(Excel.XlLineStyle.xlContinuous, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, Excel.XlColorIndex.xlColorIndexAutomatic)

                i += 1

            Loop

            TempRow += 1

        Next

        ExcelReport.Cells.Select()

        ExcelReport.Cells.EntireColumn.AutoFit()

        ExcelReport.Cells.Range("A1").Select()

    End Function

End Module
