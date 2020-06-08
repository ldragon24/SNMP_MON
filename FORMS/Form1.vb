Imports SnmpSharpNet
Imports System.Threading
Imports System.Net
Imports System.Text

Public Class Form1
    Private sTRT As Boolean = False

    Const portNumber As Integer = 161

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

        Me.Cursor = Cursors.Default

        Dim newThread5 As New Thread(AddressOf OPROS)

        If sTRT = False Then

            newThread5.Start()
            newThread5.IsBackground = True
            sTRT = True
            Button1.Text = "Стоп"
            Me.Cursor = Cursors.WaitCursor
        Else
            sTRT = False
            newThread5.Abort()
            Button1.Text = "Старт"
            Me.Cursor = Cursors.Default
        End If

        ' Me.BeginInvoke(New MethodInvoker(AddressOf OPROS))
        ' Call OPROS()

    End Sub

    Private Sub OPROS()
        ' On Error GoTo err_

        Me.Invoke(Sub() Me.Cursor = Cursors.WaitCursor)

        Dim tHOST As String = TextBox1.Text
        Dim tcommunity As String = TextBox2.Text
        Dim trootOid As Oid = New Oid(TextBox4.Text)

        Me.Invoke(Sub() TextBox3.Text = "")

        'Dim uname As String

        intcount4 = 0

        Dim host As String = tHOST
        Dim community As String = tcommunity
        Dim requestOid() As String
        Dim result As Dictionary(Of Oid, AsnType)
        Dim rootOid As Oid = New Oid(trootOid)
        Dim nextOid As Oid = rootOid
        Dim keepGoing As Boolean = True
        requestOid = New String() {rootOid.ToString()}
        Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)

        If Not snmp.Valid Then
            Console.WriteLine("Invalid hostname/community.")
            Exit Sub
        End If

        While keepGoing
            result = snmp.GetNext(SnmpVersion.Ver1, New String() {nextOid.ToString()})
            If result IsNot Nothing Then
                Dim kvp As KeyValuePair(Of Oid, AsnType)

                For Each kvp In result

                    If rootOid.IsRootOf(kvp.Key) Then
                        'Console.WriteLine("{0}: ({1}) {2}", kvp.Key.ToString(), _
                        '                      SnmpConstants.GetTypeName(kvp.Value.Type), _
                        '                      kvp.Value.ToString())


                        If Len(kvp.Value.ToString) = 0 Then

                        Else

                            If Len(TextBox5.Text) = 0 Then

                                Me.Invoke(Sub() TextBox3.Text = TextBox3.Text & vbNewLine & kvp.Key.ToString() & " " & SnmpConstants.GetTypeName(kvp.Value.Type) & " " & kvp.Value.ToString())
                                Me.Invoke(Sub() My.Application.DoEvents())

                            Else

                                If kvp.Value.ToString = TextBox5.Text Then

                                    Me.Invoke(Sub() TextBox3.Text = TextBox3.Text & vbNewLine & kvp.Key.ToString() & " " & SnmpConstants.GetTypeName(kvp.Value.Type) & " " & kvp.Value.ToString())
                                    My.Application.DoEvents()
                                Else

                                    ' TextBox3.Text = TextBox3.Text & "***" & vbNewLine
                                    Me.Invoke(Sub() My.Application.DoEvents())
                                End If

                            End If

                        End If

                        nextOid = kvp.Key
                    Else
                        keepGoing = False
                    End If

                    If sTRT = False Then Exit Sub
                Next
            Else

                Me.Invoke(Sub() TextBox3.Text = TextBox3.Text & vbNewLine & ("No results received."))
                keepGoing = False
            End If

            intcount4 = intcount4 + 1

            If sTRT = False Then

                Exit Sub
                Me.Cursor = Cursors.Default
            End If

        End While

        Me.Invoke(Sub() Button1.Text = "Старт")
        sTRT = False
        'Me.Cursor = Cursors.Default
        Exit Sub
err_:
        Me.Invoke(Sub() Button1.Text = "Старт")
        sTRT = False
        Me.Cursor = Cursors.Default
        MsgBox(Err.Description)
    End Sub

    Private Sub Form1_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        '   ListBox1.Items.Clear()
        TextBox3.Clear()

        'Dim MyIP As System.Net.IPAddress = System.Net.Dns.GetHostAddresses(My.Computer.Name.ToString).GetValue(2)

        'Dim sTmp() As String
        'sTmp = Split(MyIP.ToString, ".")

        'Dim requestOid() As String
        'Dim result As Dictionary(Of Oid, AsnType)
        'requestOid = New String() {"1.3.6.1.2.1.1.6.0", "1.3.6.1.2.1.1.6.0"}

        'For i = 1 To 254

        '    If My.Computer.Network.Ping(sTmp(0) & "." & sTmp(1) & "." & sTmp(2) & "." & i) Then

        '        Dim snmp As SimpleSnmp = New SimpleSnmp(sTmp(0) & "." & sTmp(1) & "." & sTmp(2) & "." & i, "public")

        '        If Not snmp.Valid Then

        '        Else

        '            result = snmp.Get(SnmpVersion.Ver1, requestOid)

        '            If result IsNot Nothing Then
        '                ListBox1.Items.Add(sTmp(0) & "." & sTmp(1) & "." & sTmp(2) & "." & i)

        '            End If

        '        End If

        '    End If

        'Next



        'Try
        '    Dim udpClient As New Sockets.UdpClient
        '    udpClient.Connect(sTmp(0) & "." & sTmp(1) & "." & sTmp(2) & "." & i, 161)

        '    If udpClient.Client.RemoteEndPoint.ToString = sTmp(0) & "." & sTmp(1) & "." & sTmp(2) & "." & i & ":" & 161 Then

        '        ListBox1.Items.Add(sTmp(0) & "." & sTmp(1) & "." & sTmp(2) & "." & i)

        '    End If

        '    udpClient.Close()

        'Catch ex As Exception

        'End Try


        ''Dim tcpClient As New System.Net.Sockets.TcpClient()
        ''tcpClient.Connect("10.252.245.210", 161)
        ''Dim networkStream As Sockets.NetworkStream = tcpClient.GetStream()

        ''If networkStream.CanRead Then

        ''    ListBox1.Items.Add("10.252.245.210")

        ''Else

        ''    If Not networkStream.CanRead Then
        ''        Console.WriteLine("cannot not write data to this stream")
        ''        tcpClient.Close()
        ''    Else
        ''        If Not networkStream.CanWrite Then
        ''            Console.WriteLine("cannot read data from this stream")
        ''            tcpClient.Close()
        ''        End If
        ''    End If
        ''End If


    End Sub



End Class