Imports System.Collections
'Imports SNMPDll
Imports SnmpSharpNet
Imports System.Management
Imports System.Threading
Imports System.ComponentModel

Public Class frmCiscoPort
    Public COMMDEV As String
    Public IPDEV As String
    Public txtOID As String
    Public txtOIDv As String
    Public txtOIDm As String
    Public txtPOrt As String


    Public Function REQUEST_CISCO_PORT() As String



        If Me.lstComm.InvokeRequired Then

            Me.Invoke(Sub() Me.lstComm.BeginInvoke(New MethodInvoker(AddressOf REQUEST_CISCO_PORT)))

        Else

            Dim host As String = IPDEV
            Dim community As String = COMMDEV
            Dim requestOid() As String
            Dim result As Dictionary(Of Oid, AsnType)
            Dim Skvp1 As String
            ' Dim Skvp2 As String
            ' Dim tmpOID As String
            Dim uname As String

            Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)

            '###########################################
            'requestOid = New String() {txtOIDm, txtOIDm}

            'If Not snmp.Valid Then
            '    Return "ERR_" + snmp.Valid
            '    Exit Function
            'End If

            'result = snmp.Get(SnmpVersion.Ver1, requestOid)

            'If result IsNot Nothing Then
            '    result_ = True
            'Else
            '    result_ = False
            'End If
            'If result IsNot Nothing Then
            '    Dim kvp1 As KeyValuePair(Of Oid, AsnType)
            '    For Each kvp1 In result
            '        Skvp2 = kvp1.Value.ToString
            '    Next
            'End If

            '###########################################

            requestOid = New String() {txtOIDv, txtOIDv}

            If Not snmp.Valid Then
                Return "ERR_" + snmp.Valid
                Exit Function
            End If

            result = snmp.Get(SnmpVersion.Ver1, requestOid)

            If result IsNot Nothing Then
                result_ = True
            Else
                result_ = False
            End If
            If result IsNot Nothing Then
                Dim kvp2 As KeyValuePair(Of Oid, AsnType)

                For Each kvp2 In result
                    Select Case kvp2.Value.ToString
                        Case 1
                            Skvp1 = "Up"
                        Case Else
                            Skvp1 = "Down"
                    End Select
                Next
            End If

            '###########################################

            requestOid = New String() {txtOID, txtOID}

            If Not snmp.Valid Then

                Return "ERR_" + snmp.Valid

                Exit Function

            End If

            uname = ""

            result = snmp.Get(SnmpVersion.Ver1, requestOid)

            If result IsNot Nothing Then
                result_ = True
            Else
                result_ = False
            End If

            If result IsNot Nothing Then

                Dim kvp As KeyValuePair(Of Oid, AsnType)

                For Each kvp In result


                    Me.Invoke(Sub() lstComm.Items.Add(intcountCOMM))

                    Select Case txtOID

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10001"
                            '1.3.6.1.2.1.2.2.1.8.10001
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/1"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            ' Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                            ' Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).BackColor = Color.Green

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10002"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/2"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            ' Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10003"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/3"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            ' Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10004"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/4"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            '  Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10005"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/5"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            '   Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10006"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/6"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            '  Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10007"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/7"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            '   Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10008"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/8"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            '  Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10009"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/9"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                            '  Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp2)
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10010"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/10"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10011"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/11"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10012"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/12"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10013"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/13"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10014"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/14"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10015"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/15"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10016"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/16"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10017"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/17"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10018"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/18"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10019"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/19"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10020"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/20"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10021"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/21"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10022"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/22"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10023"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/23"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10024"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/24"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10025"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/25"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10026"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/26"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10027"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/27"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10028"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/28"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10029"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/29"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10030"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/30"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10031"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/31"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10032"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/32"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10033"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/33"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10034"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/34"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10035"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/35"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10036"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/36"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10037"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/37"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10038"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/38"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10039"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/39"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10040"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/40"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10041"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/41"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10042"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/42"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10043"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/43"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10044"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/44"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10045"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/45"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10046"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/46"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10047"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/47"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10048"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/48"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                            '#################################################
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11001"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/1"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11002"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/2"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11003"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/3"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11004"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/4"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11005"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/5"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11006"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/6"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11007"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/7"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11008"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/8"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11009"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/9"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11010"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/10"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11011"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/11"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11012"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/12"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11013"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/13"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11014"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/14"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11015"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/15"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11016"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/16"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11017"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/17"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11018"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/18"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11019"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/19"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11020"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/20"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11021"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/21"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11022"
                            '1.3.6.1.4.1.9.2.2.1.1.28.11022

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/22"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11023"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/23"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11024"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/24"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11025"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/25"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11026"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/26"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11027"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/27"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11028"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/28"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11029"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/29"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11030"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/30"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11031"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/31"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11032"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/32"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11033"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/33"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11034"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/34"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11035"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/35"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11036"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/36"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11037"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/37"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11038"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/38"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11039"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/39"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11040"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/40"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11041"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/41"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11042"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/42"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11043"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/43"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11044"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/44"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11045"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/45"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11046"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/46"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11047"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/47"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11048"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/48"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10601"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/1"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10602"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/2"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10603"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/3"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10604"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/4"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10605"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/5"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10606"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/6"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10607"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/7"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10608"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/8"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10609"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/9"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10610"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/10"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10611"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/11"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10612"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/12"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10613"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/13"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10614"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/14"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10615"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/15"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10616"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/16"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10617"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/17"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10618"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/18"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10619"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/19"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10620"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/20"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10621"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/21"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10622"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/22"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10623"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/23"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10624"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/24"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10625"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/25"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10626"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/26"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10627"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/27"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10628"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/28"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10101"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/1"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10102"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/2"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10103"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/3"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10104"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/4"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10105"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/5"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10106"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/6"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10107"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/7"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10108"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/8"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10109"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/9"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10110"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/10"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10111"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/11"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10112"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/12"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10113"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/13"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10114"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/14"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10115"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/15"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10116"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/16"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10117"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/17"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10118"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/18"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10119"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/19"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10120"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/20"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10121"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/21"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10122"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/22"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10123"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/23"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10124"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/24"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10125"
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/25"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10126"
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/26"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10127"
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/27"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10128"
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/28"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11101"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/1"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11102"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/2"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11103"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/3"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.11104"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/4"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.1"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/1"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))

                        Case "1.3.6.1.4.1.9.2.2.1.1.28.2"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/2"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.3"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/3"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.4"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/4"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.5"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/5"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.6"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/6"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.7"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/7"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.8"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/8"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.9"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/9"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                        Case "1.3.6.1.4.1.9.2.2.1.1.28.10"

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/10"))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString))
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).SubItems.Add(Skvp1))
                    End Select

                    Select Case Skvp1

                        Case "Up"
                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).BackColor = Color.Green)

                        Case Else

                            Me.Invoke(Sub() lstComm.Items(CInt(intcountCOMM)).BackColor = Color.Red)

                    End Select



                Next

                intcountCOMM = intcountCOMM + 1
            Else


            End If

        End If

        Exit Function
