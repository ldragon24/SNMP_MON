Public Class frmArd
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hwnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
    Public IPDEV, COMMDEV, MODEL, DEVELOP As String
    Dim TEMPERATURE_OID As String
    Dim TEMPERATURE2_OID As String
    Dim Th As System.Threading.Thread

    <Flags()> _
    Enum AnimateWindowFlags
        AW_HOR_POSITIVE = &H1
        AW_HOR_NEGATIVE = &H2
        AW_VER_POSITIVE = &H4
        AW_VER_NEGATIVE = &H8
        AW_CENTER = &H10
        AW_HIDE = &H10000
        AW_ACTIVATE = &H20000
        AW_SLIDE = &H40000
        AW_BLEND = &H80000
    End Enum

    <System.Runtime.InteropServices.DllImport("user32.dll")> _
    Shared Function AnimateWindow(hWnd As IntPtr, time As Integer, flags As AnimateWindowFlags) As Boolean
    End Function

    Private Sub frmArd_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        AnimateWindow(Me.Handle, 1000, AnimateWindowFlags.AW_BLEND Or AnimateWindowFlags.AW_HIDE)

        Try
            Th.Abort()

        Catch ex As Exception

        End Try

    End Sub

    Sub Thr()

        Do
            If sOPROS = True Then Threading.Thread.Sleep(30000)

            Dim uname2 As String
            Dim uname As Integer

            uname2 = (REQUEST2(IPDEV, COMMDEV, "1.3.6.1.2.1.1.5.0", DEVELOP))

            Me.Invoke(Sub() Me.Text = uname2)

            Select Case result_

                Case False
                    Exit Sub
            End Select

            'TEMPERATURE_OID

            uname = REQUEST2(IPDEV, COMMDEV, TEMPERATURE_OID, DEVELOP)

            ' IBP_BATTARY.Value = uname

            Me.Invoke(Sub() Me.v_n_t.Value = 100)
            Me.Invoke(Sub() ARD_THEMP.Value = uname)

            Select Case uname

                Case Is <= 23
                    Me.Invoke(Sub() SendMessage(Me.ARD_THEMP.Handle, &H400 + 16, &H1, 0))
                    Me.Invoke(Sub() SendMessage(Me.v_n_t.Handle, &H400 + 16, &H1, 0))
                Case Is < 30 And uname > 23
                    Me.Invoke(Sub() SendMessage(Me.ARD_THEMP.Handle, &H400 + 16, &H3, 0))
                    Me.Invoke(Sub() SendMessage(Me.v_n_t.Handle, &H400 + 16, &H3, 0))
                Case Is >= 30
                    Me.Invoke(Sub() SendMessage(Me.ARD_THEMP.Handle, &H400 + 16, &H2, 0))
                    Me.Invoke(Sub() SendMessage(Me.v_n_t.Handle, &H400 + 16, &H2, 0))
            End Select


            uname = REQUEST2(IPDEV, COMMDEV, TEMPERATURE2_OID, DEVELOP)

            ' IBP_BATTARY.Value = uname

            Me.Invoke(Sub() lblH.Text = uname & "%")

            Select Case uname

                Case Is <= 10

                    Me.Invoke(Sub() lblH.ForeColor = Color.White)

                Case Is < 55 And uname > 10

                    Me.Invoke(Sub() lblH.ForeColor = Color.Blue)

                Case Is >= 55

                    Me.Invoke(Sub() lblH.ForeColor = Color.Red)
                    '  Me.Invoke(Sub() lblH.BackColor = Color.LightBlue)

            End Select

A:
            
            Application.DoEvents()
                Threading.Thread.Sleep(1000)


        Loop

    End Sub

    Private Sub REALOID()

        If sOPROS = True Then Exit Sub

        Dim sSQL As String

        sSQL = "SELECT * FROM TBL_DEV_OID where MODEL='" & MODEL & "'"

        Dim rs As Recordset
        rs = New Recordset
        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs

            TEMPERATURE_OID = .Fields("TEMPERATURE_OID").Value
            TEMPERATURE2_OID = .Fields("TEMPERATURE2_OID").Value

        End With
        rs.Close()
        rs = Nothing

    End Sub

    Private Sub frmArd_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            Th.Abort()

        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmArd_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        AnimateWindow(Me.Handle, 1000, AnimateWindowFlags.AW_BLEND Or AnimateWindowFlags.AW_VER_POSITIVE)

        lblH.Parent = PictureBox1
        lblH.BackColor = Color.Transparent

        Call REALOID()
        'Me.BeginInvoke(New MethodInvoker(AddressOf Me.REQUEST_OID_IBP_DB_no_Refresh))

        Th = New System.Threading.Thread(AddressOf Thr)
        Th.Start()

    End Sub

    Private Sub frmArd_Resize(sender As Object, e As System.EventArgs) Handles Me.Resize

        On Error GoTo error_Renamed

        If Me.WindowState <> FormWindowState.Normal Then Me.WindowState = FormWindowState.Normal


        If (Me.Height) > 574 Then Me.Height = 574
        If (Me.Width) > 165 Then Me.Width = 165

        If (Me.Height) < 574 Then Me.Height = 574
        If (Me.Width) < 165 Then Me.Width = 165

        Exit Sub
error_Renamed:
        Me.Height = 574
        Me.Width = 165

    End Sub
End Class