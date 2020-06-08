Public Class port_scan
    Dim host As String
    Dim port As Integer
    Dim counter As Integer
    Dim errcount As Integer = 0
    'Инициализируем переменные: хост, порт и счётчик + счетчик ошибок

    Private Sub port_scan_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        errcount = 0

        CheckForIllegalCrossThreadCalls = False
        Button2.Enabled = False
        TextBox2.Text = "0"

        Label8.Text = "Ошибок: " & errcount
        'устанавливаем счётчик в 0
        counter = 0
        Label3.Text = "Открыто портов: " & counter


        Me.Width = 247
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If BackgroundWorker1.IsBusy Then ' проверяем, не занят ли поток
            Exit Sub
        Else
            BackgroundWorker1.RunWorkerAsync() ' запускаем поток
        End If

    End Sub
    Dim temp As Integer 'временная переменная
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Кнопка старт
        'если конечный порт больше начального, то меняем их местами 
        If NumericUpDown1.Value > NumericUpDown2.Value Then
            temp = NumericUpDown1.Value
            NumericUpDown1.Value = NumericUpDown2.Value
            NumericUpDown2.Value = temp
        End If
        If TextBox1.Text = "" Then
            Exit Sub
        End If
        ListBox1.Items.Add("Сканирование: " + TextBox1.Text)
        ListBox1.Items.Add("-------------------")
        Button2.Enabled = True
        Button1.Enabled = False
        TextBox1.Enabled = False
        If BackgroundWorker1.IsBusy Then
            Exit Sub
        Else
            BackgroundWorker1.RunWorkerAsync()
        End If
        Button3.Enabled = True
        Button3.Text = "||" 'меняем изображение на кнопке
        TrackBar1.Enabled = False
        NumericUpDown1.Enabled = False
        NumericUpDown2.Enabled = False
    End Sub
    Dim st As Integer = 1
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'кнопка стоп
        paused = False
        BackgroundWorker1.CancelAsync() 'передаем в поток сигнал о завершении

        Button1.Enabled = True
        Button2.Enabled = False
        TextBox1.Enabled = True
        TextBox2.Text = "0"
        counter = 0
        st = 1
        Button3.Enabled = False
        Button3.Text = ">>"

        TrackBar1.Enabled = True
        NumericUpDown1.Enabled = True
        NumericUpDown2.Enabled = True
        tcpClient.Close() 'закрываем tcp  соединение
    End Sub
    Dim intr As Double = 0.03 'Время ожидания отклика по умолчанию
    Dim tcpClient = New Net.Sockets.TcpClient ' создаем новый экземпляр tcp соединения
    Dim paused As Boolean = False ' переменная отвечает за определение, была поставлена пауза или нет
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork

        Do Until BackgroundWorker1.CancellationPending
            '
            If paused = True Then ' если была поставлена пауза, то продолжаем с того места, где закончили
                counter = start
                paused = False
            Else
                counter = NumericUpDown1.Value - 1
            End If

            '
            st = NumericUpDown1.Value
            For i = st To NumericUpDown2.Value + 1
                If BackgroundWorker1.CancellationPending = True Then Exit Do 'если в поток был передан сигнал об окончании, то выходим
                counter = counter + 1 'счётчик для таймера
                st = st + 1

                TextBox2.Text = counter
                host = TextBox1.Text
                port = TextBox2.Text

                'дошли до конца, закрываем все и выходим
                If TextBox2.Text >= NumericUpDown2.Value + 1 Then
                    Timer1.Stop()
                    Timer1.Enabled = False
                    Button1.Enabled = True
                    Button2.Enabled = False
                    Button3.Enabled = False
                    TextBox2.Text = "0"
                    counter = 0
                    ListBox1.Items.Add("-------------------")
                    ListBox1.Items.Add("Сканирование портов завершено")
                    ListBox1.SelectedIndex = ListBox1.Items.Count - 1
                    TextBox1.Enabled = True
                    TrackBar1.Enabled = True
                    NumericUpDown1.Enabled = True
                    NumericUpDown2.Enabled = True
                    tcpClient.Close() ' закрываем tcp соединение
                    Exit Sub
                End If

                ' Далее создаём сокет и пытаемся подключиться.
                Try
                    Dim tcpClient = New Net.Sockets.TcpClient
                    Dim ar = tcpClient.BeginConnect(host, port, Nothing, Nothing)

                    If Not ar.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(intr), False) Then
                        tcpClient.Close()
                        'offline
                        ListBox1.Items.Add("Порт " + port.ToString + " закрыт")
                    Else
                        tcpClient.EndConnect(ar)
                        tcpClient.Close()
                        'online
                        ListBox1.Items.Add("Порт " + port.ToString + " открыт")
                        ListBox2.Items.Add(port.ToString)
                    End If

                    ar.AsyncWaitHandle.Close()
                Catch ex As Exception
                    'Исключение. Считается как Offline
                    tcpClient.Close()
                    ListBox1.Items.Add("Порт " + port.ToString + " ошибка подключения")
                    errcount = errcount + 1 ' счетчик количества ошибок подключения
                    Label8.Text = "Ошибок: " & errcount
                End Try

                Label3.Text = "Открыто портов: " + ListBox2.Items.Count.ToString
                ListBox1.SelectedIndex = ListBox1.Items.Count - 1
                If BackgroundWorker1.CancellationPending = True Then Exit Do ' повторная проверка на сигнал о завершении потока
            Next

        Loop

    End Sub
    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        If Not e.Cancelled Then
            'когда поток успешно закончил работу
            st = 0
        Else
            ' когда работа потока была завершена вручную
            Button3.Enabled = True
        End If
    End Sub
    Dim start As Integer = 0 ' хранит последний сканированный порт
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If BackgroundWorker1.IsBusy Then
            BackgroundWorker1.CancelAsync()
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button3.Text = ">>"
            TrackBar1.Enabled = True
            NumericUpDown1.Enabled = True
            NumericUpDown2.Enabled = True
            paused = True
            start = TextBox2.Text
        Else
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
            End If
            Button3.Text = "||"
            TrackBar1.Enabled = False
            NumericUpDown1.Enabled = False
            NumericUpDown2.Enabled = False
            start = TextBox2.Text
        End If


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim msg = MsgBox("Вы уверены, что хотите очистить список найденных открытых портов?", MsgBoxStyle.YesNo)
        If msg = MsgBoxResult.Yes Then
            ListBox1.Items.Clear()
            ListBox2.Items.Clear()
            Label3.Text = "Открыто портов: 0"
        Else
            Exit Sub
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'сохраняем все найденное
        If ListBox1.Items.Count = 0 Then
            MsgBox("Нечего сохранять", MsgBoxStyle.Information, "Port Scaner")
            Exit Sub
        End If
        Try
            IO.File.WriteAllText(Application.StartupPath + "\" + TextBox1.Text + ".txt", "Host: " & TextBox1.Text & vbNewLine & vbNewLine & "Открыты порты: " & vbNewLine, System.Text.Encoding.Default)
            For i = 0 To ListBox2.Items.Count - 1
                IO.File.AppendAllText(Application.StartupPath + "\" + TextBox1.Text + ".txt", ListBox2.Items.Item(i) & vbNewLine, System.Text.Encoding.Default)
            Next
            MsgBox("Все данные успешно записаны в файл", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Ошибка записи в файл. Повторите попытку", MsgBoxStyle.Critical)
            Button7.Visible = True
            Button5.Visible = False
            'если ошибка, то сообщаем об этом и выводим кнопку - сохранить как, где можно выбрать папку для сохранения
        End Try
    End Sub
    Dim c As Integer = 0 ' переменная для определения состояния нажатия кнопки Настройка
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'настройка
        If c = 0 Then
            Me.Width = 395 ' раздвигаем форму и делаем видимыми нужные элементы

            TrackBar1.Visible = True
            Button6.Text = "Скрыть"
            Label4.Visible = True
            Label5.Visible = True
            Label6.Visible = True
            Label7.Visible = True
            NumericUpDown1.Visible = True
            NumericUpDown2.Visible = True
            c = c + 1
        Else
            Me.Width = 247 ' скрываем все элементы настройки

            TrackBar1.Visible = False
            Button6.Text = "Настройки"
            Label4.Visible = False
            Label5.Visible = False
            Label6.Visible = False
            Label7.Visible = False
            NumericUpDown1.Visible = False
            NumericUpDown2.Visible = False
            c = 0
        End If
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        'устанавливаем интервалы ожидания отклика от порта при сканировании
        If TrackBar1.Value = 0 Then ' медленно
            intr = 0.5
        End If
        If TrackBar1.Value = 1 Then ' средне
            intr = 0.25
        End If
        If TrackBar1.Value = 2 Then ' быстро
            intr = 0.04
        End If
    End Sub


    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ' сохранить как
        Dim path As String = ""
        Dim SFD As New FolderBrowserDialog
        If SFD.ShowDialog = Windows.Forms.DialogResult.OK Then
            path = SFD.SelectedPath
        End If
        Try
            IO.File.WriteAllText(path & "\" + TextBox1.Text + ".txt", "Host: " & TextBox1.Text & vbNewLine & vbNewLine & "Открыты порты: " & vbNewLine, System.Text.Encoding.Default)
            For i = 0 To ListBox2.Items.Count - 1
                IO.File.AppendAllText(path & "\" + TextBox1.Text + ".txt", ListBox2.Items.Item(i) & vbNewLine, System.Text.Encoding.Default)
            Next
            MsgBox("Все данные успешно записаны в файл", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox("Ошибка записи в файл. Повторите попытку", MsgBoxStyle.Critical)
        End Try
    End Sub
End Class