Err_:
        Return "ERR_" + Err.Description
        ResList(frmRequestOID.lstUPS)

    End Function

    Private Sub frmCiscoPort_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Me.Invoke(Sub() Me.Cursor = Cursors.WaitCursor)
        Me.Invoke(Sub() Me.Show())
        Me.Invoke(Sub() lstComm.Columns.Clear())
        Me.Invoke(Sub() lstComm.Columns.Add("id", 1, HorizontalAlignment.Left))
        Me.Invoke(Sub() lstComm.Columns.Add("Порт", 140, HorizontalAlignment.Left))
        Me.Invoke(Sub() lstComm.Columns.Add("Описание", 140, HorizontalAlignment.Left))
        Me.Invoke(Sub() lstComm.Columns.Add("В работе", 70, HorizontalAlignment.Left))
        Me.Invoke(Sub() lstComm.Columns.Add("MAC", 100, HorizontalAlignment.Left))

        intcountCOMM = 0
        Me.Invoke(Sub() lstComm.Items.Clear())

        'Dim t As New Threading.Thread(AddressOf LIST_PORT)
        't.Start()
        Me.Invoke(Sub() Me.BeginInvoke(New MethodInvoker(AddressOf LIST_PORT)))
        Me.Invoke(Sub() My.Application.DoEvents())

        Me.Invoke(Sub() Me.Cursor = Cursors.Default)

    End Sub

    Private Sub LIST_PORT()

        '1.3.6.1.2.1.2.2.1.8

        For i = 10000 To 11111

            txtOID = "1.3.6.1.4.1.9.2.2.1.1.28." & i
            txtOIDv = "1.3.6.1.2.1.2.2.1.8." & i
            ' txtOIDm = "1.3.6.1.2.1.2.2.1.6." & i

            Me.BeginInvoke(New MethodInvoker(AddressOf REQUEST_CISCO_PORT))
            Me.Invoke(Sub() My.Application.DoEvents())
        Next



        If lstComm.Items.Count <= 2 Then

            For i = 1 To 100
                txtOID = "1.3.6.1.4.1.9.2.2.1.1.28." & i
                txtOIDv = "1.3.6.1.2.1.2.2.1.8." & i
                ' txtOIDm = "1.3.6.1.2.1.2.2.1.6." & i

                Me.BeginInvoke(New MethodInvoker(AddressOf REQUEST_CISCO_PORT))
                Me.Invoke(Sub() My.Application.DoEvents())

            Next

        End If


    End Sub

    '    Private Sub CISCO_OPROS_PORT()

    '        On Error GoTo err_

    '        frmRequestOID.Cursor = Cursors.WaitCursor
    '        Dim uname As String

    '        intcount4 = 0

    '        Dim host As String = IPDEV
    '        Dim community As String = COMMDEV
    '        Dim requestOid() As String
    '        Dim result As Dictionary(Of Oid, AsnType)
    '        Dim rootOid As Oid = New Oid("1.3.6.1.4.1.9.2.2.1.1.28")
    '        Dim nextOid As Oid = rootOid
    '        Dim keepGoing As Boolean = True
    '        requestOid = New String() {rootOid.ToString()}
    '        Dim snmp As SimpleSnmp = New SimpleSnmp(host, community)
    '        If Not snmp.Valid Then
    '            Console.WriteLine("Invalid hostname/community.")
    '            Exit Sub
    '        End If

    '        While keepGoing
    '            result = snmp.GetNext(SnmpVersion.Ver1, New String() {nextOid.ToString()})
    '            If result IsNot Nothing Then
    '                Dim kvp As KeyValuePair(Of Oid, AsnType)

    '                For Each kvp In result

    '                    If rootOid.IsRootOf(kvp.Key) Then

    '                        If Len(kvp.Value.ToString) = 0 Then

    '                        Else

    '                            lstComm.Items.Add(intcountCOMM + 1)

    '                            Select Case kvp.Key.ToString()

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10001"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/1")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10002"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/2")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10003"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/3")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10004"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/4")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10005"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/5")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10006"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/6")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10007"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/7")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10008"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/8")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10009"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/9")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10010"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/10")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10011"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/11")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10012"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/12")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10013"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/13")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10014"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/14")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10015"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/15")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10016"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/16")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10017"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/17")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10018"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/18")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10019"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/19")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10020"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/20")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10021"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/21")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10022"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/22")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10023"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/23")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10024"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/24")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10025"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/25")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10026"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/26")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10027"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/27")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10028"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/28")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10029"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/29")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10030"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/30")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10031"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/31")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10032"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/32")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10033"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/33")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10034"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/34")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10035"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/35")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10036"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/36")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10037"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/37")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10038"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/38")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10039"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/39")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10040"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/40")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10041"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/41")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10042"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/42")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10043"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/43")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10044"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/44")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10045"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/45")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10046"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/46")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10047"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/47")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10048"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Fa0/48")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                    '#################################################
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11001"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/1")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11002"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/2")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11003"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/3")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11004"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/4")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11005"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/5")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11006"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/6")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11007"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/7")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11008"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/8")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11009"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/9")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11010"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/10")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11011"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/11")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11012"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/12")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11013"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/13")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11014"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/14")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11015"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/15")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11016"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/16")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11017"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/17")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11018"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/18")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11019"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/19")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11020"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/20")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11021"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/21")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11022"
    '                                    '1.3.6.1.4.1.9.2.2.1.1.28.11022

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/22")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11023"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/23")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11024"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/24")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11025"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/25")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11026"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/26")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11027"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/27")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11028"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/28")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11029"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/29")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11030"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/30")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11031"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/31")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11032"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/32")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11033"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/33")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11034"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/34")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11035"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/35")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11036"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/36")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11037"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/37")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11038"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/38")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11039"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/39")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11040"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/40")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11041"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/41")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11042"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/42")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11043"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/43")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11044"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/44")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11045"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/45")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11046"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/46")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11047"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/47")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11048"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/48")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10601"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/1")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10602"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/2")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10603"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/3")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10604"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/4")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10605"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/5")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10606"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/6")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10607"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/7")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10608"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/8")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10609"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/9")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10610"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/10")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10611"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/11")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10612"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/12")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10613"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/13")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10614"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/14")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10615"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/15")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10616"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/16")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10617"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/17")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10618"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/18")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10619"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/19")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10620"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/20")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10621"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/21")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10622"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/22")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10623"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/23")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10624"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/24")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10625"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/25")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10626"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/26")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10627"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/27")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10628"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi2/0/28")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10101"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/1")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10102"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/2")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10103"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/3")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10104"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/4")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10105"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/5")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10106"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/6")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10107"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/7")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10108"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/8")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10109"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/9")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10110"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/10")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10111"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/11")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10112"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/12")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10113"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/13")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10114"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/14")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10115"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/15")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10116"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/16")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10117"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/17")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10118"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/18")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10119"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/19")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10120"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/20")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10121"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/21")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10122"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/22")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10123"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/23")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10124"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/24")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10125"
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/25")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10126"
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/26")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10127"
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/27")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10128"
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/28")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11101"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/1")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11102"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/2")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11103"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/3")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.11104"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi3/0/4")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.1"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/1")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.2"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/2")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.3"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/3")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.4"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/4")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.5"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/5")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.6"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/6")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.7"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/7")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.8"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/8")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.9"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/9")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)
    '                                Case "1.3.6.1.4.1.9.2.2.1.1.28.10"

    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add("Gi1/0/10")
    '                                    lstComm.Items(CInt(intcountCOMM)).SubItems.Add(kvp.Value.ToString)

    '                            End Select

    '                            intcountCOMM = intcountCOMM + 1

    '                        End If
    '                        nextOid = kvp.Key
    '                    Else
    '                        keepGoing = False
    '                    End If

    '                Next
    '            Else

    '                keepGoing = False
    '            End If

    '        End While


    '        frmRequestOID.Cursor = Cursors.Default
    '        Exit Sub
    'err_:

    '        frmRequestOID.Cursor = Cursors.Default
    '        MsgBox(Err.Description)

    '    End Sub


End Class