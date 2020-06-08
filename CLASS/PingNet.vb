''' <summary>
'''  Реализует простой пинг хоста
''' </summary>
''' <remarks></remarks>
Public Class PingNet

    Public Delegate Sub CallBack(ByVal P As PingNet) ' делегат для функции обратного вызова
    Public Event PingStateChange As EventHandler ' событие, возникающее при изменения состояния пинга
    ''' <summary>
    ''' Качество пинга
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum PingState
        ''' <summary>
        ''' Пинг хороший
        ''' </summary>
        ''' <remarks></remarks>
        GOOD
        ''' <summary>
        ''' Средний пинг
        ''' </summary>
        ''' <remarks></remarks>
        MIDDLE
        ''' <summary>
        ''' Плохой пинг
        ''' </summary>
        ''' <remarks></remarks>
        POOR
        ''' <summary>
        ''' Пинга нет 
        ''' </summary>
        ''' <remarks></remarks>
        NOTPING
    End Enum

    Private pState As PingState ' текущее состояние пинга
    Private adrs As String ' адрес пингуемого хоста
    Private err As String ' текст ошибки при пинге
    Private ping As Long ' величина пинга
    Private cl As CallBack ' экземпляр делегата функции обратного вызова


    ''' <summary>
    ''' Констуктор класса
    ''' </summary>
    ''' <param name="addressHost">Адрес хоста или IP</param>
    ''' <param name="fn">Делегат функции обратного вызова</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal addressHost As String, ByVal fn As CallBack)
        Me.adrs = addressHost
        Me.cl = fn
    End Sub

    ''' <summary>
    ''' Определение состояния пинга
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub getStatePing()
        If (Me.ping < 0) Then
            Me.pState = PingState.NOTPING
        ElseIf (Me.ping >= 0 And Me.ping <= 3) Then
            Me.pState = PingState.GOOD
        ElseIf (Me.ping >= 0 And Me.ping <= 11) Then
            Me.pState = PingState.MIDDLE
        Else
            Me.pState = PingState.POOR
        End If

        RaiseEvent PingStateChange(Me, New EventArgs) ' генерация события (издание)

    End Sub


    ''' <summary>
    ''' Возвращает текущее состояние пинга
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property PING_STATE() As PingState
        Get
            Return Me.pState
        End Get
    End Property

    ''' <summary>
    '''  Возвращает величину пинга
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property CUR_PING()
        Get
            Return Me.ping
        End Get
    End Property

    ''' <summary>
    '''  Получение пинга
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub checkPing()
        '   Me.err = "" ' очистка текста ошибки
        Try
            Dim p As New System.Net.NetworkInformation.Ping() ' получаем пинг

            Me.ping = p.Send(Me.adrs).Status

        Catch ex As Exception ' в случае ошибки возращаем -1 и записываем текст ошибки
            err = ex.Message
            ping = -1
        End Try
        getStatePing() ' запуск определения качества пинга
    End Sub

    ''' <summary>
    '''  Текущий адрес пингуемого хоста
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Address() As String
        Get
            Return Me.adrs
        End Get
        Set(ByVal value As String)
            Me.adrs = value
        End Set
    End Property

    ''' <summary>
    '''  Ошибка при выполнении пинга
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Error_ping() As String
        Get
            Return Me.err
        End Get
    End Property


    ''' <summary>
    '''  Инициализатор метода обратного вызова
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Start()
        If (cl IsNot Nothing) Then
            cl(Me)
        End If
    End Sub

End Class
