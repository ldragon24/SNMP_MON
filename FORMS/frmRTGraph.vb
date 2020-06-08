Imports ZedGraph
Public Class frmRTGraph
    Dim Speed As Integer = 1
    Dim Th As System.Threading.Thread
    Dim stTR As Double
    Dim sCOUNT As String
    Dim sCOUNT1 As String


    Public IPDEV, COMMDEV, MODEL, DEVELOP As String
    Private zgc = New ZedGraphControl
    Dim alist1 = New PointPairList()

    Public Sub New()
        InitializeComponent()

        AddHandler zg2.ContextMenuBuilder, AddressOf zg2_ContextMenuBuilder

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim myPane As GraphPane = zgc.GraphPane
        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()


        Th = New System.Threading.Thread(AddressOf Thr)
        Th.Start()

        Button1.Enabled = False

    End Sub

    Sub Thr()
        Do
            Select Case sCOUNT1

                Case "OUT_TOK_OID"

                    Dim A2 As String

                    A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                    Select Case A2.Count

                        Case 3

                        Case 4
                            A2 = A2 / 10

                        Case Else

                            A2 = A2 / 10

                    End Select

                    stTR = A2

                Case "IN_TOK_OID"

                    Dim A2 As String

                    A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                    Select Case A2.Count

                        Case 3

                        Case 4
                            A2 = A2 / 10

                        Case Else

                            A2 = A2 / 10

                    End Select

                    stTR = A2

                Case "BATTARY_VOLTAG_OID"
                    Dim A2 As String

                    A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                    Select Case A2.Count

                        Case 3

                        Case 4
                            A2 = A2 / 10

                        Case Else

                            A2 = A2 / 10

                    End Select

                    stTR = A2

                Case "PING"
                    Dim net As New Net.NetworkInformation.Ping
                    Dim sw = New Stopwatch()
                    sw.Start()
                    Dim intPing As Integer = 0
START:

                    Select Case net.Send(IPDEV, 20).Status

                        Case System.Net.NetworkInformation.IPStatus.Success
                            sw.Stop()

                        Case Else

                                    GoTo START

                            If sw.ElapsedMilliseconds > 4000 Then
                                GoTo STOP1
                            End If


                    End Select
Stop1:
                    sw.Stop()
                    stTR = sw.ElapsedMilliseconds

                Case Else
                    stTR = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

            End Select

            Dim now As DateTime
            now = DateTime.Now
            Dim timestamp As Double = CDbl(New XDate(now))
            alist1.Add(timestamp, stTR)


            Call real_zgc(zg2)

            Threading.Thread.Sleep(200)

        Loop

    End Sub

    Private Sub real_zgc(ByVal zgc As ZedGraphControl)

        Dim myPane As GraphPane = zgc.GraphPane
        myPane.CurveList.Clear()
        myPane.GraphObjList.Clear()

        myPane.Title.Text = Me.Text

        myPane.XAxis.Title.Text = "Текущее время"

        Select Case sCOUNT1

            Case "OUT_TOK_OID"
                myPane.YAxis.Title.Text = "VA"

            Case "IN_TOK_OID"
                myPane.YAxis.Title.Text = "VA"

            Case "BATTARY_VOLTAG_OID"
                myPane.YAxis.Title.Text = "VA"

            Case "PING"
                myPane.YAxis.Title.Text = "Время в мс."

            Case Else
                myPane.YAxis.Title.Text = "Данные"

        End Select

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

        Me.Invoke(Sub() myPane.Title.Text = IPDEV)

        Dim myCurve As LineItem = myPane.AddCurve(Me.Text, alist1, Color.Red, SymbolType.None)
        myCurve.Line.Width = 3.0F
        myCurve.Line.Style = Drawing2D.DashStyle.Solid
        myCurve.Line.Fill = New ZedGraph.Fill(Color.White, Color.Red, 45.0F)


        myPane.Chart.Fill = New Fill(Color.LightYellow, Color.LightSlateGray)

        zgc.AxisChange()

        Me.Invoke(Sub() zg2.Invalidate())


    End Sub



    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Th.Abort()
            Button1.Enabled = True
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error GoTo err_

        Speed = 1 '+ 2
        '  Label3.Text = "Скорость " & Speed
        ' PerCounter = New System.Diagnostics.PerformanceCounter
        ' PerCounter.CategoryName = "Processor"
        '  PerCounter.CounterName = "% Processor Time"
        ' PerCounter.InstanceName = "_Total"

        Select Case sCOUNT1

            Case "OUT_TOK_OID"

                Dim A2 As String

                A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                Select Case A2.Count

                    Case 3

                    Case 4
                        A2 = A2 / 10

                    Case Else

                        A2 = A2 / 10

                End Select

                stTR = A2

            Case "IN_TOK_OID"

                Dim A2 As String

                A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                Select Case A2.Count

                    Case 3

                    Case 4
                        A2 = A2 / 10

                    Case Else

                        A2 = A2 / 10

                End Select

                stTR = A2

            Case "BATTARY_VOLTAG_OID"
                Dim A2 As String

                A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                Select Case A2.Count

                    Case 3

                    Case 4
                        A2 = A2 / 10

                    Case Else

                        A2 = A2 / 10

                End Select

                stTR = A2

            Case "PING"


            Case Else
                stTR = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

        End Select


        If stTR = 0 Then stTR = 5



        Exit Sub
err_:
        MsgBox(Err.Description, MsgBoxStyle.Critical, ProductName)

    End Sub

    Public Sub ZaprosOID(ByVal sTXT As String)

        Dim sSQL As String

        sCOUNT1 = sTXT

        Dim rs As Recordset
        rs = New Recordset

        Select Case sTXT

            Case "OUT_TOK_OID"

                Dim A2 As String

                A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                Select Case A2.Count

                    Case 3

                    Case 4
                        A2 = A2 / 10

                    Case Else

                        A2 = A2 / 10

                End Select

                stTR = A2

            Case "IN_TOK_OID"

                Dim A2 As String

                A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                Select Case A2.Count

                    Case 3

                    Case 4
                        A2 = A2 / 10

                    Case Else

                        A2 = A2 / 10

                End Select

                stTR = A2

            Case "BATTARY_VOLTAG_OID"
                Dim A2 As String

                A2 = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

                Select Case A2.Count

                    Case 3

                    Case 4
                        A2 = A2 / 10

                    Case Else

                        A2 = A2 / 10

                End Select

                stTR = A2

            Case "PING"

                sCOUNT = "PING"
                Exit Sub
            Case Else
                stTR = REQUEST2(IPDEV, COMMDEV, sCOUNT, DEVELOP)

        End Select

        sSQL = "SELECT * FROM TBL_DEV_OID where MODEL='" & MODEL & "'"

        rs.Open(sSQL, DB7, CursorTypeEnum.adOpenDynamic, LockTypeEnum.adLockOptimistic)

        With rs
            sCOUNT = .Fields(sTXT).Value
        End With
        rs.Close()
        rs = Nothing


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Th.Abort()
        Button1.Enabled = True
    End Sub

    Private Sub zg2_ContextMenuBuilder(sender As ZedGraphControl, menuStrip As ContextMenuStrip, mousePt As Drawing.Point, objState As ZedGraphControl.ContextMenuObjectState)
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

End Class