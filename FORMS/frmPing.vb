Public Class frmPing

    Public Delegate Sub PingOut(ByVal P As PingNet) ' делегат для вывода строки 
    Private pout As PingOut ' экземпляр делегата


    ' Обработчик события изменения состояния пинга
    Private Sub Hoock_change_Ping(ByVal sender As Object, ByVal e As EventArgs)
        ListView1.Invoke(pout, New Object() {CType(sender, PingNet)}) ' доступ к элементу из другого потока
    End Sub

    ''' <summary>
    ''' Метод вывода очередной записи пинга
    ''' </summary>
    ''' <param name="P">Экземпляр класса PingNet</param>
    ''' <remarks></remarks>
    Private Sub printItem(ByVal P As PingNet)
        ' ListView1.Items.Clear()

        Dim i As Long = P.CUR_PING ' получаем значение пинга в переменную

        ' здесь все понятно просто постолбцовый вывод
        ListView1.Items.Add((ListView1.Items.Count + 1).ToString()).SubItems.Add(P.Address)
        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(i.ToString())
        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(DateTime.Now.ToString())
        ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(P.Error_ping)

        ' обработка результата для цветововй визуализации
        Select Case P.PING_STATE
            Case PingNet.PingState.POOR, PingNet.PingState.NOTPING
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).BackColor = Color.Red
            Case PingNet.PingState.MIDDLE
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).BackColor = Color.Yellow
            Case PingNet.PingState.GOOD
                Me.ListView1.Items(Me.ListView1.Items.Count - 1).BackColor = Color.Green

        End Select

        ' делаем чтобы показывалось всегда нижнее
        Me.ListView1.Items(Me.ListView1.Items.Count - 1).Selected = True
        Me.ListView1.Items(Me.ListView1.Items.Count - 1).EnsureVisible()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        On Error GoTo err_

        trh.Abort()
        pout = Nothing
        RemoveHandler pn.PingStateChange, AddressOf Hoock_change_Ping

        Me.Hide()

        GC.Collect()

        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub

    Private Sub frmPing_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        On Error GoTo err_
        pn = New PingNet(sHOST, AddressOf pingInList)

        AddHandler pn.PingStateChange, AddressOf Hoock_change_Ping ' подписываемся на событие изменения состояния пинга
        pout = New PingOut(AddressOf printItem) ' инициализируем экземпляр делегата вывода текущего состояния пинга

        Call PING_TEST_START()
        Exit Sub
err_:
        MsgBox(Err.Description)
    End Sub


    Private Shared Sub pingInList(ByVal P As PingNet)
        ' бесконечный цикл
        While True
            P.checkPing() ' запуск метода получения пинга
            Threading.Thread.Sleep(intr * 1000) ' задержка потока на заданный интервал
        End While
    End Sub

    Public Shared trh As Threading.Thread ' поток в котором будет выполняться пинг
    Public Shared pn As PingNet ' экземпляр нашего вспомогательного класса
    Public Shared intr As Integer = 5 ' дефолтовый интревал пинга
    ''' <summary>
    ''' Статический конструктор класса (вызывается один раз при первом обращении)
    ''' Инициализирует переменные
    ''' </summary>
    ''' <remarks></remarks>
    Shared Sub New()
        'pn = New PingNet(sHOST, AddressOf pingInList) ' по умолчанию пингуем яндекс
        'trh = New Threading.Thread(New Threading.ThreadStart(AddressOf pn.Start)) ' создаем новый поток
        'trh.Start() ' запускаем его


    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Select Case Button1.Text

            Case "Стоп"

                trh.Abort()
                Button1.Text = "Старт"

            Case "Старт"

                Call PING_TEST_START()

        End Select


    End Sub


    Public Sub PING_TEST_START()


        On Error GoTo err_
        Me.ListView1.Items.Clear()

        sHOST = TextBox1.Text

        intr = 1
        pn.Address = sHOST

        '   Me.BeginInvoke(New MethodInvoker(AddressOf pn.Start))
        trh = New Threading.Thread(New Threading.ThreadStart(AddressOf pn.Start)) ' создаем новый поток
        trh.Start() ' запускаем его

        Button1.Text = "Стоп"


        Exit Sub
err_:
        MsgBox(Err.Description)

    End Sub


End Class